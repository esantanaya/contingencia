using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contingencia
{
    class ClsCatAlmacenDAL : ClsBase
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);


        protected ClsCatAlmacenDAL() 
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

        protected ClsCatAlmacenCollection ConsultarAlmacenDAL(string psCriterio)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            ClsCatAlmacenCollection almacenColeccion = new ClsCatAlmacenCollection();
            ClsCatAlmacen almacen;

            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsCatAlmacenes, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;

                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        almacen = new ClsCatAlmacen();
                        almacen.Werks = ds.Tables[0].Rows[contador]["Werks"].ToString().Trim();
                        almacen.Lgort = ds.Tables[0].Rows[contador]["Lgort"].ToString().Trim();
                        almacen.Descripcion = ds.Tables[0].Rows[contador]["Descipcion"].ToString().Trim();
                        almacen.Werks_desc = ds.Tables[0].Rows[contador]["Werks_desc"].ToString().Trim();
                        almacenColeccion.Add(almacen);

                    }
                }

                return almacenColeccion;
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


        protected void AgregarAlmacenDAL(ClsCatAlmacen almacen)
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
                EstablecerParametrosDAL("ADD", almacen, comando);
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

        protected void ActualizarAlmacenDAL(ClsCatAlmacen almacen)
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
                EstablecerParametrosDAL("UPDATE", almacen, comando);
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

        protected void EliminarAlmacenDAL(ClsCatAlmacen almacen)
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

        protected void EstablecerParametrosDAL(string tipoTran, ClsCatAlmacen almacen, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@Werks", SqlDbType.VarChar).Value = almacen.Werks;
                comando.Parameters.Add("@Lgort", SqlDbType.VarChar).Value = almacen.Lgort;
                comando.Parameters.Add("@Descipcion", SqlDbType.VarChar).Value = almacen.Descripcion;
                comando.Parameters.Add("@Werks_desc", SqlDbType.VarChar).Value = almacen.Werks_desc;

            }
            catch
            {
                throw;
            }

        }

        
    }
}
