using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Contingencia
{
    class ClsCatUbicaciones
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

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

        public void IniciarObjeto()
        {
            werks = Variables.Blanco;
            lgort = Variables.Blanco;
            ubicacion = Variables.Blanco;
            tipoAlmacen = Variables.Blanco;
        }
    }
}
