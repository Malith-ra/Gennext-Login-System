using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication12
{
    
    public partial class Login : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection(@"Data Source = localhost;port=3306;Initial Catalog=loginandregister; User Id=root;password=''");
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
        protected void Page_Load(object sender, EventArgs e)
        {
            _regiter();
        }
        
        protected Boolean login(string sUsername, string sPassword)
        {
            string SQL = "SELECT user,password FROM tb_user";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(SQL, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if ((sUsername == reader.GetString(0)) && (sPassword == reader.GetString(1)))
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }
        
        private void LoginProcess()
        {
            if (login(TextBox1.Text, TextBox2.Text))
            {
              
                Response.Redirect("Home.aspx");
            }
            else
            {

            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }

        protected void Button5_Click1(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}