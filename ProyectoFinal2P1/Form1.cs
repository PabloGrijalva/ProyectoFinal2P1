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
using Newtonsoft.Json;
using System.Net.Http;
using Xceed.Words.NET;

namespace ProyectoFinal2P1

{

    public partial class Form1 : Form
    {
        private string connectionString = "Server=LAPTOP-UN8C66F6\\SQLEXPRESS;Database=InvestigacionesDB;Trusted_Connection=True;"; // Cambia esto

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtPregunta_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnInvestigar_Click(object sender, EventArgs e)
        {
            string pregunta = txtPregunta.Text.Trim();
            if (string.IsNullOrEmpty(pregunta))
            {
                MessageBox.Show("Por favor ingresa una pregunta o tema.");
                return;
            }

            string respuesta = await ConsultarOpenAI(pregunta);
            if (respuesta != null)
            {
                txtRespuesta.Text = respuesta;
                GuardarEnBaseDeDatos(pregunta, respuesta);
            }
            else
            {
                MessageBox.Show("Error al consultar la IA.");
            }
        }
        private async Task<string> ConsultarOpenAI(string pregunta)
        {
            string apiKey = "PEGAR API KEY";
            string endpoint = "https://api.openai.com/v1/chat/completions";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var payload = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = pregunta }
                }
            };
            string jsonPayload = JsonConvert.SerializeObject(payload);

            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync(endpoint, content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    dynamic json = JsonConvert.DeserializeObject(result);
                    string respuesta = json.choices[0].message.content.ToString();
                    return respuesta.Trim();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        private void GuardarEnBaseDeDatos(string pregunta, string respuesta)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Investigaciones (Pregunta, Respuesta, Fecha) VALUES (@pregunta, @respuesta, @fecha)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pregunta", pregunta);
                cmd.Parameters.AddWithValue("@respuesta", respuesta);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Now);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar en la base de datos: " + ex.Message);
                }
            }
        }
        private void CargarHistorial()
        {
            using (SqlConnection conn = new SqlConnection("Server=LAPTOP-UN8C66F6\\SQLEXPRESS;Database=InvestigacionesDB;Trusted_Connection=True;")) // Cambia esto por tu cadena de conexión real
            {
                string query = "SELECT Id, Pregunta, Respuesta, Fecha FROM Investigaciones ORDER BY Fecha DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    da.Fill(dt);
                    dgvHistorial.DataSource = dt;
                    dgvHistorial.AutoResizeColumns();
                    dgvHistorial.ReadOnly = true; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el historial: " + ex.Message);
                }
            }
        }
        private void txtRespuesta_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCargarHistorial_Click(object sender, EventArgs e)
        {
            dgvHistorial.Visible = true;
            CargarHistorial();
        }
        private void ExportarHistorialAWord()
        {
            if (dgvHistorial.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Documento Word|*.docx";
            saveFileDialog.Title = "Guardar historial como Word";
            saveFileDialog.FileName = "HistorialInvestigaciones.docx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                using (var doc = DocX.Create(path))
                {
                    doc.InsertParagraph("Historial de Investigaciones")
                        .FontSize(18)
                        .Bold()
                        .SpacingAfter(20);

                    foreach (DataGridViewRow row in dgvHistorial.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string pregunta = row.Cells["Pregunta"].Value?.ToString();
                        string respuesta = row.Cells["Respuesta"].Value?.ToString();
                        string fecha = row.Cells["Fecha"].Value?.ToString();

                        doc.InsertParagraph($"Pregunta: {pregunta}")
                            .FontSize(12)
                            .Bold();
                        doc.InsertParagraph($"Respuesta: {respuesta}")
                            .FontSize(12)
                            .SpacingAfter(5);
                        doc.InsertParagraph($"Fecha: {fecha}")
                            .FontSize(10)
                            .Italic()
                            .SpacingAfter(15);
                        doc.InsertParagraph("-------------------------------------");
                    }

                    doc.Save();
                    MessageBox.Show("Historial exportado correctamente a Word.");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ExportarHistorialAWord();
        }
    }
}
