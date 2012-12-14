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
    class ClsZTPPTrazabiDAL : ClsBase
    {
        protected ClsZTPPTrazabiDAL()
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

        protected ClsZTPPTrazabiCollection ConsultarZTPPTrazabiDAL(string psCriterio)
        {

            //Declaración de variables
            DataSet ds = new DataSet();
            //Definición del adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            //Definición de la coleccion
            ClsZTPPTrazabiCollection zTPPTrazabiCollection = new ClsZTPPTrazabiCollection();
            ClsZTPPTrazabi zTPPTrazabi;
            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsZTPPTrazabi, this.Conexion);
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
                        zTPPTrazabi = new ClsZTPPTrazabi();

                        
                        zTPPTrazabi.Werks = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        zTPPTrazabi.Lgort = ds.Tables[0].Rows[contador]["LGORT"].ToString().Trim();
                        zTPPTrazabi.Procedimiento = ds.Tables[0].Rows[contador]["PROCEDIMIENTO"].ToString().Trim();
                        zTPPTrazabi.Fecha = DateTime.Parse(ds.Tables[0].Rows[contador]["FECHA"].ToString().Trim());
                        zTPPTrazabi.Hora = DateTime.Parse(ds.Tables[0].Rows[contador]["HORA"].ToString().Trim());
                        zTPPTrazabi.Tatuaje = ds.Tables[0].Rows[contador]["TATUAJE"].ToString().Trim();
                        zTPPTrazabi.Fechamatanza = DateTime.Parse(ds.Tables[0].Rows[contador]["FECHAMATANZA"].ToString().Trim());
                        zTPPTrazabiCollection.Add(zTPPTrazabi);
                    }
                }

                return zTPPTrazabiCollection;

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

        protected void AgregarZTPPTrazabiDAL(ClsZTPPTrazabi zTPPTrazabi)
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
                comando.CommandText = Procedimientos.sp_InsZ_CTC;
                //Inserción de parámetros para tranzacción de alta
                EstablecerParametrosDAL("ADD", zTPPTrazabi, comando);
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

        protected void ActualizarZTPPTrazabiDAL(ClsZTPPTrazabi zTPPTrazabi)
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
                EstablecerParametrosDAL("UPDATE", zTPPTrazabi, comando);
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

        protected void EliminarZTPPTrazabi(ClsZTPPTrazabi zTPPTrazabi)
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

        protected void EstablecerParametrosDAL(string tipoTran, ClsZTPPTrazabi ZTPPGrupoMat, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();                
                comando.Parameters.Add("@WERKS", SqlDbType.VarChar).Value = ZTPPGrupoMat.Werks;
                comando.Parameters.Add("@LGORT", SqlDbType.VarChar).Value = ZTPPGrupoMat.Lgort;
                comando.Parameters.Add("@PROCEDIMIENTO", SqlDbType.VarChar).Value = ZTPPGrupoMat.Procedimiento;
                comando.Parameters.Add("@FECHA", SqlDbType.DateTime).Value = ZTPPGrupoMat.Fecha;
                comando.Parameters.Add("@HORA", SqlDbType.DateTime).Value = ZTPPGrupoMat.Hora;
                comando.Parameters.Add("@TATUAJE", SqlDbType.Int).Value = ZTPPGrupoMat.Tatuaje;
                comando.Parameters.Add("@FECHAMATANZA", SqlDbType.DateTime).Value = ZTPPGrupoMat.Fechamatanza;
                

            }
            catch
            {
                throw;
            }

        }
    }
}
