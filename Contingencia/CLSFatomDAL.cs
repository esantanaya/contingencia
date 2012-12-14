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
    class CLSFatomDAL : ClsBase
    {
        CultureInfo currentculture = CultureInfo.GetCultureInfo(Variables.Cultura);

        protected CLSFatomDAL()
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

        protected CLSFatomCollection ConsultarFatomCollection(string psCriterio)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            CLSFatomCollection catCentroCollection = new CLSFatomCollection();
            CLSFatom fatom;

            try
            {

                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsFatom, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        fatom = new CLSFatom();
                        fatom.Werks = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim().ToUpper();
                        try
                        {
                            fatom.Fecha = Convert.ToDateTime(ds.Tables[0].Rows[contador]["FECHA"].ToString().Trim());
                        }
                        catch 
                        {
                            
                            fatom.Fecha = Convert.ToDateTime("1953-01-01 00:00:00");
                        }
                        fatom.Folio = Convert.ToInt32(ds.Tables[0].Rows[contador]["FOLIO"].ToString().Trim());
                        fatom.Charg = ds.Tables[0].Rows[contador]["CHARG"].ToString().Trim().ToUpper();
                        try
                        {
                            fatom.Erfmg = Convert.ToDouble(ds.Tables[0].Rows[contador]["ERFMG"].ToString().Trim());
                        }
                        catch 
                        {
                            
                            fatom.Erfmg = 0.0;
                        }
                        fatom.Erfme = ds.Tables[0].Rows[contador]["ERFME"].ToString().Trim().ToUpper();
                        try
                        {
                            fatom.Tara = Convert.ToDouble(ds.Tables[0].Rows[contador]["TARA"].ToString().Trim());
                        }
                        catch 
                        {
                            
                            fatom.Tara = 0.0;
                        }
                        fatom.Serie = ds.Tables[0].Rows[contador]["SERIE"].ToString().Trim().ToUpper();
                        fatom.Tatuaje = ds.Tables[0].Rows[contador]["TATUAJE"].ToString().Trim().ToUpper();
                        try
                        {
                            fatom.PesoProm = Convert.ToDouble(ds.Tables[0].Rows[contador]["PESOPROM"].ToString().Trim());
                        }
                        catch 
                        {
                            
                            fatom.PesoProm = 0.0;
                        }
                        fatom.Calidad = ds.Tables[0].Rows[contador]["CALIDAD"].ToString().Trim().ToUpper();
                        fatom.CodDestino = ds.Tables[0].Rows[contador]["CODDESTINO"].ToString().Trim().ToUpper();
                        fatom.Destino = ds.Tables[0].Rows[contador]["DESTINO"].ToString().Trim().ToUpper();
                        try
                        { 
                            fatom.Musculo = Convert.ToDouble(ds.Tables[0].Rows[contador]["MUSCULO"].ToString().Trim());
                        }
                        catch 
                        {
                            
                            fatom.Musculo = 0.0;
                        }
                        try
                        {
                            fatom.Grasa = Convert.ToDouble(ds.Tables[0].Rows[contador]["GRASA"].ToString().Trim());
                        }
                        catch 
                        {
                            
                            fatom.Grasa = 0.0;
                        }
                        try
                        {
                            fatom.Chuleta = Convert.ToDouble(ds.Tables[0].Rows[contador]["CHULETA"].ToString().Trim());
                        }
                        catch 
                        {
                            
                            fatom.Chuleta = 0.0;
                        }
                        try
                        {
                            fatom.FechaLote = Convert.ToDateTime(ds.Tables[0].Rows[contador]["FECHA_LOTE"].ToString().Trim());
                        }
                        catch
                        {
                            
                            fatom.FechaLote = Convert.ToDateTime("1953-01-01 00:00:00");
                        }
                        fatom.PesarCab = ds.Tables[0].Rows[contador]["PESAR_CAB"].ToString().Trim();
                        try
                        {
                            fatom.PesoCab = Convert.ToDouble(ds.Tables[0].Rows[contador]["PESO_CAB"].ToString().Trim());
                        }
                        catch 
                        {
                            
                            fatom.PesoCab = 0.0;
                        }
                        fatom.Matnr = ds.Tables[0].Rows[contador]["MATNR"].ToString().Trim().ToUpper();
                        fatom.MatnrProd = ds.Tables[0].Rows[contador]["MATNR_PROD"].ToString().Trim().ToUpper();
                        fatom.MatnrProd2 = ds.Tables[0].Rows[contador]["MATNR_PROD2"].ToString().Trim().ToUpper();
                        fatom.Aufnr = ds.Tables[0].Rows[contador]["AUFNR"].ToString().Trim().ToUpper();
                        fatom.Procesado = ds.Tables[0].Rows[contador]["ESTADO"].ToString().ToUpper();
                        fatom.ChargProd = ds.Tables[0].Rows[contador]["CHARG_PROD"].ToString().ToUpper();
                        fatom.EstadoMaq = ds.Tables[0].Rows[contador]["ESTADO_MAQ"].ToString().ToUpper();
                        fatom.MatnrProd2Virt = ds.Tables[0].Rows[contador]["MATNR_PROD2_VIRT"].ToString().ToUpper();
                        try
                        {
                            fatom.Kg1 = Convert.ToDouble(ds.Tables[0].Rows[contador]["KG1"].ToString().Trim());
                        }
                        catch
                        {
                            
                            fatom.Kg1 = 0.0;
                        }
                        try
                        {
                            fatom.Kg2 = Convert.ToDouble(ds.Tables[0].Rows[contador]["KG2"].ToString());
                        }
                        catch
                        {

                            fatom.Kg2 = 0.0;
                        }
                        catCentroCollection.Add(fatom);
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
                EstablecerParametrosDAL("SELECT", fatom, comando);
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

        protected void ActualizarEntregaDAL(CLSFatom fatom, string criterio)
        {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomEntrega;
                comando.Parameters.Add("@vbeln", SqlDbType.VarChar).Value = fatom.Vbeln;
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
        }

        protected void ActualizarOrdenesVirtDAL(CLSFatom fatom, string criterio)
        {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomOrdenVirtual;
                comando.Parameters.Add("@aufnr2Virt", SqlDbType.VarChar).Value = fatom.Aufnr2Virt;
                comando.Parameters.Add("@chargProd2Virt", SqlDbType.VarChar).Value = fatom.ChargProd2Virt;
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
        }

        protected void ActualizarOrdenesZPPG02DAL(CLSFatom fatom, string criterio)
        {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomOrdenesZPPG02;
                comando.Parameters.Add("@AUFNR", SqlDbType.VarChar).Value = fatom.Aufnr;
                comando.Parameters.Add("@CHARG_PROD", SqlDbType.VarChar).Value = fatom.Charg;
                //comando.Parameters.Add("@MATNR_MAQ", SqlDbType.VarChar).Value = fatom.MatnrMaq;
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
        }

        protected void ActualizarOrdenesDAL(CLSFatom fatom, string criterio)
        {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomOrdenes;
                comando.Parameters.Add("@AUFNR2", SqlDbType.VarChar).Value = fatom.Aufnr2;
                comando.Parameters.Add("@CHARG_PROD2", SqlDbType.VarChar).Value = fatom.ChargProd2;
                comando.Parameters.Add("@MATNR_MAQ", SqlDbType.VarChar).Value = fatom.MatnrMaq;
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
        }

        protected void AcualizarProductoVirt2DAL(CLSFatom fatom, string criterio) {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomProdVirt2;
                comando.Parameters.Add("@matnrProd2Virt", SqlDbType.VarChar).Value = fatom.MatnrProd2Virt;
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
        }

        protected void ActualizarMaterialesDAL(CLSFatom fatom, string criterio) {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
                {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomMateriales;
                comando.Parameters.Add("@matnrProd2", SqlDbType.VarChar).Value = fatom.MatnrProd2;
                comando.Parameters.Add("@matnrProd2Virt", SqlDbType.VarChar).Value = fatom.MatnrProd2Virt;
                comando.Parameters.Add("@ordenProp", SqlDbType.VarChar).Value = fatom.OrdenProp;
                //comando.Parameters.Add("@desensamble", SqlDbType.VarChar).Value = fatom.Desensamble;
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
        }

        protected void ActualizarEstadoDAL(CLSFatom fatom, string criterio) {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomEstado;
                comando.Parameters.Add("@estado", SqlDbType.Char).Value = fatom.Procesado;
                comando.Parameters.Add("@pesoCab", SqlDbType.VarChar).Value = fatom.PesoCab.ToString();
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
        }

        protected void ActualizarPesosDAL(CLSFatom fatom, string criterio)
        {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomPeso;
                comando.Parameters.Add("@kg1", SqlDbType.VarChar).Value = fatom.Kg1.ToString();
                comando.Parameters.Add("@kg2", SqlDbType.VarChar).Value = fatom.Kg2.ToString();
                comando.Parameters.Add("@fechaCorte", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                comando.Parameters.Add("@horaCorte", SqlDbType.VarChar).Value = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
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
        }

        protected void ActalizarDescripcionDAL(CLSFatom fatom, string criterio) {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomDestino;
                //comando.Parameters.Add("@codDestino", SqlDbType.VarChar).Value = fatom.CodDestino;
                comando.Parameters.Add("@destino", SqlDbType.VarChar).Value = fatom.Destino;
                comando.Parameters.Add("@criterio", SqlDbType.VarChar).Value = criterio;
                comando.Parameters.Add("@pesarCab", SqlDbType.VarChar).Value = fatom.PesarCab;
                comando.Parameters.Add("@matnr", SqlDbType.VarChar).Value = fatom.Matnr;
                comando.Parameters.Add("@matnrProd", SqlDbType.VarChar).Value = fatom.MatnrProd;
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

        protected void ActualizarDestinoDAL(CLSFatom fatom, string criterio) {
            this.Conexion.Open();
            SqlTransaction sqlTrans = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarFatomCodDestino;
                comando.Parameters.Add("@codDestino", SqlDbType.VarChar).Value = fatom.CodDestino;
                comando.Parameters.Add("@criterio", SqlDbType.VarChar).Value = criterio;
                comando.Parameters.Add("@pesoSinCabeza", SqlDbType.VarChar).Value = fatom.PesoSinCabeza.ToString().Trim();
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

        protected void AgregarFatom0R20DAL(CLSFatom fatom)
        {
            this.Conexion.Open();
            SqlTransaction sqlTransaction = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_InsertarFatom0R20;
                //Inserción de parámetros para tranzacción de alta
                //EstablecerParametrosDAL("ADD", fatom, comando);
                comando.Parameters.Add("@werks ", SqlDbType.VarChar).Value = fatom.Werks;
                try
                {
                    comando.Parameters.Add("@fecha ", SqlDbType.DateTime).Value = fatom.Fecha;
                }
                catch
                {

                    comando.Parameters.Add("@FECHA ",SqlDbType.DateTime).Value = new DateTime(1753,01,01);
                }
                comando.Parameters.Add("@folio ", SqlDbType.VarChar).Value = fatom.Folio;
                comando.Parameters.Add("@matnr ", SqlDbType.VarChar).Value = fatom.Matnr;
                comando.Parameters.Add("@matnrProd ", SqlDbType.VarChar).Value = fatom.MatnrProd;
                comando.Parameters.Add("@matnrMaq ", SqlDbType.VarChar).Value = fatom.MatnrMaq;
                comando.Parameters.Add("@codDestino ", SqlDbType.VarChar).Value = fatom.CodDestino;
                comando.Parameters.Add("@chargProd ", SqlDbType.VarChar).Value = fatom.ChargProd;
                comando.Parameters.Add("@aufnr ", SqlDbType.VarChar).Value = fatom.Aufnr;
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

        protected void AgregarFatomDAL(CLSFatom fatom)
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
                EstablecerParametrosDAL("ADD", fatom, comando);
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

        protected void EstablecerParametrosDAL(string tipoTran, CLSFatom fatom, SqlCommand comando)
        {

            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@WERKS ", SqlDbType.VarChar).Value = fatom.Werks;
                comando.Parameters.Add("@FECHA ", SqlDbType.DateTime).Value = fatom.Fecha;
                comando.Parameters.Add("@FOLIO ", SqlDbType.SmallInt).Value = fatom.Folio;
                comando.Parameters.Add("@CHARG ", SqlDbType.VarChar).Value = fatom.Charg;
                comando.Parameters.Add("@ERFMG", SqlDbType.Float).Value = fatom.Erfmg;
                comando.Parameters.Add("@ERFME", SqlDbType.VarChar).Value = fatom.Erfme;
                comando.Parameters.Add("@TARA ", SqlDbType.Float).Value = fatom.Tara;
                comando.Parameters.Add("@SERIE", SqlDbType.VarChar).Value = fatom.Serie;
                comando.Parameters.Add("@TATUAJE ", SqlDbType.VarChar).Value = fatom.Tatuaje;
                comando.Parameters.Add("@PESOPROM ", SqlDbType.Float).Value = fatom.PesoProm;
                comando.Parameters.Add("@CALIDAD ", SqlDbType.VarChar).Value = fatom.Calidad;
                comando.Parameters.Add("@CODDESTINO ", SqlDbType.VarChar).Value = fatom.CodDestino;
                comando.Parameters.Add("@DESTINO ", SqlDbType.VarChar).Value = fatom.Destino;
                comando.Parameters.Add("@MUSCULO ", SqlDbType.Float).Value = fatom.Musculo;
                comando.Parameters.Add("@GRASA ", SqlDbType.Float).Value = fatom.Grasa;
                comando.Parameters.Add("@CHULETA ", SqlDbType.Float).Value = fatom.Chuleta;
                comando.Parameters.Add("@FECHA_LOTE ", SqlDbType.DateTime).Value = fatom.FechaLote;
                comando.Parameters.Add("@PESAR_CAB ", SqlDbType.VarChar).Value = fatom.PesarCab;
                comando.Parameters.Add("@PESO_CAB", SqlDbType.Float).Value = fatom.PesoCab;
                comando.Parameters.Add("@PESO_SIN_CAB", SqlDbType.Float).Value = fatom.PesoSinCabeza;
                comando.Parameters.Add("@MATNR ", SqlDbType.VarChar).Value = fatom.Matnr;
                comando.Parameters.Add("@MATNR_PROD ", SqlDbType.VarChar).Value = fatom.MatnrProd;
                comando.Parameters.Add("@AUFNR ", SqlDbType.VarChar).Value = fatom.Aufnr;
                comando.Parameters.Add("@ESTADO", SqlDbType.Char).Value = fatom.Procesado;
                comando.Parameters.Add("@CHARG_PROD", SqlDbType.VarChar).Value = fatom.ChargProd;
            }
            catch
            {
                throw;
            }

        }
    }
}
