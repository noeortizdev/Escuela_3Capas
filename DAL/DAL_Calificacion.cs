using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Calificacion
    {
        // CREATE
        public static string Insertar_Calificacion(Calificacion_VO calificacion)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_InsertarCalificacion",
                    "@Calificacion", calificacion.Calificacion,
                    "@ID_Estudiante", calificacion.ID_Estudiante,
                    "@ID_Asignatura", calificacion.ID_Asignatura
                    );

                if (respuesta != 0)
                {
                    salida = "Calificación registrado con éxito.";
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
        /** Este es un comentario del proyecto de bases de datos.
         * */
        public static List<Calificacion_VO> Get_Calificaciones(params object[] parametros)
        {
            // Creo una lista de objetos VO
            List<Calificacion_VO> list = new List<Calificacion_VO>();
            try
            {
                // Creo un DataSet el cuál recibirá lo que devuelva la ejecución del método "execute_DataSet" de la clase "metodos_datos".
                DataSet ds_calificaciones = Metodos_Datos.Execute_DataSet("SP_ListarCalificaciones", parametros);
                // Recorro cada renglón existente de nuestro "ds" creando objetos del tipo VO y añadiendo a la lista.
                foreach (DataRow dr in ds_calificaciones.Tables[0].Rows)
                {
                    list.Add(new Calificacion_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // UPDATE
        public static string Actualizar_Calificacion(Calificacion_VO calificacion)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_ActualizarCalificacion",
                    "@ID_Calificacion", calificacion.ID_Calificacion,
                    "@Calificacion", calificacion.Calificacion,
                    "@ID_Estudiante", calificacion.ID_Estudiante,
                    "@ID_Asignatura", calificacion.ID_Asignatura
                    );

                if (respuesta != 0)
                {
                    salida = "Calificación actualizada con éxito.";
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
        public static string Eliminar_Calificacion(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_EliminarCalificacion", "@ID_Calificacion", id);

                if (respuesta != 0)
                {
                    salida = "Calificacion eliminada con éxito";
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
    } // Fin de la CLASE "DAL_Calificacion".
} // Fin del "namespace DAL".