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
    public partial class Load_Stock_Items : Form
    {
        public Load_Stock_Items()
        {
            InitializeComponent();
        }
        //CONNECTION STRING
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //FILL SOME DETAILS
        void FilldateTimeStockBy()
        {
            string date = DateTime.Now.ToShortDateString();
            txtDate.Text = date;
            string time = DateTime.Now.ToShortTimeString();
            txtTime.Text = time;
        }
        //FILL DATAGRID
        private void FillDatagrid()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    string querry = "SELECT ItemName,ItemCode,Units,SubGroup FROM Approved_StockItems ORDER BY ItemName ASC";
                    SqlDataAdapter sqldata = new SqlDataAdapter(querry, connection);
                    DataTable dt = new DataTable();
                    sqldata.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //LOAD
        private void Load_Stock_Items_Load(object sender, EventArgs e)
        {
            textBox1.Text = IT_Support.SetValueForText1;
            FilldateTimeStockBy();
            FillDatagrid();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
        //CALCULATION IN DATAGRID
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[dataGridView1.Columns["TotalAmount"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["Stock"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["UnitPrice"].Index].Value));
                }
                //TOTAL
                //int sum = 0;
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["StockValue"].Value);
                //}
                //txtTotal.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }
        //SAVE TO GRN
        public void Save_To_GRN()
        {
           try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if(sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("Enter_New_Stocks", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtDate.Text));
                        sqlcmd.Parameters.AddWithValue("@Time", DateTime.Parse(txtTime.Text));
                        sqlcmd.Parameters.AddWithValue("@Stock_By", textBox1.Text);
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@Category", dataGridView1.Rows[i].Cells["SubGroup"].Value);
                        sqlcmd.Parameters.AddWithValue("@Stock", dataGridView1.Rows[i].Cells["Stock"].Value);
                        sqlcmd.Parameters.AddWithValue("@AVGPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@TotalPrice", dataGridView1.Rows[i].Cells["TotalAmount"].Value);
                        sqlcmd.ExecuteNonQuery();
                    }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //SAVE
        public static string date = "";
        public static string time = "";
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("NEW_STOCK_ADD", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtDate.Text));
                        sqlcmd.Parameters.AddWithValue("@Time", DateTime.Parse(txtTime.Text));
                        sqlcmd.Parameters.AddWithValue("@StocksBy", textBox1.Text);
                        sqlcmd.Parameters.AddWithValue("@ItemnName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@SubGroup", dataGridView1.Rows[i].Cells["SubGroup"].Value);
                        sqlcmd.Parameters.AddWithValue("@Stock", dataGridView1.Rows[i].Cells["Stock"].Value);
                        sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@TotalPrice", dataGridView1.Rows[i].Cells["TotalAmount"].Value);
                        sqlcmd.ExecuteNonQuery();                        
                    }
                Save_To_GRN();
                //CRYSTAL REPORT
                date = txtDate.Text;
                time = txtTime.Text;
                To_Enter_New_Stocks stocks = new To_Enter_New_Stocks();
                stocks.Show();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
