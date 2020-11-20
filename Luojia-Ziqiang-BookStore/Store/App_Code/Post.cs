using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Post 的摘要说明
/// </summary>
public class Post
{
    public Post()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    private int PostID;  //编号
    private int UserID;  //用户号
    private string Title;  //标题
    private string PostTime;  //发布时间

    public int PostID1 { get => PostID; set => PostID = value; }
    public int UserID1 { get => UserID; set => UserID = value; }
    public string Title1 { get => Title; set => Title = value; }
    public string PostTime1 { get => PostTime; set => PostTime = value; }
}