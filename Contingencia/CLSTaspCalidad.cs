using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Contingencia
{
    public class CLSTraspCalidad
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private string centro;
        public string Centro
        {
            get { return centro; }
            set { centro = value; }
        }

        private string codDestino;
        public string CodDestino
        {
            get { return codDestino; }
            set { codDestino = value; }
        }

        private string calidad;
        public string Calidad
        {
            get { return calidad; }
            set { calidad = value; }
        }

        private string matnrOrden;
        public string MatnrOrden
        {
            get { return matnrOrden; }
            set { matnrOrden = value; }
        }

        private string matnrConv;
        public string MatnrConv
        {
            get { return matnrConv; }
            set { matnrConv = value; }
        }

        public void IniciarObjeto()
        {
            Centro = Variables.Blanco;
            CodDestino = Variables.Blanco;
            Calidad = Variables.Blanco;
            MatnrOrden = Variables.Blanco;
            MatnrConv = Variables.Blanco;
        }
    }
}
