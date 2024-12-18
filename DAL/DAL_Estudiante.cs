using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Estudiante
    {
        // CREATE
        public static string Insertar_Estudiante(Estudiante_VO estudiante)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_InsertarEstudiante",
                    "@Nombre", estudiante.Nombre,
                    "@APaterno", estudiante.APaterno,
                    "@AMaterno", estudiante.AMaterno,
                    "@CURP", estudiante.CURP,
                    "@Sexo", estudiante.Sexo,
                    "@Telefono", estudiante.Telefono,
                    "@Direccion", estudiante.Direccion,
                    "@FechaNacimiento", estudiante.FechaNacimiento,
                    "@ID_Grado", estudiante.ID_Grado
                    );

                if (respuesta != 0)
                {
                    salida = "Estudiante registrada con éxito.";
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
        public static List<Estudiante_VO> Get_Estudiantes(params object[] parametros)
        {
            // Creo una lista de objetos VO
            List<Estudiante_VO> list = new List<Estudiante_VO>();
            try
            {
                // Creo un DataSet el cuál recibirá lo que devuelva la ejecución del método "execute_DataSet" de la clase "metodos_datos".
                DataSet ds_estudiantes = Metodos_Datos.Execute_DataSet("SP_ListarEstudiantes", parametros);
                // Recorro cada renglón existente de nuestro "ds" creando objetos del tipo VO y añadiendo a la lista.
                foreach (DataRow dr in ds_estudiantes.Tables[0].Rows)
                {
                    list.Add(new Estudiante_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // UPDATE
        public static string Actualizar_Estudiante(Estudiante_VO estudiante)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_ActualizarEstudiante",
                    "@ID_Estudiante", estudiante.ID_Estudiante,
                    "@Nombre", estudiante.Nombre,
                    "@APaterno", estudiante.APaterno,
                    "@AMaterno", estudiante.AMaterno,
                    "@CURP", estudiante.CURP,
                    "@Sexo", estudiante.Sexo,
                    "@Telefono", estudiante.Telefono,
                    "@Direccion", estudiante.Direccion,
                    "@FechaNacimiento", estudiante.FechaNacimiento,
                    "@ID_Grado", estudiante.ID_Grado
                    );

                if (respuesta != 0)
                {
                    salida = "Estudiante actualizada con éxito.";
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
        public static string Eliminar_Estudiante(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_EliminarEstudiante", "@ID_Estudiante", id);

                if (respuesta != 0)
                {
                    salida = "Estudiante eliminada con éxito";
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
    } // Fin de la CLASE "DAL_Estudiante".
} // Fin del "namespace DAL".