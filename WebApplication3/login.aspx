<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication3.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Healthcare | Login</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <style type="text/css">
        body{
            background-image:url('login-background.png');
            background-size:cover;
        }
        .col-md-12{
            padding-bottom:20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container" style="padding-top: 150px;">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="panel panel-success bg-info">
                        <div class="panel-header text-center">
                            <h3><i class="glyphicon glyphicon-log-in"></i>&nbsp;Login to continue </h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    User Id
                                    <asp:TextBox ID="TextBoxuid" runat="server" placeholder="Enter the User ID" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvUserId" runat="server" ControlToValidate="TextBoxuid"
                                        ErrorMessage="*Enter user_id" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                    Password
                                    <asp:TextBox ID="TextBoxpass" runat="server" placeholder="Enter the Password" TextMode="Password" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="TextBoxpass"
                                        ErrorMessage="*Enter Password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="Button_login" runat="server" CssClass="btn btn-success" Text="Login" OnClick="Button_login_Click" />
                                </div>
                                <div class="col-md-12">
                                    <a href="RPage.aspx">New User Register Here!!</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
