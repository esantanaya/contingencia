namespace Contingencia
{
    class ClsEntregasDetalle
    {
        private string entrega;     //VBELN
        private string centro;      //WERK
        private string numMaterial; //MATNR
        private string almacem;     //LGORT
        private string cantidad;    //LFIMG
        private string numPedido;   //VGBEL
        private string vgpos;       //VGPOS
        private string precioNeto;  //NETPR
        private string moneda;      //WAERK

        public string Entrega
        {
            get { return entrega; }
            set { entrega = value; }
        }

        public string Centro
        {
            get { return centro; }
            set { centro = value; }
        }

        public string NumMaterial
        {
            get { return numMaterial; }
            set { numMaterial = value; }
        }

        public string Almacem
        {
            get { return almacem; }
            set { almacem = value; }
        }

        public string Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public string NumPedido
        {
            get { return numPedido; }
            set { numPedido = value; }
        }

        public string Vgpos
        {
            get { return vgpos; }
            set { vgpos = value; }
        }

        public string PrecioNeto
        {
            get { return precioNeto; }
            set { precioNeto = value; }
        }

        public string Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }


        public void IniciarObjeto()
        {
            Entrega = Variables.Blanco;
            Centro = Variables.Blanco;
            NumMaterial = Variables.Blanco;
            Almacem = Variables.Blanco;
            Cantidad = Variables.Blanco;
            NumPedido = Variables.Blanco;
            Vgpos = Variables.Blanco;
            PrecioNeto = Variables.Blanco;
            Moneda = Variables.Blanco;
        }
    }
}
