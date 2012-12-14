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
    class CLSTraspCalidadDAL : ClsBase
    {
        CultureInfo currentculture = CultureInfo.GetCultureInfo(Variables.Cultura);

        protected CLSTraspCalidadDAL()
        {
            try
            {
                base.CrearConexion();
            }
            catch
            {
                throw;
            }
        }

        protected CLSTraspCalidadCollection ConsultarTraspCalidadCollection(string psCriterio)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            CLSTraspCalidadCollection catCentroCollection = new CLSTraspCalidadCollection();
            CLSTraspCalidad traspCalidad;

            try
            {

                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsTraspCalidad, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        traspCalidad = new CLSTraspCalidad();
                        traspCalidad.Centro = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        traspCalidad.CodDestino = ds.Tables[0].Rows[contador]["CODDESTINO"].ToString().Trim();
                        traspCalidad.Calidad = ds.Tables[0].Rows[contador]["CALIDAD"].ToString().Trim();
                        traspCalidad.MatnrOrden = ds.Tables[0].Rows[contador]["MATNR_ORDEN"].ToString().Trim();
                        traspCalidad.MatnrConv = ds.Tables[0].Rows[contador]["MATNR_CONV"].ToString().Trim();
                        catCentroCollection.Add(traspCalidad);
                    }
                }

                return catCentroCollection;
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ConsultarRegistro + Errores.MensajeOriginal + ex.Message.ToString());
            }
            finally
            {
                this.Conexion.Close();
            }
        }

        /*protected DataSet MostrarCatCentro() {
            
            this.Conexion.Open();
            SqlTransaction sqlTransaction = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ConsCatCentro;
                EstablecerParametrosDAL("SELECT", traspCalidad, comando);
                comando.Transaction = sqlTransaction;
                comando.ExecuteNonQuery();
                comando.Transaction.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ModificarRegistro + Errores.MensajeOriginal + ex.Message.ToString());
            }
            finally {
                this.Conexion.Close();
            }
        }*/

        /*protected void ActualizarEstadoDAL(CLSTraspCalidad traspCalidad, string criterio)
        {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomEstado;
                comando.Parameters.Add("@estado", SqlDbType.Char).Value = traspCalidad.Procesado;
                comando.Parameters.Add("@pesoCab", SqlDbType.VarChar).Value = traspCalidad.PesoCab.ToString();
                comando.Parameters.Add("@criterio", SqlDbType.VarChar).Value = criterio;
                comando.Transaction = sqlTrans;
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
        }*/

        /*protected void ActalizarDescripcionDAL(CLSTraspCalidad traspCalidad, string criterio)
        {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomDestino;
                //comando.Parameters.Add("@codDestino", SqlDbType.VarChar).Value = traspCalidad.CodDestino;
                comando.Parameters.Add("@destino", SqlDbType.VarChar).Value = traspCalidad.Destino;
                comando.Parameters.Add("@criterio", SqlDbType.VarChar).Value = criterio;
                comando.Parameters.Add("@pesarCab", SqlDbType.VarChar).Value = traspCalidad.PesarCab;
                comando.Parameters.Add("@matnr", SqlDbType.VarChar).Value = traspCalidad.Matnr;
                comando.Parameters.Add("@matnrProd", SqlDbType.VarChar).Value = traspCalidad.MatnrProd;
                comando.Transaction = sqlTrans;
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

        protected void ActualizarDestinoDAL(CLSTraspCalidad traspCalidad, string criterio)
        {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomCodDestino;
                comando.Parameters.Add("@codDestino", SqlDbType.VarChar).Value = traspCalidad.CodDestino;
                comando.Parameters.Add("@criterio", SqlDbType.VarChar).Value = criterio;
                comando.Parameters.Add("@pesoSinCabeza", SqlDbType.VarChar).Value = traspCalidad.PesoSinCabeza.ToString().Trim();
                comando.Transaction = sqlTrans;
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

        protected void AgregarFatomDAL(CLSTraspCalidad traspCalidad)
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
                comando.CommandText = Procedimientos.sp_InsZPPG01_FATOM;
                //Inserción de parámetros para tranzacción de alta
                EstablecerParametrosDAL("ADD", traspCalidad, comando);
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

        protected void EstablecerParametrosDAL(string tipoTran, CLSTraspCalidad traspCalidad, SqlCommand comando)
        {

            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@WERKS ", SqlDbType.VarChar).Value = traspCalidad.Werks;
                comando.Parameters.Add("@FECHA ", SqlDbType.DateTime).Value = traspCalidad.Fecha;
                comando.Parameters.Add("@FOLIO ", SqlDbType.SmallInt).Value = traspCalidad.Folio;
                comando.Parameters.Add("@CHARG ", SqlDbType.VarChar).Value = traspCalidad.Charg;
                comando.Parameters.Add("@ERFMG", SqlDbType.Float).Value = traspCalidad.Erfmg;
                comando.Parameters.Add("@ERFME", SqlDbType.VarChar).Value = traspCalidad.Erfme;
                comando.Parameters.Add("@TARA ", SqlDbType.Float).Value = traspCalidad.Tara;
                comando.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = traspCalidad.Serie;
                comando.Parameters.Add("@TATUAJE ", SqlDbType.VarChar).Value = traspCalidad.Tatuaje;
                comando.Parameters.Add("@PESOPROM ", SqlDbType.Float).Value = traspCalidad.PesoProm;
                comando.Parameters.Add("@CALIDAD ", SqlDbType.VarChar).Value = traspCalidad.Calidad;
                comando.Parameters.Add("@CODDESTINO ", SqlDbType.VarChar).Value = traspCalidad.CodDestino;
                comando.Parameters.Add("@DESTINO ", SqlDbType.VarChar).Value = traspCalidad.Destino;
                comando.Parameters.Add("@MUSCULO ", SqlDbType.Float).Value = traspCalidad.Musculo;
                comando.Parameters.Add("@GRASA ", SqlDbType.Float).Value = traspCalidad.Grasa;
                comando.Parameters.Add("@CHULETA ", SqlDbType.Float).Value = traspCalidad.Chuleta;
                comando.Parameters.Add("@FECHA_LOTE ", SqlDbType.DateTime).Value = traspCalidad.FechaLote;
                comando.Parameters.Add("@PESAR_CAB ", SqlDbType.VarChar).Value = traspCalidad.PesarCab;
                comando.Parameters.Add("@PESO_CAB", SqlDbType.Float).Value = traspCalidad.PesoCab;
                comando.Parameters.Add("@PESO_SIN_CAB", SqlDbType.Float).Value = traspCalidad.PesoSinCabeza;
                comando.Parameters.Add("@MATNR ", SqlDbType.VarChar).Value = traspCalidad.Matnr;
                comando.Parameters.Add("@MATNR_PROD ", SqlDbType.VarChar).Value = traspCalidad.MatnrProd;
                comando.Parameters.Add("@AUFNR ", SqlDbType.VarChar).Value = traspCalidad.Aufnr;
                comando.Parameters.Add("@ESTADO", SqlDbType.Char).Value = traspCalidad.Procesado;
            }
            catch
            {
                throw;
            }

        }*/
    }
}
