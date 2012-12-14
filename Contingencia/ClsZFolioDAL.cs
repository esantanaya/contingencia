using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contingencia
{
    class ClsZFolioDAL : ClsBase
    {
        protected ClsZFolioDAL()
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

        protected ClsZFolioCollection ConsultarZFolioDAL(string psCriterio)
        {

            //Declaración de variables
            DataSet ds = new DataSet();
            //Definición del adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            //Definición de la coleccion
            ClsZFolioCollection zZFolioCollection = new ClsZFolioCollection();
            ClsZFolio zFolio;
            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsZ_CTC, this.Conexion);
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
                        zFolio = new ClsZFolio();

                        zFolio.Werks = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        zFolio.Tipo = ds.Tables[0].Rows[contador]["TIPO"].ToString().Trim();
                        zFolio.Pref = ds.Tables[0].Rows[contador]["PREF"].ToString().Trim();
                        zFolio.Nbr = ds.Tables[0].Rows[contador]["NBR"].ToString().Trim();
                        zZFolioCollection.Add(zFolio);
                    }
                }

                return zZFolioCollection;

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

        protected ClsZFolioCollection AgregaryRetornoZFolioDAL(ClsZFolio zfolio)
        {

            //Declaración de variables
            DataSet ds = new DataSet();
            //Definición del adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            //Definición de la coleccion
            ClsZFolioCollection zZFolioCollection = new ClsZFolioCollection();
            ClsZFolio zFolio;
            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsInsFolioRegresaElRegistroInsertado, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@WERKS", SqlDbType.VarChar).Value = zfolio.Werks;
                da.SelectCommand.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = zfolio.Tipo;
                da.SelectCommand.Parameters.Add("@PREFIJO", SqlDbType.VarChar).Value = zfolio.Pref;
                //Se llena el DataSet
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;
                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++) //Cada renglòn
                    {
                        zFolio = new ClsZFolio();

                        zFolio.Werks = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        zFolio.Tipo = ds.Tables[0].Rows[contador]["TIPO"].ToString().Trim();
                        zFolio.Pref = ds.Tables[0].Rows[contador]["PREFIJO"].ToString().Trim();
                        zFolio.Nbr = ds.Tables[0].Rows[contador]["NBR"].ToString().Trim();
                        zZFolioCollection.Add(zFolio);
                    }
                }

                return zZFolioCollection;

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

        protected void AgregarZFolioDAL(ClsZFolio zFolio)
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
                EstablecerParametrosDAL("ADD", zFolio, comando);
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

        protected void ActualizarZFolioDAL(ClsZFolio zFolio)
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
                EstablecerParametrosDAL("UPDATE", zFolio, comando);
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

        protected void EliminarZFolio(ClsZFolio zFolio)
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

        protected void EstablecerParametrosDAL(string tipoTran, ClsZFolio zFolio, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@WERKS", SqlDbType.VarChar).Value = zFolio.Werks;
                comando.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = zFolio.Tipo;
                comando.Parameters.Add("@PREF", SqlDbType.VarChar).Value = zFolio.Pref;
                

            }
            catch
            {
                throw;
            }

        }

        protected void EstablecerParametros2DAL(string tipoTran, ClsZFolio zFolio, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@WERKS", SqlDbType.VarChar).Value = zFolio.Werks;
                comando.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = zFolio.Tipo;
                comando.Parameters.Add("@PREF", SqlDbType.VarChar).Value = zFolio.Pref;


            }
            catch
            {
                throw;
            }

        }

    }
}
