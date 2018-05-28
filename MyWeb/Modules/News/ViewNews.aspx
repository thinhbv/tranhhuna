<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="ViewNews.aspx.cs" Inherits="MyWeb.Modules.News.ViewNews" %>

<%@ Register Src="/Controls/U_MenuLeftNews.ascx" TagName="U_MenuLeftNews" TagPrefix="uc1" %>
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
<asp:Literal ID="ltrCrumb" runat="server"></asp:Literal>
<li class="crumb-3 last"><%=groupName %>
</li>
</ul>
</div>
<!-- /Breadcrumb -->
<div class="row">
<div class="large-left col-sm-12">
<div class="row">
<div id="center_column" class="center_column col-xs-12 col-sm-9">
<h1 class="page-heading"><%=groupName %></h1>
<div id="smartblogcat" class="block">
<asp:Literal ID="ltrNews" runat="server"></asp:Literal>
<asp:Repeater ID="rptNews" runat="server">
<ItemTemplate>
<div itemtype="#" itemscope="" class="sdsarticleCat clearfix">
<div id="smartblogpost-<%# Container.ItemIndex + 1 %>">
<h2 class='title_block_exclusive'><a title="<%# Eval("Name").ToString() %>" href='<%# MyWeb.Common.PageHelper.GeneralDetailUrl(MyWeb.Common.Consts.CON_TIN_TUC, groupName, Eval("Id").ToString(), Eval("Name").ToString()) %>'><%# Eval("Name").ToString() %></a></h2>
<div class="articleContent">
<a href="<%# MyWeb.Common.PageHelper.GeneralDetailUrl(MyWeb.Common.Consts.CON_TIN_TUC, groupName, Eval("Id").ToString(), Eval("Name").ToString()) %>" itemprop="url" title="<%#Eval("Name").ToString() %>" class="imageFeaturedLink post-image">
<img itemprop="image" alt="<%# Eval("Name").ToString() %>" src="<%# Eval("Image").ToString() %>" class="imageFeatured img-responsive">
</a>
<div class="sdsarticle-des" itemprop="description">
<%# MyWeb.Common.StringClass.FormatContentNews(Eval("Content").ToString(), 200) %>
<a class="read-more" title="<%# Eval("Name").ToString() %>" href="<%# MyWeb.Common.PageHelper.GeneralDetailUrl(MyWeb.Common.Consts.CON_TIN_TUC, groupName, Eval("Id").ToString(), Eval("Name").ToString()) %>"><strong>Chi tiết...</strong></a>
</div>
<div class="articleHeader">
<div class="postInfo">
Posted by														
<span itemprop="author">
<i class="fa fa-user"></i>
Admin Administrator
</span>
<span itemprop="articleSection">
<i class="fa fa-tags"></i>
<a href="#">Management</a>
</span>
<span class="comment">
<i class="fa fa-comments"></i>
<a title="0 Comments" href="#">0  Comments</a>
</span>
<span class="views">
<i class="fa fa-eye"></i>views (505)
</span>
</div>
</div>
</div>
</div>
</div>
</ItemTemplate>
</asp:Repeater>
</div>
<!--.smartblogcat-->
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
