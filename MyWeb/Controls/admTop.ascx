<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="admTop.ascx.cs" Inherits="MyWeb.Controls.admTop" %>
<%@ Import Namespace="MyWeb.Common" %>
<div class="div"><table class="table" cellspacing="0" cellpadding="0"><tr><td colspan="3" class="logo">ADMIN 
    PAGE MANAGER</td></tr><tr><td class="left">Wellcome: <strong><%= Session["FullName"]%></strong></td><td class="right">[ <a href="<%=GlobalClass.ApplicationPath %>/admin" target="_blank">Trang quản trị </a> ] &nbsp; [ <a href="<%=GlobalClass.ApplicationPath %>/" target="_blank">Trang chủ</a> ] &nbsp; [<a href="<%=GlobalClass.ApplicationPath %>/Logon"> Đăng xuất</a> ]</td></tr></table></div>


