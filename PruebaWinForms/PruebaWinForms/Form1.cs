using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int valor1;
            int valor2;
            int resultado;

            if (int.TryParse(textBox1.Text, out valor1) & int.TryParse(textBox2.Text, out valor2))
            {
                resultado = valor1 + valor2;
                label4.Text = resultado.ToString();
            }
            else
            {
                label4.Text = "Parece que no has metido 2 números...";
            }
        }   
    }
}
