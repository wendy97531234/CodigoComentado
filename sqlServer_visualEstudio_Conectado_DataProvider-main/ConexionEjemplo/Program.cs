using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionEjemplo
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configura la aplicación para usar estilos visuales modernos de Windows.
            Application.EnableVisualStyles();

            // Establece la compatibilidad de renderizado de texto para mejorar la calidad visual.
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la ejecución de la aplicación y muestra la ventana principal (Form1).
            Application.Run(new Form1());
        }
    }

}
