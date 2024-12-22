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
    /// Descripción breve de WS_Calificaciones
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Calificaciones : System.Web.Services.WebService
    {
        // Create
        [WebMethod]
        public string Insertar_Calificacion(Calificacion_VO calificacion)
        {
            return BLL_Calificacion.Insertar_Calificacion(calificacion);
        }

        // Read
        [WebMethod]
        public List<Calificacion_VO> Get_Calificaciones(params object[] parametros)
        {
            return BLL_Calificacion.Get_Calificaciones(parametros);
        }

        // Update
        [WebMethod]
        public string Actualizar_Calificacion(Calificacion_VO Calificacion)
        {
            return BLL_Calificacion.Actualizar_Calificacion(Calificacion);
        }

        // Delete
        [WebMethod]
        public string Eliminar_Calificacion(int id)
        {
            return BLL_Calificacion.Eliminar_Calificacion(id);
        }
    }
}