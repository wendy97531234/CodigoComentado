using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class CustomerRepository
    {
        // Método para obtener todos los clientes desde la base de datos.
        public List<Customers> ObtenerTodos()
        {
            using (var conexion = DataBase.GetSqlConnection())
            {

                // Cadena SQL que selecciona todos los campos de la tabla Customers.
                String selectFrom = "";
                selectFrom += "SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax] " + "\n";
                selectFrom += "  FROM [dbo].[Customers]";

                // Ejecuta la consulta y obtiene los resultados.
                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    SqlDataReader reader = comando.ExecuteReader();
                    List<Customers> Customers = new List<Customers>();

                    // Recorre los resultados y los convierte en objetos de tipo Customers.
                    while (reader.Read())
                    {
                        var customers = LeerDelDataReader(reader);
                        Customers.Add(customers);
                    }
                    return Customers; // Retorna la lista de clientes.
                }
            }
        }

        // Método para obtener un cliente específico por su ID.
        public Customers ObtenerPorID(string id)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {

                // Cadena SQL que selecciona un cliente específico por su ID.
                String selectForID = "";
                selectForID += "SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City], [Region], [PostalCode], [Country], [Phone], [Fax] " + "\n";
                selectForID += "  FROM [dbo].[Customers] " + "\n";
                selectForID += "  WHERE CustomerID = @customerId";

                // Ejecuta la consulta para el cliente con el ID proporcionado.
                using (SqlCommand comando = new SqlCommand(selectForID, conexion))
                {
                    comando.Parameters.AddWithValue("customerId", id);
                    var reader = comando.ExecuteReader();
                    Customers customers = null;

                    // Si encuentra el cliente, lo convierte en un objeto Customers.
                    if (reader.Read())
                    {
                        customers = LeerDelDataReader(reader);
                    }
                    return customers; // Retorna el cliente encontrado o null si no existe.
                }
            }
        }

        // Método que convierte un registro del DataReader en un objeto Customers.
        public Customers LeerDelDataReader(SqlDataReader reader)
        {
            Customers customers = new Customers();
            customers.CustomerID = reader["CustomerID"] == DBNull.Value ? " " : (String)reader["CustomerID"];
            customers.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (String)reader["CompanyName"];
            customers.ContactName = reader["ContactName"] == DBNull.Value ? "" : (String)reader["ContactName"];
            customers.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (String)reader["ContactTitle"];
            customers.Address = reader["Address"] == DBNull.Value ? "" : (String)reader["Address"];
            customers.City = reader["City"] == DBNull.Value ? "" : (String)reader["City"];
            customers.Region = reader["Region"] == DBNull.Value ? "" : (String)reader["Region"];
            customers.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (String)reader["PostalCode"];
            customers.Country = reader["Country"] == DBNull.Value ? "" : (String)reader["Country"];
            customers.Phone = reader["Phone"] == DBNull.Value ? "" : (String)reader["Phone"];
            customers.Fax = reader["Fax"] == DBNull.Value ? "" : (String)reader["Fax"];
            return customers; // Retorna el objeto Customers creado a partir del registro leído.
        }

        // Método para insertar un nuevo cliente en la base de datos.
        public int InsertarCliente(Customers customer)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Cadena SQL que inserta un nuevo registro en la tabla Customers.
                String insertInto = "";
                insertInto += "INSERT INTO [dbo].[Customers] ([CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City]) " + "\n";
                insertInto += "     VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City)";

                // Ejecuta el comando de inserción.
                using (var comando = new SqlCommand(insertInto, conexion))
                {
                    int insertados = parametrosCliente(customer, comando);
                    return insertados; // Retorna el número de registros insertados.
                }
            }
        }

        // Método para actualizar un cliente existente en la base de datos.
        public int ActualizarCliente(Customers customer)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Cadena SQL que actualiza un registro existente en la tabla Customers.
                String ActualizarCustomerPorID = "";
                ActualizarCustomerPorID += "UPDATE [dbo].[Customers] " + "\n";
                ActualizarCustomerPorID += "   SET [CustomerID] = @CustomerID, [CompanyName] = @CompanyName, [ContactName] = @ContactName, [ContactTitle] = @ContactTitle, [Address] = @Address, [City] = @City " + "\n";
                ActualizarCustomerPorID += " WHERE CustomerID = @CustomerID";

                // Ejecuta el comando de actualización.
                using (var comando = new SqlCommand(ActualizarCustomerPorID, conexion))
                {
                    int actualizados = parametrosCliente(customer, comando);
                    return actualizados; // Retorna el número de registros actualizados.
                }
            }
        }

        // Método auxiliar para añadir los parámetros del cliente a un SqlCommand.
        public int parametrosCliente(Customers customer, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("CustomerID", customer.CustomerID);
            comando.Parameters.AddWithValue("CompanyName", customer.CompanyName);
            comando.Parameters.AddWithValue("ContactName", customer.ContactName);
            comando.Parameters.AddWithValue("ContactTitle", customer.ContactTitle);
            comando.Parameters.AddWithValue("Address", customer.Address);
            comando.Parameters.AddWithValue("City", customer.City);
            var insertados = comando.ExecuteNonQuery();
            return insertados; // Ejecuta el comando y retorna el número de filas afectadas.
        }

        // Método para eliminar un cliente por su ID.
        public int EliminarCliente(string id)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Cadena SQL que elimina un registro de la tabla Customers basado en el ID.
                String EliminarCliente = "";
                EliminarCliente += "DELETE FROM [dbo].[Customers] WHERE CustomerID = @CustomerID";

                // Ejecuta el comando de eliminación.
                using (SqlCommand comando = new SqlCommand(EliminarCliente, conexion))
                {
                    comando.Parameters.AddWithValue("@CustomerID", id);
                    int eliminados = comando.ExecuteNonQuery();
                    return eliminados; // Retorna el número de registros eliminados.
                }
            }
        }
    }
}

