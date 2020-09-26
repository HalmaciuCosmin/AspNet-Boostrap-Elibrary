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
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"SELECT * FROM admin_login_tbl where username='{TextBox_Email.Text.Trim()}';", Con1.Connect());
            SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            addaptor.Fill(dt);

            if (dt.Rows.Count == 0)
            {

                Response.Write($"<script>alert('Username nu exista')</script>");
                return;
            }

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.GetValue(1).ToString() == TextBox_Password.Text.Trim())
                    {
                        Session["fullname"] = reader.GetValue(2).ToString();
                        Session["role"] = "admin";
                        reader.Close();
                        Response.Redirect("Home.aspx");

                    }
                    else
                    {
                        reader.Close();
                        Response.Write($"<script>alert('Parola incorecta')</script>");
                        return;
                    }
                }
            }
        }
    }
}