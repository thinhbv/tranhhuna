<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true"
    CodeBehind="Config.aspx.cs" Inherits="MyWeb.Admins.Config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="PageName">
        QUẢN LÝ CẤU HÌNH</div>
    <table class="TableUpdate" border="1">
        <tr>
            <td class="Control" colspan="2">
                <ul>
                    <li>
                        <asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" OnClick="Update_Click">Ghi lại</asp:LinkButton></li>
                    <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở
                        lại</a></li>
                </ul>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblMail_Smtp" runat="server" Text="Máy chủ gửi mail:"></asp:Label>
            </th>
            <td>
                <asp:TextBox ID="txtMail_Smtp" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblMail_Port" runat="server" Text="Cổng gửi mail:"></asp:Label>
            </th>
            <td>
                <asp:TextBox ID="txtMail_Port" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblMail_Info" runat="server" Text="Mail nhận liên hệ:"></asp:Label>
            </th>
            <td>
                <asp:TextBox ID="txtMail_Info" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblMail_Noreply" runat="server" Text="Mail gửi thông tin:"></asp:Label>
            </th>
            <td>
                <asp:TextBox ID="txtMail_Noreply" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblMail_Password" runat="server" Text="Mật khẩu mail gửi:"></asp:Label>
            </th>
            <td>
                <asp:TextBox ID="txtMail_Password" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblContent" runat="server" Text="Nội dung:"></asp:Label>
            </th>
            <td>
                <FCKeditorV2:FCKeditor ID="fckContent" runat="server" />
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblCopyright" runat="server" Text="Copyright:"></asp:Label>
            </th>
            <td>
                <FCKeditorV2:FCKeditor ID="fckCopyright" runat="server" />
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblTitle" runat="server" Text="Title Meta:"></asp:Label>
            </th>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblDescription" runat="server" Text="Description Meta:"></asp:Label>
            </th>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th>
                <asp:Label ID="lblKeyword" runat="server" Text="Keyword Meta:"></asp:Label>
            </th>
            <td>
                <asp:TextBox ID="txtKeyword" runat="server" CssClass="text multiline" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="Control" colspan="2">
                <ul>
                    <li>
                        <asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" OnClick="Update_Click">Ghi lại</asp:LinkButton></li><li>
                            <a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Trở lại</a></li>
                </ul>
            </td>
        </tr>
    </table>
</asp:Content>
