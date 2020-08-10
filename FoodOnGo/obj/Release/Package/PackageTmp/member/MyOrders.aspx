<%@ Page Title="" Language="C#" MasterPageFile="~/member/Main.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="FoodOnGo.member.MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <asp:Repeater ID="rptOrders" runat="server">
        <ItemTemplate>
            <div class="col-sm-12 mr-5 m-1 ml-3 pl-3 border">
                <div class="row m-3">
                    <div class="col-sm-2">
                        <div class="row">
                            Order
                        </div>
                        <div class="row">
                            #<%#Eval("OrderId") %>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="row">
                            OrderDate
                        </div>
                        <div class="row">
                            <%#Eval("OrderDate") %>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="row">
                            Journey
                        </div>
                        <div class="row">
                            <%# Eval("TN")+"-"+Eval("SN")%>
                            <%#Eval("JourneyDate") %>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="row">
                            OrderAmount
                        </div>
                        <div class="row">
                            <%# Eval("TotalAmount") %>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
