<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_Banner.ascx.cs" Inherits="MyWeb.Controls.U_Banner" %>

<div id="camera" class="camera_wrap">
	<asp:Repeater ID="rptBanner" runat="server">
		<ItemTemplate>
			<div data-src="<%# Eval("Link") %>">
				<div class="camera_caption fadeIn">
					<h2><%# Eval("Name") %></h2>
				</div>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>
<!--camera-->
