<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserViewBooks.aspx.cs" Inherits="WebApplication1.UserViewBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



      <div class="container-fluid">
        <div class="row">  

                 <div class="col">
                             <div class="card">
                                 <div class="card-body">
                                     <div class="row">
                                         <div class="col-12">
                                             <center>
                                              <h4>Book Inventory List</h4>
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
