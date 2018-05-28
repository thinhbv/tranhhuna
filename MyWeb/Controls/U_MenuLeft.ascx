<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_MenuLeft.ascx.cs" Inherits="MyWeb.Controls.U_MenuLeft" %>
<section id="layered_block_left" class="block">
    <h4 class="title_block">DANH MỤC SẢN PHẨM</h4>
    <div class="block_content">
        <form action="#" id="layered_form">
            <div>
                <asp:Literal ID="ltrmenu" runat="server"></asp:Literal>
            </div>
        </form>
    </div>
    <div id="layered_ajax_loader" style="display: none;">
        <p id="layered_block_loader">
            <span></span>
        </p>
    </div>
</section>
