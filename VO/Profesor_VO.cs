using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Profesor_VO
    {
        private int _ID_Profesor;
        private string _Nombre;
        private string _APaterno;
        private string _AMaterno;
        private string _CURP;
        private string _Sexo;
        private string _Telefono;
        private string _FechaNacimiento;

        public int ID_Profesor { get => _ID_Profesor; set => _ID_Profesor = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string APaterno { get => _APaterno; set => _APaterno = value; }
        public string AMaterno { get => _AMaterno; set => _AMaterno = value; }
        public string CURP { get => _CURP; set => _CURP = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }

        public Profesor_VO()
        {
            _ID_Profesor = 0;
            _Nombre = "";
            _APaterno = "";
            _AMaterno = "";
            _CURP = "";
            _Sexo = "";
            _Telefono = "";
            _FechaNacimiento = "";
        }

        public Profesor_VO(DataRow dr)
        {
            _ID_Profesor = int.Parse(dr["ID_Profesor"].ToString());
            _Nombre = dr["Nombre"].ToString();
            _APaterno = dr["APaterno"].ToString();
            _AMaterno = dr["AMaterno"].ToString();
            _CURP = dr["CURP"].ToString();
            _Sexo = dr["Sexo"].ToString();
            _Telefono = dr["Telefono"].ToString();
            _FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()).ToShortDateString();
        }
    } // Fin de la CLASE "Profesor".
} // Fin del "namespace VO".