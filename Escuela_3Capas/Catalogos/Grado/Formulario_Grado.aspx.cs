using BLL;
using Escuela_3Capas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Escuela_3Capas.Catalogos.Grado
{
    public partial class Formulario_Grado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargo mis DDL'S (Drop Down List).
                Cargar_DLL();
                // Valido si se va a Insertar o a Actualizar.
                if (Request.QueryString["Id"] != null)
                {
                    // Voy Actualizar.
                    // Recupero el ID de la URL.
                    int id_grado = int.Parse(Request.QueryString["Id"].ToString());
                    // Recupero el Objeto Original.
                    Grado_VO _grado = BLL_Grado.Get_Grados("@ID_Grado", id_grado)[0];
                    // Valido que realmente ha recuperado un objeto.
                    if (_grado.ID_Grado != 0)
                    {
                        // Relleno el formulario.
                        Titulo.Text = "Actualizar Grado";
                        Subtitulo.Text = "Grado No. " + id_grado;
                        txtGrado.Text = _grado.Grado;
                        txtGrupo.Text = _grado.Grupo;
                        ddlProfesor.SelectedValue = _grado.ID_Profesor.ToString();
                    }
                    else
                    {
                        // Sweet Alert.
                        SweetAlert.Sweet_Alert("Ops...", "No pudimos encontrar el objeto que buscas", "info", this.Page, this.GetType(), "~/Catalogos/Grado/Listado_Grado.aspx");
                    }
                }
                else
                {
                    // Voy a Insertar.
                    Titulo.Text = "Agregar Grado";
                    Subtitulo.Text = "Registrar un Nuevo Grado";
                }
            }
        }

        private void Cargar_DLL()
        {
            // ddlProfesor
            // Creo un OBJETO de TIPO 'ListItem' para agregarlo a la lista de elementos del DLL.
            // ListItem(valor_a_mostrar, valor_a_guardar).
            ListItem ddlProfesor_I = new ListItem("Seleccione un Profesor", "0");
            ddlProfesor.Items.Add(ddlProfesor_I);
            // Recupero la lista de Profesores disponibles que voy a pasar al DDL.
            List<Profesor_VO> list_p = BLL_Profesor.Get_Profesores();
            if (list_p.Count > 0)
            {
                // Recorro mi lista creando objetos del tipo "ListItem" en función de los datos que requiero.
                foreach (var p in list_p)
                {
                    ListItem PI = new ListItem((p.ID_Profesor.ToString() + ".- " + p.Nombre + " " + p.APaterno + " " + p.AMaterno), p.ID_Profesor.ToString());
                    ddlProfesor.Items.Add(PI);
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Preparo mi objeto para enviar.
            Grado_VO _grado = new Grado_VO();
            // Variables para el Sweet.
            string titulo, msg, tipo, respuesta;
            try
            {
                // Asigno mis valores del formulario al objeto.
                _grado.Grado = txtGrado.Text;
                _grado.Grupo = txtGrupo.Text;
                //_grado.ID_Profesor = int.Parse(ddlProfesor.SelectedValue);
                _grado.ID_Profesor = int.Parse(ddlProfesor.SelectedValue);

                // Valido si voy a insertar o a actualizar.
                if (Request.QueryString["Id"] != null)
                {
                    // Voy a actualizar.
                    _grado.ID_Grado = int.Parse(Request.QueryString["id"]);
                    respuesta = BLL_Grado.Actualizar_Grado(_grado);
                }
                else
                {
                    // Voy a insertar
                    respuesta = BLL_Grado.Insertar_Grado(_grado);
                }

                // Preparo mi Sweet Alert.
                if (respuesta.ToUpper().Contains("ERROR"))
                {
                    titulo = "ERROR";
                    msg = respuesta;
                    tipo = "error";
                    // Sweet Alert.
                    SweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
                }
                else
                {
                    titulo = "Ok!";
                    msg = respuesta;
                    tipo = "success";
                    // Sweet Alert.
                    SweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType(), "/Catalogos/Grado/Listado_Grado.aspx");
                }
            }
            catch (Exception ex)
            {
                titulo = "¡Error!";
                msg = ex.Message;
                tipo = "error";
                // Sweet Alert.
                SweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // No encontré el objeto y me voy para atrás.
            Response.Redirect("/Catalogos/Grado/Listado_Grado.aspx");
        }
    }
}