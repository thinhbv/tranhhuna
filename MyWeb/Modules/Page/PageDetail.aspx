<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="PageDetail.aspx.cs" Inherits="MyWeb.Modules.Page.PageDetail" %>

<%@ Register Src="~/Controls/U_MenuLeft.ascx" TagPrefix="uc1" TagName="U_MenuLeft" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<link href="../../../css/news-detail.css" rel="stylesheet" />
<script type="text/javascript">
    $(document).ready(function () {
        $("#ul_layered_id_attribute_group_1 input[type=checkbox]").each(function (index) {
            $(this).click(function () {
                event.preventDefault();
            })
            var groupId = '<%= pageId%>';
            if ($(this).val() == groupId) {
                $(this).prop("checked", true);
                $(this).parent().children().children().addClass("red");
            }
            else {
                $(this).prop("checked", false);
            }
        })
    })
</script>
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
<li class="crumb-1 last"><%=title %>
</li>
</ul>
</div>
<!-- /Breadcrumb -->
<div class="row">
<div class="large-left col-sm-12">
<div class="row">
<div id="center_column" class="center_column col-xs-12 col-sm-9">
<div itemtype="#" itemscope="" id="sdsblogArticle" class="blog-post">
<h5 class="title_block_exclusive"><%=title %></h5>
<div class="post-image">
<%=content %>
</div>
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
<!--block-addthis-->
</div>
<!--sdsarticleBottom-->
</div>
<!--blog-post-->
</div>
<!-- #center_column -->
<div id="left_column" class="column col-xs-12 col-sm-3">
<%--<uc1:U_MenuLeft ID="U_MenuLeft" runat="server" />--%>
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
