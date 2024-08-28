using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class Customers
    {
        // Identificación única para cada cliente.
        public string CustomerID { get; set; }

        // Nombre de la empresa del cliente.
        public string CompanyName { get; set; }

        // Nombre de la persona de contacto en la empresa.
        public string ContactName { get; set; }

        // Título o cargo del contacto (por ejemplo, Gerente).
        public string ContactTitle { get; set; }

        // Dirección de la empresa.
        public string Address { get; set; }

        // Ciudad donde está la empresa.
        public string City { get; set; }

        // Región o estado, si aplica.
        public string Region { get; set; }

        // Código postal de la dirección.
        public string PostalCode { get; set; }

        // País donde se encuentra la empresa.
        public string Country { get; set; }

        // Número de teléfono de la empresa.
        public string Phone { get; set; }

        // Número de fax de la empresa (si tienen uno).
        public string Fax { get; set; }
    }

}
