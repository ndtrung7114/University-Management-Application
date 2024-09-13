using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework
{
    public partial class OTPForm : Form
    {
        private int randomnumber;
        string email;
        public OTPForm(int randomnumber, string email)
        {
            InitializeComponent();
            this.randomnumber = randomnumber;
            this.email = email;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_verify_Click(object sender, EventArgs e)
        {
            string userInput = tb_1.Text + tb_2.Text + tb_3.Text + tb_4.Text ;
            if (userInput.Length == 4 && int.TryParse(userInput, out int userNumber))
            {
                if (userNumber == randomnumber)
                {
                    ResetPasswordForm reset = new ResetPasswordForm(email);
                    reset.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error: " + "Incorrect, try again.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error: " + "Please enter 4-digit number.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        

        }
    }
}
