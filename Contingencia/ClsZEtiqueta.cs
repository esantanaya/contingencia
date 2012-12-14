using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contingencia
{
    public class ClsZEtiqueta
    {

        public ClsZEtiqueta() 
        {
            etiar="";        
            etifo="";        
            matnr="";        
            maktx="";        
            padre="";
            fprod= DateTime.Now;
            hora= DateTime.Now;
            fvto= DateTime.Now;
            um="KG";
            peso= 0.0;
            charg ="";
            dd ="";
            mm="";
            yyyy="";
            direc1="";
            direc2="";
            hu="";
            descripJap="";
            empresa="";
            kunnr="";
            barcode1="";
            barcode2="";
            tiprod="";
            codprod="";
            tatunr="";
            fmatan = DateTime.Now;
            farmado=DateTime.Now;
            opera="";
            barcode3="";
            pais="MexM";
            werks="";
            kdmat="";
            lifnr="";
            bstkd="";
            vbeln="";
            diasCad =0;
                    
        //
        }
             
        private string etiar;

        public string Etiar
        {
            get { return etiar; }
            set { etiar = value; }
        }
        private string etifo;

        public string Etifo
        {
            get { return etifo; }
            set { etifo = value; }
        }
        private string matnr;

        public string Matnr
        {
            get { return matnr; }
            set { matnr = value; }
        }
        private string maktx;

        public string Maktx
        {
            get { return maktx; }
            set { maktx = value; }
        }
        private string padre;

        public string Padre
        {
            get { return padre; }
            set { padre = value; }
        }
        private DateTime fprod;

        public DateTime Fprod
        {
            get { return fprod; }
            set { fprod = value; }
        }
        private DateTime hora;

        public DateTime Hora
        {
            get { return hora; }
            set { hora = value; }
        }
        private DateTime fvto;

        public DateTime Fvto
        {
            get { return fvto; }
            set { fvto = value; }
        }
        private string um;

        public string Um
        {
            get { return um; }
            set { um = value; }
        }
        private double peso;

        public double Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        private string charg;

        public string Charg
        {
            get { return charg; }
            set { charg = value; }
        }
        private string dd;

        public string Dd
        {
            get { return dd; }
            set { dd = value; }
        }
        private string mm;

        public string Mm
        {
            get { return mm; }
            set { mm = value; }
        }
        private string yyyy;

        public string Yyyy
        {
            get { return yyyy; }
            set { yyyy = value; }
        }
        private string direc1;

        public string Direc1
        {
            get { return direc1; }
            set { direc1 = value; }
        }
        private string direc2;

        public string Direc2
        {
            get { return direc2; }
            set { direc2 = value; }
        }
        private string hu;

        public string Hu
        {
            get { return hu; }
            set { hu = value; }
        }
        private string descripJap;

        public string DescripJap
        {
            get { return descripJap; }
            set { descripJap = value; }
        }
        private string empresa;

        public string Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        private string kunnr;

        public string Kunnr
        {
            get { return kunnr; }
            set { kunnr = value; }
        }
        private string barcode1;

        public string Barcode1
        {
            get { return barcode1; }
            set { barcode1 = value; }
        }
        private string barcode2;

        public string Barcode2
        {
            get { return barcode2; }
            set { barcode2 = value; }
        }
        private string tiprod;

        public string Tiprod
        {
            get { return tiprod; }
            set { tiprod = value; }
        }
        private string codprod;

        public string Codprod
        {
            get { return codprod; }
            set { codprod = value; }
        }
        private string tatunr;

        public string Tatunr
        {
            get { return tatunr; }
            set { tatunr = value; }
        }
        private DateTime fmatan;

        public DateTime Fmatan
        {
            get { return fmatan; }
            set { fmatan = value; }
        }
        private DateTime farmado;

        public DateTime Farmado
        {
            get { return farmado; }
            set { farmado = value; }
        }
        private string opera;

        public string Opera
        {
            get { return opera; }
            set { opera = value; }
        }
        private string barcode3;

        public string Barcode3
        {
            get { return barcode3; }
            set { barcode3 = value; }
        }
        private string pais;

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }
        private string werks;

        public string Werks
        {
            get { return werks; }
            set { werks = value; }
        }
        private string kdmat;

        public string Kdmat
        {
            get { return kdmat; }
            set { kdmat = value; }
        }
        private string lifnr;

        public string Lifnr
        {
            get { return lifnr; }
            set { lifnr = value; }
        }
        private string bstkd;

        public string Bstkd
        {
            get { return bstkd; }
            set { bstkd = value; }
        }
        private string vbeln;

        public string Vbeln
        {
            get { return vbeln; }
            set { vbeln = value; }
        }

        private int diasCad;

        public int DiasCad
        {
            get { return diasCad; }
            set { diasCad = value; }
        }

    }
}
