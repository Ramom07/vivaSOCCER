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

            CargarTutores();
        }

        //Metodo para cargar tutores en su combobox
        private void CargarTutores()
        {
            // Limpiar el ComboBox antes de llenarlo
            cbSelecTutoRegister.Items.Clear();

            // Conexión a la base de datos
            Conexion conexion = new Conexion();
            using (var connection = conexion.AbrirConexion())
            {
                if (connection != null)
                {
                    string query = "SELECT u.nombre, u.apellido1, u.apellido2, t.id_tutor " +
                                   "FROM usuarios u " +
                                   "INNER JOIN tutores t ON u.id = t.idusuario " +
                                   "WHERE u.id_rol = 3"; // Rol 3 es el de tutor

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Concatenar nombre completo
                                string nombreCompleto = reader["nombre"].ToString() + " " + reader["apellido1"].ToString() + " " + reader["apellido2"].ToString();
                                int idTutor = Convert.ToInt32(reader["id_tutor"]);

                                // Agregar el tutor al ComboBox (almacenando el idTutor como Tag)
                                cbSelecTutoRegister.Items.Add(new ComboBoxItem { Text = nombreCompleto, Tag = idTutor });
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo abrir la conexión a la base de datos.");
                }
            }
            conexion.CerrarConexion();
        }

        // Clase auxiliar para almacenar el nombre del tutor y su id
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public int Tag { get; set; }

            // Sobrescribir el método ToString() para que devuelva el nombre completo del tutor
            public override string ToString()
            {
                return Text;  // Retorna el nombre completo que queremos mostrar
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

        //Metodo para calcular edad segun la fecha de nacimietno seleccionada
        private int CalcularEdad(DateTime fechNac)
        {
            int edad = DateTime.Now.Year - fechNac.Year;
            if (DateTime.Now.DayOfYear < fechNac.DayOfYear)
                edad--;
            return edad;
        }

        private void dtpFechaNaciRegister_ValueChanged(object sender, EventArgs e)
        {
            int age = CalcularEdad(dtpFechaNaciRegister.Value);
            cbHorario.Items.Clear();

            if (age >= 3 && age <= 4)
            {
                cbHorario.Items.Add("MINI 1 - Lunes y Miércoles 4PM - 5PM");
                cbHorario.Items.Add("MINI 2 - Martes y Jueves 3PM - 4PM");
            }
            else if (age >= 5 && age <= 6)
            {
                cbHorario.Items.Add("MENOR 1 - Lunes y Miércoles 3PM - 4PM");
                cbHorario.Items.Add("MENOR 2 - Martes y Jueves 4PM - 5PM");
            }
            else if (age >= 7 && age <= 8)
            {
                cbHorario.Items.Add("MAYOR A - Lunes y Miércoles 5PM - 6PM");
                cbHorario.Items.Add("MAYOR B - Martes y Jueves 6PM - 7PM");
            }
            else if (age >= 9 && age <= 10)
            {
                cbHorario.Items.Add("JUVENIL A - Lunes y Miércoles 6PM - 7:30PM");
                cbHorario.Items.Add("JUVENIL B - Martes y Jueves 4PM - 5:30PM");
            }
            else if (age >= 11 && age <= 12)
            {
                cbHorario.Items.Add("PRO - Martes y Jueves 5:30PM - 7PM");
            }
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
            string nombre = txtNom.Text;
            string apellido1 = txtAp1.Text;
            string apellido2 = txtAp2.Text;
            DateTime fechaNacimiento = dtpFechaNaciRegister.Value;
            string fechaNacimientoSQL = fechaNacimiento.ToString("yyyy-MM-dd");

            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Apellido1: " + apellido1);
            Console.WriteLine("Fecha de Nacimiento: " + fechaNacimientoSQL);

            // Verificar que los campos de texto no estén vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido1))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.");
                return;
            }

            // Verificar que se haya seleccionado un tutor
            if (cbSelecTutoRegister.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un tutor.");
                return;
            }

            // Verificar que se haya seleccionado un horario
            if (cbHorario.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un horario.");
                return;
            }

            // Tomar dirección de la foto
            string filePath = GuardarImagen();

            // Verificar que la imagen se haya guardado correctamente
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Error al guardar la imagen.");
                return;
            }

            // Registrar datos en la base de datos
            Conexion conexion = new Conexion();
            using (var connection = conexion.AbrirConexion())
            {
                if (connection != null)
                {
                    // Insertar datos del usuario
                    string queryUsuario = "INSERT INTO usuarios (id_rol, nombre, apellido1, apellido2, fechaNacimiento, foto) " +
                                           "VALUES (@rol, @nombre, @apellido1, @apellido2, @fechaNacimiento, @foto)";

                    using (var command = new MySqlCommand(queryUsuario, connection))
                    {
                        command.Parameters.AddWithValue("@rol", 5);
                        command.Parameters.AddWithValue("@nombre", nombre.ToUpper());
                        command.Parameters.AddWithValue("@apellido1", apellido1.ToUpper());
                        command.Parameters.AddWithValue("@apellido2", apellido2.ToUpper());
                        command.Parameters.AddWithValue("@fechaNacimiento", fechaNacimientoSQL);
                        command.Parameters.AddWithValue("@foto", filePath);

                        command.ExecuteNonQuery();
                    }

                    // Obtener el último numcontrol de la tabla alumnos
                    string queryLastAlumno = "SELECT numcontrol FROM alumnos ORDER BY numcontrol DESC LIMIT 1";
                    long numcontrol = 0;

                    using (var commandLastAlumno = new MySqlCommand(queryLastAlumno, connection))
                    {
                        var result = commandLastAlumno.ExecuteScalar();
                        if (result != null)
                        {
                            numcontrol = Convert.ToInt64(result);
                        }
                    }

                    // Obtener el tutor seleccionado en el ComboBox
                    string tutorSeleccionado = cbSelecTutoRegister.SelectedItem.ToString();
                    int idTutor = ObtenerIdTutor(tutorSeleccionado, connection);

                    if (idTutor == -1)
                    {
                        MessageBox.Show("No se encontró el tutor seleccionado.");
                        return;
                    }

                    // Insertar en la tabla alumno_tutor
                    string queryAlumnoTutor = "INSERT INTO alumno_tutor (numcontrol, id_tutor) VALUES (@numcontrol, @idtutor)";
                    using (var commandTutor = new MySqlCommand(queryAlumnoTutor, connection))
                    {
                        commandTutor.Parameters.AddWithValue("@numcontrol", numcontrol);
                        commandTutor.Parameters.AddWithValue("@idtutor", idTutor);
                        commandTutor.ExecuteNonQuery();
                    }

                    // Obtener la categoría seleccionada del ComboBox
                    string categoriaSeleccionada = cbHorario.SelectedItem.ToString();
                    int idCategoria = ObtenerIdCategoria(categoriaSeleccionada);

                    // Actualizar la categoría en la tabla alumnos
                    string queryUpdateCategoria = "UPDATE alumnos SET id_categoria = @idcategoria WHERE numcontrol = @numcontrol";
                    using (var commandUpdateCategoria = new MySqlCommand(queryUpdateCategoria, connection))
                    {
                        commandUpdateCategoria.Parameters.AddWithValue("@idcategoria", idCategoria);
                        commandUpdateCategoria.Parameters.AddWithValue("@numcontrol", numcontrol);
                        commandUpdateCategoria.ExecuteNonQuery();
                    }

                    // Confirmación al usuario
                    MessageBox.Show("Alumno registrado exitosamente.");
                }
                else
                {
                    MessageBox.Show("No se pudo abrir la conexión a la base de datos.");
                }
            }

            // Cerrar la conexión
            conexion.CerrarConexion();

            // Cerrar el formulario
            this.Close();
        }

        private int ObtenerIdTutor(string nombreTutor, MySqlConnection connection)
        {
            // Dividir el nombre completo en partes
            string[] partes = nombreTutor.Split(' ');
            string nombre = partes[0];
            string apellido1 = partes[1];

            // Buscar el idusuario en la tabla usuarios
            string queryUsuario = "SELECT id FROM usuarios WHERE nombre = @nombre AND apellido1 = @apellido1";
            int idUsuario = -1;

            using (var commandUsuario = new MySqlCommand(queryUsuario, connection))
            {
                commandUsuario.Parameters.AddWithValue("@nombre", nombre);
                commandUsuario.Parameters.AddWithValue("@apellido1", apellido1);

                var result = commandUsuario.ExecuteScalar();
                if (result != null)
                {
                    idUsuario = Convert.ToInt32(result);
                }
            }

            if (idUsuario == -1)
            {
                return -1;
            }

            // Buscar el id_tutor en la tabla tutores
            string queryTutor = "SELECT id_tutor FROM tutores WHERE idusuario = @idusuario";
            int idTutor = -1;

            using (var commandTutor = new MySqlCommand(queryTutor, connection))
            {
                commandTutor.Parameters.AddWithValue("@idusuario", idUsuario);

                var result = commandTutor.ExecuteScalar();
                if (result != null)
                {
                    idTutor = Convert.ToInt32(result);
                }
            }

            return idTutor;
        }







        // Método para obtener el ID de la categoría basado en la selección
        private int ObtenerIdCategoria(string categoriaSeleccionada)
        {
            // Diccionario para mapear los nombres de horarios a los IDs de categoría
            var categoriaMap = new Dictionary<string, int>
    {
        {"MINI 1 - Lunes y Miércoles 4PM - 5PM", 1},
        {"MINI 2 - Martes y Jueves 3PM - 4PM", 6},
        {"MENOR 1 - Lunes y Miércoles 3PM - 4PM", 2},
        {"MENOR 2 - Martes y Jueves 4PM - 5PM", 7},
        {"MAYOR A - Lunes y Miércoles 5PM - 6PM", 3},
        {"MAYOR B - Martes y Jueves 6PM - 7PM", 8},
        {"JUVENIL A - Lunes y Miércoles 6PM - 7:30PM", 4},
        {"JUVENIL B - Martes y Jueves 4PM - 5:30PM", 9},
        {"PRO - Martes y Jueves 5:30PM - 7PM", 5}
    };

            // Retornar el ID correspondiente o -1 si no se encuentra
            return categoriaMap.ContainsKey(categoriaSeleccionada) ? categoriaMap[categoriaSeleccionada] : -1;
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

        private void btnCancelRegister_Click(object sender, EventArgs e)
        {
            // Mostrar un cuadro de diálogo de confirmación
            DialogResult resultado = MessageBox.Show("¿Seguro que deseas cancelar el registro?", "Confirmación de Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Verificar si el usuario seleccionó "Sí"
            if (resultado == DialogResult.Yes)
            {
                // Cerrar el formulario, cancelando el registro
                this.Close();
            }
            else
            {
                // Si seleccionó "No", no se hace nada o puedes mostrar un mensaje opcional
                MessageBox.Show("Operación cancelada. Continúa con el registro.");
            }
        }
    }
}
    
