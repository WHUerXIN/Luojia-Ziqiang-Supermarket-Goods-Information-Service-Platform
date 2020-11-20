using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Aop.Api.Domain;
using Aop.Api;
using Aop.Api.Request;
using Aop.Api.Util;
using System.Data.SqlClient;

public partial class checkOut : System.Web.UI.Page
{
    Common ccObj = new Common();
    Orders ocObj = new Orders();
    Orders odObj = new Orders();
    DB dbObj = new DB();

    protected void Page_Load(object sender, EventArgs e)
    {
        
        DB dbObj = new DB();
        Order ocObj = new Order();
        User ucObj = new User();
        DataTable dtTable;
        Hashtable hashCar;
        string strSql;
        {
            if (!IsPostBack)
            {

                if (Session["UserID"] == null)
                {

                    //Response.Redirect("Default.aspx");
                    Response.Write("<script lanuage=javascript>alert('对不起,您还未登录！');location='Default.aspx'</script>");
                }
                //if (Session["Username"] != null)
                else
                {
                    //如果用户已登录，则显示用户的基本信息
                    DataTable dsTable = ucObj.GetUserInfo(Convert.ToInt32(Session["UserID"].ToString()));
                    this.txtReciverName.Text = dsTable.Rows[0][3].ToString();     //收货人姓名
                    this.txtReceiverPhone.Text = dsTable.Rows[0][5].ToString();   //收货人电话号码
                    this.txtReceiverAddress.Text = dsTable.Rows[0][7].ToString();  //收货人详细地址
                }
                if (Session["ShopCart"] == null)
                {
                    //如果没有购物，则给出相应信息，并隐藏按钮
                    this.labMessage.Text = "您还没有购物！"; //显示提示信息
                    //this.btnConfirm.Visible = false;         //隐藏“确认”按钮
                }
                else
                {
                    hashCar = (Hashtable)Session["ShopCart"];  //获取其购物车
                    if (hashCar.Count == 0)
                    {
                        //如果没有购物，则给出相应信息，并隐藏按钮
                        this.labMessage.Text = "您购物车中没有商品！";//显示提示信息
                        //this.btnConfirm.Visible = false;              //隐藏“确认”按钮
                    }
                    else
                    {
                        //设置购物车内容的数据源
                        dtTable = new DataTable();
                        DataColumn column1 = new DataColumn("No");//序号列
                        DataColumn column2 = new DataColumn("BookID");    //商品ID代号
                        DataColumn column3 = new DataColumn("BookName");  //商品名称
                        DataColumn column4 = new DataColumn("Num");       //数量
                        DataColumn column5 = new DataColumn("price");     //单价
                        DataColumn column6 = new DataColumn("totalPrice");//总价
                        dtTable.Columns.Add(column1);//添加新列
                        dtTable.Columns.Add(column2);
                        dtTable.Columns.Add(column3);
                        dtTable.Columns.Add(column4);
                        dtTable.Columns.Add(column5);
                        dtTable.Columns.Add(column6);
                        DataRow row;
                        //对数据表中每一行进行遍历，给每一行的新列赋值
                        foreach (object key in hashCar.Keys)
                        {
                            row = dtTable.NewRow();
                            row["BookID"] = key.ToString();        //商品ID
                            row["Num"] = hashCar[key].ToString();  //商品数量        
                            dtTable.Rows.Add(row);
                        }
                        //计算价格
                        DataTable dstable;
                        int i = 1;
                        float price; //商品单价
                        int num;     //商品数量
                        float totalPrice = 0; //商品总价格
                        int totailNum = 0;    //商品总数量
                        foreach (DataRow drRow in dtTable.Rows)
                        {
                            strSql = "select BookName,Price from tb_OfficialBook where BookID=" + Convert.ToInt32(drRow["BookID"].ToString());
                            dstable = dbObj.GetDataSetStr(strSql, "tbGI");
                            drRow["No"] = i;
                            drRow["BookName"] = dstable.Rows[0][0].ToString();   //商品名称
                            drRow["price"] = dstable.Rows[0][1].ToString();      //商品名称
                            price = float.Parse(dstable.Rows[0][1].ToString());
                            num = Int32.Parse(drRow["Num"].ToString());
                            drRow["totalPrice"] = (price * num);                   //总价
                            totalPrice += price * num;                          //计算合价
                            totailNum += num;                                   //计算商品总数
                            i++;
                        }
                        this.ltp.Text = totalPrice.ToString();       //显示所有商品的价格
                        this.labTotalPrice.Text = string.Format("{0:f2}", totalPrice+10);
                        //this.labTotalNum.Text = totailNum.ToString();          //显示商品总数
                        this.gvShopCart.DataSource = dtTable.DefaultView;      //绑定GridView控件
                        this.gvShopCart.DataBind();
                    }
                }
            }

        }
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        if (Page.IsValid&& this.labMessage.Text == "订单详细情况如下：")
        {
            //得到用户输入的信息
            string strPhone;  //电话号码
            float fltShipFee; //邮递方式及其费用
            if (IsValidPhone(this.txtReceiverPhone.Text.Trim()) == true)//判断输入的电话号码是否合法
            {
                strPhone = this.txtReceiverPhone.Text.Trim();
            }
            else
            {
                Response.Write(ccObj.MessageBox("输入有误！"));
                return;
            }

            fltShipFee = float.Parse(this.Shipfee.Text);//获取邮递方式及其费用
            string strName = this.txtReciverName.Text.Trim();       //收货人姓名
            string strAddress = this.txtReceiverAddress.Text.Trim();//收货人详细地址
            string strRemark = this.txtRemark.InnerText.Trim();          //备注
            //将订单信息插入订单表中
            int intOrderID = ocObj.AddOrder(float.Parse(this.labTotalPrice.Text), fltShipFee, this.ShipType.Text, int.Parse(Session["UserID"].ToString()), strName, strPhone, strAddress, strRemark);
            int IntBookID; //商品ID
            int IntNum;    //购买商品数量


            float fltTotalPrice;
            //对订单中的每一个货物插入订单详细表中
            foreach (GridViewRow gvr in this.gvShopCart.Rows)
            {
                IntBookID = int.Parse(gvr.Cells[1].Text);
                IntNum = int.Parse(gvr.Cells[3].Text);
                fltTotalPrice = float.Parse(gvr.Cells[5].Text);
                ocObj.AddDetail(IntBookID, IntNum, intOrderID, fltTotalPrice);
            }

            //设置Session
            Session["ShopCart"] = null;  //清空购物车
            //Response.Redirect("PayWay.aspx?OrderID=" + IntOrderID);
            //Response.Redirect("GoBank.aspx?OrderID=" + IntOrderID );

            //配置支付需要的东西
            //订单号IntOrderID，价格totalPrice，官方教材，时间？当前时间date
            string temp = this.labTotalPrice.Text;


            Response.Write("<Script Language=JavaScript>alert('支付成功');location='Default.aspx'</Script>");

        }
    }




    //判断修改的数据是否为有效的数据
    public bool IsValidPhone(string num)
    {//验证电话号码
        return Regex.IsMatch(num, @"(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}$");
    }


    protected void RadioButton_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButton1.Checked)
        {
            labTotalPrice.Text = string.Format("{0:f2}", float.Parse(ltp.Text) + 10);
            Shipfee.Text = "10.00";
            ShipType.Text = "顺丰快递（10元）";
        }
        if (RadioButton2.Checked)
        {
            labTotalPrice.Text = string.Format("{0:f2}", float.Parse(ltp.Text) + 5);
            Shipfee.Text = "5.00";
            ShipType.Text = "其他快递（5元）";
        }
        if (RadioButton3.Checked)
        {
            labTotalPrice.Text = string.Format("{0:f2}", float.Parse(ltp.Text));
            Shipfee.Text = "0.00";
            ShipType.Text = "免费送货（仅武汉大学）";
        }
    }
}