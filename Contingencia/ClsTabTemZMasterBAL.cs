using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Contingencia
{
    class ClsTabTemZMasterBAL : ClsTabTemZMasterDAL
    {
        public void AgregarTabTemZMasterBAL(ClsTabTemZMaster tabTemZMaster)
        {
            try
            {
                base.AgregarTabTemZMasterDAL(tabTemZMaster);
            }
            catch
            {
                throw;
            }
        }

        public ClsTabTemZMasterCollection ConsultaZMasterBAL(string psCriterio)
        {
            ClsTabTemZMasterCollection col = new ClsTabTemZMasterCollection();
            try
            {
                col = base.ConsultaZMasterDAL(psCriterio);
                return col;
            }
            catch
            {
                throw;
            }
        }

        public ClsTabTemZMasterCollection ConsultarMaterialesZMasterBAL(string psCriterio)
        {
            ClsTabTemZMasterCollection col = new ClsTabTemZMasterCollection();
            try
            {
                col = base.ConsultarMaterialesZMasterDAL(psCriterio);
                return col;
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarTabTemZMasterBAL(ClsTabTemZMaster tabTemZMaster)
        {
            try
            {
                base.ActualizarTabTemZMasterDAL(tabTemZMaster);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarTabTemZMasterBAL(ClsTabTemZMaster TabTemZMaster)
        {
            try
            {
                base.EliminarTabTemZMasterDAL(TabTemZMaster);
            }
            catch
            {
                throw;
            }
        }



        public ClsTabTemZMasterCollection ConsultarTabTemZMasterBAL(string psCriterio)
        {
            ClsTabTemZMasterCollection tabTemZMasterCollection = new ClsTabTemZMasterCollection();
            try
            {
                tabTemZMasterCollection = base.ConsultaZMasterDAL(psCriterio);

                return tabTemZMasterCollection;
            }
            catch
            {
                throw;
            }
        }

        public ArrayList CargarTabTemZMaster()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsTabTemZMasterCollection tabTemZMasterCollection;
            ClsTabTemZMasterBAL tabTemZMasterBAL = new ClsTabTemZMasterBAL();
            ArrayList arrTabTemzMaster = new ArrayList();
            try
            {
                tabTemZMasterCollection = tabTemZMasterBAL.ConsultarTabTemZMasterBAL(criterio);
                IEnumerator listaRegistros = tabTemZMasterCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsTabTemZMaster currTabTemZMaster = (ClsTabTemZMaster)listaRegistros.Current;

                    arrTabTemzMaster.Add(new AddValue(currTabTemZMaster.Werks, currTabTemZMaster.Werks));
                }
                return arrTabTemzMaster;
            }
            catch
            {
                throw;
            }
        }

    }
}
