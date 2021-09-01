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
            this.btnSshConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLogClear = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSshText
            // 
            this.txtSshText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSshText.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSshText.Location = new System.Drawing.Point(3, 38);
            this.txtSshText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSshText.Multiline = true;
            this.txtSshText.Name = "txtSshText";
            this.txtSshText.ReadOnly = true;
            this.txtSshText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSshText.Size = new System.Drawing.Size(707, 373);
            this.txtSshText.TabIndex = 0;
            this.txtSshText.WordWrap = false;
            // 
            // txtSshCmd
            // 
            this.txtSshCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSshCmd.Location = new System.Drawing.Point(3, 415);
            this.txtSshCmd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSshCmd.Name = "txtSshCmd";
            this.txtSshCmd.Size = new System.Drawing.Size(707, 21);
            this.txtSshCmd.TabIndex = 1;
            this.txtSshCmd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSshCmd_KeyPress);
            // 
            // btnSshConnect
            // 
            this.btnSshConnect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSshConnect.Location = new System.Drawing.Point(515, 2);
            this.btnSshConnect.Margin = new System.Windows.Forms.Padding(50, 2, 3, 2);
            this.btnSshConnect.Name = "btnSshConnect";
            this.btnSshConnect.Size = new System.Drawing.Size(87, 28);
            this.btnSshConnect.TabIndex = 8;
            this.btnSshConnect.Text = "CONNECT";
            this.btnSshConnect.UseVisualStyleBackColor = true;
            this.btnSshConnect.Click += new System.EventHandler(this.btnSshConnect_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Host";
            // 
            // tbPassword
            // 
            this.tbPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbPassword.Location = new System.Drawing.Point(368, 5);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(94, 21);
            this.tbPassword.TabIndex = 7;
            this.tbPassword.Text = "aprtmdnpf05!";
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "User Name";
            // 
            // tbUserName
            // 
            this.tbUserName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbUserName.Location = new System.Drawing.Point(234, 5);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(53, 21);
            this.tbUserName.TabIndex = 6;
            this.tbUserName.Text = "sujin";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            // 
            // tbHost
            // 
            this.tbHost.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbHost.Location = new System.Drawing.Point(46, 5);
            this.tbHost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(100, 21);
            this.tbHost.TabIndex = 5;
            this.tbHost.Text = "192.168.0.100";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtSshCmd, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSshText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(713, 438);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.tbHost);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.tbUserName);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.tbPassword);
            this.flowLayoutPanel1.Controls.Add(this.btnSshConnect);
            this.flowLayoutPanel1.Controls.Add(this.btnLogClear);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(707, 30);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // btnLogClear
            // 
            this.btnLogClear.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLogClear.Location = new System.Drawing.Point(615, 2);
            this.btnLogClear.Margin = new System.Windows.Forms.Padding(10, 2, 3, 2);
            this.btnLogClear.Name = "btnLogClear";
            this.btnLogClear.Size = new System.Drawing.Size(61, 28);
            this.btnLogClear.TabIndex = 8;
            this.btnLogClear.Text = "CLEAR";
            this.btnLogClear.UseVisualStyleBackColor = true;
            this.btnLogClear.Click += new System.EventHandler(this.btnLogClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 438);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SSH Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtSshCmd;
        private System.Windows.Forms.Button btnSshConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.TextBox txtSshText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnLogClear;
    }
}

