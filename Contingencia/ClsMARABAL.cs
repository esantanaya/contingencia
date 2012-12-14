using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace Contingencia
{
    class ClsMARABAL :ClsMARADAL
    {
        public void AgregarMARABAL(ClsMARA mara)
        {
            try
            {
                base.AgregarMARADAL(mara);
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarMARABAL(ClsMARA mara)
        {
            try
            {
                base.ActualizarMARADAL(mara);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarMARABAL(ClsMARA mara)
        {
            try
            {
                base.EliminarMARADAL(mara);
            }
            catch
            {
                throw;
            }
        }

        public ClsMARACollection ConsultarMARABAL(string psCriterio)
        {
            ClsMARACollection maraCollection = new ClsMARACollection();
            try
            {
                maraCollection = base.ConsultarMARADAL(psCriterio);
                return maraCollection;
            }
            catch
            {
                throw;
            }
        }

        public ArrayList CargarMARA()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsMARACollection maraCollection;
            ClsMARABAL maraBAL = new ClsMARABAL();
            ArrayList arrpMara = new ArrayList();
            try
            {
                maraCollection = maraBAL.ConsultarMARABAL(criterio);
                IEnumerator listaRegistros = maraCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsMARA currMara = (ClsMARA)listaRegistros.Current;
                    arrpMara.Add(new AddValue(currMara.Matnr, currMara.Matnr));
                }
                return arrpMara;
            }
            catch
            {
                throw;
            }
        }
    }
}
