using BLL;
using Escuela_3Capas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Escuela_3Capas.Catalogos.Calificacion
{
    public partial class Formulario_Calificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cargar_DLLEstudiante();
            Cargar_DLLAsignatura();
            // Válido si es Postback.
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    // Voy a insertar
                    Titulo.Text = "Agregar Calificación";
                    SubTitulo.Text = "Registro una nueva Calificación";
                }
                else
                {
                    // Voy a Actualizar
                    // Recupero el ID que proviene de la URL
                    int _id = Convert.ToInt32(Request.QueryString["Id"]);
                    // Obtengo el objeto original de la BD y coloco sus valores en los campos correspondientes.
                    Calificacion_VO calificacion = BLL_Calificacion.Get_Calificaciones("@ID_Calificacion", _id)[0];
                    // Valido que realmente obtenga el objeto y sus valores, de lo contrario, me regreso al formulario.
                    if (calificacion.ID_Calificacion != 0)
                    {
                        // Si encontré el La Calificación y coloco sus valores.
                        Titulo.Text = "Actualizar Calificación";
                        SubTitulo.Text = $"Modificar los datos de la Calificación No. {_id}";
                        txtCalificacion.Text = calificacion.Calificacion.ToString();
                        ddlEstudiante.SelectedValue = calificacion.ID_Estudiante.ToString();
                        ddlAsignatura.SelectedValue = calificacion.ID_Asignatura.ToString();
                    }
                    else
                    {
                        // No encontré el objeto y me voy para atrás.
                        Response.Redirect("Listado_Calificaciones.aspx");
                    }
                }
            }
        }

        private void Cargar_DLLEstudiante()
        {
            // ddlEstudiante
            // Creo un OBJETO de TIPO 'ListItem' para agregarlo a la lista de elementos del DLL.
            // ListItem(valor_a_mostrar, valor_a_guardar).
            ListItem ddlEstudiante_I = new ListItem("Seleccione un Grado", "0");
            ddlEstudiante.Items.Add(ddlEstudiante_I);
            // Recupero la lista de Profesores disponibles que voy a pasar al DDL.
            List<Estudiante_VO> list_g = BLL_Estudiante.Get_Estudiantes();
            if (list_g.Count > 0)
            {
                // Recorro mi lista creando objetos del tipo "ListItem" en función de los datos que requiero.
                foreach (var g in list_g)
                {
                    ListItem GI = new ListItem((g.ID_Estudiante.ToString() + ".- " + g.Nombre + " " + g.APaterno + " " + g.AMaterno + " - " + g.ID_Grado), g.ID_Estudiante.ToString());
                    ddlEstudiante.Items.Add(GI);
                }
            }
        }

        private void Cargar_DLLAsignatura()
        {
            // ddlAsignatura
            // Creo un OBJETO de TIPO 'ListItem' para agregarlo a la lista de elementos del DLL.
            // ListItem(valor_a_mostrar, valor_a_guardar).
            ListItem ddlAsignatura_I = new ListItem("Seleccione una Asignatura", "0");
            ddlAsignatura.Items.Add(ddlAsignatura_I);
            // Recupero la lista de Profesores disponibles que voy a pasar al DDL.
            List<Asignatura_VO> list_g = BLL_Asignatura.Get_Asignaturas();
            if (list_g.Count > 0)
            {
                // Recorro mi lista creando objetos del tipo "ListItem" en función de los datos que requiero.
                foreach (var g in list_g)
                {
                    ListItem GI = new ListItem((g.ID_Asignatura.ToString() + ".- " + g.Nombre), g.ID_Asignatura.ToString());
                    ddlAsignatura.Items.Add(GI);
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = "", respuesta = "", tipo = "", salida = "";
            try
            {
                // Creamos el objeto que enviaremos para actualizar o insertar a la BD.
                // Existen 2 formas de instanciar y llenar un objeto.
                // Forma 1 (por atributos)
                Calificacion_VO calificacion = new Calificacion_VO();
                calificacion.Calificacion = double.Parse(txtCalificacion.Text);
                calificacion.ID_Estudiante = int.Parse(ddlEstudiante.SelectedValue);
                calificacion.ID_Asignatura = int.Parse(ddlAsignatura.SelectedValue);

                // Decido si voy a insertar o actualizar.
                if (Request.QueryString["Id"] == null)
                {
                    // Voy a insertar.
                    salida = BLL_Calificacion.Insertar_Calificacion(calificacion);
                }
                else
                {
                    // Actualizar.
                    calificacion.ID_Calificacion = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Calificacion.Actualizar_Calificacion(calificacion);
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
            catch (Exception ex)
            {
                titulo = "¡Error!";
                respuesta = ex.Message;
                tipo = "error";
            }
            // Sweet Alert.
            SweetAlert.Sweet_Alert(titulo, respuesta, tipo, this.Page, this.GetType(), "/Catalogos/Calificacion/Listado_Calificaciones.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}