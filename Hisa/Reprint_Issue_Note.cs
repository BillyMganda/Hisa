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
    public partial class Reprint_Issue_Note : UserControl
    {
        public Reprint_Issue_Note()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
        //RUN
        public static string issuenumber = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            issuenumber = textBox1.Text;
            To_Reprint_Issue_Note issue=new To_Reprint_Issue_Note();
            issue.Show();
        }
    }
}
