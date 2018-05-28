<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true" EnableEventValidation="false"
	CodeBehind="Contact.aspx.cs" Inherits="MyWeb.Modules.Page.Contact" %>

<%@ Register Src="../../Controls/U_MenuLeft.ascx" TagName="U_MenuLeft" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script type="text/javascript">
		jQuery(document).ready(function () {
			jQuery('#tm_submit_search').click(function () {
				jQuery('#<%= txtTitle.ClientID %>').val("");
				jQuery('#<%= txtHoTen.ClientID %>').val("");
				jQuery('#<%= txtEmail.ClientID %>').val("");
				jQuery('#<%= txtPhone.ClientID %>').val("");
				jQuery('#<%= txtAddress.ClientID %>').val("");
				jQuery('#<%= txtDetail.ClientID %>').val("");
				return false;
			});
			jQuery('#tm_submit').click(function () {
				if (jQuery('#<%= txtTitle.ClientID %>').val().trim() == "") {
        			alert("Vui lòng nhập tiêu đề của bạn!");
        			jQuery('#<%= txtTitle.ClientID %>').focus()
            		return false
				}

        		if (jQuery('#<%= txtHoTen.ClientID %>').val().trim() == "") {
        			alert("Vui lòng nhập họ tên của bạn!");
        			jQuery('#<%= txtHoTen.ClientID %>').focus()
            		return false
				}
        		if (jQuery('#<%= txtEmail.ClientID %>').val().trim() == "") {
        			alert("Vui lòng nhập email của bạn!");
        			jQuery('#<%= txtEmail.ClientID %>').focus()
            		return false
				}
        		if (jQuery('#<%= txtDetail.ClientID %>').val().trim() == "") {
        			alert("Vui lòng nhập nội dung!");
        			jQuery('#<%= txtDetail.ClientID %>').focus()
            		return false
				}
        		return true;
        	});
		});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<form id="frmContact" runat="server">
		<div id="columns" class="container">
			<!-- Breadcrumb -->
			<div class="breadcrumb clearfix">
				<ul>
					<li class="home">
						<a class="home" href="/" title="Return to Home">
							<i class="fa fa-home"></i>
						</a>
					</li>
					<li class="crumb-1 last">Liên hệ
					</li>
				</ul>
			</div>
			<!-- /Breadcrumb -->
			<div class="row">
				<div class="large-left col-sm-12">
					<div class="row">
						<div id="center_column" class="center_column col-xs-12 col-sm-9">
							<div itemtype="#" itemscope="" id="sdsblogArticle" class="blog-post">
								<h1 class="title_block_exclusive">Liên hệ với chúng tôi</h1>
								<div class="sdsarticle-des">
									<div style="border-bottom: 1px solid #d58134; padding-bottom: 10px">
										<div style="margin-bottom: 10px">
											<asp:Literal ID="ltrContact" runat="server"></asp:Literal>
										</div>
									</div>
									<br />
									<table class="form-contact" cellpadding="0" cellspacing="0">
										<tr>
											<th>Tiêu đề (*):
											</th>
											<td>
												<asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td style="height: 10px" colspan="2"></td>
										</tr>
										<tr>
											<th>Họ tên (*):
											</th>
											<td>
												<asp:TextBox ID="txtHoTen" runat="server"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td style="height: 10px" colspan="2"></td>
										</tr>
										<tr>
											<th>Email (*):
											</th>
											<td>
												<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td style="height: 10px" colspan="2"></td>
										</tr>
										<tr>
											<th>Điện thoại:
											</th>
											<td>
												<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td style="height: 10px" colspan="2"></td>
										</tr>
										<tr>
											<th>Địa chỉ:
											</th>
											<td>
												<asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td style="height: 10px" colspan="2"></td>
										</tr>
										<tr>
											<th>Nội dung (*):
											</th>
											<td>
												<asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<th></th>
											<td>
												<i>(Lưu ý: * chỉ định những thông tin bắt buộc)</i>
											</td>
										</tr>
									</table>
									<div class="button-contact">
										<asp:Button ID="btnSend" runat="server" Text="SEND" OnClick="btnSend_Click" CssClass="btn btn-default button-search" />
										<button  type="button" id="tm_submit_search" class="btn btn-default button-search"><span>CLEAR</span></button>
									</div>
								</div>
								<!--sdsarticle-des-->
							</div>
							<!--blog-post-->
						</div>
						<!-- #center_column -->
						<div id="left_column" class="column col-xs-12 col-sm-3">
							<uc1:U_MenuLeft ID="U_MenuLeft1" runat="server" />
						</div>
					</div>
					<!--.row-->
				</div>
				<!--.large-left-->
			</div>
			<!--.row-->
		</div>
		<!-- #columns -->
	</form>
</asp:Content>
