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
using MySql.Data.MySqlClient;

namespace Calculadora
{
    public partial class Calculadora : Form
    {
        double Numero1=0;
        double Numero2=0;
        char Operador;

        public Calculadora()
        {
            InitializeComponent();
        }
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

                sql = "Select id, Numero1, Operador, Numero2, Resultado" +
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
                sql = "Inset into resultados(Numero1, Operador, Numero2, Resultado)" +
                    "values('"+Numero1+"','"+Operador+"','"+Numero2+"','" + txtResultado.Text+"')";
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
        private void clickOperador(object sender, EventArgs e)
        {
            var boton = ((Button)sender);
            Numero1 = Convert.ToDouble(txtResultado.Text);
            Operador = Convert.ToChar(boton.Tag);
            if (Operador == '²')
            {
                
                  Numero1 = Math.Pow(Numero1, 2);
                  txtResultado.Text = Numero1.ToString();
            }
            else if (Operador == '√')
            {
                Numero1 = Math.Sqrt(Numero1);
                txtResultado.Text = Numero1.ToString();
            }
            else if (Operador == 's')
            {
                Numero1 = Math.Sin(Numero1 * Math.PI / 180);
                txtResultado.Text = Numero1.ToString();
            }
            else if (Operador == 'c')
            {
                 Numero1 = Math.Cos(Numero1*Math.PI/180);
                txtResultado.Text = Numero1.ToString();
            }


            else
            {
                txtResultado.Text = "0";
            }
           

        }

        private void btnResultado_Click(object sender, EventArgs e)
        {
            Numero2 = Convert.ToDouble(txtResultado.Text);

            if (Operador == '+')
            {
                txtResultado.Text = (Numero1 + Numero2).ToString();
                Numero1 = Convert.ToDouble(txtResultado.Text);

            }
            else if(Operador== '-')
            {
                txtResultado.Text = (Numero1 - Numero2).ToString();
                Numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (Operador == 'x')
            {
                txtResultado.Text = (Numero1 * Numero2).ToString();
                Numero1 = Convert.ToDouble(txtResultado.Text);
            }
            else if (Operador == '/')
            {
                if(Numero2 != 0)
                {
                txtResultado.Text = (Numero1 / Numero2).ToString();
                Numero1 = Convert.ToDouble(txtResultado.Text);
                }
                else
                {
                    MessageBox.Show("No se puede dicidir por cero");
                }
               
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
            Numero1 = 0; 
            Numero2= 0;
            Operador = '/';
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
            Numero1 = Convert.ToDouble(txtResultado.Text);
            Numero1 *= -1;
            txtResultado.Text = Numero1.ToString();
        }

        
    }
}
