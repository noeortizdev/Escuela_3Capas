using BLL;
using Escuela_3Capas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Escuela_3Capas.Catalogos.Asignatura
{
    public partial class Formulario_Asignatura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Válido si es Postback.
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    // Voy a insertar
                    Titulo.Text = "Agregar Asignatura";
                    SubTitulo.Text = "Registro de una nueva Asignatura";
                }
                else
                {
                    // Voy a Actualizar
                    // Recupero el ID que proviene de la URL
                    int _id = Convert.ToInt32(Request.QueryString["Id"]);
                    // Obtengo el objeto original de la BD y coloco sus valores en los campos correspondientes.
                    Asignatura_VO _asignaturaOriginal = BLL_Asignatura.Get_Asignaturas("@ID_Asignatura", _id)[0];
                    // Valido que realmente obtenga el objeto y sus valores, de lo contrario, me regreso al formulario.
                    if (_asignaturaOriginal.ID_Asignatura != 0)
                    {
                        // Si encontré el Camión y coloco sus valores.
                        Titulo.Text = "Actualizar Asignatura";
                        SubTitulo.Text = $"Modificar los datos de la Asignatura #{_id}";
                        txtNombre.Text = _asignaturaOriginal.Nombre;
                    }
                    else
                    {
                        // No encontré el objeto y me voy para atrás.
                        Response.Redirect("Listado_Asignaturas.aspx");
                    }
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
                    string valores = "Q WERTYUIOPASDFGHJKLÑZXCVBNMqwertyuiopasdfghjklñzxcvbnméúíóáÉÚÍÓÁ1234567890";
                    string valoresConGuionBajo = "_";
                    string valoresConGuion = "-";
                    if (txtNombre.Text.Contains(valores) || txtNombre.Text.Contains(valoresConGuionBajo) || txtNombre.Text.Contains(valoresConGuion))
                    {
                        // Creamos el objeto que enviaremos para actualizar o insertar a la BD.
                        // Existen 2 formas de instanciar y llenar un objeto.
                        // Forma 1 (por atributos)
                        Asignatura_VO _asignaturaAux = new Asignatura_VO();
                        _asignaturaAux.Nombre = txtNombre.Text;

                        // Forma 2 (durante la propia instancia)
                        Asignatura_VO _asignaturaAux2 = new Asignatura_VO()
                        {
                            Nombre = txtNombre.Text
                        };

                        // Decido si voy a insertar o actualizar.
                        if (Request.QueryString["Id"] == null)
                        {
                            // Voy a insertar.
                            salida = BLL_Asignatura.Insertar_Asignatura(_asignaturaAux);
                        }
                        else
                        {
                            // Actualizar.
                            _asignaturaAux.ID_Asignatura = int.Parse(Request.QueryString["Id"]);
                            salida = BLL_Asignatura.Actualizar_Asignatura(_asignaturaAux);
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
                        throw new Exception("¡Error! Verifica bien los datos antes de ingresar...");
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
            SweetAlert.Sweet_Alert(titulo, respuesta, tipo, this.Page, this.GetType(), "/Catalogos/Asignatura/Listado_Asignaturas.aspx");
        }
    }
}