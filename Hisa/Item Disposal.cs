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
    public partial class Item_Disposal : Form
    {
        public Item_Disposal()
        {
            InitializeComponent();            
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //FILL SOME DETAILS
        void FillSomeDetails()
        {
            string querry = "SELECT * FROM Item_Disposal WHERE Dispose_Number=(SELECT MAX(Dispose_Number) FROM Item_Disposal)";
            SqlConnection con = new SqlConnection(connectionstring);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand(querry, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtDate.Text = reader["Dispose_Date"].ToString();
                txtTime.Text = reader["Dispose_Time"].ToString();
                txtRecordNo.Text = reader["Dispose_Number"].ToString();
                txtReason.Text = reader["Disposal_Reason"].ToString();
                txtDisposedBy.Text = reader["Dispose_By"].ToString();                
            }
        }
        //Fill Datagrid
        void FillDatagrid()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Units,SOH,UnitPrice,Value,Dispose_Amount FROM Item_Disposal WHERE Dispose_Number='" + Convert.ToInt32(txtRecordNo.Text) + "'", sqlcon);
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
        //FORM LOAD
        private void Item_Disposal_Load(object sender, EventArgs e)
        {
            textBox2.Text = Managers_Module.SetValueForlabel6;
            FillSomeDetails();
            FillDatagrid();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
        //CANCEL
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //DELETE
        void Delete()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = $"DELETE FROM Item_Disposal WHERE Dispose_Number='" + Convert.ToInt32(txtRecordNo.Text) + "'";
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
            Item_Disposal id = new Item_Disposal();
            id.ShowDialog();
        }
        //VOID
        private void btnVoid_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("Item_DisposalVoid", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Dispose_Date", DateTime.Parse(txtDate.Text));
                        sqlcmd.Parameters.AddWithValue("@Dispose_Time", DateTime.Parse(txtTime.Text));
                        sqlcmd.Parameters.AddWithValue("@Dispose_By", txtDisposedBy.Text);
                        sqlcmd.Parameters.AddWithValue("@Dispose_Number", Convert.ToInt32(txtRecordNo.Text));
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@SOH", dataGridView1.Rows[i].Cells["SOH"].Value);
                        sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["Price"].Value);
                        sqlcmd.Parameters.AddWithValue("@Value", dataGridView1.Rows[i].Cells["Value"].Value);
                        sqlcmd.Parameters.AddWithValue("@Dispose_Amount", dataGridView1.Rows[i].Cells["ToDispose"].Value);
                        sqlcmd.Parameters.AddWithValue("@Disposal_Reason", txtReason.Text);
                        sqlcmd.Parameters.AddWithValue("@Authorised_By", textBox2.Text);
                        sqlcmd.ExecuteNonQuery();
                        Hide();
                    }
                MessageBox.Show("Item Voided Successful");
                Delete();
                RefreshWindow();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //AUTHORIZE
        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("Item_DisposalaAuthorize", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Dispose_Date", DateTime.Parse(txtDate.Text));
                        sqlcmd.Parameters.AddWithValue("@Dispose_Time", DateTime.Parse(txtTime.Text));
                        sqlcmd.Parameters.AddWithValue("@Dispose_By", txtDisposedBy.Text);
                        sqlcmd.Parameters.AddWithValue("@Dispose_Number", Convert.ToInt32(txtRecordNo.Text));
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@SOH", dataGridView1.Rows[i].Cells["SOH"].Value);
                        sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["Price"].Value);
                        sqlcmd.Parameters.AddWithValue("@Value", dataGridView1.Rows[i].Cells["Value"].Value);
                        sqlcmd.Parameters.AddWithValue("@Dispose_Amount", dataGridView1.Rows[i].Cells["ToDispose"].Value);
                        sqlcmd.Parameters.AddWithValue("@Disposal_Reason", txtReason.Text);
                        sqlcmd.Parameters.AddWithValue("@Authorised_By", textBox2.Text);
                        sqlcmd.ExecuteNonQuery();
                        Hide();
                    }
                MessageBox.Show("Item Authorised Successful");
                Delete();
                RefreshWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
