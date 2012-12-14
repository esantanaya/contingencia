using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contingencia
{
    public class ClsZTPPTrazabi
    {
        private string werks;

        public string Werks
        {
            get { return werks; }
            set { werks = value; }
        }
        private string lgort;

        public string Lgort
        {
            get { return lgort; }
            set { lgort = value; }
        }
        private string procedimiento;

        public string Procedimiento
        {
            get { return procedimiento; }
            set { procedimiento = value; }
        }
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private DateTime hora;

        public DateTime Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        private string tatuaje;

        public string Tatuaje
        {
            get { return tatuaje; }
            set { tatuaje = value; }
        }
        private DateTime fechamatanza;

        public DateTime Fechamatanza
        {
            get { return fechamatanza; }
            set { fechamatanza = value; }
        }
    }
}
