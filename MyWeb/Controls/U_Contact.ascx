<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_Contact.ascx.cs" Inherits="MyWeb.Controls.U_Contact" %>
<div class="custom">
    <asp:Literal ID="ltrContact" runat="server"></asp:Literal>
</div>
<div class="custom" style="font-size:14px; width:285px">
    <strong>Hỗ trợ 24/7</strong><br />
    <strong>Hotline: </strong> <span><asp:Label ID="lblPhone" runat="server"></asp:Label></span><br />
    <strong style="position:relative; top:-9px">Yahoo: </strong><asp:Literal ID="ltrYahoo" runat="server"></asp:Literal>
    <strong style="position:relative; top:-9px">Skype: </strong><asp:Literal ID="ltrSkype" runat="server"></asp:Literal><br />
    <div style="width:45px; float:left"><strong>Hỗ trợ: </strong></div><asp:Literal ID="ltrMail" runat="server"></asp:Literal>
</div>
<div style="float: left; width: 154px; font-size: 14px;">
    <strong>Thống kê trực tuyến</strong><br />
    <strong>Đang truy cập: </strong><% =Application["visitors_online"].ToString()%><br />
    <strong>Hôm nay: </strong><% =Application["HomNay"].ToString()  %><br />
    <strong>Tháng hiện tại: </strong><% =Application["ThangNay"].ToString()  %><br />
    <strong>Tổng lượt truy cập: </strong><% =Application["TatCa"].ToString()%><br />
</div>
