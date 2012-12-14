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
    class ClsMARADAL : ClsBase
    {
        protected ClsMARADAL()
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

        protected ClsMARACollection ConsultarMARADAL(string psCriterio)
        {

            //Declaración de variables
            DataSet ds = new DataSet();
            //Definición del adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            //Definición de la coleccion
            ClsMARACollection maraCollection = new ClsMARACollection();
            ClsMARA mara;
            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsMARA, this.Conexion);
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
                        mara = new ClsMARA();
                        mara.Matnr = ds.Tables[0].Rows[contador]["MATNR"].ToString().Trim();
                        mara.Etiar = ds.Tables[0].Rows[contador]["ETIAR"].ToString().Trim();
                        mara.Etifo = ds.Tables[0].Rows[contador]["ETIFO"].ToString().Trim();
                        mara.Mhdhb = int.Parse(ds.Tables[0].Rows[contador]["MHDHB"].ToString().Trim());
                        mara.Land1 = ds.Tables[0].Rows[contador]["LAND1"].ToString().Trim();
                        mara.Magrv = ds.Tables[0].Rows[contador]["MAGRV"].ToString().Trim();
                        mara.Maktx = ds.Tables[0].Rows[contador]["MAKTX"].ToString().Trim();
                        mara.Werks = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        mara.Landx = ds.Tables[0].Rows[contador]["LANDX"].ToString().Trim();
                        mara.Ueetk = ds.Tables[0].Rows[contador]["UEETK"].ToString().Trim();
                        mara.Herkl = ds.Tables[0].Rows[contador]["HERKL"].ToString().Trim();
                        mara.Mtart = ds.Tables[0].Rows[contador]["MTART"].ToString().Trim();
                        mara.Xchpf = ds.Tables[0].Rows[contador]["XCHPF"].ToString().Trim();
                        try
                        {
                            mara.Ueeto = double.Parse(ds.Tables[0].Rows[contador]["UEETO"].ToString().Trim());
                        }
                        catch {
                            mara.Ueeto = 0.0;
                        }
                     maraCollection.Add(mara);
                    }
                }

                return maraCollection;

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

        protected void AgregarMARADAL(ClsMARA mara)
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
                EstablecerParametrosDAL("ADD", mara, comando);
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

        protected void ActualizarMARADAL(ClsMARA mara)
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
                EstablecerParametrosDAL("UPDATE", mara, comando);
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

        protected void EliminarMARADAL(ClsMARA mara)
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

        protected void EstablecerParametrosDAL(string tipoTran, ClsMARA mara, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@MATNR", SqlDbType.VarChar).Value = mara.Matnr;
                comando.Parameters.Add("@ETIAR", SqlDbType.VarChar).Value = mara.Etiar;
                comando.Parameters.Add("@ETIFO", SqlDbType.VarChar).Value = mara.Etifo;
                comando.Parameters.Add("@MHDHB", SqlDbType.VarChar).Value = mara.Mhdhb;
                comando.Parameters.Add("@LAND1", SqlDbType.VarChar).Value = mara.Land1;
                comando.Parameters.Add("@MAGRV", SqlDbType.VarChar).Value = mara.Magrv;
                comando.Parameters.Add("@MAKTX", SqlDbType.VarChar).Value = mara.Maktx;
                comando.Parameters.Add("@WERKS", SqlDbType.VarChar).Value = mara.Maktx;
                comando.Parameters.Add("@LANDX", SqlDbType.VarChar).Value = mara.Landx;
                comando.Parameters.Add("@UEETK", SqlDbType.VarChar).Value = mara.Ueetk;
                comando.Parameters.Add("@HERKL", SqlDbType.VarChar).Value = mara.Herkl;
                comando.Parameters.Add("@MTART", SqlDbType.VarChar).Value = mara.Mtart;
                comando.Parameters.Add("@XCHPF", SqlDbType.VarChar).Value = mara.Xchpf;
                comando.Parameters.Add("@UEETO", SqlDbType.VarChar).Value = mara.Ueeto;
            }
            catch
            {
                throw;
            }

        }
    }
}
