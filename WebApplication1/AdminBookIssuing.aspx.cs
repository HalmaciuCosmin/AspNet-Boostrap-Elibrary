using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AdminBookIssuing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Show();
        }



        protected void Return_Click(object sender, EventArgs e)
        {
            if (Exista())
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM book_issue_tbl WHERE member_id='{Member_ID.Text.Trim()}' AND book_id='{Book_ID.Text.Trim()}'", Con1.Connect());

                cmd.ExecuteNonQuery();
                Show();
                IncreDecre(true);
            }
            else
            {
                Response.Write("<script>alert(' Date incorecte');</script>");
            }
        }

        protected void Issued_Click(object sender, EventArgs e)
        {
            Go_Click(null, EventArgs.Empty);

            if (IsOk())
            {
                
                SqlCommand cmd = new SqlCommand($"INSERT INTO book_issue_tbl(member_id,member_name,book_id,book_name,issue_date,return_date)" +
                $"values('{Member_ID.Text.Trim()}','{Member_Name.Text.Trim()}','{Book_ID.Text.Trim()}','{Book_Name.Text.Trim()}','{Date_Start.Text.Trim()}','{Date_End.Text.Trim()}')",Con1.Connect());

                cmd.ExecuteNonQuery();
                Show();
                IncreDecre(false);
            }
            else
            {
                Response.Write("<script>alert(' Un user nu poate imprumuta aceas carte de 2 ori ');</script>");
            }

        }

        protected void Go_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand($"SELECT * FROM book_master_tbl where book_id='{Book_ID.Text.Trim()}';", Con1.Connect());
            DataTable dt = new DataTable();
            SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
            addaptor.Fill(dt);

            if(dt.Rows.Count >= 1)
            {
               Book_Name.Text = dt.Rows[0]["book_name"].ToString().Trim();
            }
            else
            {
                Response.Write("<script>alert(' ID  book incorect ');</script>");
            }

             cmd = new SqlCommand($"SELECT * FROM member_master_tbl where member_id='{Member_ID.Text.Trim()}';", Con1.Connect());
             dt = new DataTable();
             addaptor = new SqlDataAdapter(cmd);
             addaptor.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                Member_Name.Text = dt.Rows[0]["full_name"].ToString().Trim();
            }
            else
            {
                Response.Write("<script>alert(' ID  member incorect ');</script>");
            }


        }

        private bool IsOk()
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM book_issue_tbl where book_id='{Book_ID.Text.Trim()}' AND member_id='{Member_ID.Text.Trim()}';", Con1.Connect());
            SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            addaptor.Fill(dt);
          
                if (dt.Rows.Count >= 1)
                {                    
                    return false;
                }
            

            return true;
        }

        private bool Exista()
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM book_issue_tbl where book_id='{Book_ID.Text.Trim()}' AND  member_id='{Member_ID.Text.Trim()}';", Con1.Connect());
            SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            addaptor.Fill(dt);

            if(dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Show()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM book_issue_tbl", Con1.Connect());
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }


        public void IncreDecre(bool a)
        {

            SqlCommand cmd = new SqlCommand($"SELECT * FROM book_master_tbl where book_id='{Book_ID.Text.Trim()}';", Con1.Connect());
            DataTable dt = new DataTable();
            SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
            addaptor.Fill(dt);

            string actualstock = dt.Rows[0]["current_stock"].ToString();
            int curentstock;

            if (a)
            {
                 curentstock = Int32.Parse(actualstock) + 1;
            }
            else
            {
                curentstock = Int32.Parse(actualstock) - 1;
            }

            string current = curentstock.ToString();

            cmd = new SqlCommand("UPDATE book_master_tbl  SET current_stock = @stock  Where book_id = @id",Con1.Connect());
            cmd.Parameters.AddWithValue("@stock", current);
            cmd.Parameters.AddWithValue("@id", Book_ID.Text.Trim());
            cmd.ExecuteNonQuery();
            
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime d = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime t = DateTime.Today;
                    if(t > d)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
        }
    }
}