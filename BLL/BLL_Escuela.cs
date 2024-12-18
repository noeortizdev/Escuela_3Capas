using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Escuela
    {
        // Create
        public static string Insertar_Escuela(Escuela_VO camion)
        {
            return DAL_Escuela.Insertar_Escuela(camion);
        }

        // Read
        public static List<Escuela_VO> Get_Escuelas(params object[] parametros)
        {
            return DAL_Escuela.Get_Escuelas(parametros);
        }

        // Update
        public static string Actualizar_Escuela(Escuela_VO camion)
        {
            return DAL_Escuela.Actualizar_Escuela(camion);
        }

        // Delete
        public static string Eliminar_Escuela(int id)
        {
            return DAL_Escuela.Eliminar_Escuela(id);
        }
    }
}