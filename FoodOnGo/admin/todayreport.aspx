﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="todayreport.aspx.cs" Inherits="FoodOnGo.admin.todayreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-sm-10">
            <h1 style="color: white;">Today's Reports</h1>
        </div>
        <div class="col-sm-1" style="padding: 0px; padding-bottom: 10px">
            <input type="submit" onclick="PrintElem('.printdiv');" class="btn btn-primary" value="Print Report" />
        </div>
    </div>
    <div id="printdiv" style="background: rgba(0, 0, 0,0.6); padding: 20px; border-radius: 25px; height: auto">
        <asp:Repeater ID="rptToday" runat="server">
            <HeaderTemplate>
                <table class="table" style="color: white;">
                    <tr>
                        <th>
                            <h4>OrderNo</h4>
                        </th>
                        <th>
                            <h4>User</h4>
                        </th>
                        <th>
                            <h4>Total Amount</h4>
                        </th>
                        <th>
                            <h4>Journey Date</h4>
                        </th>
                        <th></th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("OrderId")%></td>
                    <td><%# Eval("FirstName")+" "+Eval("LastName")%></td>
                    <td><%# Eval("TotalAmount")%></td>
                    <td><%# Eval("JourneyDate")%></td>
                    <td><a href='Orders.aspx?Oid=<%#Eval("OrderId")%>' id="Order">ViewOrder</a></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Label ID="lblmsg" runat="server" Style="color: white" Visible="false"></asp:Label>
    </div>
    <script>
        function funprint() {
            window.print();
        }
        function PrintElem(elem) {
            PrintPopup($(elem).html());
        }

        function PrintPopup(data) {
            //Windows title in window.open itches the IE the wrong way.
            var mywindow = window.open('', '', 'height=600,width=600');
            mywindow.document.write('<html><head><title>Food On Go</title>');
    /*optional stylesheet*/mywindow.document.write('<link rel="stylesheet" href="style.css" type="text/css" />');
            mywindow.document.write('</head><body >');
            mywindow.document.write(data);
            mywindow.document.write('</body></html>');
            mywindow.document.close();
            mywindow.focus();
            mywindow.print();
            mywindow.close();

            return true;
        }
    </script>
</asp:Content>
