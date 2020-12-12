using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Hisa
{
    public partial class Approve_Inventory_Items : Form
    {
        public Approve_Inventory_Items()
        {
            InitializeComponent();
        }
        //CONNECTION STRING
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        //LOAD
        private void Approve_Inventory_Items_Load(object sender, EventArgs e)
        {
            this.dataGridApprove.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.dataGridApprove.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
            //FILL DETAILS TO DATAGRID
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter($"SELECT ItemCode,ItemName,MainGroup,SubGroup,Units FROM StockItems", sqlcon);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    dataGridApprove.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //CLOSE
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        //DELETE FROM STOCK ITEMS
        void Delete_()
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {
                    sqlcon.Open();
                    string querry = "DELETE FROM StockItems";
                    SqlCommand cmd = new SqlCommand(querry, sqlcon);
                    SqlDataReader myreader;
                    myreader = cmd.ExecuteReader();
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //REFRESH
        private void RefreshWindow()
        {
            Approve_Inventory_Items app = new Approve_Inventory_Items();
            app.ShowDialog();
        }
        //VOID
        private void btnVoid_Click(object sender, EventArgs e)
        {
            Delete_();
            RefreshWindow();
        }
        //APPROVE
        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            try
            {
                foreach (DataGridViewRow row in dataGridApprove.Rows)
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Approved_StockItems(ItemCode,ItemName,Units,MainGroup,SubGroup) VALUES(@ItemCode,@ItemName,@Units,@MainGroup,@SubGroup)", con))
                    {
                        cmd.Parameters.AddWithValue("@ItemCode", row.Cells["ItemCode"].Value);
                        cmd.Parameters.AddWithValue("@ItemName", row.Cells["ItemName"].Value);
                        cmd.Parameters.AddWithValue("@MainGroup", row.Cells["MainGroup"].Value);
                        cmd.Parameters.AddWithValue("@SubGroup", row.Cells["SubGroup"].Value);
                        cmd.Parameters.AddWithValue("@Units", row.Cells["ItemUnits"].Value);
                        cmd.ExecuteNonQuery();                        
                        Delete_();
                    }                 
                    
                }
                MessageBox.Show("Item(s) Added Successfully");
                RefreshWindow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
