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
    public partial class Sub_Group : Form
    {
        public Sub_Group()
        {
            InitializeComponent();
            FillComboBox();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        void FillComboBox()
        {
            string querry = "SELECT DISTINCT GroupName from Main_Group";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            SqlCommand sqlcmd = new SqlCommand(querry, sqlcon);
            SqlDataReader sqlreader;
            try
            {
                sqlcon.Open();
                sqlreader = sqlcmd.ExecuteReader();
                while(sqlreader.Read())
                {
                    string Gname = sqlreader.GetString(0);
                    comboMainGroup.Items.Add(Gname);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //submit button
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text == "" || comboMainGroup.Text=="")
                MessageBox.Show("Please fill all relevant fields");
            else
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == System.Data.ConnectionState.Closed)
                        sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand("SubGroupAdd", sqlcon);
                    sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@GroupName", txtGroupName.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@MainGroup", comboMainGroup.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@DateCreated", dateTimePicker1.Value);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Sub Group uccessfully added");

                    Clear();
                }
        }
        //clear method
        void Clear()
        {
            txtGroupName.Text = comboMainGroup.Text="";
        }
    }
}
