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
    public partial class Manager_LPO : Form
    {
        public Manager_LPO()
        {
            InitializeComponent();
        }
        string PaymentMode;
        //connection string
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //Load all textbox details method
        void FillSomeDetails()
        {
            try
            {
                string querry = "SELECT * FROM LPO";
                SqlConnection con = new SqlConnection(connectionstring);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtDate.Text = reader["Date"].ToString();
                    txtTime.Text= reader["Time"].ToString();
                    txtOrderNo.Text = reader["OrderNumber"].ToString();
                    txtRef.Text = reader["RefNumber"].ToString();
                    textBox2.Text = reader["RequestedBy"].ToString();
                    dateTimePicker1.Text = reader["ExpectedDeliveryDate"].ToString();
                    textBox1.Text = reader["SupplierName"].ToString();
                    textBox4.Text = reader["Address"].ToString();
                    textBox5.Text = reader["Telephone"].ToString();
                    textBox6.Text = reader["Email"].ToString();
                    textBox7.Text = reader["City"].ToString();
                    textBox8.Text = reader["Department"].ToString();
                    textBox9.Text = reader["PurchasingOfficer"].ToString();                    
                    if (reader["PaymentMode"].ToString()=="Cash")
                    {
                        radioCash.Checked = true;
                    }
                    else
                        radioCash.Checked = false;
                    if (reader["PaymentMode"].ToString() == "Cheque")
                    {
                        radioCheque.Checked = true;
                    }
                    else
                        radioCheque.Checked = false;
                    if (reader["PaymentMode"].ToString() == "Credit")
                    {
                        radioCredit.Checked = true;
                    }
                    else
                        radioCredit.Checked = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Load Datagrid with data from database
        void FillDatagrid()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Category,Units,Requested,ToOrder,ApproxUnitPrice,TotalAmount FROM LPO WHERE RefNumber='" +Convert.ToInt32(txtRef.Text)+ "'", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No more LPOs to Approve/void");
            }
        }
        //load window
        private void Manager_LPO_Load(object sender, EventArgs e)
        {
            label28.Text = Managers_Module.SetValueForlabel6;
            FillSomeDetails();
            FillDatagrid();
            Calculation_In_Datagrid();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }

        private void radioCash_CheckedChanged(object sender, EventArgs e)
        {
            PaymentMode = "Cash";
        }

        private void radioCheque_CheckedChanged(object sender, EventArgs e)
        {
            PaymentMode = "Cheque";
        }

        private void radioCredit_CheckedChanged(object sender, EventArgs e)
        {
            PaymentMode = "Credit";
        }
        //Calculations in datagrid
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[dataGridView1.Columns["TotalPrice"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["UnitPrice"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["ToPurchase"].Index].Value));
                }
                //Datagrid column total
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["TotalPrice"].Value);
                }
                txttotalTotalAmount.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        
        //CALCULATION IN DATAGRID
        public void Calculation_In_Datagrid()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[dataGridView1.Columns["TotalPrice"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["UnitPrice"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["ToPurchase"].Index].Value));
                }
                //Datagrid column total
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["TotalPrice"].Value);
                }
                txttotalTotalAmount.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Refresh New_LPO form
        void refreshWindow()
        {
            Manager_LPO newlpo = new Manager_LPO();
            newlpo.ShowDialog();
        }
        //DELETE FROM LPO TABLE AFTER AUTHORIZE
        void Delete()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = "DELETE FROM LPO WHERE RefNumber='"+int.Parse(txtRef.Text)+"'";
                    SqlCommand command = new SqlCommand(querry, sqlcon);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Fill_VoidedBy()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionstring))
                {
                    string query = "UPDATE LPO_Voided SET Voided_By=@Voided_By WHERE LPO_VoidID=(SELECT MAX(LPO_VoidID) FROM LPO_Voided)";
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@Voided_By", label28.Text);
                    cmd.ExecuteNonQuery();
                }                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //VOID
        private void btnVoid_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();
                string querry = "INSERT INTO LPO_Voided (Date,Time,OrderNumber,RefNumber,RequestedBy,ExpectedDeliveryDate,SupplierName,Address,Telephone,Email,City,Department,PurchasingOfficer,PaymentMode,ItemName,ItemCode,Units,Requested,ToOrder,ApproxUnitPrice,TotalAmount,TotalTotalAmount,Category) SELECT Date,Time,OrderNumber,RefNumber,RequestedBy,ExpectedDeliveryDate,SupplierName,Address,Telephone,Email,City,Department,PurchasingOfficer,PaymentMode,ItemName,ItemCode,Units,Requested,ToOrder,ApproxUnitPrice,TotalAmount,TotalTotalAmount,Category FROM LPO WHERE RefNumber='" + Convert.ToInt32(txtRef.Text) + "' DELETE FROM LPO WHERE RefNumber='" + Convert.ToInt32(txtRef.Text) + "'";
                SqlCommand command = new SqlCommand(querry, con);
                command.ExecuteNonQuery();
                con.Close();
                Fill_VoidedBy();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            refreshWindow();           
        }
        //AUTHORIZE
        private void btnAuthorize_Click(object sender, EventArgs e)
        {           
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                        {
                            if (sqlcon.State == ConnectionState.Closed)
                                sqlcon.Open();
                            SqlCommand sqlcmd = new SqlCommand("AUTHORISED_LPOADD", sqlcon);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Date", txtDate.Text);
                            sqlcmd.Parameters.AddWithValue("@Time", txtTime.Text);
                            sqlcmd.Parameters.AddWithValue("@OrderNumber",Convert.ToInt32(txtOrderNo.Text));
                            sqlcmd.Parameters.AddWithValue("@RefNumber",Convert.ToInt32(txtRef.Text));
                            sqlcmd.Parameters.AddWithValue("@RequestedBy", textBox2.Text);
                            sqlcmd.Parameters.AddWithValue("@ExpectedDeliveryDate", dateTimePicker1.Value);
                            sqlcmd.Parameters.AddWithValue("@SupplierName", textBox1.Text);
                            sqlcmd.Parameters.AddWithValue("@Address", textBox4.Text);
                            sqlcmd.Parameters.AddWithValue("@Telephone", textBox5.Text);
                            sqlcmd.Parameters.AddWithValue("@Email", textBox6.Text);
                            sqlcmd.Parameters.AddWithValue("@City", textBox7.Text);
                            sqlcmd.Parameters.AddWithValue("@PurchasingOfficer", textBox9.Text);
                            sqlcmd.Parameters.AddWithValue("@Department", textBox8.Text);
                            sqlcmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
                            sqlcmd.Parameters.AddWithValue("@TotalTotalAmount",Convert.ToDecimal(txttotalTotalAmount.Text));
                            sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                            sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                            sqlcmd.Parameters.AddWithValue("@Category", dataGridView1.Rows[i].Cells["SubGroup"].Value);
                            sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                            sqlcmd.Parameters.AddWithValue("@Requested", dataGridView1.Rows[i].Cells["Quantity"].Value);
                            sqlcmd.Parameters.AddWithValue("@ToOrder", dataGridView1.Rows[i].Cells["ToPurchase"].Value);
                            sqlcmd.Parameters.AddWithValue("@ApproxUnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                            sqlcmd.Parameters.AddWithValue("@TotalAmount", dataGridView1.Rows[i].Cells["TotalPrice"].Value);
                            sqlcmd.Parameters.AddWithValue("@Authorised_By", label28.Text);
                            sqlcmd.ExecuteNonQuery();
                            Hide();
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            Delete();
            refreshWindow();
        }
    }
}
