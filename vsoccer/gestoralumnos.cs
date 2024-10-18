using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace vsoccer
{
    public partial class gestoralumnos : Form
    {
        public gestoralumnos()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();

            panelOpciones.Dock = DockStyle.Top;

            // Establecer el formulario en pantalla completa
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            // Establecer el modo de escalado automático
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // Habilitar compatibilidad con alta definición
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            //Los botones de Cuenta y cerrar sesion estan en sus respectivos lugares arriba der y abajo der

            btnCuenta.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            btnCerrarsesion.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
            /*
            MySqlConnection conexionBD = conexion.conex();

            if (conexionBD != null)
            {

            }
            */

        }

        private void dgDatosAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gestoralumnos_Load(object sender, EventArgs e)
        {

        }
        //evento cerrar 
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //evento maximizar ventana
        private void btnMax_Click(object sender, EventArgs e)
        {//si esta normal lo maximiza ,si esta maximizado vuelve normal 
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
        }
        //evento minimizar ventana

        private void btnMin_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Minimized;
        }

        private void chtCalificaciones_Click(object sender, EventArgs e)
        {

        }
    }
}

