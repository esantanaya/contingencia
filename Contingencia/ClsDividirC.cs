using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contingencia
{
    public class ClsDividirC
    {

   /*     H.- Numero de caja
          P.- Numero de Parete
          L.-Numero de Lote de Producción
          D.- Fecha de Producción
          Q.-Cantidad
          W.- Centro. */
        

        private string numCaja;

        public string NumCaja
        {
            get { return numCaja; }
            set { numCaja = value; }
        }
        private string numParete;

        public string NumParete
        {
            get { return numParete; }
            set { numParete = value; }
        }
        private string numLoteProd;

        public string NumLoteProd
        {
            get { return numLoteProd; }
            set { numLoteProd = value; }
        }
        private string fechProd;

        public string FechProd
        {
            get { return fechProd; }
            set { fechProd = value; }
        }
        private string cant;

        public string Cant
        {
            get { return cant; }
            set { cant = value; }
        }
        private string centro;

        public string Centro
        {
            get { return centro; }
            set { centro = value; }
        }


        public Boolean DividirC(string codigo, string [] codigoCom)
        {
            Boolean ban = true;
            String [] codigos = codigo.Split('|');

            if (codigos.Length == 6)
            {

                for (int i = 0; i < codigos.Length; i++)
                {
                    if (!codigos[i].Substring(0, 1).Equals(codigoCom[i]))
                    {
                        ban = false;
                        return ban;
                    }
                }
                //H1001009875|P134303C1|L0014399446|D24/04/2012|Q     30.0 |W0R00
                numCaja = codigos[0].Remove(0,1);
                numParete = codigos[1].Remove(0, 1);
                numLoteProd = codigos[2].Remove(0, 1);
                fechProd = codigos[3].Remove(0, 1);
                cant = codigos[4].Remove(0, 1);
                centro = codigos[5].Remove(0, 1);
            }
            else
            {
                ban = false;
            }
            return ban;
        }



    }
}
