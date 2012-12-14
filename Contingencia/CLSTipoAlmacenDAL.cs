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
    class CLSTipoAlmacenDAL : ClsBase
    {
        CultureInfo currentculture = CultureInfo.GetCultureInfo(Variables.Cultura);

        protected CLSTipoAlmacenDAL()
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

        protected CLSTipoAlmacenCollection ConsultarTipoAlmacenCollection(string psCriterio)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            CLSTipoAlmacenCollection tipoAlmacenCollection = new CLSTipoAlmacenCollection();
            CLSTipoAlmacen tipoAlmacen;

            try
            {

                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsCatTipoAlmacen, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        tipoAlmacen = new CLSTipoAlmacen();
                        tipoAlmacen.Codigo = ds.Tables[0].Rows[contador]["CODIGO"].ToString().Trim();
                        tipoAlmacen.Descripcion = ds.Tables[0].Rows[contador]["DESCRIPCION"].ToString().Trim();
                        tipoAlmacen.Werks = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        tipoAlmacenCollection.Add(tipoAlmacen);
                    }
                }

                return tipoAlmacenCollection;
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
        }

        protected void EstablecerParametrosDAL(string tipoTran, CLSTipoAlmacen tipoAlmacen, SqlCommand comando)
        {

            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@REMISION", SqlDbType.VarChar).Value = tipoAlmacen.Remision;
                comando.Parameters.Add("@TATUAJE", SqlDbType.VarChar).Value = tipoAlmacen.Tatuaje;
                comando.Parameters.Add("@PPC", SqlDbType.VarChar).Value = tipoAlmacen.PesoProm;
                comando.Parameters.Add("@FECHA_REG", SqlDbType.VarChar).Value = tipoAlmacen.Fecha;
            }
            catch
            {
                throw;
            }

        }*/
    }
}