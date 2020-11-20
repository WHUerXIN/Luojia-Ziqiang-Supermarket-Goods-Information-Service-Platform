<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="官方教材.aspx.cs" Inherits="官方教材" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title id="Title"><%=txtName.Text%></title>
    <link  href="css/item.css" rel="stylesheet" type="text/css" />
    <link  href="css/tab.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="css/comment.css" rel="stylesheet" />
    <script src="js/layer.js"></script>
    <script src="jquery-2.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <style>body {margin:0;}
       .auto-style1 {
           width: 100%;
       }
       .auto-style6 {
           height: 37px;
       }
       .auto-style7 {
           height: 111px;
       }
       .auto-style8 {
           width: 112px;
       }
   </style>
<!--商品内容开始-->
<div class="goods" >
	<div class="goods_pic" >
    	<div class="probox" >
            <asp:Image ID="Image1" runat="server" style="height:375px; width:auto; vertical-align :middle;" />
            <div class="hoverbox"></div>
        </div>
        <div class="showbox">
            
        </div>
        <ul >
        	
        </ul>
    </div>
    <div class="goods_info">
    	<h1><asp:Label id="txtName" runat="server"></asp:Label></h1>
        <p class="mod-info ">作者：<asp:Label id="txtAuthor" runat="server"></asp:Label></p>
        <div class="goods_price">
        	<span class="price">价　格：<small>￥</small> <span id="g_price2" class="vm-money" ><asp:Label id="txtPrice" runat="server"></asp:Label></span></span>
        </div>
        <div class="goods_select">
       		<p>学　科：<asp:Label id="txtClass" runat="server"></asp:Label>　　　　　　商品编号：O<asp:Label id="txtBookID" runat="server"></asp:Label></p>
           
        </div>
        <div class="goods_select" >
       		<p>出版社：<asp:Label id="txtPublisher" runat="server"></asp:Label>
        </div>
        <div class="goods_select" >
       		<p>ISBN ： <asp:Label id="txtISBN" runat="server"></asp:Label>
        </div>
        <div class="goods_select">
       	<p>版　次：<asp:Label id="txtEdition" runat="server"></asp:Label>　　　　　　　　　　　出版时间：<asp:Label id="txtPublishDate" runat="server"></asp:Label></p>
        </div>   
        <form name="formshow" id="formshow" action="order.asp" method="post" onSubmit="return Juge()">
					
        <div class="goods_select">
       		<p>页　数：<asp:Label id="txtPages" runat="server"></asp:Label></p>
       
        </div>
			
        <div class="xian"></div>

        <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
    	<ContentTemplate>
        <div class="goods_number">
       		<p>购买数量：</p>
            <div class="goods_select_item" style="margin-left:100px; margin-top: -65px;">
        		<div class="number" style="width:500px">
                    <asp:Button ID="minus" runat="server" Text="-" Font-Size="XX-Large" OnClick="minus_Click" />&nbsp;
                    <asp:TextBox ID="GoodsNum" runat="server" Text="1" Enabled="False"></asp:TextBox>&nbsp;
                    <asp:Button ID="plus" runat="server" Text="+" Font-Size="Larger" OnClick="plus_Click" />
                </div>
            </div>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>

        <div class="goods_button" style=" margin-top: 30px;">
            <asp:ImageButton ID="add" src="Img/0gwc.png" runat="server" OnClick="add_Click" />&nbsp;&nbsp;
            <asp:ImageButton ID="buy" src="Img/0lkgm.png" runat="server" OnClick="buy_Click" />
         </div>
        </form>
    </div>
</div>
  
<div class="worko-tabs">
  
    <input class="state" type="radio" title="tab-one" name="tabs-state" id="tab-one" checked />
    <input class="state" type="radio" title="tab-two" name="tabs-state" id="tab-two" />
    <input class="state" type="radio" title="tab-three" name="tabs-state" id="tab-three" />
    <input class="state" type="radio" title="tab-four" name="tabs-state" id="tab-four" />

    <div class="tabs flex-tabs">
        <label for="tab-one" id="tab-one-label" class="tab">商品介绍</label>
        <label for="tab-two" id="tab-two-label" class="tab" >商品评论(<asp:Label ID="txtCount" runat="server" Text="Label"></asp:Label>)</label>
        <label for="tab-three" id="tab-three-label" class="tab">发布评论</label>


        <div id="tab-one-panel" class="panel active">

<!--介绍--> <div style="margin: 50px 0 200px 20px;">
                 <asp:Label ID="Introduction" runat="server" Text="暂无详情介绍"></asp:Label>
            </div>
        </div>
<!--评论-->
        <div id="tab-two-panel" class="panel">
            <div class="comments-app" >


            <div class="comments">
          
            <asp:DataList ID="dLComment" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"  CellPadding="1" CellSpace="1" ForeColor="#333333" >
                <ItemTemplate>
                <div class="comments-app" >

    <!-- Comment - Dummy -->
    <div class="comment">
      <!-- Comment Avatar -->
      <div class="comment-avatar">
        <img src="<%# Eval("HeadImage")%>">

      </div>
      <!-- Comment Box -->
      <div class="comment-box">
        <div class="comment-text"><%# Eval("Content") %></div>
        <div class="comment-footer">
          <div class="comment-info">
            <span class="comment-author">
              <a href="#"><%# Eval("UserName") %></a>
            </span>
            <span class="comment-date"><%# Eval("Time") %></span>
          </div>
        </div>
      </div>
    </div>
  </div>  
                </ItemTemplate> </asp:DataList>
          
              </div>
           </div> 
        </div>
        <div id="tab-three-panel" class="panel">
<!--发布--><div class="comments-app" >
              <!-- From -->
  <div id="submitComment" class="comment-form" runat ="server">
    <!-- Comment Avatar -->
    <div class="comment-avatar">
        <asp:Image ID="HeadImage" runat="server" />
    </div>

    <div class="form" name="form" runat="server">
      <div class="form-row">
        <textarea id="UserComment"
                  class="input"
                  placeholder="你的评论..."
                   runat="server"></textarea>
      </div>
      <div class="form-row">
          <asp:Button ID="AddComment" runat="server" Text="添加评论" OnClick="AddComment_Click" />
      </div>
    </div>
  </div></div>
        </div>
   

    </div>
    </div>
<script src="js/jquery-3.2.1.min.js"></script>
<script src="layer/layer.js"></script>
</asp:Content>

