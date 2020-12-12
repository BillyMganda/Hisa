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
    public partial class DepartmentConsItem : UserControl
    {
        public DepartmentConsItem()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //Fill Department combobox with data from database
        void FillDepartment()
        {
            string querry = "SELECT DISTINCT Department FROM UserInfo";
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
                    comboDepartment.Items.Add(Gname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Fill Item combobox with data from database
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
                    comboItem.Items.Add(Gname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //today button
        private void btnToday_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now.Date;
            dateTimePicker1.Value = date;
            dateTimePicker2.Value = date;
        }
        //yesterday button
        private void btnYesterday_Click(object sender, EventArgs e)
        {
            DateTime yesterday = DateTime.Now.Date.AddDays(-1);
            dateTimePicker1.Value = yesterday;
            dateTimePicker2.Value = yesterday;
        }
        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //LOAD
        private void DepartmentConsItem_Load(object sender, EventArgs e)
        {
            FillDepartment();
            FillItemName();
        }
        //run button
        public static string department = "";
        public static string item = "";
        public static string from = "";
        public static string to = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (comboDepartment.Text == "" || comboItem.Text == "")
                MessageBox.Show("Please fill all relevant fields to proceed");
            else
            {
                department = comboDepartment.Text;
                item = comboItem.Text;
                from = dateTimePicker1.Text;
                to = dateTimePicker2.Text;
                To_DepartmentConsumptionItem it=new To_DepartmentConsumptionItem();
                it.Show();
            }
        }
    }
}
