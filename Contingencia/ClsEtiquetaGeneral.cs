using System;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Collections;
using System.IO;

namespace Contingencia
{
    class ClsEtiquetaGeneral
    {
        string[,] aValores;
        public string[,] AValores
        {
            get
            {
                return aValores;
            }
            set
            {
                aValores = value;
            }
        }

        private string archivoBase;
        public string ArchivoBase
        {
            get
            {
                return archivoBase;
            }
            set
            {
                archivoBase = value;
            }
        }

        private string impresora;
        public string Impresora
        {
            get
            {
                return impresora;
            }
            set
            {
                impresora = value;
            }
        }


        static CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        public ClsEtiquetaGeneral()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public void ProcesarEtiqueta()
        {
            ArrayList lista; //= new ArrayList();
            try
            {
                lista = new ArrayList(ClsFileManager.ReadFile(archivoBase));
                // Sustituye cada línea con el valor correspondiente
                ArrayList listaImprimible = new ArrayList();
                listaImprimible = ActualizarLineas(lista);
                //Imprime la etiqueta
                FuncionesImpresora.ImprimirLista(listaImprimible, impresora);
            }
            catch (IOException IO)
            {
                throw new Exception(IO.Message, IO);
            }

            catch (Exception)
            {
                throw;
            }
        }

        public ArrayList ActualizarLineas(ArrayList lista)
        {
            ArrayList arraySalida = new ArrayList();
            string linea;
            string lineaActualizada;
            System.Collections.IEnumerator myEnumerator;
            myEnumerator = lista.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                linea = myEnumerator.Current.ToString();
                //modificar línea
                lineaActualizada = CrearLineaNueva(linea);
                arraySalida.Add(lineaActualizada);
            }
            return arraySalida;
        }

        private string CrearLineaNueva(string psLinea)
        {
            string lineaNueva = psLinea;
            int posicion;
            int renglones = 0;
            int contValores = 0;
            string constanteReferencia = Variables.Nulo;
            string variableReferencia = Variables.Nulo;
            if (psLinea.Length == 0)
            {
                return lineaNueva;
            }

            if (aValores.Length > 0)
            {
                renglones = aValores.Length / (aValores.GetUpperBound(1) + 1);
            }
            else
            {
                renglones = 0;
            }

            for (contValores = 0; contValores <= renglones - 1; contValores++)
            {
                if (aValores[contValores, 0] != null)
                {
                    try
                    {
                        constanteReferencia = aValores[contValores, 0].ToString().Trim();
                    }
                    catch
                    {
                        constanteReferencia = " ";  
                    }

                    try
                    {
                        variableReferencia = aValores[contValores, 1].ToString().Trim();
                    }
                    catch
                    {
                        constanteReferencia = " ";
                    }
                        
                        //comenzar en la posicion 0 y validar cobtra > o = a 0
                    posicion = psLinea.IndexOf(constanteReferencia, 0);
                    if (posicion >= 0)
                    {
                        lineaNueva = psLinea.Replace(constanteReferencia, variableReferencia);
                        break;
                    }
                }
                else
                {
                    lineaNueva = "";
                    break;
                }
            }
            return lineaNueva;
        }

    }
}
