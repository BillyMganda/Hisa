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
    public partial class Purchase_Order : Form
    {
        public Purchase_Order()
        {
            InitializeComponent();
            FillSupplierNameCombo();
            FillPaymentMode();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=ADMIN-PC\SQLEXPRESS; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        //save button
        private void btnSave_Click(object sender, EventArgs e)
        {                  
            if (comboSupplierName.Text == "" || comboPaymentMode.Text == "" )
                MessageBox.Show("Please input all neccessary fields");
            else
          try
          {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();                    

                        SqlCommand sqlcmd = new SqlCommand("LPOAdd", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Date", txtDate.Text);     
                        sqlcmd.Parameters.AddWithValue("@Time", txtTime.Text);
                        sqlcmd.Parameters.AddWithValue("@RefNumber", txtRef.Text);
                        sqlcmd.Parameters.AddWithValue("@RequestedBy", textBox2.Text);
                        sqlcmd.Parameters.AddWithValue("@ExpectedDeliveryDate", dateTimePicker1.Text);
                        sqlcmd.Parameters.AddWithValue("@SupplierName", comboSupplierName.Text);
                        sqlcmd.Parameters.AddWithValue("@Address", textBox4.Text);
                        sqlcmd.Parameters.AddWithValue("@Telephone", textBox5.Text);
                        sqlcmd.Parameters.AddWithValue("@Email", textBox6.Text);
                        sqlcmd.Parameters.AddWithValue("@City", textBox7.Text);
                        sqlcmd.Parameters.AddWithValue("@Department", textBox8.Text);
                        sqlcmd.Parameters.AddWithValue("@PurchasingOfficer", textBox9.Text);
                        sqlcmd.Parameters.AddWithValue("@PaymentMode", comboPaymentMode.Text);
                        sqlcmd.Parameters.AddWithValue("@TotalTotalAmount", txttotalTotalAmount.Text);
                            sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                            sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                            sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                            sqlcmd.Parameters.AddWithValue("@Requested", dataGridView1.Rows[i].Cells["Quantity"].Value);
                            sqlcmd.Parameters.AddWithValue("@ToOrder", dataGridView1.Rows[i].Cells["ToOrder"].Value);
                            sqlcmd.Parameters.AddWithValue("@ApproxUnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                            sqlcmd.Parameters.AddWithValue("@TotalAmount", dataGridView1.Rows[i].Cells["TotalAmount"].Value);
                            sqlcmd.ExecuteNonQuery();                      
                }
          }
          catch(Exception ex)
          {
            MessageBox.Show(ex.Message);
          }
            //Delete purchase request after save button is hit
            DeletePurchaseRequest();
            MessageBox.Show("Operation Successful");
        }
        //Delete purchase request after save button is hit and transefer the data to Data_PurchaseRequest table
        void DeletePurchaseRequest()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    SqlCommand sqlcmd = new SqlCommand("DELETEPURCHASE", sqlcon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //void button
        private void btnVoid_Click(object sender, EventArgs e)
        {

        }
        //authorize button
        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            Authorize_LPOs al = new Authorize_LPOs();
            al.ShowDialog();
        }
        //Fill Payment Mode with data from database
        void FillPaymentMode()
        {
            string querry = "SELECT DISTINCT Mode from Payment_Mode";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            SqlCommand sqlcmd = new SqlCommand(querry, sqlcon);
            SqlDataReader sqlreader;
            try
            {
                sqlcon.Open();
                sqlreader = sqlcmd.ExecuteReader();
                while (sqlreader.Read())
                {
                    string Gname = sqlreader.GetString(0);
                    comboPaymentMode.Items.Add(Gname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Fill Supplier Name combobox with data from database
        void FillSupplierNameCombo()
        {
            string querry = "SELECT DISTINCT SupplierName from Supplier_Info";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            SqlCommand sqlcmd = new SqlCommand(querry, sqlcon);
            SqlDataReader sqlreader;
            try
            {
                sqlcon.Open();
                sqlreader = sqlcmd.ExecuteReader();
                while (sqlreader.Read())
                {
                    string Gname = sqlreader.GetString(0);
                    comboSupplierName.Items.Add(Gname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //Load window
        private void Purchase_Order_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet_For_LPO.PurchaseRequest' table. You can move, or remove it, as needed.
            this.purchaseRequestTableAdapter1.Fill(this.dataSet_For_LPO.PurchaseRequest);
            // TODO: This line of code loads data into the 'dataSet_LPO.PurchaseRequest' table. You can move, or remove it, as needed.
            this.purchaseRequestTableAdapter.Fill(this.dataSet_LPO.PurchaseRequest);
            //get current date and time to date and time textboxs
            string date = System.DateTime.Now.Date.ToString();
            txtDate.Text = date;
            string time = System.DateTime.Now.TimeOfDay.ToString();
            txtTime.Text = time;
            
            dateTimePicker1.Value = DateTime.Now.AddDays(14);
            //Requested by - get name of storekeeper
            string queri= "SELECT FirstName, LastName from UserInfo where Role='Storekeeper'";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            SqlCommand sqlcmd = new SqlCommand(queri, sqlcon);
            SqlDataReader sqlreader;
            try
            {
                sqlcon.Open();
                sqlreader = sqlcmd.ExecuteReader();
                while (sqlreader.Read())
                {
                    string firstname = sqlreader["FirstName"].ToString() + " " + sqlreader["LastName"].ToString();
                    textBox2.Text = firstname; 
                                    
                }
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //end of Requested by.
            //Purchasing officer - get name of purchasing officer
            string quer = "SELECT FirstName, LastName from UserInfo where Role='Purchasing'";
            SqlConnection sqlco = new SqlConnection(connectionstring);
            SqlCommand sqlcm = new SqlCommand(quer, sqlco);
            SqlDataReader sqlreada;
            try
            {
                sqlco.Open();
                sqlreada = sqlcm.ExecuteReader();
                while (sqlreada.Read())
                {
                    string firstnem = sqlreada["FirstName"].ToString() + " " + sqlreada["LastName"].ToString();
                    textBox9.Text = firstnem;
                }
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //end of purchasing officer.
            //Autofill data with department
            string depart= "SELECT Department from UserInfo where Role='Purchasing'";
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand command = new SqlCommand(depart, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = command.ExecuteReader();
                while(reader.Read())
                {
                    string department = reader["Department"].ToString();
                    textBox8.Text = department;
                }
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Fill datagrid with data from stock items table
            //FillDatagrid();
            //autofill Order number textbox with value from database
            FillOrderNumber();
            //autofill Ref number textbox with value from database
            FillRefNumber();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
        //autofill Ref number textbox with value from database
        void FillRefNumber()
        {
            try
            {
                string querry = "SELECT RequestNumber FROM PurchaseRequest";
                SqlConnection con = new SqlConnection(connectionstring);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int value = int.Parse(reader[0].ToString());
                    txtRef.Text = value.ToString();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //autofill Order number textbox with value from database
        void FillOrderNumber()
        {
            try
            {
                string querry = "SELECT LPOID FROM LPO";
                SqlConnection con = new SqlConnection(connectionstring);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int value = int.Parse(reader[0].ToString()) + 1;
                    txtOrderNo.Text = value.ToString();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Fill datagrid with data from PurchaseRequest table(method)
        void FillDatagrid()
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("SELECT ItemName,ItemCode,Units,Quantity FROM PurchaseRequest", sqlcon);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }        
        //Fill Textboxes when supplier name is chosen  --  Supplier Name combobox event
        private void comboSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string querry = "SELECT SupplierAddress,Telephone1,EmailAddress,City from Supplier_Info where SupplierName='" + comboSupplierName.Text+ "'";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            SqlCommand sqlcmd = new SqlCommand(querry, sqlcon);
            SqlDataReader sqlreader;
            try
            {
                sqlcon.Open();
                sqlreader = sqlcmd.ExecuteReader();
                while (sqlreader.Read())
                {
                    string address = sqlreader["SupplierAddress"].ToString();
                    string telephone = sqlreader["Telephone1"].ToString();
                    string email = sqlreader["EmailAddress"].ToString();
                    string city = sqlreader["City"].ToString();
                    textBox4.Text = address;
                    textBox5.Text = telephone;
                    textBox6.Text = email;
                    textBox7.Text = city;
                }
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Calculations in datagrid
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[dataGridView1.Columns["TotalAmount"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["UnitPrice"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["ToOrder"].Index].Value));
                }
                //Datagrid column total
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["TotalAmount"].Value);
                }
                txttotalTotalAmount.Text = sum.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //when delete item is clicked on the binding navigator   Void_LPO
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {                                                
                        SqlCommand sqlcmd = new SqlCommand("SaveToVoid_LPO", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@RequestNumber", txtRef.Text.Trim());
                        sqlcmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
