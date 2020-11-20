<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/User1.master" CodeFile="EditUserInfo.aspx.cs" Inherits="EditUserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>修改个人信息</title>   
     <link type="text/css" href="css/manageforum.css" rel="stylesheet" />
	<link type="text/css" rel="stylesheet" href="css/button.css" />
    <link type="text/css" rel="stylesheet" href="css/buttonx.css" />
     
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
        <div  class="userTitle">
            <p class="titleType"  >个人信息</p>
        </div>
      <div class="a1">
               <table width="550" align="center">            
         

            <tr><td>昵称</td><td>
                    <asp:TextBox class="input1" ID="username" runat="server" AutoCompleteType="Disabled" Height="40px" Width="220px" style="border-radius: 40px;"></asp:TextBox>
                    </td></tr>   
        
            <tr><td>密码</td><td>
                    <asp:TextBox class="input1" ID="password" runat="server" AutoCompleteType="Disabled" Height="40px" Width="220px" style="border-radius: 40px;"></asp:TextBox>
                    </td></tr>     
                     
            <tr><td>真实姓名</td><td>
                    <asp:TextBox class="input1" ID="realname" runat="server" AutoCompleteType="Disabled" Height="40px" Width="220px" style="border-radius: 40px;"></asp:TextBox>
                    </td></tr> 
            <tr><td>性别</td><td>
                   <asp:DropDownList  ID="DropDownList2" runat="server" Height="40px" Width="220px" style="border-radius: 40px;padding-left:100px">
                       <asp:ListItem >男</asp:ListItem>
                       <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
            </td></tr>         
       
            <tr><td>手机</td><td>
                    <asp:TextBox class="input1" ID="phone" runat="server" AutoCompleteType="Disabled" Height="40px" Width="220px" style="border-radius: 40px;"></asp:TextBox>
                    </td></tr> 
            <tr><td>邮箱</td><td>
                    <asp:TextBox class="input1" ID="email" runat="server" AutoCompleteType="Disabled" Height="40px" Width="220px" style="border-radius: 40px;"></asp:TextBox>
                    </td></tr> 
            <tr><td>地址</td><td>
                    <asp:TextBox class="input1" ID="address" runat="server" AutoCompleteType="Disabled" Height="40px" Width="220px" style="border-radius: 40px;"></asp:TextBox>
            </td></tr> 
                <tr><td>头像</td><td>
                    <asp:FileUpload    ID="FileUpload1" runat="server" Font-Size="9pt" Height="40px" Width="220px" />
                    
                     <span><tr><td>&nbsp;</td><td>
                    <asp:Button   ID="BtnUpdateIm" runat="server" Text="上传" class="custom-btn btn-16"   OnClick="BtnUpdateIm_Click" /> 
                          <asp:Label ID="Label1" runat="server" Text="" Style="color: Red;font-size:10px;"></asp:Label>
                    </td></tr></span>             
                <tr><td>&nbsp;</td><td>
                    &nbsp;<asp:Image runat="server" ID="Image1" Style="z-index: 102; left: 20px; 
                top: 49px" Width="138px" Height="143px" /></td></tr>
 
                <tr><td>&nbsp;</td><td>                   
                        <asp:button class="custom-btn btn-16" id="btnSave" runat="server" Text="修改" OnClick="btnSave_Click"  Width="80"></asp:button>&nbsp;&nbsp;
			            <asp:button class="custom-btn btn-16" id="btnReset" runat="server" Text="重置"  OnClick="btnReset_Click"  Width="80"></asp:button>
                    </td></tr>
        </table>   
        </div>
    <script src="../js/jquery-3.2.1.min.js"></script>
    <script src="../layer/layer.js"></script>
        </asp:Content>