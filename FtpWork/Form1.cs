using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace FtpWork
{
    public partial class MainForm : Form
    {
        SftpClient m_sftpClient;
        bool connected;

        public MainForm()
        {
            InitializeComponent();
            
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

            try
            {
                foreach (var item in listLocalFile.SelectedItems)
                {
                    Stream fileStream = new FileStream(lblLocalDirPath.Text + "/" + item.ToString(), FileMode.Open);
                    m_sftpClient.UploadFile(fileStream, lblRemoteDirPath.Text + "/" + item.ToString());
                }
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

            try
            {
                foreach (var item in listRemoteFile.SelectedItems)
                {
                    Stream fileStream = File.Create(lblLocalDirPath.Text + "/" + item.ToString());
                    m_sftpClient.DownloadFile(lblRemoteDirPath.Text + "/" + item.ToString(), fileStream);
                }
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
                    m_sftpClient.ChangeDirectory("/home/sujin");
                    lblRemoteDirPath.Text = "/home/sujin";
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
                        String FileSize = entry.Length.ToString() + "B";

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
                String FileNameOnly = File.Name.Substring(0, File.Name.Length - 4);
                String FullFileName = File.FullName;
                String FileSize = File.Length.ToString() + "B";

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
    }
}
