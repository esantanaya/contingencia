using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Contingencia
{
    public class CLSCatDestino
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private string werks;
        public string Werks {
            get { return werks; }
            set { werks = value; }
        }

        private string codDestino;
        public string CodDestino
        {
            get { return codDestino; }
            set { codDestino = value; }
        }

        private string descDestino;
        public string DescDestino
        {
            get { return descDestino; }
            set { descDestino = value; }
        }

        private string matnrComp;
        public string MatnrComp
        {
            get { return matnrComp; }
            set { matnrComp = value; }
        }

        private string matnrProd;
        public string MatnrProd {
            get { return matnrProd; }
            set { matnrProd = value; }
        }

        private string matnrMaq;
        public string MatnrMaq
        {
            get { return matnrMaq; }
            set { matnrMaq = value; }
        }

        private string pesarCab;
        public string PesarCab {
            get { return pesarCab; }
            set { pesarCab = value; }
        }

        public void IniciarObjeto()
        {
            Werks = Variables.Blanco;
            CodDestino = Variables.Blanco;
            DescDestino = Variables.Blanco;
            MatnrComp = Variables.Blanco;
            MatnrProd = Variables.Blanco;
            PesarCab = Variables.Blanco;
        }
    }
}
