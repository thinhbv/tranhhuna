<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_ImageList.ascx.cs" Inherits="MyWeb.Controls.U_ImageList" %>
<%@ Import Namespace="MyWeb.Common" %>
<link type="text/css" href="../../scripts/unitegallery/css/unite-gallery.css" rel="stylesheet" />
<%--<script type="text/javascript" src="../../scripts/unitegallery/js/unitegallery.js"></script>--%>
<script type="text/javascript" src="../../scripts/unitegallery/js/unitegallery.min.js"></script>
<script type="text/javascript" src="../../scripts/unitegallery/themes/tilesgrid/ug-theme-tilesgrid.js"></script>
<div class="container">
	<h3 class="clr-default text-center">Hình ảnh sản phẩm</h3>
	<div class="row col-4_mod" id="gallery" style="display: none;">
		<asp:Repeater ID="rptImages" runat="server">
			<ItemTemplate>
				<a href="#">
					<img alt=''
						src='<%#StringClass.ThumbImage(Eval("Image").ToString()) %>'
						data-image='<%#Eval("Image") %>'
						style='display: none'></a>

			</ItemTemplate>
		</asp:Repeater>
	</div>
	<a href="/thu-vien-anh" class="btn btn-primary off2">Xem thêm</a>
</div>
<script type="text/javascript">
	jQuery(document).ready(function () {
		jQuery("#gallery").unitegallery({
			tile_enable_shadow: false
		});
	});
</script>
