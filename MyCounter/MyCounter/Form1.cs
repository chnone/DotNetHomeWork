﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num3 = 0;
            double num1 = double.Parse(textBox1.Text);
            double num2 = double.Parse(textBox2.Text);
            if (comboBox1.Text == "+")
            {
                num3 = num1 + num2;
                textBox3.Text = num3.ToString();
            }
            else if (comboBox1.Text == "-")
            {
                num3 = num1 - num2;
                textBox3.Text = num3.ToString();
            }
            else if (comboBox1.Text == "*")
            {
                num3 = num1 * num2;
                textBox3.Text = num3.ToString();
            }
            else
            {
                num3 = num1 / num2;
                textBox3.Text = num3.ToString();
            }

        }
    }
}
