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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.Show();
            // When the button is clicked it shows the user cadastration option.
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
            // Clean the name and password fields.
        }
        private string Local()
        {
            return ConfigurationManager.AppSettings["Database"];
            // Local where the confirmation of the data will be.
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
            // Hide and Show the password.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string data = File.ReadAllText(Local());
            if (data.IndexOf(textBox1.Text) > -1 && data.IndexOf(textBox2.Text) > -1)
            {
                MessageBox.Show("You are logged!");
                var form1 = new Form3();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Error! Diferent Data from the registration.");
                textBox1.Clear();
                textBox2.Clear();
            }
            // Verify if the data are right with user name and password.
        }
    }
}
