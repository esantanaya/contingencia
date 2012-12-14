using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Diagnostics;


namespace Contingencia
{
    public class ClsFunciones
    {
        private static IFormatProvider currentCulture = new System.Globalization.CultureInfo(Variables.Cultura, true);

        public static ArrayList valoresEntorno;

        public static string ObtenerValorEntorno(string psValor)
        {
            string clave = Variables.Nulo;
            string valor = Variables.Nulo;
            string linea = Variables.Nulo;
            string mensajeError = Variables.Nulo;
            try
            {
                System.Collections.IEnumerator myEnumerator = valoresEntorno.GetEnumerator();
                while (myEnumerator.MoveNext())
                {
                    linea = myEnumerator.Current.ToString();
                    if (linea != "Error")
                    {
                        clave = linea.Substring(0, 3);
                        if (clave == psValor)
                        {
                            valor = linea.Substring(6);
                            break;
                        }
                    }


                }
                if (valor == Variables.Nulo)
                {
                    mensajeError = Errores.NoVariableEntorno;
                    throw new Exception(mensajeError);
                }
                return valor;

            }
            catch (Exception ex)
            {
                mensajeError = Errores.ArchivoConfiguracion + Variables.Espacio + Errores.MensajeOriginal + ex.Message;
                throw new Exception(mensajeError);
            }

        }

