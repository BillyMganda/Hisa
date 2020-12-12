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
    public partial class To_BookShort : Form
    {
        ReportDocument crystal = new ReportDocument();
        public To_BookShort()
        {
            InitializeComponent();
        }
        static string connectionstring=ConfigurationManager.ConnectionStrings["Hisa.Properties.Settings.Setting"].ConnectionString;
        string connectionstring1 = @"Data Source=SERVER-PC\SERVERROOM; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //LOAD
        private void To_BookShort_Load(object sender, EventArgs e)
        {
            label1.Text = Print_Book_Short.record_number;
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Book_Short_Done WHERE Record_Number='" + int.Parse(label1.Text) + "'", con);
                DataSet dst = new DataSet();
                sda.Fill(dst, "Book_Short_Done");
                crystal.Load(@"C:\Users\Admin\Desktop\C#\Hisa\Hisa\CrystalReports\CrystalReport_Book_Short.rpt");
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