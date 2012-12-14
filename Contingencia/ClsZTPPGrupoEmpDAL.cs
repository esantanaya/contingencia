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
    class ClsZTPPGrupoEmpDAL : ClsBase
    {
        protected ClsZTPPGrupoEmpDAL()
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

        protected ClsZTPPGrupoEmpCollection ConsultarZTPPGrupoEmpDAL(string psCriterio)
        {

            //Declaración de variables
            DataSet ds = new DataSet();
            //Definición del adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            //Definición de la coleccion
            ClsZTPPGrupoEmpCollection zTPPGrupoEmpCollection = new ClsZTPPGrupoEmpCollection();
            ClsZTPPGrupoEmp zTPPGrupoEmp;
            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsGrupoEmp, this.Conexion);
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
                        zTPPGrupoEmp = new ClsZTPPGrupoEmp();

                        zTPPGrupoEmp.Grupo_Pt = ds.Tables[0].Rows[contador]["GRUPO_PT"].ToString().Trim();
                        zTPPGrupoEmp.Descripcion = ds.Tables[0].Rows[contador]["DESCRIPCION"].ToString().Trim();                                                
                        zTPPGrupoEmp.Pt_Aplicar = double.Parse(ds.Tables[0].Rows[contador]["PT_APLICAR"].ToString().Trim());
                        zTPPGrupoEmp.Meins = ds.Tables[0].Rows[contador]["MEINS"].ToString().Trim();
                        zTPPGrupoEmpCollection.Add(zTPPGrupoEmp);
                    }
                }

                return zTPPGrupoEmpCollection;

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

        protected void AgregarZTPPGrupoEmpDAL(ClsZTPPGrupoEmp zTPPGrupoEmp)
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
                comando.CommandText = Procedimientos.sp_InsZ_CTC;
                //Inserción de parámetros para tranzacción de alta
                EstablecerParametrosDAL("ADD", zTPPGrupoEmp, comando);
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

        protected void ActualizarZTPPGrupoEmpDAL(ClsZTPPGrupoEmp zTPPGrupoEmp)
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
                EstablecerParametrosDAL("UPDATE", zTPPGrupoEmp, comando);
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

        protected void EliminarZTPPGrupoEmp(ClsZTPPGrupoEmp zTPPGrupoEmp)
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

        protected void EstablecerParametrosDAL(string tipoTran, ClsZTPPGrupoEmp zTPPGrupoEmp, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@GRUPO_PT", SqlDbType.VarChar).Value = zTPPGrupoEmp.Grupo_Pt;
                comando.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar).Value = zTPPGrupoEmp.Descripcion;
                comando.Parameters.Add("@PT_APLICAR", SqlDbType.Float).Value = zTPPGrupoEmp.Pt_Aplicar;
                comando.Parameters.Add("@MEINS", SqlDbType.VarChar).Value = zTPPGrupoEmp.Meins;

            }
            catch
            {
                throw;
            }

        }
    }
}
