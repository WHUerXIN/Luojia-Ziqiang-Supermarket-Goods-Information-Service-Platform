<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="GoodsList.aspx.cs" Inherits="GoodsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>商品列表</title>
	<link rel="shortcut icon" href="/picture/ji.ico"/>
	<link type="text/css" href="css/filter.css" rel="stylesheet" />
    <link type="text/css" href="css/GoodsCard.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="css/searchBar.css">
    <link rel="stylesheet" href="css/buttonx.css">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--筛选表-->
	<div id="box">
	<dl>
		<dt>学科</dt>
        <dd>全部</dd>
		<dd>公共课</dd>
		<dd>计算机/网络</dd>
		<dd>经济/管理</dd>
	</dl>
	<dl>
		<dt>来源</dt>
		<dd>官方教材</dd>
		<dd>个人商品</dd>
	</dl>
	<dl class="select" style="border-bottom-width: 0px;">
		<dt>已选条件：</dt>
	</dl>
          
        </div>
       
        <asp:TextBox ID="学科" runat="server" style="display:none"></asp:TextBox> 
        <asp:TextBox ID="来源" runat="server" style="display:none"></asp:TextBox> 
<script src="js/filter.js"></script>

<asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Always" runat="server">
    	<ContentTemplate>
   <div class="grid" runat="server" style="margin-left:290px; margin-top:-20px; margin-bottom:20px; width:1000px;">
      <div style="float:left;">
        <div class="frame" style="margin:0;">
            <button ID="Button1" runat="server"  class="custom-btn btn-16" OnserverClick="Button1_Click" style="margin:0; background-image:url('/Img/wood.jpg'); background-size:200%; font-family:仿宋; font-size:18px; font-weight:700; color:white">检 索</button>
        </div>
    </div>
    <div class="wrap" style="float:left;">
     <div class="search">
      <input name="txtKey" type="text" class="searchTerm" placeholder="搜索 “<% =Session["来源"]%>” 中的全部商品...">
        <button type="button" class="searchButton" style="margin:0;"  runat="server" onserverclick ="search_Click">
        <i class="fa fa-search"></i>
      </button>
     </div>
    </div>
    <div style ="clear:both;"></div>
</div>


<!--商品列表-->
<div>
	<div class="col-xs-12 col-sm-12 col-md-12 custom-body-main-content-list" style="margin-left:105px;">
	<h><a style="margin-left: 30px;"><asp:Label ID="labTitle" runat="server" Text=""></asp:Label></a></h>

    <asp:DataList ID="dLGoodsList" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"  CellPadding="0" CellSpacing="30" ForeColor="#333333" >
        <ItemTemplate>
            <div class="card">
            <style> a{ text-decoration:none ;} </style>
			<a href="<%# Session["来源"] %>.aspx?id=<%# Eval("BookID") %>" target="_blank">
                <div style="text-align:center; margin:10px; width:250px; height:250px; vertical-align:middle; line-height:250px;">
                <asp:Image ID="Image1" runat="server" ImageUrl='<%#DataBinder.Eval(Container.DataItem,"CoverImage") %>' style="height:200px; width:auto; vertical-align :middle;" />
                </div>
                <div style="text-align:center; color: black; font-family:微软雅黑;">
                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("BookName") %>'  />
                </div>
                <div style="text-align:center;font-size:16px;color:#c00;font-weight:bold;">
                ¥<asp:Label ID="priceLabel" runat="server" Text='<%# Eval("Price") %>'  />元
                </div>
                </div>
                <br/>
             </a>
        </ItemTemplate>
    </asp:DataList>
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
</div>
</ContentTemplate>
</asp:UpdatePanel>
<script src="js/jquery-3.2.1.min.js"></script>
<script src="layer/layer.js"></script>

</asp:Content>

