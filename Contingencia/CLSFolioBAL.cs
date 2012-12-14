using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class CLSFolioBAL : CLSFolioDAL
    {
        public CLSFolioCollection MostrarFolioBAL(string psCriterio)
        {

            CLSFolioCollection coleccion = new CLSFolioCollection();

            try
            {
                coleccion = base.ConsultarFolioCollection(psCriterio);
                return coleccion;
            }
            catch
            {
                throw;
            }
        }



    }
}
