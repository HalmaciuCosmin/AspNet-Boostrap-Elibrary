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
    public partial class AdminMemberManagment : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           Show();
        }
  
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Ok())
            {
                SqlCommand cmd = new SqlCommand($"DELETE FROM member_master_tbl WHERE member_id='{Member_id.Text.Trim()}';", Con1.Connect());
                cmd.ExecuteNonQuery();
                Show();
            }
            else
            {
                Response.Write("<script>alert(' Member Inexistent ');</script>");
            }
        }

        protected void Go_Click(object sender, EventArgs e)
        {

            if(Ok())
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM member_master_tbl where member_id = '{Member_id.Text.Trim()}'", Con1.Connect());
                DataTable dt = new DataTable();
                SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
                addaptor.Fill(dt);

                FullName.Text = dt.Rows[0]["full_name"].ToString();
                AccountStatus.Text = dt.Rows[0]["account_status"].ToString();
                BirtDate.Text = dt.Rows[0]["dob"].ToString();
                ContactNr.Text = dt.Rows[0]["contact_no"].ToString();
                Email.Text = dt.Rows[0]["email"].ToString();
                Country.Text = dt.Rows[0]["state"].ToString();
                City.Text = dt.Rows[0]["city"].ToString();
                PinCode.Text = dt.Rows[0]["pincode"].ToString();
                FullAdress.Text = dt.Rows[0]["full_adress"].ToString();
            }
            else
            {
                Response.Write($"<script>alert('User Inexistent');</script>");
            }
          


        }

        protected void LinkButton_Active_Click(object sender, EventArgs e)
        {
            if(Ok())
            {
                SqlCommand cmd = new SqlCommand($"UPDATE member_master_tbl set account_status=@account_status where member_id = '{Member_id.Text.Trim()}'", Con1.Connect());
                cmd.Parameters.AddWithValue("@account_status", "active");
                cmd.ExecuteNonQuery();
                Show();
            }
        }

        protected void LinkButton_Pending_Click(object sender, EventArgs e)
        {
            if (Ok())
            {
                SqlCommand cmd = new SqlCommand($"UPDATE member_master_tbl set account_status=@account_status where member_id = '{Member_id.Text.Trim()}'", Con1.Connect());
                cmd.Parameters.AddWithValue("@account_status", "pending");
                cmd.ExecuteNonQuery();
                Show();
            }
        }

        protected void LinkButton_Inactive_Click(object sender, EventArgs e)
        {
            if (Ok())
            {
                SqlCommand cmd = new SqlCommand($"UPDATE member_master_tbl set account_status=@account_status where member_id = '{Member_id.Text.Trim()}'", Con1.Connect());
                cmd.Parameters.AddWithValue("@account_status", "inactive");
                cmd.ExecuteNonQuery();
                Show();
            }
        }


        private bool Ok()
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM member_master_tbl where member_id = '{Member_id.Text.Trim()}'", Con1.Connect());
            DataTable dt = new DataTable();
            SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
            addaptor.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        private void Show()
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM member_master_tbl", Con1.Connect());
            DataTable dt = new DataTable();
            SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
            addaptor.Fill(dt);

            dt.Columns.Remove("dob");
            dt.Columns.Remove("pincode");
            dt.Columns.Remove("full_adress");
            dt.Columns.Remove("password");

            dt.Columns["member_id"].SetOrdinal(0);
            dt.Columns["account_status"].SetOrdinal(1);
            dt.Columns["full_name"].SetOrdinal(2);
            dt.Columns["email"].SetOrdinal(3);
            dt.Columns["contact_no"].SetOrdinal(4);
            dt.Columns["state"].SetOrdinal(5);
            dt.Columns["city"].SetOrdinal(6);
    

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

    
    }
}