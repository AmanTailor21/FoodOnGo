<%@ Page Title="" Language="C#" MasterPageFile="~/member/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FoodOnGo.member.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <style>
        footer {
            position: absolute;
        }
    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="Body" runat="server">
    <div class="col-sm-12">
        <div class="row m-3">
            <div class="col-sm-2"></div>
            <div class="col-sm-4">
                <div class="row">
                    <asp:LinkButton runat="server" href="edit-profile.aspx" CssClass="btn btn-primary col-sm-11"><i class="fa fa-3x fa-user-circle"></i><br />Edit Profile</asp:LinkButton>
                </div>
            </div>
            <div class="col-sm-4">
                <div class="row">
                    <asp:LinkButton runat="server" href="change-pass.aspx" CssClass="btn btn-dark col-sm-11"><i class="fa fa-3x fa-edit"></i><br />Change Password</asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="row m-3">
            <div class="col-sm-4"></div>
            <div class="col-sm-4">
                <div class="row">
                    <asp:LinkButton runat="server" href="MyOrders.aspx" CssClass="btn btn-warning col-sm-11"><i class="fa fa-3x fa-book"></i><br />My Orders</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
