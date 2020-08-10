<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="change-pass.aspx.cs" Inherits="FoodOnGo.admin.change_pass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-6 col-xs-12 col-md-6 col-lg-6">
            <div class="row">
                 
                <div class="col-lg-12">
                   <h3 style="color:white;"><i class="fa fa-key" ></i> Change-Password</h3><br />
                    <asp:Label ID="lblMSG" runat="server" Text=""></asp:Label>
                    <div class="white-box">
                        <div class="row">
                            <div class="col-sm-10">
                                <div class="form-group">
                                    <label style="color: white;">Old Password</label>
                                    <asp:TextBox ID="txtOldPass" runat="server" CssClass="form-control col-sm-12" TextMode="password"></asp:TextBox>
                                    <asp:RequiredFieldValidator CssClass="text-danger danger" Style="font-size: x-large;" ControlToValidate="txtOldPass" ToolTip="Please Enter Password" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-sm-2">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-10">
                                <div class="form-group">
                                    <label style="color: white;">New Password</label>
                                    <asp:TextBox ID="txtPass" runat="server" CssClass="form-control col-sm-10" TextMode="password"></asp:TextBox>
                                    <asp:RequiredFieldValidator CssClass="text-danger danger" Style="font-size: x-large;" ControlToValidate="txtPass" ToolTip="Please Enter Password" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-sm-2">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-10">
                                <div class="form-group">
                                    <label style="color: white;">Confirm Password</label>
                                    <asp:TextBox ID="txtCpass" runat="server" CssClass="form-control col-sm-12" TextMode="password"></asp:TextBox>
                                    <asp:RequiredFieldValidator CssClass="text-danger danger" Style="font-size: x-large;" ControlToValidate="txtCPass" ToolTip="Please Enter Password" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="CompareValidator" ControlToValidate="txtCPass" ControlToCompare="txtPass" ToolTip="Password Does not Match" Text="*"></asp:CompareValidator>
                                </div>
                            </div>
                            <div class="col-sm-2">
                            </div>
                        </div>
                        <div class="row" style="padding-top: 10px">
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
    </div>
</asp:Content>