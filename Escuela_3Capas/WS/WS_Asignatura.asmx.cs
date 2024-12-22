using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using VO;

namespace Escuela_3Capas.WS
{
    /// <summary>
    /// Descripción breve de WS_Asignatura
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Asignatura : System.Web.Services.WebService
    {

        // Create
        [WebMethod]
        public string Insertar_Asignatura(Asignatura_VO asignatura)
        {
            return BLL_Asignatura.Insertar_Asignatura(asignatura);
        }

        // Read
        [WebMethod]
        public List<Asignatura_VO> Get_Asignaturas(params object[] parametros)
        {
            return BLL_Asignatura.Get_Asignaturas(parametros);
        }

        // Update
        [WebMethod]
        public string Actualizar_Asignatura(Asignatura_VO asignatura)
        {
            return BLL_Asignatura.Actualizar_Asignatura(asignatura);
        }

        // Delete
        [WebMethod]
        public string Eliminar_Asignatura(int id)
        {
            return BLL_Asignatura.Eliminar_Asignatura(id);
        }
    }
}
