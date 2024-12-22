using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Total
    {
        public static List<Total_Cal_VO> Get_Total(params object[] parametros)
        {
            return DAL_Total.Get_Total(parametros);
        }
    }
}
