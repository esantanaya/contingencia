using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contingencia
{
    public class ClsZTPPGrupoEmp
    {
        private string grupo_PT;

        public string Grupo_Pt
        {
            get { return grupo_PT; }
            set { grupo_PT = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private double pt_Aplicar;

        public double Pt_Aplicar
        {
            get { return pt_Aplicar; }
            set { pt_Aplicar = value; }
        }
        private string meins;

        public string Meins
        {
            get { return meins; }
            set { meins = value; }
        }
    }
}
