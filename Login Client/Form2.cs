using Registration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_Client
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private string Local()
        {
            return ConfigurationManager.AppSettings["Database"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = new User().Read();

            var user2 = new User();
            user2.Name = textBox1.Text;
            user2.Password = textBox2.Text;
            // It's defining the name and the password in 1 and 2 fields.
            string content = File.ReadAllText(Local());
            if (content.IndexOf(textBox1.Text) > -1 && content.IndexOf(textBox2.Text) > -1)
            {
                MessageBox.Show("Error! User already exists.");
            }
            else
            {
                user2.Record();
                MessageBox.Show("User registered.");
                this.Close();
            }
            // Verify if the user already exists.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Generator.Passwords();
            // Generate a random password.
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
            // Show or hide the password.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            // Close the application.
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            // Clear the fields of the name and the passwor.
        }
    }
}
