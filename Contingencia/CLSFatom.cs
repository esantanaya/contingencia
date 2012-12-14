using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Contingencia
{
    public class CLSFatom
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private string werks;
        public string Werks
        {
            get { return werks; }
            set { werks = value; }
        }

        private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private int folio;
        public int Folio
        {
            get { return folio; }
            set { folio = value; }
        }

        private string charg;
        public string Charg
        {
            get { return charg; }
            set { charg = value; }
        }

        private double erfmg;
        public double Erfmg
        {
            get { return erfmg; }
            set { erfmg = value; }
        }

        private string erfme;
        public string Erfme
        {
            get { return erfme; }
            set { erfme = value; }
        }

        private double tara;
        public double Tara
        {
            get { return tara; }
            set { tara = value; }
        }

        private string serie;
        public string Serie
        {
            get { return serie; }
            set { serie = value; }
        }

        private string tatuaje;
        public string Tatuaje
        {
            get { return tatuaje; }
            set { tatuaje = value; }
        }

        private double pesoProm;
        public double PesoProm
        {
            get { return pesoProm; }
            set { pesoProm = value; }
        }

        private string calidad;
        public string Calidad
        {
            get { return calidad; }
            set { calidad = value; }
        }

        private string codDestino;
        public string CodDestino
        {
            get { return codDestino; }
            set { codDestino = value; }
        }

        private string destino;
        public string Destino
        {
            get { return destino; }
            set { destino = value; }
        }

        private double musculo;
        public double Musculo
        {
            get { return musculo; }
            set { musculo = value; }
        }

        private double grasa;
        public double Grasa
        {
            get { return grasa; }
            set { grasa = value; }
        }

        private double chuleta;
        public double Chuleta
        {
            get { return chuleta; }
            set { chuleta = value; }
        }

        private DateTime fechaLote;
        public DateTime FechaLote
        {
            get { return fechaLote; }
            set { fechaLote = value; }
        }

        private string pesarCab;
        public string PesarCab
        {
            get { return pesarCab; }
            set { pesarCab = value; }
        }

        private double pesoCab;
        public double PesoCab
        {
            get { return pesoCab; }
            set { pesoCab = value; }
        }

        private string matnr;
        public string Matnr
        {
            get { return matnr; }
            set { matnr = value; }
        }

        private string matnrProd;
        public string MatnrProd
        {
            get { return matnrProd; }
            set { matnrProd = value; }
        }

        private string matnrProd2;
        public string MatnrProd2
        {
            get { return matnrProd2; }
            set { matnrProd2 = value; }
        }

        private string aufnr;
        public string Aufnr
        {
            get { return aufnr; }
            set { aufnr = value; }
        }

        private string procesado;
        public string Procesado
        {
            get { return procesado; }
            set { procesado = value; }
        }

        private double pesoSinCabeza;
        public double PesoSinCabeza
        {
            get { return pesoSinCabeza; }
            set { pesoSinCabeza = value; }
        }

        private string chargProd;
        public string ChargProd
        {
            get { return chargProd; }
            set { chargProd = value; }
        }

        private double kg1;
        public double Kg1
        {
            get { return kg1; }
            set { kg1 = value; }
        }

        private double kg2;
        public double Kg2
        {
            get { return kg2; }
            set { kg2 = value; }
        }

        private string estadoMaq;
        public string EstadoMaq
        {
            get { return estadoMaq; }
            set { estadoMaq = value; }
        }

        private string matnrProd2Virt;
        public string MatnrProd2Virt
        {
            get { return matnrProd2Virt; }
            set { matnrProd2Virt = value; }
        }



        private string ordenProp;
        public string OrdenProp
        {
            get { return ordenProp; }
            set { ordenProp = value; }
        }

        private string desensamble;
        public string Desensamble
        {
            get { return desensamble; }
            set { desensamble = value; }
        }

        private string aufnr2;
        public string Aufnr2
        {
            get { return aufnr2; }
            set { aufnr2 = value; }
        }

        private string chargProd2;
        public string ChargProd2
        {
            get { return chargProd2; }
            set { chargProd2 = value; }
        }

        private string matnrMaq;
        public string MatnrMaq
        {
            get { return matnrMaq; }
            set { matnrMaq = value; }
        }

        private string aufnr2Virt;
        public string Aufnr2Virt
        {
            get { return aufnr2Virt; }
            set { aufnr2Virt = value; }
        }

        private string chargProd2Virt;
        public string ChargProd2Virt
        {
            get { return chargProd2Virt; }
            set { chargProd2Virt = value; }
        }

        private string vbeln;
        public string Vbeln
        {
            get { return vbeln; }
            set { vbeln = value; }
        }

        public void IniciarObjeto()
        {
            Werks = Variables.Blanco;
            Fecha = Convert.ToDateTime(Variables.FechaNula);
            Folio = 1;
            Charg = Variables.Blanco;
            Tara = 3.5;
            Tatuaje = Variables.Blanco;
            PesoProm = 0.0;
            Calidad = Variables.Blanco;
            CodDestino = Variables.Blanco;
            Destino = Variables.Blanco;
            Musculo = 0.0;
            Grasa = 0.0;
            Chuleta = 0.0;
            FechaLote = Convert.ToDateTime(Variables.FechaNula);
            PesarCab = Variables.Blanco;
            PesoCab = 0.0;
            Matnr = Variables.Blanco;
            MatnrProd = Variables.Blanco;
            Aufnr = Variables.Blanco;
            Procesado = Variables.Blanco;
            Kg1 = 0.0;
        }
    }
}
