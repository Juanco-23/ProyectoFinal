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
	public partial class Form1 : Form

 {   
        
   
	
		public Form1()
	{
		InitializeComponent();	
	}

	private void Form1_Load(object sender, EventArgs e)
		{

		}

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=DESKTOP-TUJS2GR; database=proyectoVSE; integrated security= true");
            conexion.Open();
            MessageBox.Show("Se abrio la conexion con el servidor SQL Server y se seleccione la BD");
            String cedula = textBox1.Text;
            String nombre = textBox2.Text;
            String apellido = textBox3.Text;
            int edad = Convert.ToInt32(textBox4.Text);
            decimal altura = Convert.ToInt32(textBox5.Text);
            decimal peso = Convert.ToInt32(textBox6.Text);
            String no_Celular = textBox7.Text;
            String correo = textBox8.Text;
            String tipo_Sangre = textBox9.Text;

            string cadena = "insert into personaDat(cedula,nombre,apellido,edad,altura,peso,no_Celular,correo,tipo_Sangre ) values ('" + cedula + "," + nombre + "," + apellido + "," + edad + "," + altura + "," + peso + "," + no_Celular + "," + correo + "," + tipo_Sangre + ")";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            comando.ExecuteNonQuery();
            MessageBox.Show("Los datos se guardaron correctamente");
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox8.Text = " ";
            textBox7.Text = " ";
            textBox9.Text = " ";

            conexion.Close();
        }

		private void button2_Click(object sender, EventArgs e)
		{
            SqlConnection conexion = new SqlConnection("server=DESKTOP-TUJS2GR; database=proyectoVSE; integrated security= true");
            conexion.Open();
            string cadena = "select cedula,nombre,apellido,edad,altura,peso,no_Celular,correo,tipo_Sangre  from personaDat";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();

            while (registros.Read())
            {
                textBox10.AppendText(registros["cedula"].ToString());
                textBox1.AppendText(" - ");
                textBox10.AppendText(registros["nombre"].ToString());
                textBox1.AppendText(" - ");
                textBox10.AppendText(registros["apellido "].ToString());
                textBox1.AppendText(" - ");
                textBox10.AppendText(registros["edad"].ToString());
                textBox1.AppendText(" - ");
                textBox10.AppendText(registros["altura"].ToString());
                textBox1.AppendText(" - ");
                textBox10.AppendText(registros["peso"].ToString());
                textBox1.AppendText(" - ");
                textBox10.AppendText(registros["no_Celular"].ToString());
                textBox1.AppendText(" - ");
                textBox10.AppendText(registros["correo"].ToString());
                textBox1.AppendText(" - ");
                textBox10.AppendText(registros["tipo_Sangre "].ToString());
                textBox1.AppendText(" - ");

                textBox1.AppendText(Environment.NewLine);

            }
            conexion.Close();

           
		}

		private void button3_Click(object sender, EventArgs e)
		{
            Form2 f2= new Form2();
            f2.ShowDialog();
		}
	}

	/*private void button2_Click(object sender, EventArgs e)
    {
        
    }*/

  
}
