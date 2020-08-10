<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="FoodOnGo.admin.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        <h1 style="text-align: center">Order Details</h1>
                    </div>
                </div>
                <hr style="background-color: gray" />
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
                            <tr>
                                <td colspan="2">Train</td>
                                <td colspan="2"><asp:Label ID="train" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2">Station</td>
                                <td colspan="2"><asp:Label ID="station" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2">Journey</td>
                                <td colspan="2"><asp:Label ID="journey" runat="server"></asp:Label></td>
                            </tr>
                         </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6"></div>
                    <div class="col-sm-6">
                        <hr style="background-color: gray; width: 100%" />
                        <div class="row">
                            <div class="col-sm-2"></div>
                            <div class="col-sm-4">Total Amount</div>
                            <div class="col-sm-5"><asp:Label runat="server" ID="lblTotal"></asp:Label></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>