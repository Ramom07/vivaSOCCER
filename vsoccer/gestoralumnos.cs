using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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

            //Los botones de Cuenta y cerrar sesión están en sus respectivos lugares arriba der y abajo der
            btnCuenta.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
            btnCerrarsesion.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);

            // Configurar el gráfico
            ConfigurarGrafico();
        }

        private void ConfigurarGrafico()
        {
        }


        private void dgDatosAlumnos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDatosAlumnos.SelectedRows.Count > 0)
            {
                // Obtener el numcontrol del alumno seleccionado
                numcontrolSeleccionado = Convert.ToInt32(dgDatosAlumnos.SelectedRows[0].Cells[0].Value);

                // Llamar a la función para cargar los promedios
                CargarPromedios(numcontrolSeleccionado);
            }
        }

        private void cargarTabla(string dato)
        {
            List<Alumno> lista = new List<Alumno>();
            CtrlAlumnos ctrlAlumnos = new CtrlAlumnos();
            var datosAlumnos = ctrlAlumnos.consulta(dato);

            dgDatosAlumnos.DataSource = datosAlumnos;

            // Asegúrate de que la columna "Id" esté correctamente configurada
            dgDatosAlumnos.Columns[0].HeaderText = "Num Control"; // Si es necesario, ajusta el nombre de la columna
        }

        private void CargarPromedios(int numcontrol)
        {
            // Consulta para obtener los promedios de las calificaciones
            string sql = @"
        SELECT 
            numcontrol,
            AVG(pase) AS promedio_pase,
            AVG(recepcion) AS promedio_recepcion,
            AVG(conduccion) AS promedio_conduccion,
            AVG(tiro) AS promedio_tiro
        FROM evaluaciones
        WHERE numcontrol = @numcontrol";  // Usamos el parámetro @numcontrol

            try
            {
                using (MySqlConnection conexionBD = new Conexion().AbrirConexion())
                {
                    using (MySqlCommand comando = new MySqlCommand(sql, conexionBD))
                    {
                        // Agregamos el parámetro @numcontrol con el valor dinámico
                        comando.Parameters.AddWithValue("@numcontrol", numcontrol);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Obtener los promedios de las calificaciones
                                double promedioPase = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                                double promedioRecepcion = reader.IsDBNull(2) ? 0 : reader.GetDouble(2);
                                double promedioConduccion = reader.IsDBNull(3) ? 0 : reader.GetDouble(3);
                                double promedioTiro = reader.IsDBNull(4) ? 0 : reader.GetDouble(4);

                                // Actualizar el gráfico (Chart) con los promedios obtenidos
                                chtCalificaciones.Series["Promedios"].Points.Clear();
                                chtCalificaciones.Series["Promedios"].Points.AddXY("Pase", promedioPase);
                                chtCalificaciones.Series["Promedios"].Points.AddXY("Recepción", promedioRecepcion);
                                chtCalificaciones.Series["Promedios"].Points.AddXY("Conducción", promedioConduccion);
                                chtCalificaciones.Series["Promedios"].Points.AddXY("Tiro", promedioTiro);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los promedios: " + ex.Message);
            }
        }


        // Evento cerrar
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Evento maximizar ventana
        private void btnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
        }

        // Evento minimizar ventana
        private void btnMin_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
            else if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Minimized;
        }

        private void chtCalificaciones_Click(object sender, EventArgs e)
        {
            // Este evento puede ser utilizado para agregar funcionalidad adicional si es necesario
        }

        // Evento agregar alumno
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAlumnos formAlumnos = new frmAlumnos();
            formAlumnos.Show();
        }

        // Evento editar alumno
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgDatosAlumnos.SelectedRows.Count > 0)
            {
                int numcontrol = Convert.ToInt32(dgDatosAlumnos.SelectedRows[0].Cells[0].Value);
                Editar formEditar = new Editar(numcontrol);
                formEditar.Show();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un alumno para editar.");
            }
        }

        // Evento actualizar tabla
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarTabla(null);
        }

        // Evento eliminar (por ahora vacío, puedes implementarlo más tarde)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Implementar la lógica para eliminar un alumno si es necesario
        }

        private void dgDatosAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
