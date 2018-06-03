<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="MyWeb.Modules.Product.CheckOut" %>

<%@ Import Namespace="MyWeb.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<link rel="stylesheet" href="../../../css/font-awesome.min.css">
	<link href="../../../css/shoppingcart.css" rel="stylesheet" />
	<script type="text/javascript">
		$(document).ready(function () {
			$(".cmdDelete").click(function () {
				$(this).parent().parent().remove();
				var id = $(this).attr("data");
				$.ajax({
					method: "POST",
					url: "/Processor.aspx",
					data: { del: 'true', orderid: id }
				})
			  .done(function (result) {
			  	if (result.startsWith("1")) {
			  		$("#item-count")[0].innerText = (parseInt($("#item-count")[0].innerText) - 1).toString();
			  	}
			  });
			})
		})
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div id="cart" class="row">
		<div class="col-25">
			<div class="container">
				<h4>Giỏ hàng của bạn 
					<span class="price" style="color: black">
						<i class="fa fa-shopping-cart"></i>
						<b><%=totalCount.ToString() %> sản phẩm</b>
					</span>
				</h4>
				<asp:Repeater ID="rptCart" runat="server">
					<ItemTemplate>
						<p>
							<%#Eval("ProductName").ToString() %><img alt="<%#Eval("ProductName").ToString() %>" title="<%#Eval("ProductName").ToString() %>" src="<%#StringClass.ThumbImage(Eval("ProductImage").ToString()) %>" width="80" />
							<span class="price"><%#StringClass.ConvertPrice(Eval("Price").ToString()) %>  Đ
								<img class="cmdDelete" data="<%#Eval("Id").ToString() %>" alt="Xóa" title="Xóa" src="/App_Themes/Admin/images/delete.png" onclick="javascript:return confirm('Bạn có muốn xóa?');" /></span>
						</p>
						<hr>
					</ItemTemplate>
					<FooterTemplate>
						<p>Tổng tiền <span class="price" style="color: black; margin-top:0px;"><b><%=totalPrice %> Đ</b></span></p>
					</FooterTemplate>
				</asp:Repeater>
				<asp:Label ID="lblMsg" runat="server" Text="Hiện tại không có sản phẩm nào trong giỏ hàng" Visible="false" EnableViewState="false"></asp:Label>
			</div>
		</div>
		<div class="col-75">
			<div class="container">
				<form action="/action_page.php">

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
					<asp:Button ID="btnDelivery" runat="server" Text="Đặt hàng" CssClass="btn" OnClick="btnDelivery_Click" />
				</form>
			</div>
		</div>

	</div>
</asp:Content>
