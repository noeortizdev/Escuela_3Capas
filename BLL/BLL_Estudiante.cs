using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Estudiante
    {
        // Create
        public static string Insertar_Estudiante(Estudiante_VO estudiante)
        {
            return DAL_Estudiante.Insertar_Estudiante(estudiante);
        }

        // Read
        public static List<Estudiante_VO> Get_Estudiantes(params object[] parametros)
        {
            return DAL_Estudiante.Get_Estudiantes(parametros);
        }

        // Update
        public static string Actualizar_Escuela(Estudiante_VO estudiante)
        {
            return DAL_Estudiante.Actualizar_Estudiante(estudiante);
        }

        // Delete
        public static string Eliminar_Estudiante(int id)
        {
            return DAL_Estudiante.Eliminar_Estudiante(id);
        }
    }
}