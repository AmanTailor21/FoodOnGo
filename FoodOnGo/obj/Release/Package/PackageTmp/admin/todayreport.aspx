<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="todayreport.aspx.cs" Inherits="FoodOnGo.admin.todayreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background:rgba(0, 0, 0,0.6); padding:20px;border-radius:25px;height:auto">
        <asp:Repeater ID="rptToday" runat="server">
            <HeaderTemplate>
                <table class="table" style="color:white; ">
                    <tr>
                        <th>
                            <h4>OrderNo</h4>
                        </th>
                        <th>User</th>
                        <th>TotalAmount</th>
                        <th>Journey</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("OrderId")%></td>
                    <td><%# Eval("FirstName")+" "+Eval("LastName")%></td>
                    <td><%# Eval("TotalAmount")%></td>
                    <td><%# Eval("JourneyDate")%></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
