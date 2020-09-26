<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="WebApplication1.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
       <div class="row">
           <div class="col-md-6 mx-auto">
               <!-- card (conturul)  -->
               <div class="card">
                   <div class="card-body">
                       <div class="row">
                           <div class="col">                                                        
                            <center><img width="150px" src="img/adminuser.png" /></center>                       
                           </div>
                       </div> 

                        <div class="row">
                           <div class="col">                     
                            <center><h3>Admin Login</h3></center> 
                           </div>
                       </div> 

                       <div class="row">
                           <div class="col">                     
                            <hr />
                           </div>
                       </div> 
                       
                        <div class="row">
                           <div class="col">
                               
                               <!--  btn-info / btn-primary / btn-success (culoarea)  -->
                               <!--  btn-block (ocupa tot spatiul)  -->
                               <!--  btn-lg (dimensiunea) -->

                             
                              <div class="form-group">
                                  <asp:TextBox  CssClass="form-control" ID="TextBox_Email" runat="server" placeholder="Email"></asp:TextBox>
                              </div>
                      
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox_Password" runat="server" placeholder="Password" Wrap="True" TextMode="Password"></asp:TextBox>
                              </div>

                               <div class="form-group">
                                   <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Log In" OnClick="Button1_Click"  />
                               </div> 
                            </div>
                           </div>
                       </div> 
                   </div>
               <a href="Home.aspx"> << Back To Home</a><br /> <br />
                    
               </div>
           </div>
       </div>

</asp:Content>
