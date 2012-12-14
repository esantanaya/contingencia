using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Globalization;

namespace Contingencia
{
    /*
     * Autor: Enrique Santana
     * Fecha de creación: 02/05/2012
     * Fecha de liberación: 04/06/2012
     * Descripción: Punto de Control ZPPG01 :: FATOMETER
     */

    public partial class FrmZPPG01Captura : FrmBase
    {

    /*
     * Autor: Enrique Santana
     * Fecha de creación: 02/05/2012
     * Fecha de liberación: 04/06/2012
     * Descripción: Declaración de variables
     */

        //private SerialPort puertoFat = new SerialPort();
        static CultureInfo currentCulture = CultureInfo.CurrentCulture;
        private string inData = "";
        private double totalCerdos = 0.0;
        private double totalKilos = 0.0;
        private string charg2 = "";
        private double deberiaCerdos = 0.0;
        private double deberiaKilos = 0.0;

        private string settingFatom;
        public string SettingFatom
        {
            get { return settingFatom; }
            set { settingFatom = value; }
        }

        private string puertoFatom;
        public string PuertoFatom
        {
            get { return puertoFatom; }
            set { puertoFatom = value; }
        }

        private string codBascula;
        public string CodBascula
        {
            get { return codBascula; }
            set { codBascula = value; }
        }

        private string codCentro;
        public string CodCentro {
            get { return codCentro; }
            set { codCentro = value; }
        }

        private string desCentro;
        public string DesCentro {
            get { return desCentro; }
            set { desCentro = value; }
        }

        private bool bascula;
        public bool Bascula {
            get { return bascula; }
            set { bascula = value; }
        }

        private string modeloBascula;
        public string ModeloBascula
        {
            get { return modeloBascula; }
            set { modeloBascula = value; }
        }

        public void IniciarForma() {
            txtbxCentro.Text = codCentro;
            lblCentro.Text = desCentro;
        }

        public FrmZPPG01Captura()
        {
            InitializeComponent();
        }

