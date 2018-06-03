<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_ProductList.ascx.cs" Inherits="MyWeb.Controls.U_ProductList" %>
<%@ Import Namespace="MyWeb.Common" %>
<script type="text/javascript">
	$(document).ready(function () {
		$(".add-cart").click(function () {
			var proid = $(this)[0].id;
			$(this).removeAttr("class");
			$(this).attr("class", "added-cart");
			$.ajax({
				method: "POST",
				url: "/Processor.aspx",
				data: { id: proid }
			})
			  .done(function (result) {
			  	if (result.startsWith("1")) {
			  		$("#item-count")[0].innerText = (parseInt($("#item-count")[0].innerText) + 1).toString();
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
					<h6 class="badge"><%# StringClass.ConvertPrice(Eval("Price").ToString()) %> Đ</h6>
					<h6 id="<%#Eval("Id").ToString() %>" class="add-cart" title="Thêm vào giỏ hàng">+ giỏ hàng</h6>
					<h6><a href="<%#Eval("Link").ToString() %>" title="<%# Eval("Name") %>"><%# Eval("Name") %></a></h6>
					<p class="l-height"><%# StringClass.FormatContentNews(Eval("Content").ToString(),100) %></p>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
</div>
