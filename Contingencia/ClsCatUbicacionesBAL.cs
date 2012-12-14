using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Contingencia
{
    class ClsCatUbicacionesBAL : ClsCatUbicacionesDAL
    {
        public void AgregarUbicacionesBAL(ClsCatUbicaciones Ubicacion)
        {
            try
            {
                base.AgregarUbicacionesDAL(Ubicacion);
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarUbicacionesBAL(ClsCatUbicaciones Ubicacion)
        {
            try
            {
                base.ActualizarUbicacionesDAL(Ubicacion);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarUbicacionesBAL(ClsCatUbicaciones Ubicacion)
        {
            try
            {
                base.EliminarUbicacionesDAL(Ubicacion);
            }
            catch
            {
                throw;
            }
        }

        public ClsCatUbicacionesCollection ConsultarUbicacionesBAL(string psCriterio)
        {
            ClsCatUbicacionesCollection ubicacionesCollection = new ClsCatUbicacionesCollection();
            try
            {
                ubicacionesCollection = base.ConsultarUbicacionDAL(psCriterio);

                return ubicacionesCollection;
            }
            catch
            {
                throw;
            }
        }

        public ArrayList CargarUbicaciones()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsCatUbicacionesCollection ubicacionesCollection;
            ClsCatUbicacionesBAL ubicacionesBAL = new ClsCatUbicacionesBAL();
            ArrayList arrUbicaciones = new ArrayList();
            try
            {
                ubicacionesCollection = ubicacionesBAL.ConsultarUbicacionesBAL(criterio);
                IEnumerator listaRegistros = ubicacionesCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsCatUbicaciones currUbicaciones = (ClsCatUbicaciones)listaRegistros.Current;
                    arrUbicaciones.Add(new AddValue(currUbicaciones.Werks, currUbicaciones.Werks));
                }
                return arrUbicaciones;
            }
            catch
            {
                throw;
            }
        }

    }
}
