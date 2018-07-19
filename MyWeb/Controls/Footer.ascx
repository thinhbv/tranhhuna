<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="MyWeb.Controls.Footer" %>
<div class="container">
	<ul class="inline-list">
		<li class="fa fa-phone">
			<p>Phone:</p>
			<asp:Label ID="lblPhone" runat="server"></asp:Label>
		</li>
		<li class="fa fa-map-marker">
			<p>Địa chỉ:</p>
			<address>
				Tầng 7 Tòa nhà A
				<br />
				Khu chung cư Mễ Trì
			</address>
		</li>
		<li style="position:relative;top:-30px;"><a href="https://www.facebook.com/tranhhuna/" class="fa fa-facebook" target="_blank"></a></li>
	</ul>

	<hr>

	<h5 class="copyright">
		<asp:Literal ID="ltrCopyRight" runat="server"></asp:Literal>
	</h5>
</div>
