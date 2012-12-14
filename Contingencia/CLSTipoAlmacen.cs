using System;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class CLSTipoAlmacen
    {
        private string werks;
        public string Werks
        {
            get { return werks; }
            set { werks = value; }
        }

        private string codigo;
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private void IniciarObjeto()
        {
            Werks = Variables.Blanco;
            Codigo = Variables.Blanco;
            Descripcion = Variables.Blanco;
        }
    }
}
