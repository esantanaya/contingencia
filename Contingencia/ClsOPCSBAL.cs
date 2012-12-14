using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Contingencia
{
    class ClsOPCSBAL : ClsOPCSDAL
    {
        public void AgregarMARABAL(ClsOPCS oPCS)
        {
            try
            {
                base.AgregarOPCSDAL(oPCS);
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarOPCSBAL(ClsOPCS oPCS)
        {
            try
            {
                base.ActualizarOPCSDAL(oPCS);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarOPCSBAL(ClsOPCS oPCS)
        {
            try
            {
                base.EliminarOPCSDAL(oPCS);
            }
            catch
            {
                throw;
            }
        }

        public ClsOPCSCollection ConsultarOPCSBAL(string psCriterio)
        {
            ClsOPCSCollection oPCSCollection = new ClsOPCSCollection();
            try
            {
                oPCSCollection = base.ConsultarOPCSDAL(psCriterio);
                return oPCSCollection;
            }
            catch
            {
                throw;
            }
        }

        public ArrayList CargarOPCS()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsOPCSCollection oPCSCollection;
            ClsOPCSBAL oPCSBAL = new ClsOPCSBAL();
            ArrayList arrpOPCS = new ArrayList();
            try
            {
                oPCSCollection = oPCSBAL.ConsultarOPCSBAL(criterio);
                IEnumerator listaRegistros = oPCSCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsOPCS currMara = (ClsOPCS)listaRegistros.Current;
                    arrpOPCS.Add(new AddValue(currMara.Werks, currMara.Werks));
                }
                return arrpOPCS;
            }
            catch
            {
                throw;
            }
        }
    }
}
