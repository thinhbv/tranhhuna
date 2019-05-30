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
	<asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="Login" />
<asp:Panel ID="pnlProfile" runat="server" Visible="false">
<hr />
<asp:DataList ID="dlFiles" runat="server">
<ItemTemplate>
<table border="0" cellpadding="0" cellspacing="0" class="table">
        <tr>
            <th colspan="2">
                <%# Eval("Title") %>
            </th>
        </tr>
        <tr>
            <td rowspan="6" style="width: 100px" valign="top">
                <a href='<%# Eval("ThumbnailLink") %>' target="_blank">
                    <img alt="" src='<%# Eval("ThumbnailLink") %>' class="thumbnail" />
                </a>
            </td>
            <tr>
                <td style="width: 200px">
                    <b>File Name:</b>
                    <%# Eval("OriginalFileName") %>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Created Date:</b>
                    <%# Convert.ToDateTime(Eval("CreatedDate")).ToString("dd, MMM yyyy") %>
                </td>
            </tr>
            <tr>
                <td>
                    <b>Modified Date:</b>
                    <%# Convert.ToDateTime(Eval("ModifiedDate")).ToString("dd, MMM yyyy") %>
                </td>
            </tr>
            <tr>
                <td>
                    <b>File Type:</b>
                    <img alt="" src='<%# Eval("IconLink") %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <a href='<%# Eval("WebContentLink") %>'>Download File</a>
                </td>
            </tr>
        </tr>
    </table>
</ItemTemplate>
</asp:DataList>
</asp:Panel>
</asp:Content>
