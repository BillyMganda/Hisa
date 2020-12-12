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
    public partial class Purchasing_Print_LPO : Form
    {
        public Purchasing_Print_LPO()
        {
            InitializeComponent();
        }
        //connection string
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //LOAD DETAILS
        public void Load_Details()
        {
            try
            {                
                SqlConnection con = new SqlConnection(connectionstring);
                string querry = "SELECT * FROM LPO_Authorised";
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtDate.Text = reader["Date"].ToString();
                    txtTime.Text = reader["Time"].ToString();
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
                    label28.Text = reader["Authorised_By"].ToString();
                    if (reader["PaymentMode"].ToString() == "Cash")
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
            catch (Exception)
            {
                MessageBox.Show("No new LPO to process at this time");
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
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Category,Units,Requested,ToOrder,ApproxUnitPrice,TotalAmount FROM LPO_Authorised WHERE RefNumber='" +Convert.ToInt32(txtRef.Text) + "'", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No new LPO to process at this time");
            }
        }
        //CALCULATION IN DATAGRID
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
        //AUTOCOMPLETE SUPPLIER NAME        
        private void Autocomplete_Supplier()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT SupplierName FROM Supplier_Info",con);
                DataSet ds = new DataSet();
                SqlDataAdapter adap = new SqlDataAdapter(command);
                adap.Fill(ds, "Supplier_Info");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["SupplierName"].ToString());
                }
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox1.AutoCompleteCustomSource = col;
                textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }     
        //SUPPLIER CHANGED
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection supplier_details=new AutoCompleteStringCollection();
            SqlConnection scon=new SqlConnection(connectionstring);
            scon.Open();
            SqlCommand cmnd = scon.CreateCommand();
            cmnd.CommandType = CommandType.Text;
            cmnd.CommandText = "SELECT * FROM Supplier_Info WHERE SupplierName = '"+textBox1.Text+"'";
            SqlDataReader dReader;
            dReader = cmnd.ExecuteReader();
            while (dReader.Read())
                {                    
                    textBox4.Text = dReader["SupplierAddress"].ToString();
                    textBox5.Text = dReader["Telephone1"].ToString();
                    textBox6.Text = dReader["EmailAddress"].ToString();
                    textBox7.Text = dReader["City"].ToString();
                }
            dReader.Close();
        }
        //CALCULATION TO LOAD
        public void Calculation_In_datagrid()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //LOAD
        private void Purchasing_Print_LPO_Load(object sender, EventArgs e)
        {
            Load_Details();
            Autocomplete_Supplier();
            FillDatagrid();
            Calculation_In_datagrid();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
        //REFRESH
        public void Refresh()
        {
            Purchasing_Print_LPO pprint = new Purchasing_Print_LPO();
            pprint.ShowDialog();
        }
        //TO  LPO DONE
        public void To_LPO_Done()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();
                string querry = "INSERT INTO LPO_Done(Date,Time,OrderNumber,RefNumber,RequestedBy,ExpectedDeliveryDate,SupplierName,Address,Telephone,Email,City,Department,PurchasingOfficer,PaymentMode,ItemName,ItemCode,Units,Requested,ToOrder,ApproxUnitPrice,TotalAmount,TotalTotalAmount,CAtegory,Authorised_By)SELECT Date,Time,OrderNumber,RefNumber,RequestedBy,ExpectedDeliveryDate,SupplierName,Address,Telephone,Email,City,Department,PurchasingOfficer,PaymentMode,ItemName,ItemCode,Units,Requested,ToOrder,ApproxUnitPrice,TotalAmount,TotalTotalAmount,CAtegory,Authorised_By FROM LPO_Authorised WHERE RefNumber='" + Convert.ToInt32(txtRef.Text) + "' DELETE FROM LPO_Authorised WHERE RefNumber='" + Convert.ToInt32(txtRef.Text) + "'";
                SqlCommand command = new SqlCommand(querry, con);
                command.ExecuteNonQuery();
                con.Close();
                Hide();                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //DEAL WITH RADIO BUTTONS TO LPO SUMMARY
        private string PaymentMode;
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
        //INSERT INTO LPO_DONE TABLE
        private void Insert_Into_LPO_Done()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("LPO_Done_Proc", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtDate.Text));
                        sqlcmd.Parameters.AddWithValue("@Time", DateTime.Parse(txtTime.Text));
                        sqlcmd.Parameters.AddWithValue("@OrderNumber", Convert.ToInt32(txtOrderNo.Text));
                        sqlcmd.Parameters.AddWithValue("@RefNumber", Convert.ToInt32(txtRef.Text));
                        sqlcmd.Parameters.AddWithValue("@RequestedBy", textBox2.Text);
                        sqlcmd.Parameters.AddWithValue("@ExpectedDeliveryDate", dateTimePicker1.Value);
                        sqlcmd.Parameters.AddWithValue("@SupplierName", textBox1.Text);
                        sqlcmd.Parameters.AddWithValue("@Address", textBox4.Text);
                        sqlcmd.Parameters.AddWithValue("@Telephone", textBox5.Text);
                        sqlcmd.Parameters.AddWithValue("@Email", textBox6.Text);
                        sqlcmd.Parameters.AddWithValue("@City", textBox7.Text);
                        sqlcmd.Parameters.AddWithValue("@Department", textBox8.Text);
                        sqlcmd.Parameters.AddWithValue("@PurchasingOfficer", textBox9.Text);
                        sqlcmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@Requested", dataGridView1.Rows[i].Cells["Quantity"].Value);
                        sqlcmd.Parameters.AddWithValue("@ToOrder", dataGridView1.Rows[i].Cells["ToPurchase"].Value);
                        sqlcmd.Parameters.AddWithValue("@ApproxUnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@Category", dataGridView1.Rows[i].Cells["SubGroup"].Value);
                        sqlcmd.Parameters.AddWithValue("@TotalAmount", dataGridView1.Rows[i].Cells["TotalPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@TotalTotalAmount", Convert.ToDecimal(txttotalTotalAmount.Text));
                        sqlcmd.Parameters.AddWithValue("@Authorised_By", label28.Text);
                        sqlcmd.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //INSERT INTO LPO_SUMMARY TABLE
        private void Insert_Into_LPO_Summary()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("LPO_Summary_Proc", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtDate.Text));
                        sqlcmd.Parameters.AddWithValue("@Time", DateTime.Parse(txtTime.Text));
                        sqlcmd.Parameters.AddWithValue("@OrderNumber", Convert.ToInt32(txtOrderNo.Text));
                        sqlcmd.Parameters.AddWithValue("@RefNumber", Convert.ToInt32(txtRef.Text));
                        sqlcmd.Parameters.AddWithValue("@RequestedBy", textBox2.Text);
                        sqlcmd.Parameters.AddWithValue("@ExpectedDeliveryDate", dateTimePicker1.Value);
                        sqlcmd.Parameters.AddWithValue("@SupplierName", textBox1.Text);
                        sqlcmd.Parameters.AddWithValue("@Address", textBox4.Text);
                        sqlcmd.Parameters.AddWithValue("@Telephone", textBox5.Text);
                        sqlcmd.Parameters.AddWithValue("@Email", textBox6.Text);
                        sqlcmd.Parameters.AddWithValue("@City", textBox7.Text);
                        sqlcmd.Parameters.AddWithValue("@Department", textBox8.Text);
                        sqlcmd.Parameters.AddWithValue("@PurchasingOfficer", textBox9.Text);
                        sqlcmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@Requested", dataGridView1.Rows[i].Cells["Quantity"].Value);
                        sqlcmd.Parameters.AddWithValue("@ToOrder", dataGridView1.Rows[i].Cells["ToPurchase"].Value);
                        sqlcmd.Parameters.AddWithValue("@ApproxUnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@Category", dataGridView1.Rows[i].Cells["SubGroup"].Value);
                        sqlcmd.Parameters.AddWithValue("@TotalAmount", dataGridView1.Rows[i].Cells["TotalPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@TotalTotalAmount", Convert.ToDecimal(txttotalTotalAmount.Text));
                        sqlcmd.Parameters.AddWithValue("@Authorised_By", label28.Text);
                        sqlcmd.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //DELETE LPO AFTER PRINTING
        void Delete_LPO()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = $"DELETE FROM LPO_Authorised WHERE RefNumber='" +Convert.ToInt32(txtRef.Text)+ "'";
                    SqlCommand command = new SqlCommand(querry, sqlcon);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //PRINT
        public static string reference_number;
        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            if (txtRef.Text == "")
                MessageBox.Show("No new LPOs to print");
            else
            {
                Insert_Into_LPO_Summary();
                Insert_Into_LPO_Done();
                reference_number = txtRef.Text;
                Delete_LPO();
                Hide();               
               
                //PRINT LPO            
                ToLPO tol = new ToLPO();
                tol.ShowDialog();
            }
        }
        
    }
}
