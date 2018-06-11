<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="MyWeb.Modules.Product.CheckOut" %>

<%@ Import Namespace="MyWeb.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<link rel="stylesheet" href="../../../css/font-awesome.min.css">
	<link href="../../../css/shoppingcart.css" rel="stylesheet" />
	<script type="text/javascript">
		$(document).ready(function () {
			if ($("#itemcount").text() === "0") {
				$("#btnbuy").css("display", "none");
			}
			$("#btnInfo").click(function () {
				$("#info").css("display", "block");
				$("#btnbuy").css("display", "none");
			})
			$(".cmdDelete").click(function () {
				var del = $(this);
				var id = $(this).attr("data");
				var price = $(this).prev().text().replace(/\./g, "").trim();
				var totalprice = $("#total-price").text().replace(" Đ", "").replace(/\./g, "").trim();
				$.ajax({
					method: "POST",
					url: "/Processor.aspx",
					data: { mode: 'delete', orderid: id }
				})
			  .done(function (result) {
			  	if (result === "1") {
			  		$("#item-count")[0].innerText = (parseInt($("#item-count")[0].innerText) - 1).toString();
			  		$("#itemcount")[0].innerText = (parseInt($("#itemcount")[0].innerText) - 1).toString();
			  		if ($("#itemcount").text() === "0") {
			  			del.parent().parent().next().next().remove();
			  			$('#<%=lblMsg.ClientID%>').text('Hiện tại không có sản phẩm nào trong giỏ hàng');
			  			$("#btnbuy").css("display", "none");
			  			$("#info").css("display", "none");
					  }
				  	del.parent().parent().next().remove();
				  	del.parent().parent().remove();
				  	totalprice = (parseInt(totalprice) - parseInt(price)).toString();
				  	
				  	totalprice = FormatPrice(totalprice) + " Đ";
				  	$("#total-price").text(totalprice);
				  }
			  });
			})
			//called when key is pressed in textbox
			$(".quantity").keypress(function (e) {
				//if the letter is not digit then display error and don't type anything
				if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
					return false;
				}
				if ($(this).val() > 9 || $(this).val() < 0) {
					return false;
				}
			});
			$(".quantity").change(function () {
				if ($(this).val() == "") {
					$(this).val(1);
				}
				var id = $(this).attr("data");
				var total = $("#total-price").text().replace(" Đ", "").replace(/\./g, "").trim();
				var originprice = $(this).next().text();
				var currentprice = $($(this).next().next().children()[0]).text().replace(/\./g, "").trim();
				var price;
				price = parseInt(originprice) * parseInt($(this).val());
				$(this).next().next().children().text(FormatPrice(price));
				total = parseInt(total) + parseInt(price) - parseInt(currentprice);
				$("#total-price").text(FormatPrice(total) + " Đ");
				$.ajax({
					method: "POST",
					url: "/Processor.aspx",
					data: { mode: 'update', orderid: id, quantity: $(this).val() }
				})
			  .done(function (result) {
			  	if (result === "1") {
			  		
			  	}
			  });
			});
		})

		FormatPrice = function (price) {
			price = price.toString();
			var chunks = [];
			for (var i = price.length; i > 0; i -= 3) {
				if ((i - 3) > 0) {
					chunks.push(price.substring(i, i - 3));
				}
				else {
					chunks.push(price.substring(0, i));
				}
			}
			chunks = chunks.reverse();
			price = chunks.join(".");
			return price;
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div id="cart" class="row">
		<div class="col-25">
			<div class="container">
				<h4 id="shoppingcart" runat="server" >Giỏ hàng của bạn 
					<span class="price" style="color: black">
						<i class="fa fa-shopping-cart"></i>
						<b id="itemcount"><%=totalCount.ToString() %></b> sản phẩm
					</span>
				</h4>
				<asp:Repeater ID="rptCart" runat="server">
					<ItemTemplate>
						<p>
							<asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("Id").ToString() %>' />
							<%#Eval("ProductName").ToString() %><img alt="<%#Eval("ProductName").ToString() %>" title="<%#Eval("ProductName").ToString() %>" src="<%#StringClass.ThumbImage(Eval("ProductImage").ToString()) %>" width="80" />
							<asp:TextBox ID="txtquantity" CssClass="quantity" runat="server" Text='<%#Eval("Quantity").ToString() %>' width="50"/>
							
							<span style="display:none"><%#int.Parse(Eval("Price").ToString())/int.Parse(Eval("Quantity").ToString()) %></span>
							<span class="price"><span><%#StringClass.ConvertPrice(Eval("Price").ToString()) %></span>  Đ
								<img class="cmdDelete" data="<%#Eval("Id").ToString() %>" alt="Xóa" title="Xóa" src="/App_Themes/Admin/images/delete.png" onclick="javascript:return confirm('Bạn có muốn xóa?');" /></span>
						</p>
						<hr>
					</ItemTemplate>
					<FooterTemplate>
						<p>Tổng tiền <span class="price" style="color: black; margin-top: 0px;"><b id="total-price"><%=totalPrice %> Đ</b></span></p>
					</FooterTemplate>
				</asp:Repeater>
				<asp:Label ID="lblMsg" runat="server" Text="" EnableViewState="false"></asp:Label>
			</div>
		</div>
		<div class="col-25">
			<div id="btnbuy" class="container" style="background:none;border:none;padding:0;">
				<input type="button" id="btnInfo" value="Mua hàng" class="button-form" />
			</div>
		</div>
		<div class="col-75">
			<div id="info" class="container" style="display:none;">

				<div class="row">
					<div class="col-50">
						<h3>Thông tin của bạn</h3>
						<label for="fname"><i class="fa fa-user"></i>Họ và tên</label>
						<input type="text" runat="server" id="fname" name="firstname" placeholder="Nguyễn Văn A">
						<asp:Label ID="lblName" runat="server" Text="Vui lòng nhập tên của bạn!" Visible="false"></asp:Label>
						<label for="email"><i class="fa fa-envelope"></i>Email</label>
						<input type="text" runat="server" id="email" name="email" placeholder="abc@example.com">
						<asp:Label ID="lblEmail" runat="server" Text="Vui lòng nhập Email của bạn!" Visible="false"></asp:Label>
						<label for="adr"><i class="fa fa-address-card-o"></i>Số điện thoại</label>
						<input type="text" runat="server" id="adr" name="address" placeholder="098.888.888">
						<asp:Label ID="lblTel" runat="server" Text="Vui lòng nhập số điện thoại của bạn!" Visible="false"></asp:Label>
						<label for="city"><i class="fa fa-institution"></i>Địa chỉ</label>
						<input type="text" runat="server" id="city" name="city" placeholder="Hà Nội">
						<asp:Label ID="lblAddress" runat="server" Text="Vui lòng nhập địa chỉ của bạn!" Visible="false"></asp:Label>
						<label for="content"><i class="fa fa-institution"></i>Chú ý</label>
						<input type="text" runat="server" id="content" name="content" placeholder="Nội dung yêu cầu thêm (nếu có)">
					</div>

					<div class="col-50">
						<h3>Thông tin thanh toán</h3>
						<label for="fname"><i class="fa fa-address-card-o"></i>Phương thức thanh toán</label>
						<div class="maxl">
							<label class="radio inline">
								<input id="rdoChuyenkhoan" runat="server" type="radio" name="Payment" value="0" checked>
								<span>Chuyển khoản ngân hàng</span>
							</label>
							<label class="radio inline">
								<input id="rdoTructiep" runat="server" type="radio" name="Payment" value="1">
								<span>Thanh toán trực tiếp</span>
							</label>
						</div>
					</div>
				</div>
				<asp:Button ID="btnDelivery" runat="server" Text="Đặt hàng" CssClass="button-form" OnClick="btnDelivery_Click" />
			</div>
		</div>
	</div>
</asp:Content>
