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
    /// Descripción breve de WS_Profesor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Profesor : System.Web.Services.WebService
    {
        // Create
        [WebMethod]
        public string Insertar_Profesor(Profesor_VO profesor)
        {
            return BLL_Profesor.Insertar_Profesor(profesor);
        }

        // Read
        [WebMethod]
        public List<Profesor_VO> Get_Profesores(params object[] parametros)
        {
            return BLL_Profesor.Get_Profesores(parametros);
        }

        // Update
        [WebMethod]
        public string Actualizar_Profesor(Profesor_VO profesor)
        {
            return BLL_Profesor.Actualizar_Profesor(profesor);
        }

        // Delete
        [WebMethod]
        public string Eliminar_Profesor(int id)
        {
            return BLL_Profesor.Eliminar_Profesor(id);
        }
    }
}
