using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Contingencia
{
    class ClsResb
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private int rsnum;

        public int Rsnum
        {
            get { return rsnum; }
            set { rsnum = value; }
        }
        private string matnr;

        public string Matnr
        {
            get { return matnr; }
            set { matnr = value; }
        }
        private string aufnr;

        public string Aufnr
        {
            get { return aufnr; }
            set { aufnr = value; }
        }
        private string potx1;

        public string Potx1
        {
            get { return potx1; }
            set { potx1 = value; }
        }
        private string potx2;

        public string Potx2
        {
            get { return potx2; }
            set { potx2 = value; }
        }
        private string potx3;

        public string Potx3
        {
            get { return potx3; }
            set { potx3 = value; }
        }
        private string baugr;

        public string Baugr
        {
            get { return baugr; }
            set { baugr = value; }
        }
        private double bdmng;

        public double Bdmng
        {
            get { return bdmng; }
            set { bdmng = value; }
        }
        private string meins;

        public string Meins
        {
            get { return meins; }
            set { meins = value; }
        }
        private string werks;

        public string Werks
        {
            get { return werks; }
            set { werks = value; }
        }
        private double menge;

        public double Menge
        {
            get { return menge; }
            set { menge = value; }
        }
        private string bwart;

        public string Bwart
        {
            get { return bwart; }
            set { bwart = value; }
        }

        private string lgort;

        public string Lgort
        {
            get { return lgort; }
            set { lgort = value; }
        }

    }
}
