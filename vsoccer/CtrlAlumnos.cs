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
        public List<Object> consulta(string dato)
        {
            MySqlDataReader reader;
            List<object> lista = new List<object>();
            string sql;

            //consulta sql con filtro segun dato
            if (string.IsNullOrEmpty(dato))
            {

                sql = @"
        SELECT 
            a.numcontrol, 
            CONCAT(u.nombre, ' ', u.apellido1, ' ', u.apellido2) AS nombre_completo_alumno, 
            a.categoria, 
            u.fechaNacimiento,
            CONCAT(t.nombre, ' ', t.apellido1, ' ', t.apellido2) AS nombre_completo_tutor,
            t.tel
        FROM
            alumno_tutor at
        JOIN
            alumnos a ON at.numcontrol = a.numcontrol
        JOIN
            usuarios u ON a.id = u.id
        JOIN
            tutores tu ON at.idtutor = tu.idtutor
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
                    a.categoria, 
                    u.fechaNacimiento,
                    CONCAT(t.nombre, ' ', t.apellido1, ' ', t.apellido2) AS nombre_completo_tutor,
                    t.tel
                FROM
                    alumno_tutor at
                JOIN
                    alumnos a ON at.numcontrol = a.numcontrol
                JOIN
                    usuarios u ON a.id = u.id
                JOIN
                    tutores tu ON at.idtutor = tu.idtutor
                JOIN
                    usuarios t ON tu.idusuario = t.id 
                WHERE
                    CONCAT(u.nombre, ' ', u.apellido1, ' ', u.apellido2) LIKE @dato;
                ";
            }


            try
            {
                //Abrir conexion
                using (MySqlConnection conexionBD = AbrirConexion())
                {
                    if (conexionBD != null)
                    {
                        using (MySqlCommand comando = new MySqlCommand(sql, conexionBD))
                        {
                            //Asogmar parametro de busqueda si se proporciona un dato
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
                                    Categoria = reader["categoria"].ToString(),
                                    Tutor = reader["nombre_completo_tutor"].ToString(),
                                    Telefono = reader["tel"].ToString() // Cambia aquí si es necesario
                                };

                                lista.Add(_alumno);
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine("No se pudo establecer conexion");
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
