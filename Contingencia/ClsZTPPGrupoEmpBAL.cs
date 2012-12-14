using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class ClsZTPPGrupoEmpBAL : ClsZTPPGrupoEmpDAL
    {
        public void AgregarZTPPGrupoEmpBAL(ClsZTPPGrupoEmp zTPPGrupoEmp)
        {
            try
            {
                base.AgregarZTPPGrupoEmpDAL(zTPPGrupoEmp);

            }
            catch
            {
                throw;
            }
        }

        public void ActualizarZTPPGrupoEmpBAL(ClsZTPPGrupoEmp zTPPGrupoEmp)
        {
            try
            {
                base.ActualizarZTPPGrupoEmpDAL(zTPPGrupoEmp);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarZTPPGrupoEmpBAL(ClsZTPPGrupoEmp zTPPGrupoEmp)
        {
            try
            {
                base.EliminarZTPPGrupoEmp(zTPPGrupoEmp);
            }
            catch
            {
                throw;
            }
        }

        public ClsZTPPGrupoEmpCollection ConsultarZTPPGrupoEmpBAL(string psCriterio)
        {
            ClsZTPPGrupoEmpCollection zTPPGrupoEmpCollection = new ClsZTPPGrupoEmpCollection();
            try
            {
                zTPPGrupoEmpCollection = base.ConsultarZTPPGrupoEmpDAL(psCriterio);
                return zTPPGrupoEmpCollection;
            }
            catch
            {
                throw;
            }
        }

        public ArrayList CargarZTPPGrupoEmp()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsZTPPGrupoEmpCollection zTPPGrupoEmpCollection;
            ClsZTPPGrupoEmpBAL zTPPGrupoEmpBAL = new ClsZTPPGrupoEmpBAL();
            ArrayList arrZTPPGrupoEmp = new ArrayList();
            try
            {
                zTPPGrupoEmpCollection = zTPPGrupoEmpBAL.ConsultarZTPPGrupoEmpBAL(criterio);
                IEnumerator listaRegistros = zTPPGrupoEmpCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsZTPPGrupoEmp currZTPPGrupoEmp = (ClsZTPPGrupoEmp)listaRegistros.Current;
                    arrZTPPGrupoEmp.Add(new AddValue(currZTPPGrupoEmp.Grupo_Pt, currZTPPGrupoEmp.Grupo_Pt));
                }
                return arrZTPPGrupoEmp;
            }
            catch
            {
                throw;
            }
        }
    }
}