        private void FrmZPPG01Captura_Load(object sender, EventArgs e)
        {
            base.PonerTitulo("Estación 1: Fatometer");
            txtbxFolio.Text = CalcularFolio(dtpFecha.Value.Date).ToString();
            if (bascula == true) { txtbxPesoBruto.ReadOnly = true; }
            txtbxLote.Select();
            txtbxLote.Focus();
            try
            {
               PuertoFatometer();
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }

        /*private void ObtenerSeteoBascula()
        {
            ClsZBasculasCollection colBascula = new ClsZBasculasBAL().ConsultarZBasculasBAL("");
            IEnumerator lista = colBascula.GetEnumerator();
            while(lista.MoveNext())
            {
                ClsZBasculas bascula = (ClsZBasculas)lista.Current;
                if(this.modeloBascula.Equals(bascula.Modelo))
                {
                    codBascula = bascula.Setting;
                }
            }
        }*/

        private void PuertoFatometer() 
        {
            //ObtenerSeteoBascula();
            string codFatom = puertoFatom + "," + settingFatom;
            //string inData = "";
            //string lsPeso = "";
            /*if(puertoFat.IsOpen) 
            {
                CerrarPuerto();
            }*/

            try
            {
                InitComPort(codFatom);
                AbrirPuerto();
                //puertoFat.DiscardInBuffer();
                /*inData = inData + puertoFat.ReadLine();
                return inData;*/
            }
            catch
            {
                if (txtbxChuleta.TextLength == 0 || txtbxGrasa.TextLength == 0 || txtbxMusculo.TextLength == 0)
                {
                    //throw new Exception("Error en lectura del fatometer"); 
                }
            }
        }
            //while(true){
            //    inData = inData +puertoFat.ReadLine();
            //    if (inData.Contains("r"))
            //    {
            //        break;
            //    }
            //}
            //txtbxPesoBruto.AppendText(inData);
            /*if (puertoFat.IsOpen)
            {
                CerrarPuerto();
            }*/
            //inData = inData.Trim();
            /*bool encontroPDigi = false;
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

            inData = inData.Substring(posPDigi,((posUDigi-posPDigi)+1));

            txtbxPesoBruto.Text = "";
            txtbxPesoBruto.Text = inData.ToString();*/
            
            //InitComPort(codFatom);
            //inData = puertoFat.ReadLine();

        private void IngresaFatom()
        {
            if (inData.Length >= 32)
            {
                txtbxMusculo.Text = inData.Substring(21, 4);
                txtbxGrasa.Text = inData.Substring(25, 5);
                txtbxChuleta.Text = inData.Substring(30, 5); 
            }
            //MessageBox.Show(inData);
            //txtbxPesoBruto.AppendText(inData);
        }

        private void InitComPort(string psParametros)
        {
            string currValue = "";
            try
            {
                string[] aParametros = psParametros.Split(',');
                currValue = aParametros[1]; //Baud
                puertoFat.BaudRate = System.Int32.Parse(currValue, currentCulture);
                #region Paridad
                currValue = aParametros[2]; //Parity
                switch (currValue)
                {
                    case "E":
                        {
                            puertoFat.Parity = Parity.Even;
                            break;
                        }
                    case "M":
                        {
                            puertoFat.Parity = Parity.Mark;
                            break;

                        }
                    case "N":
                        {
                            puertoFat.Parity = Parity.None;
                            break;

                        }
                    case "O":
                        {
                            puertoFat.Parity = Parity.Odd;
                            break;

                        }
                    case "S":
                        {
                            puertoFat.Parity = Parity.Space;
                            break;

                        }
                }
                #endregion
                currValue = aParametros[3]; //DataBits
                puertoFat.DataBits = System.Int32.Parse(currValue, currentCulture);

                #region StopBit
                currValue = aParametros[4]; //StopBits
                switch (currValue)
                {
                    case "N":
                        {
                            puertoFat.StopBits = StopBits.None;
                            break;

                        }
                    case "O":
                        {
                            puertoFat.StopBits = StopBits.One;
                            break;

                        }
                    case "OnePointFive":
                        {
                            puertoFat.StopBits = StopBits.OnePointFive;
                            break;

                        }
                    case "Two":
                        {
                            puertoFat.StopBits = StopBits.Two;
                            break;

                        }
                }
                #endregion

                currValue = aParametros[0]; //Número Puerto
                puertoFat.PortName = "COM" + currValue;
                //puertoFat.PortName = "USB" + currValue;
                puertoFat.DtrEnable = true;
                puertoFat.Handshake = Handshake.None;
                puertoFat.DiscardNull = true;
            }
            catch
            {
                throw;
            }
        }

        private void AbrirPuerto() {
            try
            {
                puertoFat.Open();
            }
            catch (Exception) {
                throw;
            }
        }

        public void CerrarPuerto() {
            try
            {
                puertoFat.Close();
            }
            catch (Exception) {
                throw;
            }
        }

        /*
        * Autor: Enrique Santana
        * Fecha de creación: 02/05/2012
        * Fecha de liberación: 04/06/2012
        * Descripción: Calcula el folio siguiente
        */

        private int CalcularFolio(DateTime fecha) {
            
            int cont = 0;
            CLSFolioCollection folioCollection;
            try
            {
                string fechaCadena = fecha.ToString("yyyy-MM-dd 00:00:00");
                string siguienteDia = fecha.AddDays(1).ToString("yyyy-MM-dd 00:00:00");
                string comando = " WHERE (FECHA >= CONVERT(DATETIME, '" + fechaCadena + "', 120)) " + 
                    "AND (WERKS = '" + codCentro + "') " +
                    "AND (FECHA <= CONVERT(DATETIME, '" + siguienteDia + "', 120))ORDER BY FOLIO ASC";
                folioCollection = new CLSFolioBAL().MostrarFolioBAL(comando);
                IEnumerator lista = folioCollection.GetEnumerator();

                while (lista.MoveNext())
                {
                    cont++;
                }

                if (cont >= 1)
                {
                    int folioQ = Convert.ToInt32(folioCollection[cont - 1].Folio) + 1;
                    return folioQ; 
                }

                return 1;
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
                return cont;
            }
        }

         /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Arroja error si la fecha es mayor a la actual
         */

        private void FechaMayor(DateTime hoy, string mError) {
            if (dtpFecha.Value > hoy)
            {
                mError = "La FECHA no puede ser posterior a la actual";
                throw new Exception(mError);
            }
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Valida que los campos se ingresen correctamente
         */

        private void Validaciones() {
            double neto, bruto, tara;
            DateTime hoy = DateTime.Now;
            string mError = "";
            bool loteLleno;

            FechaMayor(hoy, mError);
            RevisarFolio();
            mError = CambiarDestino();

            #region Vacios

            if (txtbxMusculo.Text == "")
            {
                mError = "Ingrese MUSCULO";
                txtbxMusculo.Select();
                txtbxMusculo.Focus();
                throw new Exception(mError);
            }

            if (txtbxGrasa.Text == "")
            {
                mError = "Ingrese GRASA";
                txtbxGrasa.Select();
                txtbxGrasa.Focus();
                throw new Exception(mError);
            }

            if (txtbxChuleta.Text == "")
            {
                mError = "Ingrese CHULETA";
                txtbxChuleta.Select();
                txtbxChuleta.Focus();
                throw new Exception(mError);
            }

            if (txtbxPesoBruto.Text == "")
            {
                mError = "Ingrese PESO";
                txtbxPesoBruto.Select();
                txtbxPesoBruto.Focus();
                throw new Exception(mError);
            }

            if (txtbxTara.Text == "")
            {
                mError = "Ingrese TARA";
                txtbxTara.Select();
                txtbxTara.Focus();
                throw new Exception(mError);
            }

            if (txtbxLote.Text == "")
            {
                mError = "Ingrese LOTE";
                txtbxLote.Select();
                txtbxLote.Focus();
                throw new Exception(mError);
            }

            if (txtbxFolio.Text == "")
            {
                mError = "Ingrese FOLIO";
                txtbxFolio.Select();
                txtbxFolio.Focus();
                throw new Exception(mError);
            }

            ObtenerProductos();

            if (txtbxMatCon.TextLength == 0) {
                mError = "No existe material para destino";
                txtbxDestino.Select();
                txtbxDestino.Focus();
                throw new Exception(mError);
            }

            #endregion

            try
            {
                neto = Convert.ToDouble(txtbxPesoNeto.Text);
                bruto = Convert.ToDouble(txtbxPesoBruto.Text);
                tara = Convert.ToDouble(txtbxTara.Text);
            }
            catch (Exception)
            {
                mError = "Peso invalido";
                txtbxPesoBruto.SelectAll();
                txtbxPesoBruto.Focus();
                throw new Exception(mError);
            }

            if(tara >= bruto) {
                txtbxPesoBruto.SelectAll();
                txtbxPesoBruto.Focus();
                throw new Exception("TARA debe ser menor que PESO");
            }

            neto = (bruto - tara);

            if(neto < 40.00) {
                txtbxPesoBruto.SelectAll();
                txtbxPesoBruto.Focus();
                throw new Exception("PESO NETO no puede ser inferior a 40 KG");
            }

            txtbxPesoNeto.Text = neto.ToString();

            try
            {
                ExisteLote();
                loteLleno = LlenarLote();

                if (loteLleno)
                {
                    if (txtbxDocRec.TextLength == 0)
                    {
                        throw new Exception("El lote no tiene DOC. RECEPCION");
                    }
                    if (txtbxTatProv.TextLength == 0)
                    {
                        throw new Exception("El lote no tiene TATUAJE");
                    }
                    if (txtbxPesoProm.TextLength == 0)
                    {
                        throw new Exception("El lote no tiene PESO PROMEDIO");
                    }
                    if (txtbxFechaLote.TextLength == 0)
                    {
                        throw new Exception("El lote no tiene FECHA");
                    }
                }
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 07/06/2012
         * Fecha de liberación: 08/06/2012
         * Descripción: Cuenta los canales por lote
         */

        private void contarFatom()
        {
            CLSFatomCollection cFat;
            string criterio = "WHERE (WERKS = '" + codCentro + "') ";
            criterio = criterio + "AND (CHARG = '" + txtbxLote.Text + "')";
            cFat = new CLSFatomBAL().MostrarFatomBAL(criterio);
            totalCerdos = cFat.Count;
            /*IEnumerator lista = cFat.GetEnumerator();
            totalCerdos = 0;
            while(lista.MoveNext())
            {

                CLSFatom leFatom = (CLSFatom)lista.Current;
                //totalKilos = totalKilos + leFatom.Erfmg;
                totalCerdos++;
            }*/
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 07/06/2012
         * Fecha de liberación: 08/06/2012
         * Descripción: Revisa si el numero de canales es mayor al solicitado
         */

        private void RevisarStockDisponible() 
        {
            contarFatom();
            CLSLoteCollection lcvs;
            string criterio = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
            criterio = criterio + "AND (CHARG = '" + txtbxLote.Text + "') ";
            lcvs = new CLSLoteBAL().MostrarLoteBAL(criterio);
            IEnumerator lista = lcvs.GetEnumerator();
            while(lista.MoveNext()) 
            {
                CLSLote lote = (CLSLote)lista.Current;
                deberiaCerdos = lote.CwmClabs;
                //deberiaKilos = lote.Clabs;
            }

            if(totalCerdos >= deberiaCerdos)
            {
                throw new Exception("Se ha llegado al limite del lote con: " + deberiaCerdos.ToString() + " cerdos");
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            CLSBasculas claseBascula = new CLSBasculas();
            claseBascula.ModeloBascula = modeloBascula;

            try
            {
                if (bascula)
                {
                    txtbxPesoBruto.Text = claseBascula.PuertoSerial();
                    //PuertoSerial();
                }
                //PuertoFatometer();
                RevisarStockDisponible();
                IngresaFatom();
                Validaciones();
                ObtenerCalidad();
                ObtenerOrden();
                EscribirFatom();
                LimpiarCampos();
                base.MostrarMensaje("Folio Grabado!");
                txtbxPesoBruto.Focus();
                txtbxPesoBruto.Select();
            }
            catch (Exception ex)
            {
                
                base.MostrarError(ex.Message);
            }
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Limpia campos cada registro
         */

        private void LimpiarCampos() {
            
            txtbxLote.Select();
            txtbxLote.Focus();
            txtbxFolio.Text = CalcularFolio(dtpFecha.Value.Date).ToString();
            txtbxPesoBruto.Text = "";
            txtbxPesoNeto.Text = "0.00";
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Ingresa registros en la tabla ZPPFATOM
         */

        private void EscribirFatom() {
            
            CLSFatom fatom = new CLSFatom();
            CLSFatomBAL fatomBAL = new CLSFatomBAL();

            #region Asignado de Variables
            fatom.Werks = txtbxCentro.Text;
            fatom.Fecha = dtpFecha.Value;
            fatom.Folio = Convert.ToInt16(txtbxFolio.Text);
            fatom.Charg = txtbxLote.Text;
            fatom.Erfmg = Convert.ToDouble(txtbxPesoNeto.Text);
            fatom.Erfme = "KG";
            fatom.Tara = Convert.ToDouble(txtbxTara.Text);
            fatom.Serie = txtbxDocRec.Text;
            fatom.Tatuaje = txtbxTatProv.Text;
            fatom.PesoProm = Convert.ToDouble(txtbxPesoProm.Text);
            fatom.Calidad = txtbxCalidad.Text;
            fatom.CodDestino = txtbxDestino.Text;
            fatom.Destino = lblDestino.Text;
            fatom.Musculo = Convert.ToDouble(txtbxMusculo.Text);
            fatom.Grasa = Convert.ToDouble(txtbxGrasa.Text);
            fatom.Chuleta = Convert.ToDouble(txtbxChuleta.Text);
            fatom.FechaLote = Convert.ToDateTime(txtbxFechaLote.Text);
            fatom.PesarCab = lblPesarCab.Text;
            fatom.PesoCab = 0.0;
            fatom.PesoSinCabeza = 0.0;
            fatom.Matnr = txtbxMatCon.Text;
            fatom.MatnrProd = txtbxMatProd.Text;
            fatom.Aufnr = txtbxOrdenesProd.Text;
            fatom.Procesado = Variables.Blanco;
            fatom.ChargProd = charg2;
            #endregion

            try
            {
                fatomBAL.AgregarFatomBAL(fatom);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo escribir en ZPPFATOM");
            }
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Consigue la OP si existe
         */

        private void ObtenerOrden() {

            txtbxOrdenesProd.Text = "";
            CLSOrdenProdCollection orden;
            string criterio = "";
            string lote = txtbxLote.Text;
            string matCons = txtbxMatCon.Text;
            string matProd = txtbxMatProd.Text;

            criterio = "WHERE (MATNR_COMP = '" + matCons + "') " ;
            criterio = criterio + "AND (MATNR = '" + matProd + "')";
            orden = new CLSOrdenProdBAL().MostrarOrdenProdBAL(criterio);
            IEnumerator lista = orden.GetEnumerator();
            
            while(lista.MoveNext()) {
                CLSOrdenProd ordenProd = (CLSOrdenProd)lista.Current; 
                //ClsResbCollection resb;
                /*string criterio2 = "WHERE (RSNUM = '" + "471729" + "') "; 
                criterio2 = criterio2 + "AND (MATNR = '" + matProd + "') ";
                criterio2 = criterio2 + "AND (BWART = '261')";
                resb = new ClsResbBAL().ConsultarResbBAL(criterio2);*/
                txtbxOrdenesProd.Text = ordenProd.Aufnr;
                charg2 = orden[0].Charg.ToString();
                
            }

            if(orden.Count == 0) {
                throw new Exception("No se encuentra Orden de Producción");
            }
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Calcula la calidad del registro
         */

        private void ObtenerCalidad() {

            string comando = "";
            txtbxCalidad.Text = "";
            bool correcto = false;
            CLSCalidad calidad = new CLSCalidad();
            CLSCalidadCollection calidadCol;

            try
            {
                if (lblDestino.Text.TrimStart().StartsWith("MARRANA"))
                {
                    txtbxCalidad.Text = "MARRANA";
                    correcto = true;
                    return;
                }

                #region Cadena
                comando = "WHERE (PESOINI <= " + txtbxPesoNeto.Text + ")";
                comando = comando + "AND (PESOFIN >= " + txtbxPesoNeto.Text + ")";
                comando = comando + "AND (MUSCULOINI <= " + txtbxMusculo.Text + ")";
                comando = comando + "AND (MUSCULOFIN >= " + txtbxMusculo.Text + ")";
                comando = comando + "AND (GRASAINI <= " + txtbxGrasa.Text + ")";
                comando = comando + "AND (GRASAFIN >= " + txtbxGrasa.Text + ")";
                comando = comando + "AND (CHULETAINI <= " + txtbxGrasa.Text + ")";
                comando = comando + "AND (CHULETAFIN >= " + txtbxGrasa.Text + ")";
                #endregion

                calidadCol = new CLSCalidadBAL().MostrarCalidadBAL(comando);
                IEnumerator lista = calidadCol.GetEnumerator();

                while (lista.MoveNext())
                {
                    txtbxCalidad.Text = calidadCol[0].Calidad.ToString();
                    correcto = true;
                }

                if (!correcto)
                {
                    txtbxCalidad.Text = "OTRO";
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Revisa que el folio no exista para el día en curso
         */

        private void RevisarFolio() {

            CLSFatomCollection fatomCol;
            string leFecha = dtpFecha.Value.ToString("yyyy-MM-dd 00:00:00");
            string leManana = dtpFecha.Value.AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            string criterio = "WHERE (FECHA >= CONVERT(DATETIME, '" + leFecha + "', 120)) ";
            criterio = criterio + "AND (FECHA <= CONVERT(DATETIME, '" + leManana + "', 120)) ";
            criterio = criterio + "AND (WERKS = '" + codCentro + "')";
            fatomCol = new CLSFatomBAL().MostrarFatomBAL(criterio);
            IEnumerator lista = fatomCol.GetEnumerator();
            while(lista.MoveNext()) {
                CLSFatom fatom = (CLSFatom)lista.Current;
                if(txtbxFolio.Text == fatom.Folio.ToString()) {
                    throw new Exception("El folio " + txtbxFolio.Text + " ya se encuentra grabado para la fecha actual!");
                }
            }

            if (fatomCol.Count > 1)
            {
                if (Convert.ToInt16(txtbxFolio.Text) <= 0)
                {
                    int i = fatomCol.Count - 1;
                    txtbxFolio.Text = (fatomCol[i].Folio + 1).ToString();
                }
            }
            else
            {
                if (Convert.ToInt16(txtbxFolio.Text) <= 0)
                {
                    txtbxFolio.Text = "1";
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtbxFolio_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxFolio);
        }

        private void txtbxFolio_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxFolio);
            try
            {
                RevisarFolio();
            }
            catch (Exception ex)
            {
                
                base.MostrarError(ex.Message);
            }
        }

        private void txtbxMusculo_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxMusculo);
        }

        private void txtbxMusculo_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxMusculo);
        }

        private void txtbxGrasa_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxGrasa);
        }

        private void txtbxGrasa_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxGrasa);
        }

        private void txtbxChuleta_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxChuleta);
        }

        private void txtbxChuleta_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxChuleta);
        }

