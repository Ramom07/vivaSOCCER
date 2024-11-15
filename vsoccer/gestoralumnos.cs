using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace vsoccer
{
    public partial class gestoralumnos : Form
    {

        // Variable para almacenar el numcontrol seleccionado
        private int numcontrolSeleccionado;
        public gestoralumnos()
        {
            this.AutoScaleMode = AutoScaleMode.Dpi;
            InitializeComponent();
            cargarTabla(null);

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



        }

        private void dgDatosAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si la columna 'numcontrol' existe
            if (e.RowIndex >= 0 && dgDatosAlumnos.Columns.Contains("numcontrol"))
            {
                // Obtener el numcontrol seleccionado
                numcontrolSeleccionado = Convert.ToInt32(dgDatosAlumnos.Rows[e.RowIndex].Cells["Id"].Value);
            }
            else
            {
                MessageBox.Show("La columna 'numcontrol' no está presente.");
            }

        }

        private void cargarTabla(string dato)
        {
            List<Alumno> lista = new List<Alumno>();
            CtrlAlumnos ctrlAlumnos = new CtrlAlumnos();
            dgDatosAlumnos.DataSource = ctrlAlumnos.consulta(dato);
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Crear y mostrar el formulario frmAlumnos
            frmAlumnos formAlumnos = new frmAlumnos();
            formAlumnos.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            // Verificar si se ha seleccionado una fila en el DataGridView
            if (dgDatosAlumnos.SelectedRows.Count > 0)
            {
                // Obtener el numcontrol de la fila seleccionada
                int numcontrol = Convert.ToInt32(dgDatosAlumnos.SelectedRows[0].Cells["numcontrol"].Value);

                // Crear y mostrar el formulario Editar, pasando el numcontrol como argumento
                Editar formEditar = new Editar(numcontrol);
                formEditar.Show();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un alumno para editar.");
            }
        }
    }
}

