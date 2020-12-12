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
    public partial class Managers_Module : Form
    {
        public Managers_Module(string role)
        {
            InitializeComponent();
            label3.Text = role;
        }
        public static string SetValueForlabel6 = "";
       
        //Add stock items
        private void btnStockItems_Click(object sender, EventArgs e)
        {
            Approve_Inventory_Items asi = new Approve_Inventory_Items();
            asi.ShowDialog();
        }
        
        //Purchase Order
        private void btnLPO_Click(object sender, EventArgs e)
        {
            SetValueForlabel6 = label3.Text;
           Manager_LPO nlpo = new Manager_LPO();
            nlpo.ShowDialog();
        }
        //AUTHORIZE REQUEST
        private void btnRequest_Click(object sender, EventArgs e)
        {
            SetValueForlabel6 = label3.Text;
            Manager_Approve_Request request=new Manager_Approve_Request();
            request.ShowDialog();
        }
        //Item Disposal
        private void btnItemDisposal_Click(object sender, EventArgs e)
        {
            SetValueForlabel6 = label3.Text;
            Item_Disposal ids = new Item_Disposal();
            ids.ShowDialog();
        }
        //Stock Adjustment
        private void btnStockAdjustment_Click(object sender, EventArgs e)
        {
            SetValueForlabel6 = label3.Text;
            Manager_Stock_Adjustment sa = new Manager_Stock_Adjustment();
            sa.ShowDialog();
        }
        //Add Supplier
        private void btnSupplier_Click(object sender, EventArgs e)
        {
            Add_Supplier_Info asi = new Add_Supplier_Info();
            asi.ShowDialog();
        }
        //Reports
        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports tpts = new Reports();
            tpts.ShowDialog();
        }
        //Return to supplier
        private void btnReturntoSupplier_Click(object sender, EventArgs e)
        {
            SetValueForlabel6 = label3.Text;
            Return_To_Supplier rts = new Return_To_Supplier();
            rts.ShowDialog();
        }
        //Return To store
        private void btnReturn_Click(object sender, EventArgs e)
        {
            SetValueForlabel6 = label3.Text;
            Manager_ReturnToStore ret = new Manager_ReturnToStore();
            ret.ShowDialog();
        }
        
        //Switch user
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }
    }
}
