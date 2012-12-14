using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class CLSLipsBAL : CLSLipsDAL
    {
        public CLSLipsCollection ConsultarLipsCollectionBAL(string psCriterio)
        {
            CLSLipsCollection lips = new CLSLipsCollection();

            try
            {
                lips = base.ConsultarLipsCollectionDAL(psCriterio);
                return lips;
            }
            catch
            {
                throw;
            }
        }


        public void ActualizarLIPSBAL(CLSLips lipss)
        {
            try
            {
                base.ActualizarLIPSDAL(lipss);
            }
            catch
            {
                throw;
            }
        }


    }
}
