namespace MMNOSSD_Final
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.loginLbl = new System.Windows.Forms.Label();
            this.userLbl = new System.Windows.Forms.Label();
            this.passLbl = new System.Windows.Forms.Label();
            this.userTxtBx = new System.Windows.Forms.TextBox();
            this.passTxtBx = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.registerLink = new System.Windows.Forms.LinkLabel();
            this.adminChkBx = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginLbl
            // 
            this.loginLbl.AutoSize = true;
            this.loginLbl.Font = new System.Drawing.Font("Unispace", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginLbl.Location = new System.Drawing.Point(183, 18);
            this.loginLbl.Name = "loginLbl";
            this.loginLbl.Size = new System.Drawing.Size(59, 19);
            this.loginLbl.TabIndex = 0;
            this.loginLbl.Text = "Login";
            // 
            // userLbl
            // 
            this.userLbl.AutoSize = true;
            this.userLbl.Font = new System.Drawing.Font("Unispace", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLbl.Location = new System.Drawing.Point(34, 97);
            this.userLbl.Name = "userLbl";
            this.userLbl.Size = new System.Drawing.Size(63, 14);
            this.userLbl.TabIndex = 1;
            this.userLbl.Text = "Username";
            // 
            // passLbl
            // 
            this.passLbl.AutoSize = true;
            this.passLbl.Font = new System.Drawing.Font("Unispace", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passLbl.Location = new System.Drawing.Point(36, 152);
            this.passLbl.Name = "passLbl";
            this.passLbl.Size = new System.Drawing.Size(63, 14);
            this.passLbl.TabIndex = 2;
            this.passLbl.Text = "Password";
            // 
            // userTxtBx
            // 
            this.userTxtBx.Location = new System.Drawing.Point(130, 91);
            this.userTxtBx.Name = "userTxtBx";
            this.userTxtBx.Size = new System.Drawing.Size(186, 20);
            this.userTxtBx.TabIndex = 3;
            // 
            // passTxtBx
            // 
            this.passTxtBx.Location = new System.Drawing.Point(130, 149);
            this.passTxtBx.Name = "passTxtBx";
            this.passTxtBx.PasswordChar = '•';
            this.passTxtBx.Size = new System.Drawing.Size(186, 20);
            this.passTxtBx.TabIndex = 4;
            // 
            // loginBtn
            // 
            this.loginBtn.Font = new System.Drawing.Font("Unispace", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Location = new System.Drawing.Point(130, 222);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 5;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // registerLink
            // 
            this.registerLink.AutoSize = true;
            this.registerLink.Font = new System.Drawing.Font("Unispace", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerLink.Location = new System.Drawing.Point(127, 248);
            this.registerLink.Name = "registerLink";
            this.registerLink.Size = new System.Drawing.Size(119, 14);
            this.registerLink.TabIndex = 6;
            this.registerLink.TabStop = true;
            this.registerLink.Text = "First Time User?";
            this.registerLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.registerLink_LinkClicked);
            // 
            // adminChkBx
            // 
            this.adminChkBx.AutoSize = true;
            this.adminChkBx.Font = new System.Drawing.Font("Unispace", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminChkBx.Location = new System.Drawing.Point(219, 226);
            this.adminChkBx.Name = "adminChkBx";
            this.adminChkBx.Size = new System.Drawing.Size(124, 18);
            this.adminChkBx.TabIndex = 7;
            this.adminChkBx.Text = "Check if Admin";
            this.adminChkBx.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(370, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 280);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 341);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.adminChkBx);
            this.Controls.Add(this.registerLink);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passTxtBx);
            this.Controls.Add(this.userTxtBx);
            this.Controls.Add(this.passLbl);
            this.Controls.Add(this.userLbl);
            this.Controls.Add(this.loginLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Target Car Rental Service: Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginLbl;
        private System.Windows.Forms.Label userLbl;
        private System.Windows.Forms.Label passLbl;
        private System.Windows.Forms.TextBox userTxtBx;
        private System.Windows.Forms.TextBox passTxtBx;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.LinkLabel registerLink;
        private System.Windows.Forms.CheckBox adminChkBx;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}