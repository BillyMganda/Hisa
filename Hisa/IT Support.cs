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
    public partial class IT_Support : Form
    {
        public IT_Support(string role)
        {
            InitializeComponent();
            label3.Text = role;
        }
        public static string SetValueForText1 = "";
        //new account button
        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            Add_User au = new Add_User();
            au.ShowDialog();
        }
        
        //switch user button
        private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            Login ln = new Login();
            ln.Show();
            this.Hide();
        }
        //Request from store button
        private void btnRequest_Click(object sender, EventArgs e)
        {
            SetValueForText1 = label3.Text;
            Choose_Department_IT it=new Choose_Department_IT();
            it.ShowDialog();
        }
        //Delete user account button
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            Delete_User_Account dua = new Delete_User_Account();
            dua.ShowDialog();
        }
        
        //change password
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            Change_Password cp = new Change_Password();
            cp.ShowDialog();
        }
        //Retrieve Password
        private void btnRetrievePassword_Click(object sender, EventArgs e)
        {
            Authorization auth = new Authorization();
            auth.ShowDialog();
        }
        //Reports button
        private void button1_Click(object sender, EventArgs e)
        {
            Reports rpt = new Reports();
            rpt.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetValueForText1 = label3.Text;
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to enter new stocks? This should ONLY be done on a new system installation.","Enter New Stocks",MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                Load_Stock_Items stock = new Load_Stock_Items();
                stock.ShowDialog();
            }

            if (result == DialogResult.No)
            {

            }
        }
    }
}
