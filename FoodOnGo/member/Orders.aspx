<%@ Page Title="" Language="C#" MasterPageFile="~/Member/main.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="FoodOnGo.member.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <style>
        .ddl:focus {
            box-shadow: none;
            border-color: lightgrey;
        }
    </style>
    <div class="col-sm-12">
        <div class="row" style="margin: 10px;">
            <div class="col-sm-2"></div>
            <div class="col-sm-8 p-3 border" style="border-radius: 25px; box-shadow: rgb(0,0,0) 3px 3px 5px 0px">
                <div class="row">
                    <div class="col-sm-8"></div>
                    <div class="col-sm-4">OrderNo.<asp:Label ID="lblOrderNo" runat="server"></asp:Label></div>
                </div>
                <div class="row">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-6">
                        <h1 style="text-align: center">Order</h1>
                    </div>
                </div>
                <hr style="background-color: gray" />
                <div class="row">
                    <div class="col-sm-1"></div>
                    <div class="col-sm-10">
                        <asp:Repeater ID="rptOrder" runat="server">
                            <HeaderTemplate>
                                <table>
                                    <tr>
                                        <th style="width: 65%">Name</th>
                                        <th style="width: 10%">Rate</th>
                                        <th style="width: 15%">Quantity</th>
                                        <th style="width: 10%">Amount</th>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#Eval("ItemName")%></td>
                                    <td><%#Eval("Rate")%></td>
                                    <td><%#Eval("Quantity")%></td>
                                    <td><%#Eval("Amount")%></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6"></div>
                    <div class="col-sm-6">
                        <hr style="background-color: gray; width: 100%" />
                        <div class="row">
                            <div class="col-sm-2"></div>
                            <div class="col-sm-4">Total Amount</div>
                            <div class="col-sm-5">
                                <asp:Label runat="server" ID="lblTotal"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2"></div>
                            <div class="col-sm-10">
                                (including all taxes)
                            </div>
                        </div>
                    </div>
                </div>
                <asp:ScriptManager runat="server"></asp:ScriptManager>
                <asp:UpdatePanel runat="server" class="m-3">
                    <ContentTemplate>
                        <div class="row mt-3">
                            <div class="col-sm-12 p-0">
                                <hr style="background-color: black;" />
                                <h3>Deliver At:</h3>
                                <hr style="background-color: black;" />
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-3 p-0">
                                        Train:<asp:DropDownList OnSelectedIndexChanged="ddltrainCode_SelectedIndexChanged" Style="border-right: none; border-radius: 5px 0px 0px 5px" AutoPostBack="true" ID="ddltrainCode" CssClass="form-control ddl dropdown" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-8 p-0">
                                        &nbsp;<asp:DropDownList OnSelectedIndexChanged="ddltrain_SelectedIndexChanged" Style="border-left: none; border-radius: 0px 5px 5px 0px" AutoPostBack="true" ID="ddltrain" CssClass="form-control ddl dropdown" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-1 ml-0">
                                        <h4 style="color: red">
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ddltrain" InitialValue="-Train-" Style="padding: 0px;" Text="*" ToolTip="Please Select Train"></asp:RequiredFieldValidator>
                                        </h4>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-3">
                                        Day:<asp:DropDownList ID="ddlDay" CssClass="form-control" runat="server" />
                                    </div>
                                    <div class="col-sm-3">
                                        Month:<asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" CssClass="form-control" />
                                    </div>
                                    <div class="col-sm-4">
                                        Year:<asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" CssClass="form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-3 p-0">
                                        Station:
                                        <asp:DropDownList OnSelectedIndexChanged="ddlStationCode_SelectedIndexChanged" Style="border-right: none; border-radius: 5px 0px 0px 5px" AutoPostBack="true" ID="ddlStationCode" CssClass="form-control ddl dropdown" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-8 p-0">
                                        &nbsp;<asp:DropDownList OnSelectedIndexChanged="ddlStation_SelectedIndexChanged" Style="border-left: none; border-radius: 0px 5px 5px 0px" AutoPostBack="true" ID="ddlStation" CssClass="form-control ddl ddl dropdown" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-sm-1 ml-0">
                                    <h4 style="color: red">
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlStation" InitialValue="-Station-" Style="padding: 0px;" Text="*" ToolTip="Please Select Station"></asp:RequiredFieldValidator>
                                    </h4>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-4 p-0">
                                        Seat No<asp:TextBox runat="server" CssClass="form-control" ID="txtseatno"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1 ml-0">
                                        <h4 style="color: red">
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtseatno" Style="padding: 0px;" Text="*" ToolTip="Please Enter Seat No"></asp:RequiredFieldValidator>
                                        </h4>
                                    </div>
                                    <div class="col-sm-6">
                                        PNR No:<asp:TextBox runat="server" MaxLength="10" CssClass="form-control" ID="txtPNR"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-1 ml-0">
                                        <h4 style="color: red">
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPNR" Style="padding: 0px;" Text="*" ToolTip="Please Enter PNR"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator runat="server" Text="*" ToolTip="Invalid PNR" ControlToValidate="txtPNR" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                                        </h4>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-sm-5">
                                <div class="row">
                                    <div class="col-sm-11 p-0">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-sm-4"></div>
                            <div class="col-sm-4">
                                <asp:LinkButton CssClass="btn btn-success" runat="server" OnClick="btnProceed_Click" ID="btnProceed">Proceed To Payment</asp:LinkButton>
                            </div>
                            <div class="col-sm-4"></div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
