﻿<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="MyWeb.Default" %>

<%@ Import Namespace="MyWeb.Common" %>
<%@ Register Src="Controls/U_NewsList.ascx" TagPrefix="uc2" TagName="U_NewsList" %>
<%--<%@ Register Src="~/Controls/U_Delivery.ascx" TagPrefix="uc3" TagName="U_Delivery" %>--%>
<%@ Register Src="~/Controls/U_ImageList.ascx" TagPrefix="uc4" TagName="U_ImageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
					data: { mode: "add", id: proid }
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
			});
		})
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<main>
			<section class="well center767">
				<div class="container" style="padding-top:20px;">
						<asp:Repeater ID="rptGroup" runat="server" OnItemDataBound="rptGroup_ItemDataBound">
							<ItemTemplate>
								<div id="home-page-tabs" class="nav nav-tabs clearfix">
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
															<a href="<%#Eval("Link").ToString() %>" title="<%# Eval("Name") %>">
																<img src="<%# StringClass.ThumbImage(Eval("Image1").ToString()) %>" alt="<%# Eval("Name") %>" title="<%# Eval("Name") %>"></a>
															<h6 class="badge col-md-9 col-sm-9 col-xs-9"><%# StringClass.ShowPriceRange(Eval("Price").ToString()) %> Đ</h6>
															<h6 id="<%#Eval("Id").ToString() %>" class="col-md-2 col-sm-2 col-xs-2 <%#Eval("Class").ToString() %>" title="Thêm vào giỏ hàng"></h6>
															<h6 style="clear:left;"><a href="<%#Eval("Link").ToString() %>" title="<%# Eval("Name") %>"><%# StringClass.FormatContentNews(Eval("Name").ToString(), 45) %></a></h6>
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
				<%--<uc1:U_ProductList ID="idU_ProductList" runat="server" />--%>
			</section>
			<section class="well1 bg-white center479">
				<div class="container">
					<div class="row">
						<div class="col-lg-8 col-md-7 col-sm-12 col-xs-12 wow fadeInLeft">
							<h3><%= sAboutName %></h3>

							<p class="p_mod">
								<%= sContents %>
							</p>
						</div>
						<div class="col-lg-4 col-md-5 col-sm-6 col-xs-12 mg_add">
							<div class="row">
								<div class="col-md-6 col-sm-6 col-xs-6 wow fadeInRight" data-wow-delay="0.2s">
									<a href="<%= sUrl %>" class="btn btn-default">Về chúng tôi</a>
								</div>
							</div>
						</div>
					</div>
				</div>
			</section>
			<%--<section class="parallax well well__ins" data-url="images/parallax1.jpg" data-mobile="true">
				<div class="container">			
					<uc3:U_Delivery runat="server" id="idU_Delivery" />
				</div>
			</section>--%>
			<section class="well center991">
				<div class="container">				
					<uc2:U_NewsList runat="server" id="idU_NewsList" />
				</div>
			</section>
			<%--<section class="parallax well3 text-center" data-url="images/parallax2.jpg" data-mobile="true">
				<div class="container">
					<h2 class="wow fadeIn">
						<strong>
							<em>
								Một câu châm ngôn hay ở đây....
							</em>
						</strong>
					</h2>
				</div>
			</section>--%>
			<section class="well4 text-center">			
				<uc4:U_ImageList runat="server" id="idU_ImageList" />
			</section>
		</main>
</asp:Content>
