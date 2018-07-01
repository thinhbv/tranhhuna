<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_ProductList.ascx.cs" Inherits="MyWeb.Controls.U_ProductList" %>
<%@ Import Namespace="MyWeb.Common" %>
<script type="text/javascript">

	$(document).ready(function () {
		if (window.location.pathname == "/" || window.location.pathname == "/Default.aspx") {
			$(".l-height").each(function () {
				$(this).hide();
			})
		}
		$(".added-cart").each(function () {
			$(this).attr("title", "Xóa khỏi giỏ hàng");
		})
		$(".add-cart").click(function () {
			var proid = $(this)[0].id;
			var item = $(this);
			$.ajax({
				method: "POST",
				url: "/Processor.aspx",
				data: { mode:"add", id: proid }
			})
			  .done(function (result) {
			  	if (result === "1") {
			  		item.removeAttr("class");
			  		item.attr("class", "added-cart");
			  		item.attr("title", "Xóa khỏi giỏ hàng");
			  		item.removeAttr("id");
			  		$("#item-count")[0].innerText = (parseInt($("#item-count")[0].innerText) + 1).toString();
			  	}
			  });
		})
		$(".added-cart").click(function () {
			var proid = $(this)[0].id;
			var item = $(this);
			$.ajax({
				method: "POST",
				url: "/Processor.aspx",
				data: { mode: 'delete', procid: proid }
			})
			  .done(function (result) {
			  	if (result === "1") {
			  		item.removeAttr("class");
			  		item.attr("class", "add-cart");
			  		item.attr("title", "Thêm vào giỏ hàng");
			  		$("#item-count")[0].innerText = (parseInt($("#item-count")[0].innerText) - 1).toString();
			  	}
			  });
		})
	})
</script>
<div class="container">
	<div class="row">
		<asp:Repeater ID="rptProducts" runat="server">
			<ItemTemplate>
				<div class="col-md-2 col-sm-4 col-xs-6 wow fadeInUp">
					<a href="<%#Eval("Link").ToString() %>" title="<%# Eval("Name") %>">
						<img src="<%# StringClass.ThumbImage(Eval("Image1").ToString()) %>" alt="<%# Eval("Name") %>" title="<%# Eval("Name") %>"></a>
					<h6 class="badge"><%# StringClass.ShowPriceRange(Eval("Price").ToString()) %> Đ</h6>
					<h6 id="<%#Eval("Id").ToString() %>" class="<%#Eval("Class").ToString() %>" title="Thêm vào giỏ hàng"></h6>
					<h6><a href="<%#Eval("Link").ToString() %>" title="<%# Eval("Name") %>"><%# Eval("Name") %></a></h6>
					<p class="l-height"><%# StringClass.FormatContentNews(Eval("Content").ToString(),100) %></p>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
</div>
