using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Total
    {
        public static List<Total_Cal_VO> Get_Total(params object[] parametros)
        {
            // Creo una lista de objetos VO
            List<Total_Cal_VO> list = new List<Total_Cal_VO>();
            try
            {
                // Creo un DataSet el cuál recibirá lo que devuelva la ejecución del método "execute_DataSet" de la clase "metodos_datos".
                DataSet ds_Total = Metodos_Datos.Execute_DataSet("SP_CalTotal", parametros);
                // Recorro cada renglón existente de nuestro "ds" creando objetos del tipo VO y añadiendo a la lista.
                foreach (DataRow dr in ds_Total.Tables[0].Rows)
                {
                    list.Add(new Total_Cal_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
