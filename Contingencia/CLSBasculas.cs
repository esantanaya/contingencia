using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Globalization;

namespace Contingencia
{
    class CLSBasculas
    {
        private CultureInfo currentCulture = CultureInfo.CurrentCulture;
        private SerialPort puertoS = new SerialPort();

        private string codBascula;
        public string CodBascula
        {
            get { return codBascula; }
            set { codBascula = value; }
        }

        private string modeloBascula;
        public string ModeloBascula
        {
            get { return modeloBascula; }
            set { modeloBascula = value; }
        }

        private string codFatom;
        public string CodFatom
        {
            get { return codFatom; }
            set { codFatom = value; }
        }

        private void ObtenerSeteoBascula()
        {
            ClsZBasculasCollection colBascula = new ClsZBasculasBAL().ConsultarZBasculasBAL("");
            IEnumerator lista = colBascula.GetEnumerator();
            while (lista.MoveNext())
            {
                ClsZBasculas bascula = (ClsZBasculas)lista.Current;
                if (this.ModeloBascula.Equals(bascula.Modelo))
                {
                    codBascula = bascula.Setting;
                }
            }
        }

        public string PuertoSerial()
        {
            ObtenerSeteoBascula();
            //string codFatom = puertoFatom + settingFatom;
            string inData = "";
            //string lsPeso = "";
            if (puertoS.IsOpen)
            {
                CerrarPuerto();
            }

            try
            {
                InitComPort(codBascula);
                AbrirPuerto();
                puertoS.DiscardInBuffer();
                inData = inData + puertoS.ReadLine();
            }
            catch
            {

                throw new Exception("No fue posible leer la bascula!");
            }
            //while(true){
            //    inData = inData +puertoS.ReadLine();
            //    if (inData.Contains("r"))
            //    {
            //        break;
            //    }
            //}
            //txtbxPesoBruto.AppendText(inData);
            if (puertoS.IsOpen)
            {
                CerrarPuerto();
            }
            //inData = inData.Trim();
            bool encontroPDigi = false;
            int posPDigi = 0;
            int posUDigi = 0;

            for (int liCont = 1; liCont < inData.Length; liCont++)
            {

                if ((char.IsDigit(inData[liCont])))
                {
                    if (encontroPDigi)
                    {
                        posUDigi = liCont;
                    }
                    else
                    {
                        posPDigi = liCont;
                        encontroPDigi = true;
                    }
                }

                //"0","1","2","3","4","5","6","7","8","9","."
            }

            inData = inData.Substring(posPDigi, ((posUDigi - posPDigi) + 1));

            return inData.ToString();

            //InitComPort(codFatom);
            //inData = puertoS.ReadLine();
            //txtbxMusculo.Text = inData.Substring(21,4);
            //txtbxGrasa.Text = inData.Substring(25,5);
            //txtbxChuleta.Text = inData.Substring(30,5);
            //txtbxPesoBruto.AppendText(inData);
        }



        private void InitComPort(string psParametros)
        {
            string currValue = "";
            try
            {
                string[] aParametros = psParametros.Split(',');
                currValue = aParametros[1]; //Baud
                puertoS.BaudRate = System.Int32.Parse(currValue, currentCulture);
                #region Paridad
                currValue = aParametros[2]; //Parity
                switch (currValue)
                {
                    case "E":
                        {
                            puertoS.Parity = Parity.Even;
                            break;
                        }
                    case "M":
                        {
                            puertoS.Parity = Parity.Mark;
                            break;

                        }
                    case "N":
                        {
                            puertoS.Parity = Parity.None;
                            break;

                        }
                    case "O":
                        {
                            puertoS.Parity = Parity.Odd;
                            break;

                        }
                    case "S":
                        {
                            puertoS.Parity = Parity.Space;
                            break;

                        }
                }
                #endregion
                currValue = aParametros[3]; //DataBits
                puertoS.DataBits = System.Int32.Parse(currValue, currentCulture);

                #region StopBit
                currValue = aParametros[4]; //StopBits
                switch (currValue)
                {
                    case "N":
                        {
                            puertoS.StopBits = StopBits.None;
                            break;

                        }
                    case "O":
                        {
                            puertoS.StopBits = StopBits.One;
                            break;

                        }
                    case "OnePointFive":
                        {
                            puertoS.StopBits = StopBits.OnePointFive;
                            break;

                        }
                    case "Two":
                        {
                            puertoS.StopBits = StopBits.Two;
                            break;

                        }
                }
                #endregion

                currValue = aParametros[0]; //Número Puerto
                puertoS.PortName = "COM" + currValue;
                //puertoS.PortName = "USB" + currValue;
                puertoS.DtrEnable = true;
                puertoS.Handshake = Handshake.None;
                puertoS.DiscardNull = true;
            }
            catch
            {
                throw;
            }
        }

        private void AbrirPuerto()
        {
            try
            {
                puertoS.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CerrarPuerto()
        {
            try
            {
                puertoS.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
