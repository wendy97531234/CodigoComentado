using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DatosLayer
{
    // Esta clase 'DataBase' se encarga de manejar la conexión a la base de datos.
    public class DataBase
    {
        // La propiedad 'ConnectionString' es de tipo string y se encarga de generar 
        // la cadena de conexión a la base de datos. Esta cadena se construye usando
        // la configuración de la cadena de conexión definida en el archivo de configuración (app.config o web.config).
        public static string ConnectionString
        {
            get
            {
                // Se obtiene la cadena de conexión original desde la configuración.
                string CadenaConexion = ConfigurationManager
                    .ConnectionStrings["NWConnection"]
                    .ConnectionString;

                // Se utiliza SqlConnectionStringBuilder para modificar la cadena de conexión.
                SqlConnectionStringBuilder conexionBuilder =
                    new SqlConnectionStringBuilder(CadenaConexion);

                // Se asigna el nombre de la aplicación si está definido, 
                // de lo contrario, se mantiene el nombre de la aplicación original.
                conexionBuilder.ApplicationName =
                    ApplicationName ?? conexionBuilder.ApplicationName;

                // Se establece el tiempo de espera para la conexión, si es mayor a 0.
                // Si no se define un valor, se mantiene el valor predeterminado.
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0)
                    ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                // Se devuelve la cadena de conexión resultante.
                return conexionBuilder.ToString();
            }
        }

        // Propiedad estática para definir el tiempo de espera para la conexión.
        public static int ConnectionTimeout { get; set; }

        // Propiedad estática para definir el nombre de la aplicación que se conectará a la base de datos.
        public static string ApplicationName { get; set; }

        // Método estático que devuelve una instancia de SqlConnection abierta.
        public static SqlConnection GetSqlConnection()
        {
            // Se crea una nueva conexión SQL usando la cadena de conexión generada anteriormente.
            SqlConnection conexion = new SqlConnection(ConnectionString);

            // Se abre la conexión.
            conexion.Open();

            // Se devuelve la conexión abierta.
            return conexion;
        }
    }
}
