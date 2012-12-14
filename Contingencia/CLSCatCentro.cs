using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Contingencia
{
    public class CLSCatCentro
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private string codCentro;
        public string CodCentro {
            get { return codCentro; }
            set { codCentro = value; }
        }

        private string descCentro;
        public string DescCentro {
            get { return descCentro; }
            set { descCentro = value; }
        }

        private string tipoCentro;

        public string TipoCentro
        {
            get { return tipoCentro; }
            set { tipoCentro = value; }
        }

        public void IniciarObjeto() {
            CodCentro = Variables.Blanco;
            DescCentro = Variables.Blanco;
            tipoCentro = Variables.Blanco;
        }
    }
}
