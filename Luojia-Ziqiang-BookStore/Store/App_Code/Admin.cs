using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
/// <summary>
/// Admin 的摘要说明
/// </summary>
public class Admin
{
    DB dbObj = new DB();
    public Admin()
    {
    }
   
    /// <summary>
    /// 实现随机验证码
    /// </summary>
    /// <param name="n">显示验证码的个数</param>
    /// <returns>返回生成的随机数</returns>
    public string RandomNum(int n) //
    {
        //定义一个包括数字、大写英文字母和小写英文字母的字符串
        string strchar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
        //将strchar字符串转化为数组
        //String.Split 方法返回包含此实例中的子字符串（由指定Char数组的元素分隔）的 String 数组。
        string[] VcArray = strchar.Split(',');
        string VNum = "";
        //记录上次随机数值，尽量避免产生几个一样的随机数           
        int temp = -1;
        //采用一个简单的算法以保证生成随机数的不同
        Random rand = new Random();
        for (int i = 1; i < n + 1; i++)
        {
            if (temp != -1)
            {
                //unchecked 关键字用于取消整型算术运算和转换的溢出检查。
                //DateTime.Ticks 属性获取表示此实例的日期和时间的刻度数。
                rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
            }
            //Random.Next 方法返回一个小于所指定最大值的非负随机数。
            int t = rand.Next(61);
            if (temp != -1 && temp == t)
            {
                return RandomNum(n);
            }
            temp = t;
            VNum += VcArray[t];
        }
        return VNum;//返回生成的随机数
    }

    /// <summary>
    /// 对电子资源信息进行多标签模糊查询
    /// </summary>
    /// <param name="strKeyWord">关键字</param>
    /// <param name="index">标签</param>
    /// <returns>数据表</returns>
    public DataTable searchresource(string strKeyWord, int index)
    {
        string sql = "select * from tb_Resource ";
        switch (index)
        {
            
            case 0: sql += "where ResourceID=" + int.Parse(strKeyWord); break;
            case 1: sql += "where (Title like '%'+CONVERT(nvarchar(100),'" + strKeyWord + "')+'%')"; break;
            case 2: sql += "where (Introduction like '%'+CONVERT(nvarchar(MAX),'" + strKeyWord + "')+'%')"; break;
            case 3: sql += "where (Class like '%'+CONVERT(nvarchar(20),'" + strKeyWord + "')+'%')"; break;
            case 4: sql += "where Link='" + strKeyWord + "'"; break;
            case 5: sql += "where Password='" + strKeyWord + "'"; break;
        }
        SqlCommand myCmd = dbObj.GetCommandStr(sql);
        //执行操作
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbSRI");
        return dsTable;
    }

    /// <summary>
    /// 对实体书信息进行多标签模糊查询
    /// </summary>
    /// <param name="strKeyWord">关键字</param>
    /// <param name="index">标签</param>
    /// <returns>数据表</returns>
    public DataTable searchofficialbook(string strKeyWord, int index)
    {
        string sql = "select * from tb_OfficialBook ";
        switch (index)
        {
           
            case 0: sql += "where BookID=" + int.Parse(strKeyWord); break;
            case 1: sql += "where (Course like '%'+CONVERT(nvarchar(50),'" + strKeyWord + "')+'%')"; break;
            case 2: sql += "where (Type like '%'+CONVERT(nvarchar(50),'" + strKeyWord + "')+'%')"; break;
            case 3: sql += "where (BookName like '%'+CONVERT(nvarchar(100),'" + strKeyWord + "')+'%')"; break;
            case 4: sql += "where (Class like '%'+CONVERT(nvarchar(20),'" + strKeyWord + "')+'%')"; break;
            case 5: sql += "where (Publisher like '%'+CONVERT(nvarchar(100),'" + strKeyWord + "')+'%')"; break;
            case 6: sql += "where (Author like '%'+CONVERT(nvarchar(100),'" + strKeyWord + "')+'%')"; break;
            case 7: sql += "where ISBN='" + strKeyWord + "'"; break;
            case 8: sql += "where Edition=" + int.Parse(strKeyWord); break;
            case 9: sql += "where PublishDate=convert(date,'" + strKeyWord + "')"; break;
            case 10: sql += "where Pages=" + int.Parse(strKeyWord); break;
            case 11: sql += "where Price=" + float.Parse(strKeyWord); break;
            case 12: sql += "where (Introduction like '%'+CONVERT(nvarchar(MAX),'" + strKeyWord + "')+'%')"; break;
        }
        SqlCommand myCmd = dbObj.GetCommandStr(sql);
        //执行操作
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbSRI");
        return dsTable;
    }

