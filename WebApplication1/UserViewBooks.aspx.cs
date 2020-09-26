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
    public partial class UserViewBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM book_master_tbl", Con1.Connect());
            adapter.Fill(dt);
            GridView1.AutoGenerateColumns = false;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}