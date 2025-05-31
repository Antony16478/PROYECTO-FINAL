using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace PlanificadorNutricionalIA
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGenerar_Click(object sender, EventArgs e)
        {
            string entradaUsuario = txtEntrada.Text.Trim();

            if (string.IsNullOrWhiteSpace(entradaUsuario))
            {
                MessageBox.Show("Por favor, escribe tus datos antes de generar el plan.");
                return;
            }

            string respuestaIA = await ConsultarIA(entradaUsuario);

            listBoxResultado.Items.Clear();
            string[] lineas = respuestaIA.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string linea in lineas)
            {
                listBoxResultado.Items.Add(linea.Trim());
            }

            // Guardar en base de datos
            GuardarEnBD(entradaUsuario, respuestaIA);
        }

        private async Task<string> ConsultarIA(string entrada)
        {
            string prompt = $"Basado en esta información: {entrada}, genera una respuesta del tipo:\n\n" +
                            "Hola [Nombre], lo más indicado para ti sería:\n\n" +
                            "- Menú sugerido para el día\n- Consejo 1\n- Consejo 2\n- Consejo 3";

            var request = new
            {
                model = "llama3-70b-8192",
                messages = new[] {
                    new { role = "user", content = prompt }
                }
            };

            var json = System.Text.Json.JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Clear();                                                                                   // TfP (ULTIMAS 3 LINEAS DEL API 
            client.DefaultRequestHeaders.Add("Authorization", "Bearer gsk_zBRMw21SumibHng5z7SLWGdyb3FYEoBylMDibKftODbhHoOSO"); // Coloca API (YA QUE ESTA SE ENCUENTRA RECORTADA POR SER SUBIDA A GIT HUB )

            HttpResponseMessage response = await client.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                using var doc = System.Text.Json.JsonDocument.Parse(jsonResponse);
                var mensaje = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
                return mensaje;
            }
            else
            {
                return "Error al consultar la IA. Verifica la conexión o tu API key.";
            }
        }

        private void GuardarEnBD(string entrada, string respuesta)
        {
            {
                string cadenaConexion = "Server=DESKTOP-O3OIHTO\\SQLEXPRESS;Database=Proyecto 2;Trusted_Connection=True;";

                try
                {
                    using (SqlConnection conn = new SqlConnection(cadenaConexion))
                    {
                        conn.Open();
                        string query = "INSERT INTO HistorialConsultas (Entrada, Respuesta) VALUES (@entrada, @respuesta)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@entrada", entrada);
                            cmd.Parameters.AddWithValue("@respuesta", respuesta);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Conexión exitosa y datos guardados en la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar en la base de datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void groupBoxResultado_Enter(object sender, EventArgs e)
        {

        }
    }
}
