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
    public partial class HOD_Approve_Request : Form
    {
        public HOD_Approve_Request()
        {
            InitializeComponent();
        }
        //CONNECTIONSTRING
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //FILL MOST DETAILS
        private void FillDetails()
        {
            try
            {
                string querry = "SELECT * FROM Requisitions WHERE Department='"+ textBox1.Text + "'";
                SqlConnection con = new SqlConnection(connectionstring);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtRequestBy.Text = reader["Requested_By"].ToString();
                    textBox2.Text = reader["Request_Date"].ToString();
                    textBox3.Text = reader["Request_Time"].ToString();
                    textBox4.Text = reader["Shift"].ToString();
                    textBox5.Text = reader["Request_Number"].ToString();
                    textBox6.Text = reader["TotalTotalAmount"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //FILL DATAGRID
        private void Fill_Datagrid()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Units,SOH,UnitPrice,StoreValue,Requested,TotalRequestedValue FROM Requisitions WHERE Request_Number='" +Convert.ToInt32(textBox5.Text)+"'", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGrid1.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No more requisitions to view");
            }
        }
        //CALCULATION IN DATAGRID
        private void dataGrid1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGrid1.Rows)
                {
                    row.Cells[dataGrid1.Columns["TotalRequestedValue"].Index].Value = (Convert.ToDouble(row.Cells[dataGrid1.Columns["UnitPrice"].Index].Value) * Convert.ToDouble(row.Cells[dataGrid1.Columns["Requested"].Index].Value));
                }
                //Datagrid column total
                int sum = 0;
                for (int i = 0; i < dataGrid1.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(dataGrid1.Rows[i].Cells["TotalRequestedValue"].Value);
                }
                textBox6.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //LOAD
        private void HOD_Approve_Request_Load(object sender, EventArgs e)
        {
            label10.Text = HOD_Module.SetValueForlabel9;
            textBox1.Text = HOD_Module.Depa_rtment;
            FillDetails();
            Fill_Datagrid();

            this.dataGrid1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGrid1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
        //CLOSE
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        //VOID  -- DELETE A REQUISITION BASED ON THE REQUISITION NUMBER
        private void btnVoid_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = $"DELETE FROM Requisitions WHERE Request_Number='" +Convert.ToInt32(textBox5.Text)+ "'";
                    SqlCommand command = new SqlCommand(querry, sqlcon);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Request voided successfully");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //REFRESH
        private void Refresh()
        {
            HOD_Approve_Request hod = new HOD_Approve_Request();
            hod.ShowDialog();
        }
        //DELETE AFTER APPROVE
        private void Delete_After_Approve()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = $"DELETE FROM Requisitions WHERE Request_Number='" + Convert.ToInt32(textBox5.Text) + "'";
                    SqlCommand command = new SqlCommand(querry, sqlcon);
                    command.ExecuteNonQuery();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //AUTHORIZE    YOU ARE HERE
        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGrid1.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("HOD_ApproveRequestAdd", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Request_Date", DateTime.Parse(textBox2.Text));
                        sqlcmd.Parameters.AddWithValue("@Request_Time", DateTime.Parse(textBox3.Text));
                        sqlcmd.Parameters.AddWithValue("@Request_Number", Convert.ToInt32(textBox5.Text));
                        sqlcmd.Parameters.AddWithValue("@Requested_By", txtRequestBy.Text);
                        sqlcmd.Parameters.AddWithValue("@Approved_By", label10.Text);
                        sqlcmd.Parameters.AddWithValue("@Department", textBox1.Text);
                        sqlcmd.Parameters.AddWithValue("@Shift", textBox4.Text);
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGrid1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGrid1.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGrid1.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@SOH", dataGrid1.Rows[i].Cells["SOH"].Value);
                        sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGrid1.Rows[i].Cells["UnitPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@StoreValue", dataGrid1.Rows[i].Cells["StockValue"].Value);
                        sqlcmd.Parameters.AddWithValue("@Requested", dataGrid1.Rows[i].Cells["Requested"].Value);
                        sqlcmd.Parameters.AddWithValue("@TotalRequestedValue", dataGrid1.Rows[i].Cells["TotalRequestedValue"].Value);
                        sqlcmd.Parameters.AddWithValue("@TotalTotalAmount", Convert.ToDecimal(textBox6.Text));
                        sqlcmd.ExecuteNonQuery();
                        Hide();                        
                    }
                Delete_After_Approve();
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
    }
}
