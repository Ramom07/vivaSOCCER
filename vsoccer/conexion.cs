using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;

namespace vsoccer
{
     class Conexion : IDisposable
    {
        private MySqlConnection conexionBD;
       
            //Constructor para inicializar cadena para servidor
            public Conexion()
            {
                string servidor = "server = localhost; database=vsoccer; Uid = root; pwd=pokechon";
                conexionBD = new MySqlConnection(servidor);
            }

        //Método para abrir la conexión
        public MySqlConnection AbrirConexion()
        {
            try
            {
                if (conexionBD.State == System.Data.ConnectionState.Closed) conexionBD.Open();
                return conexionBD;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al abrir la conexion: " + e.Message + "\n" + e.StackTrace);
                return null;
            }
        }

        //Método para cerrar conexión
        public void CerrarConexion()
        {
            try
            {
                if (conexionBD.State == System.Data.ConnectionState.Open)
                    conexionBD.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cerrar la conexion: " + e.Message + "\n" + e.StackTrace);
            }
        }

        public void Dispose()
        {
            CerrarConexion();
        }





    }
}
