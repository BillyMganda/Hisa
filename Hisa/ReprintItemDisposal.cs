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
    public partial class ReprintItemDisposal : UserControl
    {
        public ReprintItemDisposal()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
        //RUN
        public static string record = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Fill record number to proceed");
            else
            {
                record = textBox1.Text;
                To_ReprintItemDisposal disposal=new To_ReprintItemDisposal();
                disposal.Show();
            }
        }
    }
}
