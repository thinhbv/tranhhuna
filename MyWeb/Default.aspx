<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMaster.Master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="MyWeb.Default" %>
<%@ Register Src="Controls/U_ProductList.ascx" TagName="U_ProductList" TagPrefix="uc1" %>
<%@ Register Src="Controls/U_NewsList.ascx" TagPrefix="uc2" TagName="U_NewsList" %>
<%@ Register Src="~/Controls/U_Delivery.ascx" TagPrefix="uc3" TagName="U_Delivery" %>
<%@ Register Src="~/Controls/U_ImageList.ascx" TagPrefix="uc4" TagName="U_ImageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<main>
			<section class="well center767">
				<uc1:U_ProductList ID="idU_ProductList" runat="server" />
			</section>
			<section class="well1 bg-white center479">
				<div class="container">
					<div class="row">
						<div class="col-lg-8 col-md-7 col-sm-12 col-xs-12 wow fadeInLeft">
							<h3><%= sAboutName %></h3>

							<p class="p_mod">
								<%= sContents %>
							</p>
						</div>
						<div class="col-lg-4 col-md-5 col-sm-6 col-xs-12 mg_add">
							<div class="row">
								<div class="col-md-6 col-sm-6 col-xs-6 wow fadeInRight" data-wow-delay="0.2s">
									<a href="<%= sUrl %>" class="btn btn-default">Về chúng tôi</a>
								</div>
							</div>
						</div>
					</div>
				</div>
			</section>
			<section class="well center991">
				<div class="container">				
					<uc2:U_NewsList runat="server" id="idU_NewsList" />
				</div>
			</section>
			<section class="parallax well well__ins" data-url="images/parallax1.jpg" data-mobile="true">
				<div class="container">			
					<uc3:U_Delivery runat="server" id="idU_Delivery" />
				</div>
			</section>
			<section class="parallax well3 text-center" data-url="images/parallax2.jpg" data-mobile="true">
				<div class="container">
					<h2 class="wow fadeIn">
						<strong>
							<em>
								Một câu châm ngôn hay ở đây....
							</em>
						</strong>
					</h2>
				</div>
			</section>
			<section class="well4 text-center">			
				<uc4:U_ImageList runat="server" id="idU_ImageList" />
			</section>
		</main>
</asp:Content>
