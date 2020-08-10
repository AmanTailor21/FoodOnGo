<%@ Page Title="" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="FoodOnGo.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">
    <div style="padding-top: 20%; width: 100%">
        <asp:Repeater ID="rptItems" runat="server" OnItemCommand="rptItems_ItemCommand">
            <HeaderTemplate>
                <div class="left-ads-display col-lg-12">
                    <div class="row">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col-lg-3 col-md-6 col-sm-6 product-men women_two">
                    <div class="product-toys-info">
                        <div class="men-pro-item">
                            <div class="men-thumb-item">
                                <img src='../item_img/<%#Eval("ItemImage") %>' class="img-thumbnail img-fluid" alt="">
                                <div class="men-cart-pro">
                                    <div class="inner-men-cart-pro">
                                        <a href="ItemDetails.aspx?Id=<%#Eval("ItemId") %>" class="link-product-add-cart">Quick View</a>
                                    </div>
                                </div>
                                <span class="product-new-top">New</span>
                            </div>
                            <div class="item-info-product">
                                <div class="info-product-price">
                                    <div class="grid_meta">
                                        <div class="product_price">
                                            <h4>
                                                <a href="single.html"><%#Eval("ItemName") %></a>
                                            </h4>
                                            <div class="grid-price mt-2">
                                                <span class="money">&#8377;<%#Eval("ItemAmount") %></span>
                                            </div>
                                        </div>
                                        <%--<ul class="stars">
                                            <li>
                                                <a href="#">
                                                    <i class="fas fa-star"></i>
                                                </a>
                                            </li>
                                            <li>
                                                <a href="#">
                                                    <i class="fas fa-star"></i>
                                                </a>
                                            </li>
                                            <li>
                                                <a href="#">
                                                    <i class="fas fa-star"></i>
                                                </a>
                                            </li>
                                            <li>
                                                <a href="#">
                                                    <i class="fas fa-star"></i>
                                                </a>
                                            </li>
                                            <li>
                                                <a href="#">
                                                    <i class="fas fa-star-half"></i>
                                                </a>
                                            </li>
                                        </ul>--%>
                                    </div>
                                    <div class="toys single-item hvr-outline-out">
                                        <form action="#" method="post">
                                            <a <%=Session["User"]!=null?"":"href='Login.aspx'" %>
                                                <asp:LinkButton runat="server" CommandName="Add" CommandArgument='<%# Eval("ItemId") %>' CssClass="toys-cart ptoys-cart" BackColor="Black" Width="50px" Height="50px">
                                                <i style="padding:10px 10px 10px 8px;margin:0px" class="fa fa-cart-plus"></i>
                                                </asp:LinkButton>
                                            </a>
                                        </form>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
