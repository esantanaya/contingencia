using System;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class CLSLips
    {
        private string entrega;
        public string Entrega
        {
            get { return entrega; }
            set { entrega = value; }
        }

        private string centro;
        public string Centro
        {
            get { return centro; }
            set { centro = value; }
        }

        private string matnr;        
        public string Matnr
        {
            get { return matnr; }
            set { matnr = value; }
        }

        private string lgort;
        public string Lgort
        {
            get { return lgort; }
            set { lgort = value; }
        }

        private double lfimg;        
        public double Lfimg
        {
            get { return lfimg; }
            set { lfimg = value; }
        }

        private string vgbel;
        public string Vgbel
        {
            get { return vgbel; }
            set { vgbel = value; }
        }

        private string vgpos;
        public string Vgpos
        {
            get { return vgpos; }
            set { vgpos = value; }
        }

        private string netpr;
        public string Netpr
        {
            get { return netpr; }
            set { netpr = value; }
        }

        private string waerk;
        public string Waerk
        {
            get { return waerk; }
            set { waerk = value; }
        }

        private string meins;        
        public string Meins
        {
            get { return meins; }
            set { meins = value; }
        }

        
        private int uniemp;

        public int Uniemp
        {
            get { return uniemp; }
            set { uniemp = value; }
        }

        private double picking;

        public double Picking
        {
            get { return picking; }
            set { picking = value; }
        }

        public void IniciarObjeto()
        {
            Entrega = Variables.Blanco;
            Centro = Variables.Blanco;
            Matnr = Variables.Blanco;
            Lgort = Variables.Blanco;
            Lfimg = 0.0;
            Vgbel = Variables.Blanco;
            Vgpos = Variables.Blanco;
            Netpr = Variables.Blanco;
            Waerk = Variables.Blanco;
            Meins = Variables.Blanco;
        }
    }
}
