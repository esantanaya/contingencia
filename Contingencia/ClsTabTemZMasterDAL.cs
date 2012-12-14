using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contingencia
{
    class ClsTabTemZMasterDAL : ClsBase
    {
         CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);


         protected ClsTabTemZMasterDAL() 
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

         protected int ConsultarCantidadMaterialesZMasterDAL(ClsTabTemZMasterCollection tabTemZMasterColeccion, string psCriterio)
         {
             DataSet ds = new DataSet();
             SqlDataAdapter da = new SqlDataAdapter();
             ClsTabTemZMaster tabTemZMaster = new ClsTabTemZMaster();
             

             try
             {
                 da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsMatZMaster, this.Conexion);
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;

                 da.Fill(ds);

                 if (ds.Tables[0].Rows.Count > 0)
                 {
                     int renglones = ds.Tables[0].Rows.Count;
                     int columnas = ds.Tables[0].Columns.Count;

                     for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                     {
                         tabTemZMaster = new ClsTabTemZMaster();
                         tabTemZMaster.Cajas = Convert.ToInt32(ds.Tables[0].Rows[contador]["CAJAS"].ToString().Trim());
                     }
                 }
                 else
                 {
                     tabTemZMaster.Cajas = 0;
                 }

                 return tabTemZMaster.Cajas;
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

         protected ClsTabTemZMasterCollection ConsultarMaterialesZMasterDAL(string psCriterio)
         {
             DataSet ds = new DataSet();
             SqlDataAdapter da = new SqlDataAdapter();
             ClsTabTemZMaster tabTemZMaster = new ClsTabTemZMaster();
             ClsTabTemZMasterCollection tabTempZMasterCol = new ClsTabTemZMasterCollection();


             try
             {
                 da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsMatZMaster, this.Conexion);
                 da.SelectCommand.CommandType = CommandType.StoredProcedure;
                 da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;

                 da.Fill(ds);

                 if (ds.Tables[0].Rows.Count > 0)
                 {
                     int renglones = ds.Tables[0].Rows.Count;
                     int columnas = ds.Tables[0].Columns.Count;

                     for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                     {
                         tabTemZMaster = new ClsTabTemZMaster();

                         tabTemZMaster.Matnr = ds.Tables[0].Rows[contador]["MATNR"].ToString().Trim();
                         tabTempZMasterCol.Add(tabTemZMaster);
                     }
                 }

                 return tabTempZMasterCol;
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

         protected void AgregarTabTemZMasterDAL(ClsTabTemZMaster tabTemZMaster)
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
                comando.CommandText = Procedimientos.sp_InsTabTemZMaster;
                //Inserción de parámetros para tranzacción de alta
                EstablecerParametrosDAL("ADD", tabTemZMaster, comando);
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

        protected void ActualizarTabTemZMasterDAL(ClsTabTemZMaster tabTemZMaster)
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
                EstablecerParametrosDAL("UPDATE", tabTemZMaster, comando);
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

        protected void EliminarTabTemZMasterDAL(ClsTabTemZMaster tabTemZMaster)
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

        protected ClsTabTemZMasterCollection ConsultaZMasterDAL(string psCriterio)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            ClsTabTemZMaster tabTemZMaster = new ClsTabTemZMaster();
            ClsTabTemZMasterCollection tabTempZMasterCol = new ClsTabTemZMasterCollection();


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
                        tabTemZMaster = new ClsTabTemZMaster();

                        tabTemZMaster.Descripcion = ds.Tables[0].Rows[contador]["MAKTX"].ToString().Trim();
                        tabTemZMaster.Cantidad = Convert.ToDouble(ds.Tables[0].Rows[contador]["CANTIDAD"].ToString().Trim());
                        tabTemZMaster.Matnr = ds.Tables[0].Rows[contador]["MATNR"].ToString().Trim();
                        tabTempZMasterCol.Add(tabTemZMaster);
                    }
                }

                return tabTempZMasterCol;
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

        protected void EstablecerParametrosDAL(string tipoTran, ClsTabTemZMaster tabTemZMaster, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                //comando.Parameters.Add("@IdCajas", SqlDbType.Decimal).Value = tabTemZMaster.IdCaja;
                comando.Parameters.Add("@Werks", SqlDbType.VarChar).Value = tabTemZMaster.Werks;
                comando.Parameters.Add("@Mantr", SqlDbType.VarChar).Value = tabTemZMaster.Matnr;
                comando.Parameters.Add("Cantidad", SqlDbType.Decimal).Value = tabTemZMaster.Cantidad;

            }
            catch
            {
                throw;
            }

        }

    }
}
