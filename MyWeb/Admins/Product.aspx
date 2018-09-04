<%@ Page Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="True"
	CodeBehind="Product.aspx.cs" Inherits="MyWeb.Admins.Product" %>

<%@ Import Namespace="MyWeb.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="PageName">
		QUẢN LÝ SẢN PHẨM
	</div>
	<asp:Panel ID="pnView" runat="server">
		<div style="margin-bottom: 5px">
			<asp:DropDownList ID="drlnhom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drlChuyenmuc_SelectedIndexChanged">
			</asp:DropDownList>
		</div>
		<div class="Control">
			<ul>
				<li>
					<asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" OnClick="AddButton_Click">Thêm mới</asp:LinkButton></li>
				<li>
					<asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
				<li>
					<asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
				<li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở
                    lại</a> </li>
			</ul>
		</div>
		<asp:DataGrid ID="grdProduct" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False"
			AllowPaging="True" PageSize="40" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center"
			OnItemDataBound="grdProduct_ItemDataBound" OnItemCommand="grdProduct_ItemCommand"
			OnPageIndexChanged="grdProduct_PageIndexChanged">
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
				<asp:BoundColumn DataField="Name" HeaderText="Tên sản phẩm  " ItemStyle-CssClass="MultiLine"
					Visible="true" />
				<asp:TemplateColumn ItemStyle-CssClass="Image">
					<HeaderTemplate>
						Hình ảnh 1
					</HeaderTemplate>
					<ItemTemplate>
						<script type="text/javascript">playfile('<%#Eval("Image1").ToString() %>', "95", "80", "false", "", "", "")</script>
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn ItemStyle-CssClass="Number">
					<HeaderTemplate>
						Giá
					</HeaderTemplate>
					<ItemTemplate>
						<asp:TextBox ID="txtPrice" Width="60" runat="server" Text='<%#StringClass.ConvertPrice(Eval("Price").ToString()) %>'></asp:TextBox>
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn ItemStyle-CssClass="Number">
					<HeaderTemplate>
						Kích thước
					</HeaderTemplate>
					<ItemTemplate>
						<asp:TextBox ID="txtSize" Width="60" runat="server" Text='<%#Eval("Image5").ToString() %>'></asp:TextBox>
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn ItemStyle-CssClass="Number">
					<HeaderTemplate>
						Hiển thị trang chủ
					</HeaderTemplate>
					<ItemTemplate>
						<asp:ImageButton ID="Image2" runat="server" CommandName="IsPopular" CommandArgument='<%#Eval("Id") %>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowCheckImage(DataBinder.Eval(Container.DataItem, "IsPopular"))%>' />
					</ItemTemplate>
				</asp:TemplateColumn>
				<%--<asp:TemplateColumn ItemStyle-CssClass="Number">
					<HeaderTemplate>
						Bán chạy
					</HeaderTemplate>
					<ItemTemplate>
						<asp:ImageButton ID="Image3" runat="server" CommandName="IsHot" CommandArgument='<%#Eval("Id") %>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowCheckImage(DataBinder.Eval(Container.DataItem, "IsHot"))%>' />
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn ItemStyle-CssClass="Number">
					<HeaderTemplate>
						Mới
					</HeaderTemplate>
					<ItemTemplate>
						<asp:ImageButton ID="Image4" runat="server" CommandName="IsNew" CommandArgument='<%#Eval("Id") %>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowCheckImage(DataBinder.Eval(Container.DataItem, "IsNew"))%>' />
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn ItemStyle-CssClass="Number">
					<HeaderTemplate>
						Đặc biệt
					</HeaderTemplate>
					<ItemTemplate>
						<asp:ImageButton ID="Image5" runat="server" CommandName="IsSpecial" CommandArgument='<%#Eval("Id") %>' ImageUrl='<%#MyWeb.Common.PageHelper.ShowCheckImage(DataBinder.Eval(Container.DataItem, "IsSpecial"))%>' />
					</ItemTemplate>
				</asp:TemplateColumn>--%>
				<asp:TemplateColumn ItemStyle-CssClass="Number">
					<HeaderTemplate>
						Thứ tự<asp:ImageButton ID="imgUpdateOrd" runat="server" ToolTip="Cập nhật thứ tự"
							ImageUrl="~/Images/Update.png" OnClick="imgUpdateOrd_Click" />
					</HeaderTemplate>
					<ItemTemplate>
						<asp:TextBox ID="txtOrd" runat="server" Text='<%#(Eval("Ord").ToString()) %>' Width="70px"
							Style="text-align: center" />
					</ItemTemplate>
				</asp:TemplateColumn>
				<asp:TemplateColumn ItemStyle-CssClass="Number">
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
						<asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit"
							CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#Eval("Id")%>' /><asp:ImageButton
								ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete"
								ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#Eval("Id")%>'
								OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" />
						<asp:ImageButton
								ID="cmdAddPrice" runat="server" AlternateText="Đặt giá" CommandName="AddPrice" CssClass="AddPrice"
								ToolTip="Đặt giá" ImageUrl="/App_Themes/Admin/images/icon_price.png" CommandArgument='<%#Eval("Id")%>' />
						<asp:ImageButton
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
					<asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
				<li>
					<asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
				<li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở
                    lại</a> </li>
			</ul>
		</div>
	</asp:Panel>
	<asp:Panel ID="pnUpdatePrice" runat="server" Visible="False">
		<table class="TableUpdate" border="1">
			<tr>
				<td class="Control" colspan="2">
					<ul>
						<li>
							<asp:LinkButton CssClass="uupdate" ID="LinkButton1" runat="server" OnClick="UpdatePrice_Click">Ghi lại</asp:LinkButton></li>
						<li>
							<asp:LinkButton CssClass="uback" ID="LinkButton2" runat="server" OnClick="Back_Click"
								CausesValidation="False">Trở về</asp:LinkButton></li>
					</ul>
				</td>
			</tr>
			<tr>
				<th>
					Kích thước:
				</th>
				<td>
					<asp:TextBox ID="txtKichThuoc01" runat="server"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<th>
					Giá:
				</th>
				<td>
					<asp:TextBox ID="txtPrice01" runat="server"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="Control" colspan="2">
					<ul>
						<li>
							<asp:LinkButton CssClass="uupdate" ID="LinkButton3" runat="server" OnClick="UpdatePrice_Click">Ghi lại</asp:LinkButton></li>
						<li>
							<asp:LinkButton CssClass="uback" ID="LinkButton4" runat="server" OnClick="Back_Click"
								CausesValidation="False">Trở về</asp:LinkButton></li>
					</ul>
				</td>
			</tr>
		</table>
	</asp:Panel>
	<asp:Panel ID="pnUpdate" runat="server" Visible="False">
		<table class="TableUpdate" border="1">
			<tr>
				<td class="Control" colspan="2">
					<ul>
						<li>
							<asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" OnClick="Update_Click">Ghi lại</asp:LinkButton></li>
						<li>
							<asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" OnClick="Back_Click" CausesValidation="False">Trở về</asp:LinkButton></li>
					</ul>
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblGroupProduct" runat="server" Text="Tên nhóm sản phẩm:"></asp:Label>
				</th>
				<td>
					<asp:DropDownList ID="ddlGroupProduct" runat="server"></asp:DropDownList><asp:RequiredFieldValidator
						ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlGroupProduct" Display="Dynamic" ErrorMessage="*"
						SetFocusOnError="True"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblName" runat="server" Text="Tên sản phẩm  :"></asp:Label>
				</th>
				<td>
					<asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator
						ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*"
						SetFocusOnError="True"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblImage1" runat="server" Text="Hình ảnh:"></asp:Label><span style="color: Red; font-size: 11px;"> (153x107)</span>
				</th>
				<td>
					<asp:TextBox ID="txtImage1" runat="server" CssClass="text image"></asp:TextBox>&nbsp;<input
						id="btnImgImage1" type="button" onclick="BrowseServer('<% =txtImage1.ClientID %>','Images');"
						value="Browse Server" />&nbsp;
                    <asp:Image ID="imgImage1" runat="server" ImageAlign="Middle" Width="100px" />
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblContent" runat="server" Text="Mã hàng:"></asp:Label>
				</th>
				<td>
					<asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" CssClass="text multiline"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblDetail" runat="server" Text="Nội dung:"></asp:Label>
				</th>
				<td>
					<FCKeditorV2:FCKeditor ID="fckDetail" runat="server" />
				</td>
			</tr>
			<tr>
				<th>
					Kích thước:
				</th>
				<td>
					<asp:TextBox ID="txtKichThuoc" runat="server" Width="99%"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblPrice" runat="server" Text="Giá:"></asp:Label>
				</th>
				<td>
					<asp:TextBox ID="txtPricePro" runat="server" Width="99%"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblPopular" runat="server" Text="Hiển thị trang chủ:"></asp:Label>
				</th>
				<td>
					<asp:CheckBox ID="chkPopular" runat="server" />
				</td>
			</tr>
			<%--<tr>
				<th>
					<asp:Label ID="lblHot" runat="server" Text="Sản phẩm bán chạy:"></asp:Label>
				</th>
				<td>
					<asp:CheckBox ID="chkHot" runat="server" />
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblNew" runat="server" Text="Sản phẩm mới:"></asp:Label>
				</th>
				<td>
					<asp:CheckBox ID="chkNew" runat="server" />
				</td>
			</tr>
			<tr>
				<th>
					<asp:Label ID="lblSpecial" runat="server" Text="Sản phẩm đặc biệt:"></asp:Label>
				</th>
				<td>
					<asp:CheckBox ID="chkSpecial" runat="server" />
				</td>
			</tr>--%>
			<tr>
				<th>
					<asp:Label ID="lblOrd" runat="server" Text="Thứ tự:"></asp:Label>
				</th>
				<td>
					<asp:TextBox ID="txtOrd" runat="server" CssClass="text number" /><asp:RequiredFieldValidator
						ID="rfvOrd" runat="server" ControlToValidate="txtOrd" Display="Dynamic" ErrorMessage="*"
						SetFocusOnError="True"></asp:RequiredFieldValidator>
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
