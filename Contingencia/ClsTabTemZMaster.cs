using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Contingencia
{
    class ClsTabTemZMaster
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private int cajas;
        public int Cajas
        {
            get { return cajas; }
            set { cajas = value; }
        }

        private string werks;

        public string Werks
        {
            get { return werks; }
            set { werks = value; }
        }

        private string matnr;

        public string Matnr
        {
            get { return matnr; }
            set { matnr = value; }
        }

        private double cantidad;

        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        protected void IniciarObjeto()
        {
            Cajas = Convert.ToInt32(Variables.Cero, currentCulture);
            werks = Variables.Blanco;
            matnr = Variables.Blanco;
            cantidad = Convert.ToDouble(Variables.Cero, currentCulture);
        
        }
    }
}
