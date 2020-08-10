<%@ Page Title="" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FoodOnGo.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <link href="css/fog.css" rel="stylesheet" />
    <div class="three-img" style="height: 235px; width: 100%">
    </div>
    <div class="col-sm-12" style="padding-top: 10px">
        <div class="row">
            <div class="col-sm-3"></div>
            <div class="col-sm-6" style="height: 100%; padding-bottom: 10px; border-radius: 25px;">
                <div class="row">
                    <div class="col-sm-5"></div>
                    <div class="col-sm-2">

                        <h3 style="text-align: center; color: black;">Login</h3>
                    </div>
                </div>
                <div class="row" style="border-radius: 25px;">
                    <div class="col-sm-12" style="margin: 1%; padding: 20px; border-radius: 25px; background-color: #000000">
                        <div class="row" style="padding-top: 10px;">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6">
                                <asp:ScriptManager ID="sc1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="updatepanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" ID="txtEmail" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged" CssClass="textboxReg" Placeholder="Email Id"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Insert UserId" CssClass="text-danger" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                        &nbsp;
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:TextBox runat="server" ID="txtpass" CssClass="textboxReg" Placeholder="Password" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Insert Password" CssClass="text-danger" ControlToValidate="txtpass"></asp:RequiredFieldValidator>
                                &nbsp;
                              
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-3" style="padding: 5px;">
                                <%--<asp:Label ID="lblotp" runat="server" Text="OTP" Visible="true" ForeColor="Black"></asp:Label>--%>
                            </div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:UpdatePanel ID="updatepanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblMsg" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                                        <asp:Label ID="lblMsg1" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                                        <asp:TextBox runat="server" ID="txtOTP" CssClass="textboxReg" Placeholder="OTP" Visible="false"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                &nbsp;
                            </div>
                        </div>
                        <div class="row" style="padding-bottom: 30px;">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <%-- <asp:LinkButton runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" CssClass="btnReg btn">Submit</asp:LinkButton>--%>
                                        <asp:LinkButton ID="btnLogin" runat="server" CssClass="btnReg btn col-sm-11" OnClick="btnsubmit_Click" Text="Login"></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="padding:15px">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <a href="forgetpass.aspx" style="padding-bottom: 1px;" class="">
                                            <center>Forgot Password?</center>
                                        </a>
                                        <hr style="background-color: gray; margin: 1px; padding: 0px" class="" />
                                        <a href="Register.aspx" style="padding-top: 5px; margin-top: 0px;" class="">
                                            <center>New User?Register Here</center>
                                        </a>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="row" style="padding: 10px;">
                            <div class="col-sm-1"></div>
                            <div class="col-sm-10" style="align-content: center;">
                                <div class="row">
                                    <asp:Label runat="server" ID="lblerr1" CssClass="lblReg" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-1"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
