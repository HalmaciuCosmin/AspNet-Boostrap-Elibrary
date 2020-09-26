<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="WebApplication1.UserLogin" %>
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
                            <center><img width="150px" src="img/generaluser.png" /> </center>                       
                           </div>
                       </div> 

                        <div class="row">
                           <div class="col">                     
                            <center><h3>Member Login</h3></center> 
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

                               <label>Member ID</label>
                              <div class="form-group">
                                  <asp:TextBox  CssClass="form-control" ID="TextBox_ID" runat="server" placeholder="Member ID"></asp:TextBox>
                              </div>

                               <label>Password</label>
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="TextBox_Pass" runat="server" placeholder="Password" Wrap="True" TextMode="Password"></asp:TextBox>
                              </div>

                               <div class="form-group">
                                   <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="LogIn" runat="server" Text="Log In" OnClick="LogIn_Click"  />
                               </div>
                               <div class="form-group">
                                   <a href="UserLogin.aspx"><input class="btn btn-info btn-block btn-lg" id="SignUp" type="button" value="Sign Up" /></a>
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
