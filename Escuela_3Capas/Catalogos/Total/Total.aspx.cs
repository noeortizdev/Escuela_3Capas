using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escuela_3Capas.Catalogos.Total
{
    public partial class Total : System.Web.UI.Page
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
            GVCalificaciones.DataSource = BLL_Total.Get_Total();
            GVCalificaciones.DataBind();
        }

        protected void GVCalificaciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GVCalificaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {

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

        protected void Insertar_Click(object sender, EventArgs e)
        {

        }
    }
}