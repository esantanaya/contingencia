using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contingencia
{
    public class ClsZTPPGrupoMat
    {
        private string matnr;


        public string Matnr
        {
            get { return matnr; }
            set { matnr = value; }
        }
        private string werks;

        public string Werks
        {
            get { return werks; }
            set { werks = value; }
        }
        private string codigo_Padre;

        public string Codigo_Padre
        {
            get { return codigo_Padre; }
            set { codigo_Padre = value; }
        }
        private string grupo_pt;

        public string Grupo_pt
        {
            get { return grupo_pt; }
            set { grupo_pt = value; }
        }
        private DateTime tiempo_Pro;

        public DateTime Tiempo_Pro
        {
            get { return tiempo_Pro; }
            set { tiempo_Pro = value; }
        }
        private int motivoEnt;

        public int MotivoEnt
        {
            get { return motivoEnt; }
            set { motivoEnt = value; }
        }
        private int motivoCan;

        public int MotivoCan
        {
            get { return motivoCan; }
            set { motivoCan = value; }
        }
        private double pesoMax;

        public double PesoMax
        {
            get { return pesoMax; }
            set { pesoMax = value; }
        }
        private double pesoMin;

        public double PesoMin
        {
            get { return pesoMin; }
            set { pesoMin = value; }
        }
        private double pesoFijo;

        public double PesoFijo
        {
            get { return pesoFijo; }
            set { pesoFijo = value; }
        }
        private string meins;

        public string Meins
        {
            get { return meins; }
            set { meins = value; }
        }
        private string taraEdit;

        public string TaraEdit
        {
            get { return taraEdit; }
            set { taraEdit = value; }
        }
        private string procedimiento;

        public string Procedimiento
        {
            get { return procedimiento; }
            set { procedimiento = value; }
        }
        private string clave_Rend;

        public string Clave_Rend
        {
            get { return clave_Rend; }
            set { clave_Rend = value; }
        }

    }
}
