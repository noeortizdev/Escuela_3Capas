using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Configuracion
    {
        /** Cadena de Conexión.
         * Data Source => Nombre del servidor de la Base de Datos.
         *      User = Localhost.
         *      Password = .
         * Nombre de mi Instancia.
         * Initial Catalog = nombre de la BD.
         * Integrated Security = true (Credenciales de la máquina).
         * = false (Credenciales de acceso)
         * Se habilitan los campos de 
         *      User = ;
         *      Password = ;
         * */

        private static string _cadenaConexion = @"Data Source = THINKPAD-PC\SQLEXPRESS;
                                          Initial Catalog = Escuela;
                                          Integrated Security = true;";

        // ENCAPSULAMIENTO
        public static string CadenaConexion
        {
            get
            {
                return _cadenaConexion;
            }
        }
    }
}