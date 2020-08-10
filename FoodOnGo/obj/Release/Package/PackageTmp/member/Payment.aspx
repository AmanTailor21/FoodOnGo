<%@ Page Title="" Language="C#" MasterPageFile="~/Member/main.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="FoodOnGo.member.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="col-sm-12">
        <div class="row" style="margin: 10px;">
            <div class="col-sm-2"></div>
            <div class="col-sm-8 border-dark" style="border-radius: 25px">
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
                <div class="row mt-3">
                    <div class="col-sm-3">
                        <h6>Card No</h6>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <asp:TextBox ID="txtCard1" MaxLength="4" CssClass="form-control col-2 m-1" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtCard2" MaxLength="4" CssClass="form-control col-2 m-1" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtCard3" MaxLength="4" CssClass="form-control col-2 m-1" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtCard4" MaxLength="4" CssClass="form-control col-2 m-1" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-sm-3">
                        <h6>CVV</h6>
                    </div>
                    <div class="col-sm-2">
                        <asp:TextBox ID="txtCVV" MaxLength="3" CssClass="form-control" runat="server"></asp:TextBox>

                    </div>
                    <div class="col-sm-3">
                        <h6>CVV can be found at the Back of your Card</h6>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-sm-3">
                        <h6>CardHolder Name</h6>
                    </div>
                    <div class="col-sm-6">
                        <asp:TextBox ID="txtCardHolder" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <asp:ScriptManager runat="server"></asp:ScriptManager>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row mt-3">
                            <div class="col-sm-3">
                                <h6>Expires on</h6>
                            </div>

                            <div class="col-sm-6">
                                <div class="row">
                                    <div class="col-sm-4">
                                        Month:<asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control" />
                                    </div>
                                    <div class="col-sm-4">
                                        Year:<asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" CssClass="form-control" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="row mt-3">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4">
                        <asp:LinkButton CssClass="btn btn-success" runat="server" OnClick="btnProceed_Click" ID="btnProceed">Complete Payment</asp:LinkButton>
                    </div>
                    <div class="col-sm-4"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
