<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/User1.master" CodeFile="PersonalGoods.aspx.cs" Inherits="PersonalGoods" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>个人商品管理</title>   
        <link rel="stylesheet" href="../css/gridview.css">
    <link type="text/css" href="css/manageforum.css" rel="stylesheet" />
	<link type="text/css" rel="stylesheet" href="css/button.css" />
    <link type="text/css" rel="stylesheet" href="css/buttonx.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
    
        <div  class="userTitle">
            <p class="titleType" style="font-size:23px" >个人商品管理</p>
        </div>
        <div class="row" align="center">
            <div style="display:inline-block">
            <p style="font-size:15px;color:#000000" >检索目标：</p>
           <asp:DropDownList ID="biaoqian" runat="server" Height="40px" Width="220px" style="border-radius: 40px; padding-left:10px">
                <asp:ListItem>所有</asp:ListItem>
                <asp:ListItem>商品名称</asp:ListItem>
                <asp:ListItem>类别</asp:ListItem>
                <asp:ListItem>价格</asp:ListItem>              
                <asp:ListItem>介绍</asp:ListItem>
            </asp:DropDownList>
            </div>
            <div style="display:inline-block">
            <p style="font-size:15px;color:#000000" >关键字：</p>
            &nbsp
			<asp:TextBox ID="txtKey" runat="server" CssClass="form-control custom-control-cell" Height="40px" Width="220px" style="border-radius: 40px;padding-left:10px" AutoCompleteType="Disabled" ></asp:TextBox>&nbsp;
			&nbsp
                <asp:Button class="custom-btn btn-1" style="border-radius: 40px;" ID="btnSearch" runat="server" Text="搜索"   OnClick="btnSearch_Click"  ></asp:Button>
            
            </div>
            &nbsp;
            <asp:Button class="custom-btn btn-1" id="btnShowall" runat="server" style="border-radius: 40px;" Text="全部显示" OnClick="btnShowall_Click" ></asp:Button>
            
            </div>
   <br/>
      <asp:GridView ID="goods" runat="server" CssClass="GridViewStyle" Width="70%" 
		AutoGenerateColumns="False" OnPageIndexChanging="goods_PageIndexChanging"  PageSize="10"  OnRowCancelingEdit="goods_RowCancelingEdit" OnRowEditing="goods_RowEditing" OnRowUpdating="goods_RowUpdating" OnRowDeleting=" goods_RowDeleting">
           <HeaderStyle CssClass="GridViewHeaderStyle" ></HeaderStyle>        
           <Columns>
                            <asp:BoundField DataField="GoodsID" HeaderText="ID" ReadOnly="True" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GoodsName" HeaderText="商品名称">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>           
                            <asp:BoundField DataField="Class" HeaderText="类别">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Price" HeaderText="价格">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                           <asp:BoundField DataField="GoodsImage" HeaderText="封面图片">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>                           
                           <asp:TemplateField HeaderText="介绍">
                               <EditItemTemplate><asp:TextBox ID="intro" runat="server" AutoCompleteType="Disabled" Text='<%# Eval("Introduction").ToString() %>' Width="150px" Height="150px" TextMode="MultiLine"></asp:TextBox>&nbsp;    
                               </EditItemTemplate>
                               <ItemStyle HorizontalAlign="Center" />
                          <ItemTemplate >                       
                        <asp:Label ID="Label6" runat="server" Text='<%#Eval("Introduction").ToString().Length>15?Eval("Introduction").ToString().Substring(0,15)+"...":Eval("Introduction").ToString()%>' ToolTip='<%# Eval("Introduction").ToString() %>'></asp:Label>                 
                         </ItemTemplate>
                           </asp:TemplateField>
                            <asp:CommandField HeaderText="" ShowEditButton="True" >
                                <ControlStyle Font-Underline="False" ForeColor="Black" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                            <asp:CommandField HeaderText="" ShowDeleteButton="True" >
                                <ControlStyle Font-Underline="False" ForeColor="Black" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
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
     <script src="../js/jquery-3.2.1.min.js"></script>
        <script src="../layer/layer.js"></script>
</asp:Content>
