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
    public partial class GRN_Search_LPO : Form
    {
        public GRN_Search_LPO()
        {
            InitializeComponent();
        }

        //SEARCH DB FOR LPO NUMBER
        public static string LPO_NO="";
        private void button1_Click(object sender, EventArgs e)
        {
            LPO_NO=textBox1.Text;
            this.Hide();
        }
        //ENTER IS HIT
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                 button1_Click(this, new EventArgs());
            }
        }
    }
}
