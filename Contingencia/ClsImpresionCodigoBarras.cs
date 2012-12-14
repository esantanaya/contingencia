using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;
using System.Runtime.Serialization;

namespace Contingencia
{
    [StructLayout(LayoutKind.Sequential)]

    public struct DocumentInformation
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        private string pDocName;
        [MarshalAs(UnmanagedType.LPWStr)]
        private string pOutputFile;
        [MarshalAs(UnmanagedType.LPWStr)]
        private string pDataType;

        public string DocName
        {
            get
            {
                return pDocName;
            }
            set
            {
                pDocName = value;
            }
        }

        public string OutputFile
        {
            get
            {
                return pOutputFile;
            }
            set
            {
                pOutputFile = value;
            }
        }

        public string DataType
        {
            get
            {
                return pDataType;
            }
            set
            {
                pDataType = value;
            }
        }
    }


    //    public class ImprimirDirecto
    internal class NativeMethods
    {
        private NativeMethods() { }

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern long OpenPrinter(string pPrinterName, ref IntPtr phPrinter, int pDefault);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern long StartDocPrinter(IntPtr hPrinter, int level, ref DocumentInformation pDocInfo);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true,
             CallingConvention = CallingConvention.StdCall)]
        public static extern long StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Ansi, ExactSpelling = true,
             CallingConvention = CallingConvention.StdCall)]
        public static extern long WritePrinter(IntPtr hPrinter, string data, int buf, ref int pcWritten);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true,
             CallingConvention = CallingConvention.StdCall)]
        public static extern long EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true,
             CallingConvention = CallingConvention.StdCall)]
        public static extern long EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true,
             CallingConvention = CallingConvention.StdCall)]
        public static extern long ClosePrinter(IntPtr hPrinter);
    }


    public sealed class FuncionesImpresora
    {
        private FuncionesImpresora()
        { }

        public static Boolean ImpresoraConectada(string impresora)
        {
            System.IntPtr lhPrinter = new System.IntPtr();
            Boolean conectada;
            conectada = true;
            //If lhPrinter is 0 then an error has occured
            NativeMethods.OpenPrinter(impresora, ref lhPrinter, 0);
            if (lhPrinter.ToInt32().Equals(0))
            {
                conectada = false;
            }
            else
            {
                NativeMethods.ClosePrinter(lhPrinter);
            }
            return conectada;
        }

        public static void ImprimirLista(ArrayList lista, string impresora)
        {
            System.IntPtr lhPrinter = new System.IntPtr();

            DocumentInformation di = new DocumentInformation();
            int pcWritten = 0;
            string linea;
            string lineFeed = "\r\n";

            di.DocName = "CB";
            di.DataType = "RAW";

            NativeMethods.OpenPrinter(impresora, ref lhPrinter, 0);
            NativeMethods.StartDocPrinter(lhPrinter, 1, ref di);
            NativeMethods.StartPagePrinter(lhPrinter);
            try
            {
                System.Collections.IEnumerator myEnumerator;
                myEnumerator = lista.GetEnumerator();
                while (myEnumerator.MoveNext())
                {
                    StringBuilder sbLinea = new StringBuilder();
                    sbLinea.Append(myEnumerator.Current.ToString());
                    sbLinea.Append(lineFeed);
                    linea = sbLinea.ToString();
                    NativeMethods.WritePrinter(lhPrinter, linea, linea.Length, ref pcWritten);
                }
            }
            catch
            {
                throw new Exception(Errores.Desconocido);
            }
            NativeMethods.EndPagePrinter(lhPrinter);
            NativeMethods.EndDocPrinter(lhPrinter);
            NativeMethods.ClosePrinter(lhPrinter);
        }
    }
}