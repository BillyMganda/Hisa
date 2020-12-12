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
    public partial class Return_To_Supplier : Form
    {
        public Return_To_Supplier()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //FILL TEXTBOXES WITH VALUES FROM DB
        void FillSomeDetails()
        {
            SqlConnection con = new SqlConnection(connectionstring);
            string querry = "SELECT * FROM Return_To_Supplier WHERE Record_Number=(SELECT MAX(Record_Number) FROM Return_To_Supplier)";            
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand(querry, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtDate.Text = reader["Return_Date"].ToString();
                txtTime.Text = reader["Return_Time"].ToString();
                txtRecordNO.Text = reader["Record_Number"].ToString();
                txtReturnedBy.Text = reader["Returned_By"].ToString();
                txtRequestedBy.Text = reader["GRN_Number"].ToString();
                txtDepartment.Text = reader["Department"].ToString();
                txtReson.Text = reader["Return_Reason"].ToString();               
            }
        }
        //FILL DATAGRID
        void FillDatagrid()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Units,SOH,Return_Amount,UnitPrice,TotalPrice FROM Return_To_Supplier WHERE Record_Number='" + Convert.ToInt32(txtRecordNO.Text) + "'", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No more return to supplier to process");
            }
        }
        //LOAD
        private void Return_To_Supplier_Load(object sender, EventArgs e)
        {
            textBox1.Text = Managers_Module.SetValueForlabel6;
            FillSomeDetails();
            FillDatagrid();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }      
        //CLOSE
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //DELETE FROM RETURN TO SUPPLIER TABLE
        void Delete()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = $"DELETE FROM Return_To_Supplier WHERE Record_Number='" +Convert.ToInt32(txtRecordNO.Text)+ "'";
                    SqlCommand command = new SqlCommand(querry, sqlcon);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //REFRESH
        void RefreshWindow()
        {
            Return_To_Supplier rts = new Return_To_Supplier();
            rts.ShowDialog();
        }
        //VOID
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("Void_Return_To_Supplier_Add", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Return_Date",DateTime.Parse(txtDate.Text));
                        sqlcmd.Parameters.AddWithValue("@Return_Time",DateTime.Parse(txtTime.Text));
                        sqlcmd.Parameters.AddWithValue("@Returned_By", txtReturnedBy.Text);
                        sqlcmd.Parameters.AddWithValue("@Authorised_By", textBox1.Text);
                        sqlcmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                        sqlcmd.Parameters.AddWithValue("@Record_Number",Convert.ToInt32(txtRecordNO.Text));
                        sqlcmd.Parameters.AddWithValue("@GRN_Number", Convert.ToInt32(txtRequestedBy.Text));
                        sqlcmd.Parameters.AddWithValue("@Return_Reason", txtReson.Text);
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@SOH", dataGridView1.Rows[i].Cells["SOH"].Value);
                        sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@Return_Amount", dataGridView1.Rows[i].Cells["ToReturn"].Value);
                        sqlcmd.Parameters.AddWithValue("@TotalPrice", dataGridView1.Rows[i].Cells["TotalPrice"].Value);
                        sqlcmd.ExecuteNonQuery();
                        Hide();
                    }
            }
            catch (Exception)
            {
                MessageBox.Show("No more return to supplier to authorize");
            }
            Delete();
            MessageBox.Show("Operation Successful");            
            RefreshWindow();
        }
        //AUTHORIZE
        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                        {
                            if (sqlcon.State == ConnectionState.Closed)
                                sqlcon.Open();
                            SqlCommand sqlcmd = new SqlCommand("Authorize_Return_To_Supplier_Add", sqlcon);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Return_Date", DateTime.Parse(txtDate.Text));
                            sqlcmd.Parameters.AddWithValue("@Return_Time", DateTime.Parse(txtTime.Text));
                            sqlcmd.Parameters.AddWithValue("@Returned_By", txtReturnedBy.Text);
                            sqlcmd.Parameters.AddWithValue("@Authorised_By", textBox1.Text);
                            sqlcmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                            sqlcmd.Parameters.AddWithValue("@Record_Number", Convert.ToInt32(txtRecordNO.Text));
                            sqlcmd.Parameters.AddWithValue("@GRN_Number", Convert.ToInt32(txtRequestedBy.Text));
                            sqlcmd.Parameters.AddWithValue("@Return_Reason", txtReson.Text);
                            sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                            sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                            sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                            sqlcmd.Parameters.AddWithValue("@SOH", dataGridView1.Rows[i].Cells["SOH"].Value);
                            sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                            sqlcmd.Parameters.AddWithValue("@Return_Amount", dataGridView1.Rows[i].Cells["ToReturn"].Value);
                            sqlcmd.Parameters.AddWithValue("@TotalPrice", dataGridView1.Rows[i].Cells["TotalPrice"].Value);
                            sqlcmd.ExecuteNonQuery();
                            Hide();
                        }
                }
                catch (Exception)
                {
                    MessageBox.Show("No more return to supplier to authorize");
                }
                Delete();
                MessageBox.Show("Return to supplier successful");
                RefreshWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
