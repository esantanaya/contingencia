using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Contingencia
{
    class ClsCatAlmacenBAL : ClsCatAlmacenDAL
    {
        public void AgregarAlmacenBAL(ClsCatAlmacen Almacen)
        {
            try
            {
                base.AgregarAlmacenDAL(Almacen);
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarAlmacenBAL(ClsCatAlmacen Almacen)
        {
            try
            {
                base.ActualizarAlmacenDAL(Almacen);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarAlmacenBAL(ClsCatAlmacen Almacen)
        {
            try
            {
                base.EliminarAlmacenDAL(Almacen);
            }
            catch
            {
                throw;
            }
        }

        public ClsCatAlmacenCollection ConsultarAlmacenesBAL(string psCriterio)
        {
            ClsCatAlmacenCollection almacenesCollection = new ClsCatAlmacenCollection();
            try
            {
                almacenesCollection = base.ConsultarAlmacenDAL(psCriterio);

                return almacenesCollection;
            }
            catch
            {
                throw;
            }
        }

        public ArrayList CargarAlmacenes()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsCatAlmacenCollection almacenesCollection;
            ClsCatAlmacenBAL almacenesBAL = new ClsCatAlmacenBAL();
            ArrayList arrAlmacenes = new ArrayList();
            try
            {
                almacenesCollection = almacenesBAL.ConsultarAlmacenesBAL(criterio);
                IEnumerator listaRegistros = almacenesCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsCatAlmacen currAlmacen = (ClsCatAlmacen)listaRegistros.Current;
                    arrAlmacenes.Add(new AddValue(currAlmacen.Lgort, currAlmacen.Lgort));
                }
                return arrAlmacenes;
            }
            catch
            {
                throw;
            }
        }

    }
}
