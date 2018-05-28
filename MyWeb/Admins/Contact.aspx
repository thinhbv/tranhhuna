<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Contact.aspx.cs" Inherits="MyWeb.Admins.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="PageName">
        QUẢN LÝ LIÊN HỆ , PHẢN HỒI</div>
    <asp:Panel ID="pnView" runat="server">
        <div class="Control">
            <ul>
                <li>
                    <asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
                <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở
                    lại</a> </li>
            </ul>
        </div>
        <asp:DataGrid ID="grdContact" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False"
            AllowPaging="True" PageSize="30" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center"
            OnItemDataBound="grdContact_ItemDataBound" OnItemCommand="grdContact_ItemCommand"
            OnPageIndexChanged="grdContact_PageIndexChanged">
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
                <asp:BoundColumn DataField="Name" HeaderText="Tên khách hàng" ItemStyle-CssClass="TextShort" Visible="true" />
                <asp:BoundColumn DataField="Company" HeaderText="Địa chỉ" ItemStyle-CssClass="Text" Visible="true" />
                <asp:BoundColumn DataField="Email" HeaderText="Email" ItemStyle-CssClass="TextShort" Visible="true" />
                <asp:BoundColumn DataField="Phone" HeaderText="Điện thoại" ItemStyle-CssClass="TextShort" Visible="true" />
                <asp:BoundColumn DataField="Detail" HeaderText="Nội dung" ItemStyle-CssClass="Text" Visible="true" />
                <asp:TemplateColumn ItemStyle-CssClass="CheckBoxsmall">
                    <HeaderTemplate>
                        Ngày liên hệ</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# MyWeb.Common.DateTimeClass.ConvertDate(DataBinder.Eval(Container.DataItem, "Date").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-CssClass="Function">
                    <HeaderTemplate>
                        Chức năng</HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Xóa" CommandName="Delete"
                            CssClass="Delete" ToolTip="Xóa" ImageUrl="/App_Themes/Admin/images/delete.png"
                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"Id")%>' OnClientClick="javascript:return confirm('Bạn có muốn xóa?');" /></ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="Paging" Position="Bottom" NextPageText="Previous"
                PrevPageText="Next" Mode="NumericPages"></PagerStyle>
        </asp:DataGrid>
        <div class="Control">
            <ul>
                <li>
                    <asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" OnClick="DeleteButton_Click">Xóa</asp:LinkButton></li>
                <li>
                    <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" OnClick="RefreshButton_Click">Làm mới</asp:LinkButton></li>
                <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở
                    lại</a> </li>
            </ul>
        </div>
    </asp:Panel>
</asp:Content>
