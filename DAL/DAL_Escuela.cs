using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Escuela
    {
        // CREATE
        public static string Insertar_Escuela(Escuela_VO escuela)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_InsertarEscuela",
                    "@Nombre", escuela.Nombre,
                    "@Clave", escuela.Clave,
                    "@Telefono", escuela.Telefono,
                    "@Nivel", escuela.Nivel,
                    "@Direccion", escuela.Direccion,
                    "@FechaFundacion", escuela.FechaFundacion
                    );

                if (respuesta != 0)
                {
                    salida = "Escuela registrada con éxito.";
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
        public static List<Escuela_VO> Get_Escuelas(params object[] parametros)
        {
            // Creo una lista de objetos VO
            List<Escuela_VO> list = new List<Escuela_VO>();
            try
            {
                // Creo un DataSet el cuál recibirá lo que devuelva la ejecución del método "execute_DataSet" de la clase "metodos_datos".
                DataSet ds_escuelas = Metodos_Datos.Execute_DataSet("SP_ListarEscuelas", parametros);
                // Recorro cada renglón existente de nuestro "ds" creando objetos del tipo VO y añadiendo a la lista.
                foreach (DataRow dr in ds_escuelas.Tables[0].Rows)
                {
                    list.Add(new Escuela_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // UPDATE
        public static string Actualizar_Escuela(Escuela_VO escuela)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_ActualizarEscuela",
                    "@ID_Escuela", escuela.ID_Escuela,
                    "@Nombre", escuela.Nombre,
                    "@Clave", escuela.Clave,
                    "@Telefono", escuela.Telefono,
                    "@Nivel", escuela.Nivel,
                    "@Direccion", escuela.Direccion,
                    "@FechaFundacion", escuela.FechaFundacion
                    );

                if (respuesta != 0)
                {
                    salida = "Escuela actualizada con éxito.";
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
        public static string Eliminar_Escuela(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_EliminarEscuela", "@ID_Escuela", id);

                if (respuesta != 0)
                {
                    salida = "Escuela eliminada con éxito";
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
    } // Fin de la CLASE DAL_Escuela".
} // Fin del "namespace DAL".