<%@ Page Language="C#" AutoEventWireup="true"MasterPageFile="~/User1.master"  CodeFile="Details.aspx.cs" Inherits="Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>订单详情</title>   
        <link rel="stylesheet" href="../css/gridview.css">
    <link type="text/css" href="css/manageforum.css" rel="stylesheet" />
	<link type="text/css" rel="stylesheet" href="css/button.css" />
    <link type="text/css" rel="stylesheet" href="css/details.css" />
    <link type="text/css" rel="stylesheet" href="css/buttonx.css" />
    
     <link href="http://fonts.googleapis.com/css?family=Oxygen|Marck+Script" rel="stylesheet" type="text/css">
    
    <style>
	
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
      <div  class="userTitle">
            <p class="titleType" style="font-size:23px" >订单详情</p>
        </div>

    <div class="row" style="width:106%;display:flex;vertical-align: middle;">
			
				<div class="span4" style="color:#372d2d">
				
					<div class="slate">
					
						<div class="page-header">
							<h2>订单基本信息</h2>
						</div>
						
						<p><strong>单号:</strong><asp:Label ID="id" runat="server" Text="Label"></asp:Label></p>
						<p><strong>订单日期:</strong><asp:Label ID="date" runat="server" Text="Label"></asp:Label></p>
                        <p><strong>下单人ID:</strong><asp:Label ID="userid" runat="server" Text="Label"></asp:Label></p>
						<p><strong>总书费:</strong><asp:Label ID="booksfee" runat="server" Text="Label"></asp:Label></p>
						<p><strong>总运费:</strong><asp:Label ID="shipfee" runat="server" Text="Label"></asp:Label></p>
						<p><strong>合计:</strong><asp:Label ID="total" runat="server" Text="Label"></asp:Label></p>
						<p><strong>邮寄方式:</strong><asp:Label ID="shiptype" runat="server" Text="Label"></asp:Label> </p>

					</div>
				
				</div>
			
				<div class="span3" style="color:#372d2d">
				
					<div class="slate">
					
						<div class="page-header">
							<h2>备注</h2>
						</div>
					
						<p><asp:Label ID="remark" runat="server" Text="Label" ></asp:Label></p>
						
					</div>
				
				</div>
			
				<div class="span3" style="color:#372d2d">
				
					<div class="slate">
					
						<div class="page-header">
							<h2>收货信息</h2>
						</div>
					
						<p><strong>收货人姓名:</strong><asp:Label ID="rname" runat="server" Text="Label"></asp:Label></p>
					    <p><strong>收货人电话:</strong><asp:Label ID="rphone" runat="server" Text="Label"></asp:Label></p>
                        <p><strong>收货人地址:</strong><asp:Label ID="raddress" runat="server" Text="Label"></asp:Label></p>
					</div>
				
				</div>
			
			</div>    
    
    
    
    
   
    <div class="page" style="position:center;color:white;background-color: #372d2d;width:20%;margin:auto;">       
        <asp:Label   ID="Label1" runat="server" Text="订单编号："  ></asp:Label>
        <asp:Label ID="orderid" runat="server" Text=""></asp:Label>
    </div>
        <br />
       <asp:GridView ID="goods" runat="server" CssClass="GridViewStyle" Width="70%" 
		AutoGenerateColumns="False" OnPageIndexChanging="goods_PageIndexChanging"  PageSize="10"   >
                     <HeaderStyle CssClass="GridViewHeaderStyle"></HeaderStyle>
                        <Columns>       
                            <asp:BoundField DataField="DetailID" HeaderText="订单记录编号" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>  
                            <asp:BoundField DataField="BookName" HeaderText="商品名称">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>           
                            <asp:BoundField DataField="Num" HeaderText="数量">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TotalPrice" HeaderText="总价">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>                         
                         
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
    <div class="btnBack">
        <asp:Button class="custom-btn btn-1" id="Button1" runat="server" Text="返回"  style="border-radius:40px; background-color:transparent;" OnClick="btnBack_Click" ></asp:Button>
     </div>   

              
</asp:Content>
