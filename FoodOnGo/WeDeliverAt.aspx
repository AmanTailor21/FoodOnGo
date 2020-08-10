<%@ Page Title="FoodOnGo | We Deliver At" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="WeDeliverAt.aspx.cs" Inherits="FoodOnGo.WeDeliverAt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
    <style>
        .ddl:focus {
            box-shadow: none;
            border-color: lightgrey;
        }
        footer{
            position:absolute;
            width:100%;
            bottom:0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="row">
        <div class="col-sm-4"></div>
        <div class="col-md-4" style="padding-top: 225px;">
            <div class="row">
                <div class="col-sm-12 p-0 pb-5"><h3>We Deliver at..</h3></div>
            </div>
            <div class="row">
                <div class="col-sm-4 p-0">
                    Train:<asp:DropDownList OnSelectedIndexChanged="ddltrainCode_SelectedIndexChanged" Style="border-right: none; border-radius: 5px 0px 0px 5px" AutoPostBack="true" ID="ddltrainCode" CssClass="form-control ddl dropdown" runat="server"></asp:DropDownList>
                </div>
                <div class="col-sm-8 p-0">
                    &nbsp;<asp:DropDownList OnSelectedIndexChanged="ddltrain_SelectedIndexChanged" Style="border-left: none; border-radius: 0px 5px 5px 0px" AutoPostBack="true" ID="ddltrain" CssClass="form-control ddl dropdown" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4 p-0">
                    Station:<asp:DropDownList OnSelectedIndexChanged="ddlStationCode_SelectedIndexChanged" Style="border-right: none; border-radius: 5px 0px 0px 5px" AutoPostBack="true" ID="ddlStationCode" CssClass="form-control ddl dropdown" runat="server"></asp:DropDownList>
                </div>
                <div class="col-sm-8 p-0">
                    &nbsp;<asp:DropDownList OnSelectedIndexChanged="ddlStation_SelectedIndexChanged" Style="border-left: none; border-radius: 0px 5px 5px 0px" AutoPostBack="true" ID="ddlStation" CssClass="form-control ddl dropdown" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
