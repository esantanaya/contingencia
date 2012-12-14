using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;

namespace Contingencia
{
    class ClsCatZMasterDAL : ClsBase
    {
         CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);


         protected ClsCatZMasterDAL() 
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

        protected ClsCatZMasterCollection ConsultarZMasterDAL(string psCriterio)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            ClsCatZMasterCollection zMasterColeccion = new ClsCatZMasterCollection();
            ClsCatZMaster zMaster;

            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsCatZMaster, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;

                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        zMaster = new ClsCatZMaster();
                        //ds.Tables[0].Columns[1].ColumnName
                        zMaster.CreadoPor = ds.Tables[0].Rows[contador]["CreadoPor"].ToString().Trim();
                        zMaster.IdTarima = ds.Tables[0].Rows[contador]["IdTarima"].ToString().Trim();
                        zMaster.Werks = ds.Tables[0].Rows[contador]["Werks"].ToString().Trim();
                        zMaster.IdCaja = Convert.ToInt64(ds.Tables[0].Rows[contador]["IdCaja"].ToString().Trim());
                        zMaster.Matnr = ds.Tables[0].Rows[contador]["Matnr"].ToString().Trim();
                        zMaster.Charg = ds.Tables[0].Rows[contador]["Charg"].ToString().Trim();
                        zMaster.Cantidad = Convert.ToDouble(ds.Tables[0].Rows[contador]["Cantidad"].ToString().Trim());
                        zMaster.FechaCreacion = Convert.ToDateTime(ds.Tables[0].Rows[contador]["FechaCreacion"].ToString().Trim());
                        zMaster.FechaProduccion = Convert.ToDateTime(ds.Tables[0].Rows[contador]["FechaProduccion"].ToString().Trim());
                        zMaster.FechaCaducidad = Convert.ToDateTime(ds.Tables[0].Rows[contador]["FechaCaducidad"].ToString().Trim());
                        zMaster.HoraCreacion = Convert.ToDateTime(ds.Tables[0].Rows[contador]["HoraCreacion"].ToString().Trim());
                        zMaster.Desembalada = ds.Tables[0].Rows[contador]["Desembalada"].ToString().Trim();
                        zMaster.Borrado = ds.Tables[0].Rows[contador]["Borrado"].ToString().Trim();
                        zMaster.AsignadaEntrega = ds.Tables[0].Rows[contador]["AsignadaEntrega"].ToString().Trim();
                        zMasterColeccion.Add(zMaster);

                    }
                }

                return zMasterColeccion;
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ConsultarRegistro + Errores.MensajeOriginal + ex.Message.Trim());
            }
            finally
            {
                this.Conexion.Close();
            }
        }


        protected void AgregarZMasterDAL(ClsCatZMaster zMaster)
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
                comando.CommandText = Procedimientos.sp_InsZMaster;
                //Inserción de parámetros para tranzacción de alta
                EstablecerParametrosDAL("ADD", zMaster, comando);
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


        protected void ActualizarZMasterDAL(ClsCatZMaster zMaster)
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
                comando.CommandText = Procedimientos.sp_ModZMaster;
                //Inserción de parámetros
                comando.Parameters.Add("@IdTarima", SqlDbType.VarChar).Value = zMaster.IdTarima;
                comando.Parameters.Add("@Desembalada", SqlDbType.VarChar).Value = zMaster.Desembalada;
                

               // EstablecerParametrosDAL("UPDATE", zMaster, comando);
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

        protected void ActualizarZMasterDestinosDAL(ClsCatZMaster zMaster)
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
                comando.CommandText = Procedimientos.sp_ActualizaDestinoZmaster;
                //Inserción de parámetros
                comando.Parameters.Add("@IdTarima", SqlDbType.VarChar).Value = zMaster.IdTarima;
                comando.Parameters.Add("@CentroDestino", SqlDbType.VarChar).Value = zMaster.CentroDestino;
                comando.Parameters.Add("@AlmacenDestino", SqlDbType.VarChar).Value = zMaster.AlmacenDestino;
                comando.Parameters.Add("@UbicacionDestino", SqlDbType.VarChar).Value = zMaster.UbicacionDestino;

                // EstablecerParametrosDAL("UPDATE", zMaster, comando);
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

        protected void EliminarZMasterDAL(ClsCatZMaster zMaster)
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

        protected void EstablecerParametrosDAL(string tipoTran, ClsCatZMaster zMaster, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@CreadoPor", SqlDbType.VarChar).Value = zMaster.CreadoPor;
                comando.Parameters.Add("@IdTarima", SqlDbType.VarChar).Value = zMaster.IdTarima;
                comando.Parameters.Add("@Werks", SqlDbType.VarChar).Value = zMaster.Werks;
                comando.Parameters.Add("@IdCaja", SqlDbType.Decimal).Value = zMaster.IdCaja;
                comando.Parameters.Add("@Matnr", SqlDbType.VarChar).Value = zMaster.Matnr;
                comando.Parameters.Add("@Charg", SqlDbType.VarChar).Value = zMaster.Charg;
                comando.Parameters.Add("@Cantidad", SqlDbType.Int).Value = zMaster.Cantidad;
                comando.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).Value = zMaster.FechaCreacion;
                comando.Parameters.Add("@FechaProduccion", SqlDbType.DateTime).Value = zMaster.FechaProduccion;
                comando.Parameters.Add("@FechaCaducidad", SqlDbType.DateTime).Value = zMaster.FechaCaducidad;
                comando.Parameters.Add("@HoraCreacion", SqlDbType.DateTime).Value = zMaster.HoraCreacion;
                comando.Parameters.Add("@Desembalada", SqlDbType.VarChar).Value = zMaster.Desembalada;
                comando.Parameters.Add("@Borrado", SqlDbType.VarChar).Value = zMaster.Borrado;
                comando.Parameters.Add("@AsignadaEntrega", SqlDbType.VarChar).Value = zMaster.AsignadaEntrega;

            }
            catch
            {
                throw;
            }

        }



        protected ClsCatZMasterCollection ConsultarNumCajasTarimaDAL(string psCriterio)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            ClsCatZMasterCollection zMasterColeccion = new ClsCatZMasterCollection();
            ClsCatZMaster zMaster;

            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsNumCajasTarima, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;

                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        zMaster = new ClsCatZMaster();
                        //ds.Tables[0].Columns[1].ColumnName
                        zMaster.CreadoPor = ds.Tables[0].Rows[contador]["CreadoPor"].ToString().Trim();
                        zMaster.IdTarima = ds.Tables[0].Rows[contador]["IdTarima"].ToString().Trim();
                        zMaster.Werks = ds.Tables[0].Rows[contador]["Werks"].ToString().Trim();
                        zMaster.IdCaja = Convert.ToInt64(ds.Tables[0].Rows[contador]["IdCaja"].ToString().Trim());
                        zMaster.Matnr = ds.Tables[0].Rows[contador]["Matnr"].ToString().Trim();
                        zMaster.Charg = ds.Tables[0].Rows[contador]["Charg"].ToString().Trim();
                        zMaster.Cantidad = Convert.ToDouble(ds.Tables[0].Rows[contador]["Cantidad"].ToString().Trim());
                        zMaster.FechaCreacion = Convert.ToDateTime(ds.Tables[0].Rows[contador]["FechaCreacion"].ToString().Trim());
                        zMaster.FechaProduccion = Convert.ToDateTime(ds.Tables[0].Rows[contador]["FechaProduccion"].ToString().Trim());
                        zMaster.FechaCaducidad = Convert.ToDateTime(ds.Tables[0].Rows[contador]["FechaCaducidad"].ToString().Trim());
                        zMaster.HoraCreacion = Convert.ToDateTime(ds.Tables[0].Rows[contador]["HoraCreacion"].ToString().Trim());
                        zMaster.Desembalada = ds.Tables[0].Rows[contador]["Desembalada"].ToString().Trim();
                        zMaster.Borrado = ds.Tables[0].Rows[contador]["Borrado"].ToString().Trim();
                        zMaster.AsignadaEntrega = ds.Tables[0].Rows[contador]["AsignadaEntrega"].ToString().Trim();
                        zMasterColeccion.Add(zMaster);

                    }
                }

                return zMasterColeccion;
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ConsultarRegistro + Errores.MensajeOriginal + ex.Message.Trim());
            }
            finally
            {
                this.Conexion.Close();
            }
        }
    }
}
