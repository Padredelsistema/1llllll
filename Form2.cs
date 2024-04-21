using System;
using iTextSharp.text.html.simpleparser;
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
using iTextSharp.text.pdf;

namespace _1llllll
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = ("");
            textBox2.Text = ("");
            textBox3.Text = ("");
            textBox4.Text = ("");
            
        }

        private void button2_Click(object sender, EventArgs e)
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
    <title>Reporte de Asistencia</title>
</head>
<body>
    <h1>Reporte de sipnos vitales</h1>

    <table>
        <tr>
            <th>Nombre del paciente</th>
            <th>nombre</th>
        </tr>
        <tr>
            <th>Unico tratamiento</th>
            <th>puesto</th>
        </tr>
        <tr> 
            <th>Edad del paciente</th>
            <th>Día</th>
        </tr>
        <tr>
            <th></th>
            <th></th>
        </tr>
    </table>
</body>
</html>";

                    // Reemplazar las variables en el HTML con los valores de los TextBox
                    html = html.Replace("nombre", textBox1.Text);
                    html = html.Replace("Dia", textBox2.Text);
                    html = html.Replace("puesto", textBox3.Text);

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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

