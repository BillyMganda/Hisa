using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Hisa
{
    public partial class ItemHistoryControl : UserControl
    {
        public ItemHistoryControl()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //Fill Item Name combobox with data from database
        void FillItemName()
        {
            string querry = "SELECT DISTINCT ItemName FROM Approved_StockItems";
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
                    comboBox1.Items.Add(Gname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //LOAD
        private void ItemHistoryControl_Load(object sender, EventArgs e)
        {
            FillItemName();
        }
        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //run button
        public static string itemname = "";
        public static string date1 = "";
        public static string date2 = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                MessageBox.Show("Please fill Item Name to proceed");
            else
            {
                itemname = comboBox1.Text;
                date1 = dateTimePicker1.Text;
                date2 = dateTimePicker2.Text;
                To_ItemHistory history=new To_ItemHistory();
                history.Show();
            }
        }
        
    }
}
