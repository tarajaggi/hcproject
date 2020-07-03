<%@ Page Title="" Language="C#" MasterPageFile="~/ClinicMaster.Master" AutoEventWireup="true" CodeBehind="BookSlotDoc.aspx.cs" Inherits="WebApplication3.BookSlotDoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="padding-top: 150px;">
            <div class="row">
                <div class="col-md-6 col-md-offset-3">
                    <div class="panel panel-success bg-info">
                        <div class="panel-header text-center">
                            <h3>Confirm Booking</h3>
                        </div>
                        <div class="panel-body">
                            <div class="row">
                              <div class="col-md-12">
                                  Available Seats
                                  <asp:TextBox ID="TextBoxcount" runat="server" class="form-control"></asp:TextBox>
                               </div>

                               <div class="col-md-12">
                                    <asp:Label ID="Labelinfo" runat="server" Text="Label"></asp:Label>
                               </div>

                                 <div class="col-md-12">
                                    <asp:Button ID="ButtonBook" runat="server" Text="Book" cssClass="btn btn-success" OnClick="ButtonBook_Click" />
                                    <asp:Button ID="ButtonGoBack" runat="server" Text="Go Back" Class="btn btn-success" OnClick="ButtonGoBack_Click" />
                               </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
