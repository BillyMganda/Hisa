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
    public partial class Manager_Book_Over : Form
    {
        public Manager_Book_Over()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //LOAD TEXTBOX VALUES        
        void FillSomeDetails()
        {
            string querry = "SELECT * FROM Book_Over WHERE Record_Number=(SELECT MAX(Record_Number) FROM Book_Over)";
            SqlConnection con = new SqlConnection(connectionstring);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand(querry, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtDate.Text = reader["Date"].ToString();
                txtTime.Text = reader["Time"].ToString();
                txtRecordNO.Text = reader["Record_Number"].ToString();
                txtReturnedBy.Text = reader["Record_By"].ToString();
                textBox1.Text = reader["Book_Reason"].ToString();
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
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Units,Book_Value,UnitPrice,Total_Book_Value FROM Book_Over WHERE Record_Number='" + Convert.ToInt32(txtRecordNO.Text) + "'", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There is no record to void/authorize at this time.");
            }
        }
        //LOAD
        private void Manager_Book_Over_Load(object sender, EventArgs e)
        {
            textBox2.Text = Manager_Stock_Adjustment.Logged_In_User;
            FillSomeDetails();
            FillDatagrid();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
        //DELETE FROM BOOK OVER TABLE
        void DeleteItem()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = $"DELETE FROM Book_Over WHERE Record_Number='" + Convert.ToInt32(txtRecordNO.Text) + "'";
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
        void RefreshWindow()
        {
            Manager_Book_Over mr = new Manager_Book_Over();
            mr.ShowDialog();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //VOID
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtRecordNO.Text == "")
                MessageBox.Show("There is no record to void at this time.");
            else
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                        {
                            if (sqlcon.State == ConnectionState.Closed)
                                sqlcon.Open();
                            SqlCommand sqlcmd = new SqlCommand("Void_Book_Over_Add", sqlcon);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Date",DateTime.Parse(txtDate.Text));
                            sqlcmd.Parameters.AddWithValue("@time", DateTime.Parse(txtTime.Text));
                            sqlcmd.Parameters.AddWithValue("@Record_Number",Convert.ToInt32(txtRecordNO.Text));
                            sqlcmd.Parameters.AddWithValue("@Record_By", txtReturnedBy.Text);
                            sqlcmd.Parameters.AddWithValue("@Authorised_By", textBox2.Text);
                            sqlcmd.Parameters.AddWithValue("@Book_Reason", textBox1.Text);
                            sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                            sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                            sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                            sqlcmd.Parameters.AddWithValue("@Book_Value", dataGridView1.Rows[i].Cells["Book_Value"].Value);
                            sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                            sqlcmd.Parameters.AddWithValue("@Total_Book_Value", dataGridView1.Rows[i].Cells["Total_Book_Value"].Value);
                            sqlcmd.ExecuteNonQuery();
                            this.Hide();
                        }
                    DeleteItem();
                    RefreshWindow();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //AUTHORIZE
        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            if (txtRecordNO.Text == "")
                MessageBox.Show("There is no record to void at this time.");
            else
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                        {
                            if (sqlcon.State == ConnectionState.Closed)
                                sqlcon.Open();
                            SqlCommand sqlcmd = new SqlCommand("Authorize_Book_Over_Add", sqlcon);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtDate.Text));
                            sqlcmd.Parameters.AddWithValue("@time", DateTime.Parse(txtTime.Text));
                            sqlcmd.Parameters.AddWithValue("@Record_Number", Convert.ToInt32(txtRecordNO.Text));
                            sqlcmd.Parameters.AddWithValue("@Record_By", txtReturnedBy.Text);
                            sqlcmd.Parameters.AddWithValue("@Authorised_By", textBox2.Text);
                            sqlcmd.Parameters.AddWithValue("@Book_Reason", textBox1.Text);
                            sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                            sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                            sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                            sqlcmd.Parameters.AddWithValue("@Book_Value", dataGridView1.Rows[i].Cells["Book_Value"].Value);
                            sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                            sqlcmd.Parameters.AddWithValue("@Total_Book_Value", dataGridView1.Rows[i].Cells["Total_Book_Value"].Value);
                            sqlcmd.ExecuteNonQuery();
                            this.Hide();
                        }
                    DeleteItem();
                    RefreshWindow();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
