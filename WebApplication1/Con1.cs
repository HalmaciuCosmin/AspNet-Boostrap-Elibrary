using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public static class Con1
    {
        public static SqlConnection SqlCon;


        public static SqlConnection Connect()
        {
            if (SqlCon == null)
            {
                SqlCon = new SqlConnection();
            }

            if (SqlCon.State == ConnectionState.Closed)
            {
                try
                {
                    string path = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
                    SqlCon = new SqlConnection(path);
                    SqlCon.Open();


                }
                catch (Exception e)
                {
                    SqlCon = null;
                }
            }

            return SqlCon;
        }
    }
}
