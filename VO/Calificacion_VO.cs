using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Calificacion_VO
    {
        // CAMPOS
        private int _ID_Calificacion;
        private double _Calificacion;
        private int _ID_Estudiante;
        private int _ID_Asignatura;

        // PROPIEDADES
        public int ID_Calificacion { get => _ID_Calificacion; set => _ID_Calificacion = value; }
        public double Calificacion_ { get => _Calificacion; set => _Calificacion = value; }
        public int ID_Estudiante { get => _ID_Estudiante; set => _ID_Estudiante = value; }
        public int ID_Asignatura { get => _ID_Asignatura; set => _ID_Asignatura = value; }

        // CONSTRUCTOR por defecto.
        public Calificacion_VO()
        {
            _ID_Calificacion = 0;
            _Calificacion = 0;
            _ID_Estudiante = 0;
            _ID_Asignatura = 0;
        }

        // CONSTRUCTOR con PARAMETROS, "DataRow" => Objeto ADO.
        public Calificacion_VO(DataRow dr)
        {
            _ID_Calificacion = int.Parse(dr["ID_Calificacion"].ToString());
            _Calificacion = double.Parse(dr["Calificacion"].ToString());
            _ID_Estudiante = int.Parse(dr["ID_Estudiante"].ToString());
            _ID_Asignatura = int.Parse(dr["ID_Asignatura"].ToString());
        }
    } // Fin de la CLASE "Calificacion".
} // Fin del "namespace VO".