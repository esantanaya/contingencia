using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class CLSCatCentroBAL : CLSCatCentroDAL
    {
        public string ObtenerEstadoBAL(string psCriterio)
        {

            string estado = "";

            try
            {
                estado = base.ConsultarEstado(psCriterio);
                return estado;
            }
            catch
            {
                throw;
            }
        }

        public CLSCatCentroCollection MostrarCatCentroBAL(string psCriterio)
        {

            CLSCatCentroCollection coleccion = new CLSCatCentroCollection();

            try
            {
                coleccion = base.ConsultarCatCentroCollection(psCriterio);
                return coleccion;
            }
            catch
            {
                throw;
            }
        }
    }
}
