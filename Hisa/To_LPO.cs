﻿using System;
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
    public partial class ToLPO : Form
    {
        ReportDocument crystal = new ReportDocument();
        public ToLPO()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //form load event
        private void ToLPO_Load(object sender, EventArgs e)
        {
            label1.Text = Purchasing_Print_LPO.reference_number;
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                SqlDataAdapter sda = new SqlDataAdapter($"SELECT * FROM LPO_Done WHERE RefNumber= '"+int.Parse(label1.Text) +"' ", con);
                DataSet dst = new DataSet();
                sda.Fill(dst, "LPO_Done");
                crystal.Load(@"C:\Users\Admin\Desktop\C#\Hisa\Hisa\CrystalReports\LPO_Report.rpt");
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
