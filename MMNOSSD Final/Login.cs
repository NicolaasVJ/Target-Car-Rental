using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMNOSSD_Final
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        OleDbConnection conn;
        public void ConnectToDatabase()
        {
            var DBPath = Application.StartupPath + "\\carRentalDB.accdb";
            conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + DBPath);
            conn.Open();
        }
        private void loginBtn_Click(object sender, EventArgs e)
        {
            OleDbDataReader myReader;
            ConnectToDatabase();
             try
               {
            
            if (adminChkBx.Checked)
            {
                OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Select * FROM Admin where Username ='" + userTxtBx.Text + "' and Password= '" + passTxtBx.Text + "';";
                    myReader = cmd.ExecuteReader();
                    
                if (myReader.HasRows)
                {
                    CustomerManagement custManage = new CustomerManagement();
                    custManage.Show();
                    this.Hide();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect Admin username or password");
                    conn.Close();
                }

            }
            else
            {

                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Select * FROM Customers where Username ='" + userTxtBx.Text + "' and Password= '" + passTxtBx.Text + "';";
                myReader = cmd.ExecuteReader();
                if ((myReader.HasRows))
                {
                    Booking book = new Booking();
                    book.Show();
                    this.Hide();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password");
                    conn.Close();
                }
            }
            }

            catch 
            {
                MessageBox.Show("Login Exception");
            }
        }



        private void registerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Register().Show();
        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)//closes the application if the X button is clicked
        {
            Application.Exit();

        }
    }
}
