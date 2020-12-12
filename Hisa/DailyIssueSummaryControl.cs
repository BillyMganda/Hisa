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
    public partial class DailyIssueSummaryControl : UserControl
    {
        public DailyIssueSummaryControl()
        {
            InitializeComponent();
        }
        //close button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //yesterday button
        private void btnYesterday_Click(object sender, EventArgs e)
        {
            DateTime yesterday = DateTime.Now.Date.AddDays(-1);
            dateTimePicker1.Value = yesterday;            
        }
        //today button
        private void btnToday_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now.Date;
            dateTimePicker1.Value = date;            
        }
        //run button
        public static string day = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            day = dateTimePicker1.Text;
            To_DailyIssueSummary daily=new To_DailyIssueSummary();
            daily.Show();
        }
    }
}
