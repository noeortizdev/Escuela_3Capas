using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Tutor_VO
    {
        private int _ID_Tutor;
        private string _Nombre;
        private string _APaterno;
        private string _AMaterno;
        private string _CURP;
        private string _Sexo;
        private string _Telefono;
        private string _Parentesco;
        private string _Direccion;
        private string _FechaNacimiento;
        private int _ID_Estudiante;

        public int ID_Tutor { get => _ID_Tutor; set => _ID_Tutor = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string APaterno { get => _APaterno; set => _APaterno = value; }
        public string AMaterno { get => _AMaterno; set => _AMaterno = value; }
        public string CURP { get => _CURP; set => _CURP = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Parentesco { get => _Parentesco; set => _Parentesco = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public int ID_Estudiante { get => _ID_Estudiante; set => _ID_Estudiante = value; }

        public Tutor_VO()
        {
            _ID_Tutor = 0;
            _Nombre = "";
            _APaterno = "";
            _AMaterno = "";
            _CURP = "";
            _Sexo = "";
            _Telefono = "";
            _Parentesco = "";
            _Direccion = "";
            _FechaNacimiento = "";
            _ID_Estudiante = 0;
        }

        public Tutor_VO(DataRow dr)
        {
            _ID_Tutor = int.Parse(dr["ID_Tutor"].ToString());
            _Nombre = dr["Nombre"].ToString();
            _APaterno = dr["APaterno"].ToString();
            _AMaterno = dr["AMaterno"].ToString();
            _CURP = dr["CURP"].ToString();
            _Sexo = dr["Sexo"].ToString();
            _Telefono = dr["Telefono"].ToString();
            _Parentesco = dr["Parentesco"].ToString();
            _Direccion = dr["Direccion"].ToString();
            _FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()).ToShortDateString();
            _ID_Estudiante = int.Parse(dr["ID_Estudiante"].ToString());
        }
    } // Fin de la CLASE "Tutor_VO".
} // Fin del "namespace VO".