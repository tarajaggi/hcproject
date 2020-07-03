<%@ Page Title="" Language="C#" MasterPageFile="~/ClinicMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplication3.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .col-md-4{
            box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.9);
            transition: box-shadow .5s, background 4s;
            width: 550px;
            height: 450px;
            margin: 15px;
        }
        .col-md-4:hover{     
          box-shadow: 5px 5px 15px rgba(0, 0, 0, 0.9);
          background: skyblue;
        }
        .row{
            margin-top: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container" style="padding-top: 50px;">
            <div class="row">
                <div class="col-md-4">
                    <h3>Medical Services That You Can Trust</h3>
                    <img src="HCBG.jpg" style="height:350px; width:520px"  />
                    <div>
                        Staff members (Admin, Doctor etc.) and patients can interact with each other through Health Care websites without any glitches.
                    </div>
                </div>
            
                <div class="col-md-4">
                    <h3>We Care About Your Health</h3>
                    <img src="Care.jpg" style="height:350px; width:520px"  />
                    <div>
                        Find reliable doctors and experts for your diagnosis.
                    </div>
                </div>
             </div>   
            <div class="row">
                <div class="col-md-4">
                    <h3>Faithful Treatment</h3>
                    <img src="Operation.jpg" style="height:350px; width:520px"  /> 
                    <div>
                        Get best treatment available after accurate diagnosis with pre and post tests and analysis of condition.
                    </div>
                </div>
            
                <div class="col-md-4">
                    <h3>Departments</h3>
                    <img src="Department.jpg" style="height:350px; width:520px"  /> 
                    <div>
                        All the medical departments including specialists of every arenas, pathology, dispensary etc. will be at your disposal.
                    </div>
                </div>
               </div>
             <div class="row">
                <div class="col-md-4 ">
                    <h3>Appointment</h3>
                    <img src="Appointment.jpg" style="height:350px; width:520px"  /> 
                    <div>
                        Patients can easily book appointments with any department as per their necessity without having to wait for your turn.
                    </div>
                </div>
              </div>
        </div>
            
      
    
    <div class="container" style="padding-top: 100px;">
            
        </div>
</asp:Content>
