using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMNOSSD_Final
{
    public partial class CustomerManagement : Form
    {
        public CustomerManagement()
        {
            InitializeComponent();
            editbtn.Enabled = false;
            deletebtn.Enabled = false;
            passTxtBx.Enabled = false;
            firstNameTxtBx.Enabled = false;
            lastNameTxtBx.Enabled = false;
            cellNoTxtBx.Enabled = false;//identifier

        }
        OleDbConnection conn;
        public void ConnectToDatabase()
        {
            var DBPath = Application.StartupPath + "\\carRentalDB.accdb";
            conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + DBPath);
            conn.Open();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            DialogResult delete = MessageBox.Show("Are you sure you want to delete the user", "Confirmation", MessageBoxButtons.YesNo);
            if (delete == DialogResult.Yes)
            {
        
         ConnectToDatabase();

                OleDbCommand cmd = conn.CreateCommand();
                //DELETE FROM tableName WHERE columnName IN('val1', 'val2', 'val3');
                cmd.CommandText = "DELETE FROM Customers WHERE Username= @Username";
              
                // cmd.CommandText = @"UPDATE Customers SET([Username],[Password],[firstName],[lastName],[cellNumber],[bankAccountNumber])" + "Values (@Username,@Password,@firstN,@lastN,@cell,@bank)";
                cmd.Parameters.AddWithValue("@Username", userTxtBx.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deletion performed on the user " + userTxtBx.Text + " successfully", "Confirmation");
                Login login = new Login();
                login.Show();
                this.Hide();
                //Delete
            }
            else if (delete == DialogResult.No)
            {
                //Don't delete 
                MessageBox.Show("Deletion not performed ", "Confirmation");
            }
            conn.Close();

        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            ConnectToDatabase();
            OleDbDataReader myReader;
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = "Select * FROM Customers where bankAccountNumber ='" + bankAccNoTxtBx.Text + "' and Username = '" + userTxtBx.Text + "';";
            
            myReader = cmd.ExecuteReader();

              if (myReader.Read()== true)
              {
                myReader.Close();
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {

                    userTxtBx.Text = (myReader["Username"].ToString());
                    passTxtBx.Text = (myReader["Password"].ToString());
                    firstNameTxtBx.Text = (myReader["firstName"].ToString());
                    lastNameTxtBx.Text = (myReader["lastName"].ToString());
                    cellNoTxtBx.Text = (myReader["cellNumber"].ToString());
                    bankAccNoTxtBx.Text = (myReader["bankAccountNumber"].ToString());

                }

                //if records found enable 

                editbtn.Enabled = true;
                deletebtn.Enabled = true;
                passTxtBx.Enabled = true;
                firstNameTxtBx.Enabled = true;
                lastNameTxtBx.Enabled = true;
                cellNoTxtBx.Enabled = true;
                userTxtBx.Enabled = false;
                conn.Close();


            }
            else
            {
                MessageBox.Show("User not found, make sure the entered credentials are correct", "Error");
            }
            }
            
            
        

        private void editbtn_Click(object sender, EventArgs e)
        {
            DialogResult edit = MessageBox.Show("Are you sure you want to edit the userdetails", "Confirmation", MessageBoxButtons.YesNo);
            if (edit == DialogResult.Yes)
            {
                
                ConnectToDatabase();

                OleDbCommand cmd = conn.CreateCommand();

                cmd.CommandText = @"UPDATE Customers SET [Password] = @Password, firstName = @firstN, lastName = @lastN, cellNumber = @cell, bankAccountNumber = @bank Where Username = @Username ";
               // cmd.CommandText = @"UPDATE Customers SET([Username],[Password],[firstName],[lastName],[cellNumber],[bankAccountNumber])" + "Values (@Username,@Password,@firstN,@lastN,@cell,@bank)";
               
                cmd.Parameters.AddWithValue("@Password", passTxtBx.Text);
                cmd.Parameters.AddWithValue("@first", firstNameTxtBx.Text);
                cmd.Parameters.AddWithValue("@last", lastNameTxtBx.Text);
                cmd.Parameters.AddWithValue("@cell", cellNoTxtBx.Text);
                cmd.Parameters.AddWithValue("@bank", bankAccNoTxtBx.Text);
                cmd.Parameters.AddWithValue("@Username", userTxtBx.Text);
                cmd.ExecuteNonQuery();
               
                MessageBox.Show("Edit performed on the user "+userTxtBx.Text+" successfully", "Confirmation");
                conn.Close();
                
            }
            else if (edit == DialogResult.No)
            {
                //Don't edit 
                MessageBox.Show("No edit done", "Confirmation");
            }
           

        }

        private void CustomerManagement_FormClosing(object sender, FormClosingEventArgs e)
        {//need a better solution
            
            Login login = new Login();
            login.Show();
          
            
        }
    }
}

