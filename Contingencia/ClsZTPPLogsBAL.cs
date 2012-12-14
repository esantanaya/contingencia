using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Contingencia
{
    class ClsZTPPLogsBAL : ClsZTPPLogsDAL
    {
        public void AgregarZTPPLogsBAL(ClsZTPPLogs zTPPLogs)
        {
            try
            {
                base.AgregarZTPPLogsDAL(zTPPLogs);

            }
            catch
            {
                throw;
            }
        }

        public ClsZTPPLogsCollection ObtenerChargReimpresionBAL(string psCriterio)
        {
            ClsZTPPLogsCollection zTPPLogsCollection = new ClsZTPPLogsCollection();
            try
            {
                zTPPLogsCollection = base.ObtenerChargReimpresion(psCriterio);
                return zTPPLogsCollection;
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarZTPPLogsBAL(ClsZTPPLogs zTPPLogs)
        {
            try
            {
                base.ActualizarZTPPLogsDAL(zTPPLogs);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarZTPPLogsBAL(ClsZTPPLogs zTPPLogs)
        {
            try
            {
                base.EliminarZTPPLogs(zTPPLogs);
            }
            catch
            {
                throw;
            }
        }

        public ClsZTPPLogsCollection ConsultarZTPPLogsBAL(string psCriterio)
        {
            ClsZTPPLogsCollection zTPPLogsCollection = new ClsZTPPLogsCollection();
            try
            {
                zTPPLogsCollection = base.ConsultarZTPPLogsDAL(psCriterio);
                return zTPPLogsCollection;
            }
            catch
            {
                throw;
            }
        }

        public ArrayList CargarZTPPLogs()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsZTPPLogsCollection zTPPLogsCollection;
            ClsZTPPLogsBAL zTPPLogsBAL = new ClsZTPPLogsBAL();
            ArrayList arrZTPPLogs = new ArrayList();
            try
            {
                zTPPLogsCollection = zTPPLogsBAL.ConsultarZTPPLogsBAL(criterio);
                IEnumerator listaRegistros = zTPPLogsCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsZTPPLogs currZTPPLogs = (ClsZTPPLogs)listaRegistros.Current;
                    arrZTPPLogs.Add(new AddValue(currZTPPLogs.Werks, currZTPPLogs.Werks));
                }
                return arrZTPPLogs;
            }
            catch
            {
                throw;
            }
        }
    }
}
