using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class CLSTraspCalidadBAL : CLSTraspCalidadDAL
    {
        public CLSTraspCalidadCollection MostrarTraspCalidadBAL(string psCriterio)
        {

            CLSTraspCalidadCollection coleccion = new CLSTraspCalidadCollection();

            try
            {
                coleccion = base.ConsultarTraspCalidadCollection(psCriterio);
                return coleccion;
            }
            catch
            {
                throw;
            }
        }
    }
}
