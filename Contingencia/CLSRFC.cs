using System;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class CLSRFC
    {
        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public void ObtenerEstado()
        {
            Estado = new CLSCatCentroBAL().ObtenerEstadoBAL("");
        }
    }
}
