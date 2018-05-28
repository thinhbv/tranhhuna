<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="User.aspx.cs" Inherits="MyWeb.Admins.User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="PageName">
        QUẢN LÝ NGƯỜI DÙNG</div>
    <asp:UpdatePanel ID="updatePage" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnView" runat="server">
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
                <asp:DataGrid ID="grdUser" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False"
                    AllowPaging="True" PageSize="30" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center"
                    OnItemDataBound="grdUser_ItemDataBound" OnItemCommand="grdUser_ItemCommand" OnPageIndexChanged="grdUser_PageIndexChanged">
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
                        <asp:BoundColumn DataField="Name" HeaderText="Tên quản trị" ItemStyle-CssClass="Text"
                            Visible="true" />
                        <asp:BoundColumn DataField="Username" HeaderText="Tên đăng nhập" ItemStyle-CssClass="Text"
                            Visible="true" />
                        <asp:BoundColumn DataField="Password" HeaderText="Mật khẩu" ItemStyle-CssClass="Text"
                            Visible="true" />
                        <asp:BoundColumn DataField="Email" HeaderText="Email" ItemStyle-CssClass="Text" Visible="true" />
                        <asp:BoundColumn DataField="Phone" HeaderText="Phone" ItemStyle-CssClass="Text" Visible="true" />
                        <asp:TemplateColumn ItemStyle-CssClass="CheckBox">
                            <HeaderTemplate>
                                Phân quyền</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%#MyWeb.Common.PageHelper.ShowCheckImage(DataBinder.Eval(Container.DataItem, "Admin").ToString())%>' /></ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-CssClass="Function">
                            <HeaderTemplate>
                                Chức năng</HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit"
                                    CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton
                                        ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete"
                                        ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'
                                        OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /></ItemTemplate>
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
                            <asp:Label ID="lblName" runat="server" Text="Tên quản trị:"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox><asp:RequiredFieldValidator
                                ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*"
                                SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="lblUsername" runat="server" Text="Tên đăng nhập:"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="text"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="lblPassword" runat="server" Text="Mật khẩu:"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="text"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="lblemail" runat="server" Text="Email:"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="text"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="Phone" runat="server" Text="Số phone:"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="text"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label ID="lblAdmin" runat="server" Text="Phân quyền:"></asp:Label>
                        </th>
                        <td>
                            <asp:CheckBox ID="chkAdmin" runat="server" />
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
