﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="SubCategory.aspx.cs" Inherits="FoodOnGo.admin.SubCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hid1" runat="server" />
    <div class="col-sm-12" style="width: 100%; height: 100%; border-radius: 10px 60px">
        <div class="row">
            <div class="col-sm-12">
                <a style="position:absolute; right:36%; top:-35px; color:ActiveCaption;"><h1>Sub-Category</h1></a>
                <div class="col-sm-2"></div>
                <div class="col-sm-8" style="margin-top: 1%; padding: 10px;background-color:rgba(255,255,255,0.5); border-bottom-style: groove; border-top: thin; border-radius: 500px">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-1"></div>
                            <div class="col-sm-4">
                                <b><asp:Label ID="lbl" runat="server" Text="Category Name"></asp:Label></b>
                            </div>
                            <div class="col-sm-6">
                                <b><asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"></asp:DropDownList></b>
                            </div>
                            <div>
                                <h4 style="color: red">
                                    <asp:RequiredFieldValidator runat="server" ID="rfvCategory" ControlToValidate="ddlCategory" InitialValue="-Select Category-" ErrorMessage="*" ToolTip="Please Select Category Name..."></asp:RequiredFieldValidator>
                                </h4>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 1%">
                        <div class="col-sm-12">
                            <div class="col-sm-1"></div>
                            <div class="col-sm-4">
                                <b>
                                <asp:Label ID="Label1" runat="server" Text="SubCategory Name"></asp:Label>
                                    </b>
                            </div>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtSCName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div>
                                <h4 style="color: red">
                                    <asp:RequiredFieldValidator runat="server" ID="rfvSubCategory" ControlToValidate="txtSCName" ErrorMessage="*" ToolTip="Please Fill SubCategory Name..."></asp:RequiredFieldValidator>
                                </h4>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="col-sm-5"></div>
                            <div class="col-sm-2" style="padding-top: 1%;">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" OnClick="BtnSubmit_Click" Text="Submit"></asp:Button>
                            </div>
                            <div class="col-sm-4" style="padding-top: 10px">
                                <asp:Label ID="lblWarn" runat="server" CssClass="text-danger" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12" style="margin-top: 1%; padding: 1%; background-color:rgba(255,255,255,0.5); border-radius: 250px;">
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
                                        <b><asp:Literal ID="ltrRecordFound" runat="server"></asp:Literal></b>
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
                        <div class="col-sm-2"></div>
                        <div class="col-sm-8">
                            <asp:Repeater ID="rptSubCategory" runat="server" OnItemCommand="RptSubCategory_ItemCommand">
                                <HeaderTemplate>
                                    <table class="table table-responsive" style="width: 100%; ">
                                        <tr style="background-color: #ED1C24; color: white; border-radius: 50px">
                                            <th>Category</th>
                                            <th>SubCategory</th>
                                            <th>Status</th>
                                            <th>Actions</th>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <b><asp:Label Text='<%#Eval("CategoryName")%>' runat="server"></asp:Label></b>
                                        </td>
                                        <td>
                                            <b><asp:Label Text='<%#Eval("SubCategoryName")%>' runat="server"></asp:Label></b>
                                        </td>
                                        <td>
                                            <asp:LinkButton CausesValidation="false" runat="server" CssClass='<%#Eval("Status").ToString() == "True" ? "btn btn-success":"btn btn-warning" %>' CommandName="status" CommandArgument='<%#Eval("SubCategoryId")%>' ToolTip='<%#Eval("Status").ToString() == "True" ? "Status-ON":"Status-OFF" %>'>
                                    <center>
                                        <%#Eval("Status").ToString()=="True"?"<i class='fa fa-toggle-on'></i>":"<i class='fa fa-toggle-off'></i>" %>
                                    </center>    
                                            </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton CausesValidation="false" runat="server" CssClass="btn btn-primary" CommandName="edit" CommandArgument='<%#Eval("SubCategoryId")%>' ToolTip="Edit"><i class="fa fa-edit"></i></asp:LinkButton>
                                            <asp:LinkButton CausesValidation="false" runat="server" CssClass="btn btn-danger" CommandName="delete" CommandArgument='<%#Eval("SubCategoryId")%>' ToolTip="Delete"><i class="fa fa-trash-o"></i></asp:LinkButton>
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