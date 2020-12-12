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
    public partial class DepartmentConsSub : UserControl
    {
        public DepartmentConsSub()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //Fill Department combobox with data from database
        void FillDepartment()
        {
            string querry = "SELECT DISTINCT Department from UserInfo";
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
        //Fill Sub Group combobox with data from database
        void FillSubGroup()
        {
            string querry = "SELECT DISTINCT SubGroup FROM Approved_StockItems";
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
        private void DepartmentConsSub_Load(object sender, EventArgs e)
        {
            FillDepartment();
            FillSubGroup();
        }
        //run button
        public static string department = "";
        public static string subgroup = "";
        public static string from = "";
        public static string to = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (comboDepartment.Text == "" || comboSubGroup.Text == "")
                MessageBox.Show("Please fill all relevant items to proceed");
            else
            {
                department = comboDepartment.Text;
                subgroup = comboSubGroup.Text;
                from = dateTimePicker1.Text;
                to = dateTimePicker2.Text;
                To_DepartmentConsumptionSubGroup sub=new To_DepartmentConsumptionSubGroup();
                sub.Show();
            }
        }
    }
}
