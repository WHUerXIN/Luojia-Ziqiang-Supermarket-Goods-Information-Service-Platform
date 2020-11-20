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

public partial class 官方教材 : System.Web.UI.Page
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
            DataTable dsTable = gcObj.getcomment(int.Parse(Request["id"]), "官方教材");
            dLComment.DataSource = dsTable;
            dLComment.DataBind();
            if (Session["UserID"]==null)
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
        string strSql = "select * from tb_OfficialBook where BookID=" + Convert.ToInt32(Request["id"].Trim());
        SqlCommand myCmd = dbObj.GetCommandStr(strSql);
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbBI");
        this.Image1.ImageUrl = dsTable.Rows[0]["CoverImage"].ToString();
        this.txtName.Text = dsTable.Rows[0]["BookName"].ToString();
        this.txtAuthor.Text = dsTable.Rows[0]["Author"].ToString();
        this.txtPrice.Text = string.Format("{0:F2}", double.Parse(dsTable.Rows[0]["Price"].ToString()));
        this.txtClass.Text = dsTable.Rows[0]["Class"].ToString();
        this.txtBookID.Text = dsTable.Rows[0]["BookID"].ToString();
        this.txtPublisher.Text = dsTable.Rows[0]["Publisher"].ToString();
        this.txtISBN.Text = dsTable.Rows[0]["ISBN"].ToString();
        this.txtEdition.Text = dsTable.Rows[0]["Edition"].ToString();
        this.txtPublishDate.Text = dsTable.Rows[0]["PublishDate"].ToString().Replace("0:00:00", "");
        this.txtPages.Text = dsTable.Rows[0]["Pages"].ToString();
        this.Introduction.Text=dsTable.Rows[0]["Introduction"].ToString();
        CommentNum();

    }

    public void ST_check_Login()
    {
        if ((Session["UserID"] == null))
        {
            Response.Write("<script>alert('对不起！请先登录或注册！');location='login.aspx'</script>");
            Response.End();
        }
    }


    protected void minus_Click(object sender, EventArgs e)
    {
        int num = int.Parse(GoodsNum.Text);
        if ( num> 1)
        {
            num--;
            GoodsNum.Text = num.ToString();
        }
    }

    protected void plus_Click(object sender, EventArgs e)
    {
        int num = int.Parse(GoodsNum.Text);        
        num++;
        GoodsNum.Text = num.ToString();
    }

    protected void buy_Click(object sender, ImageClickEventArgs e)
    {
        add_Click(sender,e);//添加至购物车
        Response.Redirect("~/ShopCart.aspx");//转至购物车
    }

    protected void add_Click(object sender, ImageClickEventArgs e)
    {
        /*判断是否登录*/
        ST_check_Login();
        Hashtable hashCar;
        string BookID = this.txtBookID.Text;
        int num = int.Parse(GoodsNum.Text);
        if (Session["ShopCart"] == null)
        {
            //如果用户没有分配购物车
            hashCar = new Hashtable();         //新生成一个
            hashCar.Add(BookID, num); //添加商品
            Session["ShopCart"] = hashCar;     //分配给用户
        }
        else
        {
            //用户已经有购物车
            hashCar = (Hashtable)Session["ShopCart"];//得到购物车的hash表
            if (hashCar.Contains(BookID))//购物车中已有此商品，商品数量增加
            {
                int count = Convert.ToInt32(hashCar[BookID].ToString());//得到该商品的数量
                hashCar[BookID] = (count + num);//商品数量增加
            }
            else
                hashCar.Add(BookID, num);//如果没有此商品，则新添加一个项
        }
        
        ccObj.Msg("加入成功！", this);
    }

    protected void AddComment_Click(object sender, EventArgs e)
    {
        ucObj.AddComment(int.Parse(Request["id"]),int.Parse(Session["UserID"].ToString()), UserComment.InnerText,"官方教材");
        ccObj.Msg("评论成功！", this);
        UserComment.InnerText = "";
        DataTable dsTable = gcObj.getcomment(int.Parse(Request["id"]), "官方教材");
        dLComment.DataSource = dsTable;
        dLComment.DataBind();
        CommentNum();
    }

    public void CommentNum()
    {
        string strCount = "select count(*) from tb_Comment where BookID=" + Convert.ToInt32(Request["id"].Trim()) + " and Class='官方教材'";
        SqlCommand count= dbObj.GetCommandStr(strCount);
        this.txtCount.Text = dbObj.ExecScalar(count);
    }
}