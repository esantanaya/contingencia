using System;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    public class ClsZCAT
    {

        private decimal tarima;

        public decimal TARIMA
        {
            get { return tarima; }
            set { tarima = value; }
        }
        
       private string werks;

        public string Werks
        {
            get { return werks; }
            set { werks = value; }
        }
        private string lgort;

        public string Lgort
        {
            get { return lgort; }
            set { lgort = value; }
        }

        private DateTime fechatras;

        public DateTime FECHATRAS
        {
            get { return fechatras; }
            set { fechatras = value; }
        }

        private DateTime horatras;

        public DateTime HORATRAS
        {
            get { return horatras; }
            set { horatras = value; }
        }

        private double contador;

        public double CONTADOR
        {
            get { return contador; }
            set { contador = value; }
        }

        private string ubicacion;

        public string Ubicacion
        {
            get { return ubicacion; }
            set { ubicacion = value; }
        }

        private string tipoAlmacen;

        public string TipoAlmacen
        {
            get { return tipoAlmacen; }
            set { tipoAlmacen = value; }
        }
    }
}

