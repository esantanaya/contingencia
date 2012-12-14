using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Contingencia
{
    class ClsCatZMaster
    {

        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private string creadoPor;

        public ClsCatZMaster() 
        {
            centroDestino = "";
            almacenDestino = "";
            ubicacionDestino = "";
        }

        public string CreadoPor
        {
            get { return creadoPor; }
            set { creadoPor = value; }
        }
        private string idTarima;

        public string IdTarima
        {
            get { return idTarima; }
            set { idTarima = value; }
        }
        private string werks;      //centro

        public string Werks
        {
            get { return werks; }
            set { werks = value; }
        }
        private long idCaja;
        public long IdCaja
        {
            get { return idCaja; }
            set { idCaja = value; }
        }

        private string matnr;         //material

        public string Matnr
        {
            get { return matnr; }
            set { matnr = value; }
        }

        private string charg;      //lote

        public string Charg
        {
            get { return charg; }
            set { charg = value; }
        }

        private double cantidad;

        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private DateTime fechaCreacion;

        public DateTime FechaCreacion
        {
            get { return fechaCreacion; }
            set { fechaCreacion = value; }
        }

        private DateTime fechaProduccion;

        public DateTime FechaProduccion
        {
            get { return fechaProduccion; }
            set { fechaProduccion = value; }
        }
        private DateTime fechaCaducidad;

        public DateTime FechaCaducidad
        {
            get { return fechaCaducidad; }
            set { fechaCaducidad = value; }
        }
        private DateTime horaCreacion;

        public DateTime HoraCreacion
        {
            get { return horaCreacion; }
            set { horaCreacion = value; }
        }
        private string desembalada;

        public string Desembalada
        {
            get { return desembalada; }
            set { desembalada = value; }
        }
        private string borrado;

        public string Borrado
        {
            get { return borrado; }
            set { borrado = value; }
        }
        private string asignadaEntrega;

        public string AsignadaEntrega
        {
            get { return asignadaEntrega; }
            set { asignadaEntrega = value; }
        }

        private string centroDestino;

        public string CentroDestino
        {
            get { return centroDestino; }
            set { centroDestino = value; }
        }
        private string almacenDestino;

        public string AlmacenDestino
        {
            get { return almacenDestino; }
            set { almacenDestino = value; }
        }
        private string ubicacionDestino;

        public string UbicacionDestino
        {
            get { return ubicacionDestino; }
            set { ubicacionDestino = value; }
        }

        protected void IniciarObjeto()
        {
            creadoPor = Variables.Blanco;
            idTarima = Variables.Blanco;
            werks = Variables.Blanco;
            idCaja = Convert.ToInt32(Variables.Cero, currentCulture);
            matnr = Variables.Blanco;
            charg = Variables.Blanco;
            cantidad = Convert.ToDouble(Variables.Cero, currentCulture);
            fechaCreacion = DateTime.Now;
            fechaProduccion = DateTime.Now;
            fechaCaducidad = DateTime.Now;
            horaCreacion = DateTime.Now;
            desembalada = Variables.Blanco;
            borrado = Variables.Blanco;
            asignadaEntrega = Variables.Blanco;
            centroDestino = Variables.Blanco;
            almacenDestino = Variables.Blanco;
            ubicacionDestino = Variables.Blanco;
        }


    }
}
