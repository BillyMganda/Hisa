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
    public partial class Authorize_Item : Form
    {
        public Authorize_Item()
        {
            InitializeComponent();
        }
        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=ADMIN-PC\SQLEXPRESS; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //Load window
        private void Authorize_Item_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                sqlcon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("SELECT ItemName,ItemUnits,MainGroup,SubGroup FROM StockItems", sqlcon);
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                AuthorizeDatagrid.DataSource = dt;
            }
        }
    }
}
