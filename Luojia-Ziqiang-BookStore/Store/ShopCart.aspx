<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="ShopCart.aspx.cs" Inherits="ShopCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>购物车</title>
    <link rel="stylesheet" href="/css/ShopCart.css"/>
    <link rel="stylesheet" href="/css/goodsBox.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <div class="col-xs-12 col-sm-12 col-md-12 custom-body-main-content-list">
                   
   <div class="wrap cf" style="padding-top:20px">
  <div class="goodsTitle" style="margin-left:-50px;width:1050px">
		<p class="titleType" style="font-size:23px" >购 物 车</p>
	</div>
  <h1 class="projTitle"></h1>

  <div class="heading cf">
    <h1>购物详情</h1>

      <a href="GoodsList.aspx" class="continue" style="margin-left:10px">继续购物</a>
    <asp:LinkButton ID="LinkButton2" runat="server" class="continue" OnClick="lnkbtnUpdate_Click">更新购物车</asp:LinkButton>
    
  </div>
  <div class="cart">
    <ul class="cartWrap">
      
      <asp:Label ID="labMessage" runat="server" Visible="False" style="color:orangered;font-size:23px;font-family:'Droid Serif', serif"></asp:Label>
         <asp:DataList ID="ShoppingCart" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" OnItemCommand="ShoppingCart_ItemCommand">
            <ItemTemplate>
                   
      <li class="items even">

       <div class="infoWrap">
    
        <div class="cartSection info">
            <asp:Image ID="Image1" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"CoverImage") %>' class="itemImg" alt="" />
          <p class="itemNumber"><%# Eval("BookID") %></p>
          <h3 style="margin:10px">￥<%# Eval("BookName") %></h3>
        
          <p> <asp:TextBox ID="txtNum" class="qty" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Num") %>' onkeypress="if (event.keyCode < 48 || event.keyCode >57) event.returnValue = false;"></asp:TextBox> x ￥<%# Eval("Price") %></p>
        
          <p class="stockStatus"> In Stock</p>
          
        </div>  
    
        
        <div class="prodTotal cartSection">
          <p><%# Eval("totalPrice") %></p>
        </div>
    
            <div class="cartSection removeWrap" style="width:100px">
                <asp:LinkButton ID="LinkButton3" runat="server" class="continue btn" CommandName="remove" CommandArgument =<%#DataBinder.Eval(Container.DataItem, "BookID")%> style="font-size:10px;background:#ceced6" >移除</asp:LinkButton>
        </div>
         </div>
      </li>
                </ItemTemplate>
        </asp:DataList>
      
      
      <!--<li class="items even">Item 2</li>-->
 
    </ul>
  </div>
    
  <div class="subtotal cf">
    <ul>   
       <li class="totalRow final"><span class="label">共计：</span><span id="labTotalPrice" runat="server" class="value"></span></li>
        <li class="totalRow"><asp:LinkButton ID="LinkButton1" class="btn continue" runat="server" OnClick="lnkbtnCheck_Click" >前往服务台</asp:LinkButton></li>
    </ul>
  </div>
</div>
    
    
            <br />
        </div>
    </div>
    <script  src="js/ShopCart.js"></script>
</asp:Content>

