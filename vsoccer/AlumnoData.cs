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
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Foto { get; set; }

        public static AlumnoData ObtenerDatosAlumno(int numcontrol)
        {
            // Creación del objeto de resultado
            AlumnoData alumno = null;

            // Consulta SQL para obtener los datos del alumno con JOIN entre `alumnos` y `usuarios`
            string sql = @"
                           SELECT 
                               a.numcontrol,
                               CONCAT(u.nombre, ' ', u.apellido1, ' ', IFNULL(u.apellido2, '')) AS nombreCompleto,
                               c.nombre AS categoria,
                               u.fechaNacimiento,
                               u.correo,
                               u.tel AS telefono,
                               u.foto
                           FROM alumnos a
                           INNER JOIN usuarios u ON a.id = u.id
                           LEFT JOIN categorias c ON a.id_categoria = c.id_categoria
                           WHERE a.numcontrol = 10";


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
                                    NombreCompleto = reader.GetString("nombreCompleto"),
                                    Categoria = reader["categoria"]?.ToString(),
                                    FechaNacimiento = reader.GetDateTime("fechaNacimiento"),
                                    
                                    Telefono = reader["telefono"]?.ToString(),
                                    Foto = reader["foto"]?.ToString()
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
