<%@ Page Title="" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="forgetpass.aspx.cs" Inherits="FoodOnGo.forgetpass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <link href="css/foodongo.css" rel="stylesheet" />
    <div class="col-sm-12">
        <div class="row">
            <div class="col-sm-6" style="margin-top: 15.5%; margin-left: 300px; padding-bottom: 10px; border-radius: 25px;">
                <div class="row">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-6">
                        <h2 style="text-align: center; padding-top: 15px">Forget Password</h2>
                    </div>
                </div>
                <div class="row" style="background-color: silver; border-radius: 25px;">
                    <div class="col-sm-12" style="padding: 20px; border-radius: 25px; background-color: black;">
                        <%--<div class="row" style="padding-top: 10px; text-align: center;">--%>
                        <div class="col-sm-3"></div>
                        <div class="row" style="padding-top: 10px;">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:TextBox runat="server" CssClass="textboxReg" ID="txtEmail" Placeholder="Email Address"></asp:TextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Insert EmailId" CssClass="text-danger" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                <asp:Label runat="server" ID="lblmsg2" Visible="false" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="padding-bottom: 30px;">
                            <div class="col-sm-5"></div>
                            <div class="col-sm-3">
                                <div class="col-sm-6">
                                    <asp:Button runat="server" ID="btnSubmit" CssClass="btnReg btn" OnClick="btnSubmit_Click" Text="Submit" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%--</div>--%>
            </div>
        </div>
        <div class="col-sm-1"></div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
