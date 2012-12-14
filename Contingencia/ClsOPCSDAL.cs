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
    class ClsOPCSDAL : ClsBase
    {
        protected ClsOPCSDAL()
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

        protected ClsOPCSCollection ConsultarOPCSDAL(string psCriterio)
        {

            //Declaración de variables
            DataSet ds = new DataSet();
            //Definición del adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            //Definición de la coleccion
            ClsOPCSCollection oPCSCollection = new ClsOPCSCollection();
            ClsOPCS oPCS;
            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsOPCS, this.Conexion);
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
                        oPCS = new ClsOPCS();
                        oPCS.Werks = ds.Tables[0].Rows[contador]["DWERK"].ToString().Trim();
                        oPCS.Aufnr = ds.Tables[0].Rows[contador]["AUFNR"].ToString().Trim();
                        oPCS.Objid = ds.Tables[0].Rows[contador]["OBJID"].ToString().Trim();
                        oPCS.Lgort = ds.Tables[0].Rows[contador]["LGORT"].ToString().Trim();
                        oPCS.Charg = ds.Tables[0].Rows[contador]["CHARG"].ToString().Trim();
                        try
                        {
                            oPCS.Gammg = double.Parse(ds.Tables[0].Rows[contador]["GAMMG"].ToString().Trim());
                        }
                        catch {
                            oPCS.Gammg = 0.0;
                        }
                        try
                        {
                            oPCS.Gmein = double.Parse(ds.Tables[0].Rows[contador]["GMEIN"].ToString().Trim());
                        }
                        catch {
                            oPCS.Gmein = 0.0;
                        }
                        try
                        {
                            oPCS.Uebto = double.Parse(ds.Tables[0].Rows[contador]["UEBTO"].ToString().Trim());
                        }
                        catch {
                            oPCS.Uebto = 0.0;
                        }
                        oPCS.Uebtk = ds.Tables[0].Rows[contador]["UEBTK"].ToString().Trim();
                        oPCS.Plnty = ds.Tables[0].Rows[contador]["PLNTY"].ToString().Trim();
                        oPCS.Plnnr = ds.Tables[0].Rows[contador]["PLNNR"].ToString().Trim();
                        oPCS.Plnaw = ds.Tables[0].Rows[contador]["PLNAW"].ToString().Trim();
                        oPCS.Plnal = ds.Tables[0].Rows[contador]["PLNAL"].ToString().Trim();
                        oPCS.Stlbez = ds.Tables[0].Rows[contador]["STLBEZ"].ToString().Trim();
                        oPCS.Rsnum = double.Parse(ds.Tables[0].Rows[contador]["RSNUM"].ToString().Trim());
                        oPCS.Matrnr = ds.Tables[0].Rows[contador]["MATNR"].ToString().Trim();
                        oPCS.Psmng = double.Parse(ds.Tables[0].Rows[contador]["PSMNG"].ToString().Trim());
                        oPCS.Meins = ds.Tables[0].Rows[contador]["MEINS"].ToString().Trim();
                        oPCSCollection.Add(oPCS);
                    }
                }

                return oPCSCollection;

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

        protected void AgregarOPCSDAL(ClsOPCS oPCS)
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
                EstablecerParametrosDAL("ADD", oPCS, comando);
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

        protected void ActualizarOPCSDAL(ClsOPCS oPCS)
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
                EstablecerParametrosDAL("UPDATE", oPCS, comando);
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

        protected void EliminarOPCSDAL(ClsOPCS oPCS)
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

        protected void EstablecerParametrosDAL(string tipoTran, ClsOPCS oPCS, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@WERKS", SqlDbType.VarChar).Value = oPCS.Werks;
                comando.Parameters.Add("@AUFNR", SqlDbType.VarChar).Value = oPCS.Aufnr;
                comando.Parameters.Add("@OBJID", SqlDbType.Char).Value = oPCS.Objid;
                comando.Parameters.Add("@LGORT", SqlDbType.VarChar).Value = oPCS.Lgort;
                comando.Parameters.Add("@CHARG", SqlDbType.VarChar).Value = oPCS.Charg;
                comando.Parameters.Add("@GAMMG", SqlDbType.Float).Value = oPCS.Gammg;
                comando.Parameters.Add("@GMEIN", SqlDbType.Int).Value = oPCS.Gmein;
                comando.Parameters.Add("@UEBTO", SqlDbType.Float).Value = oPCS.Uebto;
                comando.Parameters.Add("@UEBTK", SqlDbType.Char).Value = oPCS.Uebtk;
                comando.Parameters.Add("@PLNTY", SqlDbType.Char).Value = oPCS.Plnty;
                comando.Parameters.Add("@PLNNR", SqlDbType.VarChar).Value = oPCS.Plnnr;
                comando.Parameters.Add("@PLNAW", SqlDbType.Char).Value = oPCS.Plnaw;
                comando.Parameters.Add("@PLNAL", SqlDbType.VarChar).Value = oPCS.Plnal;
                comando.Parameters.Add("@STLBEZ", SqlDbType.VarChar).Value = oPCS.Stlbez;
                comando.Parameters.Add("@RSNUM", SqlDbType.Int).Value = oPCS.Rsnum;
                comando.Parameters.Add("@MATNR", SqlDbType.VarChar).Value = oPCS.Matrnr;
                comando.Parameters.Add("@PSMNG", SqlDbType.VarChar).Value = oPCS.Psmng;
                comando.Parameters.Add("@MEINS", SqlDbType.VarChar).Value = oPCS.Meins;
            }
            catch
            {
                throw;
            }

        }
    }
}
