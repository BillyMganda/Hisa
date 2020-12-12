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
    public partial class Pending_Requests : Form
    {
        public Pending_Requests()
        {
            InitializeComponent();
            AutoFillAddToPendingDatagrid();
            AutofillProcessRequestDatagrid();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=ADMIN-PC\SQLEXPRESS; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //Autofill pending requests datagrid with data from checkout table
        private void AutoFillAddToPendingDatagrid()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    string querry = "SELECT ItemName,ItemCode,RequestNumber,SOH,Request,RequestedBy,Shift,UnitPrice from CheckOut";
                    SqlDataAdapter sqldata = new SqlDataAdapter(querry, connection);
                    DataTable dt = new DataTable();
                    sqldata.Fill(dt);
                    dataGridPendingRequests.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //accept button
        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridPendingRequests.Rows.Count; i++)
                    using (SqlConnection conn = new SqlConnection(connectionstring))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Temporary_PendingRequest (ItemName,ItemCode,RequestNumber,SOH,Request,RequestedBy,Shift,UnitPrice) values (@ItemName,@ItemCode,@RequestNumber,@SOH,@Request,@RequestedBy,@Shift,@UnitPrice)", conn);
                        cmd.Parameters.AddWithValue("@ItemName", dataGridPendingRequests.Rows[i].Cells[0].Value);
                        cmd.Parameters.AddWithValue("@ItemCode", dataGridPendingRequests.Rows[i].Cells[1].Value);
                        cmd.Parameters.AddWithValue("@RequestNumber", dataGridPendingRequests.Rows[i].Cells[2].Value);
                        cmd.Parameters.AddWithValue("@SOH", dataGridPendingRequests.Rows[i].Cells[3].Value);
                        cmd.Parameters.AddWithValue("@Request", dataGridPendingRequests.Rows[i].Cells[4].Value);
                        cmd.Parameters.AddWithValue("@RequestedBy", dataGridPendingRequests.Rows[i].Cells[5].Value);
                        cmd.Parameters.AddWithValue("@Shift", dataGridPendingRequests.Rows[i].Cells[6].Value);
                        cmd.Parameters.AddWithValue("@UnitPrice", dataGridPendingRequests.Rows[i].Cells[7].Value);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Autofill checkout datagrid
            AutofillProcessRequestDatagrid();
        }
        //Autofill checkout datagrid
        private void AutofillProcessRequestDatagrid()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    string querry = "Select ItemName,ItemCode,RequestNumber,SOH,Request,UnitPrice from Temporary_PendingRequest";
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
        //Calculation on process request datagrid
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells[dataGridView1.Columns["TotalAmount"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["UnitPrice1"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["Issue"].Index].Value));
                }
                //Datagrid column total
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["TotalAmount"].Value);
                }
                txtTotalAmount.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //void button
        private void btnVoid_Click(object sender, EventArgs e)
        {

        }

        private void Pending_Requests_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetForRequests.CheckOut' table. You can move, or remove it, as needed.
            this.checkOutTableAdapter.Fill(this.dataSetForRequests.CheckOut);

        }
    }
}
