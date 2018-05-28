<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_Slider.ascx.cs" Inherits="MyWeb.Controls.U_Slider" %>
<div class="box_articles">
    <div class="clear">
        <span style="margin-left: 10px; font-weight: bold;">CÔNG NGHỆ</span>
        <div class="advertise">
            <div id="scrollerDoiTac">
                <asp:Literal ID="ltrDoiTac" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    marqueeInit({
        uniqueid: 'scrollerDoiTac',
        style: {
            'padding': '0px',
            'width': '440px',
            'height': '80px'
        },
        inc: 2, //speed - pixel increment for each iteration of this marquee's movement
        mouse: 'pause', //mouseover behavior ('pause' 'cursor driven' or false)
        moveatleast: 2,
        neutral: 150,
        savedirection: true,
        random: true,
        direction: 'right'
    });
</script>
<div class="box_articles advertise-last">
    <div class="clear">
        <span style="margin-left: 10px; font-weight: bold;">SẢN PHẨM</span>
        <div class="advertise">
            <div id="scrollerKhachHang">
                <asp:Literal ID="ltrKhachHang" runat="server"></asp:Literal>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    marqueeInit({
        uniqueid: 'scrollerKhachHang',
        style: {
            'padding': '0px',
            'width': '440px',
            'height': '80px'
        },
        inc: 2, //speed - pixel increment for each iteration of this marquee's movement
        mouse: 'pause', //mouseover behavior ('pause' 'cursor driven' or false)
        moveatleast: 2,
        neutral: 150,
        savedirection: true,
        random: true,
        direction: 'right'
    });
</script>
