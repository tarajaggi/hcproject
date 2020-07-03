<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RPage.aspx.cs" Inherits="WebApplication3.RPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Healthcare | Signin</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <style type="text/css">
        body{
            background-image:url('login-background.png');
            background-size:cover;
        }

        .col-md-12{
            padding-bottom:10px;
        }

        .col-md-4{
            padding-bottom:10px;
        }

        .col-md-6{
            padding-bottom:10px;
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
                            <h3><i class="glyphicon glyphicon-user"></i>&nbsp;Health Care Registration </h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4">
                                    First Name
                                    <asp:TextBox ID="TextBoxFname" runat="server" placeholder="First name" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFN" runat="server" ControlToValidate="TextBoxFname" 
                                        ErrorMessage="*First Name is Required Field" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    Middle Name
                                    <asp:TextBox ID="TextBoxMName" runat="server" placeholder="Middle name" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    Last Name
                                    <asp:TextBox ID="TextBoxLName" runat="server" placeholder="Last name" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLN" runat="server" ControlToValidate="TextBoxLname" 
                                        ErrorMessage="*Last Name is Required Field" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6">
                                    Gender
                                    <asp:DropDownList ID="DropDownListGender" runat="server" class="form-control">
                                        <asp:ListItem>SELECT</asp:ListItem>
                                        <asp:ListItem Value="M">MALE</asp:ListItem>
                                        <asp:ListItem Value="F">FEMALE</asp:ListItem>
                                        <asp:ListItem Value="T">OTHER</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="DropDownListGender" 
                                        ErrorMessage="*Gender is Required Field" ForeColor="Red" InitialValue="Select" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6">
                                    Age
                                    <asp:TextBox ID="TextBoxAge" runat="server" placeholder="Age" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAge" runat="server" ControlToValidate="TextBoxAge" 
                                        ErrorMessage="*Age is Required Field" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="TextBoxAge" 
                                        ErrorMessage="*Impossible Age" ForeColor="Red" MaximumValue="110" MinimumValue="1" Type="Integer" Display="Dynamic"></asp:RangeValidator>
                                </div>
                                <div class="col-md-12">
                                    Address
                                    <asp:TextBox ID="TextBoxaddress" runat="server" placeholder="Enter the Address" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvAddr" runat="server" ControlToValidate="TextBoxaddress"
                                        ErrorMessage="*Enter Address" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                    Contact Number
                                    <asp:TextBox ID="TextBoxCNo" runat="server" placeholder="Enter Your Number" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvcno" runat="server" ControlToValidate="TextBoxCNo"
                                        ErrorMessage="*Enter the number" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revcno" runat="server" ControlToValidate="TextBoxCNo" 
                                        ErrorMessage="*Enter 10 digit Mobile No." ValidationExpression="[0-9]{10}" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-12">
                                    Role
                                    <asp:DropDownList ID="DropDownListRole" runat="server" class="form-control">
                                        <asp:ListItem>SELECT</asp:ListItem>
                                        <asp:ListItem Value="AD">ADMIN</asp:ListItem>
                                        <asp:ListItem Value="DOC">DOCTOR</asp:ListItem>
                                        <asp:ListItem Value="PAT">PATIENT</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvrole" runat="server" ControlToValidate="DropDownListRole"
                                        ErrorMessage="*Select your Role" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                    Email ID
                                    <asp:TextBox ID="TextBoxmail" runat="server" placeholder="Enter Your Mail ID" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMail" runat="server" ControlToValidate="TextBoxmail"
                                        ErrorMessage="*Enter the mail ID" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revMail" runat="server" ControlToValidate="TextBoxmail" 
                                        ErrorMessage="*Enter correct mail ID" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-12">
                                    Password
                                    <asp:TextBox ID="TextBoxpass" runat="server" placeholder="Enter the Password" TextMode="Password" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="TextBoxpass"
                                        ErrorMessage="*Enter Password" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                    Confirm Password
                                    <asp:TextBox ID="TextBoxCPass" runat="server" placeholder="Re-enter the Password" TextMode="Password" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvCPass" runat="server" ControlToValidate="TextBoxCPass"
                                        ErrorMessage="*Enter Password Again" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidatorcpass" runat="server" ControlToCompare="TextBoxpass" ControlToValidate="TextBoxCPass" 
                                        ErrorMessage="*Both Password must be same" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="ButtonSubmit" runat="server" CssClass="btn btn-success" Text="Submit" OnClick="ButtonSubmit_Click" />
                                    <input id="Reset1" type="reset" value="reset" class="btn bg-success"/>
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
