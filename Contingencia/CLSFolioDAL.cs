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
    class CLSFolioDAL : ClsBase
    {
        CultureInfo currentculture = CultureInfo.GetCultureInfo(Variables.Cultura);

        protected CLSFolioDAL()
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

        protected CLSFolioCollection ConsultarFolioCollection(string psCriterio)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            CLSFolioCollection folioCollection = new CLSFolioCollection();
            CLSFolio folio;

            try
            {

                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsFolioFecha, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        folio = new CLSFolio();
                        folio.Fecha = ds.Tables[0].Rows[contador]["FECHA"].ToString().Trim();
                        folio.Folio = ds.Tables[0].Rows[contador]["FOLIO"].ToString().Trim();
                        folioCollection.Add(folio);
                    }
                }

                return folioCollection;
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

        /*protected DataSet MostrarCatCentro() {
            
            this.Conexion.Open();
            SqlTransaction sqlTransaction = Conexion.BeginTransaction();
            SqlCommand comando = this.Conexion.CreateCommand();

            
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ConsCatCentro;
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

        protected void EstablecerParametrosDAL(string tipoTran, CLSFolio folio, SqlCommand comando)
        {

            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@FECHA", SqlDbType.VarChar).Value = folio.Fecha;
                comando.Parameters.Add("@FOLIO", SqlDbType.VarChar).Value = folio.Folio;
            }
            catch
            {
                throw;
            }

        }
    }
}
