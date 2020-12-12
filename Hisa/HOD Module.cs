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
    public partial class HOD_Module : Form
    {
        public HOD_Module(string role)
        {
            InitializeComponent();
            label3.Text = role;
        }
        //CONNECTIONSTRING
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public static string SetValueForlabel9 = "";
        public static string Depa_rtment = "";
        //LOAD
        private void HOD_Module_Load(object sender, EventArgs e)
        {
            try
            {
                string querry = "SELECT Department FROM UserInfo WHERE FullNames='" + label3.Text + "'";
                SqlConnection con = new SqlConnection(connectionstring);
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(querry, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label4.Text = reader["Department"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Authorize request
        private void btnRequest_Click(object sender, EventArgs e)
        {
            SetValueForlabel9 = label3.Text;
            Depa_rtment = label4.Text;
            HOD_Approve_Request hod = new HOD_Approve_Request();
            hod.ShowDialog();
        }
        //Reports button
        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports rpts = new Reports();
            rpts.ShowDialog();
        }
        //switch user
        private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }
       
    }
}
