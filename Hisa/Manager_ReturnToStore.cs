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
    public partial class Manager_ReturnToStore : Form
    {
        public Manager_ReturnToStore()
        {
            InitializeComponent();            
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //LOAD TEXTBOX VALUES        
        void FillSomeDetails()
        {
            string querry = "SELECT * FROM Return_To_Store WHERE RecordNumber=(SELECT MAX(RecordNumber) FROM Return_To_Store)";
            SqlConnection con = new SqlConnection(connectionstring);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand(querry, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtDate.Text = reader["Date"].ToString();
                txtTime.Text = reader["Time"].ToString();
                txtRecordNO.Text = reader["RecordNumber"].ToString();
                txtReturnedBy.Text = reader["RecordBy"].ToString();
                textBox1.Text = reader["Reason"].ToString();

                this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
                this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
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
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Units,Qty,UnitPrice,TotalPrice FROM Return_To_Store WHERE Recordnumber='" +Convert.ToInt32(txtRecordNO.Text)+ "'", sqlcon);
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
        private void Manager_ReturnToStore_Load(object sender, EventArgs e)
        {
            textBox2.Text = Managers_Module.SetValueForlabel6;
            FillSomeDetails();
            FillDatagrid();
        }
        //DELETE FROM RETURN TO STORE TABLE
        void DeleteItem()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = $"DELETE FROM Return_To_Store WHERE RecordNumber='" +Convert.ToInt32(txtRecordNO.Text)+ "'";
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
            Manager_ReturnToStore mr = new Manager_ReturnToStore();
            mr.ShowDialog();            
        }
        //CANCEL
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
                            SqlCommand sqlcmd = new SqlCommand("Void_Return_To_Store_Proc", sqlcon);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Date", txtDate.Text);
                            sqlcmd.Parameters.AddWithValue("@Time", txtTime.Text);
                            sqlcmd.Parameters.AddWithValue("@RecordNumber", txtRecordNO.Text);
                            sqlcmd.Parameters.AddWithValue("@RecordBy", txtReturnedBy.Text);
                            sqlcmd.Parameters.AddWithValue("@VoidBy", textBox2.Text);
                            sqlcmd.Parameters.AddWithValue("@Reason", textBox1.Text);
                            sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                            sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                            sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                            sqlcmd.Parameters.AddWithValue("@Qty", dataGridView1.Rows[i].Cells["ToReturn"].Value);
                            sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                            sqlcmd.Parameters.AddWithValue("@TotalPrice", dataGridView1.Rows[i].Cells["TotalPrice"].Value);
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
        //AUTHORIZE BUTTON
        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            if (txtRecordNO.Text == "")
                MessageBox.Show("There is no record to authorize at this time.");
            else
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                        {
                            if (sqlcon.State == ConnectionState.Closed)
                                sqlcon.Open();
                            SqlCommand sqlcmd = new SqlCommand("Authorize_Return_To_Store_Proc", sqlcon);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Date", txtDate.Text);
                            sqlcmd.Parameters.AddWithValue("@Time", txtTime.Text);
                            sqlcmd.Parameters.AddWithValue("@RecordNumber", txtRecordNO.Text);
                            sqlcmd.Parameters.AddWithValue("@RecordBy", txtReturnedBy.Text);
                            sqlcmd.Parameters.AddWithValue("@AuthorizeBy", textBox2.Text);
                            sqlcmd.Parameters.AddWithValue("@Reason", textBox1.Text);
                            sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                            sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                            sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                            sqlcmd.Parameters.AddWithValue("@Qty", dataGridView1.Rows[i].Cells["ToReturn"].Value);
                            sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                            sqlcmd.Parameters.AddWithValue("@TotalPrice", dataGridView1.Rows[i].Cells["TotalPrice"].Value);
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
