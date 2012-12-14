using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class CLSCalidadBAL : CLSCalidadDAL
    {
        public CLSCalidadCollection MostrarCalidadBAL(string psCriterio)
        {

            CLSCalidadCollection coleccion = new CLSCalidadCollection();

            try
            {
                coleccion = base.ConsultarCalidadCollection(psCriterio);
                return coleccion;
            }
            catch
            {
                throw;
            }
        }



    }
}
