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
    public partial class StockVariance : UserControl
    {
        public StockVariance()
        {
            InitializeComponent();
        }
        
        //cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //run button
        public static string stock_date = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            stock_date = dateTimePicker1.Text;
            To_StockVariance variance=new To_StockVariance();
            variance.Show();
        }
    }
}
