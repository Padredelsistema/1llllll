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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            StringBuilder mensaje = new StringBuilder();

            // Obtener información del paciente
            string nombre = textBox1.Text;
            string edad = textBox2.Text;
            string estadoCivil = checkBox4.Checked ? "casado" : "soltero";

            mensaje.AppendLine($"Nombre del paciente: {nombre}");
            mensaje.AppendLine($"Edad: {edad}");
            mensaje.AppendLine($"Estado civil: {estadoCivil}");

            // Obtener medicamentos según los signos vitales seleccionados
            if (checkBox1.Checked)
            {
                mensaje.AppendLine("\n.Signos vitales bien:");
                mensaje.AppendLine("Frecuencia Cardíaca:");
                mensaje.AppendLine("No se requiere medicación en condiciones normales.");
                mensaje.AppendLine("Presión Arterial:");
                mensaje.AppendLine("No se requiere medicación en condiciones normales.");
                mensaje.AppendLine("Temperatura Corporal:");
                mensaje.AppendLine("No se requiere medicación en condiciones normales.");
            }

            if (checkBox2.Checked)
            {
                mensaje.AppendLine("\n.Signos vitales medios:");
                mensaje.AppendLine("Frecuencia Cardíaca:");
                mensaje.AppendLine("Beta-bloqueantes (como metoprolol),");
                mensaje.AppendLine("Antiarrítmicos (como amiodarona)");
                mensaje.AppendLine("Presión Arterial:");
                mensaje.AppendLine("Mismos medicamentos que en hipertensión leve, pero en dosis más altas o combinaciones de ellos.");
                mensaje.AppendLine("Temperatura Corporal:");
                mensaje.AppendLine("No se requieren medicamentos específicos en esta categoría.");
            }

            if (checkBox3.Checked)
            {
                mensaje.AppendLine("\n.Signos vitales graves:");
                mensaje.AppendLine("Frecuencia Cardíaca:");
                mensaje.AppendLine("Lidocaína");
                mensaje.AppendLine("Amiodarona");
                mensaje.AppendLine("Presión Arterial:");
                mensaje.AppendLine("Nitroprusiato de sodio");
                mensaje.AppendLine("Labetalol");
                mensaje.AppendLine("Temperatura Corporal:");
                mensaje.AppendLine("Paracetamol (acetaminofén) intravenoso");
                mensaje.AppendLine("Antiinflamatorios no esteroides (AINEs) intravenosos");
            }

            // Mostrar la información en richTextBox1
            richTextBox1.Text = mensaje.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Código que se ejecuta cuando el texto en textBox2 cambia
            // Puedes agregar lógica adicional aquí si es necesario
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            textBox1.Text = ("");
            textBox2.Text = ("");
            textBox3.Text = ("");
            checkBox4.Text = ("");
            checkBox3.Text = ("");
            checkBox2.Text = ("");
            checkBox1.Text = ("");



        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
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
    <title>signos vitales</title>
</head>
<body>
    <h1>REPORTES DE SIGNOS VITALES</h1>

    <table>
        <tr>
            <th>Datos</th>
            <th>1</th>
        </tr>
        <tr>
            <th>Horarios las cuales se tiene que tomar</th>
            <th>2</th>
        </tr>
    </table>
</body>
</html>";

                    // Reemplazar las variables en el HTML con los valores de los TextBox y el Label
                    html = html.Replace("1", richTextBox1.Text);
                    html = html.Replace("2", textBox3.Text); // Reemplazar por el texto del textBox3

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