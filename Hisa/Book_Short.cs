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
    public partial class Book_Short : Form
    {
        public Book_Short()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //ADD TO CART DATAGRID
        private void AutoFillAddToCartDatagrid()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Units,SOH,Price,StockValue FROM Stores ORDER BY ItemName ASC", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGridCart.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //TEXT CHANGED
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT ItemName,ItemCode,Units,SOH,Price,StockValue FROM Stores WHERE ItemName LIKE '" + txtSearch.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridCart.DataSource = dt;
            con.Close();
        }
        //ADD TO CART
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            for (int i = 0; i < dataGridCart.Rows.Count; i++)
            {
                row = (DataGridViewRow)dataGridCart.Rows[i].Clone();
                int intColIndex = 0;
                foreach (DataGridViewCell cell in dataGridCart.Rows[i].Cells)
                {
                    row.Cells[intColIndex].Value = cell.Value;
                    intColIndex++;
                }
                dataGridCheckOut.Rows.Add(row);
            }
            dataGridCheckOut.AllowUserToAddRows = false;
            dataGridCheckOut.Refresh();
        }
        //LOAD RECORD NUMBER
        private void LoadRecordNumber()
        {
            Random rnd = new Random();
            int tal = rnd.Next(0, 10000000);
            textBox1.Text = tal.ToString();
        }
        //LOAD
        private void Book_Short_Load(object sender, EventArgs e)
        {
            AutoFillAddToCartDatagrid();
            LoadRecordNumber();
            //Load Date and Time
            string dt = DateTime.Now.Date.ToShortDateString();
            txtDate.Text = dt;
            string time = DateTime.Now.ToShortTimeString();
            txtTime.Text = time;
            txtRecordBy.Text = Stock_Adjustment.Transfer_Name;

            this.dataGridCart.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridCart.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;

            this.dataGridCheckOut.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridCheckOut.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }

        //CALCULATION
        private void dataGridCheckOut_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridCheckOut.Rows)
                {
                    row.Cells[dataGridCheckOut.Columns["Total1"].Index].Value = (Convert.ToDouble(row.Cells[dataGridCheckOut.Columns["Book"].Index].Value) * Convert.ToDouble(row.Cells[dataGridCheckOut.Columns["UnitPrice1"].Index].Value));
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
            Book_Short bo = new Book_Short();
            bo.ShowDialog();
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
                MessageBox.Show("Reason must be included in a book short");
            else
            {
                try
                {
                    for (int i = 0; i < dataGridCheckOut.Rows.Count; i++)
                        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                        {
                            if (sqlcon.State == ConnectionState.Closed)
                                sqlcon.Open();
                            SqlCommand sqlcmd = new SqlCommand("Book_Short_Add", sqlcon);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtDate.Text));
                            sqlcmd.Parameters.AddWithValue("@Time", DateTime.Parse(txtTime.Text));
                            sqlcmd.Parameters.AddWithValue("@Record_By", txtRecordBy.Text);
                            sqlcmd.Parameters.AddWithValue("@Record_Number", int.Parse(textBox1.Text));
                            sqlcmd.Parameters.AddWithValue("@ItemName", dataGridCheckOut.Rows[i].Cells["ItemName1"].Value);
                            sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridCheckOut.Rows[i].Cells["ItemCode1"].Value);
                            sqlcmd.Parameters.AddWithValue("@Units", dataGridCheckOut.Rows[i].Cells["Units1"].Value);
                            sqlcmd.Parameters.AddWithValue("@SOH", dataGridCheckOut.Rows[i].Cells["SOH1"].Value);
                            sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridCheckOut.Rows[i].Cells["UnitPrice1"].Value);
                            sqlcmd.Parameters.AddWithValue("@StockValue", dataGridCheckOut.Rows[i].Cells["StockValue1"].Value);
                            sqlcmd.Parameters.AddWithValue("@Book_Value", dataGridCheckOut.Rows[i].Cells["Book"].Value);
                            sqlcmd.Parameters.AddWithValue("@Total_Book_Value", dataGridCheckOut.Rows[i].Cells["Total1"].Value);
                            sqlcmd.Parameters.AddWithValue("@Book_Reason", txtReason.Text);
                            sqlcmd.ExecuteNonQuery();
                        }
                    MessageBox.Show("Book Short Succcessful");
                    dataGridCheckOut.Rows.Clear();
                    LoadRecordNumber();
                    txtReason.Text = "";
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
            Print_Book_Short sh=new Print_Book_Short();
            sh.ShowDialog();
        }

        
    }
}
