using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contingencia
{
    public class ClsZCTC
    {
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
        private string caja;

        public string Caja
        {
            get { return caja; }
            set { caja = value; }
        }
        private DateTime fechaTraslado;

        public DateTime FechaTraslado
        {
            get { return fechaTraslado; }
            set { fechaTraslado = value; }
        }

        private DateTime horaTraslado;

        public DateTime HoraTraslado
        {
            get { return horaTraslado; }
            set { horaTraslado = value; }
        }


        private double cantidadMovimientos;

        public double CantidadMovimientos
        {
            get { return cantidadMovimientos; }
            set { cantidadMovimientos = value; }
        }

        
    }
}
