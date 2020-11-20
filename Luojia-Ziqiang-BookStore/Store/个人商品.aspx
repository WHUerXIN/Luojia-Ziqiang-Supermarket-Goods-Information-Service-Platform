<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="个人商品.aspx.cs" Inherits="个人商品" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title><%=txtName.Text%></title>
    <link  href="css/item.css" rel="stylesheet" type="text/css" />
    <link  href="css/tab.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="css/comment.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/business.css"/>
    <link rel="stylesheet" href="css/buttonx.css"/>
    <script src="js/layer.js"></script>
    <script src="jquery-2.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>body {margin:0;}.layui-layer-page.myskin {background-color: transparent; /*背景透明*/}</style>
<!--商品内容开始-->
<div class="goods" >
	<div class="goods_pic" >
    	<div class="probox" >
        	<asp:Image ID="Image1" runat="server" style="height:375px; width:auto; vertical-align :middle;" />
            <div class="hoverbox"></div>
        </div>
        <div class="showbox">
            <img src="bigpicpath" alt="">
        </div>
        <ul >
        	
        </ul>
    </div>
    <div class="goods_info" style="margin-top: 30px;">
    	<h1><asp:Label id="txtName" runat="server"></asp:Label></h1>
        <p class="mod-info "></p>
        <div class="goods_price" style="height: 50px;">
        	<span class="price">价　格：<small>￥</small> <span id="g_price2" class="vm-money" ><asp:Label id="txtPrice" runat="server"></asp:Label></span></span>
		
        </div>
        <div class="goods_select">
       		<p>类　别：<asp:Label id="txtClass" runat="server"></asp:Label>　　　　　　商品编号：P<asp:Label id="txtGoodsID" runat="server"></asp:Label>
        </div>
        <div class="goods_select" >
       		<p>卖家用户ID：<asp:Label id="txtUserID" runat="server"></asp:Label>
            <div style="display: none">
            <asp:Label ID="txtUserName" runat="server"></asp:Label>
            <asp:Label ID="txtPhone" runat="server"></asp:Label>
            <asp:Label ID="txtHeadImage" runat="server"></asp:Label>
            <asp:Label ID="txtEmail" runat="server"></asp:Label></div>
        </div>
        
		
		<INPUT type="hidden" name="gid" value="=gid"><INPUT type="hidden" name="gidget" value="">
		<INPUT type="hidden" name="lkgm"  id="lkgm" value="">
        		
		
        <div class="xian"></div>
        
        <div class="frame" style="text-align:left">
            <button ID="buy" runat="server"  class="custom-btn btn-16" OnserverClick="buy_Click" >联系卖家</button>
         </div>
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

<!--介绍--><div style="margin: 50px 0 200px 20px;">
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
    <script>
            function MyFun(){
            layer.open({
                type: 1, shade: false, title: false, skin: 'myskin', content: '<div id="wrapper"> <div id="content"> <div id="card"> <div id="front"> <div id="arrow"><i class="fa fa-arrow-left"></i></div> <div id="top-pic"></div> <div id="avatar" style="background-image:url(<% =txtHeadImage.Text%>)"></div>       <div id="info-box"> <div class="info">  <h1><% =txtUserName.Text %></h1> <h2>Phone: <% =txtPhone.Text%></h2> <h2>E-mail: <% =txtEmail.Text%></h2>  </div> </div> </div> </div> </div> </div>'
            })
            }
        </script>
<script src="js/jquery-3.2.1.min.js"></script>
<script src="layer/layer.js"></script>
</asp:Content>

