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
    public partial class Purchasing : Form
    {
        public Purchasing(string role)
        {
            InitializeComponent();
            label3.Text = role;
        }
        public static string SetValueForText2 = "";
        //Purchase Order button
        private void btnLPO_Click(object sender, EventArgs e)
        {
            SetValueForText2 = label3.Text;
            New_LPO lpo = new New_LPO();
            lpo.ShowDialog();
        }
        //Add stock items button        
        private void btnAddStockItems_Click(object sender, EventArgs e)
        {
            Add_Stock_Items asi = new Add_Stock_Items();
            asi.ShowDialog();
            
        }
        //request from store button
        private void btnRequest_Click(object sender, EventArgs e)
        {
            SetValueForText2 = label3.Text;
            Choose_Department_Purchasing purchasing = new Choose_Department_Purchasing();
            purchasing.ShowDialog();
        }
        //Reports button
        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports rpts = new Reports();
            rpts.ShowDialog();
        }
        //Add supplier button
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            Add_Supplier_Info asi = new Add_Supplier_Info();
            asi.ShowDialog();
        }
        //Switch User button
        private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }
    }
}
