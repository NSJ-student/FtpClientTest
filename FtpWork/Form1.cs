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

            foreach (var item in listLocalFile.SelectedItems)
            {
                Stream fileStream = new FileStream(lblLocalDirPath.Text + "/" + item.ToString(), FileMode.Open);
                m_sftpClient.UploadFile(fileStream, lblRemoteDirPath.Text + "/" + item.ToString());
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

            foreach(var item in listRemoteFile.SelectedItems)
            {
                Stream fileStream = File.Create(lblLocalDirPath.Text + "/" + item.ToString());
                m_sftpClient.DownloadFile(lblRemoteDirPath.Text + "/" + item.ToString(), fileStream);
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

                    btnFtpConnect.Enabled = false;
                    btnRemoteToLocal.Enabled = true;
                    btnLocalToRemote.Enabled = true;
                }
                else
                {
                    Console.WriteLine("connect failed");
                    btnFtpConnect.Enabled = true;
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
            foreach (var entry in m_sftpClient.ListDirectory(lblRemoteDirPath.Text))
            {
                if (!entry.IsDirectory)
                {
                    listRemoteFile.Items.Add(entry.Name);
                }
            }
        }

        public void loadLocalDirList()
        {
            listLocalFile.Items.Clear();
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(lblLocalDirPath.Text);
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                String FileNameOnly = File.Name.Substring(0, File.Name.Length - 4);
                String FullFileName = File.FullName;

                listLocalFile.Items.Add(FileNameOnly);
            }
        }

        private void listRemoteFile_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listLocalFile_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
