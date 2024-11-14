using AForge.Video;
using AForge.Video.DirectShow;
using MySql.Data.MySqlClient;
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

namespace vsoccer
{
    public partial class frmAlumnos : Form
    {
        private FilterInfoCollection dispositivos; // Para almacenar la lista de dispositivos de video (cámaras)
        private VideoCaptureDevice fuenteDeVideo; // Para la cámara seleccionada

        public frmAlumnos()
        {
            InitializeComponent();
            // Activar compatibilidad con pantallas de alta definición
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            // Escalado adecuado para alta definición
            this.AutoScaleMode = AutoScaleMode.Dpi;
            // Ocultar el GroupBox al iniciar el formulario
            gpRegistrartutor.Visible = false;

        }

        // Importar la función para manejar pantallas de alta definición
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private void frmAlumnos_Load(object sender, EventArgs e)
        {
            // Obtener la lista de cámaras disponibles
            dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo dispositivo in dispositivos)
            {
                Console.WriteLine(dispositivo.Name);
            }
        }

        private void gb_Info_Alumno_Enter(object sender, EventArgs e)
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

                GuardarImagen(); // Llamar al método para guardar la imagen
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

        private void frmAlumnos_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Asegurarse de que la cámara se detenga al cerrar el formulario
            if (fuenteDeVideo != null && fuenteDeVideo.IsRunning)
            {
                fuenteDeVideo.SignalToStop();
                fuenteDeVideo.WaitForStop();
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

        private void dtpFechaNaciRegister_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbSelecTutoRegister_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbHorario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveAlumRegister_Click(object sender, EventArgs e)
        {
            // Tomar datos del formulario
            string nombre = txtNombre.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            DateTime fechaNacimiento = dtpFechaNaciRegister.Value;

            // Validar los campos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido1) || fechaNacimiento == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }


            //Tomar direccion de la foto
            string filePath = GuardarImagen();

            //Registrar datos en BD
            if (!string.IsNullOrEmpty(filePath))
            {
                //Conexion a base de datos
                Conexion conexion = new Conexion();

                using (var connection = conexion.AbrirConexion())
                {
                    if (connection != null)
                    {
                        string query = "insert into usuarios (rol, nombre, apellido1, apellido2, fechaNacimiento, foto)" +
                            "VALUES (@rol, @nombre, @apellido1, @apellido2, @fechaNacimiento, @foto)";

                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@rol", 5);
                            command.Parameters.AddWithValue("@nombre", nombre);
                            command.Parameters.AddWithValue("@apellido1", apellido1);
                            command.Parameters.AddWithValue("@apellido2", apellido2);
                            command.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                            command.Parameters.AddWithValue("@foto", filePath);
                            command.ExecuteNonQuery();

                            try
                            {
                                command.ExecuteNonQuery();
                                MessageBox.Show("Alumno registrado exitosamente.");
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al registrar el alumno: " + ex.Message);
                            }



                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo abrir conexion a Base de Datos");
                    }

                }

                //Cerrar la conexion
                conexion.CerrarConexion();
                
            }
            else
            {
                MessageBox.Show("Error al guardar.");
            }




        }

        private void btnAgregartutor_Click(object sender, EventArgs e)
        {
            // Si el GroupBox está oculto, lo mostramos y expandimos el formulario
            if (!gpRegistrartutor.Visible)
            {
                gpRegistrartutor.Visible = true;

                // Expandir el formulario para que se ajuste al nuevo tamaño del GroupBox
                this.Height += gpRegistrartutor.Height + 20; // Ajuste adicional para espacio
            }
        }

        private void gpRegistrartutor_Enter(object sender, EventArgs e)
        {

        }
    }
}
    
