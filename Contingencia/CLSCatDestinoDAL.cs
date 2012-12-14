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
    class CLSCatDestinoDAL : ClsBase
    {
        CultureInfo currentculture = CultureInfo.GetCultureInfo(Variables.Cultura);

        protected CLSCatDestinoDAL()
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

        protected CLSCatDestinoCollection ConsultarCatDestinoCollection(string psCriterio)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            CLSCatDestinoCollection CatDestinoCollection = new CLSCatDestinoCollection();
            CLSCatDestino CatDestino;

            try
            {

                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsCatDestino, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        CatDestino = new CLSCatDestino();
                        CatDestino.Werks = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        CatDestino.CodDestino = ds.Tables[0].Rows[contador]["CODDESTINO"].ToString().Trim();
                        CatDestino.DescDestino = ds.Tables[0].Rows[contador]["DESCRIPCION"].ToString().Trim();
                        CatDestino.MatnrComp = ds.Tables[0].Rows[contador]["MATNR_COMP"].ToString().Trim();
                        CatDestino.MatnrProd = ds.Tables[0].Rows[contador]["MATNR_PROD"].ToString().Trim();
                        CatDestino.MatnrMaq = ds.Tables[0].Rows[contador]["MATNR_MAQ"].ToString().Trim();
                        CatDestino.PesarCab = ds.Tables[0].Rows[contador]["PESAR_CAB"].ToString();
                        CatDestinoCollection.Add(CatDestino);
                    }
                }

                return CatDestinoCollection;
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

        /*protected DataSet MostrarCatDestino() {
            
            this.Conexion.Open();
            SqlTransaction sqlTransaction = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ConsCatDestino;
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

        protected void EstablecerParametrosDAL(string tipoTran, CLSCatDestino destino, SqlCommand comando)
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

        }
    }
}
