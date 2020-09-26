<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="WebApplication1.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgview').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
    <!--  container/row/ (col) /card/cardbody/(row-col)  -->

    <div class="container-fluid">
       <div class="row">
           <div class="col-md-5">
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
                            <center><h4>Your Profile</h4></center> 
                            <center> <span>Account Status - </span> 
                                <asp:Label CssClass="badge badge-pill badge-primary" ID="Label1" runat="server"  Text="Your Status"></asp:Label>
                            </center>
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
                                  <asp:TextBox  CssClass="form-control" ID="FullName_TextBox" runat="server" Wrap="True" placeholder="Full Name"></asp:TextBox>
                              </div>
                           </div>
                            <div class="col-md-6">
                                <label>Date of Birth</label>
                             <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="BirtDate_TextBox" runat="server" placeholder="dd-mm-yyyy" Wrap="True" TextMode="Date"></asp:TextBox>
                              </div>
                           </div>
                       </div> 

                       <div class="row">
                           <div class="col-md-6">              
                               <label>Contact Number</label>
                           <div class="form-group">
                                  <asp:TextBox  CssClass="form-control" ID="ContactNumber_TextBox" runat="server" Wrap="True"  placeholder="Contact Number"></asp:TextBox>
                              </div>
                           </div>
                            <div class="col-md-6">
                                <label>Email</label>
                             <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="Email_TextBox" runat="server" placeholder="Email" Wrap="True"></asp:TextBox>
                              </div>
                           </div>
                       </div> 

                       <div class="row">
                           <div class="col-md-4">
                               <label>Country</label>
                               <div class="form-group">
                                   <asp:DropDownList CssClass="form-control" ID="DropDownList_Country" runat="server">
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
                                  <asp:TextBox CssClass="form-control" ID="City_TextBox" runat="server" placeholder="City" Wrap="True"></asp:TextBox>
                              </div>
                           </div>   
                            <div class="col-md-4">
                                <label>Pin Code</label>
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="PinCode_TextBox" runat="server" placeholder="Pin Code" Wrap="True"></asp:TextBox>
                              </div>
                           </div>   
                          
                       </div> 

                       
                           <div class="row">
                               <div class="col-md-12">
                                   <label>Full Adress</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="FullAdress_TextBox"  placeholder="Full Adress" runat="server" Wrap="True" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                    </div>
                               </div>
                           </div>

                            <div class="row">
                                <div class="col">
                                    <center><span class="badge badge-pill badge-info">Log In Data</span></center>
                                </div>
                            </div>

                                <br />

                           <div class="row">
                             <div class="col-md-4">
                                <label>User Id</label>
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="UserID_TextBox" runat="server" placeholder="User Id" Wrap="True" ReadOnly="True"></asp:TextBox>
                              </div>
                           </div>  
                              <div class="col-md-4">
                                <label>Old Password</label>
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="OldPassword" runat="server" placeholder="Password" Wrap="True" ReadOnly="True"></asp:TextBox>
                                </div>
                             </div>  
                                <div class="col-md-4">
                                <label>New Password</label>
                                <div class="form-group">
                                  <asp:TextBox CssClass="form-control" ID="NewPassword" runat="server" placeholder="Password" Wrap="True" ></asp:TextBox>
                                </div>
                             </div>  
                           </div>

                       <div class="row">
                             <div class="col-md-12">
                                  <div class="form-group">
                                   <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="Update" runat="server" Text="Update" OnClick="Update_Click"  />
                               </div> 
                           </div>  
                        </div>
                                        
               </div>
           </div>
               </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                          <div class="row">
                            <div class="col">                                                        
                             <center><img width="100px" src="img/books.png" /></center>                       
                            </div>
                           </div> 

                           <div class="row">
                            <div class="col">                     
                             <center><h4>Yours Issued Books</h4></center> 
                             <center> <span>Account Status - </span> 
                                 <asp:Label CssClass="badge badge-pill badge-success" ID="Label2" runat="server" Text="Info about book duo date"></asp:Label>
                             </center>
                            </div>
                          </div>
                            <div class="row">
                                 <div class="col">                     
                                  <hr /> 
                                 </div> 
                                  </div> 
                            
                            <div class="row">
                                <div class="col">
                                    <asp:GridView  CssClass="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
                                </div>
                            </div>



                       
                      </div>
               </div> 
            </div>
         </div>     
</asp:Content>
