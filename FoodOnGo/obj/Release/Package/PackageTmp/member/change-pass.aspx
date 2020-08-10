<%@ Page Title="" Language="C#" MasterPageFile="~/member/Main.Master" AutoEventWireup="true" CodeBehind="change-pass.aspx.cs" Inherits="FoodOnGo.member.change_pass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="col-sm-1"></div>
    <div class="col-sm-10 border" style="margin-top: 10px; margin-bottom: 10px; border-radius: 25px;">
        <div class="row" style="padding-top: 10px;">
            <div class="col-lg-12" style="padding: 0px">
                <h2 class="page-title text-center">Change Password</h2>
                <ol class="breadcrumb col-sm-12">
                    <li class="col-sm-4"></li>
                    <li class="col-sm-1"><a href="#" class="text-primary nav-link">Profile</a></li>
                    <li class="col-sm-1 nav-link text-center">/</li>
                    <li class="col-sm-2 active nav-link">Change Password</li>
                </ol>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3"></div>
            <div class="col-lg-6">
                <asp:Label ID="lblMSG" runat="server" Text=""></asp:Label>
                <div class="white-box">
                    <div class="row">
                        <div class="col-sm-10">
                            <div class="form-group">
                                <label style="color: black;">Old Password</label>
                                <asp:TextBox ID="txtOldPass" runat="server" CssClass="form-control col-sm-12" TextMode="password"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-sm-2">
                            <asp:RequiredFieldValidator CssClass="text-danger danger" Style="font-size: x-large;" ControlToValidate="txtOldPass" ToolTip="Please Enter Password" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-10">
                            <div class="form-group">
                                <label style="color: black;">New Password</label>
                                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control col-sm-12" TextMode="password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <asp:RequiredFieldValidator CssClass="text-danger danger" Style="font-size: x-large;" ControlToValidate="txtPass" ToolTip="Please Enter Password" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-10">
                            <div class="form-group">
                                <label style="color: black;">Confirm Password</label>
                                <asp:TextBox ID="txtCpass" runat="server" CssClass="form-control col-sm-12" TextMode="password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-sm-2">
                            <asp:RequiredFieldValidator CssClass="text-danger danger" Style="font-size: x-large;" ControlToValidate="txtCPass" ToolTip="Please Enter Password" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="CompareValidator" ControlToValidate="txtCPass" ControlToCompare="txtPass" ToolTip="Password Does not Match" Text="*"></asp:CompareValidator>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 10px">
                        <div class="col-sm-3"></div>
                        <div class="col-sm-8">
                            <div class="form-group">
                                <asp:Button ID="btnSubmit" CausesValidation="true" OnClick="btnSubmit_Click" CssClass="btn btn-success col-sm-4" runat="server" Text="Submit" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
