using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PruebaWinForms
{
    public partial class Form1 : Form
    {
        public string ARCHIVO = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            cargarArchivo();
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
        public void LeerArchivo(DataGridView tabla, char caracter, string ruta)
        {
            StreamReader objReader = new StreamReader(ruta);
            string sLine = "";
            int fila = 0;

            tabla.Rows.Clear();
            tabla.AllowUserToAddRows = false;

            do
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    if (fila == 0)
                    {
                        tabla.ColumnCount = sLine.Split(caracter).Length;
                        nombrarTitulos(tabla, sLine.Split(caracter));
                        fila += 1;
                    }
                    else
                    {
                        agregarFila(tabla, sLine, caracter, fila);
                        fila += 1;
                    }
                }
            } while (!(sLine == null));
            objReader.Close();
        }

        public static void nombrarTitulos(DataGridView tabla, string[] titulos)
        {
            int x = 0;
            for (x = 0; x < tabla.ColumnCount; x++)
            {
                tabla.Columns[x].HeaderText = titulos[x];
            }
        }

        public static void agregarFila(DataGridView tabla, string linea, char caracter, int fila)
        {
            string[] arreglo = linea.Split(caracter);
            tabla.Rows.Add(arreglo);
        }

        public void cargarArchivo()
        {
            try
            {
                this.openFileDialog1.ShowDialog();
                if(!string.IsNullOrEmpty(this.openFileDialog1.FileName))
                {
                    ARCHIVO = this.openFileDialog1.FileName;
                    LeerArchivo(dataGridView1, ',', ARCHIVO);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
