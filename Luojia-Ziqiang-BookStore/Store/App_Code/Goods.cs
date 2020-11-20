using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Goods 的摘要说明
/// </summary>
public class Goods
{
    DB dbObj = new DB();
    public Goods()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }





    /// <summary>
    /// 对商品信息进行模糊查询
    /// </summary>
    /// <param name="strKeyWord">关键信息</param>
    /// <returns>返回查询结果数据表DataTable</returns>
    public DataTable search(string strKeyWord)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_SearchGI");
        SqlParameter key = new SqlParameter("@keywords", SqlDbType.VarChar, 50);//添加参数
        key.Value = strKeyWord;
        myCmd.Parameters.Add(key);
        //执行操作
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbBI");
        return dsTable;
    }

    /// <summary>
    /// 用来截取小数点后nleng位
    /// </summary>
    /// <param name="sString">sString原字符串。</param>
    /// <param name="nLeng">nLeng长度。</param>
    /// <returns>处理后的字符串。</returns>
    public string VarStr(string sString, int nLeng)
    {
        int index = sString.IndexOf(".");
        if (index == -1 || index + nLeng >= sString.Length)
            return sString;
        else
            return sString.Substring(0, (index + nLeng + 1));
    }

    public DataTable getcomment(int bookid,string Class)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_Comment");
        SqlParameter BookID = new SqlParameter("@BookID", SqlDbType.Int, 4);//添加参数
        BookID.Value = bookid;
        myCmd.Parameters.Add(BookID);
        SqlParameter Type = new SqlParameter("@Class", SqlDbType.NVarChar, 10);//添加参数
        Type.Value = Class;
        myCmd.Parameters.Add(Type);
        //执行操作
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbCM");
        return dsTable;
    }

}