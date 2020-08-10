<%@ Page Title="" Language="C#" MasterPageFile="~/member/Main.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="FoodOnGo.member.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div class="checkout col-sm-12">
        <div class="row py-3">
            <div class="shop_inner_inf col-sm-12">
                <h2 style="text-align: center; padding: 15px"><i class="fa fa-shopping-cart"></i>Cart</h2>
                <asp:ScriptManager runat="server"></asp:ScriptManager>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="checkout-right row">
                            <table class="table" style="width: 100%">
                                <asp:Repeater ID="rptCart" OnItemCommand="rptCart_ItemCommand" runat="server">
                                    <HeaderTemplate>

                                        <tr style="background-color: black; color: white; height: 50px; text-align: center">
                                            <th style="width: auto">Remove</th>
                                            <th>Sr No.</th>
                                            <th style="width: auto;" colspan="2">Product</th>
                                            <th>Quantity</th>
                                            <th>Rate</th>
                                            <th>Price</th>
                                        </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr style="font-size: 20px; text-align: center">
                                            <td style="width: auto; padding-left: 20px">
                                                <asp:LinkButton CssClass="btn btn-danger" CommandName="del" CommandArgument='<%# Eval("ItemId")%>' runat="server">
                                            <i class="fa fa-times"></i>
                                                </asp:LinkButton>
                                            </td>
                                            <td style="width: auto;"><%# Eval("RecNo") %></td>
                                            <td style="width: auto">
                                                <a href="../ItemDetails.aspx?Id=<%# Eval("ItemId") %>">
                                                    <img src='../item_img/<%#Eval("ItemImage") %>' class="img-responsive img-thumbnail" style="height: 200px">
                                                </a>

                                            </td>
                                            <td style="text-align: left"><a href="../ItemDetails.aspx?Id=<%# Eval("ItemId") %>" style="color: black"><%# Eval("ItemName") %></a></td>
                                            <td>
                                                <div class="col-sm-12">
                                                    <div class="row ">
                                                        <div class="col-sm-4" style="padding-right: 0px; margin-right: 10px">
                                                            <asp:LinkButton CssClass="btn btn-dark" CommandName="qtyChange" CommandArgument='<%# (Convert.ToInt32(Eval("Quantity")) - 1)+":"+Eval("ItemId") %>' runat="server">
                                            <i class="fa fa-minus"></i>
                                                            </asp:LinkButton>
                                                        </div>
                                                        <div class="col-sm-3 text-center" style="padding-left: 0px"><%# Eval("Quantity") %></div>
                                                        <div class="col-sm-4" style="padding: 0px; margin-right: 0px">
                                                            <asp:LinkButton CssClass="btn btn-dark" CommandName="qtyChange" CommandArgument='<%# (Convert.ToInt32(Eval("Quantity")) + 1)+":"+Eval("ItemId") %>' runat="server">
                                            <i class="fa fa-plus"></i>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                            <td style="width: 80px;">&#8377;<%# Eval("Rate") %></td>
                                            <td style="width: 120px;">&#8377;<%# Eval("Amount") %></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <tr style="background-color: black; color: white; height: 50px; text-align: center">
                                    <td colspan="5"></td>
                                    <td>
                                        <h3><asp:Label runat="server" ID="Label1"></asp:Label></h3>
                                    </td>
                                    <td>
                                        <h2>
                                            <asp:Label runat="server" ID="lblTotal"></asp:Label></h2>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <hr />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row">
                    <div class="col-md-5"></div>
                    <div class="col-md-2 address_form">
                        <asp:LinkButton runat="server" ID="btnOrder" CssClass="btn col-sm-12" BackColor="Black" OnClick="btnOrder_Click">Proceed To Order</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
