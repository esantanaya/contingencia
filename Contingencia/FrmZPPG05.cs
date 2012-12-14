using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Globalization;

namespace Contingencia
{
    public partial class FrmZPPG05 : FrmBase
    {
        static CultureInfo currentCulture = CultureInfo.CurrentCulture;

        private SerialPort puertoS = new SerialPort();
        bool primeraPesada = false;
        //bool presionaEnter = false;

        private string matnrProd;
        private string desensamble;
        private string venta;

        private string centro;
        public string Centro
        {
            get { return centro; }
            set { centro = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string bascula;
        public string Bascula
        {
            get { return bascula; }
            set { bascula = value; }
        }

        public FrmZPPG05()
        {
            InitializeComponent();
        }

        public void IniciarForma() {
            txtbxCentro.Text = centro;
            lblDescCentro.Text = descripcion;
            if (bascula != "MANUAL") 
            { 
                txtbxKilos1.ReadOnly = true;
                txtbxKilos2.ReadOnly = true;
            }
        }

        private void ZPPG05_Load(object sender, EventArgs e)
        {
            base.PonerTitulo("Pesado de Canales a Cortes");
            dtpFecha.Value = DateTime.Now;
            base.TextoColorEdicionOff(txtbxNeto2);
            txtbxNeto2.ReadOnly = true;
            txtbxFolio.Select();
            txtbxFolio.Focus();
        }

        private void txtbxDestino_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxDestino);
        }

