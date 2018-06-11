<%@ Page EnableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="MyWeb.Modules.Product.ProductDetail" %>

<%@ Import Namespace="MyWeb.Common" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
	<script type="text/javascript">
		var jqZoomEnabled = true;
		var productColumns = '1';
		var nbItemsPerLine = 3;
		var nbItemsPerLineMobile = 2;
		var nbItemsPerLineTablet = 2;
		var page_name = 'category';
		$(document).ready(function () {
			$(".add-cart").click(function () {
				var proid = $(this)[0].id;
				var item = $(this);
				$.ajax({
					method: "POST",
					url: "/Processor.aspx",
					data: { mode: "add", id: proid }
				})
				  .done(function (result) {
				  	if (result === "1") {
				  		item.removeAttr("class");
				  		item.attr("class", "added-cart");
				  		item.attr("disabled", "disabled");
				  		item.removeAttr("id");
				  		$("#item-count")[0].innerText = (parseInt($("#item-count")[0].innerText) + 1).toString();
				  	}
				  });
			})
		})
		function AddToCart() {
			var proid = '<%= id%>';
			var quantity = $('#<%=txtQuantity.ClientID%>').val();
			$.ajax({
				method: "POST",
				url: "/Processor.aspx",
				data: { mode: "add", id: proid, quantity: quantity }
			})
				  .done(function (result) {
				  	if (result === "1") {
				  		$("#item-count")[0].innerText = (parseInt($("#item-count")[0].innerText) + 1).toString();
				  	}
				  });
		}
	</script>
	<link href="../../../css/product.css" rel="stylesheet" />
	<script src="../../../scripts/jquery.serialScroll.js"></script>
	<script src="../../../scripts/jquery.scrollTo.js"></script>
	<script type="text/javascript" src="../../../scripts/product.js"></script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div id="columns" class="container">
	<!-- Breadcrumb -->
	<div class="breadcrumb clearfix">
		<ul>
			<li class="home">
				<a class="home" href="/" title="Return to Home">
					<i class="fa fa-home"></i>
				</a>
			</li>
			<li class="last"><%= name %></li>
		</ul>
	</div>
	<!-- /Breadcrumb -->
	<div class="row">
		<div class="large-left col-sm-12">
			<div class="row">
				<div id="center_column" class="center_column col-xs-12 col-sm-12 accordionBox">
					<!--Replaced theme 2 -->
					<div>
						<div class="primary_block row">
							<!-- left infos-->
							<div class="pb-left-column col-sm-6 col-md-6 col-lg-6">
								<!-- product img-->
								<div id="image-block" class="clearfix is_caroucel">
									<span class="sale-box no-print"></span>
									<span id="view_full_size">
										<a class="jqzoom" title="<%= name %>" rel="gal1" href="<%=sImage_01 %>">
											<img itemprop="image" src="<%= sImage_01%>" title="<%= name %>" alt="<%= name %>" width="200" />
										</a>
										<!--jqzoom-->
									</span>
								</div>
								<!-- end image-block -->
							</div>
							<!-- center infos -->
							<div class="pb-right-column col-sm-6 col-md-6 col-lg-4">
								<h1 itemprop="name"><%= name %></h1>
								<div class="product-info-line">
									<p id="product_condition">
										<label style="width: 60px">Ý nghĩa: </label>
										<span class="editable"><%=content %></span>
									</p>
								</div>
								<div class="product-info-line">
									<p id="product_condition">
										<label style="width: 60px">Giá bán: </label>
										<span class="editable"><%=StringClass.ConvertPrice(sPrice) + " Đ" %></span>
									</p>
								</div>
								<div class="product-info-line">
									<p id="product_condition">
										<label style="width: 60px">Số lượng: </label>
										<asp:TextBox ID="txtQuantity" runat="server" Text="1" Width="60"></asp:TextBox>
									</p>
								</div>
								<div class="product-info-line">
									<p id="product_condition">
										<asp:Button ID="btnBuyNow" runat="server" Text="Mua ngay" CssClass="button-form" OnClick="btnBuyNow_Click" />
										<asp:Button ID="btnAddCart" runat="server" Text="Thêm vào giỏ hàng" CssClass="button-form" OnClientClick="AddToCart();return false;" />
									</p>
								</div>
								<div class="extra-right">
									<!-- Go to www.addthis.com/dashboard to customize your tools -->
									<script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-4f87903d1009b87f"></script>
									<div class="block-addthis">
										<!-- Go to www.addthis.com/dashboard to customize your tools -->
										<div class="addthis_inline_share_toolbox_z3zm"></div>
									</div>
								</div>
							</div>
							<!-- end center infos-->
						</div>
						<!-- end primary_block -->
						<div class="clearfix product-information">
							<ul class="product-info-tabs nav nav-stacked col-sm-3 col-md-3 col-lg-3">
								<li class="product-description-tab active"><a data-toggle="tab" href="<%=Request.RawUrl %>#product-description-tab-content">Thông tin chi tiết</a></li>
								<%--<li class="product-features-tab"><a data-toggle="tab" href="<%=Request.RawUrl %>#product-features-tab-content">Comments</a></li>--%>
							</ul>
							<div class="tab-content col-sm-9 col-md-9 col-lg-9">
								<div id="product-description-tab-content" class="product-description-tab-content tab-pane active">
									<div class="rte">
										<asp:Literal ID="ltrDetail" runat="server"></asp:Literal>
									</div>
								</div>
								<!-- quantity discount -->
								<!-- Data sheet -->
								<div id="product-features-tab-content" class="product-features-tab-content tab-pane">
									<span>Comment here</span>
								</div>
								<!--end Data sheet -->
							</div>
						</div>

						<!-- description & features -->
						<!--Accessories -->
						<section class="page-product-box">
<h3 class="page-product-heading">Sản phẩm liên quan</h3>
<div class="container">
<div class="row">
	<asp:Repeater ID="rptProducts" runat="server">
		<ItemTemplate>
			<div class="col-md-2 col-sm-4 col-xs-6 wow fadeInUp">
				<a href="<%#Eval("Link").ToString() %>" title="<%# Eval("Name") %>">
					<img src="<%# StringClass.ThumbImage(Eval("Image1").ToString()) %>" alt="<%# Eval("Name") %>" title="<%# Eval("Name") %>"></a>
				<h6 class="badge"><%# StringClass.ConvertPrice(Eval("Price").ToString()) %> Đ</h6>
				<h6 id="<%#Eval("Id").ToString() %>" class="<%#Eval("Class").ToString() %>" title="Thêm vào giỏ hàng"></h6>
				<h6><a href="<%#Eval("Link").ToString() %>" title="<%# Eval("Name") %>"><%# Eval("Name") %></a></h6>
				<p class="l-height"><%# StringClass.FormatContentNews(Eval("Content").ToString(),100) %></p>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>
</div>
</section>
						<!--end Accessories -->
					</div>
					<!-- itemscope product wrapper -->
				</div>
				<!-- #center_column -->
			</div>
			<!--.large-left-->
		</div>
		<!--.row-->
	</div>
	<!-- .row -->
</div>
<!-- #columns -->
</asp:Content>
