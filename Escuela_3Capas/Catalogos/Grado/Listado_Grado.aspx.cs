using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escuela_3Capas.Catalogos.Grado
{
    public partial class Listado_Grado : System.Web.UI.Page
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
            GVGrados.DataSource = BLL_Grado.Get_Grados();
            GVGrados.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Formulario_Grado.aspx");
        }

        protected void GVGrados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int varIndex = int.Parse(e.CommandArgument.ToString());
                string id = GVGrados.DataKeys[varIndex].Values["ID_Grado"].ToString();

                Response.Redirect($"Formulario_Grado.aspx?Id={id}");
            }
        }

        protected void GVGrados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idGrado = int.Parse(GVGrados.DataKeys[e.RowIndex].Values["ID_Grado"].ToString());
            string respuesta = BLL_Grado.Eliminar_Grado(idGrado);
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

        protected void GVGrados_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVGrados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVGrados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}