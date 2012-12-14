using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contingencia
{
    class ClsZTPPLogsDAL: ClsBase
    {
        protected ClsZTPPLogsDAL()
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

        protected ClsZTPPLogsCollection ConsultarZTPPLogsDAL(string psCriterio)
        {

            //Declaración de variables
            DataSet ds = new DataSet();
            //Definición del adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            //Definición de la coleccion
            ClsZTPPLogsCollection zTPPLogsCollection = new ClsZTPPLogsCollection();
            ClsZTPPLogs zTPPLogs;
            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsZTTPLogs, this.Conexion);
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
                        zTPPLogs = new ClsZTPPLogs();

                        zTPPLogs.Werks = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        zTPPLogs.Exidv = ds.Tables[0].Rows[contador]["EXIDV"].ToString().Trim();
                        zTPPLogs.Posicion = int.Parse(ds.Tables[0].Rows[contador]["POSICION"].ToString().Trim());
                        zTPPLogs.Fecha = DateTime.Parse(ds.Tables[0].Rows[contador]["FECHA"].ToString().Trim());
                        zTPPLogs.Hora = DateTime.Parse(ds.Tables[0].Rows[contador]["HORA"].ToString().Trim());
                        zTPPLogs.Proceso = ds.Tables[0].Rows[contador]["PROCESO"].ToString().Trim();
                        zTPPLogs.Lgort = ds.Tables[0].Rows[contador]["LGORT"].ToString().Trim();
                        zTPPLogs.Matnr = ds.Tables[0].Rows[contador]["MATNR"].ToString().Trim();
                        zTPPLogs.Aufnr = ds.Tables[0].Rows[contador]["AUFNR"].ToString().Trim();
                        zTPPLogs.Vornr = ds.Tables[0].Rows[contador]["VORNR"].ToString().Trim();
                        zTPPLogs.Icon = ds.Tables[0].Rows[contador]["ICON"].ToString().Trim();
                        zTPPLogs.Vemng = double.Parse(ds.Tables[0].Rows[contador]["VEMNG"].ToString().Trim());
                        zTPPLogs.Message = ds.Tables[0].Rows[contador]["MESSAGE"].ToString().Trim();
                        zTPPLogs.Mblnr = ds.Tables[0].Rows[contador]["MBLNR"].ToString().Trim();
                        zTPPLogs.Mjahr = int.Parse(ds.Tables[0].Rows[contador]["MJAHR"].ToString().Trim());
                        zTPPLogs.Bwart = ds.Tables[0].Rows[contador]["BWART"].ToString().Trim();
                        zTPPLogs.Rueck = int.Parse(ds.Tables[0].Rows[contador]["RUECK"].ToString().Trim());
                        zTPPLogs.Rmzhl = ds.Tables[0].Rows[contador]["RMZHL"].ToString().Trim()[0];
                        zTPPLogs.Mov_hu = ds.Tables[0].Rows[contador]["MOV_HU"].ToString().Trim();
                        zTPPLogs.Tipo_en = ds.Tables[0].Rows[contador]["TIPO_EN"].ToString().Trim();
                        zTPPLogs.Anulo = ds.Tables[0].Rows[contador]["ANULO"].ToString().Trim();
                        zTPPLogs.Fecha_a = DateTime.Parse(ds.Tables[0].Rows[contador]["FECHA_A"].ToString().Trim());
                        zTPPLogs.Hora_a = DateTime.Parse(ds.Tables[0].Rows[contador]["HORA_A"].ToString().Trim());
                        zTPPLogsCollection.Add(zTPPLogs);
                    }
                }

                return zTPPLogsCollection;

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

        protected ClsZTPPLogsCollection ObtenerChargReimpresion(string psCriterio)
        {
            //Declaración de variables
            DataSet ds = new DataSet();
            //Definición del adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            //Definición de la coleccion
            ClsZTPPLogsCollection zTPPLogsCollection = new ClsZTPPLogsCollection();
            ClsZTPPLogs zTPPLogs;
            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsZTTPLogs, this.Conexion);
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
                        zTPPLogs = new ClsZTPPLogs();

                        zTPPLogs.Charg = ds.Tables[0].Rows[contador]["CHARG"].ToString().Trim();
                        zTPPLogsCollection.Add(zTPPLogs);
                    }
                }

                return zTPPLogsCollection;

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

        protected void AgregarZTPPLogsDAL(ClsZTPPLogs zTPPLogs)
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
                comando.CommandText = Procedimientos.sp_InsLogs;
                //Inserción de parámetros para tranzacción de alta
                EstablecerParametrosDAL("ADD", zTPPLogs, comando);
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

          protected void ActualizarZTPPLogsDAL(ClsZTPPLogs zTPPLogs)
        {

            try
            {
                //Abrir la conexión
                this.Conexion.Open();
                // Start a local transaction.
                SqlTransaction sqlTransaction = Conexion.BeginTransaction();
                //Insertar registro
                SqlCommand comando = this.Conexion.CreateCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ModUsuarios;
                //Inserción de parámetros
                EstablecerParametrosDAL("UPDATE", zTPPLogs, comando);
                comando.Transaction = sqlTransaction;
                comando.ExecuteNonQuery();
                comando.Transaction.Commit();
            }
            catch (Exception ex)
            {
                //Regenerar la excepción pero ahora con un mensaje personalizado para el usuario
                throw new Exception(Errores.ModificarRegistro + Errores.MensajeOriginal + ex.Message.ToString());
            }
            finally
            {
                this.Conexion.Close();
            }
        }

          protected void EliminarZTPPLogs(ClsZTPPLogs zTPPLogs)
        {
            //try
            //{
            //    //Abrir la conexión
            //    this.Conexion.Open();
            //    //Insertar registro
            //    SqlCommand comando = this.Conexion.CreateCommand();
            //    comando.CommandType = CommandType.StoredProcedure;
            //    comando.CommandText = Procedimientos.sp_DelUsuario;
            //    //Inserción de parámetros
            //    comando.Parameters.Add("@IdUsuario", SqlDbType.Decimal).Direction = ParameterDirection.Output;
            //    EstablecerParametrosDAL("UPDATE", usuario, comando);
            //    comando.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    //Regenerar la excepción pero ahora con un mensaje personalizado para el usuario
            //    throw new Exception(Errores.EliminarRegistro + Errores.MensajeOriginal + ex.Message.ToString());
            //}
            //finally
            //{
            //    this.Conexion.Close();
            //}
        }

        protected void EstablecerParametrosDAL(string tipoTran, ClsZTPPLogs ZTPPLogs, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@WERKS", SqlDbType.VarChar).Value = ZTPPLogs.Werks;
                comando.Parameters.Add("@EXIDV", SqlDbType.VarChar).Value = ZTPPLogs.Exidv;
                comando.Parameters.Add("@POSICION", SqlDbType.Int).Value = ZTPPLogs.Posicion;
                comando.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = ZTPPLogs.Fecha;
                comando.Parameters.Add("@HORA", SqlDbType.DateTime).Value = ZTPPLogs.Hora;
                comando.Parameters.Add("@PROCESO", SqlDbType.VarChar).Value = ZTPPLogs.Proceso;
                comando.Parameters.Add("@LGORT", SqlDbType.VarChar).Value = ZTPPLogs.Lgort;
                comando.Parameters.Add("@MATNR", SqlDbType.VarChar).Value = ZTPPLogs.Matnr;
                comando.Parameters.Add("@AUFNR", SqlDbType.VarChar).Value = ZTPPLogs.Aufnr;
                comando.Parameters.Add("@VORNR", SqlDbType.VarChar).Value = ZTPPLogs.Vornr;
                comando.Parameters.Add("@ICON", SqlDbType.VarChar).Value = ZTPPLogs.Icon;
                comando.Parameters.Add("@VEMNG", SqlDbType.Float).Value = ZTPPLogs.Vemng;
                comando.Parameters.Add("@MENSAJE", SqlDbType.VarChar).Value = ZTPPLogs.Message;
                comando.Parameters.Add("@MBLNR", SqlDbType.VarChar).Value = ZTPPLogs.Mblnr;
                comando.Parameters.Add("@MJAHR", SqlDbType.Int).Value = ZTPPLogs.Mjahr;
                comando.Parameters.Add("@BWART", SqlDbType.VarChar).Value = ZTPPLogs.Bwart;
                comando.Parameters.Add("@RUECK", SqlDbType.Int).Value = ZTPPLogs.Rueck;
                comando.Parameters.Add("@RMZHL", SqlDbType.Int).Value = ZTPPLogs.Rmzhl;
                comando.Parameters.Add("@MOV_HU", SqlDbType.VarChar).Value = ZTPPLogs.Mov_hu;
                comando.Parameters.Add("@TIPO_EN", SqlDbType.VarChar).Value = ZTPPLogs.Tipo_en;
                comando.Parameters.Add("@ANULO", SqlDbType.VarChar).Value = ZTPPLogs.Anulo;
                comando.Parameters.Add("@FECHA_A", SqlDbType.DateTime).Value = ZTPPLogs.Fecha_a;
                comando.Parameters.Add("@HORA_A", SqlDbType.DateTime).Value = ZTPPLogs.Hora_a;
               


            }
            catch
            {
                throw;
            }

        }
    }
}
