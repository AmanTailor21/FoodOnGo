<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="FoodOnGo.admin.index" %>


<head runat="server">

    <title>Login</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link rel="icon" type="image/png" href="images/icons/favicon.ico" />

    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css">

    <link rel="stylesheet" type="text/css" href="css/font-awesome.css">

    <link rel="stylesheet" type="text/css" href="css/animate.css">

    <link rel="stylesheet" type="text/css" href="css/hamburgers.min.css">

    <link rel="stylesheet" type="text/css" href="css/select2.min.css">

    <link rel="stylesheet" type="text/css" href="css/util.css">
    <link rel="stylesheet" type="text/css" href="css/main.css">
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <div class="limiter">
                <div class="container-login100">
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="col-sm-2"></div>
                            <div class="col-sm-8">
                                <div class="row wrap-login100">
                                    <div class="col-sm-6">
                                        <div class="login100-pic js-tilt" data-tilt>
                                            <img src="FOG.png" alt="IMG">
                                        </div>
                                        </div>
                                    <div class="col-sm-6">
                                        <form class="login100-form validate-form">
                                            <span class="login100-form-title">Admin Login
                                            </span>

                                            <div class="wrap-input100 validate-input" data-validate="Valid email is required: ex@abc.xyz">
                                                <asp:TextBox runat="server" CssClass="input100" type="text" ID="txtEmailId" placeholder="Email"></asp:TextBox>
                                                <span class="focus-input100"></span>
                                                <span class="symbol-input100">
                                                    <i class="fa fa-envelope" aria-hidden="true"></i>
                                                </span>
                                            </div>

                                            <div class="wrap-input100 validate-input" data-validate="Password is required">
                                                <asp:TextBox runat="server" CssClass="input100" type="password"  ID="txtPassword"  placeholder="Password"></asp:TextBox>
                                                <span class="focus-input100"></span>
                                                <span class="symbol-input100">
                                                    <i class="fa fa-lock" aria-hidden="true"></i>
                                                </span>
                                            </div>

                                            <div class="container-login100-form-btn">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Login" class="login100-form-btn" />
                                               
                                            </div>
                                          
                                            <div class="text-center p-t-12" style="height:150px">
                                            </div>
                                             
                                        </form>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-2"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/popper.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/select2.min.js"></script>
    <script src="js/tilt.jquery.min.js"></script>
    <script>
        $('.js-tilt').tilt({
            scale: 1.1
        })
    </script>
    <script src="js/main.js"></script>
</body>

