<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="MyWeb.Modules.News.NewsDetail" %>

<%@ Register Src="/Controls/U_MenuLeftNews.ascx" TagName="U_MenuLeftNews" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
<li class="crumb-3 last"><%=titleNews %>
</li>
</ul>
</div>
<!-- /Breadcrumb -->
<div class="row">
<div class="large-left col-sm-12">
<div class="row">
<div id="center_column" class="center_column col-xs-12 col-sm-9">
<div itemtype="#" itemscope="" id="sdsblogArticle" class="blog-post">
<h1 class="title_block_exclusive"><%=titleNews %></h1>
<div class="post-image">
<%=contents %>
</div>
<!--post-image-->
<div class="sdsarticle-des">
<asp:Literal ID="ltrDetail" runat="server"></asp:Literal>
</div>
<!--sdsarticle-des-->
<div class="sdsarticleBottom">
<!-- Go to www.addthis.com/dashboard to customize your tools -->
<script type="text/javascript" src="//s7.addthis.com/js/300/addthis_widget.js#pubid=ra-4f87903d1009b87f"></script>
<div class="block-addthis">
<!-- Go to www.addthis.com/dashboard to customize your tools -->
<div class="addthis_inline_share_toolbox_z3zm"></div>
</div>
<div id="articleRelated" class="block">
<h4 class="title_block">Tin liên quan</h4>
<div class="block_content">
<ul class="row">
<asp:Literal ID="ltrNewsReleate" runat="server"></asp:Literal>
</ul>
</div>
<!--block_content-->
</div>
<!--articleRelated-->
</div>
<!--sdsarticleBottom-->
</div>
<!--blog-post-->
</div>
<!-- #center_column -->
<div id="left_column" class="column col-xs-12 col-sm-3">
<uc1:U_MenuLeftNews ID="U_MenuLeftNews" runat="server" />
</div>
</div>
<!--.row-->
</div>
<!--.large-left-->
</div>
<!--.row-->
</div>
<!-- #columns -->
</asp:Content>
