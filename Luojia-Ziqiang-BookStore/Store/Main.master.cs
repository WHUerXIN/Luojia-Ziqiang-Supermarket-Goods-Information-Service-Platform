using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.MasterPage
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
    }

    protected void quit_Click(object sender, ImageClickEventArgs e)
    {
        Session["UserID"] = null;
        Session["UserName"] = null;
        Session["HeadImage"] = null;
        Session["ShopCart"] = null;
        Page_Load(sender,e);
    }
}
