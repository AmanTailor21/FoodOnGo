<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="monthlyreport.aspx.cs" Inherits="FoodOnGo.admin.monthreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-9"><h1 style="color:white"><asp:Label runat="server" ID="lblHead"></asp:Label></h1></div>
        <div class="col-sm-3" style="padding:0px;padding-bottom:10px">
            <asp:LinkButton CssClass="btn btn-primary" ID="lnkLastMonth" OnClick="lnkPastMonth_Click" runat="server" Text="Last Month"></asp:LinkButton>
            <asp:LinkButton CssClass="btn btn-primary" ID="lnkThisMonth" OnClick="lnkThisMonth_Click" runat="server" Text="This Month"></asp:LinkButton>
        </div>
    </div>
    <div style="background: rgba(0, 0, 0,0.6); padding: 20px; border-radius: 25px; height: auto">
        <asp:Repeater ID="rptMonth" runat="server" OnItemCommand="rptMonth_ItemCommand">
            <HeaderTemplate>
                <table class="table" style="color: white;">
                    <tr>
                        <th>
                            <h4>OrderNo</h4>
                        </th>
                        <th>User</th>
                        <th>TotalAmount</th>
                        <th>Journey</th>
                        <th></th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("OrderId")%></td>
                    <td><%# Eval("FirstName")+" "+Eval("LastName")%></td>
                    <td><%# Eval("TotalAmount")%></td>
                    <td><%# Eval("JourneyDate")%></td>
                    <td><asp:LinkButton CommandArgument='<%# Eval("OrderId") %>' runat="server" ID="lnkOrder" Text="ViewOrder"></asp:LinkButton></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="lblmsg" runat="server" Style="color:white" Visible="false"></asp:Label>
    </div>
</asp:Content>
