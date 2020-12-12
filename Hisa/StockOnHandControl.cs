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
    public partial class StockOnHandControl : UserControl
    {
        public StockOnHandControl()
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
            To_StockOnHand hand=new To_StockOnHand();
            hand.Show();
        }
    }
}
