using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Common 的摘要说明
/// </summary>
public class Common
{
    public Common()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public void Msg(string info, Page p)
    {
        string script = "<script>layer.msg('" + info + "')</script>";
        p.ClientScript.RegisterStartupScript(p.GetType(), "", script);
    }

    public void Alert(string info, string url, Page p)
    {
        string script = "<script>layer.alert('" + info + "',function(){window.location.href='"+url+"';});</script>";
        p.ClientScript.RegisterStartupScript(p.GetType(), "", script);
    }

    public void MsgUrl(string info, Page p)
    {
        string script = "<script>layer.msg('" + info + "',function(){});</script>";
        p.ClientScript.RegisterStartupScript(p.GetType(), "", script);
    }

    public void Msgtip(string info, Page p)
    {
        string script = "<script>layer.msg('" + info + "', {icon: 0})</script>";
        p.ClientScript.RegisterStartupScript(p.GetType(), "", script);
    }
    public void Msgfault(string info, Page p)
    {
        string script = "<script>layer.msg('" + info + "', {icon: 2})</script>";
        p.ClientScript.RegisterStartupScript(p.GetType(), "", script);
    }
    public void Msgyes(string info, Page p)
    {
        string script = "<script>layer.msg('" + info + "', {icon: 1})</script>";
        p.ClientScript.RegisterStartupScript(p.GetType(), "", script);
    }




    /// <summary>
    /// 说明：MessageBox用来在客户端弹出对话框，关闭对话框返回指定页。
    /// 参数：TxtMessage 对话框中显示的内容。
    /// Url 对话框关闭后，跳转的页
    /// </summary>
    public string MessageBox(string TxtMessage, string Url)
    {
        string str;
        str = "<script language=javascript>window.alert('" + TxtMessage + "');window.location='" + Url + "';</script>";
        return str;
    }
    /// <summary>
    /// 说明：MessageBox用来在客户端弹出对话框。
    /// 参数：TxtMessage 对话框中显示的内容。
    /// </summary>
    public string MessageBox(string TxtMessage)
    {
        string str;
        str = "<script defer='defer' language=javascript>alert('" + TxtMessage + "')</script>";
        return str;
    }
    /// <summary>
    /// 说明：MessageBoxPag用来在客户端弹出对话框，关闭对话框返回原页。
    /// 参数：TxtMessage 对话框中显示的内容。
    /// </summary>
    public string MessageBoxPage(string TxtMessage)
    {
        string str;
        str = "<script language=javascript>alert('" + TxtMessage + "');</script>";
        return str;
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
}