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
    public partial class Choose_Department_Statistics : Form
    {
        public Choose_Department_Statistics()
        {
            InitializeComponent();
        }
        string Department;
        //LOAD
        private void Choose_Department_Statistics_Load(object sender, EventArgs e)
        {
            label1.Text = Statistics.LoggedInUser;
        }

        private void radioAccounts_CheckedChanged(object sender, EventArgs e)
        {
            Department = "Accounts";
        }

        private void radioAdministration_CheckedChanged(object sender, EventArgs e)
        {
            Department = "Administration";
        }

        private void radioBar_CheckedChanged(object sender, EventArgs e)
        {
            Department = "F & B Service";
        }

        private void radioCage_CheckedChanged(object sender, EventArgs e)
        {
            Department = "Cashier";
        }

        private void radioGaming_CheckedChanged(object sender, EventArgs e)
        {
            Department = "Gaming";
        }

        private void radioHousekeeping_CheckedChanged(object sender, EventArgs e)
        {
            Department = "Housekeeping";
        }

        private void radioHR_CheckedChanged(object sender, EventArgs e)
        {
            Department = "HR";
        }

        private void radioICT_CheckedChanged(object sender, EventArgs e)
        {
            Department = "ICT";
        }

        private void radioKitchenMain_CheckedChanged(object sender, EventArgs e)
        {
            Department = "F & B Production";
        }

        private void radioMaintenance_CheckedChanged(object sender, EventArgs e)
        {
            Department = "Maintenance";
        }

        private void radioSecurity_CheckedChanged(object sender, EventArgs e)
        {
            Department = "Security";
        }

        private void radioStatistics_CheckedChanged(object sender, EventArgs e)
        {
            Department = "Statistics";
        }

        private void radioStores_CheckedChanged(object sender, EventArgs e)
        {
            Department = "Stores & Purchasing";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //PROCEED
        public static string dpt = "";
        public static string user = "";
        private void btnProceed_Click(object sender, EventArgs e)
        {
            dpt = Department;
            user = label1.Text;
            Hide();
            Cart_Statistics stats=new Cart_Statistics();
            stats.ShowDialog();
        }
    }
}
