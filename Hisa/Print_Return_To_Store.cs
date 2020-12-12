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
    public partial class Print_Return_To_Store : Form
    {
        public Print_Return_To_Store()
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
                string querry = "SELECT * FROM Authorize_Return_To_Store WHERE RecordNumber=(SELECT MAX(RecordNumber) FROM Authorize_Return_To_Store)";
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtDate.Text = reader["Date"].ToString();
                    textBox1.Text = reader["Time"].ToString();
                    textBox2.Text = reader["RecordNumber"].ToString();
                    textBox3.Text = reader["RecordBy"].ToString();
                    textBox4.Text = reader["AuthorizeBy"].ToString();
                    textBox5.Text = reader["Reason"].ToString();                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //FILL DATAGRID
        public void Load_To_Datagrid()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Units,Qty,UnitPrice,TotalPrice FROM Authorize_Return_To_Store WHERE RecordNumber='" + textBox2.Text + "'", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        //LOAD
        private void Print_Return_To_Store_Load(object sender, EventArgs e)
        {
            Load_Details();
            Load_To_Datagrid();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
        //REFRESH
        private void RefreshWindow()
        {
            Print_Return_To_Store ret = new Print_Return_To_Store();
            ret.ShowDialog();
        }
        //DELETE FROM RETURN TO STORE TABLE
        private void Delete_From_Supplier_Table()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = $"DELETE FROM Authorize_Return_To_Store WHERE RecordNumber='" +textBox2.Text+ "'";
                    SqlCommand command = new SqlCommand(querry, sqlcon);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //CLOSE
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
                        sqlcmd.Parameters.AddWithValue("@Delivered", dataGridView1.Rows[i].Cells["Qty"].Value);
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
                        sqlcmd.Parameters.AddWithValue("@Authorised_By", textBox4.Text);
                        sqlcmd.Parameters.AddWithValue("@Record_Number",Convert.ToInt32(textBox2.Text));
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@Value", dataGridView1.Rows[i].Cells["Qty"].Value);
                        sqlcmd.Parameters.AddWithValue("@Total_Value", dataGridView1.Rows[i].Cells["TotalPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@Reason", textBox5.Text);
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
        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            if(textBox2.Text=="")
                MessageBox.Show("No more return to store documents to process");
            else
            {
                //INSERT POSITIVE ITEM TO GRN
                Insert_Into_GRN();
                Insert_Into_Return_In_List();
                record_number = textBox2.Text;
                try
                {
                    SqlConnection con = new SqlConnection(connectionstring);
                    con.Open();
                    string querry = "INSERT INTO Return_To_Store_Done(Date,Time,RecordNumber,RecordBy,AuthorizeBy,Reason,ItemName,ItemCode,Units,Qty,UnitPrice,TotalPrice) SELECT Date,Time,RecordNumber,RecordBy,AuthorizeBy,Reason,ItemName,ItemCode,Units,Qty,UnitPrice,TotalPrice FROM Authorize_Return_To_Store WHERE RecordNumber='" + textBox2.Text + "' DELETE FROM Authorize_Return_To_Store WHERE RecordNumber='" + textBox2.Text + "'";
                    SqlCommand command = new SqlCommand(querry, con);
                    command.ExecuteNonQuery();
                    con.Close();
                    Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //PRINT RETURN TO STORE
                To_ReturnToStore ret = new To_ReturnToStore();
                ret.ShowDialog();
                RefreshWindow();
            }
        }
    }
}
