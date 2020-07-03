<%@ Page Title="" Language="C#" MasterPageFile="~/ClinicMaster.Master" AutoEventWireup="true" CodeBehind="Dept.aspx.cs" Inherits="WebApplication3.Dept" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .col-md-12{
            padding-bottom:20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="padding-top: 150px;">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="panel panel-success bg-info">
                        <div class="panel-header text-center">
                            <h3>Add Department</h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                              <div class="col-md-12">
                                    Department ID
                                    <asp:TextBox ID="TextBoxdptId" runat="server" placeholder="Enter the Department ID" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvdptId" runat="server" ControlToValidate="TextBoxdptId"
                                        ErrorMessage="*Enter Dept_id" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                    Department Name
                                    <asp:TextBox ID="TextBoxdptname" runat="server" placeholder="Enter the Department ID" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvdptname" runat="server" ControlToValidate="TextBoxdptname"
                                        ErrorMessage="*Enter Dept Name" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                    Department Abbreviation
                                    <asp:TextBox ID="TextBoxAbb" runat="server" placeholder="Enter the Department ID" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxAbb"
                                        ErrorMessage="*Enter Dept Abbreviation" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="ButtonSubmit" runat="server" CssClass="btn btn-success" Text="Add" OnClick="ButtonSubmit_Click1" />
                                    <input id="Reset1" type="reset" value="reset"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    
</asp:Content>
