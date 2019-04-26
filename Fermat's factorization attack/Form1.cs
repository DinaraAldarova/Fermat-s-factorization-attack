using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Fermat_s_factorization_attack
{
    public partial class Form1 : Form
    {
        Culculate culc;
        public Form1()
        {
            InitializeComponent();
            culc = new Culculate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            culc.NewFact(textBox1.Text);
            richTextBox1.Text = culc.report;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!(Char.IsDigit(number) || number == 8)) // only digit or backspace
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BigInteger m1 = BigInteger.Parse(textBox2.Text);
            BigInteger m2 = BigInteger.Parse(textBox3.Text);
            BigInteger N = BigInteger.Multiply(m1, m2);
            textBox1.Text = N.ToString();
        }
    }
}
