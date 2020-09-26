using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace WebApplication1
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                Show();
            }
  
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string password;
            if(NewPassword.Text.Trim() == "")
            {
                password = OldPassword.Text;
            }
            else
            {
                password = NewPassword.Text.Trim();
            }


            SqlCommand cmd = new SqlCommand("update member_master_tbl set full_name=@full_name, dob=@dob, contact_no=@contact_no, email=@email, state=@state, city=@city, pincode=@pincode, full_adress=@full_address, password=@password, account_status=@account_status WHERE member_id='" + Session["username"].ToString().Trim() + "'", Con1.Connect());

            cmd.Parameters.AddWithValue("@full_name", FullName_TextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@dob", BirtDate_TextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@contact_no", ContactNumber_TextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@email", Email_TextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@state", DropDownList_Country.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@city", City_TextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@pincode", PinCode_TextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@full_address", FullAdress_TextBox.Text.Trim());
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@account_status", "pending");

            cmd.ExecuteNonQuery();
            Label1.CssClass = "badge badge-pill badge-warning";

        }

        void Show()
        {
            if (!(Session["username"] == null) && !(Session["username"].Equals("")))
            {
                SqlCommand cmdd = new SqlCommand($"SELECT * from book_issue_tbl WHERE member_id='{Session["username"]}'",Con1.Connect());
                DataTable dt = new DataTable();
                SqlDataAdapter addaptor = new SqlDataAdapter(cmdd);
                addaptor.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
          
                cmdd = new SqlCommand($"SELECT * from member_master_tbl WHERE member_id = '{Session["username"]}'",Con1.Connect());
                dt = new DataTable();
                addaptor = new SqlDataAdapter(cmdd);
                addaptor.Fill(dt);
                    
                FullName_TextBox.Text = dt.Rows[0]["full_name"].ToString();
                BirtDate_TextBox.Text = dt.Rows[0]["dob"].ToString();
                ContactNumber_TextBox.Text = dt.Rows[0]["contact_no"].ToString();
                Email_TextBox.Text = dt.Rows[0]["email"].ToString();
                PinCode_TextBox.Text = dt.Rows[0]["pincode"].ToString();
                FullAdress_TextBox.Text = dt.Rows[0]["full_adress"].ToString();
                UserID_TextBox.Text = dt.Rows[0]["member_id"].ToString();
                OldPassword.Text = dt.Rows[0]["password"].ToString();
                City_TextBox.Text = dt.Rows[0]["city"].ToString();
                DropDownList_Country.SelectedValue = dt.Rows[0]["state"].ToString().Trim();


                Label1.Text = dt.Rows[0]["account_status"].ToString().Trim();

                if(Label1.Text == "active" )
                {
                    Label1.CssClass = "badge badge-pill badge-success";
                }
                else  if (Label1.Text == "pending")
                {
                    Label1.CssClass = "badge badge-pill badge-warning";
                }
                else if (Label1.Text == "inactive")
                {
                    Label1.CssClass = "badge badge-pill badge-danger";
                }
                else
                {
                    Label1.Attributes.Add("class", "badge  badge-info");
                }

            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime d = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime t = DateTime.Today;
                    if (t > d)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('{ex.Message}');</script>");
            }
        }
    }
}