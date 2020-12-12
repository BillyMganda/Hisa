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
    public partial class Cart : Form
    {
        public Cart()
        {
            InitializeComponent();                     
        }        
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        //string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";        
        //LOAD DATA TO CART DATAGRID FROM STORES VIEW
        public void Load_to_Cart_Datagrid()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemName,ItemCode,Units,SOH,Price,StockValue FROM Stores ORDER BY ItemName ASC", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGridCart.DataSource = dt;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //TEXT CHANGED IN SEARCH TEXTBOX
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT ItemName,ItemCode,Units,SOH,Price,StockValue FROM Stores WHERE ItemName LIKE '" + txtSearch.Text + "%' ", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridCart.DataSource = dt;
            con.Close();
        }
        //PREVENT DUPLICATES IN DATAGRID
        private void Duplicates()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < dataGridCheckOut.Rows.Count; i++)
            {
                string str = dataGridCheckOut.Rows[i].Cells[0].Value.ToString();
                if (!list.Contains(str))
                    list.Add(dataGridCheckOut.Rows[i].Cells[0].Value.ToString());
                else
                {
                    dataGridCheckOut.Rows.Remove(dataGridCheckOut.Rows[i]);
                }
            }
        }
        //COPY FROM ONE DATAGRID VIEW TO ANOTHER DATAGRID VIEW                                      YOU ARE HERE -- NOT BEING USED
        public void CopyToAnotherDatagridview()
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
            Duplicates();
        }
        private void dataGridCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //CopyToAnotherDatagridview();
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
            Duplicates();
        }
        //Load Request Number to texbox
        private void Load_RequestNumber()
        {
            Random rnd = new Random();
            int tal = rnd.Next(0, 10000000);
            txtRequest.Text = tal.ToString();
        }        
        //LOAD FORM
        private void Cart_Load(object sender, EventArgs e)
        {
            Load_RequestNumber();
            Load_to_Cart_Datagrid();
            //Load Date and Time
            string dt = DateTime.Now.Date.ToShortDateString();
            txtDate.Text = dt;
            string time = DateTime.Now.ToShortTimeString();
            txtTime.Text = time;
            //Requested by & department                                               
            txtRequestBy.Text = Choose_Department.User_Account;
            txtDepartment.Text = Choose_Department.User_department;

            this.dataGridCart.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridCart.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;

            this.dataGridCheckOut.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridCheckOut.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
        //COMPARE REQUEST & SOH
        private void CompareValues()
        {
            double Item1;
            double Item2;
            for (int i = 0; i < dataGridCheckOut.RowCount - 1; i++)
            {
                Item1 = Convert.ToDouble(dataGridCheckOut.Rows[i].Cells[3].Value);
                Item2 = Convert.ToDouble(dataGridCheckOut.Rows[i].Cells[6].Value);
                if (Item2 > Item1)
                    MessageBox.Show("You can not request more than what is in stock");
                else
                {
                    foreach (DataGridViewRow row in dataGridCheckOut.Rows)
                    {
                        row.Cells[dataGridCheckOut.Columns["Total1"].Index].Value = (Convert.ToDouble(row.Cells[dataGridCheckOut.Columns["Request1"].Index].Value) * Convert.ToDouble(row.Cells[dataGridCheckOut.Columns["UnitPrice1"].Index].Value));
                    }
                    //Datagrid column total
                    int sum = 0;
                    for (int j = 0; j < dataGridCheckOut.Rows.Count; j++)
                    {
                        sum += Convert.ToInt32(dataGridCheckOut.Rows[j].Cells["Total1"].Value);
                    }
                    txtTotalAmount.Text = sum.ToString();
                }
            }
        }
        private void dataGridCheckOut_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            double Item1;
            double Item2;
            for (int i = 0; i < dataGridCheckOut.RowCount - 1; i++)
            {
                Item1 = Convert.ToDouble(dataGridCheckOut.Rows[i].Cells[3].Value);
                Item2 = Convert.ToDouble(dataGridCheckOut.Rows[i].Cells[6].Value);
                if (Item2 > Item1)
                {
                    MessageBox.Show("You can not request more than what is in stock");
                }
                else
                {
                    foreach (DataGridViewRow row in dataGridCheckOut.Rows)
                    {
                        row.Cells[dataGridCheckOut.Columns["Total1"].Index].Value = (Convert.ToDouble(row.Cells[dataGridCheckOut.Columns["Request1"].Index].Value) * Convert.ToDouble(row.Cells[dataGridCheckOut.Columns["UnitPrice1"].Index].Value));
                    }
                    //Datagrid column total
                    int sum = 0;
                    for (int j = 0; j < dataGridCheckOut.Rows.Count; j++)
                    {
                        sum += Convert.ToInt32(dataGridCheckOut.Rows[j].Cells["Total1"].Value);
                    }
                    txtTotalAmount.Text = sum.ToString();
                }
            }
        }
        //Canculations in datagrid
        private void dataGridCheckOut_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridCheckOut.Rows)
                {
                    row.Cells[dataGridCheckOut.Columns["Total1"].Index].Value = (Convert.ToDouble(row.Cells[dataGridCheckOut.Columns["Request1"].Index].Value) * Convert.ToDouble(row.Cells[dataGridCheckOut.Columns["UnitPrice1"].Index].Value));
                }
                //Datagrid column total
                int sum = 0;
                for (int i = 0; i < dataGridCheckOut.Rows.Count; i++)
                {
                    sum += Convert.ToInt32(dataGridCheckOut.Rows[i].Cells["Total1"].Value);
                }
                txtTotalAmount.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Radio buttons events
        string Shift;
        private void radDay_CheckedChanged(object sender, EventArgs e)
        {
            Shift = "Day";
        }

        private void radNight_CheckedChanged(object sender, EventArgs e)
        {
            Shift = "Night";
        }
        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Refresh window
        void RefreshWindow()
        {
            Cart rbo = new Cart();
            rbo.ShowDialog();
        }
        //SAVE
        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            if (Shift == "")
                MessageBox.Show("Shift not selected");
            else
            {
                try
                {
                    for (int i = 0; i < dataGridCheckOut.Rows.Count; i++)
                        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                        {
                            if (sqlcon.State == ConnectionState.Closed)
                                sqlcon.Open();
                            SqlCommand sqlcmd = new SqlCommand("RequisitionsAdd", sqlcon);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Request_Date", DateTime.Parse(txtDate.Text));
                            sqlcmd.Parameters.AddWithValue("@Request_Time", DateTime.Parse(txtTime.Text));
                            sqlcmd.Parameters.AddWithValue("@Request_Number", int.Parse(txtRequest.Text));
                            sqlcmd.Parameters.AddWithValue("@Requested_By", txtRequestBy.Text);
                            sqlcmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                            sqlcmd.Parameters.AddWithValue("@Shift", Shift);
                            sqlcmd.Parameters.AddWithValue("@ItemName", dataGridCheckOut.Rows[i].Cells["ItemName1"].Value);
                            sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridCheckOut.Rows[i].Cells["ItemCode1"].Value);
                            sqlcmd.Parameters.AddWithValue("@Units", dataGridCheckOut.Rows[i].Cells["Units1"].Value);
                            sqlcmd.Parameters.AddWithValue("@SOH", dataGridCheckOut.Rows[i].Cells["SOH1"].Value);
                            sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridCheckOut.Rows[i].Cells["UnitPrice1"].Value);
                            sqlcmd.Parameters.AddWithValue("@StoreValue", dataGridCheckOut.Rows[i].Cells["StockValue1"].Value);
                            sqlcmd.Parameters.AddWithValue("@Requested", dataGridCheckOut.Rows[i].Cells["Request1"].Value);
                            sqlcmd.Parameters.AddWithValue("@TotalRequestedValue", dataGridCheckOut.Rows[i].Cells["Total1"].Value);
                            sqlcmd.Parameters.AddWithValue("@TotalTotalAmount", decimal.Parse(txtTotalAmount.Text));
                            sqlcmd.ExecuteNonQuery();  
                        }
                    MessageBox.Show("Request Succcessful");
                    dataGridCheckOut.Rows.Clear();
                    txtTotalAmount.Text = "";
                    Load_RequestNumber();
                }                
                catch (Exception)
                {
                    MessageBox.Show("Confirm shift and requested amount before proceeding");
                } 
            }
        }

        
    }
}
