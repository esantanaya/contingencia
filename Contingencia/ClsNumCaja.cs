using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;


namespace Contingencia
{
    class ClsNumCaja : ClsBase
    {
        string tarima = "";
        string caja = "";
        string pieza = "";
        string lugar = "";
        long numFolio = 0;

        public long NumFolio
        {
            get { return numFolio; }
            set { numFolio = value; }
        }

        ArrayList lst = new ArrayList();
        //  ArrayList<String> lstRL = new ArrayList<String>();


        public ArrayList Lst
        {
            get { return lst; }
            set { lst = value; }
        }

        public string Tarima
        {
            get { return tarima; }
            set { tarima = value; }
        }


        public string Caja
        {
            get { return caja; }
            set { caja = value; }
        }


        public string Pieza
        {
            get { return pieza; }
            set { pieza = value; }
        }


        public string Lugar
        {
            get { return lugar; }
            set { lugar = value; }
        }

        public double cantidadAcomulada(string iCantidad)
        {
            double a;

            char[] arrayNotArroba = { ']' };
            String[] b = iCantidad.Split(arrayNotArroba);
            a = Convert.ToDouble(b[4].ToString().Remove(0, 1));
            return a;

        }

        public string BackCadenaMatnr(string matnr)
        {
            string a = "";

            char[] arrayNotArroba = { ']' };
            String[] b = matnr.Split(arrayNotArroba);
            a = b[1].ToString().Remove(0, 1);
            return a;
        }

        public string BackCadena(string Cad)
        {
            string a = "";

            char[] arrayNotArroba = { ']' };
            String[] b = Cad.Split(arrayNotArroba);
            a = b[0].ToString().Remove(0, 1);
            return a;

        }

        public string BackCadenaWerks(string Cad)
        {
            string a = "";

            char[] arrayNotArroba = { ']' };
            String[] b = Cad.Split(arrayNotArroba);
            a = b[5].ToString().Remove(0, 1);
            return a;
        }

        public string BackCadenaLote(string Cad)
        {
            string a = "";

            char[] arrayNotArroba = { ']' };
            String[] b = Cad.Split(arrayNotArroba);
            a = b[2].ToString().Remove(0, 1);
            return a;
        }


        public bool verificaIDcaja(string numCaja)
        {
            string lsSQLAux = "";
            string lsIDcajas = "";
            bool banExiste = true;
            ClsZTPPLogsCollection coleccionCajas;

            int longitud = numCaja.Length;
            //while (longitud < 20)
            //{
            //    numCaja = "0" + numCaja;
            //    longitud++;
            //}

            lsSQLAux = "WHERE exidv ='" + numCaja + "'";
            coleccionCajas = (new ClsZTPPLogsBAL()).ConsultarZTPPLogsBAL(lsSQLAux);

            if (coleccionCajas.Count != 0)
            {
                IEnumerator lstCajas = coleccionCajas.GetEnumerator();
                while (lstCajas.MoveNext())
                {
                    ClsZTPPLogs tabZTPPLogs = (ClsZTPPLogs)lstCajas.Current;
                    lsIDcajas = tabZTPPLogs.Exidv.ToString();
                    if (numCaja == lsIDcajas)
                    { banExiste = true; }
                    else { banExiste = false; }
                }
            }
            else
            {
                banExiste = false;
            }
            return banExiste;
        }


        public string descripcion(string matnr, string werk)
        {
            //string fecha;
            string lsSQLAux;
            string lsDesc = "";
            ClsMARACollection coleccionCajas;
            lsSQLAux = "WHERE matnr ='" + matnr + "' AND (WERKS = '" + werk + "')";
            coleccionCajas = (new ClsMARABAL()).ConsultarMARABAL(lsSQLAux);

            if (coleccionCajas.Count != 0)
            {
                IEnumerator lstCajas = coleccionCajas.GetEnumerator();
                while (lstCajas.MoveNext())
                {
                    ClsMARA tabMara = (ClsMARA)lstCajas.Current;

                    if (matnr == tabMara.Matnr)
                    {
                        lsDesc = tabMara.Maktx.ToString();
                    }
                }
            }

            return lsDesc;
        }

        public DateTime regresaFecha(string matnr, DateTime fechaPro, string werk)
        {
            //string fecha;
            string lsSQLAux;
            DateTime ltiempoProceso = DateTime.Now;

            ClsMARACollection coleccionCajas;
            lsSQLAux = "WHERE matnr ='" + matnr + "' and werks = '" + werk + "'";
            coleccionCajas = (new ClsMARABAL()).ConsultarMARABAL(lsSQLAux);

            if (coleccionCajas.Count != 0)
            {
                IEnumerator lstCajas = coleccionCajas.GetEnumerator();
                while (lstCajas.MoveNext())
                {
                    ClsMARA tabMara = (ClsMARA)lstCajas.Current;
                    int lsWerk;
                    lsWerk = int.Parse(tabMara.Mhdhb.ToString());
                    DateTime hoy = DateTime.Now;
                    ltiempoProceso = hoy.AddDays(lsWerk);

                }

            }

            return ltiempoProceso;
        }

