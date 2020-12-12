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
    public partial class ReprintReturnToSupplier : UserControl
    {
        public ReprintReturnToSupplier()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
        //RUN
        public static string returnnumber = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Input return Number to proceed");
            else
            {
                returnnumber = textBox1.Text;
                To_ReturnToSupplierReprint reprint=new To_ReturnToSupplierReprint();
                reprint.Show();
            }
        }
    }
}
