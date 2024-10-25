using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vsoccer
{
    public partial class frmEditar : Form
    {
        public frmEditar()
        {
            InitializeComponent();
            // Activar compatibilidad con pantallas de alta definición
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            // Escalado adecuado para alta definición
            this.AutoScaleMode = AutoScaleMode.Dpi;


        }

        // Importar la función para manejar pantallas de alta definición
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private void lblAddfhater_Click(object sender, EventArgs e)
        {

        }
    }
}
