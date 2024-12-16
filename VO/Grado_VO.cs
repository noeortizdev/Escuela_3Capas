using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Grado_VO
    {
        private int _ID_Grado;
        private string _Grado;
        private string _Grupo;
        private int _ID_Profesor;

        public int ID_Grado { get => _ID_Grado; set => _ID_Grado = value; }
        public string Grado { get => _Grado; set => _Grado = value; }
        public string Grupo { get => _Grupo; set => _Grupo = value; }
        public int ID_Profesor { get => _ID_Profesor; set => _ID_Profesor = value; }

        public Grado_VO()
        {
            _ID_Grado = 0;
            _Grado = "";
            _Grupo = "";
            _ID_Profesor = 0;
        }

        public Grado_VO(DataRow dr)
        {
            _ID_Grado = int.Parse(dr["ID_Grado"].ToString());
            _Grado = dr["Grado"].ToString();
            _Grupo = dr["Grupo"].ToString();
            _ID_Profesor = int.Parse(dr["ID_Profesor"].ToString());
        }
    } // Fin de la CLASE "Grado".
} // Fin del "namespace VO".