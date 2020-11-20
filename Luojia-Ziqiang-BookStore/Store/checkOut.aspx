<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="checkOut.aspx.cs" Inherits="checkOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>订单详情</title>
    <link rel="stylesheet" href="/css/OrderList.css"/>
    <link rel="stylesheet" href="/css/goodsBox.css"/>
    <link type="text/css" rel="stylesheet" href="css/button.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <div class="goodsTitle" style="margin:60px auto;margin-bottom:40px;width:1000px">
		<p class="titleType" >订单详情</p>
	</div>
<form class="form-card">
    <fieldset class="form-fieldset">
        <%--<legend class="form-legend">订单详情</legend>--%>
        <asp:Label ID="labMessage" runat="server" Text="订单详细情况如下："></asp:Label>
        <hr />
        <asp:GridView ID="gvShopCart"  runat="server"  AutoGenerateColumns="False" Width="99%" >
                <Columns>
                    <asp:BoundField DataField="No" HeaderText="序号" ReadOnly="True">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>  
                    <asp:BoundField DataField="BookID" HeaderText="商品ID" ReadOnly="True">
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>                                    
                    <asp:BoundField DataField="BookName" HeaderText="商品名称" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>  
                    <asp:BoundField DataField="Num" HeaderText="数量" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>  
                    <asp:BoundField DataField="price" HeaderText="单价(￥)" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>  
                    <asp:BoundField DataField="totalPrice" HeaderText="总价(￥)" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>  
                </Columns>
                <HeaderStyle HorizontalAlign="Center" Height="30"/>
                <RowStyle HorizontalAlign="Center"  Height="30"/>
            </asp:GridView>
        <div class="form-element form-input">
            <asp:TextBox ID="txtReciverName" runat="server" class="form-element-field" placeholder="请输入有效姓名" required></asp:TextBox>            
            <div class="form-element-bar"></div>
            <label class="form-element-label" for="field-omv6eo-metm0n-5j55wv-w3wbws-6nm2b9">收件人姓名</label>
        </div>
        <div class="form-element form-input">
            <asp:TextBox ID="txtReceiverPhone" runat="server" class="form-element-field" placeholder=" " required></asp:TextBox>
            <div class="form-element-bar"></div>
            <label class="form-element-label" for="field-uyzeji-352rnc-4rv3g1-bvlh88-9dewuz">联系电话</label>
            <small class="form-element-hint">请填写正确的电话号码</small>
        </div>
         <div class="form-element form-input">
            <asp:TextBox ID="txtReceiverAddress" runat="server" class="form-element-field" placeholder=" " required></asp:TextBox>            
            <div class="form-element-bar"></div>
            <label class="form-element-label" for="field-uyzeji-352rnc-4rv3g1-bvlh88-9dewuz">详细地址</label>
            <small class="form-element-hint">请填写准确的送货地址</small>
        </div>
        <div class="form-radio form-radio-block">
            <div class="form-radio-legend">请选择您的邮寄方式</div>
            <label >
                <asp:RadioButton style="width:20px;height:15px" GroupName="send" ID="RadioButton1" runat="server" value="10" Checked="true" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"/>
                <span>顺丰快递（10元）</span>
            </label>
            <label >
                <asp:RadioButton GroupName="send" style="width:20px;height:15px" ID="RadioButton2"  runat="server" value="5" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"/>
                <span>其他快递（5元）</span>
            </label>
            <label >
                <asp:RadioButton  style="width:20px;height:15px" GroupName="send" ID="RadioButton3" runat="server" value="0" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"/>
                <span>免费送货（仅武汉大学）</span>
            </label>
        </div>
        <div class="form-element form-textarea">
            <textarea id="txtRemark" class="form-element-field" placeholder=" " runat="server"></textarea>
            <div class="form-element-bar"></div>
            <label class="form-element-label" for="field-3naeph-0f3yuw-x153ph-dzmahy-qhkmgm">备注：</label>
        </div>
        <div style="text-align:right">
            <asp:Label ID="Label1" runat="server" Text="共计：￥" style="font-size:25px"></asp:Label>
            <asp:Label ID="labTotalPrice" runat="server" Text="" style="font-size:25px"></asp:Label>
        </div>
        <asp:Label ID="ltp" runat="server" Text="Label" style="display:none"></asp:Label>
        <asp:Label ID="ShipType" runat="server" Text="Label" style="display:none">顺丰快递（10元）</asp:Label>
        <asp:Label ID="Shipfee" runat="server" Text="Label" style="display:none">10.00</asp:Label>
    </fieldset>
    
</form>
<div class="grid" runat="server" style="margin:30px auto">
    <asp:Button ID="Button1" class="button" style="margin:auto" runat="server" Text="去付款" OnClick="btnConfirm_Click" />
</div>   
    </div>
</asp:Content>

