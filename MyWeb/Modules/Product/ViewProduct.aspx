<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="ViewProduct.aspx.cs" Inherits="MyWeb.Modules.Product.ViewProduct" %>

<%@ Register Src="~/Controls/U_MenuLeft.ascx" TagPrefix="uc1" TagName="U_MenuLeft" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
    $(document).ready(function () {
        $("#nb_item").val(getParameterByName('<%=MyWeb.Common.Consts.CON_PARAM_URL_NO%>'));
        if ($("#nb_item").val() == null) {
            $("#nb_item").val("9");
        }
        $("#selectProductSort").val(getParameterByName('<%=MyWeb.Common.Consts.CON_PARAM_URL_SORT%>'));
        if ($("#selectProductSort").val() == null) {
            $("#selectProductSort").val('<%=MyWeb.Common.Consts.SortNum.asc.ToString()%>');
        }
    	$("#layered_form input[type=checkbox]").each(function (index) {
            $(this).click(function () {
                event.preventDefault();
            })
            var groupId = '<%= id%>';
            if ($(this).val() == groupId) {
                $(this).prop("checked", true);
                $(this).parent().children().children().addClass("red");
            }
            else {
                $(this).prop("checked", false);
            }
        })
    })
    function OnChangeItemsDisplay(e) {
        var no = $(e).val();
        var url = window.location.href;
        url = replaceUrlParam(url, '<%=MyWeb.Common.Consts.CON_PARAM_URL_PAGE%>', "1");
        window.location.href = replaceUrlParam(url, '<%=MyWeb.Common.Consts.CON_PARAM_URL_NO%>', no);
    }
    function OnChangeProductSort(e) {
        var sort = $(e).val();
        var url = window.location.href;
        url = replaceUrlParam(url, '<%=MyWeb.Common.Consts.CON_PARAM_URL_PAGE%>', "1");
            window.location.href = replaceUrlParam(url, '<%=MyWeb.Common.Consts.CON_PARAM_URL_SORT%>', sort);
        }
        function getParameterByName(name) {
            var match = RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
            return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
        }
        function replaceUrlParam(url, paramName, paramValue) {
            var pattern = new RegExp('(\\?|\\&)(' + paramName + '=).*?(&|$)')
            var newUrl = url
            if (url.search(pattern) >= 0) {
                newUrl = url.replace(pattern, '$1$2' + paramValue + '$3');
            }
            else {
                newUrl = newUrl + (newUrl.indexOf('?') > 0 ? '&' : '?') + paramName + '=' + paramValue
            }
            return newUrl
        }
</script>
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
<h1 class="page-heading product-listing">
<span class="cat-name"><%=groupName %></span>
<span class="heading-counter">Có <%=totalcount %> sản phẩm.</span>
</h1>
<div class="content_sortPagiBar clearfix">
<div class="sortPagiBar clearfix">
<ul class="display hidden-xs">
<li class="display-title">Hiển thị:</li>
<li id="grid">
<a rel="nofollow" href="#" title="Grid">
<i class="fa fa-th-large"></i>
<span>Dạng lưới</span>
</a>
</li>
<li id="list">
<a rel="nofollow" href="#" title="List">
<i class="fa fa-th-list"></i>
<span>Danh sách</span>
</a>
</li>
</ul>
<div id="productsSortForm" class="productsSortForm">
<div class="select selector1">
<label for="selectProductSort">Sắp xếp theo</label>
<select id="selectProductSort" class="selectProductSort form-control" onchange="OnChangeProductSort(this);">
<option value="asc" selected="selected">Tên sản phẩm: A tới Z</option>
<option value="desc">Tên sản phẩm: Z tới A</option>
</select>
</div>
</div>
<!-- /Sort products -->
<!-- nbr product/page -->
<div class="nbrItemPage">
<div class="clearfix selector1">
<label for="nb_item">
Hiển thị
</label>
<select name="n" id="nb_item" class="form-control" onchange="OnChangeItemsDisplay(this);">
<option value="9" selected="selected">9</option>
<option value="15">15</option>
<option value="30">30</option>
</select>
<span>mỗi trang</span>
</div>
</div>
<!-- /nbr product/page -->
</div>
<!-- sortPagiBar -->
</div>
<!-- content_sortPagiBar -->
<!-- Products list -->
<ul class="no-index product_list grid row">
<asp:Literal ID="ltrProducts" runat="server"></asp:Literal>
</ul>
<!--product_list-->
<div class="content_sortPagiBar">
<div class="bottom-pagination-content clearfix">
<div id="pagination_bottom" class="pagination clearfix">
<ul class="pagination">
<asp:Literal ID="ltrPaging" runat="server"></asp:Literal>
</ul>
<!--pagination-->
</div>
<!--pagination_bottom-->
</div>
<!--bottom-pagination-content-->
</div>
<!--content_sortPagiBar-->
</div>
<!--center_column-->
<div id="left_column" class="column col-xs-12 col-sm-3">
<uc1:U_MenuLeft runat="server" ID="U_MenuLeft" />
</div>
<!--left_column-->
</div>
</div>
<!--large-left-->
</div>
<!--row-->
</div>
<!--columns-->
</asp:Content>
