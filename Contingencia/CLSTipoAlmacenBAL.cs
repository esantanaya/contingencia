using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace Contingencia
{
    class CLSTipoAlmacenBAL : CLSTipoAlmacenDAL
    {
        public CLSTipoAlmacenCollection ConsultarTipoAlmacenBAL(string psCriterio)
        {
            CLSTipoAlmacenCollection tipoAlmacenCollection = new CLSTipoAlmacenCollection();
            try
            {
                tipoAlmacenCollection = base.ConsultarTipoAlmacenCollection(psCriterio);
                return tipoAlmacenCollection;
            }
            catch
            {
                throw;
            }
        }
    }
}
