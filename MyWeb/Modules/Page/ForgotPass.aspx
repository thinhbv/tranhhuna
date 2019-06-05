<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/PageMaster.Master" AutoEventWireup="true" CodeBehind="ForgotPass.aspx.cs" Inherits="MyWeb.Modules.Page.ForgotPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
				<li class="crumb-1 last">Lấy lại mật khẩu
				</li>
			</ul>
		</div>
		<!-- /Breadcrumb -->
		<div class="row">
			<div class="large-left col-sm-12">
				<div class="row">
					<div id="left_column" class="column col-xs-12 col-sm-12">
						<div class="panel panel-default">
							<div class="panel-heading">
								Lấy lại mật khẩu
							</div>
							<div class="panel-body no-padding">
								<div class="form-group">
									<label>Địa chỉ email</label>
									<input type="text" id="txtEmail" runat="server" placeholder="Email của bạn" class="form-control input-sm bounceIn animation-delay3">
								</div>
								<!-- /form-group -->
								<div class="form-group">
									<div class="controls text-right">
										<asp:LinkButton ID="lbtGetPass" runat="server" CssClass="btn btn-success btn-sm bounceIn animation-delay7 login-link" OnClick="lbtGetPass_Click"><i class="fa fa-floppy-o"></i> Lấy lại mật khẩu</asp:LinkButton>
									</div>
								</div>
								<!-- /form-group -->
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
