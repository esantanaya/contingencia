using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Contingencia
{
    public class ClsZTPPLogs
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        public ClsZTPPLogs() 
        {
            fecha_a = new DateTime(1900, 1, 1);
            hora_a = new DateTime(1900, 1, 1);
            tipo_en = "";
            anulo = "";
        } 

        private string werks;

        public string Werks
        {
            get { return werks; }
            set { werks = value; }
        }
        private string exidv;

        public string Exidv
        {
            get { return exidv; }
            set { exidv = value; }
        }
        private int posicion;

        public int Posicion
        {
            get { return posicion; }
            set { posicion = value; }
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
        private string proceso;

        public string Proceso
        {
            get { return proceso; }
            set { proceso = value; }
        }
        private string lgort;

        public string Lgort
        {
            get { return lgort; }
            set { lgort = value; }
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
        private string vornr;

        public string Vornr
        {
            get { return vornr; }
            set { vornr = value; }
        }
        private string icon;

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        private double vemng;

        public double Vemng
        {
            get { return vemng; }
            set { vemng = value; }
        }
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        private string mblnr;

        public string Mblnr
        {
            get { return mblnr; }
            set { mblnr = value; }
        }
        private int mjahr;

        public int Mjahr
        {
            get { return mjahr; }
            set { mjahr = value; }
        }
        private string bwart;

        public string Bwart
        {
            get { return bwart; }
            set { bwart = value; }
        }
        private int rueck;

        public int Rueck
        {
            get { return rueck; }
            set { rueck = value; }
        }
        private int rmzhl;

        public int Rmzhl
        {
            get { return rmzhl; }
            set { rmzhl = value; }
        }
        private string mov_hu;

        public string Mov_hu
        {
            get { return mov_hu; }
            set { mov_hu = value; }
        }
        private string tipo_en;

        public string Tipo_en
        {
            get { return tipo_en; }
            set { tipo_en = value; }
        }
        private string anulo;

        public string Anulo
        {
            get { return anulo; }
            set { anulo = value; }
        }
        private DateTime fecha_a;

        public DateTime Fecha_a
        {
            get { return fecha_a; }
            set { fecha_a = value; }
        }
        private DateTime hora_a;

        public DateTime Hora_a
        {
            get { return hora_a; }
            set { hora_a = value; }
        }

        private string charg;
        public string Charg
        {
            get { return charg; }
            set { charg = value; }
        }
    }
}
