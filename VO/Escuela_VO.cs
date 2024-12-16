using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Escuela_VO
    {
        // VO => View Object
        // Representación de una tabla a nivel de código de C#.
        private int _ID_Escuela;
        private string _Nombre;
        private string _Clave;
        private string _Telefono;
        private string _Nivel;
        private string _Direccion;
        private string _FechaFundacion;

        // PROPIEDADES.
        public int ID_Escuela { get => _ID_Escuela; set => _ID_Escuela = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Clave { get => _Clave; set => _Clave = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Nivel { get => _Nivel; set => _Nivel = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string FechaFundacion { get => _FechaFundacion; set => _FechaFundacion = value; }

        // CONSTRUCTO por defecto.
        public Escuela_VO()
        {
            _ID_Escuela = 0;
            _Nombre = "";
            _Clave = "";
            _Telefono = "";
            _Nivel = "";
            _Direccion = "";
            _FechaFundacion = "";
        }

        // CONSTRUCTOR con PARAMETROS "DataRow" => Objeto ADO.
        public Escuela_VO(DataRow dr)
        {
            _ID_Escuela = int.Parse(dr["ID_Escuela"].ToString());
            _Nombre = dr["Nombre"].ToString();
            _Clave = dr["Clave"].ToString();
            _Telefono = dr["Telefono"].ToString();
            _Nivel = dr["Nivel"].ToString();
            _Direccion = dr["Direccion"].ToString();
            _FechaFundacion = dr["FechaFundacion"].ToString();
        }
    } // Fin de la CLASE "Escuela_VO".
} // Fin del "namespace VO".