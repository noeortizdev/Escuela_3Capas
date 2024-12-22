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
                Cargar_DLLGenero();
                Cargar_DLLParentesco();
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
                        if (tutor.Sexo == "Masculino")
                        {
                            ddlGenero.SelectedValue = "1";
                        }
                        else
                        {
                            ddlGenero.SelectedValue = "2";
                        }
                        txtTelefono.Text = tutor.Telefono;
                        if (tutor.Parentesco == "Padre")
                        {
                            ddlParentesco.SelectedValue = "1";
                        }
                        else if (tutor.Parentesco == "Madre")
                        {
                            ddlParentesco.SelectedValue = "2";
                        }
                        else if (tutor.Parentesco == "Hermano(a)")
                        {
                            ddlParentesco.SelectedValue = "3";
                        }
                        else
                        {
                            ddlParentesco.SelectedValue = "4";
                        }
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
        private void Cargar_DLLGenero()
        {
            // ddlGenero
            // Creo un OBJETO de TIPO 'ListItem' para agregarlo a la lista de elementos del DLL.
            // ListItem(valor_a_mostrar, valor_a_guardar).
            ListItem ddlGenero_I = new ListItem("Seleccione un Género", "0");
            ddlGenero.Items.Add(ddlGenero_I);
            ListItem GI1 = new ListItem("Masculino", "1");
            ddlGenero.Items.Add(GI1);
            ListItem GI2 = new ListItem("Femenino", "2");
            ddlGenero.Items.Add(GI2);
        }

        private void Cargar_DLLParentesco()
        {
            // ddlParentesco
            // Creo un OBJETO de TIPO 'ListItem' para agregarlo a la lista de elementos del DLL.
            // ListItem(valor_a_mostrar, valor_a_guardar).
            ListItem ddlParentesco_I = new ListItem("Seleccione un Parentesco", "0");
            ddlParentesco.Items.Add(ddlParentesco_I);
            ListItem PI1 = new ListItem("Padre", "1");
            ddlParentesco.Items.Add(PI1);
            ListItem PI2 = new ListItem("Madre", "2");
            ddlParentesco.Items.Add(PI2);
            ListItem PI3 = new ListItem("Hermano(a)", "3");
            ddlParentesco.Items.Add(PI3);
            ListItem PI4 = new ListItem("Tio(a)", "4");
            ddlParentesco.Items.Add(PI4);
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
                    if (ddlGenero.SelectedValue == "1")
                    {
                        tutorAux.Sexo = "Masculino";
                    }
                    else
                    {
                        tutorAux.Sexo = "Femenino";
                    }
                    tutorAux.Telefono = txtTelefono.Text;
                    if (ddlParentesco.SelectedValue == "1")
                    {
                        tutorAux.Parentesco = "Padre";
                    }
                    else if (ddlParentesco.SelectedValue == "2")
                    {
                        tutorAux.Parentesco = "Madre";
                    }
                    else if (ddlParentesco.SelectedValue == "3")
                    {
                        tutorAux.Parentesco = "Hermano(a)";
                    }
                    else
                    {
                        tutorAux.Parentesco = "Tio(a)";
                    }
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