using BLL;
using Escuela_3Capas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Escuela_3Capas.Catalogos.Tutor
{
    public partial class Formulario_Tutor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargar_DLL();
                if (Request.QueryString["Id"] == null)
                {
                    // Voy a insertar
                    Titulo.Text = "Agregar Tutor";
                    SubTitulo.Text = "Registrar un Nuevo Tutor";
                }
                else
                {
                    // Voy a Actualizar
                    // Recupero el ID que proviene de la URL
                    int id_tutor = Convert.ToInt32(Request.QueryString["Id"]);
                    // Obtengo el objeto original de la BD y coloco sus valores en los campos correspondientes.
                    Tutor_VO tutor = BLL_Tutor.Get_Tutores("@ID_Tutor", id_tutor)[0];
                    // Valido que realmente obtenga el objeto y sus valores, de lo contrario, me regreso al formulario.
                    if (tutor.ID_Tutor != 0)
                    {
                        // Relleno el formulario.
                        Titulo.Text = "Actualizar Tutor";
                        SubTitulo.Text = $"Modificar los datos del Tutor No. {id_tutor}";
                        txtNombre.Text = tutor.Nombre;
                        txtAPaterno.Text = tutor.APaterno;
                        txtAMaterno.Text = tutor.AMaterno;
                        txtCURP.Text = tutor.CURP;
                        txtSexo.Text = tutor.Sexo;
                        txtTelefono.Text = tutor.Telefono;
                        txtParentesco.Text = tutor.Telefono;
                        txtDireccion.Text = tutor.Direccion;
                        txtFechaNacimiento.Text = DateTime.Parse(tutor.FechaNacimiento).ToString("yyyy-MM-dd");
                        ddlEstudiante.SelectedValue = tutor.ID_Estudiante.ToString();
                    }
                    else
                    {
                        // No encontré el objeto y me voy para atrás.
                        Response.Redirect("Listado_Tutores.aspx");
                    }
                }
            }
        }

        private void Cargar_DLL()
        {
            // ddlProfesor
            // Creo un OBJETO de TIPO 'ListItem' para agregarlo a la lista de elementos del DLL.
            // ListItem(valor_a_mostrar, valor_a_guardar).
            ListItem ddlEstudiante_I = new ListItem("Seleccione un Estudiante", "0");
            ddlEstudiante.Items.Add(ddlEstudiante_I);
            // Recupero la lista de Profesores disponibles que voy a pasar al DDL.
            List<Estudiante_VO> list_e = BLL_Estudiante.Get_Estudiantes();
            if (list_e.Count > 0)
            {
                // Recorro mi lista creando objetos del tipo "ListItem" en función de los datos que requiero.
                foreach (var e in list_e)
                {
                    ListItem EI = new ListItem((e.ID_Estudiante.ToString() + ".- " + e.Nombre + " " + e.APaterno + " " + e.AMaterno), e.ID_Estudiante.ToString());
                    ddlEstudiante.Items.Add(EI);
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = "", respuesta = "", tipo = "", salida = "";
            try
            {
                if (txtNombre.Text != string.Empty)
                {
                    // Creamos el objeto que enviaremos para actualizar o insertar a la BD.
                    // Existen 2 formas de instanciar y llenar un objeto.
                    // Forma 1 (por atributos)
                    Tutor_VO tutorAux = new Tutor_VO();
                    tutorAux.Nombre = txtNombre.Text;
                    tutorAux.APaterno = txtAPaterno.Text;
                    tutorAux.AMaterno = txtAMaterno.Text;
                    tutorAux.CURP = txtCURP.Text;
                    tutorAux.Sexo = txtSexo.Text;
                    tutorAux.Telefono = txtTelefono.Text;
                    tutorAux.Parentesco = txtParentesco.Text;
                    tutorAux.Direccion = txtDireccion.Text;
                    tutorAux.FechaNacimiento = txtFechaNacimiento.Text;
                    tutorAux.ID_Estudiante = int.Parse(ddlEstudiante.SelectedValue);

                    // Forma 2 (durante la propia instancia)
                    Tutor_VO _tutorAux2 = new Tutor_VO()
                    {
                        Nombre = txtNombre.Text
                    };

                    // Decido si voy a insertar o actualizar.
                    if (Request.QueryString["Id"] == null)
                    {
                        // Voy a insertar.
                        salida = BLL_Tutor.Insertar_Tutor(tutorAux);
                    }
                    else
                    {
                        // Actualizar.
                        tutorAux.ID_Tutor = int.Parse(Request.QueryString["Id"]);
                        salida = BLL_Tutor.Actualizar_Tutor(tutorAux);
                    }

                    // Preparamos la salida para cachar un error y mostrar el Sweet Alert.
                    if (salida.ToUpper().Contains("ERROR"))
                    {
                        titulo = "¡Ops!...";
                        respuesta = salida;
                        tipo = "warning";
                    }
                    else
                    {
                        titulo = "¡Correcto!";
                        respuesta = salida;
                        tipo = "success";
                    }
                }
                else
                {
                    throw new Exception("Tienes que agregar un valor...");
                }
            }
            catch (Exception ex)
            {
                titulo = "¡Error!";
                respuesta = ex.Message;
                tipo = "error";
            }
            // Sweet Alert.
            SweetAlert.Sweet_Alert(titulo, respuesta, tipo, this.Page, this.GetType(), "/Catalogos/Tutor/Listado_Tutores.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // No encontré el objeto y me voy para atrás.
            Response.Redirect("/Catalogos/Tutor/Listado_Tutores.aspx");
        }
    }
}