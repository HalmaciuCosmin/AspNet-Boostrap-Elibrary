<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserSignUp.aspx.cs" Inherits="WebApplication1.UserSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--  container/row/ (col) / card/cardbody/(row-col)  -->

     <div class="container">
       <div class="row">
           <div class="col-md-8 mx-auto">
               <!-- card (conturul)  -->
               <div class="card">
                   <div class="card-body">
                       <div class="row">
                           <div class="col">                                                        
                            <center><img width="100px" src="img/generaluser.png" /> </center>                       
                           </div>
                       </div> 

                        <div class="row">
                           <div class="col">                     
                            <center><h4>Member Sign Up</h4></center> 
                           </div>
                       </div> 

                       <div class="row">
                           <div class="col">                     
                            <hr /> 
                           </div>
                       </div> 

                        <div class="row">
                           <div class="col-md-6">              
                               <label>Full Name</label>
                           <div class="form-group">
                                  <asp:TextBox  CssClass="form-control" ID="FullName_Label" runat="server" placeholder="Full Name"></asp:TextBox>
                              </div>
                           </div>
                            <div class="col-md-6">
                                <label>Date of Birth</label>
                             <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="BirtDate_Label" runat="server" placeholder="dd-mm-yyyy" Wrap="True" TextMode="Date"></asp:TextBox>
                              </div>
                           </div>
                       </div> 

                       <div class="row">
                           <div class="col-md-6">              
                               <label>Contact Number</label>
                           <div class="form-group">
                                  <asp:TextBox  CssClass="form-control" ID="ContactNumber_Label" runat="server" placeholder="Contact Number"></asp:TextBox>
                              </div>
                           </div>
                            <div class="col-md-6">
                                <label>Email</label>
                             <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="Email_Label" runat="server" placeholder="Email" Wrap="True"></asp:TextBox>
                              </div>
                           </div>
                       </div> 

                       <div class="row">
                           <div class="col-md-4">
                               <label>Country</label>
                               <div class="form-group">
                                   <asp:DropDownList CssClass="form-control" ID="Country_DropDown" runat="server">
                                       <asp:ListItem Text ="Romania" Value="Romania" />
                                       <asp:ListItem Text ="USA" Value="USA" />
                                       <asp:ListItem Text ="Canada" Value="Canada" />
                                       <asp:ListItem Text ="Germany" Value="Germany" />
                                       <asp:ListItem Text ="Italy" Value="Italy" />
                                   </asp:DropDownList>
                               </div>
                              
                           </div>
                            <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="City_Label" runat="server" placeholder="City" Wrap="True"></asp:TextBox>
                              </div>
                           </div>   
                            <div class="col-md-4">
                                <label>Pin Code</label>
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="PinCode_Label" runat="server" placeholder="Pin Code" Wrap="True"></asp:TextBox>
                              </div>
                           </div>   
                          
                       </div> 

                       
                           <div class="row">
                               <div class="col-md-12">
                                   <label>Full Adress</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="FullAdress_Label"  placeholder="Full Adress" runat="server" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                    </div>
                               </div>
                           </div>

                            <div class="row">
                                <div class="col">
                                    <center><span class="badge badge-pill badge-info">LogIn Data</span></center>
                                </div>
                            </div>

                                <br />

                           <div class="row">
                             <div class="col-md-6">
                                <label>User Id</label>
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="UserId_Label" runat="server" placeholder="User Id" Wrap="True"></asp:TextBox>
                              </div>
                           </div>  
                              <div class="col-md-6">
                                <label>Password</label>
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="Password_Label" runat="server" placeholder="Password" Wrap="True" TextMode="Password"></asp:TextBox>
                                </div>
                             </div>  
                           </div>

                       <div class="row">
                             <div class="col-md-12">
                                  <div class="form-group">
                                   <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="SignIn" runat="server" Text="Sign In" OnClick="SignIn_Click"  />
                               </div> 
                           </div>  
                        </div>
                       
               <a href="Home.aspx"> << Back To Home</a><br /> <br />
                    
               </div>
           </div>
               </div>
         </div>
       </div>
</asp:Content>
