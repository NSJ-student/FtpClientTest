namespace FtpWork
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.listRemoteFile = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listLocalFile = new System.Windows.Forms.ListBox();
            this.btnLocalToRemote = new System.Windows.Forms.Button();
            this.btnRemoteToLocal = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFtpHost = new System.Windows.Forms.TextBox();
            this.tbFtpUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFtpConnect = new System.Windows.Forms.Button();
            this.lblLocalDirPath = new System.Windows.Forms.Label();
            this.lblRemoteDirPath = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listRemoteFile
            // 
            this.listRemoteFile.FormattingEnabled = true;
            this.listRemoteFile.ItemHeight = 15;
            this.listRemoteFile.Location = new System.Drawing.Point(12, 50);
            this.listRemoteFile.Name = "listRemoteFile";
            this.listRemoteFile.Size = new System.Drawing.Size(578, 94);
            this.listRemoteFile.TabIndex = 0;
            this.listRemoteFile.DoubleClick += new System.EventHandler(this.listRemoteFile_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Remote";
            // 
            // listLocalFile
            // 
            this.listLocalFile.FormattingEnabled = true;
            this.listLocalFile.ItemHeight = 15;
            this.listLocalFile.Location = new System.Drawing.Point(12, 233);
            this.listLocalFile.Name = "listLocalFile";
            this.listLocalFile.Size = new System.Drawing.Size(578, 94);
            this.listLocalFile.TabIndex = 0;
            this.listLocalFile.DoubleClick += new System.EventHandler(this.listLocalFile_DoubleClick);
            // 
            // btnLocalToRemote
            // 
            this.btnLocalToRemote.Enabled = false;
            this.btnLocalToRemote.Location = new System.Drawing.Point(144, 163);
            this.btnLocalToRemote.Name = "btnLocalToRemote";
            this.btnLocalToRemote.Size = new System.Drawing.Size(75, 23);
            this.btnLocalToRemote.TabIndex = 2;
            this.btnLocalToRemote.Text = "△";
            this.btnLocalToRemote.UseVisualStyleBackColor = true;
            this.btnLocalToRemote.Click += new System.EventHandler(this.btnLocalToRemote_Click);
            // 
            // btnRemoteToLocal
            // 
            this.btnRemoteToLocal.Enabled = false;
            this.btnRemoteToLocal.Location = new System.Drawing.Point(392, 163);
            this.btnRemoteToLocal.Name = "btnRemoteToLocal";
            this.btnRemoteToLocal.Size = new System.Drawing.Size(75, 23);
            this.btnRemoteToLocal.TabIndex = 2;
            this.btnRemoteToLocal.Text = "▽";
            this.btnRemoteToLocal.UseVisualStyleBackColor = true;
            this.btnRemoteToLocal.Click += new System.EventHandler(this.btnRemoteToLocal_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Host";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "User Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(319, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            // 
            // tbFtpHost
            // 
            this.tbFtpHost.Location = new System.Drawing.Point(54, 19);
            this.tbFtpHost.Name = "tbFtpHost";
            this.tbFtpHost.Size = new System.Drawing.Size(114, 25);
            this.tbFtpHost.TabIndex = 5;
            this.tbFtpHost.Text = "192.168.0.100";
            // 
            // tbFtpUserName
            // 
            this.tbFtpUserName.Location = new System.Drawing.Point(258, 19);
            this.tbFtpUserName.Name = "tbFtpUserName";
            this.tbFtpUserName.Size = new System.Drawing.Size(55, 25);
            this.tbFtpUserName.TabIndex = 6;
            this.tbFtpUserName.Text = "sujin";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(397, 19);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(55, 25);
            this.tbPassword.TabIndex = 7;
            this.tbPassword.Text = "aprtmdnpf05!";
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(12, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Local";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFtpConnect);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbFtpUserName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbFtpHost);
            this.panel1.Location = new System.Drawing.Point(12, 354);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 61);
            this.panel1.TabIndex = 8;
            // 
            // btnFtpConnect
            // 
            this.btnFtpConnect.Location = new System.Drawing.Point(477, 19);
            this.btnFtpConnect.Name = "btnFtpConnect";
            this.btnFtpConnect.Size = new System.Drawing.Size(84, 25);
            this.btnFtpConnect.TabIndex = 8;
            this.btnFtpConnect.Text = "CONNECT";
            this.btnFtpConnect.UseVisualStyleBackColor = true;
            this.btnFtpConnect.Click += new System.EventHandler(this.btnFtpConnect_Click);
            // 
            // lblLocalDirPath
            // 
            this.lblLocalDirPath.AutoSize = true;
            this.lblLocalDirPath.Location = new System.Drawing.Point(101, 205);
            this.lblLocalDirPath.Name = "lblLocalDirPath";
            this.lblLocalDirPath.Size = new System.Drawing.Size(52, 15);
            this.lblLocalDirPath.TabIndex = 9;
            this.lblLocalDirPath.Text = "D:/test";
            // 
            // lblRemoteDirPath
            // 
            this.lblRemoteDirPath.AutoSize = true;
            this.lblRemoteDirPath.Location = new System.Drawing.Point(101, 23);
            this.lblRemoteDirPath.Name = "lblRemoteDirPath";
            this.lblRemoteDirPath.Size = new System.Drawing.Size(0, 15);
            this.lblRemoteDirPath.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 642);
            this.Controls.Add(this.lblRemoteDirPath);
            this.Controls.Add(this.lblLocalDirPath);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRemoteToLocal);
            this.Controls.Add(this.btnLocalToRemote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listLocalFile);
            this.Controls.Add(this.listRemoteFile);
            this.Name = "MainForm";
            this.Text = "Uploader";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listRemoteFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listLocalFile;
        private System.Windows.Forms.Button btnLocalToRemote;
        private System.Windows.Forms.Button btnRemoteToLocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbFtpHost;
        private System.Windows.Forms.TextBox tbFtpUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFtpConnect;
        private System.Windows.Forms.Label lblLocalDirPath;
        private System.Windows.Forms.Label lblRemoteDirPath;
    }
}

