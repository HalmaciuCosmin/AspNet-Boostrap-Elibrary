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
    public partial class Site1 : System.Web.UI.MasterPage
    {


 

        protected void Page_Load(object sender, EventArgs e)
        {

                   
                if (!(Session["fullname"] == null) && !(Session["fullname"].Equals("")))
                {
                    User.Text = $"Hello {Session["fullname"]}";
                    User.Visible = true;

                    Admin_Login_HREF.Visible = false;
                    User_Login_HREF.Visible = false;
                    LogOut_HREF.Visible = true;
                }

                if (!(Session["role"] == null) && Session["role"].Equals("admin"))
                {
                    Author_Managment_HREF.Visible = true;
                    Book_Inventory_HREF.Visible = true;
                    Book_Issuing_HREF.Visible = true;
                    Member_Managment_HREF.Visible = true;
                    Publisher_Managment_HREF.Visible = true;
                }
                
            
        }

        protected void Admin_Login_HREF_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void Author_Managment_HREF_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAuthorManagment.aspx");
        }

        protected void Publisher_Managment_HREF_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPublisherManagment.aspx");
        }

        protected void Book_Inventory_HREF_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookInventory.aspx");
        }

        protected void Book_Issuing_HREF_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminBookIssuing.aspx");
        }

        protected void Member_Managment_HREF_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminMemberManagment.aspx");
        }

        protected void User_Login_HREF_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }

        protected void Sign_In_HREF_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserSignUp.aspx");
        }

        protected void LogOut_HREF_Click(object sender, EventArgs e)
        {
            Session["fullname"] = "";
            Session["role"] = "";
            Session["username"] = "";

            Admin_Login_HREF.Visible = true;
            User_Login_HREF.Visible = true;
            LogOut_HREF.Visible = false;

            Author_Managment_HREF.Visible = false;
            Book_Inventory_HREF.Visible = false;
            Book_Issuing_HREF.Visible = false;
            Member_Managment_HREF.Visible = false;
            Publisher_Managment_HREF.Visible = false;

            User.Text = "Hello";
            Response.Redirect("Home.aspx");
        }

        protected void User_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }

        protected void View_Books_HREF_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserViewBooks.aspx");
        }
    }
}