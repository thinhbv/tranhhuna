﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_GroupProductList.ascx.cs" Inherits="MyWeb.Controls.U_GroupProductList" %>
<%@ Import Namespace="MyWeb.Common" %>
<script type="text/javascript">
	$(document).ready(function () {
		if (window.location.pathname == "/" || window.location.pathname == "/Default.aspx") {
			$(".l-height").each(function () {
				$(this).hide();
			})
		}
		$(".added-cart").each(function () {
			$(this).attr("title", "Đã thêm vào giỏ hàng");
		})
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
			  		item.attr("class", "fa-shopping-cart added-cart");
			  		item.attr("title", "Đã thêm vào giỏ hàng");
			  		item.removeAttr("id");
			  		$("#item-count")[0].innerText = (parseInt($("#item-count")[0].innerText) + 1).toString();
			  	}
			  });
		})
	})
</script>
<div class="container" style="padding-top: 20px;">
	<asp:Repeater ID="rptGroup" runat="server" OnItemDataBound="rptGroup_ItemDataBound">
		<ItemTemplate>
			<div id="home-page-tabs" class="nav clearfix">
				<div class="homefeatured">
					<h5><a href='<%#Eval("Link").ToString() %>' title='<%#Eval("Name").ToString() %>'><%#Eval("Name").ToString() %></a></h5>
				</div>
				<div class="tab-content">
					<!-- Products list -->
					<div id="homefeatured" class="container">
						<div id="list-product" class="row">
							<asp:Repeater ID="rptPro" runat="server">
								<ItemTemplate>
									<div class="col-md-2 col-sm-4 col-xs-6 wow fadeInUp">
										<div class="item-row">
										<a href="<%#Eval("Link").ToString() %>" title="<%# Eval("Name") %>">
											<img src="<%# StringClass.ThumbImage(Eval("Image1").ToString()) %>" alt="<%# Eval("Name") %>" title="<%# Eval("Name") %>"></a>
										</div>
										<h6 class="badge col-md-12 col-sm-12 col-xs-12">
											<span class="price"><%# StringClass.ShowPriceRange(Eval("Price").ToString()) %> Đ</span>
											<span id="<%#Eval("Id").ToString() %>" class="<%#Eval("Class").ToString() %>" title="Thêm vào giỏ hàng"></span>
										</h6>
										<p class="l-height"><%# StringClass.FormatContentNews(Eval("Content").ToString(),100) %></p>
										<h6 style="clear: left;"><a href="<%#Eval("Link").ToString() %>" title="<%# Eval("Name") %>"><%# StringClass.FormatContentNews(Eval("Name").ToString(), 60) %></a></h6>
									</div>
								</ItemTemplate>
							</asp:Repeater>
						</div>
						<div id="list-product-04" class="row">
							<asp:Repeater ID="rptProducts04" runat="server">
								<ItemTemplate>
									<div class="col-md-3 col-sm-5 col-xs-6 wow fadeInUp">
										<div class="item-row">
										<a href="<%#Eval("Link").ToString() %>" title="<%# Eval("Name") %>">
											<img src="<%# Eval("Image1").ToString() %>" alt="<%# Eval("Name") %>" title="<%# Eval("Name") %>"></a>
										</div>
										<h6 class="badge col-md-12 col-sm-12 col-xs-12">
											<span class="price"><%# StringClass.ShowPriceRange(Eval("Price").ToString()) %> Đ</span>
											<span id="<%#Eval("Id").ToString() %>" class="<%#Eval("Class").ToString() %>" title="Thêm vào giỏ hàng"></span>
										</h6>
										<p class="l-height"><%# StringClass.FormatContentNews(Eval("Content").ToString(),100) %></p>
										<h6 style="clear: left;"><a href="<%#Eval("Link").ToString() %>" title="<%# Eval("Name") %>"><%# StringClass.FormatContentNews(Eval("Name").ToString(), 60) %></a></h6>
									</div>
								</ItemTemplate>
							</asp:Repeater>
						</div>
					</div>
					<!--homefeatured-->
				</div>
			</div>
			<!--home-page-tabs-->
		</ItemTemplate>
	</asp:Repeater>
</div>
