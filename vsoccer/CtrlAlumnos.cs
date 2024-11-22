using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace vsoccer
{
    class CtrlAlumnos : Conexion
    {
        //lista de alumnos
        public List<Alumno> consulta(string dato)
        {
            List<Alumno> lista = new List<Alumno>();

            // Consulta SQL más compleja con múltiples JOIN
            string sql = @"
    SELECT 
        a.numcontrol AS Id,
        u.nombre AS Nombre,
        u.apellido1 AS Apellido1,
        u.apellido2 AS Apellido2,
        c.nombre AS Categoria,
        u.fechaNacimiento AS FechaNac,
        CONCAT(t.nombre, ' ', t.apellido1, ' ', t.apellido2) AS Tutor,
        t.tel AS Telefono
    FROM
        alumno_tutor at
    JOIN
        alumnos a ON at.numcontrol = a.numcontrol
    JOIN
        usuarios u ON a.id = u.id
    LEFT JOIN
        categorias c ON a.id_categoria = c.id_categoria  
    JOIN
        tutores tu ON at.id_tutor = tu.id_tutor
    JOIN
        usuarios t ON tu.idusuario = t.id
    ";

            // Si dato no es null o vacío, agregar un filtro de búsqueda
            if (!string.IsNullOrEmpty(dato))
            {
                sql += " WHERE u.nombre LIKE @dato OR u.apellido1 LIKE @dato OR u.apellido2 LIKE @dato";
            }

            try
            {
                using (MySqlConnection conexionBD = new Conexion().AbrirConexion())
                {
                    using (MySqlCommand comando = new MySqlCommand(sql, conexionBD))
                    {
                        if (!string.IsNullOrEmpty(dato))
                        {
                            comando.Parameters.AddWithValue("@dato", "%" + dato + "%");
                        }

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Alumno alumno = new Alumno
                                {
                                    Id = reader.GetInt32("Id"),
                                    Nombre = reader.GetString("Nombre"),
                                    Apellido1 = reader.GetString("Apellido1"),
                                    Apellido2 = reader.GetString("Apellido2"),
                                    Categoria = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? null : reader.GetString("Categoria"),
                                    FechaNac = reader.GetDateTime("FechaNac"),
                                    Tutor = reader.GetString("Tutor"),
                                    
                                };
                                lista.Add(alumno);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lista;
        }
        

        public List<Alumno> consultaPorCategoria(string dato)
        {
            List<Alumno> lista = new List<Alumno>();

            // Consulta SQL con JOIN y filtro de categoría
            string sql = @"
    SELECT 
        a.numcontrol AS Id,
        u.nombre AS Nombre,
        u.apellido1 AS Apellido1,
        u.apellido2 AS Apellido2,
        c.nombre AS Categoria,
        u.fechaNacimiento AS FechaNac,
        CONCAT(t.nombre, ' ', t.apellido1, ' ', t.apellido2) AS Tutor,
        t.tel AS Telefono
    FROM
        alumno_tutor at
    JOIN
        alumnos a ON at.numcontrol = a.numcontrol
    JOIN
        usuarios u ON a.id = u.id
    LEFT JOIN
        categorias c ON a.id_categoria = c.id_categoria  
    JOIN
        tutores tu ON at.id_tutor = tu.id_tutor
    JOIN
        usuarios t ON tu.idusuario = t.id
    ";

            // Si dato no es null o vacío, agregar un filtro de búsqueda por nombre
            if (!string.IsNullOrEmpty(dato))
            {
                sql += " WHERE u.nombre LIKE @dato OR u.apellido1 LIKE @dato OR u.apellido2 LIKE @dato";
            }

            // Agregar filtro de categoría si se seleccionó una categoría específica
            if (!string.IsNullOrEmpty(dato))
            {
                sql += " AND c.nombre LIKE @categoria";
            }

            try
            {
                using (MySqlConnection conexionBD = new Conexion().AbrirConexion())
                {
                    using (MySqlCommand comando = new MySqlCommand(sql, conexionBD))
                    {
                        if (!string.IsNullOrEmpty(dato))
                        {
                            comando.Parameters.AddWithValue("@dato", "%" + dato + "%");
                        }
                        if (!string.IsNullOrEmpty(dato))  // Filtro por categoría
                        {
                            comando.Parameters.AddWithValue("@categoria", "%" + dato + "%");
                        }

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Alumno alumno = new Alumno
                                {
                                    Id = reader.GetInt32("Id"),
                                    Nombre = reader.GetString("Nombre"),
                                    Apellido1 = reader.GetString("Apellido1"),
                                    Apellido2 = reader.GetString("Apellido2"),
                                    Categoria = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? null : reader.GetString("Categoria"),
                                    FechaNac = reader.GetDateTime("FechaNac"),
                                    Tutor = reader.GetString("Tutor"),
                                };
                                lista.Add(alumno);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lista;
        }

        


    }
}
