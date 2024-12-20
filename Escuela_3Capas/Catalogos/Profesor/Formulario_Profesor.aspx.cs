using BLL;
using Escuela_3Capas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Escuela_3Capas.Catalogos.Profesor
{
    public partial class Formulario_Profesor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Válido si es Postback.
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    // Voy a insertar
                    Titulo.Text = "Agregar Profesor";
                    SubTitulo.Text = "Registrar un nuevo Profesor";
                }
                else
                {
                    // Voy a Actualizar
                    // Recupero el ID que proviene de la URL
                    int _id = Convert.ToInt32(Request.QueryString["Id"]);
                    // Obtengo el objeto original de la BD y coloco sus valores en los campos correspondientes.
                    Profesor_VO _profesorOriginal = BLL_Profesor.Get_Profesores("@ID_Profesor", _id)[0];
                    // Valido que realmente obtenga el objeto y sus valores, de lo contrario, me regreso al formulario.
                    if (_profesorOriginal.ID_Profesor != 0)
                    {
                        // Si encontré el Camión y coloco sus valores.
                        Titulo.Text = "Actualizar Profesor";
                        SubTitulo.Text = $"Modificar los datos del Profesor No. {_id}";
                        txtNombre.Text = _profesorOriginal.Nombre;
                        txtAPaterno.Text = _profesorOriginal.APaterno;
                        txtAMaterno.Text = _profesorOriginal.AMaterno;
                        txtCURP.Text = _profesorOriginal.CURP;
                        txtSexo.Text = _profesorOriginal.Sexo;
                        txtTelefono.Text = _profesorOriginal.Telefono;
                        //txtFechaNacimiento.Text = _profesorOriginal.FechaNacimiento;
                        txtFechaNacimiento.Text = DateTime.Parse(_profesorOriginal.FechaNacimiento).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        // No encontré el objeto y me voy para atrás.
                        Response.Redirect("Listado_Profesores.aspx");
                    }
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            // Preparo mi objeto para enviar.
            Profesor_VO profesor = new Profesor_VO();
            // Variables para el Sweet.
            string titulo, msg, tipo, respuesta;
            try
            {
                // Asigno mis valores del formulario al objeto.
                profesor.Nombre = txtNombre.Text;
                profesor.APaterno = txtAPaterno.Text;
                profesor.AMaterno = txtAMaterno.Text;
                profesor.CURP = txtCURP.Text;
                profesor.Sexo = txtSexo.Text;
                profesor.Telefono = txtTelefono.Text;
                // Formateamos la fecha en Inglés, para así enviarla a SQL.
                profesor.FechaNacimiento = txtFechaNacimiento.Text;


                // Valido si voy a insertar o a actualizar.
                if (Request.QueryString["Id"] != null)
                {
                    // Voy a actualizar.
                    profesor.ID_Profesor = int.Parse(Request.QueryString["id"]);
                    respuesta = BLL_Profesor.Actualizar_Profesor(profesor);
                }
                else
                {
                    // Voy a insertar
                    respuesta = BLL_Profesor.Insertar_Profesor(profesor);
                }

                // Preparo mi Sweet Alert.
                if (respuesta.ToUpper().Contains("ERROR"))
                {
                    titulo = "¡Error!";
                    msg = respuesta;
                    tipo = "error";
                    // Sweet Alert.
                    SweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
                }
                else
                {
                    titulo = "¡Ok!";
                    msg = respuesta;
                    tipo = "success";
                    // Sweet Alert.
                    SweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType(), "/Catalogos/Profesor/Listado_Profesores.aspx");
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
            Response.Redirect("/Catalogos/Profesor/Listado_Profesores.aspx");
        }
    }
}