<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/User1.master" CodeFile="OrderList.aspx.cs" Inherits="OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>订单管理</title>   
      
     <link rel="stylesheet" href="../css/gridview.css">
    <link type="text/css" href="css/manageforum.css" rel="stylesheet" />
	<link type="text/css" rel="stylesheet" href="css/button.css" />
    <link type="text/css" rel="stylesheet" href="css/button1.css" />
     <link type="text/css" rel="stylesheet" href="css/OrderInfo.css" />
     
    

<style type="text/css">
    .auto-style2 {
        width: 100%;
        margin-left: 0;
    }
    .auto-style3 {
        width: 120px;
    }
    .auto-style6 {
        width: 100%;
    }
    .auto-style7 {
        width: 100px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
   
        <div class="userTitle">
            <p class="titleType" style="font-size:23px" >订单管理</p>
        </div>
    
    

    <div class="row">
        <div align="center">
            <p style="font-size:15px;color:#000000" >订单状态：</p>&nbsp;
			<div class="row" align="center">
            <div style="display:inline-block">
            
           <asp:DropDownList ID="OrderState" runat="server" Height="40px" Width="220px" style="border-radius: 40px; padding-left:10px">
                <asp:ListItem>请选择订单状态</asp:ListItem>
                
                <asp:ListItem>未发货</asp:ListItem>
                <asp:ListItem>未收货</asp:ListItem>
                <asp:ListItem>已收货</asp:ListItem>              
                <asp:ListItem>已完成</asp:ListItem>
            </asp:DropDownList>
                </div>
            &nbsp;
			<asp:Button class="custom-btn btn-1" id="btnSearch" runat="server" Text="搜索" OnClick="btnSearch_Click" ></asp:Button>
            &nbsp;
            <asp:Button class="custom-btn btn-1" id="btnShowall" runat="server" Text="全部显示" OnClick="btnShowall_Click" ></asp:Button>
        </div>
    </div>
        </br>
        </br>
               <div style="font-size:8px; margin-left:-70px;"> 
        <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound" OnItemCommand="DataList1_ItemCommand" RepeatLayout="Flow">
                    <ItemTemplate>
                        <table align="left" class="ttb" style="padding-left:50px;padding-bottom:40px;padding-top:30px;display:block;width:1000px;margin-bottom:30px;" >
                            <div class="a2" style="font-size:10px;">
                            <tr >
                                
                                <td style="width: 200px">订单编号：<asp:Label ID="orderid" runat="server" Text='<%# Eval("OrderID") %>'></asp:Label>
                                </td>
                                <td  style="width:300px">下单日期：<asp:Label ID="date" runat="server" Text='<%# Eval("OrderDate") %>'></asp:Label>
                                </td>
                                <td style="width: 250px">订单状态：<asp:Label ID="state" runat="server" Text="Label"></asp:Label>
                                </td>
                                <td style="width: 100px;font-weight:bold;">
                                    <asp:LinkButton ID="queren" runat="server" CommandName="State" CommandArgument='<%# Eval("OrderID") %>' >LinkButton</asp:LinkButton>
                                </td>
                                <td style="width: 100px">
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("OrderID") %>' CommandName="Detail">查看详情</asp:LinkButton>
                                </td>
                            </tr>
                            </div>
                            <tr>
                                <td colspan="5">
                                    <table align="left" class="auto-style6">
                                        <tr>
                                            <td>
                                                <asp:DataList ID="DataList2" runat="server">
                                                    <ItemTemplate>
                                                        <table align="left" class="auto-style6" style="margin-bottom:10px;margin-top:20px;">
                                                            <tr style="line-height:60px">
                                                                <td style="width: 150px;line-height:60px">
                                                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("CoverImage") %>' style="width:60px;height:60px" />
                                                                </td>
                                                                <td style="width: 300px; color: #333;-webkit-font-smoothing: antialiased;font-family: '微软雅黑';font-size:15px;font-weight:bold;">
                                                                    <asp:Label ID="goodsname" runat="server" Text='<%# Eval("BookName") %>'></asp:Label>
                                                                </td>
                                                                <td style="width: 120px">单价：
                                                                    <asp:Label ID="price" runat="server" Text='<%# Eval("Price") %>'></asp:Label>元
                                                                </td>
                                                                <td style="width: 100px">数量：
                                                                    <asp:Label ID="num" runat="server" Text='<%# Eval("Num") %>'></asp:Label>
                                                                </td>
                                                                <td style="width: 120px">总计：
                                                                    <asp:Label ID="goodstotal" runat="server" Text='<%# Eval("TotalPrice") %>'></asp:Label>元
                                                                </td>
                                                            </tr>
                                                            <tr></tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="line-height:40px">
                                <td class="auto-style7">&nbsp;</td>
                                <td class="auto-style3">&nbsp;</td>
                                <td  align="right">运费：</td>
                                <td align="center">
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("ShipFee") %>'></asp:Label>
                                </td>
                                <td>元</td>
                            </tr>
                            <tr style="line-height:40px;font-weight:bold;">
                                <td class="auto-style7">&nbsp;</td>
                                <td class="auto-style3">&nbsp;</td>
                                <td align="right" >合计：</td>
                                <td align="center">
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("TotalPrice") %>'></asp:Label>
                                </td>
                                <td>元</td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                   </div>
            
 </div>
    
        
        
        
        
        
        
        
        
        
       
                      

         <div class="row" style="margin: 20px 0 20px 470px;">
    <div class="col-xs-12 col-sm-12 col-md-12">
        <asp:Label ID="labCP" runat="server" Text="【当前为第"></asp:Label><asp:Label ID="labPage" runat="server" Text="1"></asp:Label>页，
        <asp:Label ID="labTP" runat="server" Text="共"></asp:Label><asp:Label ID="labBackPage" runat="server"></asp:Label>页】&nbsp;&nbsp;
        <asp:LinkButton ID="lnkbtnOne" runat="server" Font-Underline="False" ForeColor="#4572b9" OnClick="lnkbtnOne_Click">第一页</asp:LinkButton>&nbsp;&nbsp;
        <asp:LinkButton ID="lnkbtnUp" runat="server" Font-Underline="False" ForeColor="#4572b9" OnClick="lnkbtnUp_Click">上一页</asp:LinkButton> &nbsp;&nbsp;
        <asp:LinkButton ID="lnkbtnNext" runat="server" Font-Underline="False" ForeColor="#4572b9" OnClick="lnkbtnNext_Click">下一页</asp:LinkButton>&nbsp;&nbsp;
        <asp:LinkButton ID="lnkbtnBack" runat="server" Font-Underline="False" ForeColor="#4572b9" OnClick="lnkbtnBack_Click">最后一页</asp:LinkButton> &nbsp; &nbsp;
    </div>
	</div>
        
     <script src="../js/jquery-3.2.1.min.js"></script>
        <script src="../layer/layer.js"></script>
</asp:Content>
