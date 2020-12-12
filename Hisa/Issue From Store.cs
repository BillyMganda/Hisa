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
    public partial class Issue_From_Store : Form
    {
        public Issue_From_Store()
        {
            InitializeComponent();
            Autocomplete_ReceivedBy();
        }  
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;      
        //string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //fill some details
        void FillSomeDetails()
        {
            try
            {
                string querry = "SELECT * FROM HOD_ApproveRequest  WHERE Request_Number= '"+Convert.ToInt32(txtRequestNo.Text)+ "'";
                SqlConnection con = new SqlConnection(connectionstring);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtRequested.Text= reader["Requested_By"].ToString();
                    textBox3.Text = reader["Approved_By"].ToString();
                    txtDepartment.Text= reader["Department"].ToString();
                    if (reader["Shift"].ToString() == "Day")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                        radioButton1.Checked = false;
                    if (reader["Shift"].ToString() == "Night")
                    {
                        radioButton2.Checked = true;
                    }
                    else
                        radioButton2.Checked = false;
                }
                //date and time
                string date = DateTime.Now.Date.ToShortDateString();
                txtDate.Text = date;
                string time = DateTime.Now.ToShortTimeString();
                txtTime.Text = time;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //AUTOCOMPLETE RECEIVED BY        
        private void Autocomplete_ReceivedBy()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT FullNames FROM UserInfo",con);
                DataSet ds = new DataSet();
                SqlDataAdapter adap = new SqlDataAdapter(command);
                adap.Fill(ds, "UserInfo");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["FullNames"].ToString());
                }
                textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox1.AutoCompleteCustomSource = col;
                textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Units,SOH,Requested,UnitPrice FROM HOD_ApproveRequest WHERE Request_Number='" +Convert.ToInt32(txtRequestNo.Text)+ "'", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No more requests to process");
            }
        }
        //SHIFT
        string Shift;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Shift = "Day";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Shift = "Night";
        }
        //LOAD
        private void Issue_From_Store_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet_IssueFromStoreStorekeeper.HOD_ApproveRequest' table. You can move, or remove it, as needed.
            this.hOD_ApproveRequestTableAdapter.Fill(this.dataSet_IssueFromStoreStorekeeper.HOD_ApproveRequest);
            FillSomeDetails();                     
            FillDatagrid();
            //RANDOM ISSUE NUMBER
            Random r = new Random();
            int rInt = r.Next(0, 1000000);
            txtIssueNo.Text = rInt.ToString();
            //ISSUED BY
            txtIssuedBy.Text = Storekeeper.SetValueForlabel5;
            Autocomplete_ReceivedBy();

            this.dataGridView1.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
        //Calculation in datagrid
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)                                        
                {                   
                    row.Cells[dataGridView1.Columns["TotalAmount"].Index].Value = (Convert.ToDouble(row.Cells[dataGridView1.Columns["Issue"].Index].Value) * Convert.ToDouble(row.Cells[dataGridView1.Columns["UnitPrice"].Index].Value));
                }
                //Datagrid column total
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["TotalAmount"].Value);
                }
                textBox2.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //VOID
        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Please fill who is going to receive the items.");
            else
            {
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();
                try
                {                  

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            using (SqlCommand cmd = new SqlCommand("INSERT INTO Void_Request(Requested_By,Request_Number,Department,Shift,Issue_Date,Issue_Time,Issue_Number,Issued_By,Received_By,ItemName,ItemCode,Units,SOH,Requested,Issued,UnitPrice,TotalPrice,TotalTotalPrice,Approved_By) VALUES(@Requested_By,@Request_Number,@Department,@Shift,@Issue_Date,@Issue_Time,@Issue_Number,@Issued_By,@Received_By,@ItemName,@ItemCode,@Units,@SOH,@Requested,@Issued,@UnitPrice,@TotalPrice,@TotalTotalPrice,@Approved_By)", con))
                            {
                                cmd.Parameters.AddWithValue("@Requested_By", txtRequested.Text);
                                cmd.Parameters.AddWithValue("@Request_Number", Convert.ToInt32(txtRequestNo.Text));
                                cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                                cmd.Parameters.AddWithValue("@Shift", Shift);
                                cmd.Parameters.AddWithValue("@Issue_Date", DateTime.Parse(txtDate.Text));
                                cmd.Parameters.AddWithValue("@Issue_Time", DateTime.Parse(txtTime.Text));
                                cmd.Parameters.AddWithValue("@Issue_Number", Convert.ToInt32(txtIssueNo.Text));
                                cmd.Parameters.AddWithValue("@Issued_By", txtIssuedBy.Text);
                                cmd.Parameters.AddWithValue("@Received_By", textBox1.Text);
                                cmd.Parameters.AddWithValue("@ItemName", row.Cells["ItemName"].Value);
                                cmd.Parameters.AddWithValue("@ItemCode", row.Cells["ItemCode"].Value);
                                cmd.Parameters.AddWithValue("@Units", row.Cells["Units"].Value);
                                cmd.Parameters.AddWithValue("@SOH", row.Cells["SOH"].Value);
                                cmd.Parameters.AddWithValue("@Requested", row.Cells["Request"].Value);
                                cmd.Parameters.AddWithValue("@Issued", row.Cells["Issue"].Value);
                                cmd.Parameters.AddWithValue("@UnitPrice", row.Cells["UnitPrice"].Value);
                                cmd.Parameters.AddWithValue("@TotalPrice", row.Cells["TotalAmount"].Value);
                                cmd.Parameters.AddWithValue("@TotalTotalPrice", Convert.ToDecimal(textBox2.Text));
                                cmd.Parameters.AddWithValue("@Approved_By", textBox3.Text);
                                cmd.ExecuteNonQuery();
                                DeleteRequest();
                            }
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Hide();
                RefreshWindow();
            }
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
                        sqlcmd.Parameters.AddWithValue("@Delivered", dataGridView1.Rows[i].Cells["Issue"].Value);
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
                        sqlcmd.Parameters.AddWithValue("@Time", DateTime.Parse(txtTime.Text));
                        sqlcmd.Parameters.AddWithValue("@Record_By", txtRequested.Text);
                        sqlcmd.Parameters.AddWithValue("@Authorised_By", txtIssuedBy.Text);
                        sqlcmd.Parameters.AddWithValue("@Record_Number", Convert.ToInt32(txtIssueNo.Text));
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridView1.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridView1.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridView1.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridView1.Rows[i].Cells["UnitPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@Value", dataGridView1.Rows[i].Cells["Issue"].Value);
                        sqlcmd.Parameters.AddWithValue("@Total_Value", dataGridView1.Rows[i].Cells["TotalAmount"].Value);
                        sqlcmd.Parameters.AddWithValue("@Reason", textBox3.Text);
                        sqlcmd.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //ISSUE
        public static string Issue_Numbers;
        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || txtRequestNo.Text=="")
                MessageBox.Show("Please fill all relevant details to proceed");
            else
            {
                Insert_Into_GRN();
                Insert_Into_Return_Out_List();
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();
                try
                {

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO Authorize_Request(Requested_By,Request_Number,Department,Shift,Issue_Date,Issue_Time,Issue_Number,Issued_By,Received_By,ItemName,ItemCode,Units,SOH,Requested,Issued,UnitPrice,TotalPrice,TotalTotalPrice,Approved_By) VALUES(@Requested_By,@Request_Number,@Department,@Shift,@Issue_Date,@Issue_Time,@Issue_Number,@Issued_By,@Received_By,@ItemName,@ItemCode,@Units,@SOH,@Requested,@Issued*-1,@UnitPrice,@TotalPrice,@TotalTotalPrice,@Approved_By)", con))
                        {
                            cmd.Parameters.AddWithValue("@Requested_By", txtRequested.Text);
                            cmd.Parameters.AddWithValue("@Request_Number", Convert.ToInt32(txtRequestNo.Text));
                            cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                            cmd.Parameters.AddWithValue("@Shift", Shift);
                            cmd.Parameters.AddWithValue("@Issue_Date", DateTime.Parse(txtDate.Text));
                            cmd.Parameters.AddWithValue("@Issue_Time", DateTime.Parse(txtTime.Text));
                            cmd.Parameters.AddWithValue("@Issue_Number", Convert.ToInt32(txtIssueNo.Text));
                            cmd.Parameters.AddWithValue("@Issued_By", txtIssuedBy.Text);
                            cmd.Parameters.AddWithValue("@Received_By", textBox1.Text);
                            cmd.Parameters.AddWithValue("@ItemName", row.Cells["ItemName"].Value);
                            cmd.Parameters.AddWithValue("@ItemCode", row.Cells["ItemCode"].Value);
                            cmd.Parameters.AddWithValue("@Units", row.Cells["Units"].Value);
                            cmd.Parameters.AddWithValue("@SOH", row.Cells["SOH"].Value);
                            cmd.Parameters.AddWithValue("@Requested", row.Cells["Request"].Value);
                            cmd.Parameters.AddWithValue("@Issued", row.Cells["Issue"].Value);
                            cmd.Parameters.AddWithValue("@UnitPrice", row.Cells["UnitPrice"].Value);
                            cmd.Parameters.AddWithValue("@TotalPrice", row.Cells["TotalAmount"].Value);
                            cmd.Parameters.AddWithValue("@TotalTotalPrice", Convert.ToDecimal(textBox2.Text));
                            cmd.Parameters.AddWithValue("@Approved_By", textBox3.Text);
                            cmd.ExecuteNonQuery();
                            Hide();
                            DeleteRequest();                            
                        }
                    }
                    //CRYSTAL REPORT
                    Issue_Numbers = txtIssueNo.Text;
                    To_Issue_From_Store tissue = new To_Issue_From_Store();
                    tissue.ShowDialog();
                    RefreshWindow();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }             
     
            }
        }
        //Delete request after void or authorised based on request number 
        void DeleteRequest()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = $"DELETE FROM HOD_ApproveRequest WHERE Request_Number='" +Convert.ToInt32(txtRequestNo.Text)+ "'";
                    SqlCommand command = new SqlCommand(querry, sqlcon);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Refresh
        void RefreshWindow()
        {            
            Issue_From_Store ifs = new Issue_From_Store();
            ifs.ShowDialog();
        }
        //PREVIOUS
        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            FillSomeDetails();
            FillDatagrid();
        }
        //NEXT
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            FillSomeDetails();
            FillDatagrid();
        }
    }
}
