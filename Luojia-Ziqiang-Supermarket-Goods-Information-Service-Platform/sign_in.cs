using System;
using System.Windows.Forms;

namespace Luojia_Ziqiang_Supermarket_Goods_Information_Service_Platform
{
    public partial class sign_in : Form
    {
        private bool isExit = true;
        public sign_in()
        {
            InitializeComponent();
        }

        private void sign_in_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(account_input.Text))
            {
                MessageBox.Show("请输入学号或账号！");
                account_input.Text = "";
                return;
            }
            if (account_input.Text.Length != 13)
            {
                MessageBox.Show("输入有误，请重试！");
                password_input.Text = "";
                account_input.Text = "";
                return;
            }
            if (string.IsNullOrEmpty(password_input.Text))
            {
                MessageBox.Show("请输入密码！");
                password_input.Text = "";
                return;
            }
            if (!Form1.test.LogIn(account_input.Text, password_input.Text))
            {
                MessageBox.Show("账号或密码输入错误！");
                password_input.Text = "";
                account_input.Text = "";
                return;
            }    

            isExit = false;
            Close();
        }

        private void sign_in_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
                Application.Exit();
        }
    }
}
