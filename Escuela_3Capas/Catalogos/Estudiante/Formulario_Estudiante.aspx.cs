using BLL;
using Escuela_3Capas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Escuela_3Capas.Catalogos.Estudiante
{
    public partial class Formulario_Estudiante : System.Web.UI.Page
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
                    int id_estudiante = int.Parse(Request.QueryString["Id"].ToString());
                    // Recupero el Objeto Original.
                    Estudiante_VO estudiante = BLL_Estudiante.Get_Estudiantes("@ID_Estudiante", id_estudiante)[0];
                    // Valido que realmente ha recuperado un objeto.
                    if (estudiante.ID_Estudiante != 0)
                    {
                        // Relleno el formulario.
                        Titulo.Text = "Actualizar Estudiante";
                        SubTitulo.Text = $"Modificar los datos del Estudiante No. {id_estudiante}";
                        txtNombre.Text = estudiante.Nombre;
                        txtAPaterno.Text = estudiante.APaterno;
                        txtAMaterno.Text = estudiante.AMaterno;
                        txtCURP.Text = estudiante.CURP;
                        txtSexo.Text = estudiante.Sexo;
                        txtTelefono.Text = estudiante.Telefono;
                        txtDireccion.Text = estudiante.Direccion;
                        txtFechaNacimiento.Text = DateTime.Parse(estudiante.FechaNacimiento).ToString("yyyy-MM-dd");
                        ddlGrado.SelectedValue = estudiante.ID_Grado.ToString();
                    }
                    else
                    {
                        // Sweet Alert.
                        SweetAlert.Sweet_Alert("Ops...", "No pudimos encontrar el objeto que buscas", "info", this.Page, this.GetType(), "~/Catalogos/Estudiante/Listado_Estudiantes.aspx");
                    }
                }
                else
                {
                    // Voy a Insertar.
                    Titulo.Text = "Agregar Estudiante";
                    SubTitulo.Text = "Registrar un Nuevo Estudiante";
                }
            }
        }

        private void Cargar_DLL()
        {
            // ddlProfesor
            // Creo un OBJETO de TIPO 'ListItem' para agregarlo a la lista de elementos del DLL.
            // ListItem(valor_a_mostrar, valor_a_guardar).
            ListItem ddlGrado_I = new ListItem("Seleccione un Grado", "0");
            ddlGrado.Items.Add(ddlGrado_I);
            // Recupero la lista de Profesores disponibles que voy a pasar al DDL.
            List<Grado_VO> list_g = BLL_Grado.Get_Grados();
            if (list_g.Count > 0)
            {
                // Recorro mi lista creando objetos del tipo "ListItem" en función de los datos que requiero.
                foreach (var g in list_g)
                {
                    ListItem GI = new ListItem((g.ID_Grado.ToString() + ".- " + g.Grado + " " + g.Grupo), g.ID_Grado.ToString());
                    ddlGrado.Items.Add(GI);
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Preparo mi objeto para enviar.
            Estudiante_VO estudiante = new Estudiante_VO();
            // Variables para el Sweet.
            string titulo, msg, tipo, respuesta;
            try
            {
                /*bool validarText = txtNombre.Text == string.Empty && txtAPaterno.Text == string.Empty &&
                                       txtAMaterno.Text == string.Empty && txtCURP.Text == string.Empty &&
                                       txtSexo.Text == string.Empty && txtTelefono.Text == string.Empty &&
                                       txtDireccion.Text == string.Empty && txtFechaNacimiento.Text == string.Empty &&
                                       ddlGrado.SelectedValue == string.Empty;
                if (validarText)
                {*/
                    // Asigno mis valores del formulario al objeto.
                    estudiante.Nombre = txtNombre.Text;
                    estudiante.APaterno = txtAPaterno.Text;
                    estudiante.AMaterno = txtAMaterno.Text;
                    estudiante.CURP = txtCURP.Text;
                    estudiante.Sexo = txtSexo.Text;
                    estudiante.Telefono = txtTelefono.Text;
                    estudiante.Direccion = txtDireccion.Text;
                    // Formateamos la fecha en Inglés, para así enviarla a SQL.
                    estudiante.FechaNacimiento = txtFechaNacimiento.Text;
                    estudiante.ID_Grado = int.Parse(ddlGrado.SelectedValue);

                    // Valido si voy a insertar o a actualizar.
                    if (Request.QueryString["Id"] != null)
                    {
                        // Voy a actualizar.
                        estudiante.ID_Estudiante = int.Parse(Request.QueryString["id"]);
                        respuesta = BLL_Estudiante.Actualizar_Estudiante(estudiante);
                    }
                    else
                    {
                        // Voy a insertar
                        respuesta = BLL_Estudiante.Insertar_Estudiante(estudiante);
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
                        SweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType(), "/Catalogos/Estudiante/Listado_Estudiantes.aspx");
                    }
                /*}
                else
                {
                    throw new Exception("Tienes que completar los campos....");
                }*/
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
            Response.Redirect("/Catalogos/Estudiante/Listado_Estudiantes.aspx");
        }
    }
}