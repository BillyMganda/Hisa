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
    public partial class Main_Group : Form
    {
        public Main_Group()
        {
            InitializeComponent();
        }
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        

        //submit button
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text == "")
                MessageBox.Show("Please fill all relevant fields");
            else
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == System.Data.ConnectionState.Closed)
                        sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand("MainGroupAdd", sqlcon);
                    sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@GroupName", txtGroupName.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@DateCreated", dateTimePicker1.Value);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Main Group successfully added");

                    Clear();
                }

        }
        //Clear method
        void Clear()
        {
            txtGroupName.Text = dateTimePicker1.Text = "";
        }
        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
