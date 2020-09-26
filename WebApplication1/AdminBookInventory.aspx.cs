using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminBookInventory : System.Web.UI.Page
    {


        static string file_path = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            Show();
        }

        protected void Add_Click(object sender, EventArgs e)
        {


            if (IsOk())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand($"SELECT * FROM book_issue_tbl where book_id='{BookID.Text.Trim()}';", Con1.Connect());
                    SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    addaptor.Fill(dt);



                    string stock = (Int32.Parse(Stock.Text.Trim()) - dt.Rows.Count).ToString();
                    string s = CurrentStock.Text.Trim();
                    string gen = "";

                    foreach(int i in ListBox_Genre.GetSelectedIndices())
                    {
                        gen += $"{ListBox_Genre.Items[i].Text},";
                    }

                    string filename;

                    if (FileUpload1.HasFile)
                    {
                        filename = $"books/{Path.GetFileName(FileUpload1.PostedFile.FileName)}";
                    }
                    else
                    {
                        filename = "gol";
                    }
                   

                        cmd = new SqlCommand($"INSERT INTO book_master_tbl(book_id,book_name,author_name,publisher_name,publish_data,language," +
                        $"edition,book_cost,nr_of_pages,book_description,actual_stock,current_stock,book_img_link,genre) values('{BookID.Text.Trim()}','{BookName.Text.Trim()}'," +
                        $"'{DropDownList_AuthorName.SelectedValue.Trim()}','{DropDownList_Publisher.SelectedValue.Trim()}','{Date.Text.Trim()}'," +
                        $"'{DropDownList_Language.SelectedValue.Trim()}','{Edition.Text.Trim()}','{BookCost.Text.Trim()}','{Pages.Text.Trim()}'," +
                        $"'{Description.Text.Trim()}','{Stock.Text.Trim()}','{stock}', @file,@gen)", Con1.Connect());

                     cmd.Parameters.AddWithValue("@file", filename);
                     cmd.Parameters.AddWithValue("@gen", gen);


                    cmd.ExecuteNonQuery();

                    Response.Write("<script>alert(' Successful ');</script>");
                    Show();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Already In');</script>");
            }

            Show();

        }

        protected void Update_Click(object sender, EventArgs e)
        {


            if (!IsOk())
            {
           
                string filename;
                if (FileUpload1.HasFile)
                {
                    filename = $"books/{Path.GetFileName(FileUpload1.PostedFile.FileName)}";
                }
                else
                {
                    filename = file_path;
                }


                string genre = "";
                foreach (int i in ListBox_Genre.GetSelectedIndices())
                {
                    genre += ListBox_Genre.Items[i] + ",";
                }

                  SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl set book_name=@book_name, genre=@genre, " +
                   "author_name=@author_name, publisher_name=@publisher_name, publish_data=@publish_date, language=@language, " +
                   "edition=@edition, book_cost=@book_cost, nr_of_pages=@no_of_pages, book_description=@book_description, " +
                   "actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" 
                   + BookID.Text.Trim() + "'", Con1.Connect());


                   

                   cmd.Parameters.AddWithValue("@book_name", BookName.Text.Trim());
                   cmd.Parameters.AddWithValue("@genre", genre);
                   cmd.Parameters.AddWithValue("@author_name", DropDownList_AuthorName.SelectedItem.Value);
                   cmd.Parameters.AddWithValue("@publisher_name", DropDownList_Publisher.SelectedItem.Value);
                   cmd.Parameters.AddWithValue("@publish_date", Date.Text.Trim());
                   cmd.Parameters.AddWithValue("@language", DropDownList_Language.SelectedItem.Value);
                   cmd.Parameters.AddWithValue("@edition", Edition.Text.Trim());
                   cmd.Parameters.AddWithValue("@book_cost", BookCost.Text.Trim());
                   cmd.Parameters.AddWithValue("@no_of_pages", Pages.Text.Trim());
                   cmd.Parameters.AddWithValue("@book_description", Description.Text.Trim());
                   cmd.Parameters.AddWithValue("@actual_stock", Stock.Text.Trim());
                    int stock = Int32.Parse(Stock.Text.Trim()) - Int32.Parse(CurrentStock.Text.Trim());
                   cmd.Parameters.AddWithValue("@current_stock", stock.ToString());
                   cmd.Parameters.AddWithValue("@book_img_link", filename);

                cmd.ExecuteNonQuery();

                Show();

            }
            else
            {
                Response.Write("<script>alert(' Carte Inexistenta ');</script>");
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {

            if (!IsOk())
            {
                SqlCommand cmd = new SqlCommand("DELETE from book_master_tbl WHERE book_id='" + BookID.Text.Trim() + "'", Con1.SqlCon);

                cmd.ExecuteNonQuery();
                Show();
            }
            else
            {
                Response.Write("<script>alert(' Carte Inexistenta ');</script>");
            }

           
        }


        private bool IsOk()
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM book_master_tbl where book_id='{BookID.Text.Trim()}' OR book_name ='{BookName.Text.Trim()}';", Con1.Connect());
            SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            addaptor.Fill(dt);

            if (dt.Rows.Count >= 1) return false;
            else { return true; }

        }

        private void Show()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM book_master_tbl", Con1.Connect());
            adapter.Fill(dt);
            GridView1.AutoGenerateColumns = false;
            GridView1.DataSource = dt;
            GridView1.DataBind();


            
            adapter = new SqlDataAdapter("SELECT author_name FROM author_master_tbl;", Con1.Connect());
            dt = new DataTable();
            adapter.Fill(dt);
            DropDownList_AuthorName.DataSource = dt;
            DropDownList_AuthorName.DataValueField = "author_name";
            DropDownList_AuthorName.DataBind();

            adapter = new SqlDataAdapter("SELECT publisher_name FROM publisher_master_tbl;", Con1.Connect());
            dt = new DataTable();
            adapter.Fill(dt);
            DropDownList_Publisher.DataSource = dt;
            DropDownList_Publisher.DataValueField = "publisher_name";
            DropDownList_Publisher.DataBind();
        }

        protected void Go(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM book_master_tbl where book_id='{BookID.Text.Trim()}' OR book_name ='{BookName.Text.Trim()}';", Con1.Connect());
            SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            addaptor.Fill(dt);

            if(dt.Rows.Count>=1)
            {

                cmd = new SqlCommand($"SELECT * FROM book_issue_tbl where book_id='{BookID.Text.Trim()}';", Con1.Connect());
                addaptor = new SqlDataAdapter(cmd);
                DataTable dtt = new DataTable();
                addaptor.Fill(dtt);

                int IssueNumber = dtt.Rows.Count;
                IssuedBooks.Text = IssueNumber.ToString();


                BookName.Text = dt.Rows[0]["book_name"].ToString().Trim();
                Date.Text = dt.Rows[0]["publish_data"].ToString().Trim();
                Pages.Text = dt.Rows[0]["nr_of_pages"].ToString().Trim();
                BookCost.Text = dt.Rows[0]["nr_of_pages"].ToString().Trim();
                Stock.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                CurrentStock.Text = dt.Rows[0]["current_stock"].ToString();
                Description.Text = dt.Rows[0]["book_description"].ToString().Trim();

              
                ListBox_Genre.ClearSelection();
                string[] genre = dt.Rows[0]["genre"].ToString().Split(',');
                for(int i = 0; i < genre.Length;i++)
                {
                    for(int j = 0; j<ListBox_Genre.Items.Count;j++)
                    {
                        if(ListBox_Genre.Items[j].ToString() == genre[i])
                        {
                            ListBox_Genre.Items[j].Selected = true;
                        }                    
                    }
                }

                DropDownList_AuthorName.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                DropDownList_Language.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                DropDownList_Publisher.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();

            }
            else
            {
                Response.Write("<script>alert(' ID incorect ');</script>");
            }

        }
    }
}