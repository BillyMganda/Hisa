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
    public partial class Delete_User_Account : Form
    {
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Delete_User_Account()
        {
            InitializeComponent();
        }
        
        //DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            if (txtDelete.Text == "")
                MessageBox.Show("You can't have an empty username");
            else
                try
                {
                    sqlcon.Open();
                    string querry = "DELETE FROM UserInfo WHERE UserName='" + this.txtDelete.Text + "'";
                    SqlCommand command = new SqlCommand(querry, sqlcon);
                    command.ExecuteNonQuery();

                    MessageBox.Show("User successfully deleted");
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
            txtDelete.Text = "";
        }
    }
}
