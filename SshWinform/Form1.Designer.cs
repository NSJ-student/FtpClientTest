namespace SshWinform
{
    partial class Form1
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
            this.txtSshText = new System.Windows.Forms.TextBox();
            this.txtSshCmd = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSshConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSshText
            // 
            this.txtSshText.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSshText.Location = new System.Drawing.Point(12, 84);
            this.txtSshText.Multiline = true;
            this.txtSshText.Name = "txtSshText";
            this.txtSshText.ReadOnly = true;
            this.txtSshText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSshText.Size = new System.Drawing.Size(642, 360);
            this.txtSshText.TabIndex = 0;
            this.txtSshText.WordWrap = false;
            // 
            // txtSshCmd
            // 
            this.txtSshCmd.Location = new System.Drawing.Point(12, 450);
            this.txtSshCmd.Name = "txtSshCmd";
            this.txtSshCmd.Size = new System.Drawing.Size(642, 25);
            this.txtSshCmd.TabIndex = 1;
            this.txtSshCmd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSshCmd_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSshConnect);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbUserName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbHost);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 61);
            this.panel1.TabIndex = 9;
            // 
            // btnSshConnect
            // 
            this.btnSshConnect.Location = new System.Drawing.Point(533, 17);
            this.btnSshConnect.Name = "btnSshConnect";
            this.btnSshConnect.Size = new System.Drawing.Size(94, 25);
            this.btnSshConnect.TabIndex = 8;
            this.btnSshConnect.Text = "CONNECT";
            this.btnSshConnect.UseVisualStyleBackColor = true;
            this.btnSshConnect.Click += new System.EventHandler(this.btnSshConnect_Click);
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
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(407, 19);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(107, 25);
            this.tbPassword.TabIndex = 7;
            this.tbPassword.Text = "aprtmdnpf05!";
            this.tbPassword.UseSystemPasswordChar = true;
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
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(258, 19);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(60, 25);
            this.tbUserName.TabIndex = 6;
            this.tbUserName.Text = "sujin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(54, 19);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(114, 25);
            this.tbHost.TabIndex = 5;
            this.tbHost.Text = "192.168.0.100";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 487);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSshCmd);
            this.Controls.Add(this.txtSshText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SSH Client";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSshCmd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSshConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.TextBox txtSshText;
    }
}

