using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Asignatura
    {
        // CREATE
        public static string Insertar_Asignatura(Asignatura_VO asignatura)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_InsertarAsignatura",
                    "@Nombre", asignatura.Nombre
                    );

                if (respuesta != 0)
                {
                    salida = "Asignatura registrada con éxito.";
                }
                else
                {
                    salida = "Ha ocurrido un error.";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return salida;
        }

        // READ
        public static List<Asignatura_VO> Get_Asignaturas(params object[] parametros)
        {
            // Creo una lista de objetos VO
            List<Asignatura_VO> list = new List<Asignatura_VO>();
            try
            {
                // Creo un DataSet el cuál recibirá lo que devuelva la ejecución del método "execute_DataSet" de la clase "metodos_datos".
                DataSet ds_asignaturas = Metodos_Datos.Execute_DataSet("SP_ListarAsignaturas", parametros);
                // Recorro cada renglón existente de nuestro "ds" creando objetos del tipo VO y añadiendo a la lista.
                foreach (DataRow dr in ds_asignaturas.Tables[0].Rows)
                {
                    list.Add(new Asignatura_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // UPDATE
        public static string Actualizar_Asignatura(Asignatura_VO asignatura)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_ActualizarAsignatura",
                    "@ID_Asignatura", asignatura.ID_Asignatura,
                    "@Nombre", asignatura.Nombre
                    );

                if (respuesta != 0)
                {
                    salida = "Asignatura actualizada con éxito.";
                }
                else
                {
                    salida = "Ha ocurrido un error.";
                }
            }
            catch (Exception e)
            {
                salida = $"Error: {e.Message}";
            }
            return salida;
        }

        // DELETE
        public static string Eliminar_Asignatura(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_EliminarAsignatura", "@ID_Asignatura", id);

                if (respuesta != 0)
                {
                    salida = "Asignatura eliminada con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = $"Error: {e.Message}";
            }
            return salida;
        }
    } // Fin de la CLASE "DAL_Asignatura".
} // Fin del "namespace DAL".