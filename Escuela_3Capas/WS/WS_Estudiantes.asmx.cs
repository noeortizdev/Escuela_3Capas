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
    /// Descripción breve de WS_Estudiantes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_Estudiantes : System.Web.Services.WebService
    {

        [WebMethod]
        // Create
        public string Insertar_Estudiante(Estudiante_VO estudiante)
        {
            return BLL_Estudiante.Insertar_Estudiante(estudiante);
        }

        [WebMethod]
        // Read
        public List<Estudiante_VO> Get_Estudiantes(params object[] parametros)
        {
            return BLL_Estudiante.Get_Estudiantes(parametros);
        }

        [WebMethod]
        // Update
        public string Actualizar_Estudiante(Estudiante_VO estudiante)
        {
            return BLL_Estudiante.Actualizar_Estudiante(estudiante);
        }

        [WebMethod]
        // Delete
        public string Eliminar_Estudiante(int id)
        {
            return BLL_Estudiante.Eliminar_Estudiante(id);
        }
    }
}