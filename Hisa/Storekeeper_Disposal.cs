using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Hisa
{
    public partial class Storekeeper_Disposal : Form
    {
        public Storekeeper_Disposal()
        {
            InitializeComponent();            
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //AUTOFILL DATAGRID WITH STOCKS VALUES
        private void AutoFillAddToCartDatagrid()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    string querry = "SELECT ItemName,ItemCode,Units,SOH,Price,StockValue FROM Stores";
                    SqlDataAdapter sqldata = new SqlDataAdapter(querry, connection);
                    DataTable dt = new DataTable();
                    sqldata.Fill(dt);
                    dataGridCart.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //TEXT CHANGED IN SEARCHBOX
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT ItemName,ItemCode,Units,SOH,Price,StockValue FROM Stores WHERE ItemName LIKE '" + textBox1.Text + "%'", con);
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
        //RANDOM REQUEST NUMBER
        void RequestNumber()
        {
            Random rnd = new Random();
            int tal = rnd.Next(0, 1000000);
            textBox2.Text = tal.ToString();
        }
        //LOAD
        private void Storekeeper_Disposal_Load(object sender, EventArgs e)
        {
            AutoFillAddToCartDatagrid();
            //Load Date and Time
            string dt = DateTime.Now.Date.ToShortDateString();
            txtDate.Text = dt;
            string time = DateTime.Now.ToShortTimeString();
            txtTime.Text = time;            
            RequestNumber();
            txtRequest.Text = Storekeeper.SetValueForlabel5;

            this.dataGridCart.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridCart.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;

            this.dataGridCheckOut.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridCheckOut.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
       
        //CANCEL
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //DISPOSE
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtReason.Text == "")
                MessageBox.Show("Kindly include a reason for your disposal");    
            else
            {
                try
                {
                    for (int i = 0; i < dataGridCheckOut.Rows.Count; i++)
                        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                        {
                            if (sqlcon.State == ConnectionState.Closed)
                                sqlcon.Open();
                            SqlCommand sqlcmd = new SqlCommand("Item_DisposalAdd", sqlcon);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Dispose_Date", DateTime.Parse(txtDate.Text));
                            sqlcmd.Parameters.AddWithValue("@Dispose_Time", DateTime.Parse(txtTime.Text));
                            sqlcmd.Parameters.AddWithValue("@Dispose_By", txtRequest.Text);
                            sqlcmd.Parameters.AddWithValue("@Dispose_Number", int.Parse(textBox2.Text));
                            sqlcmd.Parameters.AddWithValue("@ItemName", dataGridCheckOut.Rows[i].Cells["ItemName1"].Value);
                            sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridCheckOut.Rows[i].Cells["ItemCode1"].Value);
                            sqlcmd.Parameters.AddWithValue("@Units", dataGridCheckOut.Rows[i].Cells["Units1"].Value);
                            sqlcmd.Parameters.AddWithValue("@SOH", dataGridCheckOut.Rows[i].Cells["SOH1"].Value);
                            sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridCheckOut.Rows[i].Cells["UnitPrice1"].Value);
                            sqlcmd.Parameters.AddWithValue("@Value", dataGridCheckOut.Rows[i].Cells["Value1"].Value);
                            sqlcmd.Parameters.AddWithValue("@Dispose_Amount", dataGridCheckOut.Rows[i].Cells["Dispose1"].Value);
                            sqlcmd.Parameters.AddWithValue("@Disposal_Reason", txtReason.Text);
                            sqlcmd.ExecuteNonQuery();
                        }                    
                    MessageBox.Show("Item Disposal Successful");
                    dataGridCheckOut.Rows.Clear();
                    txtReason.Text = "";
                    RequestNumber();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }       
        }
        //PRINT
        private void button3_Click(object sender, EventArgs e)
        {
            Print_Item_Disposal itemdisp = new Print_Item_Disposal();
            itemdisp.ShowDialog();
        }
    }
}
