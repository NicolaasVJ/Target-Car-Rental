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
    public partial class Booking : Form
    {
        public static String amountInv;
        public static String user;
        public static String car;
        public static String startLease;
        public static String endLease;
        public Booking()
        {
            InitializeComponent();
            carNames();
            //this.bookCarBtn.Enabled = false;
            carListCmbBx.SelectedIndex = 0;
        }
        OleDbConnection conn;
        public void ConnectToDatabase()
        {
            var DBPath = Application.StartupPath + "\\carRentalDB.accdb";
            conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + DBPath);
            conn.Open();
        }//done
        public void carNames()
        {
            ConnectToDatabase();
            OleDbDataReader result;
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select carName FROM car ;";
            result = cmd.ExecuteReader();
            while (result.Read())
            {
                carListCmbBx.Items.Add(result.GetString(0));
            }
            
        }//done
        public int CarIDFinder(String carName)
        {
            ConnectToDatabase();

            OleDbDataReader result;
            OleDbCommand cmd = conn.CreateCommand();
            //cmd.CommandText = "Select carID FROM car where carName ='BMW 520d';";//" + carListCmbBx.SelectedText + "
            cmd.CommandText = "Select carID FROM car where carName ='" + carListCmbBx.SelectedItem.ToString() + "';";
            result = cmd.ExecuteReader();
            if (result.Read())
            {
                
                return result.GetInt32(0);

            }
            else
            {
                MessageBox.Show("Unsuccess carIDFinder");
                
                return 0;
            }
            
        }
        public int rowID()
        {
            ConnectToDatabase();
            OleDbDataReader result;
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select Count(*) FROM carBooking ;";
            result = cmd.ExecuteReader();
            if (result.Read())
            {
                Console.WriteLine("The resulting row is "+ result.GetInt32(0)+" plus one");
                
                return result.GetInt32(0) + 1;
                
            }
            else
            {
                MessageBox.Show("Unsuccess rowID");
               
                return 0;
            }
        }
        public int invoiceAm(DateTime start, DateTime end, int carID)
        {
            ConnectToDatabase();
            try
            {
                OleDbDataReader result;
                OleDbCommand cmd = conn.CreateCommand();
                Console.WriteLine("carID is " + carID);
                cmd.CommandText = "Select ratesPerDay FROM car where carID ="+carID+";";//
                result = cmd.ExecuteReader();
                result.Read();
                int invAm = result.GetInt32(0);
                int days = ((end.Date - start).Days);
                if (days<0)
                {
                    days = days * -1;
                }
                Console.WriteLine("Days " + (days+1));
                Console.WriteLine("Start " + start.Date.ToString().Substring(0, 10));
                Console.WriteLine("End " + end.Date.ToString().Substring(0, 10));
                Console.WriteLine("Invoice amount per day R" + invAm);
                Console.WriteLine("Invoice amount R" + (invAm * (days + 1)));
                conn.Close();
                return invAm * (days+1);
              

            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Unsuccess invoiceAm " + ex);
                return 0;
            }

        }

        private void bookCarBtn_Click(object sender, EventArgs e)
        {
            if (carListCmbBx.SelectedItem != null)
            {
                int carID;
                int bookingID;
                ConnectToDatabase();
                OleDbDataReader result;
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Select * FROM Customers where bankAccountNumber ='" + bankAccTxtBx.Text + "' and userName = '" + userTxtBx.Text + "';";
                result = cmd.ExecuteReader();
                conn.Close();
                if (result != null)
                {
                    ConnectToDatabase();
                    cmd = conn.CreateCommand();
                    carID = CarIDFinder(carListCmbBx.SelectedText);
                    bookingID = rowID();

                    //values for attributes of Bookings instance
                    amountInv = invoiceAm(endDatePicker.Value, startDatePicker.Value, carID).ToString();
                    user = userTxtBx.Text;
                    car = carListCmbBx.SelectedItem.ToString();
                    startLease = startDatePicker.Value.ToString();
                    endLease = endDatePicker.Value.ToString();

                    cmd.CommandText = "INSERT INTO carBooking Values(" + bookingID + ", '" + DateTime.Today + "' , '" +
                    "R" + invoiceAm(endDatePicker.Value, startDatePicker.Value, carID) + "','" + startDatePicker.Value.ToString().Substring(0, 10) + "','" +
                    endDatePicker.Value.ToString().Substring(0, 10) + "' ," + carID + " , '" + userTxtBx.Text + "');";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully booked car");
                    conn.Close();
                    this.InvoiceBtn.Enabled = true;
                    this.bookCarBtn.Enabled = false;
                    this.startDatePicker.Enabled = false;
                    this.endDatePicker.Enabled = false;
                    this.carListCmbBx.Enabled = false;
                    this.userTxtBx.Enabled = false;
                    this.bankAccTxtBx.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Incorrect Bank Account number and/or username");
                }
            }
            else
            {
                MessageBox.Show("Choose a car");//Need to make more sophisticated
            }
        }
        private void Booking_FormClosed(object sender, FormClosedEventArgs e)//closes the application if the X button is clicked
        {
            
          //  Application.Exit();

        }

        private void InvoiceBtn_Click(object sender, EventArgs e)
        {  
            new Invoice().Show();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
            
        }

        private void carListCmbBx_SelectedIndexChanged(object sender, EventArgs e)
        {
           string carSelected = carListCmbBx.SelectedItem.ToString();
            
            ConnectToDatabase();
            OleDbDataReader myReader;
            OleDbCommand cmd = conn.CreateCommand();
            string carImage = "";

            cmd.CommandText = "Select * FROM car " +
                "WHERE carName='"+carSelected+"';";
            myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                label10.Text = (myReader["carType"].ToString());
                label11.Text = (myReader["ratesPerDay"].ToString());

                carImage = (myReader["Image"].ToString());
                this.pictureBox1.Image = Image.FromFile(Application.StartupPath + " \\Resources\\" + carImage + "");//Need to make it match car
                
            }
            conn.Close();
        }

        private void Booking_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            

        }
    }
}
