using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _1llllll
{
    public partial class Form1 : Form
    {
        // Credenciales
        private static readonly Tuple<string, string>[] Credenciales = {
            Tuple.Create("Gerente", "bryan"),
            Tuple.Create("Enfermero", "josue"),
            Tuple.Create("Contador", "jesus"),
            Tuple.Create("Recepcion", "diego"),
            Tuple.Create("Medico", "lalo"),
            


        };

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Obtiene los valores de los cuadros de texto
            string usuario = textBox1.Text;
            string contrasena = textBox2.Text;

            // Verifica las credenciales
            foreach (var credencial in Credenciales)
            {
                if (usuario == credencial.Item1 && contrasena == credencial.Item2)
                {
                    // Si las credenciales son correctas, muestra mensaje de bienvenida
                    MessageBox.Show("¡Bienvenido, " + usuario + "!", "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abre el Form correspondiente
                    switch (usuario)
                    {
                        case "gerente":
                            Form52 form52 = new Form52(); // Instantiate Form8
                            form52.Show(); // Show Form8
                            break;
                        case "enfermero":
                            Form3 form3 = new Form3();
                            form3.Show();
                            break;
                        case "contador":
                            Form4 form4 = new Form4();
                            form4.Show();
                            break;
                        case "recepcion":
                            Form5 form5 = new Form5();
                            form5.Show();
                            break;
                        case "medico":
                            Form2 form2 = new Form2();
                            form2.Show();
                            break;

                    }

                    return; // Sale del método después de encontrar las credenciales correctas
                }
            }

            // Si las credenciales son incorrectas, muestra mensaje de error
            MessageBox.Show("Usuario o contraseña incorrectos", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Limpia los cuadros de texto
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            // y así sucesivamente

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

