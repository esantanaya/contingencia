using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contingencia
{
    public class ClsDatosHU
    {
        public ClsDatosHU() 
        { 
            primeraOrden="";        
            primerMaterial="";
            tipoPrimera="";
            lote1="";        
            calculaFc1="";
            segundaOrden="";
            segundaRsnum=0;
            segundoMaterial="";
            tipoSegunda ="";
            tipoTercera="";
            terceraOrden="";
            tercerMaterial="";
            lote2="";
            lote3="";        
        calculaFc2="";

        
        calculaFC3="";

        
        cantidadCaja=0.0;

        
        maximoXCaja=0.0;

        
        materialPantalla="";

        
        materiaPrima1="";

        
        materiaPrima2="";

        
        materiaPrima3="";

        
        codigoHijo2="";

        
        lgort1="";        
        lgort2="";        
        lgort3="";
        terceraRsnum = 0;
        
        }

        private string primeraOrden;

        public string PrimeraOrden
        {
            get { return primeraOrden; }
            set { primeraOrden = value; }
        }
        private string primerMaterial;

        public string PrimerMaterial
        {
            get { return primerMaterial; }
            set { primerMaterial = value; }
        }
        private string tipoPrimera;

        public string TipoPrimera
        {
            get { return tipoPrimera; }
            set { tipoPrimera = value; }
        }
        private string lote1;

        public string Lote1
        {
            get { return lote1; }
            set { lote1 = value; }
        }
        private string calculaFc1;

        public string CalculaFc1
        {
            get { return calculaFc1; }
            set { calculaFc1 = value; }
        }
        private string segundaOrden;

        public string SegundaOrden
        {
            get { return segundaOrden; }
            set { segundaOrden = value; }
        }
        private int segundaRsnum;

        public int SegundaRsnum
        {
            get { return segundaRsnum; }
            set { segundaRsnum = value; }
        }
        private string segundoMaterial;

        public string SegundoMaterial
        {
            get { return segundoMaterial; }
            set { segundoMaterial = value; }
        }
        private string tipoSegunda;

        public string TipoSegunda
        {
            get { return tipoSegunda; }
            set { tipoSegunda = value; }
        }
        private string tipoTercera;

        public string TipoTercera
        {
            get { return tipoTercera; }
            set { tipoTercera = value; }
        }
        private string terceraOrden;

        public string TerceraOrden
        {
            get { return terceraOrden; }
            set { terceraOrden = value; }
        }
        private string tercerMaterial;

        public string TercerMaterial
        {
            get { return tercerMaterial; }
            set { tercerMaterial = value; }
        }
        private string lote2;

        public string Lote2
        {
            get { return lote2; }
            set { lote2 = value; }
        }
        private string lote3;

        public string Lote3
        {
            get { return lote3; }
            set { lote3 = value; }
        }
        private string calculaFc2;

        public string CalculaFc2
        {
            get { return calculaFc2; }
            set { calculaFc2 = value; }
        }
        private string calculaFC3;

        public string CalculaFC3
        {
            get { return calculaFC3; }
            set { calculaFC3 = value; }
        }
        private double cantidadCaja;

        public double CantidadCaja
        {
            get { return cantidadCaja; }
            set { cantidadCaja = value; }
        }
        private double maximoXCaja;

        public double MaximoXCaja
        {
            get { return maximoXCaja; }
            set { maximoXCaja = value; }
        }
        private string materialPantalla;

        public string MaterialPantalla
        {
            get { return materialPantalla; }
            set { materialPantalla = value; }
        }
        private string materiaPrima1;

        public string MateriaPrima1
        {
            get { return materiaPrima1; }
            set { materiaPrima1 = value; }
        }
        private string materiaPrima2;

        public string MateriaPrima2
        {
            get { return materiaPrima2; }
            set { materiaPrima2 = value; }
        }
        private string materiaPrima3;

        public string MateriaPrima3
        {
            get { return materiaPrima3; }
            set { materiaPrima3 = value; }
        }
        private string codigoHijo2;

        public string CodigoHijo2
        {
            get { return codigoHijo2; }
            set { codigoHijo2 = value; }
        }
        private string lgort1;

        public string Lgort1
        {
            get { return lgort1; }
            set { lgort1 = value; }
        }
        private string lgort2;

        public string Lgort2
        {
            get { return lgort2; }
            set { lgort2 = value; }
        }
        private string lgort3;

        public string Lgort3
        {
            get { return lgort3; }
            set { lgort3 = value; }
        }

        private int terceraRsnum;

        public int TerceraRsnum
        {
            get { return terceraRsnum; }
            set { terceraRsnum = value; }
        }

    }
}
