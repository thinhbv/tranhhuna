<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="FreeDownload.aspx.cs" Inherits="MyWeb.Modules.Product.FreeDownload" %>
<%@ Import Namespace="MyWeb.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<!-- Breadcrumb -->
	<div class="container">
		<div class="breadcrumb clearfix">
			<ul>
				<li class="home">
					<a class="home" href="/" title="Trang chủ">
						<i class="fa fa-home"></i>
					</a>
				</li>
				<li class="crumb-3 last">Tải miễn phí
				</li>
			</ul>
		</div>
	</div>
	<!-- /Breadcrumb -->
	<main>
		<section class="well center767">
			<div class="container">
				<div id="list-product" class="row">
					<asp:Repeater ID="rptProducts" runat="server" OnItemDataBound="rptProducts_ItemDataBound">
						<ItemTemplate>
							<div class="col-md-2 col-sm-4 col-xs-6 wow fadeInUp">
								<div class="item-row">
								<img src="<%# StringClass.ThumbImage(Eval("ThumbnailLink").ToString()) %>" alt="<%# Eval("Name") %>" title="<%# Eval("Name") %>">
								</div>
									<h6 class="badge col-md-12 col-sm-12 col-xs-12">
									<asp:LinkButton id="ltbDownload" runat="server" CssClass="add-cart" ToolTip="Tải miễn phí"><i class="fa fa-download" aria-hidden="true"></i></asp:LinkButton>
								</h6>
								<h6 class="title-pro" style="clear: left;"><%# StringClass.FormatContentNews(Eval("Name").ToString(), 60) %></h6>
							</div>
						</ItemTemplate>
					</asp:Repeater>
				</div>
			</div>
		</section>
	</main>
</asp:Content>
