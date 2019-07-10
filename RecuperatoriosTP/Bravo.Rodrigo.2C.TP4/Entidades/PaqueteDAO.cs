using System;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        public delegate void DelegadoDB(string mensaje);
        public static event DelegadoDB eventoDB;
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Constructor static de PaqueteDAO, inicializa la conexion con la base de datos
        /// </summary>
        static PaqueteDAO()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog =correo-sp-2017; Integrated Security = True";
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.conexion = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Guarda los datos del paquete en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insetar(Paquete p)
        {
            string query = $"INSERT INTO Paquetes(direccionEntrega, trackingID, alumno) values('{p.DireccionEntrega}', '{p.TrackingID}', 'Bravo.Rodrigo')";
            try
            {
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando = new SqlCommand(query, PaqueteDAO.conexion);
                if (PaqueteDAO.comando.ExecuteNonQuery() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                PaqueteDAO.eventoDB("No se pudo insertar registro en base de datos");
                return false;
            }
            finally
            {
                PaqueteDAO.conexion.Close();
            }
        }
    }
}
