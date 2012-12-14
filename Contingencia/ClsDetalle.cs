using System;

namespace Contingencia
{
    class ClsDetalle
    {
        private string entrega;     //VBELN
        private DateTime fecha;     //
        private string posicion;    //VGPOS
        private string numMaterial; //MATNR
        private string centro;      //WERK
        private string almacen;     //LGORT
        private string cantidad;    //LFIMG
        private string unidadMed;   //MEINS
        private string descripcion; //MAKTX
        private string picking; //MAKTX
        private int uniE;

        public int UniE
        {
            get { return uniE; }
            set { uniE = value; }
        }

        public string Entrega
        {
            get { return entrega; }
            set { entrega = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Posicion
        {
            get { return posicion; }
            set { posicion = value; }
        }

        public string NumMaterial
        {
            get { return numMaterial; }
            set { numMaterial = value; }
        }

        public string Centro
        {
            get { return centro; }
            set { centro = value; }
        }

        public string Almacen
        {
            get { return almacen; }
            set { almacen = value; }
        }

        public string Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public string UnidadMed
        {
            get { return unidadMed; }
            set { unidadMed = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Picking
        {
            get { return picking; }
            set { picking = value; }
        }


        public void IniciarObjeto()
        {
            Entrega = Variables.Blanco;
            Fecha = DateTime.Now;
            Posicion = Variables.Blanco;
            NumMaterial = Variables.Blanco;
            Centro = Variables.Blanco;
            Almacen = Variables.Blanco;
            Cantidad = Variables.Blanco;
            UnidadMed = Variables.Blanco;
            Descripcion = Variables.Blanco;
            Picking = Variables.Blanco;
        }
    }
}
