<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="MyWeb.Modules.Product.ViewProduct" %>

<%@ Register Src="~/Controls/U_ProductList.ascx" TagPrefix="uc1" TagName="U_ProductList" %>
<%@ Register Src="~/Controls/U_GroupProductList.ascx" TagPrefix="uc2" TagName="U_GroupProductList" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<!-- Breadcrumb -->
	<div class="container">
		<div class="breadcrumb clearfix">
			<ul>
				<li class="home">
					<a class="home" href="/" title="Trang chủ">
						<i class="fa fa-home"></i>
					</a>
				</li>
				<asp:Literal ID="ltrCrumb" runat="server"></asp:Literal>
				<li class="crumb-3 last"><asp:Label ID="lblGroupName" runat="server"></asp:Label>
				</li>
			</ul>
		</div>
	</div>
	<!-- /Breadcrumb -->
	<main>
		<section class="well center767">
			<uc1:U_ProductList ID="idU_ProductList" runat="server" />
			<uc2:U_GroupProductList ID="U_GroupProductList" runat="server" />
		</section>
	</main>
</asp:Content>
