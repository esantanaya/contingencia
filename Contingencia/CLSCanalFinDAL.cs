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
    class CLSCanalFinDAL : ClsBase
    {
        CultureInfo currentculture = CultureInfo.GetCultureInfo(Variables.Cultura);

        protected CLSCanalFinDAL()
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

        protected CLSCanalFinCollection ConsultarCanalCollection(string psCriterio)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            CLSCanalFinCollection catCentroCollection = new CLSCanalFinCollection();
            CLSCanalFin canalFin;

            try
            {

                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsCanalFin, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        canalFin = new CLSCanalFin();
                        canalFin.Centro = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        canalFin.CodDestino = ds.Tables[0].Rows[contador]["CODDESTINO"].ToString().Trim();
                        canalFin.OrdenProp = ds.Tables[0].Rows[contador]["ORDENPROP"].ToString().Trim();
                        canalFin.Descripcion = ds.Tables[0].Rows[contador]["DESCRIP"].ToString().Trim();
                        canalFin.Matnr = ds.Tables[0].Rows[contador]["MATNR"].ToString().Trim();
                        canalFin.MatnrVirt= ds.Tables[0].Rows[contador]["MATNR_VIRT"].ToString().Trim();
                        canalFin.Desensamble = ds.Tables[0].Rows[contador]["DESENSAMBLE"].ToString().Trim();
                        canalFin.Autorizado = ds.Tables[0].Rows[contador]["AUTORIZADO"].ToString().Trim();
                        canalFin.ICanaVenta = ds.Tables[0].Rows[contador]["ICANAVENTA"].ToString().Trim();
                        canalFin.IRemisionado = ds.Tables[0].Rows[contador]["IREMISIONADO"].ToString().Trim();
                        canalFin.ICanaCorte = ds.Tables[0].Rows[contador]["ICANACORTE"].ToString().Trim();
                        catCentroCollection.Add(canalFin);
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
                EstablecerParametrosDAL("SELECT", canalFin, comando);
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

        /*protected void ActualizarEstadoDAL(CLSCanalFin canalFin, string criterio)
        {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomEstado;
                comando.Parameters.Add("@estado", SqlDbType.Char).Value = canalFin.Procesado;
                comando.Parameters.Add("@pesoCab", SqlDbType.VarChar).Value = canalFin.PesoCab.ToString();
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

        /*protected void ActalizarDescripcionDAL(CLSCanalFin canalFin, string criterio)
        {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomDestino;
                //comando.Parameters.Add("@codDestino", SqlDbType.VarChar).Value = canalFin.CodDestino;
                comando.Parameters.Add("@destino", SqlDbType.VarChar).Value = canalFin.Destino;
                comando.Parameters.Add("@criterio", SqlDbType.VarChar).Value = criterio;
                comando.Parameters.Add("@pesarCab", SqlDbType.VarChar).Value = canalFin.PesarCab;
                comando.Parameters.Add("@matnr", SqlDbType.VarChar).Value = canalFin.Matnr;
                comando.Parameters.Add("@matnrProd", SqlDbType.VarChar).Value = canalFin.MatnrProd;
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

        protected void ActualizarDestinoDAL(CLSCanalFin canalFin, string criterio)
        {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomCodDestino;
                comando.Parameters.Add("@codDestino", SqlDbType.VarChar).Value = canalFin.CodDestino;
                comando.Parameters.Add("@criterio", SqlDbType.VarChar).Value = criterio;
                comando.Parameters.Add("@pesoSinCabeza", SqlDbType.VarChar).Value = canalFin.PesoSinCabeza.ToString().Trim();
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

        protected void AgregarFatomDAL(CLSCanalFin canalFin)
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
                EstablecerParametrosDAL("ADD", canalFin, comando);
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

        protected void EstablecerParametrosDAL(string tipoTran, CLSCanalFin canalFin, SqlCommand comando)
        {

            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@WERKS ", SqlDbType.VarChar).Value = canalFin.Werks;
                comando.Parameters.Add("@FECHA ", SqlDbType.DateTime).Value = canalFin.Fecha;
                comando.Parameters.Add("@FOLIO ", SqlDbType.SmallInt).Value = canalFin.Folio;
                comando.Parameters.Add("@CHARG ", SqlDbType.VarChar).Value = canalFin.Charg;
                comando.Parameters.Add("@ERFMG", SqlDbType.Float).Value = canalFin.Erfmg;
                comando.Parameters.Add("@ERFME", SqlDbType.VarChar).Value = canalFin.Erfme;
                comando.Parameters.Add("@TARA ", SqlDbType.Float).Value = canalFin.Tara;
                comando.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = canalFin.Serie;
                comando.Parameters.Add("@TATUAJE ", SqlDbType.VarChar).Value = canalFin.Tatuaje;
                comando.Parameters.Add("@PESOPROM ", SqlDbType.Float).Value = canalFin.PesoProm;
                comando.Parameters.Add("@CALIDAD ", SqlDbType.VarChar).Value = canalFin.Calidad;
                comando.Parameters.Add("@CODDESTINO ", SqlDbType.VarChar).Value = canalFin.CodDestino;
                comando.Parameters.Add("@DESTINO ", SqlDbType.VarChar).Value = canalFin.Destino;
                comando.Parameters.Add("@MUSCULO ", SqlDbType.Float).Value = canalFin.Musculo;
                comando.Parameters.Add("@GRASA ", SqlDbType.Float).Value = canalFin.Grasa;
                comando.Parameters.Add("@CHULETA ", SqlDbType.Float).Value = canalFin.Chuleta;
                comando.Parameters.Add("@FECHA_LOTE ", SqlDbType.DateTime).Value = canalFin.FechaLote;
                comando.Parameters.Add("@PESAR_CAB ", SqlDbType.VarChar).Value = canalFin.PesarCab;
                comando.Parameters.Add("@PESO_CAB", SqlDbType.Float).Value = canalFin.PesoCab;
                comando.Parameters.Add("@PESO_SIN_CAB", SqlDbType.Float).Value = canalFin.PesoSinCabeza;
                comando.Parameters.Add("@MATNR ", SqlDbType.VarChar).Value = canalFin.Matnr;
                comando.Parameters.Add("@MATNR_PROD ", SqlDbType.VarChar).Value = canalFin.MatnrProd;
                comando.Parameters.Add("@AUFNR ", SqlDbType.VarChar).Value = canalFin.Aufnr;
                comando.Parameters.Add("@ESTADO", SqlDbType.Char).Value = canalFin.Procesado;
            }
            catch
            {
                throw;
            }

        }*/
    }
}
