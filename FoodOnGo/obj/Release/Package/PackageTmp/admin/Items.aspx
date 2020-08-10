<%@ Page Title="" Language="C#" MasterPageFile="~/admin/main.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="FoodOnGo.admin.Items" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .imgHolder {
            position: relative;
            display: block;
        }

        .bimg-170 {
            background-repeat: no-repeat;
            width: auto;
            height: 150px;
            background-size: 100% 100%;
            box-shadow: 0 0 2px 2px #c2c2c2;
            border-radius: 5px;
        }

        .bimg-80 {
            background-repeat: no-repeat;
            width: auto;
            height: 80px;
            background-size: 100% 100%;
            box-shadow: 0 0 2px 2px #c2c2c2;
            border-radius: 5px;
        }

        .imgHolder .imageBoxPad {
            position: relative;
            right: 5px;
            top: 5px;
            padding: 1% 1%;
        }

        .imgHolder .imageBoxPad .removeImg {
            position: relative;
            height: 18px;
            width: 18px;
            padding: 0px;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hid1" runat="server" />
    <div class="col-sm-12" style="width: 100%; height: 100%; border-radius: 10px 60px">
        <div class="row">
            <div class="col-sm-12" style="margin-top: 1%; padding: 10px; background-color:rgba(255,255,255,0.6); border-bottom-style: groove; border-top: thin; border-radius: 500px">
                <div class="col-sm-8" style="padding-right: 0px; margin-right: 0px">
                    <div class="row">
                        <div class="col-lg-1">&nbsp;</div>
                    </div>
                    <asp:ScriptManager runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:HiddenField ID="hidImageNameGet" runat="server" />
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="col-sm-1"></div>
                                    <a style="position:absolute; right:22%; top:-75px; color:ActiveCaption;"><h1>Items</h1></a>
                                    <b>
                                    <div class="col-sm-4">
                                        <b>
                                        <asp:Label ID="lbl" runat="server" Text="Category Name"></asp:Label>
                                        </b>
                                            </div>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="ddlCategory" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                    <div>
                                        <h4 style="color: red">
                                            <asp:RequiredFieldValidator runat="server" ID="rfvCategory" ControlToValidate="ddlCategory" InitialValue="-Select Category-" ErrorMessage="*" ToolTip="Please Select Category"></asp:RequiredFieldValidator>
                                        </h4>
                                    </div>
                                        </b>
                                </div>
                            </div>
                            <div class="row" style="padding-top: 1%">
                                <div class="col-sm-12">
                                    <div class="col-sm-1"></div>
                                    <div class="col-sm-4"><b>
                                        <asp:Label ID="Label2" runat="server" Text="SubCategory Name"></asp:Label>
                                        </b>
                                        </div>
                                    <div class="col-sm-6">
                                        <b>
                                        <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </b>
                                            </div>
                                    <div>
                                        <h4 style="color: red">
                                            <asp:RequiredFieldValidator runat="server" ID="rfvSubCategory" ControlToValidate="ddlSubCategory" InitialValue="-Select SubCategory-" ErrorMessage="*" ToolTip="Please Select SubCategory..."></asp:RequiredFieldValidator>
                                        </h4>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row" style="padding-top: 1%">
                        <div class="col-sm-12">
                            <div class="col-sm-1"></div>
                            <div class="col-sm-4">
                                <b>
                                <asp:Label ID="Label1" runat="server" Text="Item Name"></asp:Label>
                                </b>
                                    </div>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtIName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div>
                                <h4 style="color: red">
                                    <asp:RequiredFieldValidator runat="server" ID="rfvIName" ControlToValidate="txtIName" ErrorMessage="*" ToolTip="Please Fill Item Name..."></asp:RequiredFieldValidator>
                                </h4>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 1%">
                        <div class="col-sm-12">
                            <div class="col-sm-1"></div>
                            <div class="col-sm-4">
                                <b>
                                    <asp:Label ID="Label3" runat="server" Text="Item Image"></asp:Label>
                                </b>
                                    </div>
                            <div class="col-sm-6"><b>
                                <asp:FileUpload ID="IImage" accept="image/*" runat="server" CssClass="form-control" AllowMultiple="false"></asp:FileUpload>
                                </b>
                                </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 1%">
                        <div class="col-sm-12">
                            <div class="col-sm-1"></div>
                            <div class="col-sm-4">
                                <b>
                                <asp:Label ID="Label4" runat="server" Text="Item Details"></asp:Label>
                                </b>
                                    </div>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtIDetails" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 1%">
                        <div class="col-sm-12">
                            <div class="col-sm-1"></div>
                            <div class="col-sm-4">
                                <b>
                                <asp:Label ID="Label5" runat="server" Text="Item Amount"></asp:Label>
                                </b>
                                    </div>
                            <div class="col-sm-6">
                                <asp:TextBox ID="txtIAmt" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div>
                                <h4 style="color: red">
                                    <asp:RequiredFieldValidator runat="server" ID="rfvIAmt" ControlToValidate="txtIAmt" ErrorMessage="*" ToolTip="Please Fill Item Amount..."></asp:RequiredFieldValidator>
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
                <div class="col-sm-3" style="padding-left: 0px; margin-left: 0px">
                    <div class="row">
                        <div class="col-sm-1" style="padding-bottom: 75px"></div>
                    </div>
                    <div class="row">
                        <div class="imgHolder col-sm-12">
                           <img id="imgFullSizePreview" src="images/no-image.png" class="bimg-170" />
                            <div class="imageBoxPad">
                                <input type="button" id="btnrem" class="btn btn-danger removeImg" onclick="RemoveImage()" value="X" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12" style="margin-top: 1%; padding: 1%; background-color:rgba(255,255,255,0.6); border-radius: 100px;">
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
                                        <asp:ListItem Value="50">50</asp:ListItem>
                                        <asp:ListItem Value="100">100</asp:ListItem>
                                         <asp:ListItem Value="200">200</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-6">
                                    <div class="text-left">
                                        <b>
                                        <asp:Literal ID="ltrRecordFound" runat="server"></asp:Literal>
                                        </b>
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
                    <div class="col-sm-12" style="padding: 2%">
                        <center>
                            <asp:Repeater ID="rptItem" runat="server" OnItemCommand="RptItem_ItemCommand">
                                <HeaderTemplate>
                                    <table class="table table-responsive " style="width: auto;">
                                        <tr style="background-color: #ED1C24; color: white; border-radius: 50px">
                                            <th>Type</th>
                                            <th>Item</th>
                                            <th>Image</th>
                                            <th style="width:200px">Details</th>
                                            <th>Amount</th>
                                            <th>Status</th>
                                            <th>Actions</th>
                                        </tr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <b>
                                    <tr>
                                        
                                        <td>
                                            <b><asp:Label Text='<%#Eval("CategoryName")+"-"+Eval("SubCategoryName")%>' runat="server"></asp:Label></b>
                                        </td>
                                        <td>
                                            <b><asp:Label Text='<%#Eval("ItemName")%>' runat="server"></asp:Label></b>
                                        </td>
                                        <td>
                                            <asp:Image runat="server" ImageUrl='<%# "~/item_img/"+Eval("ItemImage")%>' style="width:100px;height:auto"></asp:Image>
                                        </td>
                                        <td>
                                            <b><asp:Label Text='<%#Eval("ItemDetails")%>' runat="server"></asp:Label></b>
                                        </td>
                                        <td>
                                            <b><asp:Label Text='<%#Eval("ItemAmount")%>' runat="server"></asp:Label></b>
                                        </td>
                                        <td>
                                            <asp:LinkButton CausesValidation="false" runat="server" CssClass='<%#Eval("Status").ToString() == "True" ? "btn btn-success":"btn btn-warning" %>' CommandName="status" CommandArgument='<%#Eval("ItemId")%>' ToolTip='<%#Eval("Status").ToString() == "True" ? "Status-ON":"Status-OFF" %>'>
                                    <center>
                                        <%#Eval("Status").ToString()=="True"?"<i class='fa fa-toggle-on'></i>":"<i class='fa fa-toggle-off'></i>" %>
                                    </center>    
                                            </asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:LinkButton CausesValidation="false" runat="server" CssClass="btn btn-primary" CommandName="edit" CommandArgument='<%#Eval("ItemId")%>' ToolTip="Edit"><i class="fa fa-edit"></i></asp:LinkButton>
                                            <%--<asp:LinkButton runat="server" CssClass="btn btn-danger" CommandName="delete" CommandArgument='<%#Eval("ItemId")%>' ToolTip="Delete"><i class="fa fa-trash-o"></i></asp:LinkButton>--%>
                                        </td>
                                     </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </center>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnrem").hide();
        });
        $('#<%=IImage.ClientID%>').change(function () {
            $("#btnrem").show();
            var filename = $('#<%=IImage.ClientID%>').val();
            if (filename) {
                readUrl(this);
            }
            else {
                $('#imgFullSizePreview').attr('src', 'images/no-image.png');
                $("#btnrem").hide();
            }
        });

        if ($('#<%=hidImageNameGet.ClientID%>').val() != "") {
            debugger;

            $('#imgFullSizePreview').attr('src', '../item_img/' + $('#<%=hidImageNameGet.ClientID%>').val());
        }

        function readUrl(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgFullSizePreview').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
            else {
                $('#imgFullSizePreview').attr('src', 'images/no-image.png');
                $("#btnrem").hide();
            }
        }

        function RemoveImage() {
            $('#imgFullSizePreview').attr('src', 'images/no-image.png');
            $('#<%=IImage.ClientID%>').val("");
            $("#btnrem").hide();
        }
    </script>
</asp:Content>