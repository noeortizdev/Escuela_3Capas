using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Grado
    {
        // CREATE
        public static string Insertar_Grado(Grado_VO grado)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_InsertarGrado",
                    "@Grado", grado.Grado,
                    "@Grupo", grado.Grupo,
                    "@ID_Profesor", grado.ID_Profesor
                    );

                if (respuesta != 0)
                {
                    salida = "Grado registrada con éxito.";
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
        public static List<Grado_VO> Get_Grados(params object[] parametros)
        {
            // Creo una lista de objetos VO
            List<Grado_VO> list = new List<Grado_VO>();
            try
            {
                // Creo un DataSet el cuál recibirá lo que devuelva la ejecución del método "execute_DataSet" de la clase "metodos_datos".
                DataSet ds_grados = Metodos_Datos.Execute_DataSet("SP_ListarGrados", parametros);
                // Recorro cada renglón existente de nuestro "ds" creando objetos del tipo VO y añadiendo a la lista.
                foreach (DataRow dr in ds_grados.Tables[0].Rows)
                {
                    list.Add(new Grado_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // UPDATE
        public static string Actualizar_Grado(Grado_VO grado)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_ActualizarGrado",
                    "@ID_Grado", grado.ID_Grado,
                    "@Grado", grado.Grado,
                    "@Grupo", grado.Grupo,
                    "@ID_Profesor", grado.ID_Profesor
                    );

                if (respuesta != 0)
                {
                    salida = "Grado actualizada con éxito.";
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
        public static string Eliminar_Grado(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_EliminarGrado", "@ID_Grado", id);

                if (respuesta != 0)
                {
                    salida = "Grado eliminada con éxito";
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
    } // Fin de la CLASE "DAL_Grado".
} // Fin del "namespace DAL".