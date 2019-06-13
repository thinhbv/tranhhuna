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
					<asp:Repeater ID="rptProducts" runat="server" OnItemDataBound="rptProducts_ItemDataBound" OnItemCommand="rptProducts_ItemCommand">
						<ItemTemplate>
							<div class="col-md-2 col-sm-4 col-xs-6 wow fadeInUp">
								<div class="item-row">
								<a href='<%#PageHelper.GeneralDetailUrl(Consts.CON_SAN_PHAM, "tải miễn phí", Eval("ProductId").ToString(), Eval("OriginalFileName").ToString()) %>' title="<%# Eval("OriginalFileName").ToString() %>"><img src="<%# StringClass.ThumbImage(Eval("ThumbnailLink").ToString()) %>" alt="<%# Eval("OriginalFileName") %>" title="<%# Eval("OriginalFileName") %>"></a>
								</div>
									<h6 class="badge col-md-12 col-sm-12 col-xs-12">
									<asp:HyperLink id="hlDownload" runat="server" CssClass="add-cart" ToolTip="Tải miễn phí" CommandName="download" CommandArgument='<%#Eval("Id") %>'><i class="fa fa-download" aria-hidden="true"></i></asp:HyperLink>
								</h6>
								<h6 class="title-pro" style="clear: left;"><a href='<%#PageHelper.GeneralDetailUrl(Consts.CON_SAN_PHAM, "tải miễn phí", Eval("ProductId").ToString(), Eval("OriginalFileName").ToString()) %>' title="<%# Eval("OriginalFileName").ToString() %>"><%# Eval("OriginalFileName").ToString() %></a></h6>
							</div>
						</ItemTemplate>
					</asp:Repeater>
				</div>
			</div>
		</section>
		<asp:Label ID="lblMsg" runat="server"></asp:Label>
	</main>
</asp:Content>
