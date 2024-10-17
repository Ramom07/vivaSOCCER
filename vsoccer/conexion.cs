using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace vsoccer
{
    internal class conexion
    {
        //Método para abrir conexión
        public static MySqlConnection conex()
        {
            //declaración de cadena para servidor
            string servidor = "server = localhost; database=vsoccer; Uid = root; pwd=pokechon";

            //Creación de instancia de la clase MySqlConnection
            MySqlConnection conexionBD = new MySqlConnection(servidor);
            try
            {
                //devolución de conexión creada
                return conexionBD;
            }
            catch (Exception e)
            {
                // si ocurre excepción muestra mensaje
                MessageBox.Show(e.Message+e.StackTrace);
                return null;
            }

            
        }
    }
}
