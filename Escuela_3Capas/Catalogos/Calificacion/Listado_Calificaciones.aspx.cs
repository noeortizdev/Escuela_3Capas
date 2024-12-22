using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escuela_3Capas.Catalogos.Calificacion
{
    public partial class Listado_Calificaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        private void CargarGrid()
        {
            GVCalificaciones.DataSource = BLL_Calificacion.Get_Calificaciones();
            GVCalificaciones.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Formulario_Calificacion.aspx");
        }

        protected void GVCalificaciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idCalificacion = int.Parse(GVCalificaciones.DataKeys[e.RowIndex].Values["ID_Calificacion"].ToString());
            string respuesta = BLL_Calificacion.Eliminar_Calificacion(idCalificacion);
            string titulo, msg, tipo;
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                titulo = "¡Ops!...";
                msg = respuesta;
                tipo = "error";
            }
            else
            {
                titulo = "¡Correcto!";
            }
            CargarGrid();
        }

        protected void GVCalificaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int varIndex = int.Parse(e.CommandArgument.ToString());
                string id = GVCalificaciones.DataKeys[varIndex].Values["ID_Calificacion"].ToString();

                Response.Redirect($"Formulario_Calificacion.aspx?Id={id}");
            }
        }

        protected void GVCalificaciones_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVCalificaciones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVCalificaciones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}