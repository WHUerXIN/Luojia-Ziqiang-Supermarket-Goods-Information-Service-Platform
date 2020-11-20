using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Detail 的摘要说明
/// </summary>
public class Detail
{
    public Detail()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    private int detailid;
    private int goodid;
    private string goodname;
    private float price;
    private int num;
    private float totalprice;
    private int stock;
    private int orderid;

    public int Detailid { get => detailid; set => detailid = value; }
    public int Goodid { get => goodid; set => goodid = value; }
    public string Goodname { get => goodname; set => goodname = value; }
    public float Price { get => price; set => price = value; }
    public int Num { get => num; set => num = value; }
    public float Totalprice { get => totalprice; set => totalprice = value; }
    public int Stock { get => stock; set => stock = value; }
    public int Orderid { get => orderid; set => orderid = value; }
}