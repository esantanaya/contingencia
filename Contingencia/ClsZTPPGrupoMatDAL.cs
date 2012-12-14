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
    class ClsZTPPGrupoMatDAL : ClsBase
    {
        protected ClsZTPPGrupoMatDAL()
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

        protected ClsZTPPGrupoMatCollection ConsultarZTPPGrupoMatDAL(string psCriterio)
        {

            //Declaración de variables
            DataSet ds = new DataSet();
            //Definición del adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            //Definición de la coleccion
            ClsZTPPGrupoMatCollection zTPPGrupoMatCollection = new ClsZTPPGrupoMatCollection();
            ClsZTPPGrupoMat zTPPGrupoMat;
            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsGrupoMat, this.Conexion);
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
                        zTPPGrupoMat = new ClsZTPPGrupoMat();

                        zTPPGrupoMat.Matnr = ds.Tables[0].Rows[contador]["MATNR"].ToString().Trim();
                        zTPPGrupoMat.Werks = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        zTPPGrupoMat.Codigo_Padre = ds.Tables[0].Rows[contador]["CODIGO_PADRE"].ToString().Trim();
                        zTPPGrupoMat.Grupo_pt = ds.Tables[0].Rows[contador]["GRUPO_PT"].ToString().Trim();
                        zTPPGrupoMat.Tiempo_Pro = DateTime.Parse(ds.Tables[0].Rows[contador]["TIEMPO_PRO"].ToString().Trim());
                        zTPPGrupoMat.MotivoEnt = int.Parse(ds.Tables[0].Rows[contador]["MOTIVOENT"].ToString().Trim());
                        zTPPGrupoMat.MotivoCan = int.Parse(ds.Tables[0].Rows[contador]["MOTIVOCAN"].ToString().Trim());
                        zTPPGrupoMat.PesoMax = double.Parse(ds.Tables[0].Rows[contador]["PESOMAX"].ToString().Trim());
                        zTPPGrupoMat.PesoMin = double.Parse(ds.Tables[0].Rows[contador]["PESOMIN"].ToString().Trim());
                        zTPPGrupoMat.PesoFijo = double.Parse(ds.Tables[0].Rows[contador]["PESOFIJO"].ToString().Trim());
                        zTPPGrupoMat.Meins = ds.Tables[0].Rows[contador]["MEINS"].ToString().Trim();
                        zTPPGrupoMat.TaraEdit = ds.Tables[0].Rows[contador]["TARAEDIT"].ToString().Trim();
                        zTPPGrupoMat.Procedimiento = ds.Tables[0].Rows[contador]["PROCEDIMIENTO"].ToString().Trim();
                        zTPPGrupoMat.Clave_Rend = ds.Tables[0].Rows[contador]["CLAVE_REND"].ToString().Trim();
                        zTPPGrupoMatCollection.Add(zTPPGrupoMat);
                    }
                }

                return zTPPGrupoMatCollection;

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

        protected void AgregarZTPPGrupoMatDAL(ClsZTPPGrupoMat zTPPGrupoMat)
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
                EstablecerParametrosDAL("ADD", zTPPGrupoMat, comando);
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

        protected void ActualizarZTPPGrupoMatDAL(ClsZTPPGrupoMat zTPPGrupoMat)
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
                EstablecerParametrosDAL("UPDATE", zTPPGrupoMat, comando);
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

        protected void EliminarZTPPGrupoMat(ClsZTPPGrupoMat zTPPGrupoMat)
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

        protected void EstablecerParametrosDAL(string tipoTran, ClsZTPPGrupoMat ZTPPGrupoMat, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@MATNR", SqlDbType.VarChar).Value = ZTPPGrupoMat.Matnr;
                comando.Parameters.Add("@WERKS", SqlDbType.VarChar).Value = ZTPPGrupoMat.Werks;
                comando.Parameters.Add("@CODIGO_PADRE", SqlDbType.VarChar).Value = ZTPPGrupoMat.Codigo_Padre;
                comando.Parameters.Add("@GRUPO_PT", SqlDbType.VarChar).Value = ZTPPGrupoMat.Grupo_pt;
                comando.Parameters.Add("@TIEMPO_PRO", SqlDbType.DateTime).Value = ZTPPGrupoMat.Tiempo_Pro;
                comando.Parameters.Add("@MOTIVOENT", SqlDbType.Int).Value = ZTPPGrupoMat.MotivoEnt;
                comando.Parameters.Add("@MOTIVOCAN", SqlDbType.Int).Value = ZTPPGrupoMat.MotivoCan;
                comando.Parameters.Add("@PESOMAX", SqlDbType.Float).Value = ZTPPGrupoMat.PesoMax;
                comando.Parameters.Add("@PESOMIN", SqlDbType.Float).Value = ZTPPGrupoMat.PesoMin;
                comando.Parameters.Add("@PESOFIJO", SqlDbType.Float).Value = ZTPPGrupoMat.PesoFijo;
                comando.Parameters.Add("@MEINS", SqlDbType.Int).Value = ZTPPGrupoMat.Meins;
                comando.Parameters.Add("@TARAEDIT", SqlDbType.Char).Value = ZTPPGrupoMat.TaraEdit;
                comando.Parameters.Add("@PROCEDIMIENTO", SqlDbType.VarChar).Value = ZTPPGrupoMat.Procedimiento;
                comando.Parameters.Add("@CLAVE_REND", SqlDbType.VarChar).Value = ZTPPGrupoMat.Clave_Rend;
                


            }
            catch
            {
                throw;
            }

        }
    }
}