        public static void ObtenerValoresConfiguracion()
        {
            String message = Variables.Nulo;
            string configurationFile = Variables.ArchivoConfiguracion;
            try
            {
                valoresEntorno = new ArrayList(ClsFileManager.ReadFile(configurationFile));
                if (valoresEntorno.Count==0)
                {
                    message = Errores.ArchivoConfiguracion + Variables.Espacio + Errores.ArchivoVacio;
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                message = Errores.ArchivoConfiguracion + Variables.Espacio + Errores.MensajeOriginal + ex.Message.ToString();
                throw new Exception(message);
            }
        }

        public static string ObtenerClaveCadena(string psCadena, string psCarIni, string psCarFin)
        {
            string clave = Variables.Nulo;
            int posIni = 0;
            int posFin = 0;
            if (psCadena.Contains(psCarIni) && psCadena.Contains(psCarFin))
            {
                posIni = psCadena.IndexOf(psCarIni) + psCarIni.Length;
                posFin = psCadena.IndexOf(psCarFin) ;
                if ((posFin - posIni) > 0)
                {
                    clave = psCadena.Substring(posIni,(posFin - posIni));
                }
                else
                {
                    throw new Exception(Errores.ClaveInvalida);
                }
            }
            else
            {
                throw new Exception(Errores.ClaveInvalida);
            }
            return clave;
        }

        public static string ObtenerDescripcionCadena(string psCadena, string psCarIni, string psCarFin)
        {
            string clave = Variables.Nulo;
            int posIni = 0;
            int posFin = 0;
            if (psCadena.Contains(psCarIni) && psCadena.Contains(psCarFin))
            {
                posIni = psCadena.IndexOf(psCarIni) + psCarIni.Length;
                posFin = psCadena.IndexOf(psCarFin);
                if ((posFin - posIni) > 0)
                {
                    clave = psCadena.Substring(posIni, (posFin - posIni));
                }
                else
                {
                    throw new Exception(Errores.ClaveInvalida);
                }
            }
            else
            {
                throw new Exception(Errores.ClaveInvalida);
            }
            clave = psCarIni + clave + psCarFin;
            clave = psCadena.Replace(clave, "");
            return clave;
        }
        
        public static string ObtenerDescripcionCadena(string psCadena, string psCarIni)
        {
            string descripcion = Variables.Nulo;
            int posIni = 0;
            int longitud = 0;
            if (psCadena.Contains(psCarIni))
            {
                posIni = psCadena.IndexOf(psCarIni) + 2;
                longitud = psCadena.Length - posIni;
                if ((longitud) > 0)
                {
                    descripcion = psCadena.Substring(posIni, longitud);
                }
                else
                {
                    throw new Exception(Errores.DescripcionInvalida);
                }
            }
            else
            {
                throw new Exception(Errores.DescripcionInvalida);
            }
            return descripcion;
        }

        public static string ValorCadenaPosicion(string cadena, string separador, int posicion)
        {
            StringBuilder valor = new StringBuilder();
            int contador = 0;
            int posicionActual = 0;
            if (cadena.Length > 0)
            {
                while (true)
                {
                    if (contador == cadena.Length)
                    {
                        // No se encontró el valor requrido
                        valor.Remove(0, valor.Length);
                        break;
                    }


                    if (cadena.Substring(contador, 1) == separador)
                    {
                        posicionActual++;
                        if (posicionActual == posicion + 1) //Es el resultado deseado
                        {
                            break;
                        }
                        else
                        {
                            valor.Remove(0, valor.Length);
                        }
                    }
                    else
                    {
                        valor.Append(cadena.Substring(contador, 1));
                    }
                    contador++;
                }
            }


            return valor.ToString();
        }

        public static System.Drawing.Color ObtenerColor(string psTipoFondo)
        {
            System.Drawing.Color color;
            color = System.Drawing.Color.LightSteelBlue;
            switch(psTipoFondo)
            {
                case "Normal": // "FondoBase":
                    color = System.Drawing.Color.LightSteelBlue;
                    break;
                case "Error": //  "FondoError":
                    color = System.Drawing.Color.Red;
                    break;
            }
            return color;
        }

        public static bool ValidarAplicacionCargada(string psProceso)
        {
            bool cargada = false;
            Process[] processes = null;
            try
            {
                processes = Process.GetProcesses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Application.Exit();
                return cargada;
            }
//            int threadscount = 0;
            int instancias = 0;
            string proceso;
            foreach (Process p in processes)
            {
                
                
                try
                {
                    //string[] prcdetails = new string[] { p.ProcessName, p.Id.ToString(), p.StartTime.ToShortTimeString(), p.TotalProcessorTime.Duration().Hours.ToString() + ":" + p.TotalProcessorTime.Duration().Minutes.ToString() + ":" + p.TotalProcessorTime.Duration().Seconds.ToString(), (p.WorkingSet / 1024).ToString() + "k", (p.PeakWorkingSet / 1024).ToString() + "k", p.HandleCount.ToString(), p.Threads.Count.ToString() };
                    proceso = p.ProcessName.ToString().ToUpper();
                    if (proceso.StartsWith(psProceso.ToUpper()))
                    {
                        instancias++;
                        cargada = true;
                    }
                }
                catch 
                {
                    cargada = false;
                    return cargada;
                }

            }
            if (psProceso == Variables.NombreAssambly)
            {
                if (cargada)
                {

                    if (instancias > 1)
                    {
                        cargada = true;
                    }
                    else
                    {
                        cargada = false;
                    }
                }
            }
            else
            {
                if (cargada)
                {

                    if (instancias >= 1)
                    {
                        cargada = true;
                    }
                    else
                    {
                        cargada = false;
                    }
                }
            }
            return cargada;

        }

        public static void BuscarValorGrid(System.Windows.Forms.DataGridView DGVLista, string textoBuscar)
        {
            int contador = 0;
            string claveActual = Variables.N;
            int columna = 0;
            columna = DGVLista.CurrentCell.ColumnIndex;
            for (contador = 0; contador <= DGVLista.RowCount - 1; contador++)
            {
                claveActual = DGVLista.Rows[contador].Cells[columna].Value.ToString().ToUpper();
                if (claveActual.StartsWith(textoBuscar.Trim().ToUpper()))
                {
                    DGVLista.CurrentCell = DGVLista[columna, contador];
                    DGVLista.FirstDisplayedScrollingRowIndex = contador;
                    break;
                }
            }
        }

        public static bool ValidarEnteroCorto(string valSring)
        {
            try
            {
                Int32 valor = Convert.ToInt32(valSring);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool ValidarEnteroLargo(string valSring)
        {
            try
            {
                double valor = Convert.ToDouble(valSring);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool ValidarDecimal(string valSring)
        {
            try
            {
                decimal valor = Convert.ToDecimal(valSring);
                return true;
            }
            catch 
            {
                return false;
            }

        }
    }

    public class AddValue
    {
        private string m_Display;
        private string m_Value;
        public AddValue(string Display, string Value)
        {
            m_Display = Display;
            m_Value = Value;
        }
        public string Display
        {
            get { return m_Display; }
        }
        public string Value
        {
            get { return m_Value; }
        }
    }

}
