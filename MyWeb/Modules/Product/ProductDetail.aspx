<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="MyWeb.Modules.Product.ProductDetail" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
<link href="../../../css/product.css" rel="stylesheet" />
<link href="../../../scripts/jqzoom/jquery.jqzoom.css" rel="stylesheet" />
<script type="text/javascript" src="../../../scripts/product.js"></script>
<script type="text/javascript" src="../../../scripts/jqzoom/jquery.jqzoom.js"></script>
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
<div class="pb-left-column col-sm-6 col-md-6 col-lg-8">
<!-- product img-->
<div id="image-block" class="clearfix is_caroucel">
<span class="sale-box no-print">
<span class="sale-label">Mới!</span>
</span>
<span id="view_full_size">
<a class="jqzoom" title="<%= name %>" rel="gal1" href="<%=sImage_01 %>">
<img itemprop="image" src="<%= sImage_01%>" title="<%= name %>" alt="<%= name %>" />
</a>
<!--jqzoom-->
</span>
</div>
<!-- end image-block -->
<!-- thumbnails -->
<div id="views_block" class="clearfix">
<a id="view_scroll_left" class="" title="Other views" href="javascript:{}">Previous</a>
<!-- thumbs_list -->
<div id="thumbs_list">
<ul id="thumbs_list_frame">
<asp:Literal ID="ltrImages" runat="server"></asp:Literal>
</ul>
</div>
<!-- end thumbs_list -->
<a id="view_scroll_right" title="Other views" href="javascript:{}">Next</a>
</div>
<!-- end thumbnails -->
</div>
<!-- center infos -->
<div class="pb-right-column col-sm-6 col-md-6 col-lg-4">
<h1 itemprop="name"><%= name %></h1>
<div class="product-info-line">
<p id="product_condition">
<label>Mô tả: </label>
<span class="editable"><%=content %></span>
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
<li class="product-description-tab active"><a data-toggle="tab" href="<%=Request.RawUrl %>#product-description-tab-content">More info</a></li>
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
<div class="block products_block accessories-block clearfix">
<div class="block_content">
<asp:Literal ID="ltrRelated" runat="server"></asp:Literal>
</div><!--block_content-->
</div><!--products_block-->
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
