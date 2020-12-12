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
    public partial class Reprint_LPO : UserControl
    {
        public Reprint_LPO()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
        //RUN
        public static string refnumber = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Fill LPO Number to proceed");
            else
            {
                refnumber = textBox1.Text;
                To_ReprintLPO lpo=new To_ReprintLPO();
                lpo.Show();
            }
        }
    }
}
