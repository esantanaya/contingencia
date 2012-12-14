using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class ClsZCTCBAL : ClsZCTCDAL
    {
        public void AgregarZCTCBAL(ClsZCTC zCTC)
        {
            try
            {
                base.AgregarZCTCDAL(zCTC);
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarZCTCBAL(ClsZCTC zCTC)
        {
            try
            {
                base.ActualizarZCTCDAL(zCTC);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarZCTCBAL(ClsZCTC zCTC)
        {
            try
            {
                base.EliminarZCTC(zCTC);
            }
            catch
            {
                throw;
            }
        }

        public ClsZCTCCollection ConsultarZCTCBAL(string psCriterio)
        {
            ClsZCTCCollection zCTCCollection = new ClsZCTCCollection();
            try
            {
                zCTCCollection = base.ConsultarZCTCDAL(psCriterio);
                return zCTCCollection;
            }
            catch
            {
                throw;
            }
        }

        public ArrayList CargarZCTC()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsZCTCCollection zCTCCollection;
            ClsZCTCBAL zCTCBAL = new ClsZCTCBAL();
            ArrayList arrZCTC = new ArrayList();
            try
            {
                zCTCCollection = zCTCBAL.ConsultarZCTCBAL(criterio);
                IEnumerator listaRegistros = zCTCCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsZCTC currZCTC = (ClsZCTC)listaRegistros.Current;
                    arrZCTC.Add(new AddValue(currZCTC.Werks, currZCTC.Werks));
                }
                return arrZCTC;
            }
            catch
            {
                throw;
            }
        }
    }
}
