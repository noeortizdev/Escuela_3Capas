using BLL;
using Escuela_3Capas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escuela_3Capas.Catalogos.Estudiante
{
    public partial class Listado_Estudiantes : System.Web.UI.Page
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
            GVEstudiantes.DataSource = BLL_Estudiante.Get_Estudiantes();
            // Mostramos los resultados renderizando la información.
            GVEstudiantes.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Formulario_Estudiante.aspx");
        }

        protected void GVEstudiantes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Recupero el ID del renglón afectado.
            int id_Estudiante = int.Parse(GVEstudiantes.DataKeys[e.RowIndex].Values["ID_Estudiante"].ToString());
            // Invoco mi método para eliminar mi camión.
            string respuesta = BLL_Estudiante.Eliminar_Estudiante(id_Estudiante);
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

        protected void GVEstudiantes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Defino si el comando (el click que se detecta) tiene la propiedad "Select".
            if (e.CommandName == "Select")
            {
                // Recupero el índice en función de aquel elemento que haya detonado el evento.
                int varIndex = int.Parse(e.CommandArgument.ToString());
                // Recupero el ID en función del índice que recuperamos anteriormente.
                string id = GVEstudiantes.DataKeys[varIndex].Values["ID_Estudiante"].ToString();
                // Redirecciono al formulario de edición pasando como parámetro el ID.
                Response.Redirect($"Formulario_Estudiante.aspx?Id={id}");
            }
        }

        protected void GVEstudiantes_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVEstudiantes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVEstudiantes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}