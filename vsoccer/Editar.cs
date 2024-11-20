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
        private int numcontrol;

        public Editar(int numcontrol)
        {
            InitializeComponent();
            this.numcontrol = numcontrol;
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            // Cargar los datos iniciales necesarios
            CargarDatosAlumno();
        }

        // Método para cargar datos del alumno
        private void CargarDatosAlumno()
        {
            string query = @"SELECT 
                        u.nombre AS Nombre, 
                        u.apellido1 AS Apellido1, 
                        u.apellido2 AS Apellido2
                     FROM alumnos a
                     JOIN usuarios u ON a.id = u.id
                     WHERE a.numcontrol = @numcontrol";

            // Usar la clase Conexion para abrir y manejar la conexión
            using (Conexion conexion = new Conexion())
            {
                MySqlConnection connection = conexion.AbrirConexion();
                if (connection == null) return; // Si no se puede abrir la conexión, salir del método

                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@numcontrol", numcontrol);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNombre.Text = reader.GetString("Nombre");
                                txtApellido1.Text = reader.GetString("Apellido1");
                                txtApellido2.Text = reader.GetString("Apellido2");
                            }
                            else
                            {
                                MessageBox.Show("No se encontraron datos para el alumno.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
        }

      

        // Guardar información del alumno
        private void btnSaveAlumRegister_Click(object sender, EventArgs e)
        {
           // if (!ValidarCampos()) return;

            // Implementar lógica de guardado
            MessageBox.Show("Información actualizada correctamente.");
        }

        

        private void btnCancelRegister_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Editar_Load_1(object sender, EventArgs e)
        {

        }

        private void txtNombre_Load(object sender, EventArgs e)
        {

        }

        private void cbHorario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaNaciRegister_ValueChanged(object sender, EventArgs e)
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
