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
    public partial class GRN_Reprint : UserControl
    {
        public GRN_Reprint()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
        //RUN
        public static string grnnumber = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Fill GRN Number to proceed");
            else
            {
                grnnumber = textBox1.Text;
                To_ReprintGRN grn=new To_ReprintGRN();
                grn.Show();
            }
        }
    }
}
