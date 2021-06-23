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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
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
            this.listRemoteFile = new System.Windows.Forms.ListView();
            this.columnRemoteName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnRemoteSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listLocalFile = new System.Windows.Forms.ListView();
            this.columnLocalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLocalSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iconList = new System.Windows.Forms.ImageList(this.components);
            this.listProgressStatus = new System.Windows.Forms.ListView();
            this.progress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.btnStatusClear = new System.Windows.Forms.Button();
            this.btnRemoteFileDelete = new System.Windows.Forms.Button();
            this.btnLocalFileDelete = new System.Windows.Forms.Button();
            this.SrcPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DstPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Remote";
            // 
            // btnLocalToRemote
            // 
            this.btnLocalToRemote.Enabled = false;
            this.btnLocalToRemote.Location = new System.Drawing.Point(377, 172);
            this.btnLocalToRemote.Name = "btnLocalToRemote";
            this.btnLocalToRemote.Size = new System.Drawing.Size(35, 35);
            this.btnLocalToRemote.TabIndex = 2;
            this.btnLocalToRemote.Text = "◁";
            this.btnLocalToRemote.UseVisualStyleBackColor = true;
            this.btnLocalToRemote.Click += new System.EventHandler(this.btnLocalToRemote_Click);
            // 
            // btnRemoteToLocal
            // 
            this.btnRemoteToLocal.Enabled = false;
            this.btnRemoteToLocal.Location = new System.Drawing.Point(377, 293);
            this.btnRemoteToLocal.Name = "btnRemoteToLocal";
            this.btnRemoteToLocal.Size = new System.Drawing.Size(35, 35);
            this.btnRemoteToLocal.TabIndex = 2;
            this.btnRemoteToLocal.Text = "▷";
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
            this.label3.Location = new System.Drawing.Point(198, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "User Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(399, 22);
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
            this.tbFtpUserName.Location = new System.Drawing.Point(282, 19);
            this.tbFtpUserName.Name = "tbFtpUserName";
            this.tbFtpUserName.Size = new System.Drawing.Size(85, 25);
            this.tbFtpUserName.TabIndex = 6;
            this.tbFtpUserName.Text = "sujin";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(477, 19);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(107, 25);
            this.tbPassword.TabIndex = 7;
            this.tbPassword.Text = "aprtmdnpf05!";
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(423, 99);
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
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 61);
            this.panel1.TabIndex = 8;
            // 
            // btnFtpConnect
            // 
            this.btnFtpConnect.Location = new System.Drawing.Point(618, 17);
            this.btnFtpConnect.Name = "btnFtpConnect";
            this.btnFtpConnect.Size = new System.Drawing.Size(126, 25);
            this.btnFtpConnect.TabIndex = 8;
            this.btnFtpConnect.Text = "CONNECT";
            this.btnFtpConnect.UseVisualStyleBackColor = true;
            this.btnFtpConnect.Click += new System.EventHandler(this.btnFtpConnect_Click);
            // 
            // lblLocalDirPath
            // 
            this.lblLocalDirPath.AutoSize = true;
            this.lblLocalDirPath.Location = new System.Drawing.Point(486, 99);
            this.lblLocalDirPath.Name = "lblLocalDirPath";
            this.lblLocalDirPath.Size = new System.Drawing.Size(52, 15);
            this.lblLocalDirPath.TabIndex = 9;
            this.lblLocalDirPath.Text = "D:/test";
            // 
            // lblRemoteDirPath
            // 
            this.lblRemoteDirPath.AutoSize = true;
            this.lblRemoteDirPath.Location = new System.Drawing.Point(101, 99);
            this.lblRemoteDirPath.Name = "lblRemoteDirPath";
            this.lblRemoteDirPath.Size = new System.Drawing.Size(0, 15);
            this.lblRemoteDirPath.TabIndex = 9;
            // 
            // listRemoteFile
            // 
            this.listRemoteFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnRemoteName,
            this.columnRemoteSize});
            this.listRemoteFile.FullRowSelect = true;
            this.listRemoteFile.Location = new System.Drawing.Point(12, 128);
            this.listRemoteFile.Name = "listRemoteFile";
            this.listRemoteFile.Size = new System.Drawing.Size(350, 250);
            this.listRemoteFile.TabIndex = 10;
            this.listRemoteFile.UseCompatibleStateImageBehavior = false;
            this.listRemoteFile.View = System.Windows.Forms.View.Details;
            this.listRemoteFile.DoubleClick += new System.EventHandler(this.listRemoteFile_DoubleClick);
            // 
            // columnRemoteName
            // 
            this.columnRemoteName.Text = "Name";
            this.columnRemoteName.Width = 200;
            // 
            // columnRemoteSize
            // 
            this.columnRemoteSize.Text = "Size";
            this.columnRemoteSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnRemoteSize.Width = 80;
            // 
            // listLocalFile
            // 
            this.listLocalFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnLocalName,
            this.columnLocalSize});
            this.listLocalFile.FullRowSelect = true;
            this.listLocalFile.Location = new System.Drawing.Point(426, 128);
            this.listLocalFile.Name = "listLocalFile";
            this.listLocalFile.Size = new System.Drawing.Size(350, 250);
            this.listLocalFile.TabIndex = 11;
            this.listLocalFile.UseCompatibleStateImageBehavior = false;
            this.listLocalFile.View = System.Windows.Forms.View.Details;
            this.listLocalFile.DoubleClick += new System.EventHandler(this.listLocalFile_DoubleClick);
            // 
            // columnLocalName
            // 
            this.columnLocalName.Text = "Name";
            this.columnLocalName.Width = 200;
            // 
            // columnLocalSize
            // 
            this.columnLocalSize.Text = "Size";
            this.columnLocalSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnLocalSize.Width = 80;
            // 
            // iconList
            // 
            this.iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconList.ImageStream")));
            this.iconList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconList.Images.SetKeyName(0, "file.png");
            this.iconList.Images.SetKeyName(1, "folder.png");
            // 
            // listProgressStatus
            // 
            this.listProgressStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.progress,
            this.FileName,
            this.SrcPath,
            this.DstPath});
            this.listProgressStatus.Location = new System.Drawing.Point(12, 443);
            this.listProgressStatus.Name = "listProgressStatus";
            this.listProgressStatus.Size = new System.Drawing.Size(764, 180);
            this.listProgressStatus.TabIndex = 12;
            this.listProgressStatus.UseCompatibleStateImageBehavior = false;
            this.listProgressStatus.View = System.Windows.Forms.View.Details;
            this.listProgressStatus.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listProgressStatus_ColumnWidthChanging);
            // 
            // progress
            // 
            this.progress.Text = "Progress";
            this.progress.Width = 100;
            // 
            // FileName
            // 
            this.FileName.Text = "Name";
            this.FileName.Width = 150;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(12, 408);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Status";
            // 
            // btnStatusClear
            // 
            this.btnStatusClear.Location = new System.Drawing.Point(701, 408);
            this.btnStatusClear.Name = "btnStatusClear";
            this.btnStatusClear.Size = new System.Drawing.Size(75, 23);
            this.btnStatusClear.TabIndex = 13;
            this.btnStatusClear.Text = "Clear";
            this.btnStatusClear.UseVisualStyleBackColor = true;
            this.btnStatusClear.Click += new System.EventHandler(this.btnStatusClear_Click);
            // 
            // btnRemoteFileDelete
            // 
            this.btnRemoteFileDelete.Location = new System.Drawing.Point(287, 95);
            this.btnRemoteFileDelete.Name = "btnRemoteFileDelete";
            this.btnRemoteFileDelete.Size = new System.Drawing.Size(75, 23);
            this.btnRemoteFileDelete.TabIndex = 14;
            this.btnRemoteFileDelete.Text = "Delete";
            this.btnRemoteFileDelete.UseVisualStyleBackColor = true;
            this.btnRemoteFileDelete.Click += new System.EventHandler(this.btnRemoteFileDelete_Click);
            // 
            // btnLocalFileDelete
            // 
            this.btnLocalFileDelete.Location = new System.Drawing.Point(701, 95);
            this.btnLocalFileDelete.Name = "btnLocalFileDelete";
            this.btnLocalFileDelete.Size = new System.Drawing.Size(75, 23);
            this.btnLocalFileDelete.TabIndex = 14;
            this.btnLocalFileDelete.Text = "Delete";
            this.btnLocalFileDelete.UseVisualStyleBackColor = true;
            this.btnLocalFileDelete.Click += new System.EventHandler(this.btnLocalFileDelete_Click);
            // 
            // SrcPath
            // 
            this.SrcPath.Text = "Source";
            this.SrcPath.Width = 150;
            // 
            // DstPath
            // 
            this.DstPath.Text = "Destination";
            this.DstPath.Width = 150;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 640);
            this.Controls.Add(this.btnLocalFileDelete);
            this.Controls.Add(this.btnRemoteFileDelete);
            this.Controls.Add(this.btnStatusClear);
            this.Controls.Add(this.listProgressStatus);
            this.Controls.Add(this.listLocalFile);
            this.Controls.Add(this.listRemoteFile);
            this.Controls.Add(this.lblRemoteDirPath);
            this.Controls.Add(this.lblLocalDirPath);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRemoteToLocal);
            this.Controls.Add(this.btnLocalToRemote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Uploader";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.ListView listRemoteFile;
        private System.Windows.Forms.ListView listLocalFile;
        private System.Windows.Forms.ColumnHeader columnRemoteName;
        private System.Windows.Forms.ColumnHeader columnRemoteSize;
        private System.Windows.Forms.ColumnHeader columnLocalName;
        private System.Windows.Forms.ColumnHeader columnLocalSize;
        private System.Windows.Forms.ImageList iconList;
        private System.Windows.Forms.ListView listProgressStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStatusClear;
        private System.Windows.Forms.ColumnHeader progress;
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.Button btnRemoteFileDelete;
        private System.Windows.Forms.Button btnLocalFileDelete;
        private System.Windows.Forms.ColumnHeader SrcPath;
        private System.Windows.Forms.ColumnHeader DstPath;
    }
}

