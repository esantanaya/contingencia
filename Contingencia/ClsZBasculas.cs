using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contingencia
{
    public class ClsZBasculas
    {
        private string modelo;

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        private string setting;

        public string Setting
        {
            get { return setting; }
            set { setting = value; }
        }
        private char carmov;

        public char Carmov
        {
            get { return carmov; }
            set { carmov = value; }
        }
    }
}
