using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Contingencia
{
    class CLSCanalFin
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private string centro;
        public string Centro
        {
            get { return centro; }
            set { centro = value; }
        }

        private string codDestino;
        public string CodDestino
        {
            get { return codDestino; }
            set { codDestino = value; }
        }

        private string ordenProp;
        public string OrdenProp
        {
            get { return ordenProp; }
            set { ordenProp = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string matnr;
        public string Matnr
        {
            get { return matnr; }
            set { matnr = value; }
        }

        private string matnrVirt;
        public string MatnrVirt
        {
            get { return matnrVirt; }
            set { matnrVirt = value; }
        }

        private string desensamble;
        public string Desensamble
        {
            get { return desensamble; }
            set { desensamble = value; }
        }

        private string autorizado;
        public string Autorizado
        {
            get { return autorizado; }
            set { autorizado = value; }
        }

        private string iCanaVenta;
        public string ICanaVenta
        {
            get { return iCanaVenta; }
            set { iCanaVenta = value; }
        }

        private string iRemisionado;
        public string IRemisionado
        {
            get { return iRemisionado; }
            set { iRemisionado = value; }
        }

        private string iCanaCorte;
        public string ICanaCorte
        {
            get { return iCanaCorte; }
            set { iCanaCorte = value; }
        }

        public void IniciarForma() {
            centro = Variables.Blanco;
            codDestino = Variables.Blanco;
            ordenProp = Variables.Blanco;
            descripcion = Variables.Blanco;
            matnr = Variables.Blanco;
            matnrVirt = Variables.Blanco;
            desensamble = Variables.Blanco;
            autorizado = Variables.Blanco;
            iCanaVenta = Variables.Blanco;
            iRemisionado = Variables.Blanco;
            iCanaCorte = Variables.Blanco;

        }
    }
}
