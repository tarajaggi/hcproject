
<%@ Page Title="" Language="C#" MasterPageFile="~/ClinicMaster.Master" AutoEventWireup="true" CodeBehind="TimeSlotUpload.aspx.cs" Inherits="WebApplication3.TimeSlotUpload" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="ctk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .col-md-6{
            padding-bottom:10px;
        }
        .col-md-12{
            padding-bottom:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="container" style="padding-top: 150px;">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="panel panel-success bg-info">
                        <div class="panel-header text-center">
                            <h3>Add Hospital Consultancy Schedule</h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    Day
                                     <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>Monday</asp:ListItem>
                                        <asp:ListItem>Tuesday</asp:ListItem>
                                        <asp:ListItem>Wednesday</asp:ListItem>
                                        <asp:ListItem>Thursday</asp:ListItem>
                                        <asp:ListItem>Friday</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvday" runat="server" ControlToValidate="DropDownList1" 
                                        ErrorMessage="*Required Field" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6">
                                    Start Time
                                    <ctk:TimeSelector ID="TimeSelector1" runat="server" DisplaySeconds="false" ></ctk:TimeSelector>
                                </div>
                                <div class="col-md-6">
                                    End Time
                                    <ctk:TimeSelector ID="TimeSelector2" runat="server" DisplaySeconds="false" ></ctk:TimeSelector>
                                </div>
                                <div class="col-md-12">
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" CssClass="btn btn-success" />
                                    <input id="Reset1" class="auto-style22" type="reset" value="reset" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    
</asp:Content>
