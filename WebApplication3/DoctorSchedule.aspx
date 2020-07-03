<%@ Page Title="" Language="C#" MasterPageFile="~/ClinicMaster.Master" AutoEventWireup="true" CodeBehind="DoctorSchedule.aspx.cs" Inherits="WebApplication3.DoctorSchedule" %>
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
                            <h3>Doctor Sittings Schedule</h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    Select Day
                                     <asp:DropDownList ID="DropDownListDay" runat="server" class="form-control" DataTextField="Day" DataValueField="Day" AutoPostBack="True" DataSourceID="SqlDataSource3"  OnSelectedIndexChanged="DropDownListDay_SelectedIndexChanged" >
                                     </asp:DropDownList>
                                     <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RegistrationConnectionString %>" SelectCommand="SELECT DISTINCT [Day] FROM [TimeSlot]"></asp:SqlDataSource>
                                </div>
                                <div class="col-md-12">
                                    Select Start Time
                                    <asp:DropDownList ID="DropDownListSTime" runat="server" class="form-control" DataTextField="Start_Time" DataValueField="Start_Time">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-12">
                                    Select End Time
                                    <asp:DropDownList ID="DropDownListETime" runat="server" class="form-control" DataTextField="End_Time" DataValueField="End_Time">
                                    </asp:DropDownList>
                                </div>
                                 <div class="col-md-12">
                                    Maximum Visit
                                    <asp:TextBox ID="TextBoxMax" palceholder="Enter Maximum Visit" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="Button1" runat="server" Text="Add" cssClass="btn btn-success" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
   
</asp:Content>
