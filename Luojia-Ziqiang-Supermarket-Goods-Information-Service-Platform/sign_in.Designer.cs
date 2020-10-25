namespace Luojia_Ziqiang_Supermarket_Goods_Information_Service_Platform
{
    partial class sign_in
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
            this.welcome_notice = new System.Windows.Forms.Label();
            this.account_notice = new System.Windows.Forms.Label();
            this.account_input = new System.Windows.Forms.TextBox();
            this.password_input = new System.Windows.Forms.TextBox();
            this.password_notice = new System.Windows.Forms.Label();
            this.sign_in_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcome_notice
            // 
            this.welcome_notice.AutoSize = true;
            this.welcome_notice.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.welcome_notice.Location = new System.Drawing.Point(91, 78);
            this.welcome_notice.Name = "welcome_notice";
            this.welcome_notice.Size = new System.Drawing.Size(170, 22);
            this.welcome_notice.TabIndex = 0;
            this.welcome_notice.Text = "珞珈自强超市欢迎您！";
            // 
            // account_notice
            // 
            this.account_notice.Location = new System.Drawing.Point(78, 156);
            this.account_notice.Name = "account_notice";
            this.account_notice.Size = new System.Drawing.Size(196, 24);
            this.account_notice.TabIndex = 0;
            this.account_notice.Text = "请输入13位学号：";
            // 
            // account_input
            // 
            this.account_input.Location = new System.Drawing.Point(82, 183);
            this.account_input.Name = "account_input";
            this.account_input.Size = new System.Drawing.Size(192, 26);
            this.account_input.TabIndex = 1;
            // 
            // password_input
            // 
            this.password_input.Location = new System.Drawing.Point(82, 250);
            this.password_input.Name = "password_input";
            this.password_input.PasswordChar = '*';
            this.password_input.Size = new System.Drawing.Size(192, 26);
            this.password_input.TabIndex = 2;
            // 
            // password_notice
            // 
            this.password_notice.AutoSize = true;
            this.password_notice.Location = new System.Drawing.Point(78, 227);
            this.password_notice.Name = "password_notice";
            this.password_notice.Size = new System.Drawing.Size(93, 20);
            this.password_notice.TabIndex = 3;
            this.password_notice.Text = "请输入密码：";
            // 
            // sign_in_btn
            // 
            this.sign_in_btn.Location = new System.Drawing.Point(136, 306);
            this.sign_in_btn.Name = "sign_in_btn";
            this.sign_in_btn.Size = new System.Drawing.Size(78, 31);
            this.sign_in_btn.TabIndex = 4;
            this.sign_in_btn.Text = "登录";
            this.sign_in_btn.UseVisualStyleBackColor = true;
            this.sign_in_btn.Click += new System.EventHandler(this.sign_in_btn_Click);
            // 
            // sign_in
            // 
            this.AcceptButton = this.sign_in_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(370, 441);
            this.Controls.Add(this.sign_in_btn);
            this.Controls.Add(this.password_notice);
            this.Controls.Add(this.password_input);
            this.Controls.Add(this.account_input);
            this.Controls.Add(this.account_notice);
            this.Controls.Add(this.welcome_notice);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "sign_in";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录到您的账户";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.sign_in_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcome_notice;
        private System.Windows.Forms.Label account_notice;
        private System.Windows.Forms.TextBox account_input;
        private System.Windows.Forms.TextBox password_input;
        private System.Windows.Forms.Label password_notice;
        private System.Windows.Forms.Button sign_in_btn;
    }
}