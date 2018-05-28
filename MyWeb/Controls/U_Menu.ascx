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
		<%--<li class="active">
			<a href="./">Home</a>
		</li>
		<li>
			<a href="index-1.html">About us</a>
		</li>
		<li>
			<a href="index-2.html">Products</a>
		</li>
		<li class="dropdown">
			<a href="index-3.html">Recipe Corner</a>

			<ul class="dropdown-menu">
				<li>
					<a href="#">Levain Walnut Baguette</a>
				</li>
				<li>
					<a href="#">Pizza Round</a>
				</li>
				<li>
					<a href="#">Sourdough Bragel</a>

					<ul class="dropdown-menu">
						<li>
							<a href="#">Description</a>
						</li>
						<li>
							<a href="#">Ingredients</a>
						</li>
						<li>
							<a href="#">Details</a>
						</li>
					</ul>
				</li>
				<li>
					<a href="#">Cranberry Orange Scone</a>
				</li>
				<li>
					<a href="#">Cinnamon Rolls</a>
				</li>
			</ul>
		</li>

		<li>
			<a href="index-4.html">News & Events</a>
		</li>

		<li>
			<a href="index-5.html">Contact Us</a>
		</li>--%>
	</ul>
</nav>
<!--navbar-default-->
<div class="sform">
	<a class="search-form_toggle" href="#"></a>
</div>
<!--sform-->

<div class="search-form">
	<form id="search" action="search.php" method="GET" accept-charset="utf-8">
		<label class="search-form_label" for="in">
			<input id="in" class="search-form_input" type="text" name="s"
				placeholder="Type your search term here..." />
			<span class="search-form_liveout"></span>
		</label>
		<button type="submit" class="search-form_submit fa-search"></button>
	</form>
</div>
<!--search-form-->
