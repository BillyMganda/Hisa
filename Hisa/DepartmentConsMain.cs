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
    public partial class DepartmentConsMain : UserControl
    {
        public DepartmentConsMain()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Fill Department combobox
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
        void FillMainGroup()
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
        private void DepartmentConsMain_Load(object sender, EventArgs e)
        {
            FillDepartment();
            FillMainGroup();
        }
        //run button
        public static string department = "";
        public static string maingroup = "";
        public static string from = "";
        public static string to = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (comboDepartment.Text == "" || comboMainGroup.Text == "")
                MessageBox.Show("Please fill all relevant fields to proceed");
            else
            {
                department = comboDepartment.Text;
                maingroup = comboMainGroup.Text;
                from = dateTimePicker1.Text;
                to = dateTimePicker2.Text;
                To_DepartmentConsumptionMainGroup cons=new To_DepartmentConsumptionMainGroup();
                cons.Show();
            }
        }
    }
}
