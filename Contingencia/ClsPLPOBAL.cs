using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Contingencia
{
    class ClsPLPOBAL : ClsPLPODAL
    {
        public void AgregarPLPOBAL(ClsPLPO pLPO)
        {
            try
            {
                base.AgregarPLPODAL(pLPO);
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarPLPOBAL(ClsPLPO pLPO)
        {
            try
            {
                base.ActualizarPLPODAL(pLPO);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarPLPOBAL(ClsPLPO pLPO)
        {
            try
            {
                base.EliminarPLPODAL(pLPO);
            }
            catch
            {
                throw;
            }
        }

        public ClsPLPOCollection ConsultarPLPOBAL(string psCriterio)
        {
            ClsPLPOCollection pLPOCollection = new ClsPLPOCollection();
            try
            {
                pLPOCollection = base.ConsultarPLPODAL(psCriterio);
                return pLPOCollection;
            }
            catch
            {
                throw;
            }
        }

        public ArrayList CargarPLPO()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsPLPOCollection pLPOCollection;
            ClsPLPOBAL pLPOBAL = new ClsPLPOBAL();
            ArrayList arrpLPO = new ArrayList();
            try
            {
                pLPOCollection = pLPOBAL.ConsultarPLPOBAL(criterio);
                IEnumerator listaRegistros = pLPOCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsPLPO currPLPO = (ClsPLPO)listaRegistros.Current;
                    arrpLPO.Add(new AddValue(currPLPO.Plnty+"", currPLPO.Plnty+""));
                }
                return arrpLPO;
            }
            catch
            {
                throw;
            }
        }

        public ClsPLPOCollection pLPOCollection { get; set; }
    }
}
