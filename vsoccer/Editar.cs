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
using static vsoccer.frmAlumnos;

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

            //Cargar tutores
            CargarTutores();

            //Cargar horario
            CargarHorario();

            
        }

        


        private void CargarHorario()
        {
            
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
                                    dtpFechaNaciRegister.Value = fechaNac;
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

        private void CargarTutores()
        {
            // Limpiar el ComboBox antes de llenarlo
            cbSelecTutoRegister.Items.Clear();

            // Variables para identificar el tutor asignado
            int idTutorAsignado = -1;

            try
            {
                // Query para obtener el ID del tutor asignado al alumno
                string queryTutorAsignado = @"
            SELECT t.id_tutor
            FROM tutores t
            INNER JOIN alumno_tutor at ON t.id_tutor = at.id_tutor
            WHERE at.numcontrol = @numcontrol;";

                using (Conexion conexion = new Conexion())
                {
                    using (MySqlConnection conn = conexion.AbrirConexion())
                    {
                        // Obtener el tutor asignado
                        using (MySqlCommand cmd = new MySqlCommand(queryTutorAsignado, conn))
                        {
                            cmd.Parameters.AddWithValue("@numcontrol", numControl);
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                idTutorAsignado = Convert.ToInt32(result);
                            }
                        }

                        // Query para cargar la lista de tutores
                        string queryTutores = @"
                    SELECT u.nombre, u.apellido1, u.apellido2, t.id_tutor 
                    FROM usuarios u
                    INNER JOIN tutores t ON u.id = t.idusuario
                    WHERE u.id_rol = 3;"; // Rol 3 es el de tutor

                        using (MySqlCommand cmd = new MySqlCommand(queryTutores, conn))
                        {
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Concatenar el nombre completo del tutor
                                    string nombreCompleto = reader["nombre"].ToString() + " " +
                                                            reader["apellido1"].ToString() + " " +
                                                            reader["apellido2"].ToString();
                                    int idTutor = Convert.ToInt32(reader["id_tutor"]);

                                    // Agregar tutor al ComboBox
                                    ComboBoxItem item = new ComboBoxItem
                                    {
                                        Text = nombreCompleto,
                                        Tag = idTutor
                                    };
                                    cbSelecTutoRegister.Items.Add(item);

                                    // Si este tutor es el asignado, seleccionarlo
                                    if (idTutor == idTutorAsignado)
                                    {
                                        cbSelecTutoRegister.SelectedItem = item;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tutores: " + ex.Message,
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

            // Validar si la edad está fuera del rango permitido
            if (age < 3 || age > 13)
            {
                // Mostrar mensaje de advertencia
                MessageBox.Show("La edad debe estar entre 3 y 13 años.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Reestablecer el DateTimePicker a una fecha válida (por ejemplo, hace 3 años desde hoy)
                dtpFechaNaciRegister.Value = DateTime.Now.AddYears(-3);

                // Detener la ejecución del resto del código
                return;
            }

            // Limpiar los horarios previos
            cbHorario.Items.Clear();

            // Asignar horarios según la edad
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

        private void txtNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter ingresado es una letra
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false; // Permitir la entrada de letras
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false; // Permitir teclas de control como Backspace
            }
            else
            {
                e.Handled = true; // Bloquear cualquier otro carácter
                MessageBox.Show("Solo se permiten letras en este campo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtAp1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter ingresado es una letra
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false; // Permitir la entrada de letras
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false; // Permitir teclas de control como Backspace
            }
            else
            {
                e.Handled = true; // Bloquear cualquier otro carácter
                MessageBox.Show("Solo se permiten letras en este campo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtAp2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el carácter ingresado es una letra
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false; // Permitir la entrada de letras
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false; // Permitir teclas de control como Backspace
            }
            else
            {
                e.Handled = true; // Bloquear cualquier otro carácter
                MessageBox.Show("Solo se permiten letras en este campo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}
