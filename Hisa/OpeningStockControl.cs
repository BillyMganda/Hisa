using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hisa
{
    public partial class OpeningStockControl : UserControl
    {
        public OpeningStockControl()
        {
            InitializeComponent();
        }
        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //run button
        private void btnRun_Click(object sender, EventArgs e)
        {
            To_OpeningStock opening=new To_OpeningStock();
            opening.Show();
        }
    }
}
