using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Estudiante_VO
    {
        private int _ID_Estudiante;
        private string _Nombre;
        private string _APaterno;
        private string _AMaterno;
        private string _CURP;
        private string _Sexo;
        private string _Telefono;
        private string _Direccion;
        private string _FechaNacimiento;
        private int _ID_Grado;

        public int ID_Estudiante { get => _ID_Estudiante; set => _ID_Estudiante = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string APaterno { get => _APaterno; set => _APaterno = value; }
        public string AMaterno { get => _AMaterno; set => _AMaterno = value; }
        public string CURP { get => _CURP; set => _CURP = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public int ID_Grado { get => _ID_Grado; set => _ID_Grado = value; }

        public Estudiante_VO()
        {
            _ID_Estudiante = 0;
            _Nombre = "";
            _APaterno = "";
            _AMaterno = "";
            _CURP = "";
            _Sexo = "";
            _Telefono = "";
            _Direccion = "";
            _FechaNacimiento = "";
            _ID_Grado = 0;
        }

        public Estudiante_VO(DataRow dr)
        {
            _ID_Estudiante = int.Parse(dr["ID_Estudiante"].ToString());
            _Nombre = dr["Nombre"].ToString();
            _APaterno = dr["APaterno"].ToString();
            _AMaterno = dr["AMaterno"].ToString();
            _CURP = dr["CURP"].ToString();
            _Sexo = dr["Sexo"].ToString();
            _Telefono = dr["Telefono"].ToString();
            _Direccion = dr["Direccion"].ToString();
            _FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()).ToShortDateString();
            _ID_Grado = int.Parse(dr["ID_Grado"].ToString());
        }
    } // Fin de la CLASE "Estudiante_VO".
} // Fin del "namespace VO".