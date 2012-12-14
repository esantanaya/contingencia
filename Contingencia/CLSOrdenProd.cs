using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Contingencia
{
    public class CLSOrdenProd
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private string werks;
        public string Werks
        {
            get { return werks; }
            set { werks = value; }
        }

        private string aufnr;
        public string Aufnr
        {
            get { return aufnr; }
            set { aufnr = value; }
        }

        private string matnr;
        public string Matnr
        {
            get { return matnr; }
            set { matnr = value; }
        }

        private string matnrComp;
        public string MatnrComp
        {
            get { return matnrComp; }
            set { matnrComp = value; }
        }

        private string charg;
        public string Charg
        {
            get { return charg; }
            set { charg = value; }
        }

        private string lgort;
        public string Lgort
        {
            get { return lgort; }
            set { lgort = value; }
        }

        public void IniciarObjeto()
        {
            Werks = Variables.Blanco;
            Aufnr = Variables.Blanco;
            Matnr = Variables.Blanco;
            MatnrComp = Variables.Blanco;
            Charg = Variables.Blanco;
            Lgort = Variables.Blanco;
        }
    }
}
