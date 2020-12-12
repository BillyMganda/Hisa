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
    public partial class Print_Return_To_Supplier : Form
    {
        public Print_Return_To_Supplier()
        {
            InitializeComponent();
        }
        //connection string
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //LOAD DETAILS
        public void Load_Details()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                string querry = "SELECT * FROM Authorize_Return_To_Supplier WHERE Record_Number=(SELECT MAX(Record_Number) FROM Authorize_Return_To_Supplier)";
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtDate.Text = reader["Return_Date"].ToString();
                    textBox1.Text = reader["Return_Time"].ToString();
                    textBox2.Text = reader["Returned_By"].ToString();
                    textBox3.Text = reader["Department"].ToString();
                    textBox4.Text = reader["Authorised_By"].ToString();
                    textBox5.Text = reader["Record_Number"].ToString();
                    textBox6.Text = reader["GRN_Number"].ToString();
                    textBox7.Text = reader["Return_Reason"].ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No new return to supplier to process at this time");
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
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Units,SOH,UnitPrice,TotalPrice,Return_Amount FROM Authorize_Return_To_Supplier WHERE Record_Number='" + Convert.ToInt32(textBox5.Text) + "'", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No new return to supplier to process at this time");
            }
        }
        //LOAD
        private void Print_Return_To_Supplier_Load(object sender, EventArgs e)
        {
            Load_Details();
            FillDatagrid();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
        //DELETE FROM RETURN TO SUPPLIER TABLE
        private void Delete_From_Supplier_Table()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = $"DELETE FROM Authorize_Return_To_Supplier WHERE Record_Number='"+Convert.ToInt32(textBox5.Text) +"'";
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
        private void Refresh()
        {
            Print_Return_To_Supplier pp = new Print_Return_To_Supplier();
            pp.ShowDialog();
        }
        //CANCEL
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //INSERT NEGATIVE ITEM TO GRN
        private void Insert_Into_GRN()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("Negative_TO_GRN", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@Delivered", dataGridView1.Rows[i].Cells["To_Return"].Value);
                        sqlcmd.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //INSERT POSITIVE ITEM TO GRN
        private void Insert_Into_Return_Out_List()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("Return_Out_List_Proc", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtDate.Text));
                        sqlcmd.Parameters.AddWithValue("@Time", DateTime.Parse(textBox1.Text));
                        sqlcmd.Parameters.AddWithValue("@Record_By", textBox2.Text);
                        sqlcmd.Parameters.AddWithValue("@Authorised_By", textBox4.Text);
                        sqlcmd.Parameters.AddWithValue("@Record_Number", Convert.ToInt32(textBox5.Text));
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@Value", dataGridView1.Rows[i].Cells["To_Return"].Value);
                        sqlcmd.Parameters.AddWithValue("@Total_Value", dataGridView1.Rows[i].Cells["TotalPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@Reason", textBox7.Text);
                        sqlcmd.ExecuteNonQuery();
                        Hide();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //PRINT
        public static string record_number;
        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
                MessageBox.Show("No more return to supplier documents to process");
            else
            {
                Insert_Into_GRN();
                Insert_Into_Return_Out_List();
                record_number = textBox5.Text;
                try
                {
                    SqlConnection con = new SqlConnection(connectionstring);
                    con.Open();
                    string querry = "INSERT INTO Return_To_Supplier_Done(Return_Date,Return_Time,Returned_By,Authorised_By,Department,Record_Number,GRN_Number,Return_Reason,ItemName,ItemCode,Units,SOH,UnitPrice,TotalPrice,Return_Amount) SELECT Return_Date,Return_Time,Returned_By,Authorised_By,Department,Record_Number,GRN_Number,Return_Reason,ItemName,ItemCode,Units,SOH,UnitPrice,TotalPrice,Return_Amount FROM Authorize_Return_To_Supplier WHERE Record_Number='" + Convert.ToInt32(textBox5.Text) + "' DELETE FROM Authorize_Return_To_Supplier WHERE Record_Number='" + Convert.ToInt32(textBox5.Text) + "'";
                    SqlCommand command = new SqlCommand(querry, con);
                    command.ExecuteNonQuery();
                    con.Close();
                    Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                
                //PRINT RETURN TO SUPPLIER
                To_ReturnToSupplier ret = new To_ReturnToSupplier();
                ret.ShowDialog();
                Refresh();
            }
        }
    }
}
