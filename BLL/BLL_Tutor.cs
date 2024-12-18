using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Tutor
    {
        // Create
        public static string Insertar_Tutor(Tutor_VO tutor)
        {
            return DAL_Tutor.Insertar_Tutor(tutor);
        }

        // Read
        public static List<Tutor_VO> Get_Tutores(params object[] parametros)
        {
            return DAL_Tutor.Get_Tutores(parametros);
        }

        // Update
        public static string Actualizar_Tutor(Tutor_VO tutor)
        {
            return DAL_Tutor.Actualizar_Tutor(tutor);
        }

        // Delete
        public static string Eliminar_Tutor(int id)
        {
            return DAL_Tutor.Eliminar_Tutor(id);
        }
    }
}