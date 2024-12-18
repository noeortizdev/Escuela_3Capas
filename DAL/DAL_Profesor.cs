using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Profesor
    {
        // CREATE
        public static string Insertar_Profesor(Profesor_VO profesor)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_InsertarProfesor",
                    "@Nombre", profesor.Nombre,
                    "@APaterno", profesor.APaterno,
                    "@AMaterno", profesor.AMaterno,
                    "@CURP", profesor.CURP,
                    "@Sexo", profesor.Sexo,
                    "@Telefono", profesor.Telefono,
                    "@FechaNacimiento", profesor.FechaNacimiento
                    );

                if (respuesta != 0)
                {
                    salida = "Profesor registrada con éxito.";
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
        public static List<Profesor_VO> Get_Profesores(params object[] parametros)
        {
            // Creo una lista de objetos VO
            List<Profesor_VO> list = new List<Profesor_VO>();
            try
            {
                // Creo un DataSet el cuál recibirá lo que devuelva la ejecución del método "execute_DataSet" de la clase "metodos_datos".
                DataSet ds_profesores = Metodos_Datos.Execute_DataSet("SP_ListarProfesores", parametros);
                // Recorro cada renglón existente de nuestro "ds" creando objetos del tipo VO y añadiendo a la lista.
                foreach (DataRow dr in ds_profesores.Tables[0].Rows)
                {
                    list.Add(new Profesor_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // UPDATE
        public static string Actualizar_Profesor(Profesor_VO profesor)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_ActualizarProfesor",
                    "@ID_Profesor", profesor.ID_Profesor,
                    "@Nombre", profesor.Nombre,
                    "@APaterno", profesor.APaterno,
                    "@AMaterno", profesor.AMaterno,
                    "@CURP", profesor.CURP,
                    "@Sexo", profesor.Sexo,
                    "@Telefono", profesor.Telefono,
                    "@FechaNacimiento", profesor.FechaNacimiento
                    );

                if (respuesta != 0)
                {
                    salida = "Profesor actualizada con éxito.";
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
        public static string Eliminar_Profesor(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_EliminarProfesor", "@ID_Profesor", id);

                if (respuesta != 0)
                {
                    salida = "Profesor eliminada con éxito";
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
    } // Fin de la CLASE "DAL_Profesor".
} // Fin del "namespace DAL".