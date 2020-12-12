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
    public partial class To_DepartmentConsumptionSubGroup : Form
    {
        ReportDocument crystal = new ReportDocument();
        public To_DepartmentConsumptionSubGroup()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //LOAD
        private void To_DepartmentConsumptionSubGroup_Load(object sender, EventArgs e)
        {
            label1.Text = DepartmentConsSub.department;
            label2.Text = DepartmentConsSub.subgroup;
            label3.Text = DepartmentConsSub.from;
            label4.Text = DepartmentConsSub.to;
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Requests_StockItems WHERE Department='" + label1.Text + "' AND SubGroup='" + label2.Text + "' AND Issue_Date BETWEEN '" + DateTime.Parse(label3.Text) + "' AND '" + DateTime.Parse(label4.Text) + "' ", con);
                DataSet dst = new DataSet();
                sda.Fill(dst, "Requests_StockItems");
                crystal.Load(@"C:\Users\Admin\Desktop\C#\Hisa\Hisa\CrystalReports\CrystalReport_SubGroupConsumption.rpt");
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
