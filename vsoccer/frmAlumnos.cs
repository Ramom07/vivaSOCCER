using AForge.Video;
using AForge.Video.DirectShow;
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

        private void GuardarImagen()
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
            PictureBoxAddImageAlum.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

            MessageBox.Show($"Imagen guardada en: {filePath}");
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
    }
}
    
