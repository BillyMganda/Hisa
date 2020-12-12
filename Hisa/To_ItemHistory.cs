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
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;

namespace Hisa
{
    public partial class To_ItemHistory : Form
    {
        ReportDocument crystal = new ReportDocument();
        public To_ItemHistory()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //form load event
        private void To_ItemHistory_Load(object sender, EventArgs e)
        {
            label1.Text = ItemHistoryControl.itemname;
            label2.Text = ItemHistoryControl.date1;
            label3.Text = ItemHistoryControl.date2;
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Item_History_View WHERE ItemName='"+label1.Text+"' AND Delivery_Date BETWEEN '" + DateTime.Parse(label2.Text) + "' AND '" + DateTime.Parse(label3.Text) + "' ", con);
                DataSet dst = new DataSet();
                sda.Fill(dst, "Item_History_View");
                crystal.Load(@"C:\Users\Admin\Desktop\C#\Hisa\Hisa\CrystalReports\CrystalReport_ItemHistory.rpt");
                crystal.SetDataSource(dst);
                crystalReportViewer1.ReportSource = crystal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
