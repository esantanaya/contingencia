using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Contingencia
{
    class ClsResbBAL : ClsResbDAL
    {
        public void AgregarResbBAL(ClsResb resb)
        {
            try
            {
                base.AgregarResbDAL(resb);
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarResbBAL(ClsResb resb)
        {
            try
            {
                base.ActualizarResbDAL(resb);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarResbBAL(ClsResb  resb)
        {
            try
            {
                base.EliminarResbDAL(resb);
            }
            catch
            {
                throw;
            }
        }



        public ClsResbCollection ConsultarResbBAL(string psCriterio)
        {
            ClsResbCollection resbCollection = new ClsResbCollection();
            try
            {
                resbCollection = base.ConsultarResbDAL(psCriterio);

                return resbCollection;
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
            ClsResbCollection resbCollection;
            ClsResbBAL resbBAL = new ClsResbBAL();
            ArrayList arrResb = new ArrayList();
            try
            {
                resbCollection = resbBAL.ConsultarResbBAL(criterio);
                IEnumerator listaRegistros = resbCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsResb currResb = (ClsResb)listaRegistros.Current;

                    arrResb.Add(new AddValue(currResb.Werks, currResb.Werks));
                }
                return arrResb;
            }
            catch
            {
                throw;
            }
        }
    }
}
