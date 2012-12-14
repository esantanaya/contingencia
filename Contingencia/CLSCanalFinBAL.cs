using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class CLSCanalFinBAL : CLSCanalFinDAL
    {
        public CLSCanalFinCollection MostrarCanalBAL(string psCriterio)
        {

            CLSCanalFinCollection coleccion = new CLSCanalFinCollection();

            try
            {
                coleccion = base.ConsultarCanalCollection(psCriterio);
                return coleccion;
            }
            catch
            {
                throw;
            }
        }
    }
}
