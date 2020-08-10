<%@ Page Title="" Language="C#" MasterPageFile="~/member/Main.Master" AutoEventWireup="true" CodeBehind="edit-profile.aspx.cs" Inherits="FoodOnGo.member.edit_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="col-sm-1"></div>
    <div class="col-sm-10 border" style="margin-top: 10px; margin-bottom: 10px; border-radius: 25px;">
        <div class="row" style="padding-top: 10px;">
            <div class="col-lg-12" style="padding: 0px">
                <h2 class="page-title text-center">Edit Profile</h2>
                <ol class="breadcrumb col-sm-12">
                    <li class="col-sm-4"></li>
                    <li class="col-sm-1"><a href="#" class="text-primary nav-link">Profile</a></li>
                    <li class="col-sm-1 nav-link text-center">/</li>
                    <li class="col-sm-2 active nav-link">Edit Profile</li>
                </ol>
            </div>
        </div>
        <div class="row" style="">
            <div class="col-sm-2"></div>
            <div class="col-sm-8 col-xs-12 col-md-8 col-lg-8">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="white-box">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label style="color: black;">First Name</label>
                                        <asp:TextBox ID="txtFirst" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvFirst" ControlToValidate="txtFirst" Text="*" ToolTip="Please Enter First Name"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <label style="color: black;">Last Name</label>
                                        <asp:TextBox ID="txtLast" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="rfvLast" ControlToValidate="txtLast" Text="*" ToolTip="Please Enter First Name"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="row">
                                        <label style="color: black;">&nbsp;&nbsp;&nbsp;Date of Birth</label>
                                    </div>
                                    <asp:ScriptManager runat="server"></asp:ScriptManager>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="row">
                                                <div class="col-sm-4">
                                                    <asp:DropDownList ID="ddlMM" runat="server" CssClass="form-control col-sm-12" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged" Placeholder="MM"></asp:DropDownList>&nbsp;
                                                </div>
                                                <div class="col-sm-4">
                                                    <asp:DropDownList ID="ddlDD" runat="server" CssClass="form-control col-sm-12" Placeholder="DD"></asp:DropDownList>&nbsp;
                                                </div>
                                                <div class="col-sm-4">
                                                    <asp:DropDownList ID="ddlYYYY" runat="server" CssClass="form-control col-sm-12" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged" Placeholder="YYYY"></asp:DropDownList>&nbsp;
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label style="color: black;">Mobile</label>
                                    <asp:TextBox ID="txtMob" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-8">
                                <div class="form-group">
                                    <asp:Button ID="btnSubmit" CssClass="btn btn-success col-sm-4" runat="server" OnClick="btnSubmit_Click" Text="Submit"></asp:Button>
                                </div>
                            </div>
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
