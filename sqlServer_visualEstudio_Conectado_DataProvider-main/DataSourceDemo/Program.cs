using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceDemo
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// Este método es el primer lugar donde el código de la aplicación comienza a ejecutarse.
        /// </summary>
        [STAThread] // Indica que la aplicación usa el modelo de subprocesamiento de un solo apartamento.
        static void Main()
        {
            // Habilita estilos visuales para la aplicación. Esto permite que la aplicación tenga un aspecto moderno y consistente con el sistema operativo.
            Application.EnableVisualStyles();

            // Establece que la aplicación utilice un método de renderizado de texto compatible, necesario para algunas configuraciones de visualización.
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la aplicación y muestra el formulario principal (Form2).
            Application.Run(new Form2());
        }
    }
}
