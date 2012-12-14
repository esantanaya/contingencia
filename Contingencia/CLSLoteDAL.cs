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
    class CLSLoteDAL : ClsBase
    {
        CultureInfo currentculture = CultureInfo.GetCultureInfo(Variables.Cultura);

        protected CLSLoteDAL()
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

        protected CLSLoteCollection ConsultarLoteCollection(string psCriterio)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            CLSLoteCollection loteCollection = new CLSLoteCollection();
            CLSLote lote;

            try
            {

                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsLote, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        lote = new CLSLote();
                        lote.Almacen = ds.Tables[0].Rows[contador]["LGORT"].ToString().Trim();
                        lote.Lote = ds.Tables[0].Rows[contador]["CHARG"].ToString().Trim();
                        lote.Remision = ds.Tables[0].Rows[contador]["REMISION"].ToString().Trim();
                        lote.Tatuaje = ds.Tables[0].Rows[contador]["TATUAJE"].ToString().Trim();
                        lote.PesoProm = ds.Tables[0].Rows[contador]["PPC"].ToString().Trim();
                        lote.Fecha = ds.Tables[0].Rows[contador]["FECHA_REG"].ToString().Trim();
                        lote.Clabs = Convert.ToDouble(ds.Tables[0].Rows[contador]["CLABS"].ToString().Trim());
                        lote.CwmClabs = Convert.ToDouble(ds.Tables[0].Rows[contador]["/CWM/CLABS"].ToString().Trim());
                        loteCollection.Add(lote);
                    }
                }

                return loteCollection;
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

        protected void EstablecerParametrosDAL(string tipoTran, CLSLote lote, SqlCommand comando)
        {

            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@REMISION", SqlDbType.VarChar).Value = lote.Remision;
                comando.Parameters.Add("@TATUAJE", SqlDbType.VarChar).Value = lote.Tatuaje;
                comando.Parameters.Add("@PPC", SqlDbType.VarChar).Value = lote.PesoProm;
                comando.Parameters.Add("@FECHA_REG", SqlDbType.VarChar).Value = lote.Fecha;
            }
            catch
            {
                throw;
            }

        }
    }
}
