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
    public partial class Add_Stock_Items : Form
    {
        public Add_Stock_Items()
        {
            InitializeComponent();            
        }
        //add main group
        private void btnMainGroup_Click(object sender, EventArgs e)
        {
            Main_Group mg = new Main_Group();
            mg.ShowDialog();
        }
        //sub group
        private void btnSubGroup_Click(object sender, EventArgs e)
        {
            Sub_Group sg = new Sub_Group();
            sg.ShowDialog();
        }
        //stock items     
        
        private void btnStockItem_Click(object sender, EventArgs e)
        {
            Stock_Items si = new Stock_Items();
            si.ShowDialog();
        }
        //cancel button
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
