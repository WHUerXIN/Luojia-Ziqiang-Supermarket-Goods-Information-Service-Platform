using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Orders 的摘要说明
/// </summary>
public class Orders
{
    DB dbObj = new DB();
    public Orders()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// <summary>
    /// 向订单信息表添加信息
    /// </summary>
    /// <param name="fltBooksFee">商品总费用</param>
    /// <param name="fltShipFee">运输总费用</param>
    /// <param name="strShipType">运输方式</param>
    /// <param name="intUserID">用户ID</param>
    /// <param name="strName">接收人姓名</param>
    /// <param name="strPhone">接收人电话</param>
    /// <param name="strAddress">接收人详细地址</param>
    /// <param name="strRemark">留言</param>
    /// <returns>返回订单号</returns>
    public int AddOrder(float fltBooksFee, float fltShipFee, string strShipType, int intUserID, string strName, string strPhone, string strAddress, string strRemark)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_AddOI");
        //添加参数
        SqlParameter booksFee = new SqlParameter("@BooksFee", SqlDbType.Float, 8);
        booksFee.Value = fltBooksFee;
        myCmd.Parameters.Add(booksFee);
        //添加参数
        SqlParameter shipFee = new SqlParameter("@ShipFee", SqlDbType.Float, 8);
        shipFee.Value = fltShipFee;
        myCmd.Parameters.Add(shipFee);
        //添加参数
        SqlParameter shipType = new SqlParameter("@ShipType", SqlDbType.VarChar, 50);
        shipType.Value = strShipType;
        myCmd.Parameters.Add(shipType);
        //添加参数
        SqlParameter UserID = new SqlParameter("@UserID", SqlDbType.Int, 4);
        UserID.Value = intUserID;
        myCmd.Parameters.Add(UserID);
        //添加参数
        SqlParameter name = new SqlParameter("@ReceiverName", SqlDbType.VarChar, 50);
        name.Value = strName;
        myCmd.Parameters.Add(name);
        //添加参数
        SqlParameter phone = new SqlParameter("@ReceiverPhone", SqlDbType.VarChar, 20);
        phone.Value = strPhone;
        myCmd.Parameters.Add(phone);
        //添加参数
        SqlParameter address = new SqlParameter("@ReceiverAddress", SqlDbType.VarChar, 200);
        address.Value = strAddress;
        myCmd.Parameters.Add(address);
        //添加参数
        SqlParameter remark = new SqlParameter("@remark", SqlDbType.VarChar, 300);
        remark.Value = strRemark;
        myCmd.Parameters.Add(remark);
        //添加参数
        SqlParameter orderID = myCmd.Parameters.Add("@OrderID", SqlDbType.Int, 4);
        orderID.Direction = ParameterDirection.Output;
        dbObj.ExecNonQuery(myCmd);
        return Convert.ToInt32(orderID.Value.ToString());
    }
    /// <summary>
    /// 向订单的明细表中添加信息
    /// </summary>
    /// <param name="IntBookID">商品编号</param>
    /// <param name="IntNum">数量</param>
    /// <param name="IntOrderID">订单号</param>
    /// <param name="fltTotalPrice">总价</param>
    public void AddDetail(int IntBookID, int IntNum, int IntOrderID, float fltTotalPrice)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("proc_AddODetail");
        //添加参数
        SqlParameter bookID = new SqlParameter("@BookID", SqlDbType.Int, 4);
        bookID.Value = IntBookID;
        myCmd.Parameters.Add(bookID);
        //添加参数
        SqlParameter num = new SqlParameter("@Num", SqlDbType.Int, 4);
        num.Value = IntNum;
        myCmd.Parameters.Add(num);
        //添加参数
        SqlParameter orderID = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        orderID.Value = IntOrderID;
        myCmd.Parameters.Add(orderID);
        //添加参数
        SqlParameter totalPrice = new SqlParameter("@TotalPrice", SqlDbType.Float, 8);
        totalPrice.Value = fltTotalPrice;
        myCmd.Parameters.Add(totalPrice);
        dbObj.ExecNonQuery(myCmd);

    }
    public DataTable ExactOrderSearch(int IntOrderID, int IntNF, string strName, int IntIsConfirm, int IntIsSend, int IntIsEnd)
    {
        SqlCommand myCmd = dbObj.GetCommandProc("Proc_SearchOI");
        //添加参数
        SqlParameter orderId = new SqlParameter("@OrderID", SqlDbType.Int, 4);
        orderId.Value = IntOrderID;
        myCmd.Parameters.Add(orderId);
        //添加参数
        SqlParameter nf = new SqlParameter("@NF", SqlDbType.Int, 4);
        nf.Value = IntNF;
        myCmd.Parameters.Add(nf);
        //添加参数
        SqlParameter name = new SqlParameter("@Name", SqlDbType.VarChar, 50);
        name.Value = strName;
        myCmd.Parameters.Add(name);
        //添加参数
        SqlParameter confirm = new SqlParameter("@IsConfirm", SqlDbType.Int, 4);
        confirm.Value = IntIsConfirm;
        myCmd.Parameters.Add(confirm);
        //添加参数
        SqlParameter send = new SqlParameter("@IsSend", SqlDbType.Int, 4);
        send.Value = IntIsSend;
        myCmd.Parameters.Add(send);
        //添加参数
        SqlParameter end = new SqlParameter("@IsEnd", SqlDbType.Int, 4);
        end.Value = IntIsEnd;
        myCmd.Parameters.Add(end);
        dbObj.ExecNonQuery(myCmd);
        DataTable dsTable = dbObj.GetDataSet(myCmd, "tbOI");
        return dsTable;
    }

    public int ChangeState(int orderid, int state)
    {
        string change = "update tb_OrderInfo set SendState=" + state + " where OrderID=" + orderid;
        SqlCommand myCmd = dbObj.GetCommandStr(change);
        int result = dbObj.ExecNonQuery(myCmd);
        return result;
    }
}