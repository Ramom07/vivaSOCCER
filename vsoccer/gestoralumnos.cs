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
            // Verificar si la serie "Promedios" ya existe, si no, crearla
            if (!chtCalificaciones.Series.IsUniqueName("Promedios"))
            {
                chtCalificaciones.Series.Add("Promedios");
                chtCalificaciones.Series["Promedios"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar; // Tipo de gráfico de barras
                chtCalificaciones.Series["Promedios"].Color = Color.Blue; // Color de las barras
            }

            // Configuración del eje Y (calificación entre 1 y 10)
            chtCalificaciones.ChartAreas[0].AxisY.Minimum = 1; // Mínimo de 1
            chtCalificaciones.ChartAreas[0].AxisY.Maximum = 10; // Máximo de 10
            chtCalificaciones.ChartAreas[0].AxisY.Interval = 1; // Intervalo de 1 (de 1 en 1)

            // Configuración del eje X (categorías de calificación)
            chtCalificaciones.ChartAreas[0].AxisX.Interval = 1; // Intervalo de 1 (de 1 en 1)
            chtCalificaciones.ChartAreas[0].AxisX.Title = "Categorías"; // Título del eje X
            chtCalificaciones.ChartAreas[0].AxisY.Title = "Calificación"; // Título del eje Y
        }



        private void dgDatosAlumnos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgDatosAlumnos.SelectedRows.Count > 0)
            {
                try
                {
                    // Obtener el numcontrol del alumno seleccionado
                    numcontrolSeleccionado = Convert.ToInt32(dgDatosAlumnos.SelectedRows[0].Cells[0].Value);

                    // Llamar a la función para cargar los promedios
                    CargarPromedios(numcontrolSeleccionado);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar el alumno: " + ex.Message);
                }
            }
        }

        private void cargarTabla(string dato)
        {
            try
            {
                List<Alumno> lista = new List<Alumno>();
                CtrlAlumnos ctrlAlumnos = new CtrlAlumnos();
                var datosAlumnos = ctrlAlumnos.consulta(dato);

                // Asignar los datos al DataGridView
                dgDatosAlumnos.DataSource = datosAlumnos;

                // Configuración de las columnas
                if (dgDatosAlumnos.Columns.Count > 0)
                {
                    dgDatosAlumnos.Columns[0].HeaderText = "Num Control";
                    dgDatosAlumnos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Ajustar ancho
                    dgDatosAlumnos.Columns[1].HeaderText = "Nombre Completo";
                    dgDatosAlumnos.Columns[2].HeaderText = "Categoría";
                    dgDatosAlumnos.Columns[3].HeaderText = "Fecha de Nacimiento";
                    dgDatosAlumnos.Columns[4].HeaderText = "Tutor";
                    dgDatosAlumnos.Columns[5].HeaderText = "Teléfono";

                    // Formatear la columna de fechaNacimiento
                    dgDatosAlumnos.Columns["fechaNacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy"; // Asegura que esta columna se formatee como fecha

                    // Asegúrate de que "fechaNacimiento" es el nombre correcto de la columna en la base de datos
                    // Si usas un nombre diferente, ajusta el índice o el nombre de la columna
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la tabla de alumnos: " + ex.Message);
            }
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
        WHERE numcontrol = @numcontrol
        GROUP BY numcontrol";  // Usamos el parámetro @numcontrol

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
                try
                {
                    // Obtener el numcontrol del alumno seleccionado
                    int numcontrol = Convert.ToInt32(dgDatosAlumnos.SelectedRows[0].Cells[0].Value);

                    // Crear y abrir el formulario Editar
                    Editar formEditar = new Editar(numcontrol);
                    formEditar.ShowDialog(); // Usar ShowDialog para bloquear el formulario actual
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al intentar abrir el formulario de edición: " + ex.Message);
                }
            }
            else
            {
                // Mensaje si no hay una fila seleccionada
                MessageBox.Show("Por favor, seleccione un alumno para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        //btn eliminar
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            // Mostrar un cuadro de diálogo de confirmación
            DialogResult resultado = MessageBox.Show("¿SEGURO QUE QUIERES ELIMINAR ALUMNO?", "Confirmación de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Verificar si el usuario seleccionó "Sí"
            if (resultado == DialogResult.Yes)
            {
                // Lógica para eliminar al alumno
                MessageBox.Show("Alumno eliminado.");
                // Aquí puedes agregar el código para eliminar el alumno de la base de datos o lista
            }
            else
            {
                // Si seleccionó "No", no se hace nada o puedes mostrar un mensaje opcional
                MessageBox.Show("Operación cancelada.");
            }
        }

        private void btnCerrarsesion_Click(object sender, EventArgs e)
        {
            // Mostrar un cuadro de mensaje de confirmación
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario selecciona 'Sí', cerrar el formulario actual y abrir el formulario de inicio de sesión
            if (result == DialogResult.Yes)
            {
              

                // Cerrar el formulario actual (gestoralumnos)
                this.Close();
            }
        }

        private void dgDatosAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
