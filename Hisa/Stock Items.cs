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
    public partial class Stock_Items : Form
    {
        public Stock_Items()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        //string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //Fill Main Group Combobox
        void FillMaingroup()
        {
            string querry = "SELECT DISTINCT GroupName FROM Main_Group";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            SqlCommand sqlcmd = new SqlCommand(querry, sqlcon);
            SqlDataReader sqlreader;
            try
            {
                sqlcon.Open();
                sqlreader = sqlcmd.ExecuteReader();
                while (sqlreader.Read())
                {
                    string Gname = sqlreader.GetString(0);
                    comboMainGroup.Items.Add(Gname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Fill sub group combobox
        void FillSubGroup()
        {
            string querry = "SELECT DISTINCT GroupName FROM Sub_Group";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            SqlCommand sqlcmd = new SqlCommand(querry, sqlcon);
            SqlDataReader sqlreader;
            try
            {
                sqlcon.Open();
                sqlreader = sqlcmd.ExecuteReader();
                while (sqlreader.Read())
                {
                    string Gname = sqlreader.GetString(0);
                    comboSubGroup.Items.Add(Gname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //AUTOCOMPLETE ITEM NAME            --   TO AVOID DUPLICATION        
        private void Autocomplete_ItemName()
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();
                SqlCommand command = new SqlCommand("SELECT DISTINCT ItemName FROM Approved_StockItems", con);
                DataSet ds = new DataSet();
                SqlDataAdapter adap = new SqlDataAdapter(command);
                adap.Fill(ds, "Approved_StockItems");
                AutoCompleteStringCollection col = new AutoCompleteStringCollection();
                int i = 0;
                for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    col.Add(ds.Tables[0].Rows[i]["ItemName"].ToString());
                }
                txtItemName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtItemName.AutoCompleteCustomSource = col;
                txtItemName.AutoCompleteMode = AutoCompleteMode.Suggest;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //LOAD
        private void Stock_Items_Load(object sender, EventArgs e)
        {
            FillMaingroup();
            FillSubGroup();
            Autocomplete_ItemName();
        }
        //CANCEL
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //SAVE
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtItemName.Text) || string.IsNullOrEmpty(txtItemUnits.Text) || string.IsNullOrEmpty(comboMainGroup.Text) || string.IsNullOrEmpty(comboSubGroup.Text))
            {
                MessageBox.Show("Please fill all relevant fields to proceed");
            }            
            else
            {
                try
                {
                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {
                        if (sqlcon.State == ConnectionState.Closed)
                            sqlcon.Open();
                        SqlCommand sqlcmd = new SqlCommand("StockItemsAdd", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@ItemName", txtItemName.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@Units", txtItemUnits.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@MainGroup", comboMainGroup.Text);
                        sqlcmd.Parameters.AddWithValue("@SubGroup", comboSubGroup.Text);
                        sqlcmd.ExecuteNonQuery();
                        MessageBox.Show("Item successfully saved");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
