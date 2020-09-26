<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminBookInventory.aspx.cs" Inherits="WebApplication1.AdminBookInventory" %>
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
                     <div class="col">
                        <center>
                           <h4>Book Details</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img  id="imgview" width="100px" src="img/books.png" />
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:FileUpload  onchange="readURL(this);" class="form-control" ID="FileUpload1" runat="server" />
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-3">
                        <label>Book ID</label>
                        <div class="form-group">
                           <div class="input-group">
                              <asp:TextBox CssClass="form-control" ID="BookID" runat="server" placeholder="Book ID"></asp:TextBox>
                              <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server" OnClick="Go"><i class="fas fa-check-circle"></i></asp:LinkButton>
                           </div>
                        </div>
                     </div>
                     <div class="col-md-9">
                        <label>Book Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="BookName" runat="server" placeholder="Book Name"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Language</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList_Language" runat="server">
                              <asp:ListItem Text="English" Value="English" />
                              <asp:ListItem Text="Hindi" Value="Hindi" />
                              <asp:ListItem Text="Marathi" Value="Marathi" />
                              <asp:ListItem Text="French" Value="French" />
                              <asp:ListItem Text="German" Value="German" />
                              <asp:ListItem Text="Urdu" Value="Urdu" />
                           </asp:DropDownList>
                        </div>
                        <label>Publisher Name</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList_Publisher" runat="server">
                           
                           </asp:DropDownList>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Author Name</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="DropDownList_AuthorName" runat="server">
                             
                           </asp:DropDownList>
                        </div>
                        <label>Publish Date</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Date" runat="server" placeholder="Date" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Genre</label>
                        <div class="form-group">
                           <asp:ListBox CssClass="form-control" ID="ListBox_Genre" runat="server" SelectionMode="Multiple" Rows="5">
                              <asp:ListItem Text="Action" Value="Action" />
                              <asp:ListItem Text="Adventure" Value="Adventure" />
                              <asp:ListItem Text="Comic Book" Value="Comic Book" />
                              <asp:ListItem Text="Self Help" Value="Self Help" />
                              <asp:ListItem Text="Motivation" Value="Motivation" />
                              <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                              <asp:ListItem Text="Wellness" Value="Wellness" />
                              <asp:ListItem Text="Crime" Value="Crime" />
                              <asp:ListItem Text="Drama" Value="Drama" />
                              <asp:ListItem Text="Fantasy" Value="Fantasy" />
                              <asp:ListItem Text="Horror" Value="Horror" />
                              <asp:ListItem Text="Poetry" Value="Poetry" />
                              <asp:ListItem Text="Personal Development" Value="Personal Development" />
                              <asp:ListItem Text="Romance" Value="Romance" />
                              <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                              <asp:ListItem Text="Suspense" Value="Suspense" />
                              <asp:ListItem Text="Thriller" Value="Thriller" />
                              <asp:ListItem Text="Art" Value="Art" />
                              <asp:ListItem Text="Autobiography" Value="Autobiography" />
                              <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                              <asp:ListItem Text="Health" Value="Health" />
                              <asp:ListItem Text="History" Value="History" />
                              <asp:ListItem Text="Math" Value="Math" />
                              <asp:ListItem Text="Textbook" Value="Textbook" />
                              <asp:ListItem Text="Science" Value="Science" />
                              <asp:ListItem Text="Travel" Value="Travel" />
                           </asp:ListBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Edition</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Edition" runat="server" placeholder="Edition"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Book Cost(per unit)</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="BookCost" runat="server" placeholder="Book Cost(per unit)" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Pages</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Pages" runat="server" placeholder="Pages" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label>Actual Stock</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Stock" runat="server" placeholder="Actual Stock" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Current Stock</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="CurrentStock" runat="server" placeholder="" TextMode="Number" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Issued Books</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="IssuedBooks" runat="server" placeholder="" TextMode="Number" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-12">
                        <label>Book Description</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Description" runat="server" placeholder="Book Description" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Add" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Add_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Update" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Update_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Delete" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Delete_Click" />
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br>
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Book Inventory List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server">
                            <Columns>
                                <asp:BoundField DataField="book_id" HeaderText ="book_id" ReadOnly="true" SortExpression="book_id" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                       

                                        <div class="container-fluid">
                                            <div class="row">
                                                <div class ="col-lg-10">
                                                     <div class="row">
                                                         <div class="col-12">
                                                            <asp:Label ID="Book_Title_Label" runat="server" Text='<%# Eval("book_name") %>' Font-Bold="true" Font-size="X-Large"></asp:Label>
                                                         </div>
                                                     </div>

                                                     <div class="row">
                                                         <div class="col-12">
                                                             <label>Author:</label>
                                                             <asp:Label ID="Label1" runat="server" Text='<%# Eval("author_name") %>' Font-Bold="true" ></asp:Label>
                                                             <label>|</label>
                                                             <label>Genre:</label>
                                                             <asp:Label ID="Label2" runat="server" Text='<%# Eval("genre") %>' Font-Bold="true" ></asp:Label>
                                                              <label>|</label>
                                                             <label>Language:</label>
                                                             <asp:Label ID="Label3" runat="server" Text='<%# Eval("language") %>' Font-Bold="true" ></asp:Label>
                                                         </div>
                                                     </div>

                                                     <div class="row">
                                                         <div class="col-12">                                                            
                                                             <label>Publisher:</label>
                                                             <asp:Label ID="Label4" runat="server" Text='<%# Eval("publisher_name") %>' Font-Bold="true" ></asp:Label>
                                                             <label>|</label>
                                                             <label>Publish Date:</label>
                                                             <asp:Label ID="Label5" runat="server" Text='<%# Eval("publish_data") %>' Font-Bold="true" ></asp:Label>
                                                              <label>|</label>
                                                             <label>Pages:</label>
                                                             <asp:Label ID="Label6" runat="server" Text='<%# Eval("nr_of_pages") %>' Font-Bold="true" ></asp:Label>
                                                             <label>|</label>
                                                             <label>Edition:</label>
                                                             <asp:Label ID="Label7" runat="server" Text='<%# Eval("edition") %>' Font-Bold="true" ></asp:Label>
                                                         </div>
                                                     </div>

                                                     <div class="row">
                                                         <div class="col-12">
                                                              <label>Cost:</label>
                                                             <asp:Label ID="Label8" runat="server" Text='<%# Eval("book_cost") %>' Font-Bold="true" ></asp:Label>
                                                             <label>|</label>
                                                             <label>Actual Stock:</label>
                                                             <asp:Label ID="Label9" runat="server" Text='<%# Eval("actual_stock") %>' Font-Bold="true" ></asp:Label>
                                                              <label>|</label>
                                                             <label>Avaible:</label>
                                                             <asp:Label ID="Label10" runat="server" Text='<%# Eval("current_stock") %>' Font-Bold="true" ></asp:Label>                                                         
                                                         </div>
                                                     </div>

                                                     <div class="row">
                                                         <div class="col-12">
                                                               <label>Description:</label>
                                                             <asp:Label ID="Label11" runat="server" Text='<%# Eval("book_description") %>' Font-Italic="true" ></asp:Label>
                                                         </div>
                                                     </div>
                                                </div>

                                                <div class="col-lg-2">
                                                    <asp:Image CssClass="img-fluid" ID ="Image1" runat="server" 
                                                        ImageUrl='<%# Eval("book_img_link") %>' />
                                                </div>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>



    
</asp:Content>

