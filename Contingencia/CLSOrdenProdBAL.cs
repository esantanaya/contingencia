using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class CLSOrdenProdBAL : CLSOrdenProdDAL
    {
        public CLSOrdenProdCollection MostrarOrdenProdBAL(string psCriterio)
        {

            CLSOrdenProdCollection coleccion = new CLSOrdenProdCollection();

            try
            {
                coleccion = base.ConsultarOrdenProdCollection(psCriterio);
                return coleccion;
            }
            catch
            {
                throw;
            }
        }
    }
}
