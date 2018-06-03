<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_Top.ascx.cs" Inherits="MyWeb.Controls.U_Top" %>
<div class="container">

	<div class="navbar-header">
		<div class="navbar-brand-wrap">
			<img src="/images/logo.png" alt="" class="navbar-brand-img">
			<asp:Literal ID="ltrLogo" runat="server"></asp:Literal>
			<div class="brand_cnt">
				<p class="navbar-slogan">
					Phương châm sống
				</p>

				<h1 class="navbar-brand">
					<a href="./">TranhHuna</a>
				</h1>
			</div>
		</div>
	</div>
	<div class="info-box">
		<div class="fa-phone">
			<p>Phone:</p>

			<a href="callto:#">
				<asp:Label ID="lblPhone" runat="server"></asp:Label>
			</a>
		</div>
		<div class="fa-map-marker">
			<p>Địa chỉ:</p>
			<address>
				Tầng 7 Tòa nhà A
				<br />
				Khu chung cư Mễ Trì
			</address>
		</div>
		<div class="cart-info">
			<a href="/gio-hang" title="Giỏ hàng của bạn">
				<i class="fa-shopping-cart" style="font-size: 42px;"></i>
				<b id="item-count"><%=totalCount %></b>
			</a>
		</div>
	</div>
</div>
