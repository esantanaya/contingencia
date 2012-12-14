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
    class ClsPLPODAL: ClsBase
    {
        protected ClsPLPODAL()
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

        protected ClsPLPOCollection ConsultarPLPODAL(string psCriterio)
        {

            //Declaración de variables
            DataSet ds = new DataSet();
            //Definición del adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            //Definición de la coleccion
            ClsPLPOCollection pLPOCollection = new ClsPLPOCollection();
            ClsPLPO pLPO;
            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsPLPO, this.Conexion);
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
                        pLPO = new ClsPLPO();
                        pLPO.Plnty = ds.Tables[0].Rows[contador]["PLNTY"].ToString().Trim();
                        pLPO.Plnnr = ds.Tables[0].Rows[contador]["PLNNR"].ToString().Trim();
                        try
                        {
                            pLPO.Plnkn = int.Parse(ds.Tables[0].Rows[contador]["PLNKN"].ToString().Trim());
                        }
                        catch
                        {
                            pLPO.Plnkn = 0;
                        }
                        pLPO.Loekz = ds.Tables[0].Rows[contador]["LOEKZ"].ToString().Trim();
                        pLPO.Vornr = ds.Tables[0].Rows[contador]["VORNR"].ToString().Trim();
                        pLPO.Phflg = ds.Tables[0].Rows[contador]["PHFLG"].ToString().Trim();
                        pLPOCollection.Add(pLPO);
                    }
                }

                return pLPOCollection;

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

        protected void AgregarPLPODAL(ClsPLPO pLPO)
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
                comando.CommandText = Procedimientos.sp_InsUsuarios;
                //Inserción de parámetros para tranzacción de alta
                EstablecerParametrosDAL("ADD", pLPO, comando);
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

        protected void ActualizarPLPODAL(ClsPLPO pLPO)
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
                EstablecerParametrosDAL("UPDATE", pLPO, comando);
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

        protected void EliminarPLPODAL(ClsPLPO pLPO)
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

        protected void EstablecerParametrosDAL(string tipoTran, ClsPLPO pLPO, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@PLNTY", SqlDbType.VarChar).Value = pLPO.Plnty;
                comando.Parameters.Add("@PLNNR", SqlDbType.VarChar).Value = pLPO.Plnnr;
                comando.Parameters.Add("@PLNKN", SqlDbType.VarChar).Value = pLPO.Plnkn;
                comando.Parameters.Add("@LOEKZ", SqlDbType.VarChar).Value = pLPO.Loekz;
                comando.Parameters.Add("@VORNR", SqlDbType.VarChar).Value = pLPO.Vornr;
                comando.Parameters.Add("@PHFLG", SqlDbType.VarChar).Value = pLPO.Phflg;
                

            }
            catch
            {
                throw;
            }

        }
    }
}
