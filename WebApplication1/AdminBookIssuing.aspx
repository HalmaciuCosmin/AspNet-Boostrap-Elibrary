<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminBookIssuing.aspx.cs" Inherits="WebApplication1.AdminBookIssuing" %>
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
    <!--  container/row/ (col) /card/cardbody/(row-col)   textbox/button in form-group-->
    <!--  form-control  - contur -->
    <!-- form-group  input-group  ( le pune consecutiv, exp asp:text(book id) , asp:button(go) -->

       <div class="container-fluid"> 
           <div class="row">
               
               <div class="col-md-5">
                   <div class="card">
                       <div class="card-body">
                           
                           <div class="row">
                               <div class="col-12">
                                   <center>
                                       <h4>Book Issuing</h4>
                                       <img width="100px" src="img/books.png" />
                                   </center>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-6">
                                   <asp:Label ID="Label1" runat="server" Text="Member ID"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox ID="Member_ID" CssClass="form-control" Wrap="true" runat="server" Text="" />
                                    </div>
                               </div>
                               <div class="col-6">
                                   <asp:Label ID="Label2" runat="server" Text="Book ID"></asp:Label>
                                    <div class="form-group">
                                        <div class="input-group">
                                           <asp:TextBox ID="Book_ID" CssClass="form-control" Wrap ="true" runat="server" Text="" />
                                            <asp:Button class="btn btn-primary" ID="Go" runat="server" Text="Go" OnClick="Go_Click" />
                                        </div>
                                        
                                    </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-6">
                                   <asp:Label ID="Label3"  runat="server" Text="Member Name"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox ID="Member_Name" CssClass="form-control" Wrap ="true" runat="server" Text="Name" ReadOnly="true" />
                                    </div>
                               </div>
                               <div class="col-6">
                                   <asp:Label ID="Label4"   Wrap ="true" runat="server" Text="Book Name"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox ID="Book_Name" CssClass="form-control" Wrap ="true" runat="server" Text="Name" ReadOnly="true"/>
                                    </div>
                               </div>
                           </div>

                           <div class="row">
                               <div class="col-6">
                                   <asp:Label ID="Label5" runat="server" Text="Start Date"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox ID="Date_Start"  CssClass="form-control" Wrap ="true" runat="server" Text="dd-mm-yyyy" TextMode="Date" />
                                    </div>
                               </div>
                               <div class="col-6">
                                   <asp:Label ID="Label6" runat="server" Text="End Date"></asp:Label>
                                    <div class="form-group">
                                        <asp:TextBox ID="Date_End"   CssClass="form-control" Wrap ="true" runat="server" Text="dd-mm-yyyy" TextMode="Date" />
                                    </div>
                               </div>
                           </div>
                   
                              <div class="row">
                               <div class="col-6">                              
                                   <div class="form-group">
                                       <asp:Button CssClass="btn btn-lg btn-block btn-primary" ID="Issue" runat="server" Text="Issue" OnClick="Issued_Click" />
                                    </div>
                               </div>
                               <div class="col-6">                                  
                                   <asp:Button CssClass="btn btn-lg btn-block btn-success" ID="Return" runat="server" Text="Return" OnClick="Return_Click" />                                   
                               </div>
                           </div>

                           <a href="Home.aspx"> << Back To Home</a><br /> <br />
                           
                          </div>
                       
                          
                   </div>
               </div> 

                <div class="col-md-7">
                             <div class="card">
                                 <div class="card-body">
                                     <div class="row">
                                         <div class="col-12">
                                             <center>
                                              <h4>Issued Book List</h4>
                                             </center>
                                         </div>
                                     </div>
                                        
                                    <div class="row">
                                        <div class="col-md-12">
                                            <hr />
                                        </div>
                                    </div>

                                     <div class="row">
                                         <div class="col-12">
                                             <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>                   
                                         </div>
                                     </div>

                                 </div>
                             </div>
                       </div>

                 
     
    </div>
   </div>
</asp:Content>
