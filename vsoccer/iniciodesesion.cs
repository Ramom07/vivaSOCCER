using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vsoccer
{
    public partial class iniciodesesion : Form
    {
        private bool passwordVisible = false;
        private int intentosRestantes = 3; // Contador de intentos



        [STAThread]
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        public iniciodesesion()
        {
            InitializeComponent();

            // Habilitar compatibilidad con pantallas de alta resolución
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            // Asegurar el escalado adecuado
            this.AutoScaleMode = AutoScaleMode.Dpi;

            // Configurar el RJTextBox de contraseña
            txtContrasena.PasswordChar = true;

        }


       

       

      



        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string email = txtUsuario.Text; // Asumiendo que tienes un TextBox llamado txtUsuario
            string password = txtContrasena.Text;

          
            // Validar email y contraseña
            if (!ValidarEmail(email) || !ValidarContrasena(password))
            {
                intentosRestantes--;

                if (intentosRestantes > 0)
                {
                    MessageBox.Show(
                        $"Usuario y/o Contraseña incorrectos\n\nLe quedan {intentosRestantes} intentos",
                        "Error de inicio de sesión",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    // Limpiar el campo de contraseña
                    txtContrasena.Texts = "";
                    txtContrasena.Focus();
                }
                else
                {
                    MessageBox.Show(
                        "Ha excedido el número máximo de intentos.\nLa aplicación se cerrará.",
                        "Acceso bloqueado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    // Cerrar la aplicación
                    Application.Exit();
                }
                return;
            }

            // Si las validaciones son exitosas
            gestoralumnos gestorAlumnosForm = new gestoralumnos();
            gestorAlumnosForm.Show();
            this.Hide();
        }
        private bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@gmail\.com$";
            return Regex.IsMatch(email, pattern);
        }

        private bool ValidarContrasena(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            var tieneMinimo8Caracteres = password.Length >= 8;
            var tieneMayuscula = password.Any(char.IsUpper);
            var tieneNumero = password.Any(char.IsDigit);
            var tieneCaracterEspecial = password.Any(c => !char.IsLetterOrDigit(c));

            return tieneMinimo8Caracteres && tieneMayuscula && tieneNumero && tieneCaracterEspecial;
        }

        private void btnVercontraseña_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            txtContrasena.PasswordChar = !passwordVisible;

            // Cambiar el texto del botón
            Button btnVerContrasena = (Button)sender;
            btnVerContrasena.Text = passwordVisible ? "Ocultar Contraseña" : "Ver Contraseña";
        }
    }
    
}
