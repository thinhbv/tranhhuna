<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UploadFiles.aspx.cs" Inherits="MyWeb.Admins.UploadFiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
					</ul>
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblFolderName" runat="server" Text="Tên folder upload:"></asp:Label>
				</th>
				<td>
					<asp:TextBox ID="txtFolderNameUpload" runat="server" />
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblPath" runat="server" Text="Chọn files:"></asp:Label>
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
					<asp:Label ID="Span1" runat="server" Text=""></asp:Label>
				</td>
			</tr>
			<tr>
				<td class="Control" colspan="2">
					<ul>
						<li>
							<asp:LinkButton CssClass="uupdate" ID="lbtUploadB" runat="server" OnClick="lbtUpload_Click">Upload</asp:LinkButton></li>
					</ul>
				</td>
			</tr>
		</table>
	</asp:Panel>
</asp:Content>