    /// <summary>
    /// 对管理员信息进行多标签模糊查询
    /// </summary>
    /// <param name="strKeyWord">关键字</param>
    /// <param name="index">标签</param>
    /// <returns>数据表</returns>
    public DataTable searchadmin(string strKeyWord, int index)
    {
        string sql = "select * from tb_Admin ";
        switch (index)
        {
            
            case 0: sql += "where AdminID=" + int.Parse(strKeyWord); break;
            case 1: sql += "where AdminName='" + strKeyWord + "'"; break;
            case 2: sql += "where Password='" + strKeyWord + "'"; break;
            case 3: sql += "where RealName='" + strKeyWord + "'"; break;
            case 4: sql += "where (Email like '%'+CONVERT(varchar(50),'" + strKeyWord + "')+'%')"; break;
        }
        SqlCommand myCmd = dbObj.GetCommandStr(sql);
        //执行操作
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbAI");
        return dsTable;
    }

    /// <summary>
    /// 对订单信息进行按单号查询
    /// </summary>
    /// <param name="strKeyWord">关键字</param>
    /// <returns>数据表</returns>
    public DataTable searchorderinfo(string strKeyWord)
    {
        string sql = "select * from tb_OrderInfo where OrderID=" + int.Parse(strKeyWord);
        SqlCommand myCmd = dbObj.GetCommandStr(sql);
        //执行操作
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbOI");
        return dsTable;
    }

    /// <summary>
    /// 对库存进行按商品编号查询
    /// </summary>
    /// <param name="strKeyWord">关键字</param>
    /// <returns>数据表</returns>
    public DataTable searchstock(string strKeyWord)
    {
        string sql = "select * from tb_Stock where BookID=" + int.Parse(strKeyWord);
        SqlCommand myCmd = dbObj.GetCommandStr(sql);
        //执行操作
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbSS");
        return dsTable;
    }

    /// <summary>
    /// 对用户信息进行多标签模糊查询
    /// </summary>
    /// <param name="strKeyWord">关键字</param>
    /// <param name="index">标签</param>
    /// <returns>数据表</returns>
    public DataTable searchuser(string strKeyWord, int index)
    {
        string sql = "select * from tb_User ";
        int sex=0;
        if (strKeyWord.Equals("女"))
            sex = 1;

        int state = 1;
        if (strKeyWord.Equals("已冻结"))
            state = 0;
        switch (index)
        {
            
            case 0: sql += "where UserID=" + int.Parse(strKeyWord); break;
            case 1: sql += "where UserName='" + strKeyWord + "'"; break;
            case 2: sql += "where Password='" + strKeyWord + "'"; break;
            case 3: sql += "where RealName='" + strKeyWord + "'"; break;
            case 4: sql += "where Sex=" + sex; break;
            case 5: sql += "where Phone='" + strKeyWord + "'"; break;
            case 6: sql += "where (Email like '%'+CONVERT(varchar(50),'" + strKeyWord + "')+'%')"; break;
            case 7: sql += "where(Address like '%'+CONVERT(nvarchar(200),'" + strKeyWord + "')+'%')"; break; 
            case 8: sql += "where State=" + state ; break;
        }
        SqlCommand myCmd = dbObj.GetCommandStr(sql);
        //执行操作
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbUI");
        return dsTable;
    }

    /// <summary>
    /// 对帖子信息进行多标签模糊查询
    /// </summary>
    /// <param name="strKeyWord">关键字</param>
    /// <param name="index">标签</param>
    /// <returns>数据表</returns>
    public DataTable searchpost(string strKeyWord, int index)
    {
        string sql = "select * from tb_Post ";
        switch (index)
        {
           
            case 0: sql += "where PostID=" + int.Parse(strKeyWord); break;
            case 1: sql += "where UserID=" + int.Parse(strKeyWord); break;
            case 2: sql += "where (Title like '%'+CONVERT(varchar(100),'" + strKeyWord + "')+'%')"; break;
            case 3: sql += "where (Content like '%'+CONVERT(varchar(MAX),'" + strKeyWord + "')+'%')"; break;
            case 4: sql += "where PostTime='" + strKeyWord + "'"; break;
        }
        SqlCommand myCmd = dbObj.GetCommandStr(sql);
        //执行操作
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbPI");
        return dsTable;
    }
}
 
