﻿using System;
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
    public partial class Choose_Department : Form
    {
        public Choose_Department()
        {
            InitializeComponent();
        }
        string Department;

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
        //LOAD
        private void Choose_Department_Load(object sender, EventArgs e)
        {
            label1.Text = Requisitions.SetValueForlabel8;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //PROCEED
        public static string User_Account;
        public static string User_department;
        private void btnProceed_Click(object sender, EventArgs e)
        {
            User_Account = label1.Text;
            User_department = Department;
            Hide();
            Cart cart = new Cart();
            cart.ShowDialog();
        }
    }
}
