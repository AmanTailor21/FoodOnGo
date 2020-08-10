<%@ Page Title="" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FoodOnGo.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <link href="css/fog.css" rel="stylesheet" />
    <div class="one-img" style="height: 235px; width: 100%">
    </div>
    <div class="col-sm-12">
        <div class="row">
            <div class="col-sm-1"></div>
            <div class="col-sm-10" style="margin-top: 10px; margin-bottom: 10px; padding-bottom: 10px; border-radius: 25px;">
                <div class="row">
                    <div class="col-sm-5"></div>
                    <div class="col-sm-2">
                        <h3 style="text-align: center; padding-top: 10px; color: black;">Register</h3>
                    </div>
                </div>
                <div class="row" style="border-radius: 25px; padding: 10px;">
                    <div class="col-sm-12" style="padding: 20px; border-radius: 25px; background-color: #000000">
                        <div class="row" style="padding-top: 10px;">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-3" style="padding-top: 10px;">
                                <asp:TextBox runat="server" ID="txtfname" CssClass="textboxReg col-sm-11" Placeholder="First Name"></asp:TextBox>
                                &nbsp;
                                <h4 style="color: red">
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtfname" CssClass="col-sm-1" Style="padding: 0px;" Text="*" ToolTip="Please Enter First Name"></asp:RequiredFieldValidator></h4>
                            </div>
                            &nbsp;
                            <div class="col-sm-3" style="padding-top: 10px;">
                                <asp:TextBox runat="server" ID="txtlname" CssClass="textboxReg col-sm-11" Placeholder="Last Name"></asp:TextBox>&nbsp;
                                <h4 style="color: red">
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtlname" Style="padding: 0px;" Text="*" ToolTip="Please Enter Last Name"></asp:RequiredFieldValidator></h4>
                            </div>
                        </div>
                        <div class="row" style="padding: 10px;">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-4" style="align-content: center;">
                                <div class="row">
                                    <asp:Label runat="server" ID="txtdob" CssClass="lblReg pos1">Date Of Birth</asp:Label>
                                </div>
                                <br />
                                &nbsp;
                                <asp:ScriptManager runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="row">
                                            <div class="col-sm-3" style="padding-right: 0px">
                                                <asp:DropDownList ID="ddlMM" runat="server" CssClass="ddlReg" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged" BackColor="Black">
                                                    <asp:ListItem>MM</asp:ListItem>
                                                </asp:DropDownList>&nbsp;
                                            </div>
                                            <div class="col-sm-3" style="padding-right: 0px">
                                                <asp:DropDownList ID="ddlDD" runat="server" CssClass="ddlReg" BackColor="Black">
                                                    <asp:ListItem>DD</asp:ListItem>
                                                </asp:DropDownList>&nbsp;                                                
                                            </div>
                                            <div class="col-sm-4" style="padding-right: 0px">
                                                <asp:DropDownList ID="ddlYYYY" runat="server" CssClass="ddlReg" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged" BackColor="Black">
                                                    <asp:ListItem>YYYY</asp:ListItem>
                                                </asp:DropDownList>&nbsp;
                                            </div>
                                            <div class="col-sm-2">
                                                <div class="row">
                                                    <h5 style="color: red">
                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlMM" CssClass="col-sm-3" Style="padding: 0px;" Text="*" InitialValue="MM" ToolTip="Select Month"></asp:RequiredFieldValidator></h5>
                                                    <h5 style="color: red">
                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlDD" CssClass="col-sm-3" Style="padding: 0px;" Text="*" InitialValue="DD" ToolTip="Select Date"></asp:RequiredFieldValidator></h5>
                                                    <h5 style="color: red">
                                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlYYYY" CssClass="col-sm-3" Style="padding: 0px;" Text="*" InitialValue="YYYY" ToolTip="Select Year"></asp:RequiredFieldValidator></h5>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-2" style="align-content: center;">
                                <asp:Label runat="server" CssClass="col-sm-2 lblReg pos2">Gender</asp:Label><br />
                                &nbsp;&nbsp;
                                <asp:DropDownList runat="server" ID="ddlGender" CssClass="textboxReg" Placeholder="DD" BackColor="Black">
                                    <asp:ListItem Enabled="False" Selected="True">I am...</asp:ListItem>
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row" style="padding-top: 10px;">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:TextBox runat="server" ID="txtemail" CssClass="textboxReg" Placeholder="Email Address" TextMode="Email"></asp:TextBox>&nbsp;
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:TextBox runat="server" ID="txtpass" CssClass="textboxReg" Placeholder="Password" TextMode="Password"></asp:TextBox>&nbsp;
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:TextBox runat="server" ID="txtconpass" CssClass="textboxReg" Placeholder="Confirm Password" TextMode="Password"></asp:TextBox>&nbsp;
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3"></div>
                            <div class="col-sm-6" style="padding: 10px;">
                                <asp:TextBox runat="server" ID="txtmob" CssClass="textboxReg" Placeholder="Mobile Number"></asp:TextBox>&nbsp;
                            </div>
                        </div>
                        <div class="row" style="padding-bottom: 30px;">
                            <div class="col-sm-5"></div>
                            <div class="col-sm-2">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <%-- <asp:LinkButton runat="server" ID="btnsubmit" OnClick="btnsubmit_Click" CssClass="btnReg btn">Submit</asp:LinkButton>--%>
                                        <asp:LinkButton ID="btnsubmit" runat="server" CausesValidation="true" CssClass="btnReg btn col-sm-12" OnClick="btnsubmit_Click" Text="Submit" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-1"></div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
