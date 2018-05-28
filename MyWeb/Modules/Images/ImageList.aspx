<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="ImageList.aspx.cs" Inherits="MyWeb.Modules.Images.ImageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link type="text/css" href="../../scripts/unitegallery/css/unite-gallery.css" rel="stylesheet" />
<script type="text/javascript" src="../../scripts/unitegallery/js/unitegallery.js"></script>
<script type="text/javascript" src="../../scripts/unitegallery/js/unitegallery.min.js"></script>
<script type="text/javascript" src="../../scripts/unitegallery/themes/tilesgrid/ug-theme-tilesgrid.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id="columns" class="container">
<!-- Breadcrumb -->
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
<!-- /Breadcrumb -->
<div class="row">
<div class="large-left col-sm-12">
<div class="row" style="margin:0;">
<h4 class="title_block"><%=groupName %></h4>
<div id="gallery" style="display: none;">
<asp:Literal ID="ltrImages" runat="server"></asp:Literal>
</div>
<!--gallery-->
</div>
<!--row-->
</div>
<!--large-left-->
</div>
<!--row-->
</div>
<!--columns-->
<script type="text/javascript">
    jQuery(document).ready(function () {
        jQuery("#gallery").unitegallery();
    });
</script>
</asp:Content>
