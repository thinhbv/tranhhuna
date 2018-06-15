<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="MyWeb.Admins.Orders" %>

<%@ Import Namespace="MyWeb.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="PageName">
		QUẢN LÝ ĐƠN HÀNG
	</div>
	<asp:UpdatePanel ID="updatePage" runat="server">
		<ContentTemplate>
			<asp:Panel ID="pnView" runat="server">
				<div style="margin-bottom: 5px">
					<asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">
					</asp:DropDownList>
				</div>
				<div class="Control">
					<ul>
						<%--<li>
							<asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" OnClick="Update_Click">Cập nhật</asp:LinkButton></li>--%>
						<li>
							<asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
						<li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở
                            lại</a> </li>
					</ul>
				</div>
				<asp:DataGrid ID="grdGroupNews" runat="server" Width="100%" CssClass="TableView"
					AutoGenerateColumns="False" AllowPaging="True" PageSize="40" PagerStyle-Mode="NumericPages"
					PagerStyle-HorizontalAlign="Center" OnItemDataBound="grdGroupNews_ItemDataBound"
					OnItemCommand="grdGroupNews_ItemCommand" OnPageIndexChanged="grdGroupNews_PageIndexChanged">
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
						<asp:BoundColumn DataField="Name" HeaderText="Tên khách hàng" />
						<asp:BoundColumn DataField="Tel" HeaderText="Điện thoại" />
						<asp:BoundColumn DataField="Price" HeaderText="Tổng tiền" />
						<asp:BoundColumn DataField="PaymentMethod" HeaderText="Phương thức thanh toán" />
						<asp:TemplateColumn ItemStyle-CssClass="Center">
							<HeaderTemplate>
								Trạng thái
							</HeaderTemplate>
							<ItemTemplate>
								<asp:Label ID="lblStatus" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowAdvertiseStatusCart(Eval("Status").ToString()) %>'></asp:Label>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn ItemStyle-CssClass="Function">
							<HeaderTemplate>
								Chức năng
							</HeaderTemplate>
							<ItemTemplate>
								<asp:ImageButton
									ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit" CssClass="Edit"
									ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' />
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous"
						PrevPageText="Next" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
				<div class="Control">
					<ul>
						<%--<li>
							<asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" OnClick="Update_Click">Cập nhật</asp:LinkButton></li>--%>
						<li>
							<asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
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
						<th>Tên khách hàng
						</th>
						<td>
							<asp:Label ID="lblName" runat="server"></asp:Label>
						</td>
					</tr>
					<tr>
						<th>Điện thoại:
						</th>
						<td>
							<asp:Label ID="lblTel" runat="server"></asp:Label>
						</td>
					</tr>
					<tr>
						<th>Email:
						</th>
						<td>
							<asp:Label ID="lblEmail" runat="server"></asp:Label>
						</td>
					</tr>
					<tr>
						<th>Địa chỉ:
						</th>
						<td>
							<asp:Label ID="lblAddress" runat="server"></asp:Label>
						</td>
					</tr>
					<tr>
						<th>Nội dung:
						</th>
						<td>
							<asp:Label ID="lblDetail" runat="server"></asp:Label>
						</td>
					</tr>
					<tr>
						<th>Trạng thái:
						</th>
						<td>
							<asp:DropDownList ID="drlStatus" runat="server"></asp:DropDownList>
						</td>
					</tr>
					<tr>
						<th>Ngày giao hàng:
						</th>
						<td>
							<asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
							<asp:MaskedEditExtender
								ID="meeDate" runat="server" Mask="99/99/9999 99:99:99" MaskType="DateTime" OnFocusCssClass="MaskedEditFocus"
								OnInvalidCssClass="MaskedEditError" TargetControlID="txtDate" AcceptAMPM="True"
								Century="2000" />
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
		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger ControlID="lbtUpdateT" />
		</Triggers>
		<Triggers>
			<asp:PostBackTrigger ControlID="lbtUpdateB" />
		</Triggers>
	</asp:UpdatePanel>
</asp:Content>
