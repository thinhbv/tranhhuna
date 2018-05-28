<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Advertise.aspx.cs" Inherits="MyWeb.Admins.Advertise" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.3" Namespace="DevExpress.Web.ASPxEditors"
    TagPrefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="PageName">
        QUẢN LÝ QUẢNG CÁO</div>
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
        <asp:DataGrid ID="grdAdvertise" runat="server" Width="100%" CssClass="TableView"
            AutoGenerateColumns="False" AllowPaging="True" PageSize="30" PagerStyle-Mode="NumericPages"
            PagerStyle-HorizontalAlign="Center" OnItemDataBound="grdAdvertise_ItemDataBound"
            OnItemCommand="grdAdvertise_ItemCommand" OnPageIndexChanged="grdAdvertise_PageIndexChanged">
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
                <asp:BoundColumn DataField="Name" HeaderText="Tên quảng cáo" ItemStyle-CssClass="Text"
                    Visible="true" />
                <asp:TemplateColumn ItemStyle-CssClass="Image">
                    <HeaderTemplate>
                        Hình ảnh</HeaderTemplate>
                    <ItemTemplate>
                        <script type="text/javascript"> playfile('<%#DataBinder.Eval(Container.DataItem, "Image").ToString() %>', "95", "80", "false", "", "", "")</script>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Width" HeaderText="Độ rộng" ItemStyle-CssClass="Center"
                    Visible="true" />
                <asp:BoundColumn DataField="Height" HeaderText="Chiều cao" ItemStyle-CssClass="Center"
                    Visible="true" />
                <asp:BoundColumn DataField="Link" HeaderText="Liên kết" ItemStyle-CssClass="Text"
                    Visible="true" />
                <asp:BoundColumn DataField="Target" HeaderText="Kiểu liên kết" ItemStyle-CssClass="Center"
                    Visible="true" ItemStyle-Width="120px" />
                <asp:TemplateColumn ItemStyle-CssClass="CheckBox">
                    <HeaderTemplate>
                        Vị trí</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPosition" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowAdvertisePosition(DataBinder.Eval(Container.DataItem, "Position").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Ord" HeaderText="Thứ tự" ItemStyle-CssClass="Number"
                    Visible="true" />
                <asp:TemplateColumn ItemStyle-CssClass="Center" ItemStyle-Width="120px">
                    <HeaderTemplate>
                        Kích hoạt</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowActiveStatus(DataBinder.Eval(Container.DataItem, "Active").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="Function" ItemStyle-Width="150px">
                    <HeaderTemplate>
                        Chức năng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Sửa" CommandName="Edit"
                            CssClass="Edit" ToolTip="Sửa" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /><asp:ImageButton
                                ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete" CssClass="Delete"
                                ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>'
                                OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /><asp:ImageButton
                                    ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                                    CommandName="Active" CssClass="Active" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                                    ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Active").ToString())%>'
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' /></ItemTemplate>
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
                    <asp:Label ID="lblName" runat="server" Text="Tên quảng cáo:"></asp:Label>
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
                        id="btnImgImage" type="button" onclick="BrowseServer('<% =txtImage.ClientID %>','Advertise');"
                        value="Browse Server" />&nbsp;
                    <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="color:Red; font-size:11px;">Ảnh banner giữa (916x354) - Ảnh Công nghệ và Sản phẩm (106x66) - Ảnh quảng cáo hai bên (164x483)</span>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblWidth" runat="server" Text="Độ rộng:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtWidth" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblHeight" runat="server" Text="Chiều cao:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtHeight" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblLink" runat="server" Text="Liên kết:"></asp:Label>
                </th>
                <td>
                    <asp:TextBox ID="txtLink" runat="server" CssClass="text"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    <asp:Label ID="lblTarget" runat="server" Text="Kiểu liên kết:"></asp:Label>
                </th>
                <td>
                    <asp:DropDownList ID="ddlTarget" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <%--<tr>
                <th>
                    <asp:Label ID="lblContent" runat="server" Text="Nội dung:"></asp:Label>
                </th>
                <td>
                    <FCKeditorV2:FCKeditor ID="fckContent" runat="server" />
                </td>
            </tr>--%>
            <tr>
                <th>
                    <asp:Label ID="lblPosition" runat="server" Text="Vị trí:"></asp:Label>
                </th>
                <td>
                    <asp:DropDownList ID="ddlPosition" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
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
