using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Asignatura_VO
    {
        private int _ID_Asignatura;
        private string _Nombre;

        public int ID_Asignatura { get => _ID_Asignatura; set => _ID_Asignatura = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }

        public Asignatura_VO()
        {
            _ID_Asignatura = 0;
            _Nombre = "";
        }

        public Asignatura_VO(DataRow dr)
        {
            _ID_Asignatura = int.Parse(dr["ID_Asignatura"].ToString());
            _Nombre = dr["Nombre"].ToString();
        }
    } // Fin de la CLASE "Asignatura".
} // Fin del "namespace VO".