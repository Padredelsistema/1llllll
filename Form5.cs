using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;


namespace _1llllll
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            // Este método se llama cada vez que el texto en textBox9 cambia
            // Puedes agregar código aquí para manejar el cambio de texto en textBox9
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            // Este método se llama cada vez que el texto en textBox9 cambia
            // Puedes agregar código aquí para manejar el cambio de texto en textBox9
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            // Este método se llama cada vez que el texto en textBox9 cambia
            // Puedes agregar código aquí para manejar el cambio de texto en textBox9
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // Este método se llama cada vez que el texto en textBox9 cambia
            // Puedes agregar código aquí para manejar el cambio de texto en textBox9
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // Este método se llama cada vez que el texto en textBox9 cambia
            // Puedes agregar código aquí para manejar el cambio de texto en textBox9
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Este método se llama cada vez que el texto en textBox9 cambia
            // Puedes agregar código aquí para manejar el cambio de texto en textBox9
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Este método se llama cada vez que el texto en textBox9 cambia
            // Puedes agregar código aquí para manejar el cambio de texto en textBox9
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Este método se llama cada vez que el texto en textBox9 cambia
            // Puedes agregar código aquí para manejar el cambio de texto en textBox9
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Este método se llama cada vez que el texto en textBox9 cambia
            // Puedes agregar código aquí para manejar el cambio de texto en textBox9
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Verificar si textBox1.Text es nulo o vacío
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Por favor, seleccione un empleado antes de generar el PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método para evitar más procesamiento
            }

            // Abrir el cuadro de diálogo para guardar el archivo
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivos PDF (*.pdf)|*.pdf";
            guardar.FileName = $"Reporte_{DateTime.Now.ToString("yyyyMMdd")}.pdf";

            // Verificar si el usuario hizo clic en el botón "Guardar"
            if (guardar.ShowDialog() == DialogResult.OK)
            {
                // Crear el documento PDF
                Document documento = new Document();

                try
                {
                    // Crear un escritor para escribir en el archivo PDF
                    PdfWriter.GetInstance(documento, new FileStream(guardar.FileName, FileMode.Create));

                    // Abrir el documento
                    documento.Open();

                    // Crear un objeto de estilo para el contenido del PDF
                    StyleSheet estilos = new StyleSheet();
                    estilos.LoadTagStyle("body", "font-family", "Arial, sans-serif");
                    estilos.LoadTagStyle("h1", "text-align", "center");
                    estilos.LoadTagStyle("h1", "color", "#007bff");
                    estilos.LoadTagStyle("label", "display", "block");
                    estilos.LoadTagStyle("label", "font-weight", "bold");

                    // Obtener el HTML desde un archivo o recursos
                    string html = @"
<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title></title>
</head>
<body>
    <h>REPORTE DE ASISTENCIA</h1>

    <table>
        <tr>
            <th>Nombre de la persona</th>
            <th>1</th>
        </tr>
        <tr>
            <th>Fecha</th>
            <th>2</th>
        </tr>
        <tr> 
            <th>Direccion</th>
            <th>3</th>
        </tr>
        <tr>
            <th>Cedula personal</th>
            <th>4</th>
        </tr>
        </tr>
            <th>Parententesco</th>
            <th>5</th>
        </tr>
        </tr>
            <th>Medico</th>
            <th>6</th>
        </tr>
        <tr>
            <th>Edad</th>
            <th>7</th>
        </tr>
        <tr>
            <th>Horarios de abierto</th>
            <th>8</th>

    </table>
</body>
</html>";

                    html = html.Replace("1", textBox1.Text);
                    html = html.Replace("2", textBox2.Text);
                    html = html.Replace("3", textBox3.Text);
                    html = html.Replace("4", textBox4.Text);
                    html = html.Replace("5", textBox5.Text);
                    html = html.Replace("6", textBox7.Text);
                    html = html.Replace("7", textBox8.Text);
                    html = html.Replace("8", textBox7.Text);

                    // Convertir el HTML a elementos PDF y agregarlos al documento
                    List<IElement> elementos = iTextSharp.text.html.simpleparser.HTMLWorker.ParseToList(new StringReader(html), estilos);
                    foreach (IElement elemento in elementos)
                    {
                        documento.Add(elemento);
                    }

                    // Cerrar el documento
                    documento.Close();

                    // Mostrar un mensaje de éxito
                    MessageBox.Show("PDF guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que pueda ocurrir durante la generación del PDF
                    MessageBox.Show("Error al guardar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
