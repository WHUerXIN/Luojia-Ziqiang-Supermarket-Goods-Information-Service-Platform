<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/User1.master" CodeFile="Order.aspx.cs" Inherits="Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>订单管理</title>   
      
     <link rel="stylesheet" href="../css/gridview.css">
    <link type="text/css" href="css/manageforum.css" rel="stylesheet" />
	<link type="text/css" rel="stylesheet" href="css/button.css" />
    <link type="text/css" rel="stylesheet" href="css/button1.css" />
     
    

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
 
    <br/>
    <asp:GridView ID="goods" runat="server" CssClass="GridViewStyle" Width="70%" 
		AutoGenerateColumns="False" OnPageIndexChanging="goods_PageIndexChanging"  PageSize="10" OnRowCommand="goods_RowCommand"  >
           <HeaderStyle CssClass="GridViewHeaderStyle" ></HeaderStyle>        
           <Columns>
                     
                            <asp:BoundField  DataField="OrderID" HeaderText="订单编号" ReadOnly="True">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OrderDate" HeaderText="订单日期">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
           
                            <asp:BoundField DataField="BooksFee" HeaderText="书费">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ShipFee" HeaderText="邮费">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                           <asp:BoundField DataField="TotalPrice" HeaderText="总价">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ShipType" HeaderText="邮寄方式">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UserID" HeaderText="用户ID">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ReceiverName" HeaderText="收货人姓名">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ReceiverPhone" HeaderText="收货人电话">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ReceiverAddress" HeaderText="收货人地址">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="remark" HeaderText="备注">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             
                            <asp:TemplateField HeaderText="订单状态">
                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
			                      <ItemStyle HorizontalAlign="Center" ></ItemStyle>
			                  <ItemTemplate>
				                    <%# GetStatus(Convert.ToInt32(DataBinder.Eval(Container.DataItem, "OrderID").ToString()))%>
			                  </ItemTemplate>  
                            </asp:TemplateField >
                            <asp:ButtonField  CommandName="Btn_Operation" Text="确认收货"  ControlStyle-ForeColor="darkblue"  />
                            <asp:TemplateField HeaderText="">
                               <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
			                   <ItemStyle HorizontalAlign="Center" ></ItemStyle>

			                   <ItemTemplate >
				                <a  href='Details.aspx?OrderID=<%# DataBinder.Eval(Container.DataItem, "OrderID")%>' target="_self" style="color:darkblue;">
				              查看详情</a>
			                </ItemTemplate>            
                            </asp:TemplateField>
                           
                            
                        </Columns>


                        <FooterStyle CssClass="GridViewFooterStyle" />
                        <RowStyle CssClass="GridViewRowStyle"  />
                        <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                        <PagerStyle CssClass="GridViewPagerStyle"/>
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                       <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                       <SortedDescendingCellStyle BackColor="#E5E5E5" />
                       <SortedDescendingHeaderStyle BackColor="#242121" />
                      <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" /> 
                    </asp:GridView>


         <div class="page">
             <div class="con">
            <asp:Label ID="labCP" runat="server" Text="当前页码为："></asp:Label>
            [<asp:Label ID="labPage" runat="server" Text="1"></asp:Label>]
            <asp:Label ID="labTP" runat="server" Text="总页码为："></asp:Label>
            [<asp:Label ID="labBackPage" runat="server"></asp:Label>]
            <asp:LinkButton ID="lnkbtnOne" runat="server" Font-Underline="False" ForeColor="white" OnClick="lnkbtnOne_Click">第一页</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lnkbtnUp" runat="server" Font-Underline="False" ForeColor="white" OnClick="lnkbtnUp_Click">上一页</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lnkbtnNext" runat="server" Font-Underline="False" ForeColor="white" OnClick="lnkbtnNext_Click">下一页</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lnkbtnBack" runat="server" Font-Underline="False" ForeColor="white" OnClick="lnkbtnBack_Click">最后一页</asp:LinkButton>&nbsp;
        </div>
         </div>
        </div>
     <script src="../js/jquery-3.2.1.min.js"></script>
        <script src="../layer/layer.js"></script>
</asp:Content>
