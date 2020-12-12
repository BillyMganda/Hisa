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
    public partial class Stock_Adjustment : Form
    {
        public Stock_Adjustment()
        {
            InitializeComponent();
        }
        public static string Transfer_Name;
        //LOAD
        private void Stock_Adjustment_Load(object sender, EventArgs e)
        {
            label3.Text = Statistics.LoggedInUser;
        }
        //cancel
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Book over
        private void btnBookOver_Click(object sender, EventArgs e)
        {
            Transfer_Name = label3.Text;
            Book_Over bo = new Book_Over();
            bo.ShowDialog();
        }
        //Book short
        private void btnBookShort_Click(object sender, EventArgs e)
        {
            Transfer_Name = label3.Text;
            Book_Short bs = new Book_Short();
            bs.ShowDialog();
        }
        
    }
}
