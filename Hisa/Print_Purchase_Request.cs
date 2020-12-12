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
using Dapper;
using System.Configuration;

namespace Hisa
{
    public partial class Print_Purchase_Request : Form
    {
        public Print_Purchase_Request()
        {
            InitializeComponent();
        }
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        //when Load button is clicked, load data on datagrid depending on dates selected
        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon=new SqlConnection(connectionstring))
            {
                try
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = $"SELECT ItemName,ItemCode,SubGroup,Units,Quantity,RequestNumber FROM PurchaseRequest WHERE Date BETWEEN '{fromDate.Value}' AND '{toDate.Value}'";                                                        
                    printPurchaseRequestsBindingSource.DataSource = sqlcon.Query<PrintPurchaseRequests>(querry, commandType: CommandType.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //Print Button
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPurchaseRequests obj = printPurchaseRequestsBindingSource.Current as PrintPurchaseRequests;
            if (obj != null)
            { 
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                try
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();
                    string querry = $"SELECT Date,Time,RequestedBy,Department,Itemname,ItemCode,SubGroup, Units, Quantity,RequestNumber FROM PurchaseRequest WHERE RequestNumber='obj.RequestNumber'";
                    List<PurchaseRequestDetails>list = sqlcon.Query<PurchaseRequestDetails>(querry, commandType: CommandType.Text).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            }
        }
    }
}
