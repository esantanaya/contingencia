using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Contingencia
{
    class ClsCatZMasterBAL : ClsCatZMasterDAL
    {
        public void AgregarZMasterBAL(ClsCatZMaster zMaster)
        {
            try
            {
                base.AgregarZMasterDAL(zMaster);
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarZMasterBAL(ClsCatZMaster zMaster)
        {
            try
            {
                base.ActualizarZMasterDAL(zMaster);
            }
            catch
            {
                throw;
            }
        }



        public void ActualizarZMasterDestinosBAL(ClsCatZMaster zMaster)
        {
            try
            {
                base.ActualizarZMasterDestinosDAL(zMaster);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarZMasterBAL(ClsCatZMaster zMaster)
        {
            try
            {
                base.EliminarZMasterDAL(zMaster);
            }
            catch
            {
                throw;
            }
        }



        public ClsCatZMasterCollection ConsultarZMasterBAL(string psCriterio)
        {
            ClsCatZMasterCollection zMasterCollection = new ClsCatZMasterCollection();
            try
            {
                zMasterCollection = base.ConsultarZMasterDAL(psCriterio);

                return zMasterCollection;
            }
            catch
            {
                throw;
            }
        }


        public ArrayList CargarZMaster()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsCatZMasterCollection zMasterCollection;
            ClsCatZMasterBAL zMasterBAL = new ClsCatZMasterBAL();
            ArrayList arrzMaster = new ArrayList();
            try
            {
                zMasterCollection = zMasterBAL.ConsultarZMasterBAL(criterio);
                IEnumerator listaRegistros = zMasterCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsCatZMaster currZMaster = (ClsCatZMaster)listaRegistros.Current;
                    // arrAlmacenes.Add(new AddValue(currAlmacen.Lgort, currAlmacen.Lgort));

                    arrzMaster.Add(new AddValue(currZMaster.CreadoPor, currZMaster.CreadoPor));
                }
                return arrzMaster;
            }
            catch
            {
                throw;
            }
        }


        public ClsCatZMasterCollection ConsultarNumCajasTarimaBAL(string psCriterio)
        {
            ClsCatZMasterCollection zMasterCollection = new ClsCatZMasterCollection();
            try
            {
                zMasterCollection = base.ConsultarZMasterDAL(psCriterio);

                return zMasterCollection;
            }
            catch
            {
                throw;
            }
        }


    }
}
