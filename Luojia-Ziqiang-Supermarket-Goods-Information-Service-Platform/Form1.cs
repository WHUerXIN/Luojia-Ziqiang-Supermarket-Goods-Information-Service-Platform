using System;
using System.Windows.Forms;

namespace Luojia_Ziqiang_Supermarket_Goods_Information_Service_Platform
{
    public partial class Form1 : Form
    {
        public static Consumer test = Consumer.getConsumerInstance();
        //定义一个测试对象
        //"测试", "2018300000000", 20, Gender.MALE, "Test123."
        public Form1()
        {
            InitializeComponent();
            sign_in sign_in_wnd = new sign_in();
            sign_in_wnd.ShowDialog();
            welcome_notice.Text = test.getConsumerName() + "，欢迎光临珞珈自强超市！";
        }

        private void view_btn_Click(object sender, EventArgs e)
        {
            View view_wnd = new View();
            view_wnd.ShowDialog();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void view_info_btn_Click(object sender, EventArgs e)
        {
            string info = "您的个人信息如下：\n学号：" + test.getStudentID() + "\n姓名：" + test.getConsumerName() + "\n年龄："
                + Convert.ToString(test.getAge()) + "\n性别：";
            if (test.getGender() == Gender.MALE)
                info += "男";
            else
                info += "女";
            MessageBox.Show(info);
        }

        private void change_info_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("诶呀！这个功能还没实现呢！");
        }

        private void submit_feedback_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("诶呀！这个功能还没实现呢！");
        }
    }
}
