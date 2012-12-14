namespace Contingencia
{
    class ClsEntregas
    {
        private string entrega;         //VBELN
        private string destMercancia;   // KUNNR
        private string solicitante;     //KUNAG
        private string dptoEntrega;     //VSTEL
        private string numPedido;       //BSTNK

        public string Entrega
        {
            get { return entrega; }
            set { entrega = value; }
        }

        public string DestMercancia
        {
            get { return destMercancia; }
            set { destMercancia = value; }
        }

        public string Solicitante
        {
            get { return solicitante; }
            set { solicitante = value; }
        }

        public string DptoEntrega
        {
            get { return dptoEntrega; }
            set { dptoEntrega = value; }
        }

        public string NumPedido
        {
            get { return numPedido; }
            set { numPedido = value; }
        }

        public void IniciarObjeto()
        {
            Entrega = Variables.Blanco;
            DestMercancia = Variables.Blanco;
            Solicitante = Variables.Blanco;
            DptoEntrega = Variables.Blanco;
            NumPedido = Variables.Blanco;
        }
    }
}
