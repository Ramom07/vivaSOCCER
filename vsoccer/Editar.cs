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
                                // Asignar datos del alumno a los controles
                                txtNombre.Text = reader.GetString("nombre");
                                txtApellido1.Text = reader.GetString("apellido1");
                                txtApellido2.Text = reader.GetString("apellido2");
                                dtpFechaNaciRegister.Value = reader.GetDateTime("fechaNacimiento");
                                cbHorario.SelectedValue = reader.GetInt32("categoria"); // Asigna la categoría al ComboBox
                                cbSelecTutoRegister.SelectedValue = reader.GetInt32("idtutor"); // Asigna el tutor al ComboBox
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
            if (!ValidarCampos()) return;

            // Recoger los datos del formulario
            string nombre = txtNombre.Text;
            string apellido1 = txtApellido1.Text;
            string apellido2 = txtApellido2.Text;
            DateTime fechaNacimiento = dtpFechaNaciRegister.Value;
            int categoria = Convert.ToInt32(cbHorario.SelectedValue);
            int tutor = Convert.ToInt32(cbSelecTutoRegister.SelectedValue);
            string fotoPath = GuardarImagen();

            StringBuilder updateQuery = new StringBuilder("UPDATE usuarios u " +
                                                         "INNER JOIN alumnos a ON u.id = a.id " +
                                                         "SET ");
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            // Construcción de la consulta dinámica
            if (!string.IsNullOrEmpty(nombre)) { updateQuery.Append("u.nombre = @nombre, "); parameters.Add(new MySqlParameter("@nombre", nombre)); }
            if (!string.IsNullOrEmpty(apellido1)) { updateQuery.Append("u.apellido1 = @apellido1, "); parameters.Add(new MySqlParameter("@apellido1", apellido1)); }
            if (!string.IsNullOrEmpty(apellido2)) { updateQuery.Append("u.apellido2 = @apellido2, "); parameters.Add(new MySqlParameter("@apellido2", apellido2)); }
            if (fechaNacimiento != DateTime.MinValue) { updateQuery.Append("u.fechaNacimiento = @fechaNacimiento, "); parameters.Add(new MySqlParameter("@fechaNacimiento", fechaNacimiento)); }
            if (!string.IsNullOrEmpty(fotoPath)) { updateQuery.Append("u.foto = @foto, "); parameters.Add(new MySqlParameter("@foto", fotoPath)); }
            if (categoria != 0) { updateQuery.Append("a.categoria = @categoria, "); parameters.Add(new MySqlParameter("@categoria", categoria)); }
            if (tutor != 0) { updateQuery.Append("a.idtutor = @tutor, "); parameters.Add(new MySqlParameter("@tutor", tutor)); }

            // Remover la última coma
            if (parameters.Count > 0) updateQuery.Length -= 2;
            updateQuery.Append(" WHERE a.numcontrol = @numcontrol");
            parameters.Add(new MySqlParameter("@numcontrol", numcontrol));

            using (var conexion = new Conexion())
            {
                var conn = conexion.AbrirConexion();
                if (conn == null) return;

                using (var command = new MySqlCommand(updateQuery.ToString(), conn))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    command.ExecuteNonQuery();
                }

                conexion.CerrarConexion();
            }
            MessageBox.Show("Información actualizada correctamente.");
        }

        // Método para guardar la imagen de la foto del alumno
        private string GuardarImagen()
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FotosAlumnos");

            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            string fileName = $"Alumno_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";
            string filePath = Path.Combine(folderPath, fileName);

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

        private void btnFoto_Click(object sender, EventArgs e)
        {
            if (dispositivos == null) DetectarCamaras();
            if (dispositivos.Count == 0) return;

            fuenteDeVideo = new VideoCaptureDevice(dispositivos[0].MonikerString);
            fuenteDeVideo.NewFrame += new NewFrameEventHandler(CapturarFrame);
            fuenteDeVideo.Start();
            Task.Delay(5000).ContinueWith(_ => CapturarImagen());
        }

        // Método para capturar el frame de la cámara
        private void CapturarFrame(object sender, NewFrameEventArgs eventArgs)
        {
            PictureBoxAddImageAlum.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        // Método que captura la imagen cuando la cámara está activa
        private void CapturarImagen()
        {
            if (fuenteDeVideo != null && fuenteDeVideo.IsRunning)
            {
                fuenteDeVideo.SignalToStop();
                fuenteDeVideo.WaitForStop();
                GuardarImagen();
            }
        }
    }
}
