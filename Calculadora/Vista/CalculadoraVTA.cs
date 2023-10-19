using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Calculadora.Controlador;
using Calculadora.Modelo;
using MySql.Data.MySqlClient;

namespace Calculadora
{
    public partial class CalculadoraVTA : Form
    {
        private readonly CalculadoraController controller;
        public CalculadoraVTA()
        {
            controller = new CalculadoraController();
            InitializeComponent();
        }
        private double numero1=0;
        private double numero2 =0;
        private char operador;

        MySqlConnection conn = new MySqlConnection("" +
            "server=localhost;user id=root;password=;" +
            "database=dbcalculadora;sslMode=none");

        MySqlCommand cmd;
        MySqlDataAdapter da;
        DataTable dt;
        string sql;


        private void loalData()
        {
            try
            {

                sql = "Select id, numero1, operador, numero2, Resultado" +
                    "from resultados";
                conn.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                dgvResultados.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { 
                conn.Close();
                da.Dispose();
            }
        }

        private void guardadDatos()
        {
            try
            {
                sql = "Inset into resultados(numero1, operador, numero2, Resultado)" +
                    "values('"+numero1+"','"+operador+"','"+numero2+"','" + txtResultado.Text+"')";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void agregarNumero(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            if (txtResultado.Text == "0")
            
                txtResultado.Text = "";
                txtResultado.Text += boton.Text;
        }
        private void Calculadora_Load(object sender, EventArgs e)
        {

        }
        private void clickoperador(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            numero1 = Convert.ToDouble(txtResultado.Text);
            operador = Convert.ToChar(boton.Tag);
            txtResultado.Text = controller.OperarNumero1(numero1, operador);
        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            numero2 = Convert.ToDouble(txtResultado.Text);
            string resultado = controller.RealizarOperacion(numero1, numero2, operador);
            if (resultado == "No se puede dividir por cero")
            {
                MessageBox.Show(resultado);
            }
            else
            {
                txtResultado.Text = resultado;
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if(txtResultado.Text.Length > 1)
            {
             txtResultado.Text = txtResultado.Text.Substring(0, txtResultado.Text.Length - 1);
            }
            else
            {
                txtResultado.Text = "0";
            }
        }

        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            numero1 = 0; 
            numero2= 0;
            operador = '/';
            txtResultado.Text = "0";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
        }

        private void btnComa_Click(object sender, EventArgs e)
        {
            if(!txtResultado.Text.Contains("."))
            {
                txtResultado.Text += ".";
            }
        }

        private void btnSigno_Click(object sender, EventArgs e)
        {
            numero1 = Convert.ToDouble(txtResultado.Text);
            numero1 *= -1;
            txtResultado.Text = numero1.ToString();
        }

        
    }
}
