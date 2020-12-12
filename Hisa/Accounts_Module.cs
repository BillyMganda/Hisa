using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Hisa
{
    public partial class Accounts_Module : Form
    {
        public Accounts_Module(string role)
        {
            InitializeComponent();
            label3.Text = role;
        }
        public static string SetValueForlabel7 = "";
        private void Accounts_Module_Load(object sender, EventArgs e)
        {

        }
        //physical stock count
        private void btnPhysicalStockCount_Click(object sender, EventArgs e)
        {
            Stock_Count sc = new Stock_Count();
            sc.ShowDialog();
        }
        //add stock items
        private void btnAddStockItems_Click(object sender, EventArgs e)
        {
            Add_Stock_Items asi = new Add_Stock_Items();
            asi.ShowDialog();
        }
        //Request from Store
        private void btnRequestfromStore_Click(object sender, EventArgs e)
        {
            SetValueForlabel7 = label3.Text;
            Cart cart = new Cart();
            cart.ShowDialog();
        }
        //Reports
        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports rps = new Reports();
            rps.ShowDialog();
        }
        //stock adjustment
        private void btnStockAdjustment_Click(object sender, EventArgs e)
        {
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
        //Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
