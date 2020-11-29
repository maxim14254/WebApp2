<%@ Page MasterPageFile="Master.master" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" Async="true" %>

<asp:Content ContentPlaceHolderId="CPH1" runat="server">

<link rel="stylesheet" type="text/css" href="Css/StyleSheet3.css">
    <div style="width:20%; margin:0 40%;">
        <h2 style="margin-top:5%;">Все пользователи</h2>
    </div>
    <asp:Table ID="data" CssClass="t1" runat="server" cellspacing="0" cellpadding="12" align="center">
    </asp:Table>
</asp:Content>
