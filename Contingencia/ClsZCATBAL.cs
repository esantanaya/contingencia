using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class ClsZCATBAL : ClsZCATDAL
    {
        public void AgregarZCATBAL(ClsZCAT zCAT)
        {
            try
            {
                base.AgregarZCATDAL(zCAT);
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarZCATBAL(ClsZCAT zCAT)
        {
            try
            {
                base.ActualizarZCATDAL(zCAT);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarZCATBAL(ClsZCAT zCAT)
        {
            try
            {
                base.EliminarZCAT(zCAT);
            }
            catch
            {
                throw;
            }
        }

        public ClsZCATCollection ConsultarZCATBAL(string psCriterio)
        {
            ClsZCATCollection zCATCollection = new ClsZCATCollection();
            try
            {
                zCATCollection = base.ConsultarZCATDAL(psCriterio);
                return zCATCollection;
            }
            catch
            {
                throw;
            }
        }

        public ArrayList CargarZCAT()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsZCATCollection zCATCollection;
            ClsZCATBAL zCATBAL = new ClsZCATBAL();
            ArrayList arrZCAT = new ArrayList();
            try
            {
                zCATCollection = zCATBAL.ConsultarZCATBAL(criterio);
                IEnumerator listaRegistros = zCATCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsZCAT currZCAT = (ClsZCAT)listaRegistros.Current;
                    arrZCAT.Add(new AddValue(currZCAT.Werks, currZCAT.Werks));
                }
                return arrZCAT;
            }
            catch
            {
                throw;
            }
        }
    }
  }

