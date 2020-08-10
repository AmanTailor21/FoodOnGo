<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="TrainStation.aspx.cs" Inherits="FoodOnGo.admin.TrainStation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hid1" runat="server" />
    <div class="col-sm-12" style="width: 100%; height: 100%; border-radius: 10px 60px">
        <div class="row">
            <div class="col-sm-12">
                <div class="col-sm-1"></div>
                <div class="col-sm-10" style="margin-top: 1%; padding: 10px; background-color: white; border-bottom-style: groove; border-top: thin; border-radius: 500px">
                    <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-10">
                            <asp:ScriptManager runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row" style="padding-top: 1%">
                                        <div class="col-sm-1"></div>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lbl" runat="server" Text="Train"></asp:Label>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlTrainCode" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlTrainCode_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlTrain" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlTrain_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div>
                                            <h4 style="color: red">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvTrain" ControlToValidate="ddlTrain" InitialValue="-Select Train-" ErrorMessage="*" ToolTip="Please Select Station..."></asp:RequiredFieldValidator>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 1%">
                                        <div class="col-sm-1"></div>
                                        <div class="col-sm-4">
                                            <asp:Label ID="lblTN" runat="server" Text="Station"></asp:Label>
                                        </div>
                                        <div class="col-sm-2">
                                            <asp:DropDownList ID="ddlStationCode" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlStationCode_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4">
                                            <asp:DropDownList ID="ddlStation" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlStation_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 1%">
                                        <div class="col-sm-1"></div>
                                        <div class="col-sm-4">
                                            <asp:Label ID="Label6" runat="server" Text="Arrival Time"></asp:Label>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="ddlArrivalTimeHH" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="ddlArrivalTimeMM" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div>
                                            <h4 style="color: red">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvATimeHH" ControlToValidate="ddlArrivalTimeHH" InitialValue="HH" ErrorMessage="*" ToolTip="Please Select Hour..."></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvATimeMM" ControlToValidate="ddlArrivalTimeMM" InitialValue="MM" ErrorMessage="*" ToolTip="Please Select Minutes..."></asp:RequiredFieldValidator>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 1%">
                                        <div class="col-sm-1"></div>
                                        <div class="col-sm-4">
                                            <asp:Label ID="Label7" runat="server" Text="Departure Time"></asp:Label>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="ddlDepartureTimeHH" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:DropDownList ID="ddlDepartureTimeMM" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div>
                                            <h4 style="color: red">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvDepartureTimeHH" ControlToValidate="ddlDepartureTimeHH" InitialValue="HH" ErrorMessage="*" ToolTip="Please Select Hour..."></asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator runat="server" ID="rfvDepartureTimeMM" ControlToValidate="ddlDepartureTimeMM" InitialValue="MM" ErrorMessage="*" ToolTip="Please Select Minutes..."></asp:RequiredFieldValidator>
                                            </h4>
                                        </div>
                                    </div>
                                    <div class="row" style="padding-top: 1%">
                                        <div class="col-sm-1"></div>
                                        <div class="col-sm-4">
                                            <asp:Label ID="Label8" runat="server" Text="Halt Time"></asp:Label>
                                        </div>
                                        <div class="col-sm-3">
                                            <asp:TextBox ID="txtStopTime" MaxLength="2" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div>
                                            <h4 style="color: red">
                                                <asp:RequiredFieldValidator runat="server" ID="rfvStopTime" ControlToValidate="txtStopTime" ErrorMessage="*" ToolTip="Please Fill Stop/Halt Time..."></asp:RequiredFieldValidator>
                                            </h4>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="row" style="padding-top: 1%">
                                <div class="col-sm-5"></div>
                                <div class="col-sm-2" style="padding-top: 1%;">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" OnClick="BtnSubmit_Click" Text="Submit"></asp:Button>
                                </div>
                                <div class="col-sm-4" style="padding-top: 10px">
                                    <asp:Label ID="lblWarn" runat="server" CssClass="text-danger" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-1"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12" style="margin-top: 1%; padding: 1%; background-color: white; border-radius: 50px;">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="col-sm-3"></div>
                        <div class="col-sm-1" style="padding-top: 1%;">
                            <label>Search</label>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-1">
                            <asp:Button ID="btnSearch" OnClick="btnSearch_Click" runat="server" CssClass="btn btn-success" CausesValidation="false" Text="Search" />
                        </div>
                    </div>
                </div>
                <div class="row" style="padding-top: 1%;">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-8">
                        <div class="white-box">
                            <div class="row">
                                <div class="col-sm-2">
                                    <asp:DropDownList runat="server" ID="cboPageSize" Style="background-color: aliceblue; color: black" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cboPageSize_SelectedIndexChanged">
                                        <asp:ListItem Value="5">5</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="15">15</asp:ListItem>
                                        <asp:ListItem Value="25">25</asp:ListItem>
                                        <asp:ListItem Value="50">50</asp:ListItem>
                                        <asp:ListItem Value="100">100</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-6">
                                    <div class="text-left">
                                        <asp:Literal ID="ltrRecordFound" runat="server"></asp:Literal>
                                    </div>
                                </div>
                                <%--<div class="col-sm-2">
                                    <label>Search</label>
                                </div>
                                <div class="col-sm-4">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Style="border-radius: 20px; background-color: aliceblue; color: black"></asp:TextBox>
                                </div>
                                <div class="col-sm-2">
                                    <asp:Button ID="Button1" CausesValidation="false" runat="server" CssClass="btn btn-primary" OnClick="btnsearch_Click" Style="border-radius: 20px" Text="Search" /><br />
                                </div>--%>
                                <div class="text-right p-b-10">
                                    <asp:Repeater ID="rptPager" runat="server">
                                        <ItemTemplate>
                                            <asp:LinkButton CausesValidation="false" ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                                CssClass='<%# Convert.ToBoolean(Eval("Enabled")) ? "btn btn-primary btn-sm" : "btn btn-default btn-sm" %>'
                                                OnClick="Page_Changed" OnClientClick='<%# !Convert.ToBoolean(Eval("Enabled")) ? "return false;" : "" %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12">
                                    <asp:Literal ID="ltrMsg" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2"></div>
                </div>
                <div class="row" style="padding-top: 2%;">
                    <div class="col-sm-12">

                        <div class="col-sm-12">
                            <asp:Repeater ID="rptTrainStation" runat="server" OnItemCommand="RptTrainStation_ItemCommand">
                                <HeaderTemplate>
                                    <table class="table table-responsive " style="width: 100%;">
                                        <tr style="background-color: #ED1C24; color: white">
                                            <th>Train</th>
                                            <th>Station</th>
                                            <th>Arrives-Departs</th>
                                            <th>Status</th>
                                            <th colspan="2">Actions</th>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label Text='<%#Eval("TC")+"-"+Eval("TN")%>' runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label Text='<%#Eval("SC")+"-"+Eval("SN")%>' runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label Text='<%#Eval("SAT")+"-"+Eval("SDT")%>' runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label Text='<%#Eval("ST")%>' runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton CausesValidation="false" runat="server" CssClass='<%#Eval("Status").ToString() == "True" ? "btn btn-success":"btn btn-warning" %>' CommandName="status" CommandArgument='<%#Eval("TSI")%>' ToolTip='<%#Eval("Status").ToString() == "True" ? "Status-ON":"Status-OFF" %>'>
                                    <center>
                                        <%#Eval("Status").ToString()=="True"?"<i class='fa fa-toggle-on'></i>":"<i class='fa fa-toggle-off'></i>" %>
                                    </center>    
                                            </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton CausesValidation="false" runat="server" CssClass="btn btn-primary" CommandName="edit" CommandArgument='<%#Eval("TSI")%>' ToolTip="Edit"><i class="fa fa-edit"></i></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
