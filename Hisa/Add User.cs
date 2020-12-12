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
    public partial class Add_User : Form
    {
        public Add_User()
        {
            InitializeComponent();
        }
        //connection 
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //submit button
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFirstName.Text == "" || txtLastName.Text == "" || comboRole.Text == "" || comboDepartment.Text == "" || txtUserName.Text == "" || txtPassword.Text == "")
                    MessageBox.Show("Please fill all relevant fields");
                else
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("UserAdd", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@EmailAddress", txtEmailAddress.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@Role", comboRole.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@Department", comboDepartment.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@UserName", txtUserName.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@FullNames", textBox1.Text.Trim());
                        sqlcmd.ExecuteNonQuery();
                        MessageBox.Show("Registration Successful");
                        Clear();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtPhoneNumber.Text = txtEmailAddress.Text = comboRole.Text = comboDepartment.Text = txtUserName.Text = txtPassword.Text = "";
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = txtFirstName.Text.ToString();
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = txtFirstName.Text.ToString() + " " + txtLastName.Text.ToString();
        }
        
    }
}
