using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminAuthorManagmentaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Show();
        }

        protected void Button_Ad_Click(object sender, EventArgs e)
        {
            if (IsOk())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand($"INSERT INTO author_master_tbl(author_ID,author_name) values('{TextBox_ID.Text.Trim()}','{TextBox_AuthorName.Text.Trim()}')", Con1.Connect());

                   
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
        }

        protected void Button_Update_Click(object sender, EventArgs e)
        {
            if(!IsOk())
            {
               SqlCommand cmd = new SqlCommand($"UPDATE author_master_tbl SET author_name='{TextBox_AuthorName.Text.Trim()}' WHERE author_ID='{TextBox_ID.Text.Trim()}'", Con1.Connect());                  
               cmd.ExecuteNonQuery();

               Response.Write("<script>alert(' Successful ');</script>");
               Show();
            }
            else
            {
                Response.Write("<script>alert(' Autor Inexistent ');</script>");
            }

        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            if(!IsOk())
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM author_master_tbl WHERE author_ID='{TextBox_ID.Text.Trim()}'", Con1.Connect());            
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert(' Deleted ');</script>");
                Show();
            }
            else
            {
                Response.Write("<script>alert(' Autor Inexistent ');</script>");
            }
        }

        protected void Button_GO_Click(object sender, EventArgs e)
        {
         
        }


        private bool IsOk()
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM author_master_tbl where author_ID='{TextBox_ID.Text.Trim()}';", Con1.Connect());
            SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            addaptor.Fill(dt);

            if (dt.Rows.Count >= 1) return false;
            else { return true; }

        }

        private void Show()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM author_master_tbl", Con1.Connect());
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


    }


}
