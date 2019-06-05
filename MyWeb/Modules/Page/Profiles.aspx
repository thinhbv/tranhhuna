<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="Profiles.aspx.cs" Inherits="MyWeb.Modules.Page.Profiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {

			if (window.location.href.indexOf("#doi-mat-khau") > -1) {
				$(".tab-bar li").removeClass("active");
				$(".tab-content div").removeClass("active");
				$("#tab02").addClass("active");
				$("#changpass").addClass("active");
			}
		})
	</script>
	<style type="text/css">
		.panel.panel-default {
			border-color: #f1f5fc;
		}

			.panel.panel-default .panel-heading + .panel-collapse .panel-body {
				border-top-color: #f1f5fc;
			}

			.panel.panel-default .panel-heading {
				background: #fff;
				color: #ff662c;
				font-weight: bold;
				font-size: 14px;
				border-color: #f1f5fc;
			}

			.panel.panel-default .panel-title a {
				font-size: 12px;
			}

				.panel.panel-default .panel-title a:focus, .panel.panel-default .panel-title a:hover {
					text-decoration: none;
					color: #aaa;
				}

		.tab-left:after, .tab-left:before {
			display: table;
			line-height: 0;
			content: "";
		}

		.tab-left:after {
			clear: both;
		}

		.tab-left .tab-bar {
			float: left;
		}

			.tab-left .tab-bar > li {
				display: block;
				float: none;
				margin-right: -1px;
				border-right: 1px solid #eee;
			}

				.tab-left .tab-bar > li.active {
					border-right: 1px solid #fff;
					z-index: 2;
				}

					.tab-left .tab-bar > li.active:first-child a {
						border-top: none;
					}

					.tab-left .tab-bar > li.active a {
						border-top: 1px solid #eee;
						border-bottom: 1px solid #eee;
					}

		.tab-left .tab-content {
			overflow: auto;
			padding: 15px 20px;
			border-left: 1px solid #eee;
		}

		.tab-bar > li {
			display: inline-block;
			float: left;
			margin-bottom: -1px;
		}

			.tab-bar > li.active:first-child a {
				border-left: none;
			}

			.tab-bar > li.active a {
				background: #fff;
				color: #777;
			}

			.tab-bar > li a {
				display: block;
				padding: 10px;
				color: #ccc;
				text-shadow: 0 1px #fff;
				transition: color .2s ease;
				-webkit-transition: color .2s ease;
				-moz-transition: color .2s ease;
				-ms-transition: color .2s ease;
				-o-transition: color .2s ease;
			}

				.tab-bar > li a:focus, .tab-bar > li a:hover {
					text-decoration: none;
					color: #777;
					transition: color .2s ease;
					-webkit-transition: color .2s ease;
					-moz-transition: color .2s ease;
					-ms-transition: color .2s ease;
					-o-transition: color .2s ease;
				}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div id="columns" class="container">
		<!-- Breadcrumb -->
		<div class="breadcrumb clearfix">
			<ul>
				<li class="home">
					<a class="home" href="/" title="Return to Home">
						<i class="fa fa-home"></i>
					</a>
				</li>
				<li class="crumb-1 last">Thông tin của bạn
				</li>
			</ul>
		</div>
		<!-- /Breadcrumb -->
		<div class="row">
			<div class="large-left col-sm-12">
				<div class="row">
					<div id="left_column" class="column col-xs-12 col-sm-12">
						<div class="panel panel-default">
							<div class="panel-body no-padding">
								<div class="tab-left">
									<ul class="tab-bar">
										<li id="tab01" class="active"><a href="#info" data-toggle="tab"><i class="fa fa-info-circle"></i> Thông tin nhân</a></li>
										<li id="tab02"><a href="#changpass" data-toggle="tab"><i class="fa fa-key"></i> Đổi mật khẩu</a></li>
										<li><asp:LinkButton ID="lbtLogout" runat="server" tabindex="-1" CssClass="main-link logoutConfirm_open" OnClick="lbtLogout_Click"><i class="fa fa-sign-out"></i> Đăng xuất</asp:LinkButton></li>
									</ul>
									<div class="tab-content">
										<div class="tab-pane fade in active" id="info">
											<form class="form-login">
												<div class="form-group">
													<label>Họ và tên</label>
													<input type="text" id="txtFullName" runat="server" placeholder="Email address" class="form-control input-sm bounceIn animation-delay2">
												</div>
												<!-- /form-group -->
												<div class="form-group">
													<label>Mật khẩu</label>
													<input type="password" id="txtPass" runat="server" placeholder="●●●●●●●●" class="form-control input-sm bounceIn animation-delay3" readonly="readonly">
												</div>
												<!-- /form-group -->
												<div class="form-group">
													<label>Email</label>
													<input type="text" id="txtEmail" runat="server" placeholder="Email" class="form-control input-sm bounceIn animation-delay4" readonly="readonly">
												</div>
												<!-- /form-group -->
												<div class="form-group">
													<label>Điện thoại</label>
													<input type="text" id="txtPhone" runat="server" placeholder="Phone" class="form-control input-sm bounceIn animation-delay4">
												</div>
												<!-- /form-group -->
												<div class="form-group">
													<div class="controls text-right">
														<asp:LinkButton ID="lbtSave" runat="server" CssClass="btn btn-success btn-sm bounceIn animation-delay7 login-link" OnClick="lbtSave_Click"><i class="fa fa-floppy-o"></i> Cập nhật thông tin</asp:LinkButton>
													</div>
												</div>
												<!-- /form-group -->
											</form>
										</div>
										<div class="tab-pane fade in" id="changpass">
											<div class="form-group">
													<label>Mật khẩu cũ</label>
													<input type="password" id="txtOldPassword" runat="server" placeholder="Password" class="form-control input-sm bounceIn animation-delay3">
												</div>
											<div class="form-group">
													<label>Mật khẩu mới</label>
													<input type="password" id="txtNewPassword" runat="server" placeholder="New Password" class="form-control input-sm bounceIn animation-delay3">
												</div>
												<!-- /form-group -->
												<div class="form-group">
													<label>Nhập lại mật khẩu mới</label>
													<input type="password" id="txtConfirmNewPassword" runat="server" placeholder="Confirm New Password" class="form-control input-sm bounceIn animation-delay4">
												</div>
												<!-- /form-group -->
											<div class="form-group">
													<div class="controls text-right">
														<asp:LinkButton ID="lbtSavePass" runat="server" CssClass="btn btn-success btn-sm bounceIn animation-delay7 login-link" OnClick="lbtSavePass_Click"><i class="fa fa-floppy-o"></i> Cập nhật mật khẩu</asp:LinkButton>
													</div>
												</div>
												<!-- /form-group -->
										</div>
									</div>
								</div>
							</div>
						</div>
						<!-- /panel -->
					</div>
					<!--#left_column-->
				</div>
				<!--.row-->
			</div>
			<!--.large-left-->
		</div>
		<!--.row-->
	</div>
	<!-- #columns -->
</asp:Content>
