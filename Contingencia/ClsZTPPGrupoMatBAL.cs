using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class ClsZTPPGrupoMatBAL : ClsZTPPGrupoMatDAL
    {
        public void AgregarZTPPGrupoMatBAL(ClsZTPPGrupoMat zTPPGrupoMat)
        {
            try
            {
                base.AgregarZTPPGrupoMatDAL(zTPPGrupoMat);

            }
            catch
            {
                throw;
            }
        }

        public void ActualizarZTPPGrupoMatBAL(ClsZTPPGrupoMat zTPPGrupoMat)
        {
            try
            {
                base.ActualizarZTPPGrupoMatDAL(zTPPGrupoMat);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarZTPPGrupoMatBAL(ClsZTPPGrupoMat zTPPGrupoMat)
        {
            try
            {
                base.EliminarZTPPGrupoMat(zTPPGrupoMat);
            }
            catch
            {
                throw;
            }
        }

        public ClsZTPPGrupoMatCollection ConsultarZTPPGrupoMatBAL(string psCriterio)
        {
            ClsZTPPGrupoMatCollection zTPPGrupoMatCollection = new ClsZTPPGrupoMatCollection();
            try
            {
                zTPPGrupoMatCollection = base.ConsultarZTPPGrupoMatDAL(psCriterio);
                return zTPPGrupoMatCollection;
            }
            catch
            {
                throw;
            }
        }

        public ArrayList CargarZTPPGrupoMat()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsZTPPGrupoMatCollection zTPPGrupoMatCollection;
            ClsZTPPGrupoMatBAL zTPPGrupoMatBAL = new ClsZTPPGrupoMatBAL();
            ArrayList arrZTPPGrupoMat = new ArrayList();
            try
            {
                zTPPGrupoMatCollection = zTPPGrupoMatBAL.ConsultarZTPPGrupoMatBAL(criterio);
                IEnumerator listaRegistros = zTPPGrupoMatCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsZCTC currZCTC = (ClsZCTC)listaRegistros.Current;
                    arrZTPPGrupoMat.Add(new AddValue(currZCTC.Werks, currZCTC.Werks));
                }
                return arrZTPPGrupoMat;
            }
            catch
            {
                throw;
            }
        }
    }
}
