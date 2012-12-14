using System;

namespace Contingencia
{
    class ClsTarimaTemporal
    {
        private string idTarima;
        private string idEntrega;
        private string pedido;
        private DateTime fecha;
        
        public string IdTarima
        {
            get { return idTarima; }
            set { idTarima = value; }
        }

        public string IdEntrega
        {
            get { return idEntrega; }
            set { idEntrega = value; }
        }

        public string Pedido
        {
            get { return pedido; }
            set { pedido = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        public void IniciarObjeto()
        {
            IdTarima = "";
            IdEntrega = Variables.Blanco;
            Pedido = Variables.Blanco;
            Fecha = DateTime.Now;
        }
    }
}
