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
using System.Text.RegularExpressions;

public partial class Login : System.Web.UI.Page
{
    DB dbObj = new DB();
    User ucObj = new User();
    Common ccObj = new Common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { ViewState["back_no"] = 0; }
        ViewState["back_no"] = Convert.ToInt32(ViewState["back_no"]) + 1;
    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        //清空Session对象
        Session["UserID"] = null;
        Session["Username"] = null;
        Session["HeadImage"] = null; 
        if (this.txtUserName.Text.Trim() == "" || this.txtPwd.Text.Trim() == "")
        {
            ccObj.Msg("登录名和密码不能为空！", this);
        }
        else
        {
                //调用UserClass类的UserLogin方法判断用户是否为合法用户
                DataTable dsTable = ucObj.UserLogin(this.txtUserName.Text.Trim(), this.txtPwd.Text.Trim());
                if (dsTable != null) //判断用户是否存在
                {
                    if ((bool)dsTable.Rows[0]["State"])
                    {
                        Session["UserID"] = Convert.ToInt32(dsTable.Rows[0][0].ToString()); //保存用户ID
                        Session["UserName"] = dsTable.Rows[0][1].ToString(); //保存用户登录名
                        Session["HeadImage"] = dsTable.Rows[0]["HeadImage"].ToString();
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>layer.alert('登录成功！',function(){history.go(-" + ViewState["back_no"].ToString() + ");});</script>");
                    }
                    else
                    {
                        ccObj.Msg("该账号被冻结！请联系管理员", this);
                    }
                }
                else
                {
                    ccObj.Msg("您的登录有误，请核对后再重新登录！", this);
                }
            
        }
    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        //判断是否输入必要的信息
        if (this.txtUser.Text.Trim() == "" && this.txtPass.Text.Trim() == "" && this.txtPassCon.Text.Trim() == "" && this.txtPhone.Text.Trim() == "")
        {
            ccObj.Msg("请输入必要的信息！", this);
        }
        else
        {
            if(this.txtPass.Text == this.txtPassCon.Text)
            {
                if (IsValidPhone(txtPhone.Text.Trim()))
                {//将用户输入的信息插入到用户表tb_Member中
                    int IntReturnValue = ucObj.AddNewUser(txtUser.Text.Trim(), txtPass.Text.Trim(), txtPhone.Text.Trim());
                    if (IntReturnValue == 100)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>layer.alert('恭喜您，注册成功！',function(){history.go(-" + ViewState["back_no"].ToString() + ");});</script>");
                    }
                    else
                    {
                        ccObj.Msg("注册失败，该名字已存在！", this);
                    }
                }
                else
                {
                    ccObj.Msg("请输入正确的手机号码！", this);
                }
            }
            else
            {
                this.txtPass.Text = "";
                this.txtPassCon.Text = "";
                this.txtPass.Focus();
                ccObj.Msg("两次密码不一致！", this);
            }
        }
    }
    public bool IsValidPhone(string num)
    {//验证电话号码
        return Regex.IsMatch(num, @"(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}$");
    }
}