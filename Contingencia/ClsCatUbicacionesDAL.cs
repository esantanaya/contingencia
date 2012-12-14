using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;

namespace Contingencia
{
    class ClsCatUbicacionesDAL : ClsBase
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);


        protected ClsCatUbicacionesDAL() 
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

        protected ClsCatUbicacionesCollection ConsultarUbicacionDAL(string psCriterio)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            ClsCatUbicacionesCollection ubicacionColeccion = new ClsCatUbicacionesCollection();
            ClsCatUbicaciones ubicacion;

            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsCatUbicaciones, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;

                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        ubicacion = new ClsCatUbicaciones();
                        ubicacion.Werks = ds.Tables[0].Rows[contador]["Werks"].ToString().Trim();
                        ubicacion.Lgort = ds.Tables[0].Rows[contador]["Lgort"].ToString().Trim();
                        ubicacion.Ubicacion = ds.Tables[0].Rows[contador]["Ubicaciones"].ToString().Trim();
                        ubicacion.TipoAlmacen = ds.Tables[0].Rows[contador]["Tipoalmacen"].ToString().Trim();
                        ubicacionColeccion.Add(ubicacion);

                    }
                }

                return ubicacionColeccion;
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


        protected void AgregarUbicacionesDAL(ClsCatUbicaciones ubicacion)
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
                EstablecerParametrosDAL("ADD", ubicacion, comando);
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

        protected void ActualizarUbicacionesDAL(ClsCatUbicaciones ubicacion)
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
                EstablecerParametrosDAL("UPDATE", ubicacion, comando);
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

        protected void EliminarUbicacionesDAL(ClsCatUbicaciones ubicacion)
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

        protected void EstablecerParametrosDAL(string tipoTran, ClsCatUbicaciones ubicacion, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@Werks", SqlDbType.VarChar).Value = ubicacion.Werks;
                comando.Parameters.Add("@Lgort", SqlDbType.VarChar).Value = ubicacion.Lgort;
                //comando.Parameters.Add("@Descipcion", SqlDbType.VarChar).Value = ubicacion.Descripcion;
                comando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = ubicacion.Ubicacion;

            }
            catch
            {
                throw;
            }

        }

    }
}
