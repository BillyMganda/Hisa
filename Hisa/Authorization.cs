using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Hisa
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //SEARCH
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
                MessageBox.Show("Input username to proceed");
            else
            {
                try
                {
                    string querry = "SELECT Password FROM UserInfo WHERE Username='" + txtUsername.Text + "'";
                    SqlConnection con = new SqlConnection(connectionstring);
                    SqlCommand cmd = new SqlCommand(querry, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        MessageBox.Show(this, "The password for '" + txtUsername.Text + "' is " + reader["Password"]);
                    }
                    else
                    {
                        MessageBox.Show(this, "No person of such username available, please enter the right username!");
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
