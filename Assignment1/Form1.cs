using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "+")
            {
                textBox4.Text = (double.Parse(textBox1.Text) + double.Parse(textBox3.Text)).ToString();
            }
            if (textBox2.Text == "-")
            {
                textBox4.Text = (double.Parse(textBox1.Text) - double.Parse(textBox3.Text)).ToString();
            }
            if (textBox2.Text == "*")
            {
                textBox4.Text = (double.Parse(textBox1.Text) * double.Parse(textBox3.Text)).ToString();
            }
            if (textBox2.Text == "/")
            {
                textBox4.Text = (double.Parse(textBox1.Text) / double.Parse(textBox3.Text)).ToString();
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null; textBox2.Text = null; textBox3.Text =null; textBox4.Text =null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
