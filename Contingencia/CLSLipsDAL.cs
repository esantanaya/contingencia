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
    class CLSLipsDAL : ClsBase
    {
        CultureInfo currentculture = CultureInfo.GetCultureInfo(Variables.Cultura);

        protected CLSLipsDAL()
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

        protected CLSLipsCollection ConsultarLipsCollectionDAL(string psCriterio)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            CLSLipsCollection lipsCollection = new CLSLipsCollection();
            CLSLips lips;

            try
            {

                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsLIPS, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        lips = new CLSLips();
                        lips.Entrega = ds.Tables[0].Rows[contador]["VBELN"].ToString().Trim();
                        lips.Centro = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        lips.Matnr = ds.Tables[0].Rows[contador]["MATNR"].ToString().Trim();
                        lips.Lgort = ds.Tables[0].Rows[contador]["LGORT"].ToString().Trim();
                        lips.Lfimg = Convert.ToDouble(ds.Tables[0].Rows[contador]["LFIMG"].ToString().Trim());
                        lips.Vgbel = ds.Tables[0].Rows[contador]["VGBEL"].ToString().Trim();
                        lips.Vgpos = ds.Tables[0].Rows[contador]["VGPOS"].ToString().Trim();
                        lips.Netpr = ds.Tables[0].Rows[contador]["NETPR"].ToString().Trim();
                        lips.Waerk = ds.Tables[0].Rows[contador]["WAERK"].ToString().Trim();
                        lips.Meins = ds.Tables[0].Rows[contador]["MEINS"].ToString().Trim();
                        try
                        {
                            lips.Picking = double.Parse(ds.Tables[0].Rows[contador]["PICKING"].ToString().Trim());
                        }
                        catch {
                            lips.Picking = 0.0;
                        }
                        try
                        {
                        lips.Uniemp = int.Parse(ds.Tables[0].Rows[contador]["UNIEMP"].ToString().Trim());
                        }
                        catch
                        {
                            lips.Uniemp = 0;
                        }
                        lipsCollection.Add(lips);
                    }
                }

                return lipsCollection;
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

        protected void ActualizarLIPSDAL(CLSLips lipss)
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
                comando.CommandText = Procedimientos.sp_ModLips;
                //Inserción de parámetros
                EstablecerParametrosDAL("UPDATE", lipss, comando);
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

        /*protected DataSet Mostrarorden() {
            
            this.Conexion.Open();
            SqlTransaction sqlTransaction = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_Consorden;
                EstablecerParametrosDAL("SELECT", centro, comando);
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

        protected void EstablecerParametrosDAL(string tipoTran, CLSLips lipss, SqlCommand comando)
        {

            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@VBELN", SqlDbType.VarChar).Value = lipss.Entrega;
                comando.Parameters.Add("@WERKS", SqlDbType.VarChar).Value = lipss.Centro;
                comando.Parameters.Add("@MATNR", SqlDbType.VarChar).Value = lipss.Matnr;
               // comando.Parameters.Add("@LGORT", SqlDbType.VarChar).Value = lipss.Lgort;
               // comando.Parameters.Add("@LFIMG", SqlDbType.Float).Value = lipss.Lfimg;
               // comando.Parameters.Add("@VGBEL", SqlDbType.VarChar).Value = lipss.Vgbel;
                //comando.Parameters.Add("@VGPOS", SqlDbType.Float).Value = lipss.Vgpos;
                //comando.Parameters.Add("@NETPR", SqlDbType.Float).Value = lipss.Netpr;
                //comando.Parameters.Add("@WAERK", SqlDbType.VarChar).Value = lipss.Waerk;
                comando.Parameters.Add("@PICKING", SqlDbType.Float).Value = lipss.Picking;
                comando.Parameters.Add("@UNIEMP", SqlDbType.Int).Value = lipss.Uniemp;
                //comando.Parameters.Add("@MEINS", SqlDbType.VarChar).Value = lipss.Meins;
                
                
            }
            catch
            {
                throw;
            }

        }
    }
}
