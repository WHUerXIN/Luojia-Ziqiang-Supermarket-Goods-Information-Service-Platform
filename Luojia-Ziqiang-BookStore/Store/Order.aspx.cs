using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Order : System.Web.UI.Page
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
        string strSql = "select * from tb_OrderInfo where SendState <> 0 and UserID=" + Session["UserID"];
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
        this.goods.DataSource = ps;
        this.goods.DataKeyNames = new string[] { "OrderID" };
        this.goods.DataBind();
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
        this.goods.DataSource = ps;
        this.goods.DataKeyNames = new string[] { "OrderID" };
        this.goods.DataBind();
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
        string strSql = "select (case SendState when '1' then '未发货' when '2' then '未收货' when '3' then '已收货' when '4' then '已完成' end ) as SendState ";
        strSql += "  from tb_OrderInfo where SendState <> 0 and OrderID=" + IntOrderID;      
        SqlCommand sqlCommand = dbObj.GetCommandStr(strSql);
        string result = dbObj.ExecScalar(sqlCommand);
        return result;
           
    }
    protected void goods_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        goods.PageIndex = e.NewPageIndex;
        if (ViewState["search"] != null)
        {
            gvSearchBind();//绑定查询后的订单信息
        }
        else
        {
            gvBind();//绑定所有订单信息
        }
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


    protected void goods_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Btn_Operation")
        {
            int id = Convert.ToInt32(goods.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);
            string sql = "select SendState from tb_OrderInfo where OrderID=" + id ;
            DataTable dt = dbObj.GetDataSetStr(sql, "tbSS");
            int n = int.Parse(dt.Rows[0][0].ToString());
            if (n ==1 )
                
                common.Alert("商品尚未发货！", "order.aspx", this);
            if (n == 2)
            {
                int result = order.ChangeState(id, 3);
                if (result > 0)
                {
                    gvBind();
                    
                    common.Alert("收货成功！", "order.aspx", this);
                }               
            }
            if (n == 3)
                
                common.Alert("商品已确认收货！", "order.aspx", this);
            if (n == 4)
                
                common.Alert("订单已完成！", "order.aspx", this);


        }
    }
}