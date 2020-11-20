using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.ServiceModel.Channels;

public partial class GoodsList : System.Web.UI.Page
{
    
    Goods gcObj = new Goods();
    DB dbObj = new DB();
    Common ccObj = new Common();
    static bool flag = true;
    static string key = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request["来源"]!=null)
            Session["来源"] = Request["来源"].ToString();
        if (Request["学科"] != null)
            Session["学科"] = Request["学科"].ToString();
        
                   //显示浏览的商品信息
        if (Session["学科"] == null || Session["学科"].ToString() == "")
            Session["学科"] = "全部";
        if (Session["来源"] == null || Session["来源"].ToString() == "")
            Session["来源"] = "官方教材";
        dlBind();
        labTitle.Text = ">　"+ Session["来源"].ToString() + "　>　"+ Session["学科"].ToString();
    }
    /// <summary>
    /// 说明：dlBind方法用于绑定相关的商品信息
    /// 如果Request["var"]的值为1，表示点击头控件中的“新品上市”、“特价商品”和“热门商品”导航到该浏览页
    /// 否则，表示点击分类导航条中的商品类别名导航到该浏览页
    /// </summary>
    public void dlBind()
    {
        if (Session["学科"] == null || Session["学科"].ToString() == "")
            Session["学科"] = "全部";
        if (Session["来源"] == null || Session["来源"].ToString() == "")
            Session["来源"] = "官方教材";
        dlBindPage(Session["学科"].ToString(), Session["来源"].ToString());//分页显示某个商品类别下的商品信息
        
    }


    public void dlBindPage(String StrClass, String StrFrom)
    {
        //获取数据源的数据表

        SqlCommand myCmd = dbObj.GetCommandProc("proc_GIList");
        //添加参数
        SqlParameter Class = new SqlParameter("@Class", SqlDbType.NVarChar,20);
        Class.Value = StrClass;
        myCmd.Parameters.Add(Class);
        //添加参数
        SqlParameter From = new SqlParameter("@From", SqlDbType.NVarChar, 10);
        From.Value = StrFrom;
        myCmd.Parameters.Add(From);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbGI1");
        int curpage = Convert.ToInt32(this.labPage.Text);
        PagedDataSource ps = new PagedDataSource();
        ps.DataSource = dsTable.DefaultView;
        ps.AllowPaging = true; //是否可以分页
        ps.PageSize = 12; //显示的数量
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
        this.dLGoodsList.DataSource = ps;
        this.dLGoodsList.DataKeyField = "BookID";
        this.dLGoodsList.DataBind();
    }

    protected void lnkbtnOne_Click(object sender, EventArgs e)
    {
        this.labPage.Text = "1";
        if (flag)
            this.dlBind();
        else this.dlBindSearch(key, Session["来源"].ToString());
    }
    protected void lnkbtnUp_Click(object sender, EventArgs e)
    {
        this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) - 1);
        if (flag)
            this.dlBind();
        else this.dlBindSearch(key, Session["来源"].ToString());
    }
    protected void lnkbtnNext_Click(object sender, EventArgs e)
    {
        this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) + 1);
        if (flag)
            this.dlBind();
        else this.dlBindSearch(key, Session["来源"].ToString());
    }
    protected void lnkbtnBack_Click(object sender, EventArgs e)
    {
        this.labPage.Text = this.labBackPage.Text;
        if (flag)
            this.dlBind();
        else this.dlBindSearch(key, Session["来源"].ToString());
    }
    //绑定市场价格
    public string GetVarMKP(string strMarketPrice)
    {
        return gcObj.VarStr(strMarketPrice, 2);
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        ccObj.Msg("检索成功！", this);
        //Button1.Text = Session["来源"].ToString();
        Session["来源"] = 来源.Text;
        Session["学科"] = 学科.Text;
        this.labPage.Text = "1";
        flag = true;
        dlBind();
    }


    protected void search_Click(object sender, EventArgs e)
    {
        ccObj.Msg("搜索成功！", this);
        if (Request["txtKey"] != null)
        {
            key = Request["txtKey"].ToString();
        }
        dlBindSearch(key, Session["来源"].ToString());
        flag = false;
    }

    public void dlBindSearch(String StrKey, String StrFrom)
    {
        //获取数据源的数据表

        SqlCommand myCmd = dbObj.GetCommandProc("proc_Search");
        //添加参数
        SqlParameter key = new SqlParameter("@Key", SqlDbType.NVarChar, 20);
        key.Value = StrKey;
        myCmd.Parameters.Add(key);
        //添加参数
        SqlParameter From = new SqlParameter("@From", SqlDbType.NVarChar, 10);
        From.Value = StrFrom;
        myCmd.Parameters.Add(From);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbSch");
        int curpage = Convert.ToInt32(this.labPage.Text);
        PagedDataSource ps = new PagedDataSource();
        ps.DataSource = dsTable.DefaultView;
        ps.AllowPaging = true; //是否可以分页
        ps.PageSize = 12; //显示的数量
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
        this.dLGoodsList.DataSource = ps;
        this.dLGoodsList.DataKeyField = "BookID";
        this.dLGoodsList.DataBind();
    }
}

