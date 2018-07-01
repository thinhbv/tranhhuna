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
				$(".container").find("input.quantity").attr("readonly", "true");
				//$(".container").find("input.quantity").attr("disabled", "true");
				//$(".container").find("select.prosize").attr("disabled", "true");
			})
			$("#<%=btnDelivery.ClientID%>").click(function () {
				if ($('#<%=fname.ClientID%>').val().trim() === "") {
					$('#<%=lblName.ClientID%>').show();
					$('#<%=fname.ClientID%>').focus();
					return false;
				}
				if ($('#<%=email.ClientID%>').val().trim() === "") {
					$('#<%=lblEmail.ClientID%>').show();
					$('#<%=email.ClientID%>').focus();
					return false;
				}
				if ($('#<%=adr.ClientID%>').val().trim() === "") {
					$('#<%=lblTel.ClientID%>').show();
					$('#<%=adr.ClientID%>').focus();
					return false;
				}
				if ($('#<%=city.ClientID%>').val().trim() === "") {
					$('#<%=lblAddress.ClientID%>').show();
					$('#<%=city.ClientID%>').focus();
					return false;
				}
				return true;
			})
			$(".cmdDelete").click(function () {
				if (confirm('Bạn có muốn xóa?')) {
					var del = $(this);
					var id = $(this).attr("data");
					var price = $(this).parent().find("span.price").text().replace(/\./g, "").trim();
					var totalprice = $("#total-price").text().replace(" Đ", "").replace(/\./g, "").trim();
					$.ajax({
						method: "POST",
						url: "/Processor.aspx",
						data: { mode: 'delete', procid: id }
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
			   }
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
				var total = $("#total-price").text().replace(" Đ", "").replace(/\./g, "").trim();
				var originprice = $(this).parent().find("span.originprice").text();
				var currentprice = $(this).parent().find("span.price").text().replace(/\./g, "").trim();
				var price;
				price = parseInt(originprice) * parseInt($(this).val());
				$(this).parent().find("span.price").text(FormatPrice(price) + " Đ");
				total = parseInt(total) + parseInt(price) - parseInt(currentprice);
				$("#total-price").text(FormatPrice(total) + " Đ");
			});
			$('.prosize').change(function () {
				var index = this.selectedIndex;
				var quantity = $(this).parent().find("input.quantity").val();
				var total = $("#total-price").text().replace(" Đ", "").replace(/\./g, "").trim();
				var originprice = $(this).parent().find("span.originprice").text();
				var currentprice = $(this).parent().find("span.price").text().replace(/\./g, "").trim();
				var lPrice = $($(this).prev()).val();
				var arr = lPrice.split(",");
				var price = parseInt(arr[index]) * parseInt(quantity);
				$(this).parent().find("span.price").text(FormatPrice(price) + " Đ");
				total = parseInt(total) + parseInt(price) - parseInt(currentprice);
				$("#total-price").text(FormatPrice(total) + " Đ");
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
				<h4 id="shoppingcart" runat="server">Giỏ hàng của bạn 
					<span class="price" style="color: black">
						<i class="fa fa-shopping-cart"></i>
						<b id="itemcount"><%=totalCount.ToString() %></b> sản phẩm
					</span>
				</h4>
				<asp:Repeater ID="rptCart" runat="server" OnItemDataBound="rptCart_ItemDataBound">
					<ItemTemplate>
						<p>
							<asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("Id").ToString() %>' />
							<asp:HiddenField ID="hdSize" runat="server" Value='<%#Eval("Size").ToString() %>' />
							<asp:HiddenField ID="hdProductId" runat="server" Value='<%#Eval("ProductId").ToString() %>' />
							<%#Eval("ProductName").ToString() %><img alt="<%#Eval("ProductName").ToString() %>" title="<%#Eval("ProductName").ToString() %>" src="<%#StringClass.ThumbImage(Eval("ProductImage").ToString()) %>" width="80" />
							Số lượng:
							<asp:TextBox ID="txtquantity" CssClass="quantity" runat="server" Text='<%#Eval("Quantity").ToString() %>' Width="50" />
							<span class="originprice" style="display: none"><%#int.Parse(Eval("Price").ToString())/int.Parse(Eval("Quantity").ToString()) %></span>
							<asp:HiddenField ID="hdPrice" runat="server" Value="" />
							Kích thước:
							<asp:DropDownList ID="ddlSize" runat="server" CssClass="prosize" Width="80"></asp:DropDownList>&nbsp;cm
							<span class="btndelete">
								<img class="cmdDelete" data="<%#Eval("ProductId").ToString() %>" alt="Xóa" title="Xóa" src="/App_Themes/Admin/images/delete.png" /></span>
							<span class="price"><%#StringClass.ConvertPrice(Eval("Price").ToString()) %>  Đ
							</span>

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
			<div id="btnbuy" class="container" style="background: none; border: none; padding: 0;">
				<input type="button" id="btnInfo" value="Mua hàng" class="button-form" />
			</div>
		</div>
		<div class="col-75">
			<div id="info" class="container" style="display: none;">

				<div class="row">
					<div class="col-50">
						<h3>Thông tin của bạn</h3>
						<label for="fname"><i class="fa fa-user"></i>Họ và tên</label>
						<asp:Label ID="lblName" runat="server" Text="Vui lòng nhập tên của bạn!" Visible="false"></asp:Label>
						<input type="text" runat="server" id="fname" name="firstname" placeholder="Nguyễn Văn A">
						<label for="email"><i class="fa fa-envelope"></i>Email</label>
						<asp:Label ID="lblEmail" runat="server" Text="Vui lòng nhập Email của bạn!" Visible="false"></asp:Label>
						<input type="text" runat="server" id="email" name="email" placeholder="abc@example.com">
						<label for="adr"><i class="fa fa-address-card-o"></i>Số điện thoại</label>
						<asp:Label ID="lblTel" runat="server" Text="Vui lòng nhập số điện thoại của bạn!" Visible="false"></asp:Label>
						<input type="text" runat="server" id="adr" name="address" placeholder="098.888.888">
						<label for="city"><i class="fa fa-institution"></i>Địa chỉ</label>
						<asp:Label ID="lblAddress" runat="server" Text="Vui lòng nhập địa chỉ của bạn!" Visible="false"></asp:Label>
						<input type="text" runat="server" id="city" name="city" placeholder="Hà Nội">
						<label for="content"><i class="fa fa-institution"></i>Chú ý</label>
						<input type="text" runat="server" id="content" name="content" placeholder="Nội dung yêu cầu thêm (nếu có)">
					</div>

					<div class="col-50">
						<h3>Thông tin thanh toán</h3>
						<label for="fname"><i class="fa fa-address-card-o"></i>Phương thức thanh toán</label>
						<div class="maxl">
							<label class="radio inline">
								<input id="rdoChuyenkhoan" runat="server" type="radio" name="Payment" value="1" checked>
								<span>Chuyển khoản ngân hàng</span>
							</label>
							<label class="radio inline">
								<input id="rdoTructiep" runat="server" type="radio" name="Payment" value="2">
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
