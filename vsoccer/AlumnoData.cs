using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vsoccer
{
    public class AlumnoData
    {
        public int NumControl { get; set; }
        public string NombreCompleto { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Tutor { get; set; }
        public string Telefono { get; set; }

        public static AlumnoData ObtenerDatosAlumno(int numcontrol)
        {
            // Creación del objeto de resultado
            AlumnoData alumno = null;

            // Consulta SQL para obtener los datos del alumno
            string sql = @"
            SELECT numcontrol, nombre, categoria, fechaNacimiento, tutor, telefono
            FROM alumnos
            WHERE numcontrol = @numcontrol";

            try
            {
                // Crear y abrir la conexión con la base de datos
                using (MySqlConnection conexionBD = new Conexion().AbrirConexion())
                {
                    using (MySqlCommand comando = new MySqlCommand(sql, conexionBD))
                    {
                        // Agregar el parámetro de la consulta
                        comando.Parameters.AddWithValue("@numcontrol", numcontrol);

                        // Ejecutar la consulta y leer los datos
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Asignar los valores leídos del lector de datos al objeto AlumnoData
                                alumno = new AlumnoData
                                {
                                    NumControl = reader.GetInt32("numcontrol"),
                                    NombreCompleto = reader.GetString("nombre"),
                                    Categoria = reader.GetString("categoria"),
                                    FechaNacimiento = reader.GetDateTime("fechaNacimiento"),
                                    Tutor = reader.GetString("tutor"),
                                    Telefono = reader.GetString("telefono")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al obtener los datos del alumno: " + ex.Message);
            }

            return alumno;
        }
    }
}
