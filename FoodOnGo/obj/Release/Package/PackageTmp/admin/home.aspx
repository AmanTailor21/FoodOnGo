<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/main.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="FoodOnGo.Admin.home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="refresh" content="30" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1 style="color: white; text-align: center;">Welcome to FoodOnGo</h1>
        <div style="height: 10px"></div>
        <div class="row">
             
            <div class="col-sm-12" style="margin-left: 10px;">
                <div class="row" style="background-color:white; text-align: center; color: green; height: 50px; padding-top: 15px;border-top-left-radius:35px; border-top-right-radius:35px;"><i class="fa fa-shopping-cart"></i> Orders Count</div>
                <div class="row">
                    <div class="col-sm-3">
                        <div class="row" style="background-color:white; text-align: center; color: green; height: 50px; padding-top: 15px;">Today</div>
                        <div class="row" style="height: 75px; ;background-color:rgba(0,128,0,0.6); color: white; text-align: center;">
                            <asp:Label runat="server" ID="TodayOrder" Font-Size="X-Large"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="row" style="background-color:white; text-align: center; color: green; height: 50px; padding-top: 15px;">This Week </div>
                        <div class="row" style="height:75px; background-color:rgba(0,128,0,0.6); color: white; text-align: center;">
                            <asp:Label runat="server" ID="WeekOrder" Font-Size="X-Large"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="row" style="background-color:white; text-align: center; color: green; height: 50px; padding-top: 15px;">This Month</div>
                        <div class="row" style="height: 75px; background-color:rgba(0,128,0,0.6); color: white; text-align: center;">
                            <asp:Label runat="server" ID="MonthOrder" Font-Size="X-Large"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="row" style="background-color:white; text-align: center; color: green; height: 50px; padding-top: 15px;">Life Time</div>
                        <div class="row" style="height:75px; background-color:rgba(0,128,0,0.6); color: white; text-align: center;">
                            <asp:Label runat="server" ID="TotalOrder" Font-Size="X-Large"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="height:10px"></div>
        <div class="row">
            <div class="col-sm-12" style="margin-left:10px;">
                <div class="row" style="background-color:white; text-align: center; color: orange; height: 50px; padding-top: 15px;"><i class="fa fa-user"></i> User Count</div>
                <div class="row">
                    <div class="col-sm-3">
                        <div class="row" style="background-color:white; text-align: center; color: orange; height: 50px; padding-top: 10px;">Today</div>
                        <div class="row" style="height:75px; background-color:rgba(248, 148, 6,0.6); color: white; text-align: center;">
                            <asp:Label runat="server" ID="TodayUser" Font-Size="X-Large"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="row" style="background-color:white; text-align: center; color: orange; height: 50px; padding-top: 10px;">This Week </div>
                        <div class="row" style="height:75px; background-color:rgba(248, 148, 6,0.6); color: white; text-align: center;">
                            <asp:Label runat="server" ID="WeekUser" Font-Size="X-Large"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="row" style="background-color:white; text-align: center; color: orange; height: 50px; padding-top: 10px;">This Month</div>
                        <div class="row" style="height:75px; background-color:rgba(248, 148, 6,0.6); color: white; text-align: center;">
                            <asp:Label runat="server" ID="MonthUser" Font-Size="X-Large"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="row" style="background-color:white; text-align: center; color: orange; height: 50px; padding-top: 15px;">Life Time</div>
                        <div class="row" style="height:75px; background-color:rgba(248, 148, 6,0.6); color: white; text-align: center;">
                            <asp:Label runat="server" ID="TotalUser" Font-Size="X-Large"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="height: 10px"></div>
        <div class="row">
            <div class="col-sm-12" style="margin-left: 10px;">
                <div class="row" style="background-color:white; text-align: center;color:blue; padding-top: 15px; "><i class="fa fa-commenting"></i> Feedback Count</div>
                <div class="row">
                    <div class="col-sm-3">
                        <div class="row" style="background-color: white; text-align: center; color: blue; height: 50px; padding-top: 15px;">Today</div>
                        <div class="row" style="height: 75px; background-color:rgba(0, 181, 204,0.6); color: white; text-align: center; border-bottom-left-radius:10px;">
                            <asp:Label runat="server" ID="TodayFeed" Font-Size="X-Large"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="row" style="background-color: white; text-align: center; color: blue; height: 50px; padding-top: 15px;">This Week </div>
                        <div class="row" style="height: 75px; background-color:rgba(0, 181, 204,0.6); color: white; text-align: center; ">
                            <asp:Label runat="server" ID="WeekFeed" Font-Size="X-Large"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="row" style="background-color: white; text-align: center; color: blue; height: 50px; padding-top: 15px;">This Month</div>
                        <div class="row" style="height: 75px; background-color:rgba(0, 181, 204,0.6); color: white; text-align: center;">
                            <asp:Label runat="server" ID="MonthFeed" Font-Size="X-Large"></asp:Label>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div class="row" style="background-color: white; text-align: center; color: blue; height: 50px; padding-top: 15px; ">Life Time</div>
                        <div class="row" style="height: 75px; background-color: rgba(0, 181, 204,0.6); color: white; text-align: center;  border-bottom-right-radius:10px;">
                            <asp:Label runat="server" ID="TotalFeed" Font-Size="X-Large"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
