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
        private int intentosRestantes = 3;

        // Credenciales correctas como constantes de clase
        private const string USUARIO_CORRECTO = "prueba@gmail.com";
        private const string CONTRASENA_CORRECTA = "Vivasoccer24!";

        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        public iniciodesesion()
        {
            InitializeComponent();
            ConfigurarFormulario();
          //  VerificarControles(); // Agregamos verificación inicial de controles
        }

        private void ConfigurarFormulario()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            this.AutoScaleMode = AutoScaleMode.Dpi;
            txtContrasena.PasswordChar = true; // Usando la propiedad PasswordChar del RJTextBox
        }

        //verificar si estan los campos
        /*
        private void VerificarControles()
        {
            foreach (Control control in this.Controls)
            {
                if (control is RJTextBox)
                {
                    RJTextBox rjTextBox = (RJTextBox)control;
                    MessageBox.Show(
                        $"Control RJTextBox encontrado:\n" +
                        $"Nombre: {rjTextBox.Name}\n" +
                        $"Texto actual: {rjTextBox.Texts}\n" +
                        $"Es contraseña: {rjTextBox.PasswordChar}",
                        "Información del Control",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }*/

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Obtener y limpiar las credenciales ingresadas usando la propiedad Texts
            string emailIngresado = txtUsuario.Texts?.Trim() ?? "";
            string passwordIngresado = txtContrasena.Texts?.Trim() ?? "";

            // Diagnóstico: Mostrar longitud de los campos
           /* MessageBox.Show(
                $"Diagnóstico:\n" +
                $"Longitud del email: {emailIngresado.Length}\n" +
                $"Longitud de la contraseña: {passwordIngresado.Length}\n" +
                $"Email ingresado: '{emailIngresado}'\n" +
                $"¿Email está vacío?: {string.IsNullOrEmpty(emailIngresado)}\n" +
                $"¿Contraseña está vacía?: {string.IsNullOrEmpty(passwordIngresado)}",
                "Información de diagnóstico",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
           */

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(emailIngresado) || string.IsNullOrEmpty(passwordIngresado))
            {
                MostrarError("Por favor, complete todos los campos.");
                return;
            }

            // Validar el formato del email
            if (!ValidarEmail(emailIngresado))
            {
                MostrarError("El formato del correo electrónico no es válido.");
                return;
            }

            // Validar el formato de la contraseña
            if (!ValidarContrasena(passwordIngresado))
            {
                MostrarError("La contraseña debe tener al menos 8 caracteres, una mayúscula, un número y un carácter especial.");
                return;
            }

            // Verificar las credenciales
            if (emailIngresado == USUARIO_CORRECTO && passwordIngresado == CONTRASENA_CORRECTA)
            {
                InicioSesionExitoso();
            }
            else
            {
                ManejarIntentoFallido();
            }
        }

        private void InicioSesionExitoso()
        {
            DialogResult resultado = MessageBox.Show(
                "¡Inicio de sesión exitoso!\n\nPresione Aceptar para continuar",
                "Bienvenido",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            if (resultado == DialogResult.OK)
            {
                gestoralumnos gestorAlumnosForm = new gestoralumnos();
                gestorAlumnosForm.Show();
                this.Hide();
            }
        }

        private void ManejarIntentoFallido()
        {
            intentosRestantes--;

            if (intentosRestantes > 0)
            {
                MostrarError($"Usuario y/o Contraseña incorrectos\n\nLe quedan {intentosRestantes} intentos");
                txtContrasena.Texts = ""; // Usando la propiedad Texts para limpiar
                txtContrasena.Focus();
            }
            else
            {
                MessageBox.Show(
                    "Ha excedido el número máximo de intentos.\nLa aplicación se cerrará.",
                    "Acceso bloqueado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void MostrarError(string mensaje)
        {
            MessageBox.Show(
                mensaje,
                "Error de inicio de sesión",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Patrón de validación de email más preciso
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(email, pattern);
            }
            catch
            {
                return false;
            }
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
            txtContrasena.PasswordChar = !passwordVisible; // Usando la propiedad PasswordChar del RJTextBox

            Button btnVerContrasena = (Button)sender;
            btnVerContrasena.Text = passwordVisible ? "Ocultar Contraseña" : "Ver Contraseña";
        }
    }
}