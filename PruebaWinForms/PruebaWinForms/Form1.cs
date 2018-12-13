using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
// Para realizar consultas directas a la base de datos
using System.Data.SqlClient;
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

        // Conexión OLEDB
        // Provider=SQLOLEDB.1;User ID=<username>;Password=<strong password>;Initial Catalog=pubs;Data Source=(local)

        // Conexión SqlClient
        // User ID=<username>;Password=<strong password>;Initial Catalog=pubs;Data Source=(local)

        public string CadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MVCDemoDB;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Form1()
        {
            InitializeComponent();
        }


        private void Conectar()
        {
            SqlConnection conexion = new SqlConnection();

            conexion.ConnectionString = CadenaConexion;

            conexion.Open();

            MessageBox.Show("Me acabo de conectar...");

            string consulta = "select * from employee";
            consulta = "insert into Employee (id, EmployeeId, FirstName, LastName, EmailAdress) values (1, 1, \"1\",\"1\",\"1\")";
            consulta = "insert into Employee values (1, 1, \"1\",\"1\",\"1\")";
            consulta = "create table tabla1 (id integer)";
            /*
            consulta = "insert into tabla1 (id) values (@ident)";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@ident",SqlDbType.Int).Value=1000;

            try
            {
                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
            consulta = "select * from tabla1";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader lector;

            try
            {
                lector = comando.ExecuteReader();
                while(lector.Read())
                {
                    MessageBox.Show(lector.GetValue(0).ToString());
                }
                lector.Close();
                comando.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conexion.Close();

            MessageBox.Show("Acabo de desconectar.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            cargarArchivo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Conectar();
        }
    }
}
