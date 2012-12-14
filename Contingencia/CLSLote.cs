using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Contingencia
{
    public class CLSLote
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private string almacen;
        public string Almacen
        {
            get { return almacen; }
            set { almacen = value; }
        }

        private string lote;
        public string Lote
        {
            get { return lote; }
            set { lote = value; }
        }

        private string remision;
        public string Remision
        {
            get { return remision; }
            set { remision = value; }
        }

        private string tatuaje;
        public string Tatuaje
        {
            get { return tatuaje; }
            set { tatuaje = value; }
        }

        private string pesoProm;
        public string PesoProm {
            get { return pesoProm; }
            set { pesoProm = value; }
        }

        private string fecha;
        public string Fecha {
            get { return fecha; }
            set { fecha = value; }
        }

        private string centro;
        public string Centro
        {
            get { return centro; }
            set { centro = value; }
        }

        private double clabs;
        public double Clabs
        {
            get { return clabs; }
            set { clabs = value; }
        }

        private double cwmClabs;
        public double CwmClabs
        {
            get { return cwmClabs; }
            set { cwmClabs = value; }
        }

        public void IniciarObjeto()
        {
            Lote = Variables.Blanco;
            Remision = Variables.Blanco;
            Tatuaje = Variables.Blanco;
            PesoProm = Variables.Blanco;
            Fecha = Variables.Blanco;
            Clabs = 0.0;
            CwmClabs = 0.0;
        }
    }
}
