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
    public partial class VoidLPOs : UserControl
    {
        public VoidLPOs()
        {
            InitializeComponent();
        }
        
        //cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //run
        private void btnRun_Click(object sender, EventArgs e)
        {
            To_VoidedLPO lpo=new To_VoidedLPO();
            lpo.Show();
        }
    }
}
