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
            this.numcontrol = numcontrol; // Save the value
            InitializeComponent();
            try
            {
                AlumnoData alumno = AlumnoData.ObtenerDatosAlumno(numcontrol);
                txtNombre.Text = alumno.NombreCompleto;
                dtpFechaNaciRegister.Value = alumno.FechaNacimiento;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del alumno: " + ex.Message);
            }
        }

        private void Editar_Load(object sender, EventArgs e)
        {
            // Cargar los datos iniciales necesarios
            CargarDatosAlumno();
        }

        // Método para cargar datos del alumno
        private void CargarDatosAlumno()
        {
            // Implementar la lógica de carga de datos
            try
            {
                // Aquí cargarías más datos como categoría, tutor, teléfono, etc.
                AlumnoData alumno = AlumnoData.ObtenerDatosAlumno(numcontrol);
                // Si tienes más campos, asignarlos a los controles aquí
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del alumno: " + ex.Message);
            }
        }

        // Método para cargar ComboBox desde la base de datos
        private void CargarComboBox(string query, ComboBox comboBox, string displayMember, string valueMember)
        {
            // Implementar lógica para cargar ComboBox
        }

        // Validación de campos antes de actualizar
        /*private bool ValidarCampos()
        {
            if (!ValidarCampos()) return;

            // Actualizar los datos del alumno en la base de datos
            try
            {
                string nombreCompleto = txtNombre.Text;
                DateTime fechaNacimiento = dtpFechaNaciRegister.Value;

                // Actualizar los datos en la base de datos
                AlumnoData.ActualizarDatosAlumno(numcontrol, nombreCompleto, fechaNacimiento);

                MessageBox.Show("Información actualizada correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message);
            }
        }
        */

        /*private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return false;
            }

            // Agregar validaciones adicionales si es necesario
            return true;
        }*/

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return false;
            }
            if (dtpFechaNaciRegister.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura.");
                return false;
            }
            return true;
        }

        // Guardar información del alumno
        private void btnSaveAlumRegister_Click(object sender, EventArgs e)
        {
           // if (!ValidarCampos()) return;

            // Implementar lógica de guardado
            MessageBox.Show("Información actualizada correctamente.");
        }

        // Guardar imagen del alumno
        private string GuardarImagen()
        {
            // Implementar lógica para guardar imagen
            return null;
        }

        // Detectar cámaras disponibles
        private void DetectarCamaras()
        {
            // Implementar lógica para detectar cámaras
        }

        // Capturar frame de la cámara
        private void CapturarFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Implementar lógica para capturar frame
        }

        // Capturar imagen cuando la cámara está activa
        private void CapturarImagen()
        {
            // Implementar lógica para capturar imagen final
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
    }
}
