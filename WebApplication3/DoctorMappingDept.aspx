<%@ Page Title="" Language="C#" MasterPageFile="~/ClinicMaster.Master" AutoEventWireup="true" CodeBehind="DoctorMappingDept.aspx.cs" Inherits="WebApplication3.DoctorMappingDept" %>
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
                            <h3>Add Doctor to the Department</h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    Select Doctor
                                    <asp:DropDownList ID="DropDownListdoc" runat="server" DataSourceID="SqlDataSource1" DataTextField="Full_Name" DataValueField="Full_Name" class="form-control">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegistrationConnectionString %>" SelectCommand="SELECT DISTINCT [Full_Name] FROM [User_Reg_Details] WHERE ([Prefix] = @Prefix)">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="DOC" Name="Prefix" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="rfvDocId" runat="server" ControlToValidate="DropDownListdoc"
                                        ErrorMessage="*Select Doctor" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                    Select Department
                                    <asp:DropDownList ID="DropDownListdpt" runat="server" DataSourceID="SqlDataSource2" DataTextField="Dept_Name" DataValueField="Dept_Name" class="form-control">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RegistrationConnectionString %>" SelectCommand="SELECT DISTINCT [Dept_Name] FROM [Department]"></asp:SqlDataSource>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownListdpt"
                                        ErrorMessage="*Select Dept" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="ADD" OnClick="Button1_Click"  />
                                    <input id="Reset1" class="auto-style21" type="reset" value="reset" style="margin-left:20px;"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
   
</asp:Content>
