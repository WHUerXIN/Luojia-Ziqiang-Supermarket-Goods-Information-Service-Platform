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

public partial class EditUserInfo : System.Web.UI.Page
{
    DB dbObj = new DB();
    Common common = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["UserID"] = 1;
        if (!IsPostBack)
        {
            if (Session["UserID"] == null)
            {
                 common.Alert("请先登录/注册！", "login.aspx", this);
            }
            else
                gvBind();
        }
        
    }

    public void gvBind()
    {
        string strSql = "select * from tb_User where UserID= " + Session["UserID"];
        DataTable dsTable = dbObj.GetDataSetStr(strSql, "tbuser");
        this.username.Text = dsTable.Rows[0][1].ToString();
        this.password.Text = dsTable.Rows[0][2].ToString();
        this.realname.Text = dsTable.Rows[0][3].ToString();
        string sex = dsTable.Rows[0][4].ToString();
        if (sex == "False")
        {
            this.DropDownList2.SelectedValue = "男";
        }
        else
            this.DropDownList2.SelectedValue = "女";

        this.phone.Text = dsTable.Rows[0][5].ToString();
        this.email.Text = dsTable.Rows[0][6].ToString();
        this.address.Text = dsTable.Rows[0][7].ToString();
        this.Image1.ImageUrl = dsTable.Rows[0][8].ToString();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strusersname = this.username.Text.Trim();
        string strpa = this.password.Text.Trim();
        string strrealname = this.realname.Text.Trim();
        string sex = this.DropDownList2.SelectedValue;
        string strphone = this.phone.Text.Trim();
        string stremail = this.email.Text.Trim();
        string stradd = this.address.Text.Trim();
        
       
        //将信息插入数据库中
        string strAddSql = "Update tb_User set UserName= '" + strusersname + "',Password='" + strpa + "',RealName='" + strrealname;
        switch (DropDownList2.SelectedIndex)
        {
            case 0 : strAddSql += "',Sex= 0 ,Phone='" + strphone + "',Email='" + stremail + "',Address='" + stradd + "',HeadImage='" + this.Image1.ImageUrl + "' where UserID=" + Session["UserID"]; break;
            case 1 : strAddSql += "',Sex= 1 ,Phone='" + strphone + "',Email='" + stremail + "',Address='" + stradd + "',HeadImage='" + this.Image1.ImageUrl + "' where UserID=" + Session["UserID"]; break;

        }
        SqlCommand myCmd = dbObj.GetCommandStr(strAddSql);
        int result=dbObj.ExecNonQuery(myCmd);
        if (result > 0)
        {
            gvBind();
            common.Alert("修改成功！", "EditUserInfo.aspx", this);
            Session["HeadImage"] = this.Image1.ImageUrl;
        }
        else
            //SBS.JsHelper.AlertAndRedirect("修改失败！", "EditUserInfo.aspx");
            common.Alert("修改失败！", "EditUserInfo.aspx", this);
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {        
        this.password.Text = "";
        this.username.Text = "";        
        this.realname.Text = "";
        this.phone.Text = "";
        this.email.Text = "";
        this.address.Text = "";
        this.Image1.ImageUrl = "";
        this.Label1.Text = "";
    }
    #region 文件上传
    /// <summary>
    /// 文件上传
    /// </summary>
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.FileName == "")
        {
            this.Label1.Text = "上传文件不能为空";
            return;
        }

        bool fileIsValid = false;
        //如果确认了上传文件，则判断文件类型是否符合要求 
        if (this.FileUpload1.HasFile)
        {
            //获取上传文件的后缀 
            String fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
            String[] restrictExtension = { ".jpg", ".bmp", ".png" };
            //判断文件类型是否符合要求 
            for (int i = 0; i < restrictExtension.Length; i++)
            {
                if (fileExtension == restrictExtension[i])
                {
                    fileIsValid = true;
                }
                //如果文件类型符合要求,调用SaveAs方法实现上传,并显示相关信息 
                if (fileIsValid == true)
                {
                    //上传文件是否大于10M
                    if (FileUpload1.PostedFile.ContentLength > (10 * 1024 * 1024))
                    {
                        this.Label1.Text = "上传文件过大";
                        return;
                    }
                    try
                    {
                        this.Image1.ImageUrl = "~/Images/OfficialBook/" + FileUpload1.FileName;
                        this.FileUpload1.SaveAs(Server.MapPath("~/Images/OfficialBook/") + FileUpload1.FileName);
                        this.Label1.Text = "文件上传成功!";
                    }
                    catch
                    {
                        this.Label1.Text = "文件上传失败！";
                    }
                    finally
                    {

                    }
                }
                else
                {
                    this.Label1.Text = "只能够上传后缀为.jpg,.bmp,.png的文件";
                }
            }
        }
    }
    #endregion
    protected void BtnUpdateIm_Click(object sender, EventArgs e)
    {
        if (FileUpload1.FileName == "")
        {
            this.Label1.Text = "上传图片不能为空";
            return;
        }

        bool fileIsValid = false;
        //如果确认了上传文件，则判断文件类型是否符合要求 
        if (this.FileUpload1.HasFile)
        {
            //获取上传文件的后缀 
            String fileExtension = System.IO.Path.GetExtension(this.FileUpload1.FileName).ToLower();
            String[] restrictExtension = { ".jpg", ".bmp", ".png" };
            //判断文件类型是否符合要求 
            for (int i = 0; i < restrictExtension.Length; i++)
            {
                if (fileExtension == restrictExtension[i])
                {
                    fileIsValid = true;
                }
                //如果文件类型符合要求,调用SaveAs方法实现上传,并显示相关信息 
                if (fileIsValid == true)
                {
                    //上传文件是否大于10M
                    if (FileUpload1.PostedFile.ContentLength > (10 * 1024 * 1024))
                    {
                        this.Label1.Text = "上传图片过大";
                        return;
                    }
                    try
                    {
                        this.Image1.ImageUrl = "Images/HeadImage/" + FileUpload1.FileName;
                        this.FileUpload1.SaveAs(Server.MapPath("Images/HeadImage/") + FileUpload1.FileName);
                        this.Label1.Text = "图片上传成功!";
                    }
                    catch
                    {
                        this.Label1.Text = "图片上传失败！";
                    }
                    finally
                    {

                    }
                }
                else
                {
                    this.Label1.Text = "只能够上传后缀为.jpg,.bmp,.png的图片";
                }
            }
        }



    }

}
