using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contingencia
{
    class ClsResbDAL :ClsBase
    {
         protected ClsResbDAL()
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

         protected ClsResbCollection ConsultarResbDAL(string psCriterio)
        {

            //Declaración de variables
            DataSet ds = new DataSet();
            //Definición del adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            //Definición de la coleccion
            ClsResbCollection resbCollection = new ClsResbCollection();
            ClsResb resb;
            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsRESB, this.Conexion);
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
                        resb = new ClsResb();

                        resb.Rsnum = int.Parse(ds.Tables[0].Rows[contador]["RSNUM"].ToString().Trim());
                        resb.Matnr = ds.Tables[0].Rows[contador]["MATNR"].ToString().Trim();
                        resb.Aufnr = ds.Tables[0].Rows[contador]["AUFNR"].ToString().Trim();
                        resb.Potx1 = ds.Tables[0].Rows[contador]["POTX1"].ToString().Trim();
                        resb.Potx2 = ds.Tables[0].Rows[contador]["POTX2"].ToString().Trim();
                        resb.Potx3 = ds.Tables[0].Rows[contador]["POTX3"].ToString().Trim();
                        resb.Baugr = ds.Tables[0].Rows[contador]["BAUGR"].ToString().Trim();
                        resb.Bdmng = double.Parse(ds.Tables[0].Rows[contador]["BDMNG"].ToString().Trim());
                        resb.Meins = ds.Tables[0].Rows[contador]["MEINS"].ToString().Trim();
                        resb.Werks = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        resb.Menge = double.Parse(ds.Tables[0].Rows[contador]["MENGE"].ToString().Trim());
                        resb.Bwart = ds.Tables[0].Rows[contador]["BWART"].ToString().Trim();
                        resb.Lgort = ds.Tables[0].Rows[contador]["LGORT"].ToString().Trim();
                        resbCollection.Add(resb);
                    }
                }

                return resbCollection;

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

        protected void AgregarResbDAL(ClsResb resb)
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
                EstablecerParametrosDAL("ADD", resb, comando);
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

        protected void ActualizarResbDAL(ClsResb resb)
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
                EstablecerParametrosDAL("UPDATE", resb, comando);
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

        protected void EliminarResbDAL(ClsResb resb)
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

        protected void EstablecerParametrosDAL(string tipoTran, ClsResb resb, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@RSNUM", SqlDbType.Int).Value = resb.Rsnum;
                comando.Parameters.Add("@MATNR", SqlDbType.VarChar).Value = resb.Matnr;
                comando.Parameters.Add("@AUFNR", SqlDbType.VarChar).Value = resb.Aufnr;
                comando.Parameters.Add("@POTX1", SqlDbType.DateTime).Value = resb.Potx1;
                comando.Parameters.Add("@POTX2", SqlDbType.DateTime).Value = resb.Potx2;
                comando.Parameters.Add("@POTX3", SqlDbType.DateTime).Value = resb.Potx3;
                comando.Parameters.Add("@BAUGR", SqlDbType.Int).Value = resb.Baugr;
                comando.Parameters.Add("@BDMNG", SqlDbType.Int).Value = resb.Bdmng;
                comando.Parameters.Add("@MEINS", SqlDbType.Int).Value = resb.Meins;
                comando.Parameters.Add("@WERKS", SqlDbType.VarChar).Value = resb.Werks;
                comando.Parameters.Add("@MENGE", SqlDbType.Int).Value = resb.Menge;
                comando.Parameters.Add("@BWART", SqlDbType.Float).Value = resb.Bwart;
                


            }
            catch
            {
                throw;
            }

        }
    }
}
