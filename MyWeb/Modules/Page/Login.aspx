<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyWeb.Modules.Page.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<meta name="google-signin-scope" content="profile email">
	<meta name="google-signin-client_id" content="611511258170-in5k2tdgb89bfa2ja9sp8mdu4imsum7k.apps.googleusercontent.com">
	<script src="https://apis.google.com/js/api:client.js"></script>
	<script language="javascript" type="text/javascript">
		function LoginCompleted() {
			FB.api('/me', { fields: 'id, name, email' }, function (response) {
				if (response.error) {
					return false;
				}
				$.ajax({
					type: 'POST',
					url: '/checklogin.aspx?id=' + response.id + '&name=' + response.name + '&email=' + response.email,
					// Always include an `X-Requested-With` header in every AJAX request,
					// to protect against CSRF attacks.
					headers: {
						'X-Requested-With': 'XMLHttpRequest'
					},
					contentType: 'application/octet-stream; charset=utf-8',
					success: function (result) {
						window.location.href = "/";
					},
					processData: false
				});
			});
		}
		var googleUser = {};
		var startApp = function () {
			gapi.load('auth2', function () {
				// Retrieve the singleton for the GoogleAuth library and set up the client.
				auth2 = gapi.auth2.init({
					client_id: '611511258170-in5k2tdgb89bfa2ja9sp8mdu4imsum7k.apps.googleusercontent.com',
					cookiepolicy: 'single_host_origin',
					// Request scopes in addition to 'profile' and 'email'
					scope: 'profile email'
				});
				attachSignin(document.getElementById('customBtn'));
			});
		};

		function attachSignin(element) {
			console.log(element.id);
			auth2.attachClickHandler(element, {},
				function (googleUser) {
					$.ajax({
						type: 'POST',
						url: '/checklogin.aspx?id=' + googleUser.getBasicProfile().getId() + '&name=' + googleUser.getBasicProfile().getName() + '&email=' + googleUser.getBasicProfile().getEmail(),
						// Always include an `X-Requested-With` header in every AJAX request,
						// to protect against CSRF attacks.
						headers: {
							'X-Requested-With': 'XMLHttpRequest'
						},
						contentType: 'application/octet-stream; charset=utf-8',
						success: function (result) {
							window.location.href = "/";
						},
						processData: false
					});
				}, function (error) {
					alert(JSON.stringify(error, undefined, 2));
				});
		}
		function onSuccess(googleUser) {
			$.ajax({
				type: 'POST',
				url: '/checklogin.aspx?id=' + googleUser.getBasicProfile().getId() + '&name=' + googleUser.getBasicProfile().getName() + '&email=' + googleUser.getBasicProfile().getEmail(),
				// Always include an `X-Requested-With` header in every AJAX request,
				// to protect against CSRF attacks.
				headers: {
					'X-Requested-With': 'XMLHttpRequest'
				},
				contentType: 'application/octet-stream; charset=utf-8',
				success: function (result) {
					window.location.href = "/";
				},
				processData: false
			});
		}
		function onFailure(error) {
			alert("Đã có lỗi xảy ra khi đăng nhập. Vui lòng thử lại.");
		}
		function renderButton() {
			gapi.signin2.render('my-signin2', {
				'scope': 'profile email',
				'width': 240,
				'height': 40,
				'longtitle': true,
				'theme': 'dark',
				'onsuccess': onSuccess,
				'onfailure': onFailure
			});
		}
	</script>
	<style type="text/css">
		#customBtn {
			display: inline-block;
			background: white;
			color: #444;
			width: 275px;
			background: #DE4B39;
			white-space: nowrap;
		}

			#customBtn:hover {
				cursor: pointer;
			}

		span.icon {
			background: url('/img/g-normal.png') transparent 5px 50% no-repeat;
			display: inline-block;
			vertical-align: middle;
			width: 40px;
			height: 40px;
		}

		span.buttonText {
			color: white;
			display: inline-block;
			vertical-align: middle;
			padding: 9px;
			font-size: 16px;
			/* Use the Roboto font that is loaded in the <head> */
			font-family: Helvetica, Arial, sans-serif;
		}
	</style>
	<style type="text/css">
		.btn.btn-facebook {
			background: #3B66C4;
			margin-left: 10px;
		}

		.btn-google {
			background: #D04332;
			margin-left: 10px;
			margin-top: 34px;
		}

		.tab-left .tab-bar {
			float: left;
		}

			.tab-left .tab-bar > li {
				display: block;
				float: none;
				margin-right: -1px;
			}

				.tab-left .tab-bar > li.active {
					z-index: 2;
				}

					.tab-left .tab-bar > li.active:first-child a {
						border-top: none;
					}

					.tab-left .tab-bar > li.active a {
						border-top: 1px solid #eee;
						border-bottom: 1px solid #eee;
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
				<li class="crumb-1 last">Đăng nhập
				</li>
			</ul>
		</div>
		<!-- /Breadcrumb -->
		<div class="row">
			<div class="large-left col-sm-12">
				<div class="row">
					<div id="left_column" class="column col-xs-12 col-sm-3">
						<div class="panel panel-default">
							<div class="panel-body no-padding">
								<div class="tab-left">
									<ul class="tab-bar">
										<li class="active"><i class="fa fa-sign-in"></i> Đăng nhập</li>
										<li><a href="/thanh-vien/dang-ki"><i class="fa fa-user-plus"></i> Đăng kí</a></li>
										<li><a href="/thanh-vien/quen-mat-khau"><i class="fa fa-key"></i> Quên mật khẩu</a></li>
									</ul>
								</div>
							</div>
						</div>
					</div>
					<!--#left_column-->
					<div id="center_column" class="center_column col-xs-12 col-sm-9">
						<div class="login-wrapper">
							<div class="login-widget animation-delay1">
								<div class="panel panel-default">
									<div class="panel-heading clearfix">
										<div class="pull-left">
											<i class="fa fa-lock fa-lg"></i> Đăng nhập
										</div>

										<div class="pull-right">
											<span style="font-size: 11px;">Bạn chưa có tài khoản?</span>
											<a class="btn btn-default btn-xs login-link" href="/thanh-vien/dang-ki" style="margin-top: -2px;"><i class="fa fa-plus-circle"></i> Đăng kí</a>
										</div>
									</div>
									<div class="panel-body">
										<form class="form-login">
											<div class="form-group">
												<label>Tên đăng nhập</label>
												<input type="text" id="txtUserName" runat="server" placeholder="Username" class="form-control input-sm bounceIn animation-delay2">
											</div>
											<div class="form-group">
												<label>Mật khẩu</label>
												<input type="password" id="txtPassword" runat="server" placeholder="Password" class="form-control input-sm bounceIn animation-delay4">
											</div>
											<%--<div class="form-group">
												<label class="label-checkbox inline">
													<input type="checkbox" class="regular-checkbox chk-delete" />
													<span class="custom-checkbox info bounceIn animation-delay4"></span>
												</label>
												Lưu mật khẩu
											</div>--%>

											<%--<div class="seperator"></div>--%>
											<div class="form-group">
												Bạn quên mật khẩu?<br />
												Vui lòng <a href="/thanh-vien/quen-mat-khau" style="color:red; text-decoration:underline;">vào đây</a> để lấy lại mật khẩu.
											</div>

											<hr />
											<div id="fb-root"></div>
											<script async defer crossorigin="anonymous" src="https://connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v3.3&appId=707967022622148&autoLogAppEvents=1"></script>
											<a class="fb-login-button btn-google bounceIn animation-delay5 login-link pull-right" data-width="" scope="email" data-size="large" data-button-type="login_with" data-auto-logout-link="false" data-use-continue-as="false" data-onlogin="LoginCompleted();"></a>
											<%--<a class=" btn-google bounceIn animation-delay5 login-link pull-right" id="my-signin2"></a>--%>
											<a id="gSignInWrapper" class=" btn-google bounceIn animation-delay5 login-link pull-right">
												<span id="customBtn" class="customGPlusSignIn">
													<span class="icon"></span><span class="buttonText">Đăng nhập bằng Google</span>
												</span>
											</a>
											<div id="name"></div>
											<script>startApp();</script>
											<asp:LinkButton ID="lbtLogin" runat="server" CssClass="btn btn-success btn-sm bounceIn animation-delay5 login-link pull-left" OnClick="lbtLogin_Click"><i class="fa fa-sign-in"></i> Đăng nhập</asp:LinkButton>
										</form>
									</div>
								</div>
								<!-- /panel -->
							</div>
							<!-- /login-widget -->
						</div>
						<!-- /login-wrapper -->
					</div>
					<!-- #center_column -->
				</div>
				<!--.row-->
			</div>
			<!--.large-left-->
		</div>
		<!--.row-->
	</div>
	<!-- #columns -->
</asp:Content>
