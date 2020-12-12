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
    public partial class ReturnToStore : Form
    {
        public ReturnToStore()
        {
            InitializeComponent();            
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //AUTO FILL ADD TO CARD DATAGRID
        private void AutoFillAddToCartDatagrid()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Units,SOH,Price FROM Stores", connection);
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
        //TEXT CHANGED IN SEARCH TEXTBOX
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT ItemName,ItemCode,Units,SOH,Price FROM Stores WHERE ItemName LIKE '" + txtSearch.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //PREVENT DUPLICATES IN DATAGRID
        private void Duplicates()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                string str = dataGridView2.Rows[i].Cells[0].Value.ToString();
                if (!list.Contains(str))
                    list.Add(dataGridView2.Rows[i].Cells[0].Value.ToString());
                else
                {
                    dataGridView2.Rows.Remove(dataGridView2.Rows[i]);
                }
            }
        }

        //ADD TO CART BUTTON
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                int intColIndex = 0;
                foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                {
                    row.Cells[intColIndex].Value = cell.Value;
                    intColIndex++;
                }
                dataGridView2.Rows.Add(row);
            }
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.Refresh();
            Duplicates();
        }
        //LOAD
        private void ReturnToStore_Load(object sender, EventArgs e)
        {
            AutoFillAddToCartDatagrid();
            //get current date and time to date and time textboxs
            string date = DateTime.Now.Date.ToShortDateString();
            txtDate.Text = date;
            string time = DateTime.Now.ToShortTimeString();
            txtTime.Text = time;
            FillRecordNumber();
            txtRecordNumber.Text = Storekeeper.SetValueForlabel5;

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;

            this.dataGridView2.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }        
        //FILL RECORD NUMBER - RANDOM
        void FillRecordNumber()
        {
            Random rnd = new Random();
            int tal = rnd.Next(0, 10000000);
            textBox1.Text = tal.ToString();
        }
        
        //CALCULATIONS IN DATAGRID
        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    row.Cells[dataGridView2.Columns["TotalPrice"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView2.Columns["Qty"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView2.Columns["UnitPrice1"].Index].Value));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }        
       
        //CANCEL BUTTON
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //SAVE
        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (txtReason.Text == "")
                MessageBox.Show("Reason for this transaction not given");
            else
            {
                try
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                        {
                            if (sqlcon.State == ConnectionState.Closed)
                                sqlcon.Open();
                            SqlCommand sqlcmd = new SqlCommand("RETURN_TO_STORE_PROC", sqlcon);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtDate.Text));
                            sqlcmd.Parameters.AddWithValue("@Time", DateTime.Parse(txtTime.Text));
                            sqlcmd.Parameters.AddWithValue("@RecordBy", txtRecordNumber.Text);
                            sqlcmd.Parameters.AddWithValue("@RecordNumber", int.Parse(textBox1.Text));
                            sqlcmd.Parameters.AddWithValue("@Reason", txtReason.Text);
                            sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView2.Rows[i].Cells["ItemName1"].Value);
                            sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView2.Rows[i].Cells["ItemCode1"].Value);
                            sqlcmd.Parameters.AddWithValue("@Units", dataGridView2.Rows[i].Cells["Units1"].Value);
                            sqlcmd.Parameters.AddWithValue("@SOH", dataGridView2.Rows[i].Cells["SOH1"].Value);
                            sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView2.Rows[i].Cells["UnitPrice1"].Value);
                            sqlcmd.Parameters.AddWithValue("Qty", dataGridView2.Rows[i].Cells["Qty"].Value);
                            sqlcmd.Parameters.AddWithValue("@TotalPrice", dataGridView2.Rows[i].Cells["TotalPrice"].Value);
                            sqlcmd.ExecuteNonQuery();                            
                        }
                    MessageBox.Show("Return Succcessful");
                    dataGridView2.Rows.Clear();
                    txtReason.Text = "";
                    FillRecordNumber();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }               
            }
        }
        //PRINT
        private void button1_Click(object sender, EventArgs e)
        {
            Print_Return_To_Store pri = new Print_Return_To_Store();
            pri.ShowDialog();
        }
    }
}
