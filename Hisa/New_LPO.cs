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
    public partial class New_LPO : Form
    {      
        public New_LPO()
        {
            InitializeComponent();       
        }

        //connection string
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        string PaymentMode;

        //order details
        void OrderDetails()
        {
            try
            {
                //get current date and time to date and time textboxs
                string date = DateTime.Now.Date.ToShortDateString();
                txtDate.Text = date;
                string time = DateTime.Now.ToShortTimeString();
                txtTime.Text = time;
                dateTimePicker1.Value = DateTime.Now.AddDays(14);
                //fill Order number textbox with Random Value  

                Random r = new Random();
                int rInt = r.Next(0, 10000000);
                txtOrderNo.Text = rInt.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //fill Ref number textbox with value from database
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
        //Fill requested by textbox with data from database
        void RequestedBy()
        {
            string queri = "SELECT RequestedBy from PurchaseRequest";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            SqlCommand sqlcmd = new SqlCommand(queri, sqlcon);
            SqlDataReader sqlreader;
            try
            {
                sqlcon.Open();
                sqlreader = sqlcmd.ExecuteReader();
                while (sqlreader.Read())
                {
                    string firstname = (sqlreader["RequestedBy"].ToString());
                    textBox2.Text = firstname;

                }
                sqlcon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Supplier details
        void SupplierDetails()
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
        
        //fill department
        void Department()
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataReader myReader = null;
            SqlCommand command = new SqlCommand("SELECT Department FROM UserInfo WHERE FullNames='" + textBox9.Text + "'", con);
            DataTable dt = new DataTable();
            myReader = command.ExecuteReader();
            while (myReader.Read())
            {
                textBox8.Text = (myReader["Department"].ToString());
            }
            con.Close();
        }
        //Load window
        private void New_LPO_Load(object sender, EventArgs e)
        {
            OrderDetails();
            SupplierDetails();            
            RequestedBy();
            FillRefNumber();
            FillDatagrid();            
            textBox9.Text = Purchasing.SetValueForText2;
            Department();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
        //Fill Textboxes when supplier name is chosen  --  Supplier Name combobox event
        private void comboSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string querry = "SELECT SupplierAddress,Telephone1,EmailAddress,City from Supplier_Info where SupplierName='" + comboSupplierName.Text + "'";
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
        //Radio button Cash clicked event
        private void radioCash_CheckedChanged(object sender, EventArgs e)
        {
            PaymentMode = "Cash";
        }
        //Radio button Cheque clicked event
        private void radioCheque_CheckedChanged(object sender, EventArgs e)
        {
            PaymentMode = "Cheque";
        }
        //Radio button Credit clicked event
        private void radioCredit_CheckedChanged(object sender, EventArgs e)
        {
            PaymentMode = "Credit";
        }
        //Fill datagrid with data from PurchaseRequest table(method)
        void FillDatagrid()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,SubGroup,Units,Quantity FROM PurchaseRequest WHERE RequestNumber='" + txtRef.Text + "'", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
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
        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Delete current LPO after void,authorize,print
        void Delete()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = $"DELETE FROM PurchaseRequest WHERE RequestNumber='"+ txtRef .Text+ "'";
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
        void refreshWindow()
        {
            New_LPO newlpo = new New_LPO();
            newlpo.ShowDialog();
        }

        //SAVE
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboSupplierName.Text == "")
                MessageBox.Show("Please input all neccessary fields");
            else
            {
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
                            sqlcmd.Parameters.AddWithValue("@OrderNumber", txtOrderNo.Text);
                            sqlcmd.Parameters.AddWithValue("@RefNumber", txtRef.Text);
                            sqlcmd.Parameters.AddWithValue("@RequestedBy", textBox2.Text);
                            sqlcmd.Parameters.AddWithValue("@ExpectedDeliveryDate", dateTimePicker1.Text);
                            sqlcmd.Parameters.AddWithValue("@SupplierName", comboSupplierName.Text);
                            sqlcmd.Parameters.AddWithValue("@Address", textBox4.Text);
                            sqlcmd.Parameters.AddWithValue("@Telephone", textBox5.Text);
                            sqlcmd.Parameters.AddWithValue("@Email", textBox6.Text);
                            sqlcmd.Parameters.AddWithValue("@City", textBox7.Text);
                            sqlcmd.Parameters.AddWithValue("@PurchasingOfficer", textBox9.Text);
                            sqlcmd.Parameters.AddWithValue("@Department", textBox8.Text);
                            sqlcmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
                            sqlcmd.Parameters.AddWithValue("@TotalTotalAmount", txttotalTotalAmount.Text);
                            sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                            sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                            sqlcmd.Parameters.AddWithValue("@Category", dataGridView1.Rows[i].Cells["SubGroup"].Value);
                            sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                            sqlcmd.Parameters.AddWithValue("@Requested", dataGridView1.Rows[i].Cells["Quantity"].Value);
                            sqlcmd.Parameters.AddWithValue("@ToOrder", dataGridView1.Rows[i].Cells["ToPurchase"].Value);
                            sqlcmd.Parameters.AddWithValue("@ApproxUnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                            sqlcmd.Parameters.AddWithValue("@TotalAmount", dataGridView1.Rows[i].Cells["TotalPrice"].Value);
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
         
        //PRINT LPO
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Purchasing_Print_LPO pprint = new Purchasing_Print_LPO();
            pprint.ShowDialog();
        }
    }
}
