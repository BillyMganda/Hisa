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
    public partial class Add_Supplier_Info : Form
    {
        public Add_Supplier_Info()
        {
            InitializeComponent();
        }
        //CONNECTION STRING
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        //Cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //submit button
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtSupplierName.Text == "" || txtSupplierAddress.Text == "" || txtTelephone1.Text == "" || txtEmailAddress.Text == "")
                MessageBox.Show("Please input all neccessary fields");
            else
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == System.Data.ConnectionState.Closed)
                        sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand("SupplierAdd", sqlcon);
                    sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@SupplierAddress", txtSupplierAddress.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Telephone1", txtTelephone1.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Telephone2", txtTelephone2.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Telephone3", txtTelephone3.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@EmailAddress", txtEmailAddress.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@PIN", txtPIN.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@VAT", txtVAT.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@City", txtCity.Text.Trim());
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Successful");
                    Clear();
                }
            }            
        }
        //clear fields method
        void Clear()
        {
            txtSupplierName.Text = txtSupplierAddress.Text = txtTelephone1.Text = txtTelephone2.Text = txtTelephone3.Text = txtEmailAddress.Text = txtPIN.Text = txtVAT.Text = txtCity.Text = "";
        }

    }
}
