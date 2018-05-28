<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_ProductList.ascx.cs" Inherits="MyWeb.Controls.U_ProductList" %>
<%@ Import Namespace="MyWeb.Common" %>
<div class="container">

	<div class="row">
		<asp:Repeater ID="rptProducts" runat="server">
			<ItemTemplate>
				<div class="col-md-2 col-sm-4 col-xs-6 wow fadeInUp">
					<img src="<%# Eval("Image1") %>" alt="<%# Eval("Name") %>" title="<%# Eval("Name") %>">
					<h4 class="badge"><%# StringClass.ConvertPrice(Eval("Price").ToString()) %> Đ</h4>
					<h6><a href="<%#Eval("Link").ToString() %>"><%# Eval("Name") %></a></h6>
					<p class="l-height"><%# StringClass.FormatContentNews(Eval("Content").ToString(),100) %></p>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
</div>
