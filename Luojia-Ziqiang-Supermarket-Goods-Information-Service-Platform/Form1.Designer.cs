namespace Luojia_Ziqiang_Supermarket_Goods_Information_Service_Platform
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.view_btn = new System.Windows.Forms.Button();
            this.view_info_btn = new System.Windows.Forms.Button();
            this.change_info_btn = new System.Windows.Forms.Button();
            this.submit_feedback_btn = new System.Windows.Forms.Button();
            this.welcome_notice = new System.Windows.Forms.Label();
            this.exit_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // view_btn
            // 
            this.view_btn.Location = new System.Drawing.Point(76, 108);
            this.view_btn.Name = "view_btn";
            this.view_btn.Size = new System.Drawing.Size(107, 32);
            this.view_btn.TabIndex = 0;
            this.view_btn.Text = "查看商品";
            this.view_btn.UseVisualStyleBackColor = true;
            this.view_btn.Click += new System.EventHandler(this.view_btn_Click);
            // 
            // view_info_btn
            // 
            this.view_info_btn.Location = new System.Drawing.Point(76, 178);
            this.view_info_btn.Name = "view_info_btn";
            this.view_info_btn.Size = new System.Drawing.Size(107, 32);
            this.view_info_btn.TabIndex = 1;
            this.view_info_btn.Text = "查看个人信息";
            this.view_info_btn.UseVisualStyleBackColor = true;
            this.view_info_btn.Click += new System.EventHandler(this.view_info_btn_Click);
            // 
            // change_info_btn
            // 
            this.change_info_btn.Location = new System.Drawing.Point(76, 248);
            this.change_info_btn.Name = "change_info_btn";
            this.change_info_btn.Size = new System.Drawing.Size(107, 32);
            this.change_info_btn.TabIndex = 2;
            this.change_info_btn.Text = "更改个人信息";
            this.change_info_btn.UseVisualStyleBackColor = true;
            this.change_info_btn.Click += new System.EventHandler(this.change_info_btn_Click);
            // 
            // submit_feedback_btn
            // 
            this.submit_feedback_btn.Location = new System.Drawing.Point(76, 318);
            this.submit_feedback_btn.Name = "submit_feedback_btn";
            this.submit_feedback_btn.Size = new System.Drawing.Size(107, 32);
            this.submit_feedback_btn.TabIndex = 3;
            this.submit_feedback_btn.Text = "提交反馈";
            this.submit_feedback_btn.UseVisualStyleBackColor = true;
            this.submit_feedback_btn.Click += new System.EventHandler(this.submit_feedback_btn_Click);
            // 
            // welcome_notice
            // 
            this.welcome_notice.AutoSize = true;
            this.welcome_notice.Location = new System.Drawing.Point(35, 58);
            this.welcome_notice.Name = "welcome_notice";
            this.welcome_notice.Size = new System.Drawing.Size(65, 20);
            this.welcome_notice.TabIndex = 4;
            this.welcome_notice.Text = "欢迎你！";
            // 
            // exit_btn
            // 
            this.exit_btn.Location = new System.Drawing.Point(76, 391);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(107, 32);
            this.exit_btn.TabIndex = 5;
            this.exit_btn.Text = "退出";
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(274, 494);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.welcome_notice);
            this.Controls.Add(this.submit_feedback_btn);
            this.Controls.Add(this.change_info_btn);
            this.Controls.Add(this.view_info_btn);
            this.Controls.Add(this.view_btn);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button view_btn;
        private System.Windows.Forms.Button view_info_btn;
        private System.Windows.Forms.Button change_info_btn;
        private System.Windows.Forms.Button submit_feedback_btn;
        private System.Windows.Forms.Label welcome_notice;
        private System.Windows.Forms.Button exit_btn;
    }
}

