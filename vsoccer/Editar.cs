using AForge.Video.DirectShow;
using AForge.Video;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vsoccer
{
    public partial class Editar : Form
    {
        private FilterInfoCollection dispositivos; // Para almacenar la lista de dispositivos de video (cámaras)
        private VideoCaptureDevice fuenteDeVideo; // Para la cámara seleccionada
        private int numControl;
        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private DateTime fechaNac;

        public Editar(int numControl, string nombre, string apellidoPaterno, string apellidoMaterno, DateTime fechaNac)
        {
            InitializeComponent();

            this.numControl = numControl;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.fechaNac = fechaNac;
            
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            // Cargar datos en los controles
            CargarDatos(numControl);
            

            // Cargar la foto del alumno
            CargarFoto(numControl);
        }

        private void CargarDatos(int numControl)
        {
            try
            {
                string querydatos = @"
            SELECT usuarios.nombre, usuarios.apellido1, usuarios.apellido2 
            FROM alumnos 
            INNER JOIN usuarios ON alumnos.id = usuarios.id 
            WHERE alumnos.numcontrol = @numcontrol;";

                using (Conexion conexion = new Conexion())
                {
                    using (MySqlConnection conn = conexion.AbrirConexion())
                    {
                        using (MySqlCommand cmd = new MySqlCommand(querydatos, conn))
                        {
                            // Agregar parámetro para numControl
                            cmd.Parameters.AddWithValue("@numcontrol", numControl);

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Asignar directamente a los TextBox
                                    txtNom.Text = reader["nombre"].ToString();
                                    txtAp1.Text = reader["apellido1"].ToString();
                                    txtAp2.Text = reader["apellido2"].ToString();
                                }
                                else
                                {
                                    MessageBox.Show("No se encontraron datos para este número de control.",
                                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Método para cargar la foto del alumno desde la base de datos
        private void CargarFoto(int numControl)
        {
            try
            {
                string query = @"
            SELECT u.foto
            FROM usuarios u
            INNER JOIN alumnos a ON u.id = a.id
            WHERE a.numcontrol = @numcontrol";

                using (Conexion conexion = new Conexion())
                {
                    using (MySqlConnection conn = conexion.AbrirConexion())
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@numcontrol", numControl);

                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                string rutaFoto = result.ToString();
                                if (!string.IsNullOrEmpty(rutaFoto))
                                {
                                    try
                                    {
                                        PictureBoxAddImageAlum.Image = Image.FromFile(rutaFoto);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("No se pudo cargar la imagen del alumno.");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se encontró la ruta de la foto para este alumno.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la foto del alumno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombre_Load(object sender, EventArgs e)
        {

        }

        private void txtApellido1_Load(object sender, EventArgs e)
        {

        }

        private void txtApellido2_Load(object sender, EventArgs e)
        {

        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelRegister_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveAlumRegister_Click(object sender, EventArgs e)
        {

            GuardarImagen(); // Llamar al método para guardar la imagen

        }

        private void cbHorario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            // Mostrar una lista de cámaras y seleccionar una
            if (dispositivos.Count == 0)
            {
                MessageBox.Show("No se detectaron cámaras.");
                return;
            }

            // Seleccionar la primera cámara
            fuenteDeVideo = new VideoCaptureDevice(dispositivos[0].MonikerString);
            fuenteDeVideo.NewFrame += new NewFrameEventHandler(CapturarFrame);
            fuenteDeVideo.Start();

            // Capturar la imagen después de 5 segundos
            Task.Delay(5000).ContinueWith(_ => CapturarImagen());
        }

        private void CapturarFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Mostrar la imagen en el PictureBox (de manera continua mientras la cámara esté activa)
            PictureBoxAddImageAlum.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void CapturarImagen()
        {
            if (fuenteDeVideo != null && fuenteDeVideo.IsRunning)
            {
                fuenteDeVideo.SignalToStop();
                fuenteDeVideo.WaitForStop();

                
            }
        }

        private string GuardarImagen()
        {
            // Crear la ruta de la carpeta FotosAlumnos dentro del proyecto
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FotosAlumnos");

            // Crear la carpeta si no existe
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Crear un nombre de archivo único con la fecha y hora
            string fileName = $"Alumno_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";
            string filePath = Path.Combine(folderPath, fileName);

            // Guardar la imagen del PictureBox en la carpeta
            if (PictureBoxAddImageAlum.Image != null)
            {
                PictureBoxAddImageAlum.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show($"Imagen guardada en: {filePath}");
                return filePath;
            }
            else
            {
                MessageBox.Show("No se capturó ninguna imagen.");
                return null;
            }

        }

        private void dtpFechaNaciRegister_ValueChanged(object sender, EventArgs e)
        {

        }
    }

}
