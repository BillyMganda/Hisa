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
    public partial class Storekeeper_ReturnToSupplier : Form
    {
        public Storekeeper_ReturnToSupplier()
        {
            InitializeComponent();            
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //FILL CART DATAGRID
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
        //TEXT CHANGED
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT ItemName,ItemCode,Units,SOH,Price,StockValue FROM Stores WHERE ItemName like '" + textBox1.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridCart.DataSource = dt;
            con.Close();
        }
        //ADD TO CART
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridCart.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("Temporary_ReturnToSupplierProc", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridCart.Rows[i].Cells["ItemName"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridCart.Rows[i].Cells["ItemCode"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridCart.Rows[i].Cells["Units"].Value);
                        sqlcmd.Parameters.AddWithValue("@SOH", dataGridCart.Rows[i].Cells["SOH"].Value);
                        sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridCart.Rows[i].Cells["UnitPrice"].Value);
                        sqlcmd.Parameters.AddWithValue("@TotalPrice", dataGridCart.Rows[i].Cells["TotalAmount"].Value);
                        sqlcmd.ExecuteNonQuery();
                    }
                Fill_ChechoutDatagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //LOAD DATA TO CHECKOUT DATAGRID
        private void Fill_ChechoutDatagrid()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    string querry = "SELECT ItemName,ItemCode,Units,SOH,UnitPrice,TotalPrice FROM Temporary_ReturnToSupplier";
                    SqlDataAdapter sqldata = new SqlDataAdapter(querry, connection);
                    DataTable dt = new DataTable();
                    sqldata.Fill(dt);
                    dataGridCheckOut.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //DELETE FROM TEMPORARY RETUEN TO SUPPLIER
        private void Delete_Return()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = $"DELETE FROM Temporary_ReturnToSupplier";
                    SqlCommand command = new SqlCommand(querry, sqlcon);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //FILL REQUEST NUMBER
        void RequestNumber()
        {
            Random rnd = new Random();
            int tal = rnd.Next(0, 1000000);
            textBox2.Text = tal.ToString();
        }
        //LOAD
        private void Storekeeper_ReturnToSupplier_Load(object sender, EventArgs e)
        {
            AutoFillAddToCartDatagrid();
            Fill_ChechoutDatagrid();
            txtRequest.Text = Storekeeper.SetValueForlabel5;
            //Load Date and Time
            string dt = DateTime.Now.Date.ToShortDateString();
            txtDate.Text = dt;
            string time = DateTime.Now.ToShortTimeString();
            txtTime.Text = time;  
            RequestNumber();
            Department();

            this.dataGridCart.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridCart.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;

            this.dataGridCheckOut.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridCheckOut.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
       
        //Department
        void Department()
        {
            string queri = "Select Department from UserInfo where FullNames='"+ txtRequest.Text + "'";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            SqlCommand sqlcmd = new SqlCommand(queri, sqlcon);
            SqlDataReader sqlreader;
            try
            {
                sqlcon.Open();
                sqlreader = sqlcmd.ExecuteReader();
                while (sqlreader.Read())
                {
                    string firstname = sqlreader["Department"].ToString();
                    txtDepartment.Text = firstname;
                }
                sqlcon.Close();
                sqlreader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }                
        //CANCEL
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        //RETURN BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtReason.Text == ""|| txtGRN.Text=="")
                MessageBox.Show("Please provide GRN number and reason for return");
            else
            {
                try
                {
                    for (int i = 0; i < dataGridCheckOut.Rows.Count; i++)
                        using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                        {
                            if (sqlcon.State == ConnectionState.Closed)
                                sqlcon.Open();
                            SqlCommand sqlcmd = new SqlCommand("Return_To_Supplier_Add", sqlcon);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Return_Date", DateTime.Parse(txtDate.Text));
                            sqlcmd.Parameters.AddWithValue("@Return_Time", DateTime.Parse(txtTime.Text));
                            sqlcmd.Parameters.AddWithValue("@Returned_By", txtRequest.Text);
                            sqlcmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                            sqlcmd.Parameters.AddWithValue("@Record_Number", int.Parse(textBox2.Text));
                            sqlcmd.Parameters.AddWithValue("@GRN_Number", int.Parse(txtGRN.Text));
                            sqlcmd.Parameters.AddWithValue("@Return_Reason", txtReason.Text);
                            sqlcmd.Parameters.AddWithValue("@ItemName", dataGridCheckOut.Rows[i].Cells["ItemName1"].Value);
                            sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridCheckOut.Rows[i].Cells["ItemCode1"].Value);
                            sqlcmd.Parameters.AddWithValue("@Units", dataGridCheckOut.Rows[i].Cells["Units1"].Value);
                            sqlcmd.Parameters.AddWithValue("@SOH", dataGridCheckOut.Rows[i].Cells["SOH1"].Value);
                            sqlcmd.Parameters.AddWithValue("@UnitPrice", dataGridCheckOut.Rows[i].Cells["UnitPrice1"].Value);
                            sqlcmd.Parameters.AddWithValue("@TotalPrice", dataGridCheckOut.Rows[i].Cells["TotalPrice1"].Value);
                            sqlcmd.Parameters.AddWithValue("@Return_Amount", dataGridCheckOut.Rows[i].Cells["ToReturn"].Value);
                            sqlcmd.ExecuteNonQuery();
                            txtReason.Text = "";
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Delete_Return();
                MessageBox.Show("Operation successful");
                Fill_ChechoutDatagrid();
                RequestNumber();
            }  
        }
        //PRINT
        private void button3_Click(object sender, EventArgs e)
        {
            Print_Return_To_Supplier pr = new Print_Return_To_Supplier();
            pr.ShowDialog();
        }
    }
}
