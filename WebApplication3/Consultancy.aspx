<%@ Page Title="" Language="C#" MasterPageFile="~/ClinicMaster.Master" AutoEventWireup="true" CodeBehind="Consultancy.aspx.cs" Inherits="WebApplication3.Consultancy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .col-md-12 {
            padding-bottom: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">


        <h3>Book Your Appointment</h3>


        <div class="row">
            <div class="col-md-3">
                Select Date

                <div class="row">
                    <div class="col-md-10" style="padding-right:1px;">
                        <asp:TextBox ID="TextBoxDate" runat="server" class="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-2" style="padding-left:1px;">
                        <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" ImageUrl="~/Calender.jpg" OnClick="ImageButton1_Click" Width="25px" />
                    </div>
                </div>

                <asp:HiddenField ID="HiddenFieldDay" runat="server" />
                <asp:HiddenField ID="HiddenFieldMonth" runat="server" />
                <asp:Calendar ID="Calendar1" runat="server" OnDayRender="Calendar1_DayRender" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
            </div>
            <div class="col-md-3">
                Select Department
                <asp:DropDownList ID="DropDownListDept" class="form-control" runat="server" DataSourceID="SqlDataSource1" DataTextField="Dept_Name" DataValueField="Dept_Name" OnSelectedIndexChanged="DropDownListDept_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                <asp:HiddenField ID="HiddenFieldDpt" runat="server" />
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RegistrationConnectionString %>" SelectCommand="SELECT DISTINCT [Dept_Name] FROM [Department]"></asp:SqlDataSource>
            </div>
            <div class="col-md-3">
                Select Your Preference
                <br />
                <asp:RadioButton ID="RadioButtonTS" runat="server" Text="Time-Slot" GroupName="Option" AutoPostBack="True" OnCheckedChanged="RadioButtonTS_CheckedChanged" />

                <asp:RadioButton ID="RadioButtonDoc" runat="server"
                    Text="Doctor" GroupName="Option" AutoPostBack="True" OnCheckedChanged="RadioButtonDoc_CheckedChanged" />
                
                <asp:HiddenField ID="HiddenFieldTS" runat="server" />
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="DropDownListTS" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownListTS_SelectedIndexChanged" Visible="false">
                </asp:DropDownList>

                <asp:DropDownList ID="DropDownListDoc" runat="server" class="form-control" AutoPostBack="True" Visible="False" DataSourceID="SqlDataSource2" DataTextField="Full_Name" DataValueField="Full_Name" OnSelectedIndexChanged="DropDownListDoc_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:HiddenField ID="HiddenFieldDoc" runat="server" />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RegistrationConnectionString %>" SelectCommand="SELECT [Full_Name] FROM [User_Reg_Details] WHERE ([Prefix] = @Prefix)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="DOC" Name="Prefix" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>

        </div>
        <br />
        <div class="row">
            <div class="col-md-6">
                
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                                            <table class="table table-bordered table-condensed">
                                                <tr>
                                                    <th>Sitting-Time
                                                    </th>
                                                    
                                                    <th>Book
                                                    </th>
                                                </tr>
                                        </HeaderTemplate>
                    <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelTime" runat="server" Text='<%# Eval("Start_Time") %>'></asp:Label>
                                                </td>

                                                <td>
                                                    <a href='BookSlotDoc.aspx?id=<%# Eval("TS_ID") %>' target='_ '>View </a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                </asp:Repeater>
                                    <asp:Repeater ID="Repeater2" runat="server">
                                        <HeaderTemplate>
                                            <table class="table table-bordered table-condensed">
                                                <tr>
                                                    <th>Doctor
                                                    </th>
                                                    <th>Seat
                                                    </th>
                                                    <th>Book
                                                    </th>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LabelDoc" runat="server" Text='<%# Eval("Full_Name") %>'></asp:Label>
                                                </td>

                                                <td>
                                                    <asp:Label ID="LabelSeat" runat="server" Style="text-align: center" Text='<%# Eval("Max_Visit") %>'></asp:Label>
                                                </td>

                                                <td>
                                                    <a href='BookSlot.aspx?id=<%# Eval("User_id") %>' target='_ '>View </a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
            </div>
           
        </div>



    </div>

</asp:Content>
