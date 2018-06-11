<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="MyWeb.Modules.Product.ViewProduct" %>

<%@ Register Src="~/Controls/U_ProductList.ascx" TagPrefix="uc1" TagName="U_ProductList" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<!-- Breadcrumb -->
	<div class="container">
		<div class="breadcrumb clearfix">
			<ul>
				<li class="home">
					<a class="home" href="/" title="Return to Home">
						<i class="fa fa-home"></i>
					</a>
				</li>
				<asp:Literal ID="ltrCrumb" runat="server"></asp:Literal>
				<li class="crumb-3 last"><%=groupName %>
				</li>
			</ul>
		</div>
	</div>
	<!-- /Breadcrumb -->
	<main>
		<section class="well center767">
			<uc1:U_ProductList ID="idU_ProductList" runat="server" />
		</section>
	</main>
</asp:Content>
