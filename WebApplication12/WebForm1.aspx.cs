using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication12
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection(@"Data Source = localhost;port=3306;Initial Catalog=loginandregister; User Id=root;password=''");

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        bool _regiter()
        {
            int retval = 0;
            try
            {
                string SQLS = string.Empty;
                SQLS += "INSERT tb_user SET ";
                SQLS += "fullname='" + "" + "'";
                SQLS += ",user='" + "" + "'";
                SQLS += ",password='" + "" + "'";


                conn.Open();
                using (MySqlCommand com = new MySqlCommand(SQLS, conn))
                {
                    retval = com.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                

            }
            finally { conn.Close(); }
            return retval > 0;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            _regiter();
            Response.Redirect("Login.aspx");


        }
    }
}