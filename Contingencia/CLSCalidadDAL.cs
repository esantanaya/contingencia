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
    class CLSCalidadDAL : ClsBase
    {
        CultureInfo currentculture = CultureInfo.GetCultureInfo(Variables.Cultura);

        protected CLSCalidadDAL()
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

        protected CLSCalidadCollection ConsultarCalidadCollection(string psCriterio)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            CLSCalidadCollection calidadCollection = new CLSCalidadCollection();
            CLSCalidad calidad;

            try
            {

                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsCalidad, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        calidad = new CLSCalidad();
                        calidad.Calidad = ds.Tables[0].Rows[contador]["CALIDAD"].ToString().Trim();
                        calidad.PesoIni = ds.Tables[0].Rows[contador]["PESOINI"].ToString().Trim();
                        calidad.PesoFin = ds.Tables[0].Rows[contador]["PESOFIN"].ToString().Trim();
                        calidad.MusculoIni = ds.Tables[0].Rows[contador]["MUSCULOINI"].ToString().Trim();
                        calidad.MusculoFin = ds.Tables[0].Rows[contador]["MUSCULOFIN"].ToString().Trim();
                        calidad.GrasaIni = ds.Tables[0].Rows[contador]["GRASAINI"].ToString().Trim();
                        calidad.GrasaFin = ds.Tables[0].Rows[contador]["GRASAFIN"].ToString().Trim();
                        calidad.ChuletaIni = ds.Tables[0].Rows[contador]["CHULETAINI"].ToString().Trim();
                        calidad.ChuletaFin = ds.Tables[0].Rows[contador]["CHULETAFIN"].ToString().Trim();
                        calidadCollection.Add(calidad);
                    }
                }

                return calidadCollection;
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

        /*protected void EstablecerParametrosDAL(string tipoTran, CLSCalidad calidad, SqlCommand comando)
        {

            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@FECHA", SqlDbType.VarChar).Value = calidad;
                comando.Parameters.Add("@FOLIO", SqlDbType.VarChar).Value = calidad.Folio;
            }
            catch
            {
                throw;
            }

        }*/
    }
}
