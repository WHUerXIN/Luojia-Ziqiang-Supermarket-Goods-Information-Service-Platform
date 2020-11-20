using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class User1 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["HeadImage"] != null)
        {
            this.headimage.ImageUrl = Session["HeadImage"].ToString();

        }
        else
        {
            this.headimage.ImageUrl = "/Img/用户.svg";
            this.quit.Style.Value = "display:none";
        }
        if (Session["UserName"] == null)
        {
            Response.Write("<script>alert('请先登录/注册！');location='login.aspx'</script>");
            Response.End();
        }


    }

    protected void quit_Click(object sender, ImageClickEventArgs e)
    {
        Session["UserID"] = null;
        Session["UserName"] = null;
        Session["HeadImage"] = null;
        Session["ShopCart"] = null;
        Page_Load(sender, e);
    }
}
