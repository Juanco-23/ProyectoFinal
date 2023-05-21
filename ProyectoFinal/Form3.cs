using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace ProyectoFinal
{
	public partial class Form3 : Form
	{

        SqlConnection conexion = new SqlConnection("server=DESKTOP-TUJS2GR; database=proyectoVSE; integrated security= true");
        public Form3()
		{
			InitializeComponent();
		}

		private void button3_Click(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{
            
            conexion.Open();
            string ced = textBox12.Text;
            string cadena = "select cedula,nombre,apellido,edad,altura,peso,no_Celular,correo,tipo_Sangre  from personaDat where cedula= " + ced;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            if (registros.Read())
            {
                textBox10.Text = registros["cedula"].ToString();
                textBox1.Text = registros["nombre"].ToString();
                textBox2.Text = registros["apellido"].ToString();
                textBox3.Text = registros["edad"].ToString();
                textBox4.Text = registros["altura"].ToString();
                textBox5.Text = registros["peso"].ToString();
                textBox6.Text = registros["no_Celular"].ToString();
                textBox7.Text = registros["correo"].ToString();
                textBox9.Text = registros["tipo_Sangre"].ToString();

                button5.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se encontro el registro con la cedula: " + ced);
            }
            conexion.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            conexion.Open();
            string ced = textBox12.Text;
            string nombre = textBox2.Text;
            string apellido = textBox3.Text;
            string edad = textBox3.Text;
            string cadena = "update personaDat set nombre= '" + nombre + "',apellido=" + apellido + " ',edad=" + edad + "where cedula=" + ced;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant == 1)
            {
                MessageBox.Show("Ya se modificaron los datos del usuario");
                textBox10.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
            }
			else 

                MessageBox.Show("No existe el usuario ingresado");
        
                conexion.Close();

                button5.Enabled = false;
            
        }

		private void button1_Click(object sender, EventArgs e)
		{
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

		private void button2_Click(object sender, EventArgs e)
		{
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

		private void textBox9_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
