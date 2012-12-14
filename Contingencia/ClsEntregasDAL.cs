using System;
using System.Data;
using System.Data.SqlClient;

namespace Contingencia
{
    internal class ClsEntregasDAL : ClsBase
    {
        protected ClsEntregasDAL()
        {
            CrearConexion();
        }

        protected ClsEntregasCollection ConsultarEntregasDAL(string psCriterio)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            ClsEntregasCollection entregasCollection = new ClsEntregasCollection();
            ClsEntregas entregas;

            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsEntregas, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@criterio", SqlDbType.VarChar).Value = psCriterio;

                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        entregas = new ClsEntregas();
                        entregas.Entrega = ds.Tables[0].Rows[contador]["vbeln"].ToString().Trim();
                        entregas.DestMercancia = ds.Tables[0].Rows[contador]["kunnr"].ToString().Trim();
                        entregas.Solicitante = ds.Tables[0].Rows[contador]["kunag"].ToString().Trim();
                        entregas.DptoEntrega = ds.Tables[0].Rows[contador]["vstel"].ToString().Trim();
                        entregas.NumPedido = ds.Tables[0].Rows[contador]["bstnk"].ToString().Trim();
                        entregasCollection.Add(entregas);
                    }
                }

                return entregasCollection;
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ConsultarRegistro + Errores.MensajeOriginal + ex.Message.Trim());
            }
            finally
            {
                Conexion.Close();
            }
        }

        protected ClsDetalleCollection ConsultarDetalleDAL(string entrega, string centro)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            ClsDetalleCollection detalleCollection = new ClsDetalleCollection();
            ClsDetalle detalle;

            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsDetalle, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@entrega", SqlDbType.VarChar).Value = entrega;
                da.SelectCommand.Parameters.Add("@centro", SqlDbType.VarChar).Value = centro;

                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        detalle = new ClsDetalle();
                        detalle.Entrega = ds.Tables[0].Rows[contador]["vbeln"].ToString().Trim();
                        detalle.Fecha = Convert.ToDateTime(ds.Tables[0].Rows[contador]["fecha"].ToString().Trim());
                        detalle.Posicion = ds.Tables[0].Rows[contador]["vgpos"].ToString().Trim();
                        detalle.NumMaterial = ds.Tables[0].Rows[contador]["matnr"].ToString().Trim();
                        detalle.Centro = ds.Tables[0].Rows[contador]["werks"].ToString().Trim();
                        detalle.Almacen = ds.Tables[0].Rows[contador]["lgort"].ToString().Trim();
                        detalle.Cantidad = ds.Tables[0].Rows[contador]["lfimg"].ToString().Trim();
                        detalle.UnidadMed = ds.Tables[0].Rows[contador]["meins"].ToString().Trim();
                        detalle.Descripcion = ds.Tables[0].Rows[contador]["maktx"].ToString().Trim();
                        detalle.Picking = ds.Tables[0].Rows[contador]["picking"].ToString().Trim();
                        try
                        {
                            detalle.UniE = int.Parse(ds.Tables[0].Rows[contador]["uniE"].ToString().Trim());
                        }
                        catch {
                            detalle.UniE = 0;
                        }
                        detalleCollection.Add(detalle);
                    }
                }

                return detalleCollection;
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ConsultarRegistro + Errores.MensajeOriginal + ex.Message.Trim());
            }
            finally
            {
                Conexion.Close();
            }
        }

        protected void AgregarTarimaTemporalDAL(ClsTarimaTemporal tarimaTemporal)
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
                comando.CommandText = Procedimientos.sp_InsTarimaTemporal;
                //Inserción de parámetros para tranzacción de alta
                comando.Parameters.Add("@idTarima", SqlDbType.Decimal).Value = tarimaTemporal.IdTarima;
                comando.Parameters.Add("@idEntrega", SqlDbType.VarChar).Value = tarimaTemporal.IdEntrega;
                comando.Parameters.Add("@pedido", SqlDbType.VarChar).Value = tarimaTemporal.Pedido;
                comando.Parameters.Add("@fecha", SqlDbType.DateTime).Value = tarimaTemporal.Fecha;
 
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
                Conexion.Close();
            }
        }

        protected void ActualizarPickingDAL(string entrega, int posicion, string centro, decimal picking, int uniEmp)
        {
            //Abrir la conexión
            this.Conexion.Open();
            // Start a local transaction.
            SqlTransaction sqlTransaction = Conexion.BeginTransaction();
            //Insertar registro
            SqlCommand comando = this.Conexion.CreateCommand();

            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = Procedimientos.sp_ActualizarPicking;
                //Inserción de parámetros para tranzacción de alta
                comando.Parameters.Add("@entrega", SqlDbType.VarChar).Value = entrega;
                comando.Parameters.Add("@posicion", SqlDbType.Int).Value = posicion;
                comando.Parameters.Add("@centro", SqlDbType.VarChar).Value = centro;
                comando.Parameters.Add("@picking", SqlDbType.Decimal).Value = picking;
                comando.Parameters.Add("@uniemp", SqlDbType.Int).Value = uniEmp;

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
                Conexion.Close();
            }
        }

        protected DataSet ConsultarResumenDAL(string entrega, string centro)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsRepoResumen, Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@entrega", SqlDbType.VarChar).Value = entrega;
                da.SelectCommand.Parameters.Add("@centro", SqlDbType.VarChar).Value = centro;

                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ConsultarRegistro + Errores.MensajeOriginal + ex.Message.Trim());
            }
            finally
            {
                Conexion.Close();
            }
        }

        protected DataSet ConsultarResumenDetalleDAL(string entrega, string material, string centro)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsRepoResumenDetalle, Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@entrega", SqlDbType.VarChar).Value = entrega;
                da.SelectCommand.Parameters.Add("@material", SqlDbType.VarChar).Value = material;
                da.SelectCommand.Parameters.Add("@centro", SqlDbType.VarChar).Value = centro;

                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ConsultarRegistro + Errores.MensajeOriginal + ex.Message.Trim());
            }
            finally
            {
                Conexion.Close();
            }
        }

        protected DataSet ConsultarProductoDAL(string entrega, string centro)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsRepoProducto, Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@entrega", SqlDbType.VarChar).Value = entrega;
                da.SelectCommand.Parameters.Add("@centro", SqlDbType.VarChar).Value = centro;

                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ConsultarRegistro + Errores.MensajeOriginal + ex.Message.Trim());
            }
            finally
            {
                Conexion.Close();
            }
        }

        protected DataSet ConsultarRemisionDAL(string entrega, string centro)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsRepoRemision, Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@entrega", SqlDbType.VarChar).Value = entrega;
                da.SelectCommand.Parameters.Add("@centro", SqlDbType.VarChar).Value = centro;

                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ConsultarRegistro + Errores.MensajeOriginal + ex.Message.Trim());
            }
            finally
            {
                Conexion.Close();
            }
        }

        protected DataSet ConsultarRemisionCanalDAL(string entrega, string centro)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsRepoRemisionCanal, Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@entrega", SqlDbType.VarChar).Value = entrega;
                da.SelectCommand.Parameters.Add("@centro", SqlDbType.VarChar).Value = centro;

                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ConsultarRegistro + Errores.MensajeOriginal + ex.Message.Trim());
            }
            finally
            {
                Conexion.Close();
            }
        }

        protected DataSet ConsultarCanalDAL(string entrega, string centro)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsRepoCanal, Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@entrega", SqlDbType.VarChar).Value = entrega;
                da.SelectCommand.Parameters.Add("@centro", SqlDbType.VarChar).Value = centro;

                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ConsultarRegistro + Errores.MensajeOriginal + ex.Message.Trim());
            }
            finally
            {
                Conexion.Close();
            }
        }
    }
}
