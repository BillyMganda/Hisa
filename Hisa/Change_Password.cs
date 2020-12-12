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
       

    public partial class Change_Password : Form
    {
        public Change_Password()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Change button
        private void btnChange_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            if (txtUserName.Text == "" || txtNewPassword.Text == "")
                MessageBox.Show("You can't have an empty username or password");
            else
                try
                {
                    sqlcon.Open();
                    string querry = "UPDATE UserInfo SET Password='" + this.txtNewPassword.Text + "' WHERE Username='" + this.txtUserName.Text + "'";
                    SqlCommand command = new SqlCommand(querry, sqlcon);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Password successfully changed");
                    sqlcon.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            Clear();
        }
        void Clear()
        {
            txtUserName.Text = txtNewPassword.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
