using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Contingencia
{
    public class CLSCalidad
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private string calidad;
        public string Calidad
        {
            get { return calidad; }
            set { calidad = value; }
        }

        private string pesoIni;
        public string PesoIni
        {
            get { return pesoIni; }
            set { pesoIni = value; }
        }

        private string pesoFin;
        public string PesoFin
        {
            get { return pesoFin; }
            set { pesoFin = value; }
        }

        private string musculoIni;
        public string MusculoIni
        {
            get { return musculoIni; }
            set { musculoIni = value; }
        }

        private string musculoFin;
        public string MusculoFin {
            get { return musculoFin; }
            set { musculoFin = value; }
        }

        private string grasaIni;
        public string GrasaIni {
            get { return grasaIni; }
            set { grasaIni = value; }
        }

        private string grasaFin;
        public string GrasaFin {
            get { return grasaFin; }
            set { grasaFin = value; }
        }

        private string chuletaIni;
        public string ChuletaIni {
            get { return chuletaIni; }
            set { chuletaIni = value; }
        }

        private string chuletaFin;
        public string ChuletaFin {
            get { return chuletaFin; }
            set { chuletaFin = value; }
        }

        public void IniciarObjeto()
        {
            Calidad = Variables.Blanco;
            pesoIni = Variables.Blanco;
            PesoFin = Variables.Blanco;
            MusculoIni = Variables.Blanco;
        }
    }
}
