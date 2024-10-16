using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vsoccer
{
    public partial class iniciodesesion : Form
    {
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

        }


        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario gestoralumnos
            gestoralumnos gestorAlumnosForm = new gestoralumnos();

            // Mostrar el formulario
            gestorAlumnosForm.Show();

            // Ocultar el formulario de inicio de sesión actual (opcional)
            this.Hide();
        }
    }
}
