using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Contingencia
{
    class ClsZFolioBAL : ClsZFolioDAL
    {
        public void AgregarZFolioBAL(ClsZFolio zFolio)
        {
            try
            {
                base.AgregarZFolioDAL(zFolio);
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarZFolioBAL(ClsZFolio zFolio)
        {
            try
            {
                base.ActualizarZFolioDAL(zFolio);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarZFolioBAL(ClsZFolio zFolio)
        {
            try
            {
                base.EliminarZFolio(zFolio);
            }
            catch
            {
                throw;
            }
        }

        public ClsZFolioCollection ConsultarZFolioBAL(string psCriterio)
        {
            ClsZFolioCollection zFolioCollection = new ClsZFolioCollection();
            try
            {
                zFolioCollection = base.ConsultarZFolioDAL(psCriterio);
                return zFolioCollection;
            }
            catch
            {
                throw;
            }
        }

        
        public ClsZFolioCollection AgregaryRetornoZFolioBAL(ClsZFolio zFolio)
        {
            ClsZFolioCollection zFolioCollection = new ClsZFolioCollection();
            try
            {
                zFolioCollection = base.AgregaryRetornoZFolioDAL(zFolio);
                return zFolioCollection;
            }
            catch
            {
                throw;
            }
        }

        public ArrayList CargarZFolio()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsZFolioCollection zFolioCollection;
            ClsZFolioBAL zFolioBAL = new ClsZFolioBAL();
            ArrayList arrZFolio = new ArrayList();
            try
            {
                zFolioCollection = zFolioBAL.ConsultarZFolioBAL(criterio);
                IEnumerator listaRegistros = zFolioCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsZFolio currZFolio = (ClsZFolio)listaRegistros.Current;
                    arrZFolio.Add(new AddValue(currZFolio.Werks, currZFolio.Werks));
                }
                return arrZFolio;
            }
            catch
            {
                throw;
            }
        }
    }
}
