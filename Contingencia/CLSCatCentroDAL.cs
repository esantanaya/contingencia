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
    class CLSCatCentroDAL : ClsBase
    {
        CultureInfo currentculture = CultureInfo.GetCultureInfo(Variables.Cultura);

        protected CLSCatCentroDAL() {
            try {
                base.CrearConexion();
            } catch {
                throw;
            }
        }

        protected CLSCatCentroCollection ConsultarCatCentroCollection(string psCriterio) 
        {    
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            CLSCatCentroCollection catCentroCollection = new CLSCatCentroCollection();
            CLSCatCentro catCentro;

            try
            {

                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsCatCentro, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        catCentro = new CLSCatCentro();
                        catCentro.CodCentro = ds.Tables[0].Rows[contador]["WERKS"].ToString().Trim();
                        catCentro.DescCentro = ds.Tables[0].Rows[contador]["DESCRIPCION"].ToString().Trim();
                        catCentro.TipoCentro = ds.Tables[0].Rows[contador]["TIPOCENTRO"].ToString().Trim();
                        catCentroCollection.Add(catCentro);
                    }
                }

                return catCentroCollection;
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ConsultarRegistro + Errores.MensajeOriginal + ex.Message.ToString());
            }
            finally {
                this.Conexion.Close();
            }
        }

        protected string ConsultarEstado(string psCriterio)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            string estado = "";
            CLSRFC claseEstado;

            try
            {

                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsEstado, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        claseEstado = new CLSRFC();
                        claseEstado.Estado = ds.Tables[0].Rows[contador]["EstadoContingencia"].ToString().Trim();
                        estado = claseEstado.Estado;
                    }
                }

                return estado;
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

        protected void EstablecerParametrosDAL(string tipoTran, CLSCatCentro centro, SqlCommand comando) {

            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@WERKS", SqlDbType.VarChar).Value = centro.CodCentro;
                comando.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = centro.DescCentro;
                comando.Parameters.Add("@TIPOCENTRO", SqlDbType.VarChar).Value = centro.TipoCentro;
            }
            catch {
                throw;
            }
            
        }
    }
}
