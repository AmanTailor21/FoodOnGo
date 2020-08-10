<%@ Page Title="" Language="C#" MasterPageFile="~/visitor.Master" AutoEventWireup="true" CodeBehind="ItemDetails.aspx.cs" Inherits="FoodOnGo.ItemDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    <asp:Repeater runat="server" ID="rptDetails" OnItemCommand="rptDetails_ItemCommand">
        <HeaderTemplate>
            <div class="inner_page-banner1 one-img" style="padding: 0px; margin: 0px;">
            </div>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="using-border py-3">
                <div class="inner_breadcrumb  ml-4">
                    <ul class="short_ls">
                        <li>
                            <a href="index.aspx">Home</a>
                            <span>/</span>
                        </li>
                        <li><%#Eval("ItemName")%></li>
                    </ul>
                </div>
            </div>

            <div class="banner-bottom py-lg-5 py-3">
                <div class="container">
                    <div class="inner-sec-shop pt-lg-4 pt-3">
                        <div class="row">
                            <div class="col-lg-4 single-right-left ">
                                <div class="grid images_3_of_2">
                                    <div class="flexslider1">
                                        <ul class="slides">
                                            <li data-thumb="images/f2.jpg">
                                                <div class="thumb-image">
                                                    <img src='/item_img/<%# Eval("ItemImage") %>' data-imagezoom="true" class="img-fluid" alt=" ">
                                                </div>
                                            </li>
                                        </ul>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-8 single-right-left simpleCart_shelfItem">
                                <h3><%#Eval("ItemName")%></h3>
                                <p>
                                    <span class="item_price">&#8377;<asp:Label ID="lblAmt" runat="server" Text='<%# Eval("ItemAmount")%>'></asp:Label></span>
                                </p>
                                <div class="occasional">
                                    <h4 style="color: black; font-size: 20px">Description</h4>
                                    <h5>
                                        <%#Eval("ItemDetails") %>
                                    </h5>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="occasion-cart">
                                    <div class="toys single-item singlepage">
                                        <a <%=Session["Email"]!=null?"":"href='Login.aspx'" %><asp:LinkButton ID="btnAdd" CssClass="btn font-weight-normal" Style="color: white" runat="server" CommandName="Add" CommandArgument='<%# Eval(" ItemId ") %>' BackColor="Black" Text="Add To Cart" /></a>
                                    </div>
                                </div>
                                <%--<ul class="footer-social text-left mt-lg-4 mt-3">
                                    <li>Share On : </li>
                                    <li class="mx-1">
                                        <a href="#">
                                            <span class="fab fa-facebook-f"></span>
                                        </a>
                                    </li>
                                    <li class="">
                                        <a href="#">
                                            <span class="fab fa-twitter"></span>
                                        </a>
                                    </li>
                                    <li class="mx-1">
                                        <a href="#">
                                            <span class="fab fa-google-plus-g"></span>
                                        </a>
                                    </li>
                                    <li class="">
                                        <a href="#">
                                            <span class="fab fa-linkedin-in"></span>
                                        </a>
                                    </li>
                                    <li class="mx-1">
                                        <a href="#">
                                            <span class="fas fa-rss"></span>
                                        </a>
                                    </li>
                                </ul>--%>
                            </div>
                            <div class="clearfix"></div>
                            <!--/tabs-->
                        </div>
                        <!--//tabs-->
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="row mb-5" style='margin-left: 300px; display: <%= Session["Email"]!=null?"block":"none"%>;'>
        <div class="col-sm-1"></div>
        <div class="col-sm-8 border" style="box-shadow:rgb(0,0,0) 3px 3px 5px ;">
            <div class="row ">
                <div class="col-sm-12">
                    <h3 class="text-center mt-2">Feedback</h3>
                </div>
            </div>
            <div class="row mt-2 mb-2">
                <div class="col-sm-2">
                    Title
                </div>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control col-sm-12" ID="txtfeedtitle"></asp:TextBox>
                </div>
            </div>
            <div class="row mt-2 mb-2">
                <div class="col-sm-2">
                    Description
                </div>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" CssClass="form-control col-sm-12" Height="100px" ID="txtfeedback" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="row mr-0 m-2">
                <div class="col-sm-10">
                    <asp:LinkButton runat="server" ID="btnFeed" OnClick="btnFeed_Click"  CssClass="btn btn-success">Submit Feedback</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>


    <script src="js/jquery-2.2.3.min.js"></script>
    <!-- newsletter modal -->
    <!-- cart-js -->
    <script src="js/minicart.js"></script>
    <script>
        toys.render();

        toys.cart.on('toys_checkout', function (evt) {
            var items, len, i;

            if (this.subtotal() > 0) {
                items = this.items();

                for (i = 0, len = items.length; i < len; i++) { }
            }
        });
    </script>
    <!-- //cart-js -->
    <!-- price range (top products) -->
    <script src="js/jquery-ui.js"></script>
    <script>
        //<![CDATA[ 
        $(window).load(function () {
            $("#slider-range").slider({
                range: true,
                min: 0,
                max: 9000,
                values: [50, 6000],
                slide: function (event, ui) {
                    $("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
                }
            });
            $("#amount").val("$" + $("#slider-range").slider("values", 0) + " - $" + $("#slider-range").slider("values", 1));

        }); //]]>
    </script>
    <!-- //price range (top products) -->
    <!-- single -->
    <script src="js/imagezoom.js"></script>
    <!-- single -->
    <!-- script for responsive tabs -->
    <script src="js/easy-responsive-tabs.js"></script>
    <script>
        $(document).ready(function () {
            $('#horizontalTab').easyResponsiveTabs({
                type: 'default', //Types: default, vertical, accordion           
                width: 'auto', //auto or any width like 600px
                fit: true, // 100% fit in a container
                closed: 'accordion', // Start closed if in accordion view
                activate: function (event) { // Callback function if tab is switched
                    var $tab = $(this);
                    var $info = $('#tabInfo');
                    var $name = $('span', $info);
                    $name.text($tab.text());
                    $info.show();
                }
            });
            $('#verticalTab').easyResponsiveTabs({
                type: 'vertical',
                width: 'auto',
                fit: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
