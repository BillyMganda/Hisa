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
    public partial class Purchase_Request : Form
    {
        public Purchase_Request()
        {
            InitializeComponent();            
        }
        //CONNECTIONSTING
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }       
       
        //FOAM LOAD
        private void Purchase_Request_Load(object sender, EventArgs e)
        {
            //Load time and date to textboxes
            string datetime = DateTime.Now.Date.ToShortDateString();
            txtDate.Text = datetime;
            string time = DateTime.Now.ToShortTimeString();
            txtTime.Text = time;            
            //LOAD DATA TO CARTDATAGRID  
            Load_Data();
            //LOGGED IN USER
            textBox2.Text = Storekeeper.SetValueForlabel5;
            //DEPARTMENT
            Fill_Department();
            //REQUEST NUMBER
            Fill_Request_Number();

            this.dataGridCart.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridCart.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;

            this.dataGridCheckOut.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridCheckOut.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
        }
        //LOAD DATA TO CART DATAGRID
        void Load_Data()
        {
            //FILL DETAILS TO DATAGRID
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemCode,ItemName,MainGroup,SubGroup,Units FROM Approved_StockItems ORDER BY ItemName ASC", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGridCart.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //TEXT CHANGED IN SEARCH TEXTBOX
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT ItemName,ItemCode,MainGroup,SubGroup,Units FROM Approved_StockItems where ItemName like '" + txtSearch.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridCart.DataSource = dt;
            con.Close();
        }
        //COPY DATA FROM CART DATAGRID TO CHECKOUT DATAGRID
        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            for(int i=0; i< dataGridCart.Rows.Count; i++)
            {
                row = (DataGridViewRow)dataGridCart.Rows[i].Clone();
                int intColIndex = 0;
                foreach(DataGridViewCell cell in dataGridCart.Rows[i].Cells)
                {
                    row.Cells[intColIndex].Value = cell.Value;
                    intColIndex++;
                }
                dataGridCheckOut.Rows.Add(row);
            }
            dataGridCheckOut.AllowUserToAddRows = false;
            dataGridCheckOut.Refresh();
        }
        
        //FILL DEPARTMENT
        public void Fill_Department()
        {            
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataReader myReader = null;
            SqlCommand command = new SqlCommand("SELECT Department FROM UserInfo WHERE FullNames='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            myReader = command.ExecuteReader();
            while (myReader.Read())
            {
                textBox3.Text = (myReader["Department"].ToString());
            }
            con.Close();
        }
        //FILL REQUEST NUMBER               --COME BACK HERE    (RANDOM NUMBER GENERATED)        
        public void Fill_Request_Number()
        {
            try
            {                
                Random r = new Random();
                int rInt = r.Next(0, 100000);                
                textBox1.Text = rInt.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //SAVE
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridCheckOut.Rows.Count; i++)
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("PurchaseRequestAdd", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Date", txtDate.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@Time", txtTime.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@RequestNumber", textBox1.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@RequestedBy", textBox2.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@Department", textBox3.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@ItemName", dataGridCheckOut.Rows[i].Cells["ItemName1"].Value);
                        sqlcmd.Parameters.AddWithValue("@ItemCode", dataGridCheckOut.Rows[i].Cells["ItemCode1"].Value);
                        sqlcmd.Parameters.AddWithValue("@MainGroup", dataGridCheckOut.Rows[i].Cells["Maingroup1"].Value);
                        sqlcmd.Parameters.AddWithValue("@SubGroup", dataGridCheckOut.Rows[i].Cells["SubGroup1"].Value);
                        sqlcmd.Parameters.AddWithValue("@Units", dataGridCheckOut.Rows[i].Cells["Units1"].Value);
                        sqlcmd.Parameters.AddWithValue("@Quantity", dataGridCheckOut.Rows[i].Cells["Quantity1"].Value);
                        sqlcmd.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Operation Successfull");
            dataGridCheckOut.Rows.Clear();
            Fill_Request_Number();
        }

        
    }
}
