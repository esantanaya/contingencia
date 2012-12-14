using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.Serialization;
using System.Globalization;

namespace Contingencia
{
    class ClsVariablesEntornoBD: ClsBase
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        protected ClsVariablesEntornoBD()
        {
            //Se genera la conexión a la base cuando es instanciada la clase
            try
            {
                base.CrearConexion();
            }
            catch
            {
                throw ;
            }
        }

        protected string[,] ConsultarVariablesBD()
        {

            //Declaración de variables
            string[,] aVariables = new string[0, 0];
            int contador;
            DataSet ds = new DataSet();
            //Definición del adaptador
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                //Definición del Stored Procedure a ejecutar
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsEntorno, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //Se llena el DataSet
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;
                    aVariables = new string[renglones, columnas];
                    for (contador = 0; contador < ds.Tables[0].Rows.Count; contador++) //Cada renglòn
                    {
                        aVariables[contador, 0] = ds.Tables[0].Rows[contador]["NombreVariable"].ToString();
                        aVariables[contador, 1] = ds.Tables[0].Rows[contador]["valor"].ToString();
                    }
                }
                return aVariables;

            }
            catch (Exception ex)
            {
                //Regenerar la excepción pero ahora con un mensaje personalizado para el usuario
                throw new Exception(Errores.ConsultarVariablesEntorno + Errores.MensajeOriginal + ex.Message.ToString());
            }
            finally
            {
                //Cerrar la conexión
                this.Conexion.Close();
            }

        }
    }
}
