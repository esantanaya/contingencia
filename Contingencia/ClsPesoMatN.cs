using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contingencia
{
    public class ClsPesoMatN
    {
        private string matnr;

        public string Matnr
        {
            get { return matnr; }
            set { matnr = value; }
        }
        private double peso;

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        private int contador;

        public int Contador
        {
            get { return contador; }
            set { contador = value; }
        }
    }
}
