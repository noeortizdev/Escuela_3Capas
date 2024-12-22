using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Total_Cal_VO
    {
        private string _ID_Calificacion;
        private string _Calificacion;
        private string _NombreEstudiante;
        private string _ApellidoPaterno;
        private string _ApellidoMaterno;
        private string _Grado;
        private string _Grupo;
        private string _NombreAsignatura;

        public string ID_Calificacion { get => _ID_Calificacion; set => _ID_Calificacion = value; }
        public string Calificacion { get => _Calificacion; set => _Calificacion = value; }
        public string NombreEstudiante { get => _NombreEstudiante; set => _NombreEstudiante = value; }
        public string ApellidoPaterno { get => _ApellidoPaterno; set => _ApellidoPaterno = value; }
        public string ApellidoMaterno { get => _ApellidoMaterno; set => _ApellidoMaterno = value; }
        public string Grado { get => _Grado; set => _Grado = value; }
        public string Grupo { get => _Grupo; set => _Grupo = value; }
        public string NombreAsignatura { get => _NombreAsignatura; set => _NombreAsignatura = value; }

        public Total_Cal_VO()
        {
            _ID_Calificacion = "";
            _Calificacion = "";
            _NombreEstudiante = "";
            _ApellidoPaterno = "";
            _ApellidoMaterno = "";
            _Grado = "";
            _Grupo = "";
            _NombreAsignatura = "";
        }

        public Total_Cal_VO(DataRow dr)
        {
            _ID_Calificacion = dr["ID_Calificacion"].ToString();
            _Calificacion = dr["Calificacion"].ToString();
            _NombreEstudiante = dr["NombreEstudiante"].ToString();
            _ApellidoPaterno = dr["ApellidoPaterno"].ToString();
            _ApellidoMaterno = dr["ApellidoMaterno"].ToString();
            _Grado = dr["Grado"].ToString();
            _Grupo = dr["Grupo"].ToString();
            _NombreAsignatura = dr["NombreAsignatura"].ToString();
        }
    }
}
