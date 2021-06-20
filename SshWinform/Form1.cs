using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using System.Threading;

namespace SshWinform
{
    public partial class Form1 : Form
    {
        SshClient cSSH_Command;
        ShellStream Command_sShell;
        Thread Command_thread;

        public Form1()
        {
            InitializeComponent();
        }

        private void txtSshCmd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar != (char)Keys.Return)
            {
                return;
            }
            if(txtSshCmd.Text == "")
            {
                return;
            }

            if (cSSH_Command != null)
            {
                if (cSSH_Command.IsConnected)
                {
                    try
                    {
                        string output = cSSH_Command.CreateCommand(txtSshCmd.Text).Execute();
                        string new_output = output.Replace("\n", Environment.NewLine);
                        txtSshText.AppendText(new_output);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }

                    txtSshCmd.Clear();
                }
            }

        }

        private void btnSshConnect_Click(object sender, EventArgs e)
        {
            if (cSSH_Command == null)
            {
                cSSH_Command = Connect_SSH(tbHost.Text, 22, tbUserName.Text, tbPassword.Text);

                Command_sShell = cSSH_Command.CreateShellStream("vt100", 80, 60, 800, 600, 65536);

                if (cSSH_Command.IsConnected)
                {
                    Command_thread = new Thread(() => recvCommSSHData());

                    Command_thread.IsBackground = true;
                    Command_thread.Start();
                }
            }
        }

        private SshClient Connect_SSH(string host, int port, string user, string passwd)
        {
            try
            {
                SshClient cSSH = new SshClient(host, port, user, passwd);

                cSSH.ConnectionInfo.Timeout = TimeSpan.FromSeconds(120);

                cSSH.Connect();

                return cSSH;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        private void recvCommSSHData()
        {
            while (true)
            {
                try
                {
                    if (Command_sShell != null && Command_sShell.DataAvailable)
                    {
                        String strData = Command_sShell.Read();

                        
                        UpdateTextBox(strData);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }

                Thread.Sleep(200);
            }
        }

        private void UpdateTextBox(string data)
        {
            // 호출한 쓰레드가 작업쓰레드인가?
            if (txtSshText.InvokeRequired)
            {
                // 작업쓰레드인 경우
                txtSshText.BeginInvoke(new Action(() => txtSshText.Text = data));
            }
            else
            {
                // UI 쓰레드인 경우
                txtSshText.Text = data;
            }
        }

    }
}
