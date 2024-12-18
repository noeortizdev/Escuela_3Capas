using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Grado
    {
        // Create
        public static string Insertar_Grado(Grado_VO grado)
        {
            return DAL_Grado.Insertar_Grado(grado);
        }

        // Read
        public static List<Grado_VO> Get_Grados(params object[] parametros)
        {
            return DAL_Grado.Get_Grados(parametros);
        }

        // Update
        public static string Actualizar_Grado(Grado_VO grado)
        {
            return DAL_Grado.Actualizar_Grado(grado);
        }

        // Delete
        public static string Eliminar_Grado(int id)
        {
            return DAL_Grado.Eliminar_Grado(id);
        }
    }
}