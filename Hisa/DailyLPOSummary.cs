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
    public partial class DailyLPOSummary : UserControl
    {
        public DailyLPOSummary()
        {
            InitializeComponent();
        }
        //today
        private void btnToday_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now.Date;
            dateTimePicker1.Value = date;
        }
        //yesterday
        private void btnYesterday_Click(object sender, EventArgs e)
        {
            DateTime yesterday = DateTime.Now.Date.AddDays(-1);
            dateTimePicker1.Value = yesterday;
        }
        //cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //run
        public static string day = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            day = dateTimePicker1.Text;
            To_DailyLPOSummary daily=new To_DailyLPOSummary();
            daily.Show();
        }
    }
}
