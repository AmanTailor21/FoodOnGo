<%@ Page Title="" Language="C#" MasterPageFile="~/Member/main.Master" AutoEventWireup="true" CodeBehind="ViewOrder.aspx.cs" Inherits="FoodOnGo.member.ViewOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="col-sm-12">
        <div class="row" style="margin: 10px;">
            <div class="col-sm-2"></div>
            <div class="col-sm-8 p-3 border" style="border-radius: 25px; box-shadow: rgb(0,0,0) 3px 3px 5px 0px">

                <div class="row" style="padding-top: 2%">
                    <div class="col-sm-8"></div>
                    <div class="col-sm-4">OrderNo.<asp:Label ID="lblOrderNo" runat="server"></asp:Label></div>
                </div>
                <div class="row" style="border-bottom: 1px solid black">
                    <div class="col-sm-3"></div>
                    <div class="col-sm-6">
                        <h1 style="text-align: center">Order Details</h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-1"></div>
                    <div class="col-sm-10">
                        <table>
                            <asp:Repeater ID="rptOrder" runat="server">
                                <HeaderTemplate>

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
                                </FooterTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6"></div>
                    <div class="col-sm-6">
                        <hr style="background-color: gray; width: 100%" />
                        <div class="row">
                            <div class="col-sm-1"></div>
                            <div class="col-sm-4">Total Amount</div>
                            <div class="col-sm-5">
                                <asp:Label runat="server" ID="lblTotal"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-sm-4">Train</div>
                    <div class="col-sm-4">
                        <asp:Label ID="lbltrain" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-sm-4">Station</div>
                    <div class="col-sm-4">
                        <asp:Label ID="lblstation" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-sm-4">Timing</div>
                    <div class="col-sm-4">
                        <asp:Label ID="lblst" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-sm-4">JourneyDate</div>
                    <div class="col-sm-4">
                        <asp:Label ID="lbljourney" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-sm-4">Payment Status</div>
                    <div class="col-sm-4">
                        <asp:Label ID="lblPayment" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
