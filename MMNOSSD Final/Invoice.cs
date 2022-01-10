using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMNOSSD_Final
{
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.Date.ToString().Substring(0,10);
            label2.Text = Booking.user;
            label3.Text = Booking.car;
            label4.Text = "R"+Booking.amountInv;
            label5.Text = (Booking.startLease).Substring(0, 10);
            label7.Text = (Booking.endLease).Substring(0, 10);
        }
        private void Invoice_FormClosed(object sender, FormClosedEventArgs e)//closes the application if the X button is clicked
        {
            Application.Exit();

        }
    }
}
