using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// OrderProperty 的摘要说明
/// </summary>
public class OrderProperty
{
    public OrderProperty()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    private int IntOrderNo;  //订单编号
    private DateTime dtOrderTime;//下单时间
    private float fltProductPrice;//商品总金额
    private float fltShipPrice;//商品运费
    private float fltTotalPrice;//订单总金额
    private int IntUserID;//用户ID
    private string strReceiverName;//收货人姓名
    private string strReceiverPhone;//联系人电话
    private string strReceiverAddress;//购货人地址
    private string strRemark;//留言
    private string strShipType;//运输类型
    private int IntSendState;//状态

    public int OrderNo
    {
        get
        {
            return IntOrderNo;
        }
        set
        {
            IntOrderNo = value;
        }

    }
    public int UserID
    {
        get
        {
            return IntUserID;
        }
        set
        {
            IntUserID = value;
        }

    }
    public DateTime OrderTime
    {
        get
        {
            return dtOrderTime;
        }
        set
        {
            dtOrderTime = value;

        }
    }
    public float ProductPrice
    {
        get
        {
            return fltProductPrice;
        }
        set
        {
            fltProductPrice = value;
        }

    }
    public float ShipPrice
    {
        get { return fltShipPrice; }
        set { fltShipPrice = value; }
    }
    public float TotalPrice
    {
        get { return fltTotalPrice; }
        set { fltTotalPrice = value; }
    }
    public string ReceiverName
    {
        get
        {
            return strReceiverName;
        }
        set
        {
            strReceiverName = value;

        }
    }
    public string ReceiverPhone
    {
        get
        {
            return strReceiverPhone;
        }
        set
        {
            strReceiverPhone = value;
        }

    }
    public string Remark
    {
        get
        {
            return strRemark;
        }
        set
        {
            strRemark = value;

        }
    }
    public string ReceiverAddress
    {
        get
        {
            return strReceiverAddress;
        }
        set
        {
            strReceiverAddress = value;
        }

    }

    public string ShipType
    {
        get
        {
            return strShipType;
        }
        set
        {
            strShipType = value;
        }

    }

    public int SendState
    {
        get
        {
            return IntSendState;
        }
        set
        {
            IntSendState = value;
        }

    }

}