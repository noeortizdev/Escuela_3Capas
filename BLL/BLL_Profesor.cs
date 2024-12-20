using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Profesor
    {
        // Create
        public static string Insertar_Profesor(Profesor_VO profesor)
        {
            return DAL_Profesor.Insertar_Profesor(profesor);
        }

        // Read
        public static List<Profesor_VO> Get_Profesores(params object[] parametros)
        {
            return DAL_Profesor.Get_Profesores(parametros);
        }

        // Update
        public static string Actualizar_Profesor(Profesor_VO profesor)
        {
            return DAL_Profesor.Actualizar_Profesor(profesor);
        }

        // Delete
        public static string Eliminar_Profesor(int id)
        {
            return DAL_Profesor.Eliminar_Profesor(id);
        }
    }
}