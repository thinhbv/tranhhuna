<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="U_Menu.ascx.cs" Inherits="MyWeb.Controls.U_Menu" %>
<script type="text/javascript">
	$(document).ready(function () {
		var key = '<%=keyword%>';
		$("#tm_submit_search").click(function () {
			key = $("#tm_search_query").val();
			window.location.href = "/san-pham?key=" + encodeURIComponent(key);
		})
		if (key !== '') {
			$("#tm_search_query").val(key);
		}
	})
	function PressEnter(e) {
		if (e.keyCode == 13) {
			var key = $("#tm_search_query").val();
			window.location.href = "/san-pham?key=" + encodeURIComponent(key);
		}
		return false;
	}
</script>
<nav class="navbar navbar-default navbar-static-top ">
	<ul class="navbar-nav sf-menu navbar-left" data-type="navbar">
		<asp:Repeater ID="rptParent" runat="server" OnItemDataBound="rptParent_ItemDataBound">
			<ItemTemplate>
				<li id="liparent" runat="server">
					<a href="<%# Eval("Link").ToString() %>"><%#Eval("Name").ToString() %></a>
					<ul id="ulSub" runat="server" class="dropdown-menu" visible="false">
						<asp:Repeater ID="rptSub" runat="server" OnItemDataBound="rptSub_ItemDataBound">
							<ItemTemplate>
								<li><a href="<%#Eval("Link").ToString() %>"><%#Eval("Name").ToString() %></a>
									<ul id="ulLevel3" runat="server" class="dropdown-menu" visible="false">
										<asp:Repeater ID="rptLevel3" runat="server">
											<ItemTemplate>
												<li><a href="<%#Eval("Link").ToString() %>"><%#Eval("Name").ToString() %></a></li>
											</ItemTemplate>
										</asp:Repeater>
									</ul>
								</li>
							</ItemTemplate>
						</asp:Repeater>
					</ul>
				</li>
			</ItemTemplate>
		</asp:Repeater>

	</ul>
	<%if (Session["FullName"] == null)
   {%>
	<div class="form-login"><a href="/thanh-vien/dang-nhap" title="Đăng nhập">Đăng nhập</a> / <a href="/thanh-vien/dang-ki" title="Đăng nhập">Đăng kí</a></div>
	<%}
   else
   {%>
	<div class="form-login">
		<div class="profile dropdown">
			<a class="dropdown-toggle" data-toggle="dropdown" href="#">
				Xin chào <strong><% =Session["FullName"] %></strong>
				<span><i class="fa fa-chevron-down"></i></span>
			</a>
			<ul class="dropdown-menu">
				<li>
					<a class="clearfix" href="#">
						<div class="detail">
							<strong><% =Session["FullName"] %></strong>
							<p class="grey"><% =Session["Email"] %></p>
						</div>
					</a>
				</li>
				<li><a tabindex="-1" href="profile.html" class="main-link"><i class="fa fa-edit fa-lg"></i> Thông tin cá nhân</a></li>
				<li><a tabindex="-1" href="gallery.html" class="main-link"><i class="fa fa-picture-o fa-lg"></i> Lịch sử tải xuống</a></li>
				<li class="divider"></li>
				<li><asp:LinkButton ID="lbtLogout" runat="server" tabindex="-1" CssClass="main-link logoutConfirm_open" OnClick="lbtLogout_Click"><i class="fa fa-lock fa-lg"></i> Đăng xuất</asp:LinkButton></li>
			</ul>
		</div>
	</div>
	<%} %>
</nav>
<!--navbar-default-->
<div class="sform">
	<a class="search-form_toggle" href="#"></a>
</div>
<!--sform-->

<div class="search-form">
	<label class="search-form_label" for="in">
		<input id="tm_search_query" class="search-form_input" type="text" name="s"
			placeholder="Nhập keyword của bạn ở đây..." />
		<span class="search-form_liveout"></span>
	</label>
	<button type="button" id="tm_submit_search" class="search-form_submit fa-search"></button>
</div>
<!--search-form-->
