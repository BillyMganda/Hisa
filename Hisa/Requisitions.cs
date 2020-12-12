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
    public partial class Requisitions : Form
    {
        public Requisitions(string role)
        {
            InitializeComponent();
            label3.Text = role;
        }
        public static string SetValueForlabel8 = "";
        //Request from store button
        private void btnRequest_Click(object sender, EventArgs e)
        {
            SetValueForlabel8 = label3.Text;
            Choose_Department cd = new Choose_Department();
            cd.ShowDialog();
        }
        //switch user button
        private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();            
        }
    }
}
