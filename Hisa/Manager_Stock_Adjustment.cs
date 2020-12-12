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
    public partial class Manager_Stock_Adjustment : Form
    {
        public Manager_Stock_Adjustment()
        {
            InitializeComponent();
        }
        public static string Logged_In_User;
        //LOAD
        private void Manager_Stock_Adjustment_Load(object sender, EventArgs e)
        {
            label1.Text = Managers_Module.SetValueForlabel6;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //BOOK OVER
        private void button1_Click(object sender, EventArgs e)
        {
            Logged_In_User = label1.Text;
            Manager_Book_Over mna = new Manager_Book_Over();
            mna.ShowDialog();
        }
        //BOOK SHORT
        private void button2_Click(object sender, EventArgs e)
        {
            Logged_In_User = label1.Text;
            Manager_Book_Short sho=new Manager_Book_Short();
            sho.ShowDialog();
        }
        
    }
}
