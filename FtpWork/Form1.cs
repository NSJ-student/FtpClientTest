using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace FtpWork
{
    public partial class MainForm : Form
    {
        SftpClient m_sftpClient;
        Thread uploadThread;
        Thread downloadThread;
        ulong fileLength;
        List<ProgressBar> progresList;
        List<ListViewItem> selectedItems;
        ProgressBar currentProgress;
        bool connected;

        public MainForm()
        {
            InitializeComponent();

            progresList = new List<ProgressBar>();
            selectedItems = new List<ListViewItem>();
            
            listLocalFile.SmallImageList = iconList;
            listRemoteFile.SmallImageList = iconList;
            
            loadLocalDirList();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLocalToRemote_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                return;
            }
            if (listLocalFile.SelectedItems.Count == 0)
            {
                return;
            }

            selectedItems.Clear();
            foreach (ListViewItem item in listLocalFile.SelectedItems)
            {
                selectedItems.Add(item);
            }
            progresList.Clear();
            foreach (ListViewItem item in selectedItems)
            {
                progresList.Add(addProgress(item.Text, lblLocalDirPath.Text, lblRemoteDirPath.Text));
            }
            
            try
            {
                uploadThread = new Thread(() => uploadThreadFunc());

                uploadThread.IsBackground = true;
                uploadThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            loadRemoteDirList();
        }

        private void btnRemoteToLocal_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                return;
            }
            if(listRemoteFile.SelectedItems.Count==0)
            {
                return;
            }

            selectedItems.Clear();
            foreach(ListViewItem item in listRemoteFile.SelectedItems)
            {
                selectedItems.Add(item);
            }
            progresList.Clear();
            foreach (ListViewItem item in selectedItems)
            {
                progresList.Add(addProgress(item.Text, lblRemoteDirPath.Text, lblLocalDirPath.Text));
            }

            try
            {
                downloadThread = new Thread(() => downloadThreadFunc());

                downloadThread.IsBackground = true;
                downloadThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            loadLocalDirList();
        }

        private void btnFtpConnect_Click(object sender, EventArgs e)
        {
            try
            {
                m_sftpClient = new SftpClient(tbFtpHost.Text, 22, tbFtpUserName.Text, tbPassword.Text);
                m_sftpClient.KeepAliveInterval = TimeSpan.FromSeconds(60);
                m_sftpClient.ConnectionInfo.Timeout = TimeSpan.FromMinutes(180);
                m_sftpClient.OperationTimeout = TimeSpan.FromMinutes(180);
                m_sftpClient.Connect();
                connected = m_sftpClient.IsConnected;
                if (connected)
                {
                    lblRemoteDirPath.Text = m_sftpClient.WorkingDirectory;
                    loadRemoteDirList();
                
                    btnRemoteToLocal.Enabled = true;
                    btnLocalToRemote.Enabled = true;
                }
                else
                {
                    Console.WriteLine("connect failed");
                    btnRemoteToLocal.Enabled = false;
                    btnLocalToRemote.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void loadRemoteDirList()
        {
            if(!connected)
            {
                return;
            }

            listRemoteFile.Items.Clear();
            
            try
            {
                foreach (var entry in m_sftpClient.ListDirectory(lblRemoteDirPath.Text))
                {
                    if (entry.IsDirectory)
                    {
                        String FileNameOnly = entry.Name;

                        string[] items = new string[] { FileNameOnly, "" };
                        ListViewItem lvi = new ListViewItem(items, 1);
                        listRemoteFile.Items.Add(lvi);
                    }
                }
                foreach (var entry in m_sftpClient.ListDirectory(lblRemoteDirPath.Text))
                {
                    if (entry.IsRegularFile)
                    {
                        String FileNameOnly = entry.Name;
                        String FileSize = entry.Length.ToString("#,##0") + "B";

                        string[] items = new string[] { FileNameOnly, FileSize };
                        ListViewItem lvi = new ListViewItem(items, 0);
                        listRemoteFile.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void loadLocalDirList()
        {
            listLocalFile.Items.Clear();
            
            listLocalFile.Items.Add(new ListViewItem(new string[] { "..", "" }, 1));

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(lblLocalDirPath.Text);
            foreach (System.IO.DirectoryInfo Dir in di.GetDirectories())
            {
                String FileNameOnly = Dir.Name;

                string[] items = new string[] { FileNameOnly, "" };
                ListViewItem lvi = new ListViewItem(items, 1);
                listLocalFile.Items.Add(lvi);
            }
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                String FileNameOnly = File.Name;
                String FullFileName = File.FullName;
                String FileSize = File.Length.ToString("#,##0") + "B";

                string[] items = new string[] { FileNameOnly, FileSize };
                ListViewItem lvi = new ListViewItem(items, 0);
                listLocalFile.Items.Add(lvi);
            }
        }

        private void listRemoteFile_DoubleClick(object sender, EventArgs e)
        {
            if (listRemoteFile.SelectedItems[0].Text == ".")
            {
                loadRemoteDirList();
                return;
            }
            if (listRemoteFile.SelectedItems[0].Text == "..")
            {
                lblRemoteDirPath.Text = get_parent_dir_path(lblRemoteDirPath.Text);
                loadRemoteDirList();
                return;
            }
            if (listRemoteFile.SelectedItems[0].ImageIndex == 1)
            {
                lblRemoteDirPath.Text += "/" + listRemoteFile.SelectedItems[0].Text;
                loadRemoteDirList();
            }
        }

        private void listLocalFile_DoubleClick(object sender, EventArgs e)
        {
            if (listLocalFile.SelectedItems[0].Text == ".")
            {
                loadLocalDirList();
                return;
            }
            if (listLocalFile.SelectedItems[0].Text == "..")
            {
                lblLocalDirPath.Text = get_parent_dir_path(lblLocalDirPath.Text);
                loadLocalDirList();
                return;
            }
            if (listLocalFile.SelectedItems[0].ImageIndex == 1)
            {
                lblLocalDirPath.Text += "/" + listLocalFile.SelectedItems[0].Text;
                loadLocalDirList();
            }
        }

        private string get_parent_dir_path(string path)
        {
            // notice that i used two separators windows style "\\" and linux "/" (for bad formed paths)
            // We make sure to remove extra unneeded characters.
            string trim = path.TrimEnd('/', '\\');
            int index = trim.LastIndexOfAny(new char[] { '\\', '/' });

            // now if index is >= 0 that means we have at least one parent directory, otherwise the given path is the root most.
            if (index >= 0)
            {
                if(path.Remove(index).Last() == ':')
                {
                    return path.Remove(index) + "/";
                }
                else
                {
                    return path.Remove(index);
                }
            }
            else
            {
                return path;
            }
        }

        private void btnStatusClear_Click(object sender, EventArgs e)
        {
            listProgressStatus.Items.Clear();
            listProgressStatus.Controls.Clear();
        }
        
        private void downloadThreadFunc()
        {
            try
            {
                int current = 0;
                foreach (ListViewItem item in selectedItems)
                {
                    string localPath = lblLocalDirPath.Text + "/" + item.Text;
                    string remotePath = lblRemoteDirPath.Text + "/" + item.Text;
                    Stream fileStream = File.Create(localPath);

                    SftpFile file = m_sftpClient.Get(remotePath);
                    long file_size = file.Attributes.Size;
                    InitProgresBar(progresList[current], (ulong)file_size);
                    m_sftpClient.DownloadFile(remotePath, fileStream, UpdateProgresBar);
                    fileStream.Close();
                    current++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            this.Invoke(new Action(loadLocalDirList));
        }

        private void uploadThreadFunc()
        {
            try
            {
                int current = 0;
                foreach (ListViewItem item in selectedItems)
                {
                    string localPath = lblLocalDirPath.Text + "/" + item.Text;
                    string remotePath = lblRemoteDirPath.Text + "/" + item.Text;
                    Stream fileStream = new FileStream(localPath, FileMode.Open);

                    InitProgresBar(progresList[current], (ulong)fileStream.Length);
                    m_sftpClient.UploadFile(fileStream, remotePath, UpdateProgresBar);
                    fileStream.Close();
                    current++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            this.Invoke(new Action(loadRemoteDirList));
        }

        private ProgressBar addProgress(string fileName, string source, string dest)
        {
            ListViewItem lvi = new ListViewItem();
            ProgressBar pb = new ProgressBar();
            lvi.SubItems[0].Text = "ddd";
            lvi.SubItems.Add(fileName);
            lvi.SubItems.Add(source);
            lvi.SubItems.Add(dest);
            listProgressStatus.Items.Add(lvi);

            Rectangle r = lvi.SubItems[0].Bounds;
            pb.SetBounds(r.X, r.Y, 100, r.Height);
            pb.Minimum = 0;
            pb.Maximum = 100;
            pb.Value = 0;
            pb.Parent = listProgressStatus;
            listProgressStatus.Controls.Add(pb);

            return pb;
        }

        private void InitProgresBar(ProgressBar progress, ulong max)
        {
            fileLength = max;
            currentProgress = progress;
            // Update progress bar on foreground thread
            progress.Invoke(
                (MethodInvoker)delegate { progress.Value = (int)0; progress.Maximum = (int)100; });
        }

        private void UpdateProgresBar(ulong uploaded)
        {
            int percent = (int)((uploaded * 100) / fileLength);
            // Update progress bar on foreground thread
            currentProgress.Invoke(
                (MethodInvoker)delegate { currentProgress.Value = percent; });
        }

        private void listProgressStatus_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if(e.ColumnIndex==0)
            {
                e.NewWidth = listProgressStatus.Columns[e.ColumnIndex].Width;
                e.Cancel = true;
            }
        }

        private void btnRemoteFileDelete_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                return;
            }
            if (listRemoteFile.SelectedItems.Count == 0)
            {
                return;
            }
            
            try
            {
                foreach (ListViewItem item in listRemoteFile.SelectedItems)
                {
                    string remotePath = lblRemoteDirPath.Text + "/" + item.Text;
                    m_sftpClient.Delete(remotePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            loadRemoteDirList();
        }

        private void btnLocalFileDelete_Click(object sender, EventArgs e)
        {
            if (listLocalFile.SelectedItems.Count == 0)
            {
                return;
            }
            
            foreach (ListViewItem item in listLocalFile.SelectedItems)
            {
                string localPath = lblLocalDirPath.Text + "/" + item.Text;
                File.Delete(localPath);
            }
            
            loadLocalDirList();
        }
    }
}
