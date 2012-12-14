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
    class CLSOrdenProdDAL : ClsBase
    {
        CultureInfo currentculture = CultureInfo.GetCultureInfo(Variables.Cultura);

        protected CLSOrdenProdDAL()
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

        protected CLSOrdenProdCollection ConsultarOrdenProdCollection(string psCriterio)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            CLSOrdenProdCollection ordenCollection = new CLSOrdenProdCollection();
            CLSOrdenProd orden;

            try
            {

                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsOrdenProd, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        orden = new CLSOrdenProd();
                        orden.Werks = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        orden.Aufnr = ds.Tables[0].Rows[contador]["AUFNR"].ToString().Trim();
                        orden.Charg = ds.Tables[0].Rows[contador]["CHARG"].ToString().Trim();
                        orden.Matnr = ds.Tables[0].Rows[contador]["MATNR"].ToString().Trim();
                        orden.MatnrComp = ds.Tables[0].Rows[contador]["MATNR_COMP"].ToString().Trim();
                        orden.Lgort = ds.Tables[0].Rows[contador]["LGORT"].ToString().Trim();
                        ordenCollection.Add(orden);
                    }
                }

                return ordenCollection;
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

        /*protected void EstablecerParametrosDAL(string tipoTran, CLSOrdenProd destino, SqlCommand comando)
        {

            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@CODDESTINO", SqlDbType.VarChar).Value = destino.CodDestino;
                comando.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = destino.DescDestino;
            }
            catch
            {
                throw;
            }

        }*/
    }
}
