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
    public partial class AdminPublisherManagment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Show();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if(!IsOk())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id,publisher_name) values(@publisher_id,@publisher_name)", Con1.Connect());
                cmd.Parameters.AddWithValue("@publisher_id", Publisher_ID.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", Publisher_name.Text.Trim());
                cmd.ExecuteNonQuery();
                Show();
            }
            else
            {
                Response.Write("<script>alert(' Publisheru se afla in baza de date ');</script>");
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if(IsOk())
            {
                SqlCommand cmd = new SqlCommand($"UPDATE publisher_master_tbl set publisher_name=@publisher_name where publisher_id = '{Publisher_ID.Text.Trim()}'",Con1.Connect());
                cmd.Parameters.AddWithValue("@publisher_name", Publisher_name.Text.Trim());
                cmd.ExecuteNonQuery();
                Show();
            }
            else
            {
                Response.Write("<script>alert(' Publisheru se afla in baza de date ');</script>");
            }


        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            if(IsOk())
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM publisher_master_tbl WHERE publisher_id='{Publisher_ID.Text.Trim()}';", Con1.Connect());
                cmd.ExecuteNonQuery();
                Show();
            }
            else
            {
                Response.Write("<script>alert(' Publisheru nu se afla in baza de date ');</script>");
            }
        }

        public void Show()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM publisher_master_tbl", Con1.Connect());
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }


        public bool IsOk()
        {

            SqlCommand cmd = new SqlCommand($"SELECT * FROM publisher_master_tbl where publisher_id='{Publisher_ID.Text.Trim()}';", Con1.Connect());
            SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            addaptor.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void Go_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM publisher_master_tbl where publisher_id='{Publisher_ID.Text.Trim()}';", Con1.Connect());
            SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            addaptor.Fill(dt);


            if (dt.Rows.Count >= 1)
            {
                Publisher_name.Text = dt.Rows[0]["publisher_name"].ToString();
            }

        }
    }
}