        private void txtbxDestino_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxDestino);
        }

        private void txtbxFolio_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxFolio);
        }

        private void txtbxFolio_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxFolio);
        }

        private void txtbxTipoPesaje_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxTipoPesaje);
        }

        private void txtbxTipoPesaje_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxTipoPesaje);
        }

        private void txtbxKilos1_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxKilos1);
          
        }

        private void txtbxKilos1_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxKilos1);
        }

        private void txtbxTara1_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxTara1);
        }

        private void txtbxTara1_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxTara1);
        }

        private void txtbxNeto1_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxNeto1);
        }

        private void txtbxNeto1_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxNeto1);
        }

        private void txtbxKilos2_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxKilos2);
        }

        private void txtbxKilos2_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxKilos2);
        }

        private void txtbxTara2_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxTara2);
        }

        private void txtbxTara2_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxTara2);
        }

        private void txtbxNeto2_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxNeto2);
        }

        private void txtbxNeto2_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxNeto2);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void LimpiarCampos() {
            txtbxDestino.Clear();
            txtbxDescDestino.Clear();
            txtbxAlmacen.Clear();
            txtbxTatuaje.Clear();
            txtbxTipoPesaje.Clear();
            txtbxOrdenProceso.Clear();
            txtbxEntrega.Clear();
            txtbxKilos1.Clear();
            txtbxTara1.Clear();
            txtbxNeto1.Text = "0.0";
            txtbxKilos2.Clear();
            txtbxTara2.Clear();
            txtbxNeto2.Text = "0.0";
        }

        private CLSFatomCollection RevisarFolioExistente() 
        {
            CLSFatomCollection fatCol;
            string fecha = dtpFecha.Value.ToString("yyyy-MM-dd 00:00:00");
            string diaSiguiente = dtpFecha.Value.AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            string criterio = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
            criterio = criterio + "AND (FECHA >= CONVERT(DATETIME, '" + fecha + "', 120)) ";
            criterio = criterio + "AND (FECHA <= CONVERT(DATETIME, '" + diaSiguiente + "', 120)) ";
            criterio = criterio + "AND (FOLIO = '" + txtbxFolio.Text + "')";
            fatCol = new CLSFatomBAL().MostrarFatomBAL(criterio);

            return fatCol;
            
        }

        private CLSFatom Validar()
        {

            base.MensajeApagar();

            if (txtbxCentro.Text == "0R20")
            {
                if (txtbxFolio.TextLength == 0)
                {
                    throw new Exception("Ingresa un folio!");
                }
                /*if (txtbxDestino.TextLength == 0)
                {
                    throw new Exception("Ingresa un destino!");
                }*/
            }
            else
            {
                if (txtbxFolio.Text == "")
                {
                    throw new Exception("Complete todos los campos obligatorios");
                }
            }

            string fecha = dtpFecha.Value.ToString("yyyy-MM-dd 00:00:00");
            string diaSiguiente = dtpFecha.Value.AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            
            //Se obtiene la fatom con centro, fecha y folio

            CLSFatomCollection fatCol = RevisarFolioExistente();

            if (txtbxCentro.Text != "0R20")
            {
                if (fatCol.Count == 0)
                {
                    throw new Exception("El folio no existe en la fecha");
                }
            }
            else
            {
                
                CLSCatDestinoCollection destinosCol = GrabarDestino();

                if (fatCol.Count == 0)
                {
                    if (MessageBox.Show(MostrarMensaje(), "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (txtbxDestino.TextLength == 0)
                        {
                            throw new Exception("Ingresa un destino!");
                        }
                        CLSFatom fatometer = new CLSFatom();
                        bool tmpDestinoCorrecto = false;
                        fatometer.Werks = txtbxCentro.Text;
                        fatometer.Fecha = dtpFecha.Value;
                        fatometer.Folio = Convert.ToInt32(txtbxFolio.Text);
                        fatometer.CodDestino = txtbxDestino.Text;
                        IEnumerator lista = destinosCol.GetEnumerator();
                        while (lista.MoveNext())
                        {
                            CLSCatDestino destino = (CLSCatDestino)lista.Current;
                            if (txtbxDestino.Text == destino.CodDestino)
                            {
                                fatometer.Matnr = destino.MatnrComp;
                                fatometer.MatnrProd = destino.MatnrProd;
                                fatometer.MatnrMaq = destino.MatnrMaq;
                                tmpDestinoCorrecto = true;
                            }
                        }
                        if (!tmpDestinoCorrecto)
                        {
                            throw new Exception("El código de destino no existe para este centro");
                        }
                        fatometer = ObtenerLote0R20(fatometer);
                        CLSFatomBAL fatBal = new CLSFatomBAL();
                        fatBal.AgregarFatom0R20BAL(fatometer);
                        fatCol = RevisarFolioExistente();
                        //Validaciones();
                    }
                    else
                    {
                        throw new Exception("El folio no existe en la fecha");
                    }
                }
            }

            if (fatCol[0].Werks != txtbxCentro.Text)
            {
                string mensajeError = "Folio pertenece al centro: " + fatCol[0].Werks;
                throw new Exception(mensajeError);
            }

            matnrProd = fatCol[0].MatnrProd.ToString();
            txtbxDestino.Text = fatCol[0].CodDestino.ToString();
            txtbxTatuaje.Text = fatCol[0].Tatuaje.ToString();
            txtbxTipoPesaje.Text = "";

            //if (txtbxDestino.TextLength == 0)
            //{
            //    txtbxDescDestino.Text = fatCol[0].Destino.ToString();
            //}
            //else
            //{
            //    ActualizarFatom();
            //}

            /*if (fatCol[0].Procesado == " " || fatCol[0].Procesado == "" )
            {
                base.MostrarAdvertencia("Folio aún no procesado en 2da. estación");
            }

            if ((fatCol[0].EstadoMaq == " " || fatCol[0].EstadoMaq == "") && txtbxCentro.Text == "0R20")
            {
                throw new Exception("Folio aún no procesado en recepción de maquila");
            }*/

            if (fatCol[0].Kg1 > 0)
            {
                throw new Exception("Folio ya pesado en esta estación");
            }

            if (fatCol[0].ChargProd == "" || fatCol[0].MatnrProd == "" || fatCol[0].ChargProd == " " || fatCol[0].MatnrProd == " ")
            {
                throw new Exception("Tabla ZPPFATOM incompleta. No se puede procesar el folio");
            }

            matnrProd = fatCol[0].MatnrProd.ToString();
            txtbxDescDestino.Text = fatCol[0].Destino.ToString();
            txtbxTatuaje.Text = fatCol[0].Tatuaje.ToString();

            //Obtener Almacen

            CLSLoteCollection lcvs;
            string where = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
            where = where + "AND (CHARG = '" + fatCol[0].ChargProd + "') ";
            where = where + "AND (MATNR = '" + fatCol[0].MatnrProd + "')";
            lcvs = new CLSLoteBAL().MostrarLoteBAL(where);
            if (lcvs.Count > 0)
            {
                txtbxAlmacen.Text = lcvs[0].Almacen.ToString();
            }
            else
            {
                txtbxAlmacen.Text = "";
            }

            //lv_estatusCorte = 'Procesados' 

            string codDestino = fatCol[0].CodDestino.ToString();
            string fechaFolio = fatCol[0].Fecha.ToString("yyyy-MM-dd 00:00:00");

            if (txtbxTipoPesaje.Text == "" || txtbxTipoPesaje.Text == " ")
            {
                ObtenerTipoPesaje(codDestino);
                if (txtbxTipoPesaje.Text == "" || txtbxTipoPesaje.Text == " ")
                {
                    txtbxTipoPesaje.Select();
                    txtbxTipoPesaje.Focus();
                    throw new Exception("Ingrese Tipo de Pesaje!");
                }
            }

            //
            CLSCanalFinCollection canal;
            CLSCanalFin canalfin;
            string criterioCanal = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
            criterioCanal = criterioCanal + "AND (CODDESTINO = '" + codDestino + "') ";
            criterioCanal = criterioCanal + "AND (DESCRIP = '" + txtbxTipoPesaje.Text + "')";
            canal = new CLSCanalFinBAL().MostrarCanalBAL(criterioCanal);
            canalfin = canal[0];

            if (canal.Count <= 0) { throw new Exception("Tipo de Pesaje inexistente"); }

            CLSFatomBAL fatomAgrega = new CLSFatomBAL();
            CLSFatom fatom = new CLSFatom();
            DateTime diaSiguiente1 = Convert.ToDateTime(fecha).AddDays(1);

            string criterioFatom = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
            criterioFatom = criterioFatom + "AND (FOLIO = '" + txtbxFolio.Text + "') ";
            criterioFatom = criterioFatom + "AND (FECHA >= CONVERT(DATETIME, '" + fecha + "', 120))";
            criterioFatom = criterioFatom + "AND (FECHA <= CONVERT(DATETIME, '" + diaSiguiente1.ToString("yyyy-MM-dd 00:00:00") + "', 120))";

            try
            {
                fatom.MatnrProd2 = canalfin.Matnr;
                fatom.MatnrProd2Virt = canalfin.MatnrVirt;
                fatom.OrdenProp = canalfin.OrdenProp;
                fatom.CodDestino = txtbxDestino.Text;
                desensamble = canalfin.Desensamble;
                fatom.Calidad = fatCol[0].Calidad;
                venta = canalfin.ICanaVenta;
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                fatomAgrega.ActualizarMaterialesBAL(fatom, criterioFatom);
                fatCol = RevisarFolioExistente();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            if (venta == "X")
            {
                CLSTraspCalidadCollection traspCalidadCol;
                string criterio2 = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
                criterio2 = criterio2 + "AND (CODDESTINO = '" + codDestino + "') ";
                criterio2 = criterio2 + "AND (CALIDAD = '" + fatom.Calidad + "')";
                traspCalidadCol = new CLSTraspCalidadBAL().MostrarTraspCalidadBAL(criterio2);
                if (traspCalidadCol.Count <= 0)
                {
                    txtbxTipoPesaje.Select();
                    txtbxTipoPesaje.Focus();
                    throw new Exception("No existe material de venta vs destino");
                }
                fatom.MatnrProd2Virt = traspCalidadCol[0].MatnrConv;
                fatomAgrega.ActualizarProductoVirt2BAL(fatom, criterioFatom);
                fatCol = RevisarFolioExistente();
                
                txtbxEntrega.ReadOnly = false;
                txtbxEntrega.TabStop = true;
                string entrega = txtbxEntrega.Text;

                while (entrega.Length < 10)
                {
                    entrega = "0" + entrega;
                }

                CLSLipsCollection lipsCol;
                string criterio3 = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
                criterio3 = criterio3 + "AND (VBELN = '" + entrega + "') ";
                criterio3 = criterio3 + "AND (MATNR = '" + fatom.MatnrProd2Virt + "')";
                lipsCol = new CLSLipsBAL().ConsultarLipsCollectionBAL(criterio3);
                
                if(lipsCol.Count == 0)
                {
                    txtbxEntrega.Select();
                    txtbxEntrega.Focus();
                    throw new Exception("No se encontró la entrega");
                }

                fatom.Vbeln = lipsCol[0].Entrega;

                fatomAgrega.ActualizarEntregaBAL(fatom, criterioFatom);
            }
            //

            //ObtnerMatProd(codDestino, fechaFolio);
            fatCol = RevisarFolioExistente();
            ObtenerOrden(fatCol[0].CodDestino.ToString(), fatCol[0].MatnrProd.ToString(), fatCol[0].MatnrProd2.ToString(), criterioFatom);
            ObtenerOrdenVirtual(fatCol[0].MatnrProd2Virt.ToString(), fatom.MatnrProd2.ToString(), criterioFatom);

            //Obtener primera pesada

            double neto1 = 0.0;
            double neto2 = 0.0;
            double dif = 0.0;

            if (txtbxKilos1.TextLength == 0 || desensamble == "X")
            {
                PuertoSerial(true);
                //txtbxKilos1.Text = "100";
                primeraPesada = true;
                pnlPrimPes2.Visible = false;
            }

            if(txtbxKilos1.TextLength == 0) 
            {
                txtbxKilos1.Select();
                txtbxKilos1.Focus();
                throw new Exception("Ingrese KILOS 1ra. PESADA");
            }

            if(txtbxTara1.TextLength == 0)
            {
                txtbxTara1.Text = "0.0";
            }

            double kilos1 = Convert.ToDouble(txtbxKilos1.Text);
            double tara1 = Convert.ToDouble(txtbxTara1.Text);

            if(kilos1 <= tara1) 
            {
                txtbxKilos1.Select();
                txtbxKilos1.Focus();
                throw new Exception("KILOS 1ra. PESADA debe ser mayor a la tara");
            }

            neto1 = kilos1 - tara1;
            txtbxNeto1.Text = neto1.ToString();
            fatom.Kg1 = neto1;

            dif = Convert.ToDouble(fatCol[0].Erfmg) - Convert.ToDouble(fatCol[0].PesoCab) - neto1;
            if (dif <= 0)
            {
                if (MessageBox.Show("¿Peso Canal Fría es Mayor que Peso Canal Caliente: " + dif.ToString() + ", desea continuar?",     
                    "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (desensamble == " "  || desensamble == "")
                    {
                        pnlPrimPes2.Visible = true;
                        //txtbxKilos2.Text = "90";
                        if (primeraPesada) { PuertoSerial(false); }
                        if (txtbxKilos2.Text == " " || txtbxKilos2.Text == "")
                        {
                            txtbxKilos2.Select();
                            txtbxKilos2.Focus();
                            throw new Exception("Ingrese KILOS 2da. PESADA");
                        }
                        if(txtbxTara2.TextLength == 0)
                        {
                            txtbxTara2.Text = "0.0";
                        }
                    }
                    else
                    {
                        if (txtbxKilos2.TextLength != 0)
                        {
                            txtbxKilos2.Select();
                            txtbxKilos2.Focus();
                            throw new Exception("No se admiten KILOS 2da. PESADA");
                        }
                    }
                    if (desensamble == " " || desensamble == "")
                    {
                        pnlPrimPes2.Visible = true;
                        double kilos2 = Convert.ToDouble(txtbxKilos2.Text);
                        double tara2 = Convert.ToDouble(txtbxTara2.Text);

                        if (kilos2 <= tara2)
                        {
                            txtbxKilos2.Select();
                            txtbxKilos2.Focus();
                            throw new Exception("KILOS 2da. PESADA debe ser mayor a la tara");
                        }
                        neto2 = kilos2 - tara2;
                        txtbxNeto2.Text = neto2.ToString();
                        fatom.Kg2 = neto2;
                    }
                    else
                    {
                        txtbxNeto2.Clear();
                    }
                    if (neto2 > neto1)
                    {
                        txtbxKilos2.Select();
                        txtbxKilos2.Focus();
                        throw new Exception("KILOS 2da. PESADA NO puede ser mayor a KILOS 1ra. PESADA");
                    }
                }
                else
                {
                    txtbxKilos1.Select();
                    txtbxKilos1.Focus();
                    throw new Exception("El peso de canal frio es mayor que el peso de canal caliente!");
                }
            }
            else
            {
                if (desensamble == " " || desensamble == "")
                {
                    pnlPrimPes2.Visible = true;
                    if (primeraPesada) { PuertoSerial(false); }
                    if (txtbxKilos2.Text == " " || txtbxKilos2.Text == "")
                    {
                        txtbxKilos2.Select();
                        txtbxKilos2.Focus();
                        throw new Exception("Ingrese KILOS 2da. PESADA");
                    }
                    if (txtbxTara2.TextLength == 0)
                    {
                        txtbxTara2.Text = "0.0";
                    }
                }
                else
                {
                    if (txtbxKilos2.TextLength != 0)
                    {
                        txtbxKilos2.Select();
                        txtbxKilos2.Focus();
                        throw new Exception("No se admiten KILOS 2da. PESADA");
                    }
                }
                if (desensamble == " " || desensamble == "")
                {
                    pnlPrimPes2.Visible = true;
                    double kilos2 = Convert.ToDouble(txtbxKilos2.Text);
                    double tara2 = Convert.ToDouble(txtbxTara2.Text);

                    if (kilos2 <= tara2)
                    {
                        txtbxKilos2.Select();
                        txtbxKilos2.Focus();
                        throw new Exception("KILOS 2da. PESADA debe ser mayor a la tara");
                    }
                    neto2 = kilos2 - tara2;
                    txtbxNeto2.Text = neto2.ToString();
                    fatom.Kg2 = neto2;
                }
                else
                {
                    txtbxNeto2.Clear();
                }
                if (neto2 > neto1)
                {
                    txtbxKilos2.Select();
                    txtbxKilos2.Focus();
                    throw new Exception("KILOS 2da. PESADA NO puede ser mayor a KILOS 1ra. PESADA");
                }
            }
            
            return fatom;
        }

        private void IncrementarCampos()
        {
            
            double tmpKilosProc = Convert.ToDouble(txtbxKilosProc.Text);
            double tmpKilos1 = Convert.ToDouble(txtbxKilos1.Text);
            double tmpKilos2 = 0.0;
            if(txtbxKilos2.TextLength != 0) 
            {
                tmpKilos2 = Convert.ToDouble(txtbxKilos2.Text);
            }

            try
            {
                txtbxCanalesProc.Text = (Convert.ToInt32(txtbxCanalesProc.Text) + 1).ToString();
                txtbxKilosProc.Text = (tmpKilosProc + tmpKilos1 + tmpKilos2).ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Grabar(CLSFatom fatom)
        {
            string fecha = dtpFecha.Value.ToString("yyyy-MM-dd 00:00:00");
            DateTime diaSiguiente1 = dtpFecha.Value.AddDays(1);
            CLSFatomBAL Graba = new CLSFatomBAL();

            string criterioFatom = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
            criterioFatom = criterioFatom + "AND (FOLIO = '" + txtbxFolio.Text + "') ";
            criterioFatom = criterioFatom + "AND (FECHA >= CONVERT(DATETIME, '" + fecha + "', 120))";
            criterioFatom = criterioFatom + "AND (FECHA <= CONVERT(DATETIME, '" + diaSiguiente1.ToString("yyyy-MM-dd 00:00:00") + "', 120))";

            Graba.ActualizarPesosBAL(fatom, criterioFatom);
        }

        private void ObtenerOrdenVirtual(string matnrProd2Virt, string matnrProd2, string criterioFatom) 
        { 
            CLSOrdenProdCollection ordenP;
            string criterio = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
            criterio = criterio + "AND (MATNR = '" + matnrProd2Virt + "') ";
            criterio = criterio + "AND (MATNR_COMP = '" + matnrProd2 + "')";

            ordenP = new CLSOrdenProdBAL().MostrarOrdenProdBAL(criterio);
            IEnumerator lista = ordenP.GetEnumerator();

            if (ordenP.Count == 0)
            {
                throw new Exception("No se encuentra Orden de Proceso para canal virtual");
            }
        

            CLSFatom fatom = new CLSFatom();
            CLSFatomBAL ordenFat = new CLSFatomBAL();
            
            fatom.MatnrMaq = ordenP[0].MatnrComp.ToString();
        
            fatom.Aufnr2Virt = ordenP[0].Aufnr.ToString();
            fatom.ChargProd2Virt = ordenP[0].Charg.ToString();
            ordenFat.ActualizarOrdenesVirtBAL(fatom, criterioFatom);
        }        

        private void ObtnerMatProd(string codDestino, string fecha) {
            CLSCanalFinCollection canal;
            CLSCanalFin canalfin;
            string criterio = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
            criterio = criterio + "AND (CODDESTINO = '" + codDestino + "') ";
            criterio = criterio + "AND (DESCRIP = '" + txtbxDescDestino.Text + "')";
            canal = new CLSCanalFinBAL().MostrarCanalBAL(criterio);
            canalfin = canal[0];

            if (canal.Count <= 0) { throw new Exception("Tipo de Pesaje inexistente"); }

            CLSFatomBAL fatomAgrega = new CLSFatomBAL();
            CLSFatom fatom = new CLSFatom();
            DateTime diaSiguiente = Convert.ToDateTime(fecha).AddDays(1);

            string criterioFatom = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
            criterioFatom = criterioFatom + "AND (FOLIO = '" + txtbxFolio.Text + "') ";
            criterioFatom = criterioFatom + "AND (FECHA >= CONVERT(DATETIME, '" + fecha + "', 120))";
            criterioFatom = criterioFatom + "AND (FECHA <= CONVERT(DATETIME, '" + diaSiguiente.ToString("yyyy-MM-dd 00:00:00") + "', 120))";

            try
            {
                fatom.MatnrProd2 = canalfin.Matnr;
                fatom.MatnrProd2Virt = canalfin.MatnrVirt;
                fatom.OrdenProp = canalfin.OrdenProp;
                desensamble = canalfin.Desensamble;
                venta = canalfin.ICanaVenta;
            }
            catch (Exception)
            {
                
                throw;
            }

            try
            {
                fatomAgrega.ActualizarMaterialesBAL(fatom, criterioFatom);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }

            if (venta == "X") 
            {
                CLSTraspCalidadCollection traspCalidadCol;
                string criterio2 = "WHERE (WERKS = '" + fatom.Werks + "') ";
                criterio2 = criterio2 + "AND (CODDESTINO = '" + codDestino + "') ";
                criterio2 = criterio2 + "AND (CALIDAD = '" + fatom.Calidad + "')";
                traspCalidadCol = new CLSTraspCalidadBAL().MostrarTraspCalidadBAL(criterio2);
                fatom.MatnrProd2Virt = traspCalidadCol[0].MatnrConv;
                fatomAgrega.ActualizarProductoVirt2BAL(fatom, criterioFatom);

                    if(traspCalidadCol.Count <= 0) 
                    {
                        txtbxTipoPesaje.Select();
                        txtbxTipoPesaje.Focus();
                        throw new Exception("No existe material de venta vs destino");
                    }
             }
        }

        private string ObtenerMatMaq(string codDestinoM) 
        {
            CLSCatDestinoCollection destinoCol;
            string criterio = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
            criterio = criterio + "AND (CODDESTINO = '" + codDestinoM + "')";
            destinoCol = new CLSCatDestinoBAL().MostrarCatDestinoBAL(criterio);
            if (destinoCol.Count > 0)
	        {
                return destinoCol[0].MatnrMaq;
	        }
            return "";
        }

        private CLSFatom ObtenerLote0R20(CLSFatom fatom)
        {
            CLSOrdenProdCollection ordenM;
            string criterio = "WHERE (MATNR_COMP = '" + fatom.Matnr + "') ";
            criterio = criterio + "AND (WERKS = '" + txtbxCentro.Text + "') ";
            criterio = criterio + "AND (MATNR = '" + fatom.MatnrProd + "') ";
            ordenM = new CLSOrdenProdBAL().MostrarOrdenProdBAL(criterio);
            fatom.ChargProd = ordenM[0].Charg;
            fatom.Aufnr = ordenM[0].Aufnr;
            return fatom;
        }

        private void ObtenerOrden(string codDestino, string matnrProd, string matnrProd2, string criterioFatom) 
        {
            CLSOrdenProdCollection ordenP;
            bool bandera = false;

            if (txtbxCentro.Text == "0R20")
            {

                string matnrMaq = ObtenerMatMaq(codDestino);
                
                string criterio = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
                criterio = criterio + "AND (MATNR_COMP = '" + matnrMaq + "') "; //*********************Revisar con Alejandro Mendez!!!!!!!! ¡¡¡¡¡¡¡¡¡¡¡¡¡¡
                //criterio = criterio + "AND (MATNR_COMP = '" + matnr + "') "; 
                criterio = criterio + "AND (MATNR = '" + matnrProd2 + "')";

                ordenP = new CLSOrdenProdBAL().MostrarOrdenProdBAL(criterio);
                IEnumerator lista = ordenP.GetEnumerator();

                while (lista.MoveNext())
                {
                    txtbxOrdenProceso.Text = ordenP[0].Aufnr.ToString();
                    bandera = true;
                }

                if (ordenP.Count == 0)
                {
                    throw new Exception("No se encuentra Orden de Proceso para canal frío");
                }
            }
            else
            {
                
                //CLSOrdenProdCollection ordenP;
                string criterio = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
                criterio = criterio + "AND (MATNR_COMP = '" + matnrProd + "') "; 
                criterio = criterio + "AND (MATNR = '" + matnrProd2 + "')";

                ordenP = new CLSOrdenProdBAL().MostrarOrdenProdBAL(criterio);
                IEnumerator lista = ordenP.GetEnumerator();

                while (lista.MoveNext())
                {
                    txtbxOrdenProceso.Text = ordenP[0].Aufnr.ToString();
                    bandera = false;
                }

                if (ordenP.Count == 0)
                {
                    throw new Exception("No se encuentra Orden de Proceso para canal frío");
                }
            }

            CLSFatom fatom = new CLSFatom();
            CLSFatomBAL ordenFat = new CLSFatomBAL();
            if (bandera)
            {
                fatom.MatnrMaq = ordenP[0].MatnrComp.ToString();
            }
            else
            {
                fatom.MatnrMaq = "";
            }
            fatom.Aufnr2 = ordenP[0].Aufnr.ToString();
            fatom.ChargProd2 = ordenP[0].Charg.ToString();
            ordenFat.ActualizarOrdenesBAL(fatom, criterioFatom);
        }

        private void ObtenerTipoPesaje(string codDestino) {
            
            CLSCanalFinCollection canal;
            /*CLSFatomBAL fatomAgrega = new CLSFatomBAL();
            CLSFatom fatom = new CLSFatom();*/
            string criterio = "WHERE (WERKS = '" + txtbxCentro.Text + "') ";
            criterio = criterio + "AND (CODDESTINO = '" + codDestino + "')";
            
            canal = new CLSCanalFinBAL().MostrarCanalBAL(criterio);
            txtbxTipoPesaje.Text = canal[0].Descripcion.ToString();
            
            /*fatom.MatnrProd2 = canal[0].Matnr.ToString();
            fatom.MatnrProd2Virt = canal[0].MatnrVirt.ToString();
            fatom.OrdenProp = canal[0].OrdenProp.ToString();
            desensamble = canal[0].Desensamble.ToString();
            venta = canal[0].ICanaVenta.ToString();
            fatomAgrega.ActualizarMaterialesBAL(fatom);*/

            if(canal.Count <= 0) {
                throw new Exception("Tipo de pesaje inexistente");
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            CLSFatom fatom = new CLSFatom();
            try
            {
                fatom = Validar();
                Grabar(fatom);
                IncrementarCampos();
                base.MostrarMensaje("Folio Grabado Correctamente");
                txtbxKilos1.Clear();
                txtbxKilos2.Clear();
                txtbxFolio.Select();
                txtbxFolio.Focus();
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }

            //txtbxTipoPesaje.Text = txtbxDescDestino.Text;

            /*if(txtbxFolio.Text.Trim().StartsWith("1") == true) {
                pnlPrimPes2.Visible = false;
            }
            else if (txtbxFolio.Text.Trim().StartsWith("2") == true)
            {
                pnlPrimPes2.Visible = true;
            }*/
        }

        private string MostrarMensaje() 
        {
            return "El folio no existe para la fecha, desea crear un registro nuevo en base a el centro: " + txtbxCentro.Text + " la fecha: " +
                dtpFecha.Value.Date.ToString().Substring(0,10) + " el folio: " + txtbxFolio.Text + " y el destino: " + txtbxDestino.Text + "?";
        }

        private void ActualizarFatom()
        {
            CLSFatomBAL fatomBAL = new CLSFatomBAL();
            CLSFatom fatom = new CLSFatom();
            string criterio = "";
            DateTime diaSiguiente = dtpFecha.Value.AddDays(1);

            criterio = "WHERE (WERKS = '" + centro + "') ";
            criterio = criterio + "AND (FECHA >= CONVERT(DATETIME, '" + dtpFecha.Value.ToString("yyyy-MM-dd 00:00:00") + "', 120)) ";
            criterio = criterio + "AND (FECHA <= CONVERT(DATETIME, '" + diaSiguiente.ToString("yyyy-MM-dd 00:00:00") + "', 120)) ";
            criterio = criterio + "AND (FOLIO = '" + txtbxFolio.Text + "')";
            if (txtbxDestino.TextLength > 0)
            {
                try
                {
                    fatom.CodDestino = txtbxDestino.Text;
                    if (primeraPesada)
                    {
                        fatom.Kg1 = Convert.ToDouble(txtbxKilos1.Text);
                        pnlPrimPes2.Visible = false;
                    }
                    else if (!primeraPesada)
                    {
                        fatom.Kg2 = Convert.ToDouble(txtbxKilos2.Text);
                    }
                }
                catch (Exception)
                {
                    
                    throw new Exception("El campo peso se encuentra vacio");
                }
            }
            //fatom.PesoSinCabeza = Convert.ToDouble(dgvFatom.Rows[i].Cells[3].Value) - Convert.ToDouble(dgvFatom.Rows[i].Cells[12].Value);
            fatomBAL.ActualizarDestinoBAL(fatom, criterio);
            ActualizarDescripcion(fatom);
            
        }

        private void ActualizarDescripcion(CLSFatom fatom)
        {
            CLSCatDestinoCollection destino = new CLSCatDestinoBAL().MostrarCatDestinoBAL("");
            CLSFatomBAL fatoBal = new CLSFatomBAL();
            string criterio = "WHERE (CODDESTINO = '" + fatom.CodDestino.ToString() + "') ";
            criterio = criterio +  "AND (WERKS = '" + txtbxCentro.Text + "')";
            string destinoPar = "";
            string pesarCab = "";
            //bool pesarCabLog = false;

            for (int i = 0; i < destino.Count; i++)
            {
                if (fatom.CodDestino.ToString() == destino[i].CodDestino.ToString())
                {
                    destinoPar = destino[i].DescDestino;
                    pesarCab = destino[i].PesarCab;
                    /*if (pesarCab == "X")
                    {
                        pesarCabLog = true;
                    }
                    else
                    {
                        pesarCabLog = false;
                    }*/
                    /*dgvFatom.Rows[index].Cells[7].Value = destinoPar;
                    dgvFatom.Rows[index].Cells[11].Value = pesarCabLog;*/
                    fatom.Destino = destinoPar;
                    fatom.PesarCab = pesarCab;
                    fatom.Matnr = destino[i].MatnrComp.ToString();
                    fatom.MatnrProd = destino[i].MatnrProd.ToString();
                    fatoBal.AcualizarDescripcionBAL(fatom, criterio);
                    txtbxDescDestino.Text = destinoPar;
                    break;
                }
            }
        }

        private string CambiarDestino()
        {
            CLSCatDestinoCollection destino;
            destino = new CLSCatDestinoBAL().MostrarCatDestinoBAL("");
            IEnumerator lista = destino.GetEnumerator();
            int i = 0;

            while (lista.MoveNext())
            {

                if (txtbxDestino.Text == destino[i].CodDestino.ToString())
                {
                    /*txtbxMatCon.Text = destino[i].MatnrComp;
                    txtbxMatProd.Text = destino[i].MatnrProd;
                    lblPesarCab.Text = destino[i].PesarCab;*/
                    return destino[i].DescDestino;
                }
                if (txtbxDestino.Text == "")
                {
                    return " ";
                }
                i++;
            }
            throw new Exception("No existe Destino");
        }

        private CLSCatDestinoCollection GrabarDestino()
        {
            CLSCatDestinoCollection destino;
            string criterio = "WHERE (WERKS = '" + txtbxCentro.Text + "')";
            destino = new CLSCatDestinoBAL().MostrarCatDestinoBAL(criterio);
            IEnumerator lista = destino.GetEnumerator();
            int i = 0;

            while (lista.MoveNext())
            {

                if (txtbxDestino.Text == destino[i].CodDestino.ToString())
                {
                    /*txtbxMatCon.Text = destino[i].MatnrComp;
                    txtbxMatProd.Text = destino[i].MatnrProd;
                    lblPesarCab.Text = destino[i].PesarCab;*/
                    return destino;
                }
                if (txtbxDestino.Text == "")
                {
                    return null;
                }
                i++;
            }
            throw new Exception("No existe Destino");
        }

        private void txtbxDescDestino_TextChanged(object sender, EventArgs e)
        {
            try
            {
                base.MensajeApagar();
                txtbxDescDestino.Text = CambiarDestino();
            }
            catch (Exception ex)
            {

                base.MostrarError(ex.Message);
            }
        }

        private void PuertoSerial(bool pesada)
        {
            CLSBasculas claseBascula = new CLSBasculas();
            //string codFatom = puertoFatom + settingFatom;
            string waBascula;
            string peso = "";
            int cont = 0;
            int cont2 = 0;
            int longitud = 0;
            int maxPos = 0;
            int indice;

            if (bascula == "MANUAL") { return; }

            if (puertoS.IsOpen) { CerrarPuerto(); }
            
            if (pesada) { txtbxKilos1.Clear(); }
            else { txtbxKilos2.Clear(); }

            while (cont < 4)
            { 
                if(pesada && txtbxKilos1.TextLength > 0) 
                {
                    break;
                }
                if (!pesada && txtbxKilos2.TextLength > 0)
                {
                    break;
                }
                AbrirPuerto();
                waBascula = "";
                
                InitComPort(bascula);
                waBascula = puertoS.ReadLine().Trim();
                longitud = waBascula.Length;
                maxPos = longitud - 11;
                if(maxPos < 0) { break; }
                indice = 0;
                do
                {
                    if (waBascula + indice.ToString() == "") 
                    {
                        waBascula = waBascula + indice.ToString();
                        if(waBascula.Length > maxPos) { break; }
                        peso = waBascula;
                        if (pesada)
                        {
                            try
                            {
                                txtbxKilos1.Text = peso;
                                CerrarPuerto();
                            }
                            catch (Exception)
                            {

                                throw new Exception("Error en lectura de báscula");
                            }
                        }
                        else 
                        {
                            try
                            {
                                txtbxKilos2.Text = peso;
                                CerrarPuerto();
                            }
                            catch (Exception)
                            {
                                throw new Exception("Error en lectura de báscula");
                            }
                        }
                    }
                }
                while (cont2 < longitud);
                cont++;
            }
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
                    case "Even":
                        {
                            puertoS.Parity = Parity.Even;
                            break;
                        }
                    case "Mark":
                        {
                            puertoS.Parity = Parity.Mark;
                            break;

                        }
                    case "None":
                        {
                            puertoS.Parity = Parity.None;
                            break;

                        }
                    case "Odd":
                        {
                            puertoS.Parity = Parity.Odd;
                            break;

                        }
                    case "Space":
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
                    case "None":
                        {
                            puertoS.StopBits = StopBits.None;
                            break;

                        }
                    case "One":
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

                currValue = aParametros[0]; //DataBits
                puertoS.PortName = "COM" + currValue;
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

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void FrmZPPG05_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    Validar();
                    //presionaEnter = false;
                }
                //if (e.KeyChar == (char)Keys.F8)
                //{
                //    CLSFatom fatom = Validar();
                //    IncrementarCampos();
                //    Grabar(fatom);
                //}
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }

        private void ObtenerProductos0R20(CLSFatom fatom)
        {
            CLSCatDestinoCollection destinos;
            string criterio = "WHERE (CODDESTINO = '" + txtbxDestino.Text + "') ";
            criterio = criterio + "AND (WERKS = '" + txtbxCentro.Text + "') ";
            criterio = criterio + "AND (PESOINI < '" + txtbxKilos1.Text + "') ";
            criterio = criterio + "ORDER BY CODDESTINO, PESOINI DESC";
            destinos = new CLSCatDestinoBAL().MostrarCatDestinoBAL(criterio);
            //fatom.Matnr = destinos[0].MatnrComp.ToString();
            fatom.MatnrProd = destinos[0].MatnrProd.ToString();
            //lblPesarCab.Text = destinos[0].PesarCab.ToString();
        }

        private void FrmZPPG05_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F8)
            {
                btnGrabar_Click(sender, e);
            }
        }

        private void txtbxTara2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                txtbxFolio.Select();
                txtbxFolio.Focus();
            }
        }

        private void txtbxEntrega_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxEntrega);
        }

        private void txtbxEntrega_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxEntrega);
        }
    }
}
