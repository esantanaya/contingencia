using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class CLSLoteBAL : CLSLoteDAL
    {
        public CLSLoteCollection MostrarLoteBAL(string psCriterio)
        {

            CLSLoteCollection coleccion = new CLSLoteCollection();

            try
            {
                coleccion = base.ConsultarLoteCollection(psCriterio);
                return coleccion;
            }
            catch
            {
                throw;
            }
        }
    }
}
