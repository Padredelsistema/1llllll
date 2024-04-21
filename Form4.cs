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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace _1llllll
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los campos de entrada
            string nombre = textBox1.Text;
            decimal monto = 0;
            if (!decimal.TryParse(textBox2.Text, out monto))
            {
                MessageBox.Show("El monto debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tipoTransaccion = textBox3.Text;

            // Validar que se hayan completado todos los campos
            if (string.IsNullOrWhiteSpace(nombre) || monto <= 0 || string.IsNullOrWhiteSpace(tipoTransaccion))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Agregar una nueva fila al DataGridView
            dataGridView1.Rows.Add(nombre, monto, tipoTransaccion);

            // Limpiar los campos de entrada después de agregar la fila
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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
    <h1>REGISTRO DE TRASACCION</h1>

    <table>
        <tr>
            <th>Nombre del paciente a ingresar</th>
            <th>1</th>
        </tr>
        <tr>
            <th>Monto el que se tiene que ingresar</th>
            <th>2</th>
        </tr>
        <tr> 
            <th>Trasaccion que se tiene ingresar</th>
            <th>3</th>
    </table>
</body>
</html>";

                    html = html.Replace("1", textBox1.Text);
                    html = html.Replace("2", textBox2.Text);
                    html = html.Replace("3", textBox3.Text);
                   

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

    

