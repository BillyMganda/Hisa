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
    public partial class Processed_GRN : Form
    {
        public Processed_GRN()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //LOAD DETAILS
        private void Load_Details()
        {
            try
            {
                string querry = "SELECT * FROM GRN WHERE GRNNumber='" + Convert.ToInt32(textBox12.Text) + "'";
                SqlConnection con = new SqlConnection(connectionstring);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime.Parse(txtDate.Text = reader["Delivery_Date"].ToString());
                    DateTime.Parse(txtTime.Text = reader["Delivery_Time"].ToString());
                    int.Parse(textBox3.Text = reader["OrderNumber"].ToString());
                    int.Parse(textBox4.Text = reader["RefNumber"].ToString());
                    textBox5.Text = reader["Department"].ToString();
                    textBox6.Text = reader["PurchasingOfficer"].ToString();
                    textBox7.Text = reader["ReceivedBy"].ToString();
                    textBox1.Text = reader["InvoiceNumber"].ToString();
                    textBox2.Text = reader["DeliveryNoteNumber"].ToString();
                    textBox8.Text = reader["SupplierName"].ToString();
                    textBox9.Text = reader["Address"].ToString();
                    textBox10.Text = reader["Telephone"].ToString();
                    textBox11.Text = reader["Email"].ToString();
                    decimal.Parse(txtTotal.Text = reader["TotalTotalAmount"].ToString());
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
        //FILL DATAGRID
        private void Fill_Datagrid()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Units,Category,UnitPrice,Delivered,TotalAmount FROM GRN WHERE GRNNumber='" + Convert.ToInt32(textBox12.Text) + "'", sqlcon);
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
        //LOAD
        private void Processed_GRN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet_ToProcessedGRN.GRN' table. You can move, or remove it, as needed.
            this.gRNTableAdapter.Fill(this.dataSet_ToProcessedGRN.GRN);
            Load_Details();
            Fill_Datagrid();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }


        //PREVIOUS
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            Load_Details();
            Fill_Datagrid();
        }
        //NEXT
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            Load_Details();
            Fill_Datagrid();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            Close();
        }
        //PRINT
        public static string GRN_Number = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
                MessageBox.Show("You can not print an empty GRN");
            else
            {
                GRN_Number = textBox12.Text;
                To_ProcessedGRN grn = new To_ProcessedGRN();
                grn.Show();
            }

        }
        //SEARCH
        private void button2_Click(object sender, EventArgs e)
        {
            GRN_Search_LPO gsl=new GRN_Search_LPO();
            gsl.ShowDialog();
        }
    }
}
