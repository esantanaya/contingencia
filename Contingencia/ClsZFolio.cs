using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Contingencia
{
    public class ClsZFolio
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private string werks;

        public string Werks
        {
            get { return werks; }
            set { werks = value; }
        }
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private string pref;

        public string Pref
        {
            get { return pref; }
            set { pref = value; }
        }
        private string nbr;
        public string Nbr
        {
            get { return nbr; }
            set { nbr = value; }
        }

        public void IniciarObjeto()
        {
            werks = Variables.Blanco;
            tipo = Variables.Blanco;
            pref = Variables.Blanco;
            nbr = Variables.Blanco;
        }

    }
}
