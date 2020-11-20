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

public partial class 个人商品 : System.Web.UI.Page
{
    DB dbObj = new DB();
    Goods gcObj = new Goods();
    User ucObj = new User();
    Common ccObj = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetGoodsInfo();
            Session["BookID"] = Convert.ToInt32(Request["id"].Trim());
            if (Session["UserID"] == null)
                this.submitComment.Style.Value = "display:none";
            else
            {
                string headimage = ucObj.GetHead(int.Parse(Session["UserID"].ToString()));
                this.HeadImage.ImageUrl = headimage;
            }
        }
    }
    public void GetGoodsInfo()
    {
        string strSql = "select * from tb_PersonalGoods p, tb_User u where GoodsID=" + Convert.ToInt32(Request["id"].Trim())+ "and p.UserID=u.UserID";
        SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbBI");
        this.Image1.ImageUrl = dsTable.Rows[0]["GoodsImage"].ToString();
        this.txtName.Text = dsTable.Rows[0]["GoodsName"].ToString();
        this.txtPrice.Text = string.Format("{0:F2}", double.Parse(dsTable.Rows[0]["Price"].ToString()));
        this.txtClass.Text = dsTable.Rows[0]["Class"].ToString();
        this.txtGoodsID.Text = dsTable.Rows[0]["GoodsID"].ToString();
        this.txtUserID.Text = dsTable.Rows[0]["UserID"].ToString();
        this.txtUserName.Text = dsTable.Rows[0]["UserName"].ToString();
        this.txtHeadImage.Text = dsTable.Rows[0]["HeadImage"].ToString();
        this.txtPhone.Text = dsTable.Rows[0]["Phone"].ToString();
        this.txtEmail.Text = dsTable.Rows[0]["Email"].ToString();
        this.Introduction.Text= dsTable.Rows[0]["Introduction"].ToString();
        DataTable dsTable2 = gcObj.getcomment(int.Parse(Request["id"]), "个人商品");
        dLComment.DataSource = dsTable2;
        dLComment.DataBind();
        CommentNum();
    }
    protected void AddComment_Click(object sender, EventArgs e)
    {
        ucObj.AddComment(int.Parse(Request["id"]), int.Parse(Session["UserID"].ToString()), UserComment.InnerText, "个人商品");
        ccObj.Msg("评论成功！", this);
        UserComment.InnerText = "";
        DataTable dsTable = gcObj.getcomment(int.Parse(Request["id"]), "个人商品");
        dLComment.DataSource = dsTable;
        dLComment.DataBind();
        CommentNum();
    }

    protected void buy_Click(object sender, EventArgs e)
    {
        //Response.Redirect("http://wpa.qq.com/msgrd?v=3&uin=1835932338&site=qq&menu=yes", true);
        ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>MyFun();</script>");
    }
    public void CommentNum()
    {
        string strCount = "select count(*) from tb_Comment where BookID=" + Convert.ToInt32(Request["id"].Trim()) + " and Class='个人商品'";
        SqlCommand count = dbObj.GetCommandStr(strCount);
        this.txtCount.Text = dbObj.ExecScalar(count);
    }
}