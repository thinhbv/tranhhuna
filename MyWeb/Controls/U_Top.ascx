<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_Top.ascx.cs" Inherits="MyWeb.Controls.U_Top" %>
<div class="container">

	<div class="navbar-header">
		<div class="navbar-brand-wrap">
			<a href="/" title="Tranh Huna"><img src="/images/logo.png" alt="" class="navbar-brand-img"></a>
		</div>
	</div>
	<div class="info-box">
		<%--<div class="fa-phone">
			<p>Phone:</p>
			<asp:Label ID="lblPhone" runat="server"></asp:Label>
		</div>
		<div class="fa-map-marker">
			<p>Địa chỉ:</p>
			<address>
				Tầng 7 Tòa nhà A
				<br />
				Khu chung cư Mễ Trì
			</address>
		</div>--%>
		<a href="/gio-hang" title="Giỏ hàng của bạn">
			<div class="fa-shopping-cart">
				<b id="item-count"><%=totalCount %></b>
			</div>
		</a>
	</div>
</div>
