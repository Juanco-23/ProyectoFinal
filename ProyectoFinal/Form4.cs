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
	public partial class Form4 : Form
	{
        SqlConnection conexion = new SqlConnection("server=DESKTOP-TUJS2GR; database=proyectoVSE; integrated security= true");
        public Form4()
		{
			InitializeComponent();
		}

		private void button6_Click(object sender, EventArgs e)
		{
            
            conexion.Open();
            string ced = textBox12.Text;
            string cadena = "select cedula,nombre,apellido,edad,altura,peso,no_Celular,correo,tipo_Sangre  from personaDat where cedula= " + ced;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            if (registros.Read())
            {
                label20.Text = registros["cedula"].ToString();
                label21.Text = registros["nombre"].ToString();
                label22.Text = registros["apellido"].ToString();
                label23.Text = registros["edad"].ToString();
                label24.Text = registros["altura"].ToString();
                label25.Text = registros["peso"].ToString();
                label26.Text = registros["no_Celular"].ToString();
                label27.Text = registros["correo"].ToString();
                label28.Text = registros["tipo_Sangre"].ToString();

                button7.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se encontro el registro con la cedula: " + ced);
            }
            conexion.Close();
        }

		private void button7_Click(object sender, EventArgs e)
		{
            
            conexion.Open();
            string ced = textBox12.Text;
            string cadena = "delete from personaDat where cedula= " + ced;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant == 1)
            {

                label20.Text = "";
                label21.Text = "";
                label22.Text = "";
                label23.Text = "";
                label24.Text = "";
                label25.Text = "";
                label26.Text = "";
                label27.Text = "";
                label28.Text = "";
                MessageBox.Show("Los datos se han eliminado");

            }
            else
            {
                MessageBox.Show("No se encontro el registro con la cedula: " + ced);
            }
            conexion.Close();

            button7.Enabled = true;
        }

		private void button2_Click(object sender, EventArgs e)
		{
            this.Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
	}
}
