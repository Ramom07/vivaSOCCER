using AForge.Video.DirectShow;
using AForge.Video;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace vsoccer
{
    public partial class Editar : Form
    {
        private int numcontrol; // Numero de control del alumno
        private FilterInfoCollection dispositivos; // Para detectar cámaras disponibles
        private VideoCaptureDevice fuenteDeVideo; // Para capturar video desde la cámara

        public Editar(int numcontrol)
        {
            InitializeComponent();
            this.numcontrol = numcontrol;
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            // Cargar los datos del alumno y los ComboBoxes al cargar el formulario
            CargarDatosAlumno();
            CargarCategorias();
            CargarTutores();
        }

        // Método común para cargar ComboBox desde la base de datos
        private void CargarComboBox(string query, ComboBox comboBox, string displayMember, string valueMember)
        {
            try
            {
                using (var conexion = new Conexion())
                {
                    var conn = conexion.AbrirConexion();
                    if (conn == null) return;

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    comboBox.DataSource = dataTable;
                    comboBox.DisplayMember = displayMember;
                    comboBox.ValueMember = valueMember;

                    conexion.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }



        // Método para cargar los datos del alumno desde la base de datos
        private void CargarDatosAlumno()
        {
            try
            {
                // Conectar a la base de datos
                using (var conexion = new Conexion())
                {
                    var conn = conexion.AbrirConexion();
                    if (conn == null) return;

                    // Consulta SQL para obtener los datos del alumno por su numcontrol
                    string query = "SELECT u.nombre, u.apellido1, u.apellido2, u.fechaNacimiento, a.categoria, a.idtutor " +
                                   "FROM usuarios u " +
                                   "INNER JOIN alumnos a ON u.id = a.id " +
                                   "WHERE a.numcontrol = @numcontrol";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        // Añadir el parámetro numcontrol
                        cmd.Parameters.AddWithValue("@numcontrol", numcontrol);

                        // Ejecutar la consulta y leer los resultados
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Leer los datos del alumno
                                string nombre = reader.GetString("nombre");
                                string apellido1 = reader.GetString("apellido1");
                                string apellido2 = reader.GetString("apellido2");
                                DateTime fechaNacimiento = reader.GetDateTime("fechaNacimiento");
                                int categoria = reader.GetInt32("categoria");
                                int idTutor = reader.GetInt32("idtutor");

                                // Asignar los datos a los controles del formulario
                                txtNombre.Text = nombre;
                                txtApellido1.Text = apellido1;
                                txtApellido2.Text = apellido2;
                                dtpFechaNaciRegister.Value = fechaNacimiento;
                                cbHorario.SelectedValue = categoria; // Asigna la categoría al ComboBox
                                cbSelecTutoRegister.SelectedValue = idTutor; // Asigna el tutor al ComboBox
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el alumno con el número de control especificado.");
                            }
                        }
                    }
                    conexion.CerrarConexion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del alumno: " + ex.Message);
            }
        }


        // Cargar categorías
        private void CargarCategorias()
        {
            CargarComboBox("SELECT id_categoria, nombre FROM categorias", cbHorario, "nombre", "id_categoria");
        }

        // Cargar tutores
        private void CargarTutores()
        {
            CargarComboBox("SELECT idtutor, nombre FROM tutores", cbSelecTutoRegister, "nombre", "idtutor");
        }

        // Validación de campos antes de actualizar
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido1.Text))
            {
                MessageBox.Show("Por favor, complete los campos obligatorios.");
                return false;
            }
            return true;
        }

        // Método para guardar la información del alumno
        private void btnSaveAlumRegister_Click(object sender, EventArgs e)
        {
            // Verificar que los campos sean válidos
            if (!ValidarCampos()) return;

            // Recoger los datos del formulario
            string nombre = txtNombre.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            DateTime fechaNacimiento = dtpFechaNaciRegister.Value;
            int categoria = Convert.ToInt32(cbHorario.SelectedValue);
            int tutor = Convert.ToInt32(cbSelecTutoRegister.SelectedValue);
            string fotoPath = GuardarImagen(); // Obtener la ruta de la foto guardada

            // Crear la consulta base para actualizar
            StringBuilder updateQuery = new StringBuilder("UPDATE usuarios u " +
                                                         "INNER JOIN alumnos a ON u.id = a.id " +
                                                         "SET ");

            List<MySqlParameter> parameters = new List<MySqlParameter>();

            // Verificar qué campos han cambiado y construir la consulta dinámicamente
            if (!string.IsNullOrEmpty(nombre))
            {
                updateQuery.Append("u.nombre = @nombre, ");
                parameters.Add(new MySqlParameter("@nombre", nombre));
            }
            if (!string.IsNullOrEmpty(apellido1))
            {
                updateQuery.Append("u.apellido1 = @apellido1, ");
                parameters.Add(new MySqlParameter("@apellido1", apellido1));
            }
            if (!string.IsNullOrEmpty(apellido2))
            {
                updateQuery.Append("u.apellido2 = @apellido2, ");
                parameters.Add(new MySqlParameter("@apellido2", apellido2));
            }
            if (fechaNacimiento != DateTime.MinValue)
            {
                updateQuery.Append("u.fechaNacimiento = @fechaNacimiento, ");
                parameters.Add(new MySqlParameter("@fechaNacimiento", fechaNacimiento));
            }
            if (!string.IsNullOrEmpty(fotoPath))
            {
                updateQuery.Append("u.foto = @foto, ");
                parameters.Add(new MySqlParameter("@foto", fotoPath));
            }
            if (categoria != 0) // Si categoría es válida
            {
                updateQuery.Append("a.categoria = @categoria, ");
                parameters.Add(new MySqlParameter("@categoria", categoria));
            }
            if (tutor != 0) // Si tutor es válido
            {
                updateQuery.Append("at.idtutor = @tutor, ");
                parameters.Add(new MySqlParameter("@tutor", tutor));
            }

            // Eliminar la última coma y espacio sobrante
            updateQuery.Length--;

            // Completar la condición WHERE
            updateQuery.Append(" WHERE a.numcontrol = @numcontrol");

            // Añadir el parámetro numcontrol
            parameters.Add(new MySqlParameter("@numcontrol", numcontrol));

            // Usar la clase Conexion para obtener la conexión a la base de datos
            using (var conexion = new Conexion())
            {
                var conn = conexion.AbrirConexion();
                if (conn == null) return;

                using (var command = new MySqlCommand(updateQuery.ToString(), conn))
                {
                    // Añadir todos los parámetros al comando
                    command.Parameters.AddRange(parameters.ToArray());

                    // Ejecutar la actualización
                    command.ExecuteNonQuery();
                }

                conexion.CerrarConexion();
            }

            MessageBox.Show("Información actualizada correctamente.");
        }

        // Método para guardar la imagen de la foto del alumno
        private string GuardarImagen()
        {
            // Crear la ruta de la carpeta FotosAlumnos dentro del proyecto
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FotosAlumnos");

            // Crear la carpeta si no existe
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = $"Alumno_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";
            string filePath = Path.Combine(folderPath, fileName);

            // Verificar si hay una imagen cargada
            if (PictureBoxAddImageAlum.Image != null)
            {
                PictureBoxAddImageAlum.Image.Save(filePath);
                return filePath;
            }

            return null;
        }

        // Detectar cámaras disponibles
        private void DetectarCamaras()
        {
            dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (dispositivos.Count == 0)
            {
                MessageBox.Show("No se detectaron cámaras.");
                return;
            }
        }

        // Foto de clic para tomar imagen
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

        // Método para capturar el frame de la cámara
        private void CapturarFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Mostrar la imagen en el PictureBox
            PictureBoxAddImageAlum.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        // Método que captura la imagen cuando la cámara está activa
        private void CapturarImagen()
        {
            if (fuenteDeVideo != null && fuenteDeVideo.IsRunning)
            {
                fuenteDeVideo.SignalToStop();
                fuenteDeVideo.WaitForStop();

                GuardarImagen(); // Llamar al método para guardar la imagen
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
    }
}
