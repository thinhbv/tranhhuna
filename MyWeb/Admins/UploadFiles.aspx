<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UploadFiles.aspx.cs" Inherits="MyWeb.Admins.UploadFiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="PageName">
		Quản lý file download free

	</div>
	<asp:Panel ID="pnView" runat="server">
		<div class="Control">
			<ul>
				<li>
					<asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" OnClick="AddButton_Click">Thêm mới</asp:LinkButton></li>
				<li>
					<asp:LinkButton CssClass="vrefresh" ID="lbtSynchT" runat="server" OnClick="lbtSynch_Click">Đồng bộ dữ liệu</asp:LinkButton></li>
				<li>
					<asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
				<li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở
                    lại</a> </li>
			</ul>
		</div>
		<asp:DataGrid ID="grdUploadFiles" runat="server" Width="100%" CssClass="TableView"
			AutoGenerateColumns="False" AllowPaging="True" PageSize="40" PagerStyle-Mode="NumericPages"
			PagerStyle-HorizontalAlign="Center" OnItemDataBound="grdUploadFiles_ItemDataBound"
			OnItemCommand="grdUploadFiles_ItemCommand" OnPageIndexChanged="grdUploadFiles_PageIndexChanged">
			<HeaderStyle CssClass="trHeader"></HeaderStyle>
			<ItemStyle CssClass="trOdd"></ItemStyle>
			<AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle>
			<Columns>
				<asp:TemplateColumn ItemStyle-CssClass="tdCenter">
					<HeaderTemplate>
						<asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="False"></asp:CheckBox>
					</HeaderTemplate>
					<ItemTemplate>
						<asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
					</ItemTemplate>
					<ItemStyle CssClass="tdCenter"></ItemStyle>
				</asp:TemplateColumn>
				<asp:BoundColumn DataField="Id" HeaderText="Id" Visible="False" />
				<asp:BoundColumn DataField="Active" HeaderText="Active" Visible="False" />
				<asp:BoundColumn DataField="Name" HeaderText="Tiêu đề file" />
				<asp:TemplateColumn ItemStyle-CssClass="Image">
					<HeaderTemplate>
						Hình ảnh
					</HeaderTemplate>
					<ItemTemplate>
						<script type="text/javascript">playfile('<%#Eval("ThumbnailLink").ToString() %>', "95", "80", "false", "", "", "")</script>
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:BoundColumn DataField="OriginalFileName" HeaderText="Tên file" ItemStyle-CssClass="Number"
					Visible="true" />
				<asp:TemplateColumn ItemStyle-CssClass="Active">
					<HeaderTemplate>
						Kích hoạt
					</HeaderTemplate>
					<ItemTemplate>
						<asp:Label ID="lblStatus" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowActiveStatus(Eval("Active").ToString()) %>'></asp:Label>
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn ItemStyle-CssClass="Function">
					<HeaderTemplate>
						Chức năng
					</HeaderTemplate>
					<ItemTemplate>
						<asp:ImageButton ID="cmdEdit" runat="server"
							AlternateText="Sửa" CommandName="Edit" CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png"
							CommandArgument='<%#Eval("Id")%>' /><asp:ImageButton ID="cmdDelete" runat="server"
								AlternateText="Xóa" CommandName="Delete" CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png"
								CommandArgument='<%#Eval("Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton
									ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(Eval( "Active").ToString())%>'
									CommandName="Active" CssClass="Active" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(Eval( "Active").ToString())%>'
									ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(Eval( "Active").ToString())%>'
									CommandArgument='<%#Eval("Id")%>' />
					</ItemTemplate>
				</asp:TemplateColumn>
			</Columns>
			<PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous"
				PrevPageText="Next" Mode="NumericPages"></PagerStyle>
		</asp:DataGrid>
		<div class="Control">
			<ul>
				<li>
					<asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" OnClick="AddButton_Click">Thêm mới</asp:LinkButton></li>
				<li>
					<asp:LinkButton CssClass="vrefresh" ID="lbtSynchB" runat="server" OnClick="lbtSynch_Click">Đồng bộ dữ liệu</asp:LinkButton></li>
				<li>
					<asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
				<li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở
                    lại</a> </li>
			</ul>
		</div>
	</asp:Panel>
	<asp:Panel ID="pnUpdate" runat="server" Visible="False">
		<table class="TableUpdate" border="1">
			<tr>
				<td class="Control" colspan="2">
					<ul>
						<li>
							<asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" OnClick="Update_Click">Ghi lại</asp:LinkButton></li>
						<li>
							<asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" OnClick="Back_Click"
								CausesValidation="False">Trở về</asp:LinkButton></li>
					</ul>
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblName" runat="server" Text="Tiêu đề file:"></asp:Label>
				</th>
				<td>
					<asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator
						ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*"
						SetFocusOnError="True"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblImage" runat="server" Text="Hình ảnh:"></asp:Label>
				</th>
				<td>
					<asp:TextBox ID="txtImage" runat="server" CssClass="text image"></asp:TextBox>&nbsp;<input
						id="btnImgImage" type="button" onclick="BrowseServer('<% =txtImage.ClientID %>	','Images');"
						value="Browse Server" />&nbsp;
                    <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px" />
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblActive" runat="server" Text="Kích hoạt:"></asp:Label>
				</th>
				<td>
					<asp:CheckBox ID="chkActive" runat="server" />
				</td>
			</tr>
			<tr>
				<td class="Control" colspan="2">
					<ul>
						<li>
							<asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" OnClick="Update_Click">Ghi lại</asp:LinkButton></li>
						<li>
							<asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server" OnClick="Back_Click"
								CausesValidation="False">Trở về</asp:LinkButton></li>
					</ul>
				</td>
			</tr>
		</table>
	</asp:Panel>
</asp:Content>
