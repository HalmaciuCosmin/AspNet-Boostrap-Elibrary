using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebApplication1
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void LogIn_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand($"SELECT * FROM member_master_tbl where member_id='{TextBox_ID.Text.Trim()}';", Con1.Connect());
            SqlDataAdapter addaptor = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            addaptor.Fill(dt);

                if (dt.Rows.Count == 0) 
                {

                    Response.Write($"<script>alert('Username nu exista')</script>");
                    return;
                }

            SqlDataReader reader = cmd.ExecuteReader();
            
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    if (reader.GetValue(9).ToString() == TextBox_Pass.Text.Trim())
                    {
                        Session["fullname"] = reader.GetValue(0).ToString();
                        Session["role"] = "user";
                        Session["username"] = reader.GetValue(8).ToString();

                        reader.Close();
                        Response.Redirect("Home.aspx");

                    }
                    else
                    {
                        Response.Write($"<script>alert('Parola incorecta')</script>");
                        
                    }
                }
                reader.Close();
            }

            
           
          }

           
           
        }
    }
