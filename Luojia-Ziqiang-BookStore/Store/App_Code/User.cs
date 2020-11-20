using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// User 的摘要说明
/// </summary>
public class User
{
    DB dbObj = new DB();
    public User()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //

    }
    //***************************************登录界面************************************************************
    /// <summary>
    /// 判断用户是否能登录
    /// </summary>
    /// <param name="strName">用户名</param>
    /// <param name="strPwd">用户密码</param>
    /// <returns>返回数据源的数据表</returns>
    public DataTable UserLogin(string strName, string strPwd)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_UserLogin");
        //添加参数(用户名)
        SqlParameter Name = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        Name.Value = strName;
        myCmd.Parameters.Add(Name);
        //添加参数(密码)
        SqlParameter Pwd = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        Pwd.Value = strPwd;
        myCmd.Parameters.Add(Pwd);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbUser");
        return dsTable;
    }
    //***************************************注册界面************************************************************
   
    public int AddNewUser(string strName, string strPassword, string strPhone)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_AddNewUser");
        //添加参数
        SqlParameter name = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        name.Value = strName;
        myCmd.Parameters.Add(name);
        //添加参数
        SqlParameter password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        password.Value = strPassword;
        myCmd.Parameters.Add(password);
        //添加参数
        SqlParameter phone = new SqlParameter("@Phone", SqlDbType.VarChar, 20);
        phone.Value = strPhone;
        myCmd.Parameters.Add(phone);
        //添加参数
        SqlParameter ReturnValue = myCmd.Parameters.Add("ReturnValue", SqlDbType.Int, 4);
        ReturnValue.Direction = ParameterDirection.ReturnValue;
        dbObj.ExecNonQuery(myCmd);
        return Convert.ToInt32(ReturnValue.Value.ToString());
    }

    //***************************************修改界面************************************************************
    /// <summary>
    /// 通过用户ID，获取用户的详细信息
    /// </summary>
    /// <param name="UserID">用户ID代号</param>
    /// <returns>返回数据集的表的集合</returns>
    public DataTable GetUserInfo(int UserID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_GetUI");
        //添加参数
        SqlParameter userId = new SqlParameter("@UserID", SqlDbType.Int, 4);
        userId.Value = UserID;
        myCmd.Parameters.Add(userId);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbUser");
        return dsTable;
    }
    /// <summary>
    /// 通过用户ID，获取用户的头像地址
    /// </summary>
    /// <param name="UserID">用户ID代号</param>
    /// <returns>返回头像地址</returns>
    public string GetHead(int UserID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_getHead");
        //添加参数
        SqlParameter userId = new SqlParameter("@UserID", SqlDbType.Int, 4);
        userId.Value = UserID;
        myCmd.Parameters.Add(userId);
        dbObj.ExecNonQuery(myCmd);
        string image = dbObj.ExecScalar(myCmd);
        return image;
    }
    /// <summary>
    /// 修改用户表的信息
    /// </summary>
    /// <param name="strName">会员名</param>
    /// <param name="strPassword">密码</param>
    /// <param name="strRealName">真实姓名</param>
    /// <param name="blSex">性别</param>
    /// <param name="strPhonecode">电话号码</param>
    /// <param name="strEmail">E_Mail</param>
    /// <param name="strAddress">会员详细地址</param>
    /// <param name="strImage">头像</param>
    /// <param name="IntUserID">用户的ID代号</param>
    public void MedifyUser(string strName, string strPassword, string strRealName, bool blSex, string strPhonecode, string strEmail, string strAddress, string strImage, int IntUserID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_ModifyUser");
        //添加参数
        SqlParameter name = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
        name.Value = strName;
        myCmd.Parameters.Add(name);
        //添加参数
        SqlParameter password = new SqlParameter("@Password", SqlDbType.VarChar, 50);
        password.Value = strPassword;
        myCmd.Parameters.Add(password);
        //添加参数
        SqlParameter realName = new SqlParameter("@RealName", SqlDbType.VarChar, 50);
        realName.Value = strRealName;
        myCmd.Parameters.Add(realName);
        //添加参数
        SqlParameter sex = new SqlParameter("@Sex", SqlDbType.Bit, 1);
        sex.Value = blSex;
        myCmd.Parameters.Add(sex);
        //添加参数
        SqlParameter phonecode = new SqlParameter("@Phonecode", SqlDbType.VarChar, 20);
        phonecode.Value = strPhonecode;
        myCmd.Parameters.Add(phonecode);
        //添加参数
        SqlParameter email = new SqlParameter("@Email", SqlDbType.VarChar, 50);
        email.Value = strEmail;
        myCmd.Parameters.Add(email);
        //添加参数
        SqlParameter address = new SqlParameter("@Address", SqlDbType.VarChar, 200);
        address.Value = strAddress;
        myCmd.Parameters.Add(address);
        //添加参数
        SqlParameter headImage = new SqlParameter("@HeadImage", SqlDbType.VarChar, 300);
        headImage.Value = strImage;
        myCmd.Parameters.Add(headImage);
        //添加参数
        SqlParameter userId = new SqlParameter("@MemberId", SqlDbType.Int, 4);
        userId.Value = IntUserID;
        myCmd.Parameters.Add(userId);
        dbObj.ExecNonQuery(myCmd);
    }

    /// <summary>
    /// 添加评论
    /// </summary>
    /// <param name="bookid">图书id</param>
    /// <param name="userid">用户ID代号</param>
    /// <param name="content">评论内容</param>
    /// <param name="class">来源</param>
    public void AddComment(int BookID,int UserID,string Content,string Class)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_AddComment");
        //添加参数
        SqlParameter bookid = new SqlParameter("@BookID", SqlDbType.Int, 4);
        bookid.Value = BookID;
        myCmd.Parameters.Add(bookid);
        //添加参数
        SqlParameter userId = new SqlParameter("@UserID", SqlDbType.Int, 4);
        userId.Value = UserID;
        myCmd.Parameters.Add(userId);
        //添加参数
        SqlParameter content = new SqlParameter("@Content", SqlDbType.VarChar, 10000);
        content.Value = Content;
        myCmd.Parameters.Add(content);
        //添加参数
        SqlParameter clas = new SqlParameter("@Class", SqlDbType.NVarChar, 10);
        clas.Value = Class;
        myCmd.Parameters.Add(clas);
        dbObj.ExecNonQuery(myCmd);
    }
    
    //确认收货
    public int ChangeState(int userid, int state)
    {
        string change = "update tb_User set State=" + state + " where UserID=" + userid;
        SqlCommand myCmd = dbObj.GetCommandStr(change);
        int result = dbObj.ExecNonQuery(myCmd);
        return result;
    }

    //删除帖子
    public int DelPost(int PostID)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_DelPost");
        //添加参数
        myCmd.Parameters.Add("@PostID", SqlDbType.Int, 4);
        myCmd.Parameters["@PostID"].Value = PostID;      
        dbObj.ExecNonQuery(myCmd);
        int result = dbObj.ExecNonQuery(myCmd);
        return result;
    }

    public DataTable SearchPersonalGoods(string strKeyWord, int index, object userid)
    {
        string sql = "select * from tb_PersonalGoods where UserID=" + userid ;
        switch (index)
        {
            case 0: sql += "and ((GoodsName like '%'+CONVERT(nvarchar(100),'" + strKeyWord + "')+'%') or (Class like '%'+CONVERT(nvarchar(20),'" + strKeyWord + "')+'%') or  (Introduction like '%' + CONVERT(nvarchar(MAX), '" + strKeyWord + "') + '%'))"; break;
            case 1: sql += "and (GoodsName like '%'+CONVERT(nvarchar(100),'" + strKeyWord + "')+'%')"; break;
            case 2: sql += "and (Class like '%'+CONVERT(nvarchar(20),'" + strKeyWord + "')+'%')"; break;          
            case 3: sql += "and Price=" + float.Parse(strKeyWord); break;
            case 4: sql += "and (Introduction like '%'+CONVERT(nvarchar(MAX),'" + strKeyWord + "')+'%')"; break;
        }
        SqlCommand myCmd = dbObj.GetCommandStr(sql);
        //执行操作
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbSPR");
        return dsTable;
    }

    public DataTable SearchOrderInfo(int index, object userid)
    {
        int state = 1;
        switch (index)
        {
            case 1: state = 1; break;
            case 2: state = 2; break;
            case 3: state = 3; break;
            case 4: state = 4; break;
        }
        string sql = "select * from tb_OrderInfo where UserID=" + userid + "and SendState=" + state;
        SqlCommand myCmd = dbObj.GetCommandStr(sql);
        //执行操作
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbOI");
        return dsTable;
    }


}