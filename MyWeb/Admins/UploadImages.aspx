<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UploadImages.aspx.cs" Inherits="MyWeb.Admins.UploadImages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script type="text/javascript">
		var win;
		function OpenCenter(url, name, w, h) {
			var left = (screen.width - w) / 2;
			var top = (screen.height - h) / 4;
			win = window.open(url, name, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
			var pollTimer = window.setInterval(function () {
				if (win.closed !== false) { // !== is required for compatibility with Opera
					window.clearInterval(pollTimer);
					window.location.reload();
				}
			}, 200);
		}

	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="PageName">
		Upload ảnh
	</div>

	<asp:Panel ID="pnUpdate" runat="server">
		<table class="TableUpdate" border="1">
			<tr>
				<td class="Control" colspan="2">
					<ul>
						<li>
							<asp:LinkButton CssClass="uupdate" ID="lbtUploadT" runat="server" OnClick="lbtUpload_Click">Upload</asp:LinkButton></li>
						<li>
							<a href="javascript:void(0);" class="vadd" onclick="OpenCenter('/scripts/ckfinder/ckfinder.html','CreateFolder','600', '600');" >Tạo thư mục</a></li>
						<li>
							<asp:LinkButton CssClass="uback" ID="lbtClearT" runat="server"
								CausesValidation="False">Clear</asp:LinkButton></li>
					</ul>
				</td>
			</tr>	
			<tr>
				<th>
					<asp:Label ID="Label1" runat="server" Text="Thư mục Upload:"></asp:Label>
				</th>
				<td>
					<asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows" NodeIndent="15">
						<HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
						<NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
							NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
						<ParentNodeStyle Font-Bold="False" />
						<SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
							VerticalPadding="0px" />
					</asp:TreeView>
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblPath" runat="server" Text="Chọn ảnh:"></asp:Label>
				</th>
				<td>
					<asp:FileUpload ID="fupFiles" runat="server" AllowMultiple="true" />
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblMsg" runat="server" Text="Kết quả Upload:"></asp:Label>
				</th>
				<td>
					<asp:Label ID="Span1" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="Control" colspan="2">
					<ul>
						<li>
							<asp:LinkButton CssClass="uupdate" ID="lbtUploadB" runat="server" OnClick="lbtUpload_Click">Upload</asp:LinkButton></li>
						<li>
							<a href="javascript:void(0);" class="vadd" onclick='window.open("/scripts/ckfinder/ckfinder.html","CreateFolder","width=500,height=700");' >Tạo thư mục</a></li>
						<li>
							<asp:LinkButton CssClass="uback" ID="lbtClearB" runat="server"
								CausesValidation="False">Clear</asp:LinkButton></li>
					</ul>
				</td>
			</tr>
		</table>
	</asp:Panel>
</asp:Content>
