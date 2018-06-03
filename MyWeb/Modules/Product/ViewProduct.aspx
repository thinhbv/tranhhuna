<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="MyWeb.Modules.Product.ViewProduct" %>

<%@ Register Src="~/Controls/U_ProductList.ascx" TagPrefix="uc1" TagName="U_ProductList" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<main>
		<section class="well center767">
			<uc1:U_ProductList ID="idU_ProductList" runat="server" />
		</section>
	</main>
</asp:Content>
