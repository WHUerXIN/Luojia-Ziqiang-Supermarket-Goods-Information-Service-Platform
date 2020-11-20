using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class PersonalGoods : System.Web.UI.Page
{    
    DB dbObj = new DB();
    User usObj = new User();
    Common common = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["UserID"] = 1;
        if (!IsPostBack)
        {
            if ((Session["UserID"] == null))
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
    /// 绑定所有书籍的信息
    /// </summary>
    public void gvBind()
    {
        string strSql = "select * from tb_PersonalGoods where UserID=" + Session["UserID"];
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
        this.goods.DataKeyNames = new string[] { "GoodsID" };
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
    /// <summary>
    /// 在搜索中绑定书籍信息
    /// </summary>
    public void gvSearchBind()
    {
        DataTable dsTable = usObj.SearchPersonalGoods(this.txtKey.Text.Trim(), biaoqian.SelectedIndex, Session["UserID"]);
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
        this.goods.DataKeyNames = new string[] { "GoodsID" };
        this.goods.DataBind();
    }

    protected void goods_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        goods.PageIndex = e.NewPageIndex;
        if (ViewState["search"] != null)
        {
            gvSearchBind();//绑定查询后的信息
        }
        else
        {
            gvBind();//绑定所有信息
        }
    }
    /// <summary>
    /// 编辑按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void goods_RowEditing(object sender, GridViewEditEventArgs e)
    {
        goods.EditIndex = e.NewEditIndex;//编辑行的索引为当前行
        if (ViewState["search"] != null)
        {
            gvSearchBind();//绑定查询后的信息
        }
        else
        {
            gvBind();//绑定所有信息
        }
    }
    /// <summary>
    /// 取消按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void goods_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        goods.EditIndex = -1;//将索引行变为-1          
        if (ViewState["search"] != null)
        {
            gvSearchBind();//绑定查询后的信息
        }
        else
        {
            gvBind();//绑定所有信息
        }
    }
    /// <summary>
    /// 更新按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void goods_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int id = Convert.ToInt32(this.goods.DataKeys[e.RowIndex].Value.ToString());

        string sql = "update tb_PersonalGoods set GoodsName='" + ((TextBox)goods.Rows[e.RowIndex].Cells[1].Controls[0]).Text +  "',GoodsImage='"
            + ((TextBox)goods.Rows[e.RowIndex].Cells[4].Controls[0]).Text + "',Class='" + ((TextBox)goods.Rows[e.RowIndex].Cells[2].Controls[0]).Text + "',Price=" + float.Parse(((TextBox)goods.Rows[e.RowIndex].Cells[3].Controls[0]).Text) + ",Introduction='" + ((TextBox)goods.Rows[e.RowIndex].Cells[5].Controls[0]).Text + "' where GoodsID =" + id;
        SqlCommand sqlCommand = dbObj.GetCommandStr(sql);
        int result = dbObj.ExecNonQuery(sqlCommand);
        if (result > 0)
        {
            common.Alert("修改成功！", "PersonalGoods.aspx", this);
        }

        else
        {
            common.Alert("修改失败！", "PersonalGoods.aspx", this);
        }
        goods.EditIndex = -1;
        if (ViewState["search"] != null)
        {
            gvSearchBind();//绑定查询后的信息
        }
        else
        {
            gvBind();//绑定所有信息
        }

    }
    protected void goods_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int IntID = Convert.ToInt32(goods.DataKeys[e.RowIndex].Value); //获取代号
        //在文件夹中删除图片
        string str = "select GoodsImage from tb_PersonalGoods where GoodsID=" + IntID;
        DataTable dsTable = dbObj.GetDataSetStr(str, "tbIm");
        string strFilePath = Server.MapPath(dsTable.Rows[0][0].ToString());
        File.Delete(strFilePath);
        //删除指定的信息
        string strDelSql = "delete from tb_PersonalGoods where GoodsID=" + IntID;
        SqlCommand myDelCmd = dbObj.GetCommandStr(strDelSql);
        dbObj.ExecNonQuery(myDelCmd);

        common.Alert("删除成功！", "PersonalGoods.aspx", this);
        //对商品进行重新绑定
        if (ViewState["search"] != null)
        {
            gvSearchBind();
        }
        else
        {
            gvBind();
        }      
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //将ViewState["search"]对象值1
        ViewState["search"] = 1;
        this.labPage.Text = "1";
        gvSearchBind();//绑定查询后的商品信息
        this.txtKey.Text = "";
    }

    public string GetCut(object content, int num)
    {
        if (content.ToString().Length > num - 2)
        {
            return content.ToString().Substring(0, num - 2) + "...";
        }
        else
        {
            return content.ToString();
        }
    }


    protected void btnShowall_Click(object sender, EventArgs e)
    {
        this.labPage.Text = "1";
        gvBind();
        this.txtKey.Text = "";
    }
}