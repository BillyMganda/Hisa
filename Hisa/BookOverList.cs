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
    public partial class BookOverList : UserControl
    {
        public BookOverList()
        {
            InitializeComponent();
        }
        //today
        private void btnToday_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now.Date;
            dateTimePicker1.Value = date;
            dateTimePicker2.Value = date;
        }
        //yesterday
        private void btnYesterday_Click(object sender, EventArgs e)
        {
            DateTime yesterday = DateTime.Now.Date.AddDays(-1);
            dateTimePicker1.Value = yesterday;
            dateTimePicker2.Value = yesterday;
        }
        //cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //run
        public static string from = "";
        public static string to = "";
        private void btnRun_Click(object sender, EventArgs e)
        {
            @from = dateTimePicker1.Text;
            to = dateTimePicker2.Text;
            To_BookOverList book=new To_BookOverList();
            book.Show();
        }
    }
}
