using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hisa
{
    public partial class Statistics : Form
    {
        public Statistics(string role)
        {
            InitializeComponent();
            label3.Text = role;
        }
        public static string LoggedInUser;
        
        //PHYSICAL STOCK COUNT
        private void btnPhysicalStockCount_Click(object sender, EventArgs e)
        {
            LoggedInUser = label3.Text;
            Stock_Count sc = new Stock_Count();
            sc.ShowDialog();
        }
        //Request from store
        private void btnRequest_Click(object sender, EventArgs e)
        {
            LoggedInUser = label3.Text;
            Choose_Department_Statistics choose=new Choose_Department_Statistics();
            choose.ShowDialog();
        }
        //Reports
        private void bbtnReports_Click(object sender, EventArgs e)
        {
            Reports rp = new Reports();
            rp.ShowDialog();
        }
        //stock adjustment
        private void btnStockAdjustment_Click(object sender, EventArgs e)
        {
            LoggedInUser = label3.Text;
            Stock_Adjustment sa = new Stock_Adjustment();
            sa.ShowDialog();
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
