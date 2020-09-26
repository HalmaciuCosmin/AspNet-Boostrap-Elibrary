using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class UserSignUp : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SignIn_Click(object sender, EventArgs e)
        {
             if(!IsOk())
             {
                Response.Write($"<script>alert('Username Invalid')</script>");
                return;
             }
            else
            {
                Insert();
            }
         
            
        }


        private bool IsOk()
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM member_master_tbl where member_id='{UserId_Label.Text.Trim()}';", Con1.Connect());
            SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            addaptor.Fill(dt);

            if (dt.Rows.Count >= 1) return false;
            else { return true; }

        }

        private void Insert()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email,state,city,pincode,full_adress,member_id,password,account_status) values(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_adress,@member_id,@password,@account_status)", Con1.Connect());

                cmd.Parameters.AddWithValue("@full_name", FullName_Label.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", BirtDate_Label.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", ContactNumber_Label.Text.Trim());
                cmd.Parameters.AddWithValue("@email", Email_Label.Text.Trim());
                cmd.Parameters.AddWithValue("@state", Country_DropDown.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", City_Label.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", PinCode_Label.Text.Trim());
                cmd.Parameters.AddWithValue("@full_adress", FullAdress_Label.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", UserId_Label.Text.Trim());
                cmd.Parameters.AddWithValue("@password", Password_Label.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
               

                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

    }
          

}
    