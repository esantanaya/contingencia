using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class CLSCatDestinoBAL : CLSCatDestinoDAL
    {
        public CLSCatDestinoCollection MostrarCatDestinoBAL(string psCriterio)
        {

            CLSCatDestinoCollection coleccion = new CLSCatDestinoCollection();

            try
            {
                coleccion = base.ConsultarCatDestinoCollection(psCriterio);
                return coleccion;
            }
            catch
            {
                throw;
            }
        }
    }
}
