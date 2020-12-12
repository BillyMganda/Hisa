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
    public partial class PurchaseMainGroup : UserControl
    {
        public PurchaseMainGroup()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //Fill Main Group combobox with data from database
        void FillGroup()
        {
            string querry = "SELECT DISTINCT MainGroup FROM Approved_StockItems";
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
        //LOAD
        private void PurchaseMainGroup_Load(object sender, EventArgs e)
        {
            FillGroup();
        }
        //today
        private void btnToday_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now.Date;
            dateTimePicker1.Value = date;
            dateTimePicker2.Value = date;
        }
        //yesterday
        private void btnYesterday_Click(object sender, EventArgs e)
        {
            DateTime yesterday = DateTime.Now.Date.AddDays(-1);
            dateTimePicker1.Value = yesterday;
            dateTimePicker2.Value = yesterday;
        }
        //cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //run
        public static string maingroup = "";
        public static string from = "";
        public static string to = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (comboMainGroup.Text == "")
                MessageBox.Show("Choose main group to proceed");
            else
            {
                maingroup = comboMainGroup.Text;
                from = dateTimePicker1.Text;
                to = dateTimePicker2.Text;
                To_PurchasesForMainGroup gGroup=new To_PurchasesForMainGroup();
                gGroup.Show();
            }
        }
    }
}
