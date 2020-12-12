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
    public partial class Departmental_Budget : Form
    {
        public Departmental_Budget()
        {
            InitializeComponent();
        }
        //CANCEL
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //SUBMIT
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (comboDepartment.Text == "" || txtBudgetAmount.Text == "")
                MessageBox.Show("Please fill all relevant fields");
            else
            {
                try
                {
                    SqlConnection sqlcon = new SqlConnection(connectionstring);
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand("Departmental_Budget_Add", sqlcon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Department", comboDepartment.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@From", DateTime.Parse(dateTimePicker1.Text.Trim()));
                    sqlcmd.Parameters.AddWithValue("@To", DateTime.Parse(dateTimePicker2.Text.Trim()));
                    sqlcmd.Parameters.AddWithValue("@BudgetAmount", txtBudgetAmount.Text.Trim());
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Budget saved successfully");
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            
        }
        void Clear()
        {
          txtBudgetAmount.Text = "";
        }
    }
}