        public CLSMatnrWFechaCollection ObtenerMatFec(string psCriterio) 
        {
            this.CrearConexion();

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            CLSMatnrWFechaCollection materialColeccion = new CLSMatnrWFechaCollection();
            CLSMatnrWFecha matnrFec;
            try
            {
                da.SelectCommand = new SqlCommand(Procedimientos.sp_ConsMatnrFechaZMaster, this.Conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@Criterio", SqlDbType.VarChar).Value = psCriterio;

                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    int renglones = ds.Tables[0].Rows.Count;
                    int columnas = ds.Tables[0].Columns.Count;

                    for (int contador = 0; contador < ds.Tables[0].Rows.Count; contador++)
                    {
                        matnrFec = new CLSMatnrWFecha();
                        //ds.Tables[0].Columns[1].ColumnName
                        try
                        {
                            matnrFec.Cajas = Convert.ToInt32(ds.Tables[0].Rows[contador]["Cajas"].ToString().Trim());
                        }
                        catch 
                        {
                            
                            matnrFec.Cajas = 0;
                        }
                        try
                        {
                            matnrFec.Cantidad = Convert.ToDouble(ds.Tables[0].Rows[contador]["Kilos"].ToString().Trim());
                        }
                        catch
                        {

                            matnrFec.Cantidad = 0.0;
                        }
                        materialColeccion.Add(matnrFec);

                    }
                }

                return materialColeccion;
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ConsultarRegistro + Errores.MensajeOriginal + ex.Message.Trim());
            }
            finally
            {
                this.Conexion.Close();
            }
        }

        public string coleccionDatos(ArrayList lstItems)
        {

            this.CrearConexion();

            string horaCreacion;
            DateTime hora = DateTime.Now;

            try
            {
                for (int i = 0; i < lstItems.Count; i++)
                {

                    this.Conexion.Open();
                    SqlCommand comando = this.Conexion.CreateCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = Procedimientos.sp_InsertaZmaster;

                    char[] arrayNotArroba = { ']' };
                    String[] b = lstItems[i].ToString().Split(arrayNotArroba);
                    DateTime fechaCadu;

                    horaCreacion = hora.Hour.ToString() + ':' + hora.Minute.ToString() + ':' + hora.Second.ToString();
                    fechaCadu = regresaFecha(b[1].ToString().Remove(0, 1), Convert.ToDateTime(b[3].ToString().Remove(0, 1)), b[5].ToString().Remove(0, 1));

                    comando.Parameters.Add("@CreadoPor", SqlDbType.VarChar).Value = "SC";
                    comando.Parameters.Add("@IDTarima", SqlDbType.VarChar).Value = numFolio;
                    comando.Parameters.Add("@WERKS", SqlDbType.VarChar).Value = b[5].ToString().Remove(0, 1);
                    comando.Parameters.Add("@IDCaja", SqlDbType.VarChar).Value = b[0].ToString().Remove(0, 1);
                    comando.Parameters.Add("@MATNR", SqlDbType.VarChar).Value = b[1].ToString().Remove(0, 1);
                    comando.Parameters.Add("@CHARG", SqlDbType.VarChar).Value = b[2].ToString().Remove(0, 1);
                    comando.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = Convert.ToDouble(b[4].ToString().Remove(0, 1));
                    comando.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).Value = DateTime.Now;
                    comando.Parameters.Add("@FechaProduccion", SqlDbType.DateTime).Value = Convert.ToDateTime(b[3].ToString().Remove(0, 1));
                    comando.Parameters.Add("@FechaCaducidad", SqlDbType.DateTime).Value = fechaCadu;
                    comando.Parameters.Add("@HoraCreacion", SqlDbType.DateTime).Value = horaCreacion;
                    comando.Parameters.Add("@Desembalada", SqlDbType.VarChar).Value = "";
                    comando.Parameters.Add("@Borrado", SqlDbType.VarChar).Value = "";
                    comando.Parameters.Add("@AsignadaEntrega", SqlDbType.VarChar).Value = "";
                    comando.ExecuteNonQuery();
                    this.Conexion.Close();
                    //T43]H999]P11123456]L2323]D14/05/2012]Q111]W0R20
                }
            }
            catch (Exception ex)
            {
                //Dar rollback a la transaccion
                //comando.Transaction.Rollback();
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

            return "";
        }
    }
}
