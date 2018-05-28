<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_ImageList.ascx.cs" Inherits="MyWeb.Controls.U_ImageList" %>
<div class="container">
	<h3 class="clr-default text-center">Hình ảnh sản phẩm</h3>
	<div class="row col-4_mod">
		<asp:Repeater ID="rptImages" runat="server">
			<ItemTemplate>
				<div class="col-md-4 col-sm-6 col-xs-12">
					<a class="thumb" href='<%#Eval("Image").ToString() %>'>
						<img src='<%#Eval("Thumbnail").ToString() %>' alt="" />
						<span class="thumb_overlay"></span>
					</a>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
	<a href="#" class="btn btn-primary off2">Xem thêm</a>
</div>
