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
    public partial class Request_For_Purchase : Form
    {
        ComboBox combo;
        TextBox ItemCodez;
        TextBox MainGroupz;
        TextBox SubGroupz;
        TextBox Unitsz;

        public Request_For_Purchase()
        {
            InitializeComponent();
        }
        //connection string
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=ADMIN-PC\SQLEXPRESS; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True;";
        //Populate ItemName combobox in datagrid
        void PopulateItemName()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    connection.Open();
                    string querry = "SELECT ItemName,ItemCode,Units,MainGroup,SubGroup from StockItems";                          
                    SqlDataAdapter sqldata = new SqlDataAdapter(querry, connection);
                    DataTable dt = new DataTable();
                    sqldata.Fill(dt);
                    ItemName.ValueMember = "ItemName";
                    ItemName.DisplayMember = "ItemName";
                    //dataGridView1.DataSource = dt;
                    ItemName.DataSource = dt;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Load window
        private void Request_For_Purchase_Load(object sender, EventArgs e)
        {
            //Populate ItemName combobox in datagrid
            PopulateItemName();
            //get current date and time to date and time textboxs
            string date = System.DateTime.Now.Date.ToString();
            txtDate.Text = date;
            string time = System.DateTime.Now.TimeOfDay.ToString();
            txtTime.Text = time;
            //autofill Request number textbox with value from database
            RetrieveRequestNumber();
            //Fill requested by and department desxboxes
            FillSupplierNameCombo();
        }
        //autofill Request number textbox with value from database
        void RetrieveRequestNumber()
        {
            try
            {
                string querry = "SELECT RequestID FROM PurchaseRequest";
                SqlConnection con = new SqlConnection(connectionstring);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int value = int.Parse(reader[0].ToString()) + 1;
                    textBox1.Text = value.ToString();
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //save button
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        //auto complete item name on datagrid
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.ColumnIndex == 0)
                {
                    SqlDataReader dreader;
                    SqlConnection conn = new SqlConnection(connectionstring);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    AutoCompleteStringCollection autocomplete = new AutoCompleteStringCollection();
                    cmd.CommandText = "SELECT ItemName,ItemCode,Units,MainGroup,SubGroup from StockItems";
                    conn.Open();
                    dreader = cmd.ExecuteReader();
                    if (dreader.HasRows == true)
                    {
                        while (dreader.Read())
                            autocomplete.Add(dreader["ItemName"].ToString());                       
                    }
                    else
                    {
                        MessageBox.Show("Data not Found");
                    }
                    dreader.Close();
                    TextBox txtBusID = e.Control as TextBox;
                    if (txtBusID != null)
                    {
                        txtBusID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        txtBusID.AutoCompleteCustomSource = autocomplete;
                        txtBusID.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Get objects
            ItemCodez = e.Control as TextBox;                           
            MainGroupz = e.Control as TextBox;            
            SubGroupz = e.Control as TextBox;            
            Unitsz = e.Control as TextBox;            
            combo = e.Control as ComboBox;
            if(combo != null)
            {
                combo.SelectedIndexChanged -= new EventHandler(combo_SelectedIndexChanged);                
                combo.SelectedIndexChanged += combo_SelectedIndexChanged;
            }
        }
        //Genereted index changed method
        private void combo_SelectedIndexChanged(object sender, EventArgs e)                                  //
        {
            TextSelected();            
        }
        //to be called
        public void TextSelected()
        {
            try
            {
                SqlConnection sqlcon = new SqlConnection(connectionstring);
                string querry = "SELECT ItemCode,Units,MainGroup,SubGroup from StockItems where ItemName=  '"+combo.Text+"' ";     //            
                SqlCommand sqlcmd = new SqlCommand(querry, sqlcon);
                SqlDataReader sqlreader;
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                using (sqlcon)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        sqlreader = sqlcmd.ExecuteReader();
                        while (sqlreader.Read())
                        {
                            string itemcode = sqlreader["ItemCode"].ToString();
                            string Units = sqlreader["Units"].ToString();
                            string maingroup = sqlreader["MainGroup"].ToString();
                            string subgroup = sqlreader["SubGroup"].ToString();
                            row.Cells[dataGridView1.Columns["ItemCode"].Index].Value = itemcode;
                            row.Cells[dataGridView1.Columns["Units"].Index].Value = Units;
                            row.Cells[dataGridView1.Columns["MainGroup"].Index].Value = maingroup;
                            row.Cells[dataGridView1.Columns["SubGroup"].Index].Value = subgroup;
                            dataGridView1.Refresh();
                            itemcode = "";
                        }
                        sqlreader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //Fill Requested by texbox with data from database
        void FillSupplierNameCombo()
        {
            //Requested by - get name of storekeeper
            string queri = "SELECT FirstName, LastName from UserInfo where Role='Storekeeper'";
            SqlConnection sqlcon = new SqlConnection(connectionstring);
            SqlCommand sqlcmd = new SqlCommand(queri, sqlcon);
            SqlDataReader sqlreader;
            try
            {
                sqlcon.Open();
                sqlreader = sqlcmd.ExecuteReader();
                while (sqlreader.Read())
                {
                    string firstname = sqlreader["FirstName"].ToString() + " " + sqlreader["LastName"].ToString();
                    txtRequestedBy.Text = firstname;
                    txtRequestedBy.Text = firstname;
                }
                sqlcon.Close();
                sqlreader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Autofill data with department
            string depart = "SELECT Department from UserInfo where Role='Storekeeper'";
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand command = new SqlCommand(depart, con);
            SqlDataReader reader;
            try
            {
                con.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string department = reader["Department"].ToString();
                    txtDepartment.Text = department;
                }
                sqlcon.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
