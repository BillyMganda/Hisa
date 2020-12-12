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
    public partial class Stock_Count : Form
    {
        public Stock_Count()
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
        //FILL RECORD NUMBER
        void FillRecordNumber()
        {
            try
            {
                string querry = "SELECT RecordNumber FROM Physical_Stock_Count";
                SqlConnection con = new SqlConnection(connectionstring);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int value = int.Parse(reader[0].ToString()) + 1;
                    textBox2.Text = value.ToString();
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //FILL DATAGRID
        private void FillDatagrid()
        {            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    string querry = "SELECT ItemName,ItemCode,Units,SubGroup,Price FROM VIEW_FOR_STOCK_ITEMS ORDER BY ItemName ASC";
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
        private void Stock_Count_Load(object sender, EventArgs e)
        {
            FilldateTimeStockBy();
            FillRecordNumber();
            FillDatagrid();
            textBox1.Text = Statistics.LoggedInUser;

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }

        //CANCEL
        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
        }       
        //CALCULATION IN DATAGRID
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[dataGridView1.Columns["StockValue"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["UnitPrice"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["Stock"].Index].Value));
                }
                //TOTAL
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["StockValue"].Value);
                }
                txtTotal.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //TO TRANSFER GRN VALUES BEFORE STOCK TAKE EXECUTES
        //TO AFFECT STOCK ITEMS (POSITIVE)
        public void To_Affect_Stock_items()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("Stock_Count_To_Affect_Stocks", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@Delivered", dataGridView1.Rows[i].Cells["Stock"].Value);
                        sqlcmd.Parameters.AddWithValue("@TotalAmount", dataGridView1.Rows[i].Cells["StockValue"].Value);
                        sqlcmd.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //TO AFFECT STOCK ITEMS (NEGATIVE)
        public void To_Affect_Stock_items_Negative()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("Stock_Count_To_Affect_Stocks_Negative", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@Delivered", dataGridView1.Rows[i].Cells["Stock"].Value);
                        sqlcmd.Parameters.AddWithValue("@TotalAmount", dataGridView1.Rows[i].Cells["StockValue"].Value);
                        sqlcmd.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //SAVE
        public static string Record_number = "";
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (txtTotal.Text == "")
                MessageBox.Show("Please fill all neccesary details");
            else
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                        {
                            if (sqlcon.State == ConnectionState.Closed)
                                sqlcon.Open();
                            SqlCommand sqlcmd = new SqlCommand("PHYSICAL_STOCK_COUNT_PROC", sqlcon);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtDate.Text));
                            sqlcmd.Parameters.AddWithValue("@Time", DateTime.Parse(txtTime.Text));
                            sqlcmd.Parameters.AddWithValue("@StockBy", textBox1.Text);
                            sqlcmd.Parameters.AddWithValue("@RecordNumber", int.Parse(textBox2.Text));
                            sqlcmd.Parameters.AddWithValue("@TotalStockValue", double.Parse(txtTotal.Text));
                            sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                            sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                            sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                            sqlcmd.Parameters.AddWithValue("@SubGroup", dataGridView1.Rows[i].Cells["SubGroup"].Value);
                            sqlcmd.Parameters.AddWithValue("@Stock", dataGridView1.Rows[i].Cells["Stock"].Value);
                            sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                            sqlcmd.Parameters.AddWithValue("@StockValue", dataGridView1.Rows[i].Cells["StockValue"].Value);
                            sqlcmd.ExecuteNonQuery();
                            //AFFECT STOCKS
                            To_Affect_Stock_items();
                            To_Affect_Stock_items_Negative();
                        }
                    MessageBox.Show("Stocks saved successfully");
                    //CRYSTAL REPORT
                    Record_number = textBox2.Text;
                    To_PhysicalStockCount cou = new To_PhysicalStockCount();
                    cou.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            
        }
        
    }
}