        private void txtbxPesoBruto_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxPesoBruto);
        }

        private void txtbxPesoBruto_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxPesoBruto);
        }

        private void txtbxTara_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxTara);
        }

        private void txtbxTara_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxTara);
        }

        private void txtbxDestino_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxDestino);
        }

        private void txtbxDestino_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxDestino);
            if (txtbxDestino.TextLength == 0)
            {
                base.MostrarError("Ingresar Destino"); 
            }
            //ObtenerProductos();
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Obtiene el numero de material componente, de produccion y si lleva pesado de cabeza
         */

        private void ObtenerProductos() {
            CLSCatDestinoCollection destinos;
            string criterio = "WHERE (CODDESTINO = '" + txtbxDestino.Text + "') ";
            criterio = criterio + "AND (PESOINI < '" + txtbxPesoBruto.Text + "') ";
            criterio = criterio + "AND (WERKS = '" + codCentro + "') ";
            criterio = criterio + "ORDER BY CODDESTINO, PESOINI DESC";
            destinos = new CLSCatDestinoBAL().MostrarCatDestinoBAL(criterio);
            txtbxMatCon.Text = destinos[0].MatnrComp.ToString();
            txtbxMatProd.Text = destinos[0].MatnrProd.ToString();
            lblPesarCab.Text = destinos[0].PesarCab.ToString();
        }

        private void txtbxLote_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxLote);
        }

        private void txtbxLote_Leave(object sender, EventArgs e)
        {

            //bool loteLleno = false;

            if (txtbxLote.Text != "")
            {
                while (txtbxLote.TextLength < txtbxLote.MaxLength)
                {
                    txtbxLote.Text = "0" + txtbxLote.Text;
                }
            }
            else 
            {
                base.MostrarError("Ingrese LOTE");
            }
            base.TextoColorEdicionOff(txtbxLote);
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Verifica que exista el lote
         */

        private void ExisteLote() {
            bool correcto = false;
            CLSLote lote = new CLSLote();
            CLSLoteCollection lotes;
            string criterio = "WHERE (MATNR = '" + txtbxMatCon.Text + "') ";
            criterio = criterio + "AND (CHARG = '" + txtbxLote.Text + "')";
            lotes = new CLSLoteBAL().MostrarLoteBAL(criterio);
            IEnumerator lista = lotes.GetEnumerator();
            while(lista.MoveNext()) 
            {
                lote = (CLSLote)lista.Current;
                if(txtbxLote.Text == lote.Lote)
                {
                    correcto = true;
                }
            }
            if(!correcto) {
                throw new Exception("El lote: " + txtbxLote.Text + " no existe para el material: " + txtbxMatCon.Text);
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            base.MensajeApagar();
            string error = "";
            DateTime hoy = DateTime.Now;

            try
            {
                FechaMayor(hoy, error);
                txtbxFolio.Text = CalcularFolio(dtpFecha.Value).ToString();
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }

        private void txtbxLote_TextChanged(object sender, EventArgs e)
        {
            base.MensajeApagar();
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Llena la información del lote
         */

        private bool LlenarLote() {

            string comando = "WHERE (WERKS = '" + codCentro + "') AND (CHARG = '" + txtbxLote.Text + "')"; 
            CLSLoteCollection loteColeccion = new CLSLoteBAL().MostrarLoteBAL(comando);
            IEnumerator lista = loteColeccion.GetEnumerator();
            try
            {
                txtbxDocRec.Text = loteColeccion[0].Remision.ToString();
                txtbxTatProv.Text = loteColeccion[0].Tatuaje.ToString();
                txtbxPesoProm.Text = loteColeccion[0].PesoProm.ToString();
                txtbxFechaLote.Text = loteColeccion[0].Fecha.Substring(0,10);
                return true;
            }
            catch (Exception)
            {
                txtbxDocRec.Text = Variables.Blanco;
                txtbxTatProv.Text = Variables.Blanco;
                txtbxPesoProm.Text = Variables.Blanco;
                txtbxFechaLote.Text = Variables.Blanco;
                throw new Exception("No existe el Lote para ese Material");
            }
        }

        private void txtbxDestino_TextChanged(object sender, EventArgs e)
        {
            try
            {
                base.MensajeApagar();
                lblDestino.Text = CambiarDestino();
            }
            catch (Exception ex)
            {
                
                base.MostrarError(ex.Message);
            }
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Verifica que exista el destino
         */

        private string CambiarDestino() {
            CLSCatDestinoCollection destino;
            destino = new CLSCatDestinoBAL().MostrarCatDestinoBAL("");
            IEnumerator lista = destino.GetEnumerator();
            int i = 0;

            while(lista.MoveNext()) {
                
                if(txtbxDestino.Text == destino[i].CodDestino.ToString()) {
                    /*txtbxMatCon.Text = destino[i].MatnrComp;
                    txtbxMatProd.Text = destino[i].MatnrProd;
                    lblPesarCab.Text = destino[i].PesarCab;*/
                    return destino[i].DescDestino;
                }
                if(txtbxDestino.Text == "") {
                    return " ";
                }
                ObtenerOrden();
                i++;
            }
            throw new Exception("No existe Destino");
        }

        private void txtbxTara_TextChanged(object sender, EventArgs e)
        {
            base.MensajeApagar();
        }

        /*private void FrmZPPG01Captura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter) 
            {
                CLSBasculas claseBascula = new CLSBasculas();
                claseBascula.ModeloBascula = modeloBascula;

                try
                {
                    if (bascula)
                    {
                        txtbxPesoBruto.Text = claseBascula.PuertoSerial();
                        //PuertoSerial();
                    }
                    Validaciones();
                }
                catch (Exception ex)
                {
                    base.MostrarError(ex.Message);
                }
                btnGrabar.Focus();
                
            }
            if (e.KeyChar == (char)Keys.F8) 
            {
                if (bascula)
                {
                    PuertoSerial(); 
                }
                btnGrabar_Click(sender, e);
            }
        }*/

        private void btnSalir_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Dispose();
        }

        private void txtbxMusculo_TextChanged(object sender, EventArgs e)
        {
            if(txtbxMusculo.TextLength == 3) {
                txtbxMusculo.AppendText(".");
            }
        }

        private void txtbxGrasa_TextChanged(object sender, EventArgs e)
        {
            if(txtbxGrasa.TextLength == 3) {
                txtbxGrasa.AppendText(".");
            }
        }

        private void txtbxChuleta_TextChanged(object sender, EventArgs e)
        {
            if(txtbxChuleta.TextLength == 3) {
                txtbxChuleta.AppendText(".");
            }
        }

        private void txtbxPesoBruto_TextChanged(object sender, EventArgs e)
        {
            base.MensajeApagar();
        }

        private void txtbxFolio_TextChanged(object sender, EventArgs e)
        {
            base.MensajeApagar();
        }

        private void FrmZPPG01Captura_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CLSBasculas claseBascula = new CLSBasculas();
                claseBascula.ModeloBascula = modeloBascula;

                try
                {
                    if (bascula)
                    {
                        txtbxPesoBruto.Text = claseBascula.PuertoSerial();
                        //PuertoSerial();
                    }
                    IngresaFatom();
                    //PuertoFatometer();
                    Validaciones();
                }
                catch (Exception ex)
                {
                    base.MostrarError(ex.Message);
                }
                btnGrabar.Focus();
            }

            if (e.KeyCode == Keys.F8) 
            {
                CLSBasculas claseBascula = new CLSBasculas();
                claseBascula.ModeloBascula = modeloBascula;
                claseBascula.CodFatom = puertoFatom + settingFatom;
                try
                {
                    if (bascula)
                    {
                        txtbxPesoBruto.Text = claseBascula.PuertoSerial();
                        //PuertoSerial();
                    }
                    btnGrabar_Click(sender, e);
                }
                catch (Exception ex)
                {
                    base.MostrarError(ex.Message);
                }
            }
        }

        private void puertoFat_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            base.MensajeApagar();
            inData = puertoFat.ReadLine();
            //base.MostrarMensaje("Mensaje recibido!!!");
        }
    }
}