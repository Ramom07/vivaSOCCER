using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace vsoccer
{
    class CtrlAlumnos : Conexion
    {
        public List<Alumno> consulta(string dato)
        {
            MySqlDataReader reader;
            List<Alumno> lista = new List<Alumno>();
            string sql;

            // Consulta SQL con filtro según el dato proporcionado
            if (string.IsNullOrEmpty(dato))
            {
                sql = @"
                SELECT 
                    a.numcontrol, 
                    CONCAT(u.nombre, ' ', u.apellido1, ' ', u.apellido2) AS nombre_completo_alumno, 
                    c.nombre AS categoria_alumno,  -- Cambié 'a.categoria' por 'c.nombre' (de la tabla categorias)
                    u.fechaNacimiento,
                    CONCAT(t.nombre, ' ', t.apellido1, ' ', t.apellido2) AS nombre_completo_tutor,
                    t.tel
                FROM
                    alumno_tutor at
                JOIN
                    alumnos a ON at.numcontrol = a.numcontrol
                JOIN
                    usuarios u ON a.id = u.id
                LEFT JOIN
                    categorias c ON a.id_categoria = c.id_categoria  -- LEFT JOIN para obtener la categoría del alumno
                JOIN
                    tutores tu ON at.id_tutor = tu.id_tutor
                JOIN
                    usuarios t ON tu.idusuario = t.id;
                ";
            }
            else
            {
                sql = @"
                SELECT 
                    a.numcontrol, 
                    CONCAT(u.nombre, ' ', u.apellido1, ' ', u.apellido2) AS nombre_completo_alumno, 
                    c.nombre AS categoria_alumno,  -- Cambié 'a.categoria' por 'c.nombre'
                    u.fechaNacimiento,
                    CONCAT(t.nombre, ' ', t.apellido1, ' ', t.apellido2) AS nombre_completo_tutor,
                    t.tel
                FROM
                    alumno_tutor at
                JOIN
                    alumnos a ON at.numcontrol = a.numcontrol
                JOIN
                    usuarios u ON a.id = u.id
                LEFT JOIN
                    categorias c ON a.id_categoria = c.id_categoria  -- LEFT JOIN para obtener la categoría del alumno
                JOIN
                    tutores tu ON at.id_tutor = tu.id_tutor
                JOIN
                    usuarios t ON tu.idusuario = t.id
                WHERE
                    CONCAT(u.nombre, ' ', u.apellido1, ' ', u.apellido2) LIKE @dato;
                ";
            }

            try
            {
                // Abrir conexión
                using (MySqlConnection conexionBD = AbrirConexion())
                {
                    if (conexionBD != null)
                    {
                        using (MySqlCommand comando = new MySqlCommand(sql, conexionBD))
                        {
                            // Asignar parámetro de búsqueda si se proporciona un dato
                            if (!string.IsNullOrEmpty(dato))
                            {
                                comando.Parameters.AddWithValue("@dato", "%" + dato + "%");
                            }

                            reader = comando.ExecuteReader();

                            while (reader.Read())
                            {
                                Alumno _alumno = new Alumno
                                {
                                    Id = int.Parse(reader["numcontrol"].ToString()), // Asegúrate de que 'numcontrol' es el ID correcto
                                    Nombre = reader["nombre_completo_alumno"].ToString(),
                                    Categoria = reader["categoria_alumno"].ToString(), // Ahora se usa 'categoria_alumno' que proviene de la tabla 'categorias'
                                    Tutor = reader["nombre_completo_tutor"].ToString(),
                                    Telefono = reader["tel"].ToString() // Cambia aquí si es necesario
                                };

                                lista.Add(_alumno);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se pudo establecer conexión.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return lista;
        }
    }
}
