using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Contingencia
{
    public class CLSFolio
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private string fecha;
        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string folio;
        public string Folio
        {
            get { return folio; }
            set { folio = value; }
        }

        public void IniciarObjeto()
        {
            Fecha = Variables.Blanco;
            Folio = Variables.Blanco;
        }
    }
}
