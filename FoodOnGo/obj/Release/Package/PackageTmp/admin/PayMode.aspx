<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="PayMode.aspx.cs" Inherits="FoodOnGo.admin.PayMode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hid1" runat="server" />
    <div class="col-sm-12" style="width: 100%; height: 100%; border-radius: 10px 60px">
        <div class="row">
            <div class="col-sm-12">
                <div class="col-sm-2"></div>
                <div class="col-sm-8" style="margin-top: 1%; padding: 10px; background-color: white; border-bottom-style: groove; border-top: thin; border-radius: 500px">
                    <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-4">
                            <asp:Label ID="lbl" runat="server" Text="PayMode Name"></asp:Label>
                        </div>
                        <div class="col-sm-6">
                            <asp:TextBox ID="txtCName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-5"></div>
                        <div class="col-sm-4" style="padding-top: 1%;">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" OnClick="BtnSubmit_Click" Text="Submit"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
                <div class="col-sm-12" style="margin-top: 1%; padding: 1%; background-color: white; border-radius: 500px;">
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
                    <div class="row" style="padding-top: 2%;">
                        <div class="col-sm-12">
                            <div class="col-sm-2"></div>
                            <div class="col-sm-8">
                                <asp:Repeater ID="rptPayMode" runat="server" OnItemCommand="RptPayMode_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-responsive " style="width: 100%;">
                                            <tr style="background-color: #ED1C24; color: white; border-radius: 50px">
                                                <th>PayMode</th>
                                                <th>Status</th>
                                                <th>Actions</th>
                                            </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label Text='<%#Eval("PayModeName")%>' runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:LinkButton runat="server" CssClass='<%#Eval("Status").ToString() == "True" ? "btn btn-success":"btn btn-warning" %>' CommandName="status" CommandArgument='<%#Eval("PayModeId")%>' ToolTip='<%#Eval("Status").ToString() == "True" ? "Status-ON":"Status-OFF" %>'>
                                    <center>
                                        <%#Eval("Status").ToString()=="True"?"<i class='fa fa-toggle-on'></i>":"<i class='fa fa-toggle-off'></i>" %>
                                    </center>    
                                                </asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton runat="server" CssClass="btn btn-primary" CommandName="edit" CommandArgument='<%#Eval("PayModeId")%>' ToolTip="Edit"><i class="fa fa-edit"></i></asp:LinkButton>
                                                <asp:LinkButton runat="server" CssClass="btn btn-danger" CommandName="delete" CommandArgument='<%#Eval("PayModeId")%>' ToolTip="Delete"><i class="fa fa-trash-o"></i></asp:LinkButton>
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
