using BLL;
using Escuela_3Capas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escuela_3Capas.Catalogos.Profesor
{
    public partial class Listado_Profesores : System.Web.UI.Page
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
            GVProfesores.DataSource = BLL_Profesor.Get_Profesores();
            // Mostramos los resultados renderizando la información.
            GVProfesores.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Formulario_Profesor.aspx");
        }

        protected void GVProfesores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Recupero el ID del renglón afectado.
            int id_Profesor = int.Parse(GVProfesores.DataKeys[e.RowIndex].Values["ID_Profesor"].ToString());
            // Invoco mi método para eliminar mi camión.
            string respuesta = BLL_Profesor.Eliminar_Profesor(id_Profesor);
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

        protected void GVProfesores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Defino si el comando (el click que se detecta) tiene la propiedad "Select".
            if (e.CommandName == "Select")
            {
                // Recupero el índice en función de aquel elemento que haya detonado el evento.
                int varIndex = int.Parse(e.CommandArgument.ToString());
                // Recupero el ID en función del índice que recuperamos anteriormente.
                string id = GVProfesores.DataKeys[varIndex].Values["ID_Profesor"].ToString();
                // Redirecciono al formulario de edición pasando como parámetro el ID.
                Response.Redirect($"Formulario_Profesor.aspx?Id={id}");
            }
        }

        protected void GVProfesores_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVProfesores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVProfesores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}