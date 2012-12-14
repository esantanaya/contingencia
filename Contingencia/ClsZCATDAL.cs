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
    class ClsZCATDAL : ClsBase
    {
        protected ClsZCATDAL()
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

        protected ClsZCATCollection ConsultarZCATDAL(string psCriterio)
        {

            //Declaración de variables
            DataSet ds = new DataSet();
            //Definición del adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            //Definición de la coleccion
            ClsZCATCollection zZCATCollection = new ClsZCATCollection();
            ClsZCAT zCAT;
            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsZ_CAT, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;
                //Se llena el DataSet
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;
                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++) //Cada renglòn
                    {
                        zCAT = new ClsZCAT();

                        zCAT.TARIMA = Convert.ToDecimal(ds.Tables[0].Rows[contador]["TARIMA"].ToString().Trim());
                        zCAT.Werks = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        zCAT.Lgort = ds.Tables[0].Rows[contador]["LGORT"].ToString().Trim();
                        zCAT.FECHATRAS = DateTime.Parse(ds.Tables[0].Rows[contador]["FECHATRAS"].ToString().Trim());
                        zCAT.HORATRAS = DateTime.Parse(ds.Tables[0].Rows[contador]["HORATRAS"].ToString().Trim());
                        zCAT.CONTADOR = double.Parse(ds.Tables[0].Rows[contador]["CONTADOR"].ToString().Trim());
                        zCAT.Ubicacion = ds.Tables[0].Rows[contador]["UBICACIONES"].ToString().Trim();
                        zZCATCollection.Add(zCAT);
                    }
                }

                return zZCATCollection;

            }
            catch (Exception ex)
            {
                //Regenerar la excepción pero ahora con un mensaje personalizado para el usuario
                throw new Exception(Errores.ConsultarRegistro + Errores.MensajeOriginal + ex.Message.ToString());
            }
            finally
            {
                //Cerrar la conexión
                this.Conexion.Close();
            }

        }

        protected void AgregarZCATDAL(ClsZCAT zCAT)
        {
            //string createdIdUsuario = "";
            //Abrir la conexión
            this.Conexion.Open();
            // Start a local transaction.
            SqlTransaction sqlTransaction = Conexion.BeginTransaction();
            //Insertar registro
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_InsZ_CAT;
                //Inserción de parámetros para tranzacción de alta
                EstablecerParametrosDAL("ADD", zCAT, comando);
                comando.Transaction = sqlTransaction;
                comando.ExecuteNonQuery();
                comando.Transaction.Commit();
            }
            catch (Exception ex)
            {
                //Dar rollback a la transaccion
                comando.Transaction.Rollback();
                //Regenerar la excepción pero ahora con un mensaje personalizado para el usuario
                if (ex.ToString().IndexOf(Errores.LlavePrimariaExiste) >= 0)
                {
                    throw new Exception(Errores.ClaveExiste);
                }
                else
                {
                    throw new Exception(Errores.InsertarRegistro + Errores.MensajeOriginal + ex.Message.ToString());
                }
            }
            finally
            {
                this.Conexion.Close();
            }
        }

        protected void ActualizarZCATDAL(ClsZCAT zCAT)
        {

        }

        protected void EliminarZCAT(ClsZCAT zCAT)
        {
            
        }

        protected void EstablecerParametrosDAL(string tipoTran, ClsZCAT zCAT, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@TARIMA", SqlDbType.VarChar).Value = zCAT.TARIMA;
                comando.Parameters.Add("@WERKS", SqlDbType.VarChar).Value = zCAT.Werks;
                comando.Parameters.Add("@LGORT", SqlDbType.VarChar).Value = zCAT.Lgort;
                comando.Parameters.Add("@UBICACION", SqlDbType.VarChar).Value = zCAT.Ubicacion;
                comando.Parameters.Add("@TIPOALMACEN", SqlDbType.VarChar).Value = zCAT.TipoAlmacen;
            }
            catch
            {
                throw;
            }

        }
     }
}
