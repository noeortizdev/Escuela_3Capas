using BLL;
using Escuela_3Capas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escuela_3Capas.Catalogos.Tutor
{
    public partial class Listado_Tutores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Utilizamos la variable "IsPostBack" para controlar la primera vez que carga la página.
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        private void CargarGrid()
        {
            // Cargar la información desde la BLL al GV.
            GVTutores.DataSource = BLL_Tutor.Get_Tutores();
            // Mostramos los resultados renderizando la información.
            GVTutores.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Formulario_Tutor.aspx");
        }

        protected void GVTutores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Recupero el ID del renglón afectado.
            int id_Tutor = int.Parse(GVTutores.DataKeys[e.RowIndex].Values["ID_Tutor"].ToString());
            // Invoco mi método para eliminar mi camión.
            string respuesta = BLL_Tutor.Eliminar_Tutor(id_Tutor);
            // Preparamos el Sweet Alert
            string titulo, msg, tipo;
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                titulo = "¡Error!";
                msg = respuesta;
                tipo = "error";
            }
            else
            {
                titulo = "¡Correcto!";
                msg = respuesta;
                tipo = "success";
            }

            // Sweet Alert.
            // Debemos importar el "using" de <NOMBRE_DE_TU_PROYECTO>.Utilidades".
            SweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
            // Recargamos la página.
            CargarGrid();
        }

        protected void GVTutores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Defino si el comando (el click que se detecta) tiene la propiedad "Select".
            if (e.CommandName == "Select")
            {
                // Recupero el índice en función de aquel elemento que haya detonado el evento.
                int varIndex = int.Parse(e.CommandArgument.ToString());
                // Recupero el ID en función del índice que recuperamos anteriormente.
                string id = GVTutores.DataKeys[varIndex].Values["ID_Tutor"].ToString();
                // Redirecciono al formulario de edición pasando como parámetro el ID.
                Response.Redirect($"Formulario_Tutor.aspx?Id={id}");
            }
        }

        protected void GVTutores_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVTutores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVTutores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}