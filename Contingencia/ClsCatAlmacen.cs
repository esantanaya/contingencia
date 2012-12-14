using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


namespace Contingencia
{
    class ClsCatAlmacen
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

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        
        private string werks_desc;

        public string Werks_desc
        {
            get { return werks_desc; }
            set { werks_desc = value; }
        }

       

        public void IniciarObjeto() {

            werks = Variables.Blanco;
            lgort = Variables.Blanco;
            descripcion = Variables.Blanco;
            werks_desc = Variables.Blanco;
           
        }
    }
}
