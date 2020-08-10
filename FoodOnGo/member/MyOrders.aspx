<%@ Page Title="" Language="C#" MasterPageFile="~/member/Main.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="FoodOnGo.member.MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <h1 class="w-100 text-center m-1">My Orders</h1>
    <asp:Repeater ID="rptOrders" runat="server" OnItemCommand="rptOrders_ItemCommand">
        <ItemTemplate>
            <div class="col-sm-11 ml-5 mr-5 m-1 p-2 border">
                <div class="row m-1">
                    <div class="col-sm-2">
                        <div class="row">
                            <h4>Order</h4>
                        </div>
                        <div class="row">
                            #<%#Eval("OrderId") %>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="row">
                            <h4>OrderDate</h4>
                        </div>
                        <div class="row">
                            <%#Eval("OrderDate") %>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="row">
                            <h4>Journey</h4>
                        </div>
                        <div class="row">
                            <%# Eval("TN")+"<br>"+Eval("SN")%>
                            <%#Eval("JourneyDate") %>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="row">
                            <h4>Amount</h4>
                        </div>
                        <div class="row">
                            <%# Eval("TotalAmount") %>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <div class="row">
                            <h4>Payment</h4>
                        </div>
                        <div class="row">
                            <%# Eval("PaymentStatus").ToString()=="False"?"Pending":"Completed" %>
                        </div>
                    </div>
                    <div class="col-sm-2 ">
                        <div class="row">
                            <asp:LinkButton runat="server" ID="btnView" CommandName="view" CommandArgument='<%#Eval("OrderId")%>' CssClass="btn m-0 btn-primary text-white col-sm-12 m-0">View Order</asp:LinkButton> &nbsp;
                            <%--<asp:LinkButton runat="server" ID="btnCancel" CssClass="btn btn-danger text-white m-0 col-sm-12">Cancel Order</asp:LinkButton>--%>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
