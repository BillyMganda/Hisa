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
    public partial class PhysicalStocksControl : UserControl
    {
        public PhysicalStocksControl()
        {
            InitializeComponent();
        }
        
        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //run button
        public static string date = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            date = dateTimePicker1.Text;
            To_PhysicalStocsCount stocs=new To_PhysicalStocsCount();
            stocs.Show();
        }
    }
}
