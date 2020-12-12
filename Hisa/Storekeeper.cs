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
    public partial class Storekeeper : Form
    {
        public Storekeeper(string role)
        {
            InitializeComponent();
            label3.Text = role;
        }
        public static string SetValueForlabel5 = "";
        //Receive stock items
        private void btnReceiveStockItems_Click(object sender, EventArgs e)
        {
            SetValueForlabel5 = label3.Text;
            GRN gRN = new GRN();
            gRN.ShowDialog();
        }
        //item disposal
        private void btnItemDisposal_Click(object sender, EventArgs e)
        {
            SetValueForlabel5= label3.Text;
            Storekeeper_Disposal ids = new Storekeeper_Disposal();
            ids.ShowDialog();
        }
        //Return to supplier
        private void btnReturnToSupplier_Click(object sender, EventArgs e)
        {
            SetValueForlabel5 = label3.Text;
            Storekeeper_ReturnToSupplier rts = new Storekeeper_ReturnToSupplier();
            rts.ShowDialog();
        }
        //departmental budget
        private void btnDepartmental_Click(object sender, EventArgs e)
        {
            Departmental_Budget db = new Departmental_Budget();
            db.ShowDialog();
        }
        //issue from store
        private void btnIssueFromStore_Click(object sender, EventArgs e)
        {
            SetValueForlabel5 = label3.Text;
            Issue_From_Store ifs = new Issue_From_Store();
            ifs.ShowDialog();
        }
        //purchase request
        private void btnPurchaseRequest_Click(object sender, EventArgs e)
        {
            SetValueForlabel5 = label3.Text;
            Purchase_Request pr = new Purchase_Request();
            pr.ShowDialog();
        }
        //reports
        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports pr = new Reports();
            pr.ShowDialog();
        }
        //switch user
        private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }
        //cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetValueForlabel5 = label3.Text;
            ReturnToStore rts = new ReturnToStore();
            rts.ShowDialog();
        }
    }
}
