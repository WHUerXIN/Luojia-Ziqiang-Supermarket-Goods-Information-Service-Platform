<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>用户登录 | 注册</title>
    <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Open+Sans:600'/>
    <link rel="stylesheet" href="css/login.css"/>
	<link rel="stylesheet" href="css/verify.css">
	<style>
	 body{
		 background-color:#ffffcc;
	 }
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- partial:index.partial.html -->
<div style="height:750px;">
<div class="login-wrap">
	<div class="login-html">
		<input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">登录</label>
		<input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab">注册</label>
		<div class="login-form">
           
			<div class="sign-in-htm">
               
				<div class="group">
					<label for="user" class="label">用户名</label>
                    <asp:TextBox  ID="txtUserName" class="input" runat="server" ></asp:TextBox>
				</div>
				<div class="group">
					<label for="pass" class="label">密码</label>
                    <asp:TextBox ID="txtPwd" type="password" class="input" data-type="password" runat="server" ></asp:TextBox>
				</div>
               
                <asp:TextBox ID="txtValid" runat="server" style="display:none" ></asp:TextBox>
     			<div class="group">

                    <asp:Button ID="BtnLogin" class="button" runat="server" type="button" Text="登录" OnClick="BtnLogin_Click" />
				</div>
				<div class="hr"></div>
			</div>
            
       
			<div class="sign-up-htm">
				<div class="group">
					<label for="user" class="label">用户名</label>
                    <asp:TextBox ID="txtUser" class="input"  runat="server"></asp:TextBox>
				</div>
				<div class="group">
					<label for="pass" class="label">密码</label>
                    <asp:TextBox ID="txtPass" type="password"  class="input" data-type="password" runat="server"></asp:TextBox>
				</div>
				<div class="group">
					<label for="pass" class="label">确认密码</label>
					<asp:TextBox ID="txtPassCon" type="password"   class="input" data-type="password" runat="server"></asp:TextBox>
				</div>
				<div class="group">
					<label for="pass" class="label">手机号码</label>
					<asp:TextBox ID="txtPhone" class="input"  runat="server"></asp:TextBox>
				</div>
				<div class="group">
                    <asp:Button ID="BtnRegister" class="button" type="button" runat="server" Text="立即注册！"  OnClick="BtnRegister_Click" />
				</div>
				<div class="hr">
                </div>
				<div class="foot-lnk">
					<a><label for="tab-1">已经注册过账号？</label></a>
				</div>
			</div>
               
		</div>
	</div>
</div>

</div>
<!-- partial -->
<script src="js/verify.js"></script>
<script src="js/jquery-3.2.1.min.js"></script>
<script src="layer/layer.js"></script>
<script>
	function sub(){
		var name=document.getElementById('username').value;
		var pass=document.getElementById('password').value;
		var cname="admin";
		var cpass="123";
		if(name==cname && pass==cpass && flag==true){
		alert("登录成功!")
			//window.location.href="#";
		}
		else {
			alert("用户名或密码错误!")
		}
	}
		document.getElementById('ContentPlaceHolder1_txtValid').value = 'True';
	})
</script>
</asp:Content>

