using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace Contingencia
{
    class ClsZBasculasBAL : ClsZBasculasDAL
    {

        public void AgregarZBasculasBAL(ClsZBasculas zBasculas)
        {
            try
            {
                base.AgregarZBasculasDAL(zBasculas);
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarZBasculasBAL(ClsZBasculas zBasculas)
        {
            try
            {
                base.ActualizarZBasculasDAL(zBasculas);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarZBasculasBAL(ClsZBasculas zBasculas)
        {
            try
            {
                base.EliminarZBasculasDAL(zBasculas);
            }
            catch
            {
                throw;
            }
        }

        public ClsZBasculasCollection ConsultarZBasculasBAL(string psCriterio)
        {
            ClsZBasculasCollection zBasculasCollection = new ClsZBasculasCollection();
            try
            {
                zBasculasCollection = base.ConsultarZBasculasDAL(psCriterio);
                return zBasculasCollection;
            }
            catch
            {
                throw;
            }
        }

        public ArrayList CargarZBasculas()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsZBasculasCollection zBasculasCollection;
            ClsZBasculasBAL zBasculasBAL = new ClsZBasculasBAL();
            ArrayList arrZBasculas = new ArrayList();
            try
            {
                zBasculasCollection = zBasculasBAL.ConsultarZBasculasBAL(criterio);
                IEnumerator listaRegistros = zBasculasCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsZBasculas currZBasculas = (ClsZBasculas)listaRegistros.Current;
                    arrZBasculas.Add(new AddValue(currZBasculas.Modelo, currZBasculas.Modelo));
                }
                return arrZBasculas;
            }
            catch
            {
                throw;
            }
        }

    }
}
