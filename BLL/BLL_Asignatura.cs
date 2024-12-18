using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Asignatura
    {
        // Create
        public static string Insertar_Asignatura(Asignatura_VO asignatura)
        {
            return DAL_Asignatura.Insertar_Asignatura(asignatura);
        }

        // Read
        public static List<Asignatura_VO> Get_Asignaturas(params object[] parametros)
        {
            return DAL_Asignatura.Get_Asignaturas(parametros);
        }

        // Update
        public static string Actualizar_Asignatura(Asignatura_VO asignatura)
        {
            return DAL_Asignatura.Actualizar_Asignatura(asignatura);
        }

        // Delete
        public static string Eliminar_Asignatura(int id)
        {
            return DAL_Asignatura.Eliminar_Asignatura(id);
        }
    }
}