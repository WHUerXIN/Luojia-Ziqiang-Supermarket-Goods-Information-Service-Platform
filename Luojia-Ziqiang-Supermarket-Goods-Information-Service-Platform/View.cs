using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Luojia_Ziqiang_Supermarket_Goods_Information_Service_Platform
{
    public partial class View : Form
    {
        private static List<Product> Product_List = new List<Product>();
        private static List<Product> Products = new List<Product>();
        private static Order order = new Order("000001", Form1.test, Products, "2020-10-16");

        public View()
        {
            InitializeComponent();
            for (int i = 0; i < 20; i++) //初始化商品列表
            {
                Product product = new Product("商品" + Convert.ToString(i + 1), "生产商" + Convert.ToString(i + 1),
                    "2020-10-15", 20 * (i + 1));
                Product_List.Add(product);
            }
            for (int i = 0; i < 20; i++) //初始化各个标签和按钮
            {
                if (i % 2 == 0) //左边一列
                {
                    //Label
                    Label label = new Label();
                    Point temp = new Point(10, 20 + (i + 1) / 2 * 40);
                    label.Location = temp;
                    label.Text = Product_List[i].getProductName() + "\t价格：" + Convert.ToString(Product_List[i].getPrice()) + "元";
                    label.AutoSize = true;
                    Controls.Add(label);

                    //Button
                    Button button = new Button();
                    Size size = new Size(75, 30);
                    temp.X = 150;
                    temp.Y -= 5;
                    button.Text = "添加";
                    button.Tag = Convert.ToString(i);
                    button.Location = temp;
                    button.Size = size;
                    button.Click += new EventHandler(add_good_btn_Click);
                    Controls.Add(button);
                }
                else //右边一列
                {
                    //Label
                    Label label = new Label();
                    Point temp = new Point(400, 20 + (i - 1) / 2 * 40);
                    label.Location = temp;
                    label.Text = Product_List[i].getProductName() + "\t价格：" + Convert.ToString(Product_List[i].getPrice()) + "元";
                    label.AutoSize = true;
                    Controls.Add(label);

                    //Button
                    Button button = new Button();
                    Size size = new Size(75, 30);
                    temp.X = 550;
                    temp.Y -= 5;
                    button.Text = "添加";
                    button.Tag = Convert.ToString(i);
                    button.Location = temp;
                    button.Size = size;
                    button.Click += new EventHandler(add_good_btn_Click);
                    Controls.Add(button);
                }
            }

        }
        private void add_good_btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int index = Convert.ToInt32(button.Tag);
            order.AddingGoods(Product_List[index]);
            MessageBox.Show("商品添加成功！");
        }

        private void submit_order_btn_Click(object sender, EventArgs e)
        {
            if (Products.Count == 0)
            {
                MessageBox.Show("提示：您没有选择任何商品！");
                return;
            }
            if (Form1.test.SubmitOrders(order))
            {
                string info = "预订单提交成功！您的订单信息如下（商品按添加顺序排列）：\n";
                int cost = 0;
                for (int i = 0; i < Products.Count; i++)
                {
                    info += Products[i].getProductName() + "\n";
                    cost += Products[i].getPrice();
                }
                info += "共消费" + Convert.ToString(cost) + "元。";
                for (int i = 0; i < Products.Count; i++)
                {
                    order.DeleteGoods(Products[i]);
                }
                Products.Clear();
                MessageBox.Show(info);
                Close();
            }
        }
    }
}
