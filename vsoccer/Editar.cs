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
        private int numControl;
        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private DateTime fechaNacimiento;

        public Editar(int numControl, string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            InitializeComponent();

            this.numControl = numControl;
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            // Cargar datos en los controles
            txtNombre.Text = this.nombre;
            txtApellido1.Text = this.apellidoPaterno;
            txtApellido2.Text = this.apellidoMaterno;
            

            // Cargar la foto del alumno
            CargarFoto(numControl);
        }

        private void CargarDatos(string nombre, string ap1, string ap2)
        {
            string query = "SELECT a.numcontrol, u.nombre, u.apellido1, u.apellido2 FROM alumnos a JOIN usuarios u ON a.id = u.id;";

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
    }

}
