<%@ Page Title="" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="CheckEmail.aspx.cs" Inherits="FoodOnGo.CheckEmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <meta http-equiv="refresh" content="10;url=index.aspx" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <style>
        body {
            background-color: dimgray;
            min-height: 600px;
            height: auto;
        }

        footer {
            position: absolute;
            bottom: 0px;
            width: 100%;
        }
    </style>
    <div class="" style="height:300px"></div>
    <div class="m-auto popover-header w-50" style="height: auto; width: auto; background-color:rgba(255, 255, 255, 0.3)"><h2 class="text-center text-white">Please Check Your Email</h2><hr /><h6 class="text-center">Redirecting to Home Page in 10 sec</h6></div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
