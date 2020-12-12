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
    public partial class GRN : Form
    {
        

        public GRN()
        {
            InitializeComponent();            
        }
        string PaymentMode;
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //FILL MOST DETAILS
        void FillSomeDetails()
        {
            try
            {
                string querry = "SELECT * FROM LPO_Done WHERE RefNumber='"+Convert.ToInt32(textBox4.Text)+"'";
                SqlConnection con = new SqlConnection(connectionstring);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Convert.ToInt32(textBox3.Text = reader["OrderNumber"].ToString());
                    //Int32.Parse(textBox4.Text=reader["RefNumber"].ToString());
                    textBox5.Text = reader["Department"].ToString();
                    textBox6.Text = reader["PurchasingOfficer"].ToString();                   
                    textBox8.Text = reader["SupplierName"].ToString();
                    textBox9.Text = reader["Address"].ToString();
                    textBox10.Text = reader["Telephone"].ToString();
                    textBox11.Text = reader["Email"].ToString();
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
                throw;
            }
        }
        //Fill Datagrid
        void FillDatagrid()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Units,Category,ApproxUnitPrice FROM LPO_Done WHERE RefNumber='" +Convert.ToInt32(textBox4.Text)+ "'", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No GRN to process at this time");
            }
        }
        //Calculations inside datagrid
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {                    
                    row.Cells[dataGridView1.Columns["TotalAmount"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["UnitPrice"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["Delivered"].Index].Value));
                }
                //Datagrid column total
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["TotalAmount"].Value);
                }
                txtTotal.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   
        
        //Load window
        private void GRN_Load(object sender, EventArgs e)
        {
            
                // TODO: This line of code loads data into the 'dataSet_GRN_Binding.LPO_Done' table. You can move, or remove it, as needed.
                this.lPO_DoneTableAdapter.Fill(this.dataSet_GRN_Binding.LPO_Done);
            
            
            textBox7.Text = Storekeeper.SetValueForlabel5;
            FillDatagrid();
            FillSomeDetails();
            //date and time
            string date = DateTime.Now.Date.ToShortDateString();
            Convert.ToDateTime(txtDate.Text = date);
            string time = DateTime.Now.ToShortTimeString();
            Convert.ToDateTime(txtTime.Text = time);
            //RANDOM GRN NUMBER
            Random r = new Random();
            int rInt = r.Next(0, 1000000);
            textBox12.Text = rInt.ToString();

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
        //cancel button
        private void btnAddToCart_Click(object sender, EventArgs e)
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
                    string querry = $"DELETE FROM Authorised_LPO WHERE RefNumber='" + textBox3.Text + "'";
                    SqlCommand command = new SqlCommand(querry, sqlcon);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //DELETE FROM LPO_DONE TABLE
        private void Delete_From_LPO_Done()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = "DELETE FROM LPO_Done WHERE RefNumber='" + Convert.ToInt32(textBox4.Text) + "'";
                    SqlCommand command = new SqlCommand(querry, sqlcon);
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //SAVE
        public static string GRN_To_Transfer="";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
                MessageBox.Show("No GRN to process at this time");
            else
            {
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();
                try
                {
                    if (textBox1.Text == "")
                        MessageBox.Show("You can not process GRN without invoice number");
                    else
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO GRN(Delivery_Date,Delivery_Time,OrderNumber,RefNumber,Department,PurchasingOfficer,ReceivedBy,GRNNumber,InvoiceNumber,DeliveryNoteNumber,SupplierName,Address,Telephone,Email,PaymentMode,ItemName,ItemCode,Units,Category,UnitPrice,Delivered,TotalAmount,TotalTotalAmount)VALUES(@Delivery_Date,@Delivery_Time,@OrderNumber,@RefNumber,@Department,@PurchasingOfficer,@ReceivedBy,@GRNNumber,@InvoiceNumber,@DeliveryNoteNumber,@SupplierName,@Address,@Telephone,@Email,@PaymentMode,@ItemName,@ItemCode,@Units,@Category,@UnitPrice,@Delivered,@TotalAmount,@TotalTotalAmount)", con))
                            {
                                cmd.Parameters.AddWithValue("@Delivery_Date", DateTime.Parse(txtDate.Text));
                                cmd.Parameters.AddWithValue("@Delivery_Time", DateTime.Parse(txtTime.Text));
                                cmd.Parameters.AddWithValue("@OrderNumber", Convert.ToInt32(textBox3.Text));
                                cmd.Parameters.AddWithValue("@RefNumber", Convert.ToInt32(textBox4.Text));
                                cmd.Parameters.AddWithValue("@Department", textBox5.Text);
                                cmd.Parameters.AddWithValue("@PurchasingOfficer", textBox6.Text);
                                cmd.Parameters.AddWithValue("@ReceivedBy", textBox7.Text);
                                cmd.Parameters.AddWithValue("@GRNNumber", Convert.ToInt32(textBox12.Text));
                                cmd.Parameters.AddWithValue("@InvoiceNumber", textBox1.Text);
                                cmd.Parameters.AddWithValue("@DeliveryNoteNumber", textBox2.Text);
                                cmd.Parameters.AddWithValue("@SupplierName", textBox8.Text);
                                cmd.Parameters.AddWithValue("@Address", textBox9.Text);
                                cmd.Parameters.AddWithValue("@Telephone", textBox10.Text);
                                cmd.Parameters.AddWithValue("@Email", textBox11.Text);
                                cmd.Parameters.AddWithValue("@PaymentMode", PaymentMode);
                                cmd.Parameters.AddWithValue("@ItemName", row.Cells["ItemName"].Value);
                                cmd.Parameters.AddWithValue("@ItemCode", row.Cells["ItemCode"].Value);
                                cmd.Parameters.AddWithValue("@Units", row.Cells["Units"].Value);
                                cmd.Parameters.AddWithValue("@Category", row.Cells["Category"].Value);
                                cmd.Parameters.AddWithValue("@UnitPrice", row.Cells["UnitPrice"].Value);
                                cmd.Parameters.AddWithValue("@Delivered", row.Cells["Delivered"].Value);
                                cmd.Parameters.AddWithValue("@TotalAmount", row.Cells["TotalAmount"].Value);
                                cmd.Parameters.AddWithValue("@TotalTotalAmount", Convert.ToDecimal(txtTotal.Text));
                                cmd.ExecuteNonQuery();
                                Hide();
                            }
                        }
                        Delete_From_LPO_Done();
                        GRN_To_Transfer = textBox12.Text;
                        ToGRN togrn = new ToGRN();
                        togrn.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //PREVIOUS
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            FillSomeDetails();
            FillDatagrid();
            // RANDOM GRN NUMBER
            Random r = new Random();
            int rInt = r.Next(0, 1000000);
            textBox12.Text = rInt.ToString();
        }
        //NEXT
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            FillSomeDetails();
            FillDatagrid();
            // RANDOM GRN NUMBER
            Random r = new Random();
            int rInt = r.Next(0, 1000000);
            textBox12.Text = rInt.ToString();
        }
        //PROCESSED GRN
        private void button2_Click(object sender, EventArgs e)
        {
            Processed_GRN grn=new Processed_GRN();
            grn.ShowDialog();
        }        
    }
}
