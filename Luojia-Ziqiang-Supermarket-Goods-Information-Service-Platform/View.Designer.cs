namespace Luojia_Ziqiang_Supermarket_Goods_Information_Service_Platform
{
    partial class View
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
            this.submit_order_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // submit_order_btn
            // 
            this.submit_order_btn.Location = new System.Drawing.Point(762, 435);
            this.submit_order_btn.Name = "submit_order_btn";
            this.submit_order_btn.Size = new System.Drawing.Size(88, 28);
            this.submit_order_btn.TabIndex = 0;
            this.submit_order_btn.Text = "提交预订单";
            this.submit_order_btn.UseVisualStyleBackColor = true;
            this.submit_order_btn.Click += new System.EventHandler(this.submit_order_btn_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(862, 475);
            this.Controls.Add(this.submit_order_btn);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "View";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button submit_order_btn;
    }
}