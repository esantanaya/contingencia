using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class ClsZTPPTrazabiBAL : ClsZTPPTrazabiDAL
    {
        public void AgregarZTPPTrazabiBAL(ClsZTPPTrazabi zTPPTrazabi)
        {
            try
            {
                base.AgregarZTPPTrazabiDAL(zTPPTrazabi);

            }
            catch
            {
                throw;
            }
        }

        public void ActualizarZTPPTrazabiBAL(ClsZTPPTrazabi zTPPTrazabi)
        {
            try
            {
                base.ActualizarZTPPTrazabiDAL(zTPPTrazabi);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarZTPPTrazabiBAL(ClsZTPPTrazabi zTPPTrazabi)
        {
            try
            {
                base.EliminarZTPPTrazabi(zTPPTrazabi);
            }
            catch
            {
                throw;
            }
        }

        public ClsZTPPTrazabiCollection ConsultarZTPPTrazabiBAL(string psCriterio)
        {
            ClsZTPPTrazabiCollection zTPPTrazabiCollection = new ClsZTPPTrazabiCollection();
            try
            {
                zTPPTrazabiCollection = base.ConsultarZTPPTrazabiDAL(psCriterio);
                return zTPPTrazabiCollection;
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
