<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>首 页</title>
    <meta name="author" content="jixue" />
    <link rel="shortcut icon" href="/Img/ji.ico"/>
	<link rel="stylesheet" href="/css/slideshow.css"/>
	<%--<link rel="stylesheet" type="text/css" href="css/default.css">--%>
    <link rel="stylesheet" type="text/css" href="css/search-form.css">
	<link rel="stylesheet" href="/css/goodsBox.css"/>
	<link rel="stylesheet" href="/css/three.css"/>
	<link rel="stylesheet" href="/css/flip.css"/>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<style>body {background-color: #F4F4F4; }</style>
    <!--轮播图开始-->
<div class="main" id="main">
	<div class="menu-box">
	</div>
	<!--内容-->
	<div class="sub-menu hide" id="sub-menu">
		<div class="inner-box">
			<div class="sub-inner-box">
				<div class="title"><a href="GoodsList.aspx?来源=官方教材&学科=全部" style="color:#376088;">全部官方教材</a></div>
				<div class="sub-row">
					<span class="bold mr10">◎</span>
					<a href="GoodsList.aspx?来源=官方教材&学科=公共课">公共课</a>
					
				</div>
				<div class="sub-row">
					<span class="bold mr10">◎</span>
					<a href="GoodsList.aspx?来源=官方教材&学科=计算机%2F网络">计算机/网络</a>
				</div>
				<div class="sub-row">
					<span class="bold mr10">◎</span>
					<a href="GoodsList.aspx?来源=官方教材&学科=经济%2F管理">经济/管理</a>
				</div>
				
			</div>
		</div>
		<div class="inner-box">
			<div class="sub-inner-box">
				<div class="title"><a href="GoodsList.aspx?来源=个人商品&学科=全部" style="color:#376088;">全部个人商品</a></div>
				<div class="sub-row">
					<span class="bold mr10">◎</span>
					<a href="GoodsList.aspx?来源=个人商品&学科=公共课">公共课</a>
					
				</div>
				<div class="sub-row">
					<span class="bold mr10">◎</span>
					<a href="GoodsList.aspx?来源=个人商品&学科=计算机%2F网络">计算机/网络</a>
				</div>
				<div class="sub-row">
					<span class="bold mr10">◎</span>
					<a href="GoodsList.aspx?来源=个人商品&学科=经济%2F管理">经济/管理</a>
				</div>
				
			</div>
		</div>
		
	</div>
	<!-- 菜单 -->
	<div class="menu-content" id="menu-content">
		<div class="menu-item">
			<a href="GoodsList.aspx?来源=官方教材&学科=全部">
				<span>官方教材</span>
			</a>
		</div>
		<div class="menu-item">
			<a href="GoodsList.aspx?来源=个人商品&学科=全部">
				<span>个人商品</span>
			</a>
		</div>
	</div>
	<div class="banner" id="banner">
		<a href="">
			<div class="banner-slide slide1 slide-active"></div>
		</a>
		<a href="EditUserInfo.aspx">
			<div class="banner-slide slide2"></div>
		</a>
		<a href="个人商品.aspx?id=77" target="_blank">
			<div class="banner-slide slide3"></div>
		</a>
	</div>
	<a href="javascript:void(0)" class="button prev" id="prev"></a>
	<a href="javascript:void(0)" class="button next" id="next"></a>
	<div class="dots" id="dots">
		<span class="active"></span>
		<span></span>
		<span></span>
	</div>
</div>
<script src="/js/slideshow.js"></script>



<!--热卖商品-->
<div>
	<div class="goodsTitle">
		<a class="titleType" href ="GoodsList.aspx?来源=官方教材&学科=全部">官 方 教 材</a>
	</div>

<ul class="card-list">
    

    <li class="card">
        <a class="card-image">
            <img src="Img/sample.jpg" alt="Psychopomp" />
        </a>
        <a class="card-description" href="官方教材.aspx?id=21" target="_blank">
            <h2>财务管理学（第8版）</h2>
            <p>¥43.00</p>
        </a>
    </li>
    
    <li class="card">
        <a class="card-image">
            <img src="Img/高等数学（第七版 上册）.jpg" alt="let's go" />
        </a>
        <a class="card-description" href="官方教材.aspx?id=89" target="_blank">
            <h2>高等数学（第七版 上册）</h2>
            <p>¥39.30</p>
        </a>
    </li>
    
    <li class="card">
        <a class="card-image">
            <img src="Img/ASP.NET程序设计及应用.jpg" alt="The Beautiful Game" />
        </a>
        <a class="card-description" href="官方教材.aspx?id=1" target="_blank">
            <h2>ASP.NET程序设计及应用</h2>
            <p>¥59.00</p>
        </a>
    </li>
    
    <li class="card">
        <a class="card-image">
            <img src="Img/线性代数（第6版）.jpg" alt="Jane Doe" />
        </a>
        <a class="card-description" href="官方教材.aspx?id=315" target="_blank">
            <h2>线性代数（第6版）</h2>
            <p>¥22.20</p>
        </a>
    </li>
    
</ul>
</div>
<div>
	<div class="goodsTitle">
		<a class="titleType" href="GoodsList.aspx?来源=个人商品&学科=全部">个 人 商 品</a>
	</div>

<ul class="card-list">
    
    <li class="card">
        <a class="card-image">
            <img src="Img/75.jpg" alt="Psychopomp" />
        </a>
        <a class="card-description" href="个人商品.aspx?id=75" target="_blank">
            <h2>激荡十年，水大鱼大</h2>
            <p>¥35.00</p>
        </a>
    </li>
    
    <li class="card">
        <a class="card-image">
            <img src="Img/15.jpg" alt="let's go" />
        </a>
        <a class="card-description" href="个人商品.aspx?id=15" target="_blank">
            <h2>卡西欧FX-991CN科学计算器</h2>
            <p>¥99.00</p>
        </a>
    </li>
    
    <li class="card">
        <a class="card-image">
            <img src="Img/77.jpg" alt="The Beautiful Game" />
        </a>
        <a class="card-description" href="个人商品.aspx?id=77" target="_blank">
            <h2>宽容</h2>
            <p>¥30.00</p>
        </a>
    </li>
    
    <li class="card">
        <a class="card-image">
            <img src="Img/14.jpg" alt="Jane Doe" />
        </a>
        <a class="card-description" href="个人商品.aspx?id=14" target="_blank">
            <h2>【二手】得力4K椴木画板</h2>
            <p>¥22.00</p>
        </a>
    </li>
    
</ul>
</div>

</asp:Content>

