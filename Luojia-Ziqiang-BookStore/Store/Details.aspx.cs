using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Details : Page
{
    DB dbObj = new DB();
    protected string menu = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        orderid.Text = Request["OrderID"].Trim();
        gvBind();//显示信息
        bind();
    }
    /// <summary>
    /// 绑定所有详细信息
    /// </summary>
    public void gvBind()
    {
        string strSql = "select DetailID,BookName,Num,TotalPrice from tb_Detail d,tb_OfficialBook ob where d.BookID=ob.BookID and OrderID="+ Convert.ToInt32(Request["OrderID"].Trim());
        //调用公共类中的GetDataSetStr方法执行SQL语句，返回数据源的数据表
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbDetail");
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
        this.goods.DataKeyNames = new string[] { "DetailID" };
        this.goods.DataBind();
    }
    protected void lnkbtnOne_Click(object sender, EventArgs e)
    {
        this.labPage.Text = "1";
       
            gvBind();//绑定所有信息
        
    }
    protected void lnkbtnUp_Click(object sender, EventArgs e)
    {
        this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) - 1);
       
            gvBind();//绑定所有信息
        
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) + 1);
       
            gvBind();//绑定所有信息
        
    }
    protected void lnkbtnBack_Click(object sender, EventArgs e)
    {
        this.labPage.Text = this.labBackPage.Text;
       
            gvBind();//绑定所有信息
        
    }
    
    protected void goods_RowEditing(object sender, GridViewEditEventArgs e)
    {
        goods.EditIndex = e.NewEditIndex;//编辑行的索引为当前行      
            gvBind();//绑定所有信息        
    }
    
    protected void goods_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        goods.PageIndex = e.NewPageIndex;
        gvBind();//显示信息 
    }

    public void bind()
    {
        orderid.Text = Request["OrderID"].Trim();
        string strSql = "select * from tb_OrderInfo where OrderID=" + Convert.ToInt32(Request["OrderID"].Trim());
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbOB");
        this.id.Text = dsTable.Rows[0]["OrderID"].ToString();
        this.date.Text = dsTable.Rows[0]["OrderDate"].ToString();
        this.userid.Text = dsTable.Rows[0]["UserID"].ToString();
        this.booksfee.Text = dsTable.Rows[0]["BooksFee"].ToString();
        this.shipfee.Text = dsTable.Rows[0]["ShipFee"].ToString();
        this.total.Text = dsTable.Rows[0]["TotalPrice"].ToString();
        this.shiptype.Text = dsTable.Rows[0]["ShipType"].ToString();
        this.remark.Text = dsTable.Rows[0]["remark"].ToString();
        this.rname.Text = dsTable.Rows[0]["ReceiverName"].ToString();
        this.rphone.Text = dsTable.Rows[0]["ReceiverPhone"].ToString();
        this.raddress.Text = dsTable.Rows[0]["ReceiverAddress"].ToString();
    }

   
    protected void btnBack_Click(object sender, EventArgs e)
    {
        SBS.JsHelper.Redirect("OrderList.aspx");
    }
}