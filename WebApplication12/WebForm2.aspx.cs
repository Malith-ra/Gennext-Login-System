using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication12
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection(@"Data Source = localhost;port=3306;Initial Catalog=loginandregister; User Id=root;password=''");

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void LoginProcess()
        {
            if (login(TextBox1.Text, TextBox2.Text))
            {
                Response.Redirect("WebForm1.aspx");
            }
            else
            {
               
            }
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }
    }
}