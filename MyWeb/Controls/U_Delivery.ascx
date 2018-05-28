<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_Delivery.ascx.cs" Inherits="MyWeb.Controls.U_Delivery" %>
<ol class="row index-list">
	<asp:Repeater ID="rptDelivery" runat="server">
		<ItemTemplate>
			<li class="col-md-4 col-sm-4 col-xs-12">
				<h4><%#Eval("Name").ToString() %></h4>
				<p>
					<%#Eval("Detail").ToString() %>
				</p>
			</li>
		</ItemTemplate>
	</asp:Repeater>
</ol>
