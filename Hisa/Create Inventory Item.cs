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
    public partial class Create_Inventory_Item : Form
    {
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=ADMIN-PC\SQLEXPRESS; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Create_Inventory_Item()
        {
            InitializeComponent();
            InitializeComponent();
        }
        //fill main group combobox
        void FillMainGroupCombo()
        {
            using (SqlConnection saConn = new SqlConnection(connectionstring))
            {
                saConn.Open();

                string query = "select MainGroupName from Main_Group";
                SqlCommand cmd = new SqlCommand(query, saConn);

                using (SqlDataReader saReader = cmd.ExecuteReader())
                {
                    while (saReader.Read())
                    {
                        string name = saReader.GetString(0);
                        comboMainGroup.Items.Add(name);
                    }
                }
                saConn.Close();
            }
        }
        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //form loaded
        private void Create_Inventory_Item_Load(object sender, EventArgs e)
        {
            using (SqlConnection saConn = new SqlConnection(connectionstring))
            {
                saConn.Open();

                string query = "select MainGroupName from Main_Group";
                SqlCommand cmd = new SqlCommand(query, saConn);

                using (SqlDataReader saReader = cmd.ExecuteReader())
                {
                    while (saReader.Read())
                    {
                        string name = saReader.GetString(0);
                        comboMainGroup.Items.Add(name);
                    }
                }
                saConn.Close();
            }

        }
    }
}
