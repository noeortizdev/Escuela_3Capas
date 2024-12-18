using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Tutor
    {
        // CREATE
        public static string Insertar_Tutor(Tutor_VO tutor)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_InsertarTutor",
                    "@Nombre", tutor.Nombre,
                    "@APaterno", tutor.APaterno,
                    "@AMaterno", tutor.AMaterno,
                    "@CURP", tutor.CURP,
                    "@Sexo", tutor.Sexo,
                    "@Telefono", tutor.Telefono,
                    "@Parentesco", tutor.Parentesco,
                    "@Direccion", tutor.Direccion,
                    "@FechaNacimiento", tutor.FechaNacimiento,
                    "@ID_Estudiante", tutor.ID_Estudiante
                    );

                if (respuesta != 0)
                {
                    salida = "Tutor registrado con éxito.";
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
        public static List<Tutor_VO> Get_Tutores(params object[] parametros)
        {
            // Creo una lista de objetos VO
            List<Tutor_VO> list = new List<Tutor_VO>();
            try
            {
                // Creo un DataSet el cuál recibirá lo que devuelva la ejecución del método "execute_DataSet" de la clase "metodos_datos".
                DataSet ds_tutores = Metodos_Datos.Execute_DataSet("SP_ListarTutores", parametros);
                // Recorro cada renglón existente de nuestro "ds" creando objetos del tipo VO y añadiendo a la lista.
                foreach (DataRow dr in ds_tutores.Tables[0].Rows)
                {
                    list.Add(new Tutor_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // UPDATE
        public static string Actualizar_Tutor(Tutor_VO tutor)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_ActualizarTutor",
                    "@ID_Tutor", tutor.ID_Tutor,
                    "@Nombre", tutor.Nombre,
                    "@APaterno", tutor.APaterno,
                    "@AMaterno", tutor.AMaterno,
                    "@CURP", tutor.CURP,
                    "@Sexo", tutor.Sexo,
                    "@Telefono", tutor.Telefono,
                    "@Parentesco", tutor.Parentesco,
                    "@Direccion", tutor.Direccion,
                    "@FechaNacimiento", tutor.FechaNacimiento,
                    "@ID_Estudiante", tutor.ID_Estudiante
                    );

                if (respuesta != 0)
                {
                    salida = "Tutor actualizada con éxito.";
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
        public static string Eliminar_Tutor(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = Metodos_Datos.Execute_NonQuery("SP_EliminarTutor", "@ID_Tutor", id);

                if (respuesta != 0)
                {
                    salida = "Tutor eliminado con éxito";
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
    } // Fin de la CLASE "DAL_Tutor".
} // Fin del "namespace DAL".