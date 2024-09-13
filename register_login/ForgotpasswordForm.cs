using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace coursework
{
    public partial class ForgotpasswordForm : Form
    {
        public int RandomNumber { get; private set; }

        public ForgotpasswordForm()
        {
            InitializeComponent();
            GenerateRandomNumber();
        }
        private void GenerateRandomNumber()
        {
            Random random = new Random();
            RandomNumber = random.Next(1000, 9999); // Generates a number between 1 and 100
            /*lblRandomNumber.Text = RandomNumber.ToString()*/; // For debugging purposes
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        static private void send_email(string email, int random_num)
        {

            var fromAddress = new MailAddress("trunghack999@gmail.com", "From System Management");
            var toAddress = new MailAddress(email, "To Name");
            const string fromPassword = "qdch rbza dwzy ottt";
            const string subject = "Here is your OTP";
             string body = random_num.ToString();

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

        }


        private void btn_send_Click(object sender, EventArgs e)
        {
            send_email(tb_email.Text, RandomNumber);
            OTPForm otp = new OTPForm(RandomNumber, tb_email.Text);
            otp.Show();
            this.Hide();


        }

        private void lb_signin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
