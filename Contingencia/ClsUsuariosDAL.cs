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
    class ClsUsuariosDAL: ClsBase
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        protected ClsUsuariosDAL()
        {
            //Se genera la conexión a la base cuando es instanciada la clase
            try
            {
                base.CrearConexion();
            }
            catch
            {
                throw;
            }
        }

        protected ClsUsuariosCollection ConsultarUsuariosDAL(string psCriterio)
        {

            //Declaración de variables
            DataSet ds = new DataSet();
            //Definición del adaptador
            SqlDataAdapter da = new SqlDataAdapter();
            //Definición de la coleccion
            ClsUsuariosCollection usuariosCollection = new ClsUsuariosCollection();
            ClsUsuarios usuario;
            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsUsuarios, this.Conexion);
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
                        usuario = new ClsUsuarios();
                        usuario.Usuario = ds.Tables[0].Rows[contador]["IdUsuario"].ToString().Trim();
                        usuario.Clave = ds.Tables[0].Rows[contador]["Clave"].ToString().Trim();
                        usuario.Nombre = ds.Tables[0].Rows[contador]["Nombre"].ToString().Trim();
                        usuario.Estado = ds.Tables[0].Rows[contador]["Estado"].ToString().Trim();
                        usuario.Nivel = Convert.ToInt32(ds.Tables[0].Rows[contador]["Nivel"].ToString().Trim());
                        usuario.FAlta = Convert.ToDateTime(ds.Tables[0].Rows[contador]["FAlta"].ToString().Trim());
                        usuario.Opciones = ds.Tables[0].Rows[contador]["Opciones"].ToString().Trim();
                        usuariosCollection.Add(usuario);
                    }
                }

                return usuariosCollection;

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

        protected void AgregarUsuarioDAL(ClsUsuarios usuario)
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
                EstablecerParametrosDAL("ADD", usuario, comando);
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

        protected void ActualizarUsuarioDAL(ClsUsuarios usuario)
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
                EstablecerParametrosDAL("UPDATE", usuario, comando);
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

        protected void EliminarUsuarioDAL(ClsUsuarios usuario)
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

        protected void EstablecerParametrosDAL(string tipoTran, ClsUsuarios usuario, SqlCommand comando)
        {
            try
            {
                comando.Parameters.Clear();
                comando.Parameters.Add("@IDUsuario", SqlDbType.VarChar).Value = usuario.Usuario;
                comando.Parameters.Add("@Clave", SqlDbType.VarChar).Value = usuario.Clave;
                comando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                /*comando.Parameters.Add("@Paterno", SqlDbType.VarChar).Value = usuario.Paterno;
                 comando.Parameters.Add("@Materno", SqlDbType.VarChar).Value = usuario.Materno;
                 comando.Parameters.Add("@Calle", SqlDbType.VarChar).Value = usuario.Calle;
                 comando.Parameters.Add("@Colonia", SqlDbType.VarChar).Value = usuario.Colonia;
                 comando.Parameters.Add("@Cp", SqlDbType.VarChar).Value = usuario.Cp;
                 comando.Parameters.Add("@Estado", SqlDbType.VarChar).Value = usuario.Estado;
                 comando.Parameters.Add("@Poblacion", SqlDbType.VarChar).Value = usuario.Poblacion;*/
                //comando.Parameters.Add("@Nivel", SqlDbType.VarChar).Value = usuario.Nivel;
                comando.Parameters.Add("@FAlta", SqlDbType.DateTime).Value = DateTime.Now;
                //comando.Parameters.Add("@FMod", SqlDbType.DateTime).Value = Convert.ToDateTime(usuario.FMod);
                comando.Parameters.Add("@Estado", SqlDbType.VarChar).Value = usuario.Estado;
                comando.Parameters.Add("@Opciones", SqlDbType.VarChar).Value = usuario.Opciones;

            }
            catch
            {
                throw;
            }

        }

    }
}
