using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Calificacion
    {
        // Create
        public static string Insertar_Calificacion(Calificacion_VO calificacion)
        {
            return DAL_Calificacion.Insertar_Calificacion(calificacion);
        }

        // Read
        public static List<Calificacion_VO> Get_Calificaciones(params object[] parametros)
        {
            return DAL_Calificacion.Get_Calificaciones(parametros);
        }

        // Update
        public static string Actualizar_Calificacion(Calificacion_VO Calificacion)
        {
            return DAL_Calificacion.Actualizar_Calificacion(Calificacion);
        }

        // Delete
        public static string Eliminar_Calificacion(int id)
        {
            return DAL_Calificacion.Eliminar_Calificacion(id);
        }
    }
}