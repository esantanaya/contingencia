using System;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class CLSMatnrWFecha
    {
        private double cantidad;
        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private int cajas;
        public int Cajas
        {
            get { return cajas; }
            set { cajas = value; }
        }

        public void IniciarObjeto() 
        {
            Cantidad = 0.0;
            Cajas = 0;
        }
    }
}
