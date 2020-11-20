using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class OrderList : System.Web.UI.Page
{
    Admin admin = new Admin();
    DB dbObj = new DB();
    User usObj = new User();
    Orders order = new Orders();
    Common common = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            //Session["UserID"] = 2;
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert('请先登录/注册！');location='login.aspx'</script>");
                Response.End();
            }
            //判断是否已点击“搜索”按钮
            ViewState["search"] = null;
            gvBind();//显示订单信息
        }
    }

    /// <summary>
    /// 绑定所有订单的信息
    /// </summary>
    public void gvBind()
    {
        string strSql = "select * from tb_OrderInfo where SendState<> 0 and UserID=" + Session["UserID"];
        //调用公共类中的GetDataSetStr方法执行SQL语句，返回数据源的数据表
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbO");
        int curpage = Convert.ToInt32(this.labPage.Text);
        PagedDataSource ps = new PagedDataSource();
        ps.DataSource = dsTable.DefaultView;
        ps.AllowPaging = true; //是否可以分页
        ps.PageSize = 10; //显示的数量
        ps.CurrentPageIndex = curpage - 1; //取得当前页的页码
        this.lnkbtnUp.Enabled = true;
        this.lnkbtnNext.Enabled = true;
        this.lnkbtnBack.Enabled = true;
        this.lnkbtnOne.Enabled = true;
        if (curpage == 1)
        {
            this.lnkbtnOne.Enabled = false;//不显示第一页按钮
            this.lnkbtnUp.Enabled = false;//不显示上一页按钮
        }
        if (curpage == ps.PageCount)
        {
            this.lnkbtnNext.Enabled = false;//不显示下一页
            this.lnkbtnBack.Enabled = false;//不显示最后一页
        }
        this.labBackPage.Text = Convert.ToString(ps.PageCount);
        

        this.DataList1.DataSource = dsTable;
        this.DataList1.DataKeyField = "OrderID";
        this.DataList1.DataBind();
    }
    /// <summary>
    /// 在搜索中绑定订单信息
    /// </summary>
    public void gvSearchBind()
    {
        DataTable dsTable = usObj.SearchOrderInfo(OrderState.SelectedIndex, Session["UserID"]);
        int curpage = Convert.ToInt32(this.labPage.Text);
        PagedDataSource ps = new PagedDataSource();
        ps.DataSource = dsTable.DefaultView;
        ps.AllowPaging = true; //是否可以分页
        ps.PageSize = 10; //显示的数量
        ps.CurrentPageIndex = curpage - 1; //取得当前页的页码
        this.lnkbtnUp.Enabled = true;
        this.lnkbtnNext.Enabled = true;
        this.lnkbtnBack.Enabled = true;
        this.lnkbtnOne.Enabled = true;
        if (curpage == 1)
        {
            this.lnkbtnOne.Enabled = false;//不显示第一页按钮
            this.lnkbtnUp.Enabled = false;//不显示上一页按钮
        }
        if (curpage == ps.PageCount)
        {
            this.lnkbtnNext.Enabled = false;//不显示下一页
            this.lnkbtnBack.Enabled = false;//不显示最后一页
        }
        this.labBackPage.Text = Convert.ToString(ps.PageCount);
        
        this.DataList1.DataSource = dsTable;
        this.DataList1.DataKeyField = "OrderID";
        this.DataList1.DataBind();
    }

    protected void lnkbtnOne_Click(object sender, EventArgs e)
    {
        this.labPage.Text = "1";
        if (ViewState["search"] != null)
        {
            gvSearchBind();//绑定查询后的信息
        }
        else
        {
            gvBind();//绑定所有信息
        }
    }
    protected void lnkbtnUp_Click(object sender, EventArgs e)
    {
        this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) - 1);
        if (ViewState["search"] != null)
        {
            gvSearchBind();//绑定查询后的信息
        }
        else
        {
            gvBind();//绑定所有信息
        }
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) + 1);
        if (ViewState["search"] != null)
        {
            gvSearchBind();//绑定查询后的信息
        }
        else
        {
            gvBind();//绑定所有信息
        }
    }
    protected void lnkbtnBack_Click(object sender, EventArgs e)
    {
        this.labPage.Text = this.labBackPage.Text;
        if (ViewState["search"] != null)
        {
            gvSearchBind();//绑定查询后的信息
        }
        else
        {
            gvBind();//绑定所有信息
        }
    }
    public string GetStatus(int IntOrderID)
    {
        string strSql = "select (case SendState  when '1' then '未发货' when '2' then '未收货' when '3' then '已收货' when '4' then '已完成' end ) as SendState ";
        strSql += "  from tb_OrderInfo where SendState <> 0 and OrderID=" + IntOrderID;      
        SqlCommand sqlCommand = dbObj.GetCommandStr(strSql);
        string result = dbObj.ExecScalar(sqlCommand);
        return result;
           
    }
   
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //将ViewState["search"]对象值1
        ViewState["search"] = 1;
        gvSearchBind();//绑定查询后的信息
        //this.txtKey.Text = "";
    }
    protected void btnShowall_Click(object sender, EventArgs e)
    {
        this.labPage.Text = "1";
        gvBind();
        //this.txtKey.Text = "";
    }


    

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        DataList DataList2 = (DataList)e.Item.FindControl("DataList2");
        int orderid = int.Parse(DataList1.DataKeys[e.Item.ItemIndex].ToString());

        string getGoods = "select SendState,DetailID,d.TotalPrice,o.OrderID,Num,Price,BookName,CoverImage from tb_Detail d,tb_OrderInfo o,tb_OfficialBook ob where d.BookID=ob.BookID and d.OrderID=o.OrderID and UserID=" +Session["UserID"] +"and o.OrderID=" + orderid;
        SqlCommand myCmd = dbObj.GetCommandStr(getGoods);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbOrder");

        DataList2.DataSource = dsTable;
        DataList2.DataKeyField = "DetailID";
        DataList2.DataBind();

        string status = dsTable.Rows[0][0].ToString();
        Label state = (Label)e.Item.FindControl("state");
        LinkButton receive=(LinkButton)e.Item.FindControl("queren");
        receive.Enabled = true;
        switch (status)
        {         
            case "1": state.Text = "未发货"; break;
            case "2": state.Text = "未收货"; break;
            case "3": state.Text = "已收货"; break;
            case "4": state.Text = "已完成"; break;
        }

        if (status == "2")
        {
            receive.Text = "确认收货";
            
        }
        
        else if (status == "1")
        {
            receive.Text="准备发货";
            receive.Enabled = false;
        }
        else if (status == "3")
        {
            receive.Text = "订单完成";
            receive.Enabled = false;
        }
        else 
        {
            receive.Text = "订单结束";
            receive.Enabled = false;
        }

    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        
        if (e.CommandName=="Detail")
        {
            int orderid = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("Details.aspx?OrderID=" + orderid);
        }
        if (e.CommandName == "State")
        {
            int orderid = Convert.ToInt32(e.CommandArgument);
            Label receive = (Label)e.Item.FindControl("state");
            
            if (receive.Text == "未收货")
            {
                string change = "update tb_OrderInfo set SendState=3 where OrderID=" + orderid;
                SqlCommand myCmd = dbObj.GetCommandStr(change);
                int result = dbObj.ExecNonQuery(myCmd);

                if (result > 0)
                {
                    gvBind();
                    common.Alert("收货成功！", "OrderList.aspx", this);
                }
            }
        }

    }
}