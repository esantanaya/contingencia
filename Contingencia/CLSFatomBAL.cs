using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class CLSFatomBAL : CLSFatomDAL
    {
        public CLSFatomCollection MostrarFatomBAL(string psCriterio)
        {

            CLSFatomCollection coleccion = new CLSFatomCollection();

            try
            {
                coleccion = base.ConsultarFatomCollection(psCriterio);
                return coleccion;
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarEntregaBAL(CLSFatom fatom, string criterio)
        {
            try
            {
                base.ActualizarEntregaDAL(fatom, criterio);
            }
            catch { throw; }
        }

        public void ActualizarPesosBAL(CLSFatom fatom, string criterio)
        {
            try
            {
                base.ActualizarPesosDAL(fatom, criterio);
            }
            catch { throw; }
        }

        public void ActualizarOrdenesVirtBAL(CLSFatom fatom, string criterio)
        {
            try
            {
                base.ActualizarOrdenesVirtDAL(fatom, criterio);
            }
            catch { throw; }
        }

        public void ActualizarOrdenesZPPG02BAL(CLSFatom fatom, string criterio)
        {
            try
            {
                base.ActualizarOrdenesZPPG02DAL(fatom, criterio);
            }
            catch { throw; }
        }

        public void ActualizarOrdenesBAL(CLSFatom fatom, string criterio)
        {
            try
            {
                base.ActualizarOrdenesDAL(fatom, criterio);
            }
            catch { throw; }
        }

        public void ActualizarEstadoBAL(CLSFatom fatom, string criterio) {
            try
            {
                base.ActualizarEstadoDAL(fatom, criterio);
            }
            catch { throw; }
        }

        public void AcualizarDescripcionBAL(CLSFatom fatom, string criterio) {
            try
            {
                base.ActalizarDescripcionDAL(fatom, criterio);
            }
            catch { throw; }
        }

        public void ActualizarProductoVirt2BAL(CLSFatom fatom, string criterio)
        {
            try
            {
                base.AcualizarProductoVirt2DAL(fatom, criterio);
            }
            catch { throw; }
        }

        public void ActualizarMaterialesBAL(CLSFatom fatom, string criterio) {
            try
            {
                base.ActualizarMaterialesDAL(fatom, criterio);
            }
            catch { throw; }
        }

        public void ActualizarDestinoBAL(CLSFatom fatom, string criterio) {
            try
            {
                base.ActualizarDestinoDAL(fatom, criterio);
            }
            catch { throw; }
        }

        public void AgregarFatom0R20BAL(CLSFatom fatom)
        {
            try
            {
                base.AgregarFatom0R20DAL(fatom);
            }
            catch { throw; }
        }

        public void AgregarFatomBAL(CLSFatom fatom) {

            try
            {
                base.AgregarFatomDAL(fatom);
            }
            catch { throw; }
        }

    }
}
