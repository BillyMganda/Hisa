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
    public partial class Print_Book_Over : Form
    {
        public Print_Book_Over()
        {
            InitializeComponent();
        }

        string connectionstring1 =
            @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        //LOAD DETAILS
        public void Load_Details()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                string querry = "SELECT * FROM Authorize_Book_Over WHERE Record_Number=(SELECT MAX(Record_Number) FROM Authorize_Book_Over)";
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtDate.Text = reader["Date"].ToString();
                    textBox1.Text = reader["time"].ToString();
                    textBox3.Text = reader["Record_By"].ToString();
                    textBox2.Text = reader["Authorised_By"].ToString();
                    textBox5.Text = reader["Record_Number"].ToString();
                    textBox4.Text = reader["Book_Reason"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //FILL DATAGRID
        private void FillDataGrid()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Units,UnitPrice,Book_Value,Total_Book_Value FROM Authorize_Book_Over WHERE Record_Number='" +Convert.ToInt32(textBox5.Text) + "'", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No new book over to print at this time");
            }
        }
        //LOAD
        private void Print_Book_Over_Load(object sender, EventArgs e)
        {
            Load_Details();
            FillDataGrid();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
        //REFRESH
        public void Refresh()
        {
            Print_Book_Over pprint = new Print_Book_Over();
            pprint.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //INSERT POSITIVE ITEM TO GRN
        private void Insert_Into_GRN()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("Book_Over_TO_GRN", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@Delivered", dataGridView1.Rows[i].Cells["Book_Value"].Value);
                        sqlcmd.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //INSERT POSITIVE ITEM TO GRN
        private void Insert_Into_Return_In_List()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("Return_In_List_Proc", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Date", DateTime.Parse(txtDate.Text));
                        sqlcmd.Parameters.AddWithValue("@Time", DateTime.Parse(textBox1.Text));
                        sqlcmd.Parameters.AddWithValue("@Record_By", textBox3.Text);
                        sqlcmd.Parameters.AddWithValue("@Authorised_By", textBox2.Text);
                        sqlcmd.Parameters.AddWithValue("@Record_Number", Convert.ToInt32(textBox5.Text));
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@Value", dataGridView1.Rows[i].Cells["Book_Value"].Value);
                        sqlcmd.Parameters.AddWithValue("@Total_Value", dataGridView1.Rows[i].Cells["Total_Book_Value"].Value);
                        sqlcmd.Parameters.AddWithValue("@Reason", textBox4.Text);
                        sqlcmd.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //PRINT
        public static string record_number;
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
                MessageBox.Show("No new book over to print at this time");
            else
            {
                record_number = textBox5.Text;
                //INSERT POSITIVE ITEM TO GRN
                Insert_Into_GRN();
                Insert_Into_Return_In_List();
                //INSERT INTO BOOK OVER DONE & DELETE FROM AUTHORISED BOOK OVER
                try
                {
                    SqlConnection con = new SqlConnection(connectionstring);
                    con.Open();
                    string querry = "INSERT INTO Book_Over_Done(Date,time,Record_By,Authorised_By,Record_Number,ItemName,ItemCode,Units,UnitPrice,Book_Value,Total_Book_Value,Book_Reason)SELECT Date,time,Record_By,Authorised_By,Record_Number,ItemName,ItemCode,Units,UnitPrice,Book_Value,Total_Book_Value,Book_Reason FROM Authorize_Book_Over WHERE Record_Number='" + Convert.ToInt32(textBox5.Text) + "' DELETE FROM Authorize_Book_Over WHERE Record_Number='" + Convert.ToInt32(textBox5.Text) + "'";
                    SqlCommand command = new SqlCommand(querry, con);
                    command.ExecuteNonQuery();
                    con.Close();
                    Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //PRINT
                To_BookOver book=new To_BookOver();
                book.ShowDialog();
            }
        }
    }
}
