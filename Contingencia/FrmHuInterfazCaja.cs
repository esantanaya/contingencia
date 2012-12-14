using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Drawing.Printing;
using System.Globalization;

namespace Contingencia
{
    public partial class FrmHuInterfazCaja : FrmBase
    {
        private SerialPort puertoS;
        static CultureInfo currentCulture = CultureInfo.CurrentCulture;

        private string pOrdenGtSub;
        private string pMaterialGtSub;

        private string idCentro;
        public string IdCentro
        {
            get { return idCentro; }
            set { idCentro = value; }
        }

        private string nombreCentro;
        public string NombreCentro
        {
            get { return nombreCentro; }
            set { nombreCentro = value; }
        }

        private string nombreBascula;
        public string NombreBascula
        {
            get { return nombreBascula; }
            set { nombreBascula = value; }
        }

        private string setteoBascula;
        public string SetteoBascula
        {
            get { return setteoBascula; }
            set { setteoBascula = value; }
        }

        private ClsZEtiqueta gsEtiq;
        private string gvMatnr;
        private string gsMensaje;
        private string gsCriterio;
        private ClsMARA mara;
        private ClsMARA mara2;
        private ClsZTPPGrupoMat zTPPGrupoMat;
        private ClsZTPPGrupoEmp zTPPGrupoEmp;
        private ClsProcedimientosCollection grProcedimiento;
        private ClsZTPPTrazabi ztppTrazabi;
        private ClsZTPPTrazabiCollection ztppTrazabiCol;
        private CLSFatomCollection lfatomCollection;
        private ClsResb resb;
        private ClsResbCollection resb1raColl;
        private ClsResbCollection resb2daColl;
        private ClsResbCollection resb3raColl;
        private ClsResb resb1ra;
        private ClsResb resb2da;
        private ClsResb resb3ra;
        private ClsOPCS opcs;
        private ClsOPCSCollection opcsColl;
        private double gTotalCantidadCajas;
        private double gTotalCajas;
        private ClsZTPPLogs ztppLogs;
        private string lMensaje2;
        private ClsDatosHU datos;
        private ClsPLPOCollection plpo1Ra;
        private ClsPLPOCollection plpo2Da;
        private ClsPLPOCollection plpo3Ra;
        private bool gvError;
        private string gvNoCaja;
        private ClsOPCSCollection linealopCol;
        private string cIconError;
        private string l_material_gt_sub;
        private string pSegundoMaterial;
        private string c261;
        private string c531;
        private string c101;
        private string c03;
        private string c05;
        private string c02;
        private string c0261;
        private string ckg;
        private string cper;
        private string cF;
        private int gvPosicion;


        public FrmHuInterfazCaja()
        {
            InitializeComponent();
            datos = new ClsDatosHU();
            gsEtiq = new ClsZEtiqueta();
            fillRangoProc();
            textCodigoProducto.Focus();
            gvError = false;
            cIconError = "@0A@";
            l_material_gt_sub = "";
            c261 = "261";
            c531 = "531";
            c101 = "101";
            c03 = "03";
            c05 = "05";
            c02 = "02";
            c0261 = "0261";
            ckg = "KG";
            cper = "PER";
            cF = "F";
            gvPosicion = 0;
            base.PonerTitulo("Interfaz Caja");


        }

        private void FrmHuInterfazCaja_Load(object sender, EventArgs e)
        {
            textCodigoProducto.Focus();
            if (nombreBascula.Equals("manual"))
            {
                textPesoBruto.ReadOnly = false;
            }
            else
            {
                textPesoBruto.ReadOnly = true;
            }
            //AutoCompletarMaterial();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void InciarForma()
        {
            lblCentro.Text = idCentro;
            lblNombreCentro.Text = nombreCentro;
            textCodigoProducto.Focus();
        }

        private void spcDetalle_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void spcCuerpo_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textCodigoProducto_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textCodigoProducto);
        }

        private void textTipoProducto_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textTipoProducto);
        }

        private void textPesoBruto_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textPesoBruto);
        }

        private void textCodigoProducto_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(textCodigoProducto);
        }

        private void textTipoProducto_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(textTipoProducto);
        }

        private void textPesoBruto_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(textPesoBruto);
        }

        private void picProductos_Click(object sender, EventArgs e)
        {
            ConsultarProductos();
        }

        private void ConsultarProductos()
        {
            DialogResult resultado;
            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            listaSeleccion.TipoCatalogo = "MATERIAL";
            listaSeleccion.IniciarForma();
            resultado = listaSeleccion.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                string lsClave = listaSeleccion.ClaveSel;
                textCodigoProducto.Text = lsClave;
            }


        }

        private void picTipoProducto_Click(object sender, EventArgs e)
        {
            ConsultarTipoProductos();
        }

        private void ConsultarTipoProductos()
        {
            DialogResult resultado;
            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            listaSeleccion.TipoCatalogo = "TIPOMATERIAL";
            listaSeleccion.IniciarForma();
            resultado = listaSeleccion.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                string lsClave = listaSeleccion.ClaveSel;
                textTipoProducto.Text = lsClave;
            }


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            unEnter();
            ValidarValidarProcesoEjecutar();
            double ldPesoN = double.Parse(textPesoNeto.Text);
            if ((int.Parse(textProducirCajas.Text)) != 0)
            {
                double ldEntre = (double.Parse(textEntregado.Text)) + (double.Parse(textPesoNeto.Text));
                textEntregado.Text = ldEntre + "";
            }


        }

        public void ImprimirEtiquetaGenerica(string psArchivoBase, string psImpresora)
        {
            int nuevosRenglones = 25;
            //Se aumenta el renglon para el valor compuesto 2020
            //MessageBox.Show("Hora: " + fechaNow);
            //DateTime hoy = DateTime.Now;
            string[,] aValoresTotales = new string[nuevosRenglones, 2];
            //A los valores obtenidos se les debe agregar los fijos de la parte
            aValoresTotales[0, 0] = "&datos-maktx&"; //Descripcion del Material
            aValoresTotales[0, 1] = gsEtiq.Maktx;
            // string lsFecha = (gsEtiq.Hora).Day.ToString("dd") + "/" + (gsEtiq.Hora).Month.ToString("mm") + "/" + (gsEtiq.Hora).Year.ToString("yyyy");
            aValoresTotales[1, 0] = "&gv_fecha_prod&"; //Fecha Produccion
            aValoresTotales[1, 1] = String.Format("{0:d}", gsEtiq.Hora);

            aValoresTotales[2, 0] = "&datos-peso&"; //Datos Peso
            aValoresTotales[2, 1] = String.Format("{0:0.0}", gsEtiq.Peso);

            string horaConformato = (gsEtiq.Hora).Hour + ":" + (gsEtiq.Hora).Minute + ":" + (gsEtiq.Hora).Second;

            aValoresTotales[3, 0] = "&datos-hora&"; //Datos Hora
            aValoresTotales[3, 1] = String.Format("{0:hh:mm:ss}", gsEtiq.Hora);

            aValoresTotales[4, 0] = "&datos-matnr&"; //Datos Material
            aValoresTotales[4, 1] = gsEtiq.Matnr;

            aValoresTotales[5, 0] = "&datos-padre&"; //Datos Padre
            aValoresTotales[5, 1] = gsEtiq.Padre;

            aValoresTotales[6, 0] = "&datos-HU&";
            aValoresTotales[6, 1] = gsEtiq.Hu;

            aValoresTotales[7, 0] = "&datos-barcode1&";//Datos CodigoBarra
            aValoresTotales[7, 1] = gsEtiq.Hu;

            aValoresTotales[8, 0] = "&datos-um&";//DatosCentro
            aValoresTotales[8, 1] = gsEtiq.Um + "";

            aValoresTotales[9, 0] = "&datos-tatunr&";//
            aValoresTotales[9, 1] = gsEtiq.Tatunr;

            aValoresTotales[10, 0] = "&datos-fmatan&";//
            aValoresTotales[10, 1] = String.Format("{0:d}", gsEtiq.Fmatan);

            aValoresTotales[11, 0] = "&datos-charg&"; //Datos Lote
            aValoresTotales[11, 1] = gsEtiq.Charg;

            aValoresTotales[12, 0] = "&gv_stadom&"; //
            aValoresTotales[12, 1] = textNombreTipo.Text;

            aValoresTotales[13, 0] = "&datos-werks&";
            aValoresTotales[13, 1] = idCentro;

            aValoresTotales[14, 0] = "&NEtiq&";
            aValoresTotales[14, 1] = gsEtiq.Etifo;

            aValoresTotales[15, 0] = "&barcode2d&";
            aValoresTotales[15, 1] = gsEtiq.Hu + "|P" + gsEtiq.Matnr + "|L" + gsEtiq.Charg + "|D" + String.Format("{0:d}", gsEtiq.Hora) + "|Q" + gsEtiq.Peso + "|W" + gsEtiq.Werks;

            DateTime ldtFecha = gsEtiq.Hora;
            int diasCadu = gsEtiq.DiasCad;
            ldtFecha = ldtFecha.AddDays(+diasCadu);

            aValoresTotales[16, 0] = "&gv_fecha_cad&";
            aValoresTotales[16, 1] = String.Format("{0:d}", ldtFecha);

            string lsDigEan13 = CalculateChecksumDigit(Calcular12Digitos(gsEtiq.Peso, gvMatnr));

            aValoresTotales[17, 0] = "&V_BARCODE4&";
            aValoresTotales[17, 1] = lsDigEan13;

            aValoresTotales[18, 0] = "&datos-dd&";
            aValoresTotales[18, 1] = String.Format("{0:dd}", ldtFecha);

            aValoresTotales[19, 0] = "&datos-mm&";
            aValoresTotales[19, 1] = String.Format("{0:MM}", ldtFecha);

            aValoresTotales[20, 0] = "&datos-yyyy&";
            aValoresTotales[20, 1] = String.Format("{0:yyyy}", ldtFecha);

            aValoresTotales[21, 0] = "&datos-tiprod&";
            aValoresTotales[21, 1] = (textTipoProducto.Text).Substring(1, 1);

            aValoresTotales[22, 0] = "&datos-codpro&";
            aValoresTotales[22, 1] = (textCodigoProducto.Text).ToUpper();

            gsCriterio = "WHERE MATNR = '" + gvMatnr + "' ";
            //    + "AND WERKS = '" + idCentro + "'";

            ClsMARACollection maraCollE = new ClsMARABAL().ConsultarMARABAL(gsCriterio);

            if (maraCollE.Count > 0)
            {
                gsEtiq.Pais = maraCollE[0].Landx;
            }

            aValoresTotales[23, 0] = "&W_PAIS&";
            aValoresTotales[23, 1] = gsEtiq.Pais;

            string barc2 = "";
            barc2 = gvMatnr.Substring(0, 6);
            double pesotemXdiesmil = (gsEtiq.Peso) * 10000;
            if ((gsEtiq.Peso) >= 10)
            {
                barc2 = barc2 + pesotemXdiesmil;
            }
            else
            {
                barc2 = barc2 + "0" + pesotemXdiesmil;
            }

            aValoresTotales[24, 0] = "&datos-barcode2&";
            aValoresTotales[24, 1] = barc2;

            ClsEtiquetaGeneral etiquetaGeneral = new ClsEtiquetaGeneral();
            etiquetaGeneral.AValores = aValoresTotales;
            etiquetaGeneral.ArchivoBase = psArchivoBase;
            etiquetaGeneral.Impresora = psImpresora;

            try
            {
                etiquetaGeneral.ProcesarEtiqueta();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textCodigoProducto_TextChanged(object sender, EventArgs e)
        {

        }

        public void AutoCompletarMaterial()
        {

            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();

            ClsMARACollection maraCol;
            maraCol = new ClsMARABAL().ConsultarMARABAL("");
            IEnumerator lista = maraCol.GetEnumerator();

            while (lista.MoveNext())
            {
                ClsMARA mara = (ClsMARA)lista.Current;
                datos.Add((mara.Matnr).Remove(0, 1));
            }
            textCodigoProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textCodigoProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textCodigoProducto.AutoCompleteCustomSource = datos;

        }

        public void Validar()
        {

            limpiarVariables();
            textCodigoProducto.Text = (textCodigoProducto.Text).ToUpper();
            textTratado.Text = 0 + "";
            textEntregado.Text = 0 + "";
            textProducirCajas.Text = 0 + "";
            
            if (!(nombreBascula.Equals("MANUAL")))
            {
                textPesoBruto.Text = 0 + "";
                CLSBasculas claseBascula = new CLSBasculas();
                claseBascula.ModeloBascula = nombreBascula;

                try
                {
                    textPesoBruto.Text = claseBascula.PuertoSerial();
                }
                catch (Exception ex)
                {
                    base.MostrarError(ex.Message);
                }
            }
            base.MostrarMensaje("");
            bool lbValida = true;
            string lsMensaje = "";
            try
            {


                if (textCodigoProducto.Text.Length == 0)
                {
                    lsMensaje = "Ingrese MATERIAL";
                    textCodigoProducto.SelectAll();
                    textCodigoProducto.Focus();
                    lbValida = false;
                }

                if (textTipoProducto.Text.Length == 0)
                {
                    lsMensaje = "Ingrese TIPO DE PRODUCTO";
                    textTipoProducto.SelectAll();
                    textTipoProducto.Focus();
                    lbValida = false;
                }

                if (lbValida)
                {
                    gvMatnr = textTipoProducto.Text + textCodigoProducto.Text;
                    gsEtiq.Werks = idCentro;
                    gsEtiq.Tiprod = textTipoProducto.Text;
                    gsEtiq.Codprod = textCodigoProducto.Text;


                    ClsZTPPGrupoMatCollection zTPPGrupoMatCol = new ClsZTPPGrupoMatBAL().ConsultarZTPPGrupoMatBAL("where MATNR= '" + gvMatnr + "' AND WERKS = '" + idCentro + "' ");
                    if (zTPPGrupoMatCol.Count > 0)
                    {
                        gsEtiq.Padre = zTPPGrupoMatCol[0].Codigo_Padre;
                    }



                }
                else
                {
                    throw new Exception(lsMensaje);

                }
            }
            catch
            {
                throw;
            }
        }

        public void ValidarProceso()
        {
            //datos = new ClsDatosHU();

            textCodigoProducto.Text = (textCodigoProducto.Text).ToUpper();

            string lsmatnr;
            int lmhdhb;

            double ldPesMax = 0.0;
            double ldPesMin = 0.0;
            double ldPesFijo = 0.0;
            try
            {
                ClsZTPPGrupoMatCollection zTPPGrupoMatCollection;
                gsCriterio = "where MATNR= '" + gvMatnr + "' AND WERKS = '" + idCentro + "'";
                zTPPGrupoMatCollection = new ClsZTPPGrupoMatBAL().ConsultarZTPPGrupoMatBAL(gsCriterio);


                if (zTPPGrupoMatCollection.Count == 0)
                {
                    textCodigoProducto.Focus();

                    gsMensaje = "No existen los pesos para material '" + gvMatnr + "' ";
                    gsMensaje = gsMensaje + "Verifique ZGRUPOMAT";
                    textCodigoProducto.SelectAll();
                    textCodigoProducto.Focus();
                    throw new Exception(gsMensaje);

                }
                zTPPGrupoMat = zTPPGrupoMatCollection[0];

                if (zTPPGrupoMat.TaraEdit.Equals(""))
                {
                    textTara.Text = "";
                    gsCriterio = "WHERE GRUPO_PT ='" + zTPPGrupoMat.Grupo_pt + "'";
                    ClsZTPPGrupoEmpCollection zTPPGrupoEmpCollection = new ClsZTPPGrupoEmpBAL().ConsultarZTPPGrupoEmpBAL(gsCriterio);

                    if (zTPPGrupoEmpCollection.Count == 0)
                    {
                        gsMensaje = "No existen los pesos para material '" + gvMatnr + "' ";
                        gsMensaje = gsMensaje + "Verifique ZGRUPOEMP";
                        textCodigoProducto.SelectAll();
                        textCodigoProducto.Focus();
                        throw new Exception(gsMensaje);
                    }
                    else
                    {
                        zTPPGrupoEmp = zTPPGrupoEmpCollection[0];
                        textTara.Text = zTPPGrupoEmp.Pt_Aplicar + "";
                    }
                }
                else
                {
                    if ((textTara.Text).Equals(""))
                    {
                        textTara.ReadOnly = false;
                        textTara.Focus();
                        textTara.Text = "0";
                        return;
                    }
                    else
                    {
                        try
                        {
                            double tara = double.Parse(textTara.Text);
                        }
                        catch
                        {
                            gsMensaje = "Campo Tara no valido";
                            textTara.SelectAll();
                            textTara.Focus();
                            throw new Exception(gsMensaje);

                        }
                    }

                }


                //validar que el material tenga dias de caducidad

                if (zTPPGrupoMat.Codigo_Padre.Equals(""))
                {
                    lsmatnr = gvMatnr;
                }
                else
                {
                    lsmatnr = zTPPGrupoMat.Codigo_Padre;
                }


                lmhdhb = 0;

                ClsMARACollection maraCollection;
                gsCriterio = " WHERE MATNR = '" + lsmatnr + "'";
                maraCollection = new ClsMARABAL().ConsultarMARABAL(gsCriterio);

                if (maraCollection.Count == 0)
                {
                    gsMensaje = "No existe el material '" + gvMatnr + "' ";
                    gsMensaje = gsMensaje + "Verifique MARA";
                    textCodigoProducto.SelectAll();
                    textCodigoProducto.Focus();
                    throw new Exception(gsMensaje);
                }
                else
                {
                    mara = maraCollection[0];
                    lmhdhb = mara.Mhdhb;
                }


                if (lmhdhb == 0)
                {
                    gsMensaje = "Material '" + gvMatnr + "' no tiene información";
                    gsMensaje = gsMensaje + " para calcular la fecha de caducidad";
                    textCodigoProducto.SelectAll();
                    textCodigoProducto.Focus();
                    throw new Exception(gsMensaje);
                }

                textPesoMaximo.Text = "" + zTPPGrupoMat.PesoMax;
                textPesoMinimo.Text = "" + zTPPGrupoMat.PesoMin;
                textPesoFijo.Text = "" + zTPPGrupoMat.PesoFijo;
                //para no tomar valores del directo del textBox
                ldPesMax = zTPPGrupoMat.PesoMax;
                ldPesMin = zTPPGrupoMat.PesoMin;
                ldPesFijo = zTPPGrupoMat.PesoFijo;

                //Determinar peso neto
                if ((textPesoBruto.Text).Equals(""))
                {
                    textPesoBruto.Text = 0.0 + "";
                }

                double pesoNetoredondeo = double.Parse(textPesoBruto.Text) - double.Parse(textTara.Text);
                pesoNetoredondeo = Math.Round(pesoNetoredondeo, 1);
                textPesoNeto.Text = pesoNetoredondeo + "";

                if (pesoNetoredondeo < 0)
                {
                    textPesoNeto.Text = 0 + "";
                }

                //validar que peso neto esta entre peso maximo y minimo
                if (pesoNetoredondeo < ldPesMin || pesoNetoredondeo > ldPesMax)
                {
                    textPesoBruto.Focus();
                    textPesoBruto.SelectAll();
                    gsMensaje = "Peso neto debe estar entre peso minimo y máximo";
                    throw new Exception(gsMensaje);
                }

                //determinar peso a imprimir
                if (ldPesFijo > 0)
                {
                    gsEtiq.Peso = ldPesFijo;
                    textPesoNeto.Text = ldPesFijo + "";
                    datos.CantidadCaja = ldPesFijo;
                }
                else
                {
                    gsEtiq.Peso = double.Parse(textPesoNeto.Text);
                    datos.CantidadCaja = double.Parse(textPesoNeto.Text);
                }

                ObtenerTatuaje();
                GetPrimeraOrden();


                if (resb1raColl.Count == 0 || (datos.PrimeraOrden).Equals("") || (datos.TipoPrimera).Equals(""))
                {
                    GetProcesoLineal();//una sola orden
                    base.MostrarMensaje("Una sola orden");
                    //throw new Exception("Una sola orden");
                }

                if (gvError)
                {
                    throw new Exception(gsMensaje);
                }

                if (!datos.TipoPrimera.Equals("L"))
                {
                    GetSegundaOrden();
                }

                if (!(datos.MateriaPrima3).Equals(""))
                {
                    GetTerceraOrden();
                }

            }
            catch
            {
                throw;
            }

        }

        public void ValidarValidarProcesoEjecutar()
        {
            try
            {
                textCodigoProducto.Text = (textCodigoProducto.Text).ToUpper();
                textTratado.Text = 0 + "";
                textEntregado.Text = 0 + "";
                textProducirCajas.Text = 0 + "";
                limpiarVariables();
                Validar();
                ValidarProceso();

                if (gvError)
                {
                    throw new Exception(gsMensaje);
                }
                EjecutarProcesos();
                string ruta = ClsFunciones.ObtenerValorEntorno(Variables.SistemaOperativo);
                //string ruta = "C:\\EtiquetasContingencia\\\\";
                string nombreArchivo = ruta + "GMPF" + gsEtiq.Etiar + idCentro + ".zpl";
                //ImprimirEtiquetaGenerica(nombreArchivo, GetImpresoraDefecto());
                ImprimirEtiquetaGenerica(nombreArchivo, GetImpresoraDefecto());

                limpiarTodasVariables();
                textOrden.Text = "";
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }

        public void EjecutarProcesos()
        {

            ClsZFolio zfolio = GenerarHU();
            DateTime hoy = DateTime.Now;
            gvNoCaja = "" + zfolio.Nbr;

            gsEtiq.Hora = hoy;
            gsEtiq.Hu = gvNoCaja;

            gsEtiq.Peso = datos.CantidadCaja;
            gsEtiq.Charg = textLote.Text;


            //lblEtiqueta.Text = gvNoCaja;
            textEtiquetaG.Text = gvNoCaja;
            /*proceso
             *code
             *mtv_ind
             *almacen
             *orden
             *clasemovimiento
             *material
             *cantidad
             *lote
             *motivomovimiento
             *umb
             *fecha_prod
             *afpos
             *lgort
             */
            string lsTipoEn = "";

            switch (datos.TipoPrimera)
            {
                
                case "P":
                    switch (datos.TipoSegunda)
                    {
                        case "P":
                            EjecutaProceso2daP();

                            switch (datos.TipoTercera)
                            {
                                case "P":
                                    EjecutaProceso3raP();

                                    break;
                                case "S":
                                    EjecutaProceso3raS();
                                    break;
                            }
                            break;
                        case "S":
                            EjecutaProcesos2daS();
                            switch (datos.TipoTercera)
                            {

                                case "P":
                                    EjecutaProceso3raP();
                                    break;
                                case "S":
                                    EjecutaProceso3raS();
                                    break;
                            }
                            break;
                    }
                    lsTipoEn = "P";
                    EjecutaProcesos1raP(lsTipoEn);
                    break;
                
                case "L":
                    lsTipoEn = "L";
                    EjecutaProcesos1raP(lsTipoEn);
                    break;
            }

        }

        public ClsZFolio GenerarHU()
        {
            ClsZFolio zfolio = new ClsZFolio();
            zfolio.Werks = idCentro;
            zfolio.Tipo = "TC";
            zfolio.Pref = "";
            ClsZFolioCollection folios = new ClsZFolioBAL().AgregaryRetornoZFolioBAL(zfolio);

            if (folios.Count == 0)
            {
                gsMensaje = "Error al crear folio ";
                throw new Exception(gsMensaje);
            }
            zfolio = folios[0];
            return zfolio;
        }

        public void GetTerceraOrden()
        {
            string lmatnrLike;
            double luebto;
            double ltotalDeCajas;
            double lcantActualOrden = 0.0;
            double lcanNotLog;
            double lcajasMasNeto;
            string lordenSinCapacidad = "";
            int lsinLote;
            string lobjnr;
            int lok;
            string lmateriagtsub = "";
            string lordengtsub = "";
            int lrsum;
            string lstlnr;
            string str1;
            string str2;
            string str3;
            bool gvError1;

            datos.TerceraOrden = "";
            resb3raColl = null;

            //conjunto de Segundas posibles ordenes
            string lcriterio = "WHERE "
            + "MATNR = '" + datos.MateriaPrima3 + "' AND "
            + "WERKS = '" + idCentro + "' AND BWART = '261'"
            + " ORDER BY RSNUM DESC";
            resb3raColl = new ClsResbBAL().ConsultarResbBAL(lcriterio);
            if (resb3raColl.Count == 0)
            {
                gvError = true;
                gsMensaje = "No se encuentra tercera Orden de Producción"
                    + " para la materia prima: " + datos.MateriaPrima3;
                return;
            }
            else
            {

                IEnumerator totalResb = resb3raColl.GetEnumerator();

                while (totalResb.MoveNext())
                {
                    lordenSinCapacidad = "";
                    resb3ra = (ClsResb)totalResb.Current;
                    lcriterio = "";
                    lcriterio = "WHERE AUFNR = '" + resb3ra.Aufnr + "'";
                    opcsColl = new ClsOPCSBAL().ConsultarOPCSBAL(lcriterio);
                    if (opcsColl.Count > 0)
                    {
                        //begin de alex
                        //end de alex

                        gsCriterio = "WHERE RSNUM = " + resb3ra.Rsnum + " "
                           + "AND MATNR = '" + datos.MateriaPrima2 + "'";

                        ClsResbCollection resbVal = new ClsResbBAL().ConsultarResbBAL(gsCriterio);

                        if (resbVal.Count == 0)
                        {
                            if (!((resb3ra.Baugr).Equals(datos.MateriaPrima2)))
                            {
                                continue;
                            }
                            else
                            {
                                datos.TipoTercera = "P";
                            }
                        }
                        else
                        {

                            datos.TipoTercera = "S";
                        }

                        datos.MateriaPrima3 = "";
                        gvError1 = false;

                        //validamos y vs



                        resb3ra.Lgort = opcsColl[0].Lgort;
                        ltotalDeCajas = 0.0;

                        getCantidadEmbalada(resb1ra.Aufnr);
                        ltotalDeCajas = gTotalCantidadCajas;


                        //gTotalCajas;
                        //Cantidad actual de la orden (real -notificada)
                        if ((datos.TipoSegunda).Equals("P"))
                        {
                            datos.TercerMaterial = resb3ra.Baugr;

                            gsCriterio = "WHERE AUFNR = '" + opcsColl[0].Aufnr + "' "
                                + "AND MATNR = '" + opcsColl[0].Matrnr + "' "
                                + "AND ICON = '" + cIconError + "' "
                                + "AND PROCESO = 'EM'";

                            ClsZTPPLogsCollection llogsColl = new ClsZTPPLogsBAL().ConsultarZTPPLogsBAL(gsCriterio);
                            IEnumerator totalllogsColl = llogsColl.GetEnumerator();
                            lcanNotLog = 0.0;
                            while (totalllogsColl.MoveNext())
                            {
                                ClsZTPPLogs logsUn = (ClsZTPPLogs)totalllogsColl.Current;
                                lcanNotLog = lcanNotLog + logsUn.Vemng;
                            }

                            if (!((opcsColl[0].Uebtk).Equals("X")))
                            {
                                lcantActualOrden = opcsColl[0].Psmng + (opcsColl[0].Psmng * opcsColl[0].Uebto / 100)
                            - ltotalDeCajas;
                            }
                            else
                            {
                                lcantActualOrden = 100000;
                            }

                            //si tiene capacidad

                            if (double.Parse(textPesoNeto.Text) <= lcantActualOrden)
                            {
                                /*Cantidad notificada tambien se verifica
                                   cambio Temporal para revisar contra cantidad notificada
                                   l_cant_actual_orden = afko-gamng - afko-igmng.*/


                                //Si la cantidad de cajas + el peso neto sobrepasa el total de orden..
                                //buscamos en la siguiente orden.

                                lcajasMasNeto = double.Parse(textPesoNeto.Text);
                                //+ ltotalDeCajas;

                                if (lcajasMasNeto > lcantActualOrden)
                                {
                                    lordenSinCapacidad = resb3ra.Aufnr;

                                    continue;

                                }
                            }
                            else
                            {
                                lordenSinCapacidad = resb3ra.Aufnr;

                                continue;
                            }
                        }
                        else
                        {
                            lmateriagtsub = "";
                            lordengtsub = "";

                            GetCantidadNotSub3(resb2da.Rsnum, resb2da.Aufnr, double.Parse(textPesoNeto.Text),
                                   resb3ra.Aufnr);

                            if ((datos.TerceraOrden).Equals("") || (datos.TerceraRsnum).Equals(""))
                            {
                                lordenSinCapacidad = resb2da.Aufnr;
                                continue;
                            }
                            else
                            {
                                lordenSinCapacidad = "";
                            }

                        }

                        Producto(3, resb1ra.Baugr, resb2da.Aufnr, opcsColl[0].Plnty, opcsColl[0].Plnnr);

                        //Validacion almacen en orden
                        if (opcsColl[0].Lgort.Equals(""))
                        {
                            gsMensaje = "";
                            gsMensaje = "Ingrese almacen en orden '" + resb3ra.Aufnr + "'";
                            textCodigoProducto.SelectAll();
                            textCodigoProducto.Focus();
                            gvError = true;
                            break;
                        }

                        //validar almacen de la lista
                        gsCriterio = "WHERE RSNUM = " + resb3ra.Rsnum + " AND "
                            + "MATNR IS NOT NULL AND "
                            + "WERKS = '" + idCentro + "' AND "
                            + "AUFNR = '" + resb3ra.Aufnr + "' ";
                        // + "LGORT IS NULL";
                        ClsResbCollection lresColl = new ClsResbBAL().ConsultarResbBAL(gsCriterio);

                        if (lresColl.Count > 0)
                        {
                            gsMensaje = "";
                            gsMensaje = "Ingrese almacen en lista de materiales de orden '" + resb3ra.Aufnr + "' ";
                            textCodigoProducto.SelectAll();
                            textCodigoProducto.Focus();
                            gvError = true;
                            break;
                        }

                        datos.TerceraOrden = resb3ra.Aufnr;
                        datos.TerceraRsnum = resb3ra.Rsnum;
                        datos.Lgort3 = opcsColl[0].Lgort;
                        break;


                    }
                }

                if (!lordenSinCapacidad.Equals("") || gvError || (datos.TerceraOrden).Equals(""))
                {

                    if ((datos.TerceraOrden).Equals(""))
                    {
                        gvError = true;
                        if (lordenSinCapacidad.Equals(""))
                        {
                            gsMensaje = "No se encontro ninguna tercera orden disponible";
                        }
                        else
                        {
                            gsMensaje = "La tercera orden " + lordenSinCapacidad + "no tiene cantidad disponible";
                        }

                        if (!(lmateriagtsub.Equals("")))
                        {
                            gvError = true;
                            gsMensaje = "La tercera orden de proceso " + lordengtsub + "ha sido excedida para el maerial " + lmateriagtsub;
                        }
                    }

                }
            }
        }

        public void GetSegundaOrden()
        {
            string lmatnrLike;
            double luebto;
            double ltotalDeCajas;
            double lcantActualOrden = 0.0;
            double lcanNotLog;
            double lcajasMasNeto;
            string lordenSinCapacidad = "";
            int lsinLote;
            string lobjnr;
            int lok;
            string lmateriagtsub = "";
            string lordengtsub = "";
            int lrsum;
            string lstlnr;
            string str1;
            string str2;
            string str3;
            bool gvError1;

            datos.SegundaOrden = "";
            datos.SegundaRsnum = 0;
            lmatnrLike = gvMatnr;
            gsCriterio = "WHERE "
            + "MATNR = '" + datos.MateriaPrima2 + "' AND "
            + "WERKS = '" + idCentro + "' AND BWART = '261'"
            + " ORDER BY RSNUM DESC";
            resb2daColl = new ClsResbBAL().ConsultarResbBAL(gsCriterio);

            if (resb2daColl.Count == 0)
            {
                gvError = true;
                gsMensaje = "No se encuentra segunda Orden de Producción"
                    + " para la materia prima: " + datos.MateriaPrima2;
                return;
            }
            else
            {


                IEnumerator totalResb = resb2daColl.GetEnumerator();

                while (totalResb.MoveNext())
                {
                    lordenSinCapacidad = "";
                    resb2da = (ClsResb)totalResb.Current;
                    gsCriterio = "";
                    gsCriterio = "WHERE AUFNR = '" + resb2da.Aufnr + "'";
                    opcsColl = new ClsOPCSBAL().ConsultarOPCSBAL(gsCriterio);
                    if (opcsColl.Count > 0)
                    {
                        //begin de alex
                        //end de alex

                        gsCriterio = "WHERE RSNUM = " + resb2da.Rsnum + " "
                            + "AND MATNR = '" + datos.MateriaPrima1 + "'";

                        ClsResbCollection resbVal = new ClsResbBAL().ConsultarResbBAL(gsCriterio);

                        if (resbVal.Count == 0)
                        {
                            if (!((resb2da.Baugr).Equals(datos.MateriaPrima1)))
                            {
                                continue;
                            }
                            else
                            {
                                datos.TipoSegunda = "P";
                            }
                        }
                        else
                        {

                            datos.TipoSegunda = "S";
                        }

                        datos.MateriaPrima3 = "";
                        gvError1 = false;

                        //validamos y vs


                        if (!((datos.CodigoHijo2).Equals("261")))
                        {
                            if (!((datos.CodigoHijo2).Equals("26")))
                            {
                                gvError1 = true;
                                gsCriterio = "";
                                gsCriterio = "WHERE RSNUM = " + resb2da.Rsnum + " AND "
                                    + "POTX1 IS NOT NULL";
                                resb3raColl = new ClsResbBAL().ConsultarResbBAL(gsCriterio);
                                IEnumerator toResb3ra = resb3raColl.GetEnumerator();
                                while (toResb3ra.MoveNext())
                                {
                                    ClsResb resb3raOnly = (ClsResb)toResb3ra.Current;
                                    str1 = resb3raOnly.Potx1;
                                    str2 = resb3raOnly.Potx2;
                                    str3 = resb3raOnly.Potx3;
                                    if (!(datos.CodigoHijo2).Equals(str1))
                                    {
                                        gvError1 = true;
                                    }
                                    else
                                    {
                                        datos.MateriaPrima3 = str2;
                                        gvError1 = false;

                                        continue;
                                    }
                                }
                            }

                        }
                        if (gvError1)
                        {
                            continue;
                        }
                        resb2da.Lgort = opcsColl[0].Lgort;
                        ltotalDeCajas = 0.0;

                        getCantidadEmbalada(resb1ra.Aufnr);
                        ltotalDeCajas = gTotalCantidadCajas;
                        //gTotalCajas;
                        //Cantidad actual de la orden (real -notificada)
                        if ((datos.TipoSegunda).Equals("P"))
                        {
                            datos.SegundoMaterial = resb2da.Baugr;

                            gsCriterio = "WHERE AUFNR = '" + opcsColl[0].Aufnr + "' "
                                + "AND MATNR = '" + opcsColl[0].Matrnr + "' "
                                + "AND ICON = '" + cIconError + "' "
                                + "AND PROCESO = 'EM'";

                            ClsZTPPLogsCollection llogsColl = new ClsZTPPLogsBAL().ConsultarZTPPLogsBAL(gsCriterio);
                            IEnumerator totalllogsColl = llogsColl.GetEnumerator();
                            lcanNotLog = 0.0;
                            while (totalllogsColl.MoveNext())
                            {
                                ClsZTPPLogs logsUn = (ClsZTPPLogs)totalllogsColl.Current;
                                lcanNotLog = lcanNotLog + logsUn.Vemng;
                            }

                            if (!((opcsColl[0].Uebtk).Equals("X")))
                            {
                                lcantActualOrden = opcsColl[0].Psmng + (opcsColl[0].Psmng * opcsColl[0].Uebto / 100)
                            - ltotalDeCajas;
                            }
                            else
                            {
                                lcantActualOrden = 100000;
                            }

                            //si tiene capacidad

                            if (double.Parse(textPesoNeto.Text) <= lcantActualOrden)
                            {
                                /*Cantidad notificada tambien se verifica
                                   cambio Temporal para revisar contra cantidad notificada
                                   l_cant_actual_orden = afko-gamng - afko-igmng.*/


                                //Si la cantidad de cajas + el peso neto sobrepasa el total de orden..
                                //buscamos en la siguiente orden.

                                lcajasMasNeto = double.Parse(textPesoNeto.Text);
                                //+ ltotalDeCajas;

                                if (lcajasMasNeto > lcantActualOrden)
                                {
                                    lordenSinCapacidad = resb2da.Aufnr;

                                    continue;

                                }
                                else
                                {
                                    lordenSinCapacidad = "";
                                }
                            }
                            else
                            {
                                lordenSinCapacidad = resb2da.Aufnr;

                                continue;
                            }
                        }
                        else
                        {
                            lmateriagtsub = "";
                            lordengtsub = "";

                            GetCantidadNotSub(resb1ra.Rsnum, resb1ra.Aufnr, double.Parse(textPesoNeto.Text),
                                   resb2da.Aufnr);

                            if ((datos.SegundaOrden).Equals("") || (datos.SegundaRsnum).Equals(""))
                            {
                                lordenSinCapacidad = resb2da.Aufnr;
                                continue;
                            }
                            else
                            {
                                lordenSinCapacidad = "";
                            }



                        }

                        Producto(2, resb2da.Baugr, resb2da.Aufnr, opcsColl[0].Plnty, opcsColl[0].Plnnr);

                        //Validacion almacen en orden
                        //if (opcsColl[0].Lgort.Equals(""))
                        //{
                        //    gsMensaje = "";
                        //    gsMensaje = "Ingrese almacen en orden '" + resb2da.Aufnr + "'";
                        //    textCodigoProducto.SelectAll();
                        //    textCodigoProducto.Focus();
                        //    gvError = true;
                        //    break;
                        //}

                        //validar almacen de la lista
                        //gsCriterio = "WHERE RSNUM = " + resb2da.Rsnum + " AND "
                        //    + "MATNR IS NOT NULL AND "
                        //    + "WERKS = '" + idCentro + "' AND "
                        //    + "AUFNR = '" + resb2da.Aufnr + "' ";
                        //    //+ "LGORT IS NULL";
                        //ClsResbCollection lresColl = new ClsResbBAL().ConsultarResbBAL(gsCriterio);

                        //if (lresColl.Count > 0)
                        //{
                        //    gsMensaje = "";
                        //    gsMensaje = "Ingrese almacen en lista de materiales de orden '" + resb2da.Aufnr + "' ";
                        //    textCodigoProducto.SelectAll();
                        //    textCodigoProducto.Focus();
                        //    gvError = true;
                        //    break;
                        //}

                        datos.SegundaOrden = resb2da.Aufnr;
                        datos.SegundaRsnum = resb2da.Rsnum;

                        datos.Lgort2 = opcsColl[0].Lgort;
                        break;


                    }
                }

                if (!lordenSinCapacidad.Equals("") || gvError || (datos.SegundaOrden).Equals(""))
                {

                    if ((datos.SegundaOrden).Equals(""))
                    {
                        gvError = true;
                        if (lordenSinCapacidad.Equals(""))
                        {
                            gsMensaje = "No se encontro ninguna segunda orden disponible";
                        }
                        else
                        {
                            gsMensaje = "La segunda orden " + lordenSinCapacidad + "no tiene cantidad disponible";
                        }

                        if (!(lmateriagtsub.Equals("")))
                        {
                            gvError = true;
                            gsMensaje = "La segunda orden de proceso " + lordengtsub + "ha sido excedida para el maerial " + lmateriagtsub;
                        }
                    }

                }
            }
        }

        public void GetPrimeraOrden()
        {
            string lmatnrLike;
            double luebto;
            double ltotalDeCajas;
            double lcantActualOrden;
            double lcajasMasNeto;
            string lordenSinCapacidad = "";
            int lsinLote;
            string lobjnr;
            int lok;
            int lrsum;
            string str1;

            datos.TipoPrimera = "";
            lmatnrLike = gvMatnr;
            string lcriterio = "WHERE "
            + "WERKS = '" + idCentro + "' AND POTX1 = '" + lmatnrLike + "'"
            + " ORDER BY AUFNR DESC";
            resb1raColl = new ClsResbBAL().ConsultarResbBAL(lcriterio);

            IEnumerator totalResb = resb1raColl.GetEnumerator();

            while (totalResb.MoveNext())
            {
                resb1ra = (ClsResb)totalResb.Current;
                lcriterio = "";
                lcriterio = "WHERE AUFNR = '" + resb1ra.Aufnr + "'";
                opcsColl = new ClsOPCSBAL().ConsultarOPCSBAL(lcriterio);

                if (opcsColl.Count > 0)
                {


                    /* if((resb1ra[i].Potx1).Equals(opcsColl[0].Stlbez))
                     {
                         datos.TipoPrimera = "P";
                     }
                     else
                     {
                         datos.TipoPrimera = "S";
                     }
                     */

                    datos.TipoPrimera = "P";

                    resb1ra.Lgort = opcsColl[0].Lgort;

                    ltotalDeCajas = 0.0;




                    getCantidadEmbalada(resb1ra.Aufnr);
                    ltotalDeCajas = gTotalCantidadCajas;
                    //gTotalCajas;
                    //Cantidad actual de la orden (real -notificada)

                    lcantActualOrden = opcsColl[0].Psmng + (opcsColl[0].Psmng * opcsColl[0].Uebto / 100)
                        - ltotalDeCajas;

                    //si tiene capacidad

                    if (double.Parse(textPesoNeto.Text) < lcantActualOrden)
                    {
                        /*Cantidad notificada tambien se verifica
                           cambio Temporal para revisar contra cantidad notificada
                           l_cant_actual_orden = afko-gamng - afko-igmng.*/


                        //Si la cantidad de cajas + el peso neto sobrepasa el total de orden..
                        //buscamos en la siguiente orden.

                        lcajasMasNeto = double.Parse(textPesoNeto.Text);
                        //+ ltotalDeCajas;

                        if (lcajasMasNeto > lcantActualOrden)
                        {
                            lordenSinCapacidad = resb1ra.Aufnr;
                            continue;

                        }

                        // Material que se ingreso en pantalla
                        datos.MaterialPantalla = gvMatnr;
                        gvMatnr = resb1ra.Baugr;

                        //Norma de embalaje

                        //getNormaEmbalaje();

                        //Validamos y mostramos los datos del material padre
                        validaMaterialReal(gvMatnr);

                        Producto(1, gvMatnr, resb1ra.Aufnr, opcsColl[0].Plnty, opcsColl[0].Plnnr);


                        //Validacion almacen en orden
                        if (opcsColl[0].Lgort.Equals(""))
                        {
                            gsMensaje = "";
                            gsMensaje = "Ingrese almacen en orden '" + resb1ra.Aufnr + "'";
                            textCodigoProducto.SelectAll();
                            textCodigoProducto.Focus();
                            gvError = true;
                        }

                        // Validacion almacen en orden
                        if (opcsColl[0].Lgort.Equals(""))
                        {
                            gsMensaje = "";
                            gsMensaje = "Ingrese almacen en orden '" + resb1ra.Aufnr + "' no tiene orden de producción";
                            textCodigoProducto.SelectAll();
                            textCodigoProducto.Focus();
                            gvError = true;
                        }


                        gsEtiq.Charg = opcsColl[0].Lgort;
                        gsCriterio = "WHERE RSNUM = '" + resb1ra.Rsnum + "' "
                            + "AND MATNR IS NOT NULL "
                            + "AND WERKS = '" + idCentro + "' "
                            + "AND AUFNR = '" + resb1ra.Aufnr + "' ";
                        //+"AND LGORT = '' ";
                        ClsResbCollection lResbColle = new ClsResbBAL().ConsultarResbBAL(gsCriterio);


                        if (lResbColle.Count == 0)
                        {
                            gsMensaje = "";
                            gsMensaje = "Ingrese almacen en lista de materiales de orden '" + resb1ra.Aufnr + "' ";
                            textCodigoProducto.SelectAll();
                            textCodigoProducto.Focus();
                            gvError = true;
                            break;

                        }


                        lrsum = lResbColle[0].Rsnum;

                        textOrden.Text = resb1ra.Aufnr;
                        datos.PrimeraOrden = resb1ra.Aufnr;
                        datos.PrimerMaterial = gvMatnr;
                        datos.MaximoXCaja = lcantActualOrden;
                        datos.Lgort1 = opcsColl[0].Lgort;

                        str1 = resb1ra.Potx1;
                        datos.MateriaPrima2 = resb1ra.Potx2;
                        datos.CodigoHijo2 = resb1ra.Potx3;

                        UpdateOtrosDatos(opcsColl[0].Psmng, gTotalCantidadCajas, gTotalCajas);


                    }
                    else
                    {
                        gsMensaje = "";
                        gsMensaje = "Material '" + gvMatnr + "' no tiene orden de producción";
                        textCodigoProducto.SelectAll();
                        textCodigoProducto.Focus();
                        gvError = true;
                    }

                    gsCriterio = "";
                    gsCriterio = "INNER JOIN MARA ON RESB.MATNR = MARA.MATNR WHERE RSNUM = "
                      + "'" + resb1ra.Rsnum + "' AND "
                      + "RESB.WERKS = '" + idCentro + "' AND "
                      + "(MARA.MTART = 'FERT' OR MARA.MTART ='HALB')";
                    ClsResbCollection lresbCol2 = new ClsResbBAL().ConsultarResbBAL(gsCriterio);

                    if (lresbCol2.Count > 0)
                    {
                        datos.MateriaPrima1 = lresbCol2[0].Matnr;
                    }

                    break;
                }
                else
                {
                    lordenSinCapacidad = resb1ra.Aufnr;

                    continue;
                }

            }

            if (lordenSinCapacidad.Length > 0 || gvError || (datos.PrimeraOrden).Equals(""))
            {
                if ((textOrden.Text).Equals("") || (textOrden.Text).Equals(lordenSinCapacidad))
                {
                    gvError = true;
                    gsMensaje = "";
                    gsMensaje = "1er  y 2do. plano:La orden " + lordenSinCapacidad + " no tiene cantidad disponible";
                    textEntregado.Text = "0";
                    textProducirCajas.Text = "0";
                    textOrden.Text = "";
                    datos = new ClsDatosHU();
                }

            }

        }

        public void GetCantidadNotSub3(int p_rsnum, string p_orden, double p_cantidad_caja, string p_tercera_orden)
        {
            double lcantidadNot;
            double lcantidadNotLog;
            double lcantidadSub;
            double lcantidadRestante;
            double lueeto = 0.0;
            string lueetk = "";

            pSegundoMaterial = "";
            pOrdenGtSub = "";
            pMaterialGtSub = "";

            //material de subproducto
            gsCriterio = "INNER JOIN MARA ON RESB.MATRN = MARA.MATNR"
            + " WHERE RSNUM = " + p_rsnum + " AND "
            + " AUFRN = '" + p_orden + "' AND "
            + " MTART = 'FERT'";
            ClsResbCollection lresbColl = new ClsResbBAL().ConsultarResbBAL(gsCriterio);
            if (lresbColl.Count > 0)
            {
                pSegundoMaterial = lresbColl[0].Matnr;
            }
            else
            {
                pSegundoMaterial = "";
            }

            //cantidad necesaria
            gsCriterio = "WHERE RSNUM = " + resb3ra.Rsnum + " AND "
                + "MATNR = '" + datos.MateriaPrima2 + "' AND "
                + "WERKS = '" + idCentro + "' AND "
                + "AUFNR = '" + resb3ra.Aufnr + "'";
            lresbColl = new ClsResbBAL().ConsultarResbBAL(gsCriterio);
            if (lresbColl.Count > 0)
            {
                lcantidadSub = lresbColl[0].Bdmng;
            }
            else
            {
                lcantidadSub = 0.0;
            }

            //Cantidad notificada
            //campos no encontrados

            //cantidad que falta dar entrada y rojo en la tabla de logs
            gsCriterio = "WHERE AUFNR = '" + p_tercera_orden + "' AND "
                + "MATNR = '" + datos.MateriaPrima2 + "' AND "
                + "ICON = '" + cIconError + "'";

            ClsZTPPLogsCollection logsColle = new ClsZTPPLogsBAL().ConsultarZTPPLogsBAL(gsCriterio);
            if (lresbColl.Count > 0)
            {
                IEnumerator totalllogsColl = logsColle.GetEnumerator();
                lcantidadNotLog = 0.0;
                while (totalllogsColl.MoveNext())
                {
                    ClsZTPPLogs logsUn = (ClsZTPPLogs)totalllogsColl.Current;
                    lcantidadNotLog = lcantidadNotLog + logsUn.Vemng;
                }

            }
            else
            {
                lcantidadNotLog = 0.0;
            }

            //SELECT PARA OBTENER PORCENTAJE A ECCEDER
            gsCriterio = "WHERE MATNR = '" + datos.MateriaPrima2 + "' "
                + "AND WERKS = '" + idCentro + "'";

            ClsMARACollection maraCollE = new ClsMARABAL().ConsultarMARABAL(gsCriterio);

            if (maraCollE.Count > 0)
            {
                lueeto = maraCollE[0].Ueeto;
                lueetk = maraCollE[0].Ueetk;
            }

            if (!(lueetk.Equals("X")))
            {
                lcantidadRestante = lcantidadSub + ((lcantidadSub * lueeto) / 100) - lcantidadNotLog;
                if (p_cantidad_caja < lcantidadRestante)
                {
                    datos.TerceraOrden = p_tercera_orden;
                    datos.TerceraRsnum = resb3ra.Rsnum;
                }

            }
            else
            {
                datos.TerceraOrden = p_tercera_orden;
                datos.TerceraRsnum = resb3ra.Rsnum;

            }
        }

        public void GetCantidadNotSub(int p_rsnum, string p_orden, double p_cantidad_caja, string p_segunda_orden)
        {
            double lcantidadNot;
            double lcantidadNotLog;
            double lcantidadSub;
            double lcantidadRestante;
            double lueeto = 0.0;
            string lueetk = "";

            pSegundoMaterial = "";
            pOrdenGtSub = "";
            pMaterialGtSub = "";

            //material de subproducto
            gsCriterio = "INNER JOIN MARA ON RESB.MATNR = MARA.MATNR"
            + " WHERE RSNUM = " + p_rsnum + " AND "
            + " AUFNR = '" + p_orden + "' AND "
            + " MTART = 'FERT'";
            ClsResbCollection lresbColl = new ClsResbBAL().ConsultarResbBAL(gsCriterio);
            if (lresbColl.Count > 0)
            {
                pSegundoMaterial = lresbColl[0].Matnr;

            }
            else
            {
                pSegundoMaterial = "";
            }

            //cantidad necesaria
            gsCriterio = "WHERE RSNUM = " + resb2da.Rsnum + " AND "
                + "MATNR = '" + pSegundoMaterial + "' AND "
                + "WERKS = '" + idCentro + "' AND "
                + "AUFNR = '" + resb2da.Aufnr + "'";
            lresbColl = new ClsResbBAL().ConsultarResbBAL(gsCriterio);
            if (lresbColl.Count > 0)
            {
                lcantidadSub = lresbColl[0].Bdmng;
            }
            else
            {
                lcantidadSub = 0.0;
            }

            //Cantidad notificada
            //campos no encontrados

            //cantidad que falta dar entrada y rojo en la tabla de logs
            gsCriterio = "WHERE AUFNR = '" + p_segunda_orden + "' AND "
                + "MATNR = '" + pSegundoMaterial + "' AND "
                + "WERKS = '" + idCentro + "' AND "
                + "ICON = '" + cIconError + "'";

            ClsZTPPLogsCollection logsColle = new ClsZTPPLogsBAL().ConsultarZTPPLogsBAL(gsCriterio);
            if (lresbColl.Count > 0)
            {
                IEnumerator totalllogsColl = logsColle.GetEnumerator();
                lcantidadNotLog = 0.0;
                while (totalllogsColl.MoveNext())
                {
                    ClsZTPPLogs logsUn = (ClsZTPPLogs)totalllogsColl.Current;
                    lcantidadNotLog = lcantidadNotLog + logsUn.Vemng;
                }

            }
            else
            {
                lcantidadNotLog = 0.0;
            }

            //SELECT PARA OBTENER PORCENTAJE A ECCEDER



            gsCriterio = "WHERE MATNR = '" + pSegundoMaterial + "' "
                + "AND WERKS = '" + idCentro + "'";

            ClsMARACollection maraCollE = new ClsMARABAL().ConsultarMARABAL(gsCriterio);

            if (maraCollE.Count > 0)
            {
                lueeto = maraCollE[0].Ueeto;
                lueetk = maraCollE[0].Ueetk;

            }

            if (!(lueetk.Equals("X")))
            {
                lcantidadRestante = lcantidadSub + ((lcantidadSub * lueeto) / 100) - lcantidadNotLog;
                if (p_cantidad_caja < lcantidadRestante)
                {
                    datos.SegundaOrden = p_segunda_orden;
                    datos.SegundaRsnum = resb2da.Rsnum;
                    datos.SegundoMaterial = pSegundoMaterial;
                }

            }
            else
            {
                datos.SegundaOrden = p_segunda_orden;
                datos.SegundaRsnum = resb2da.Rsnum;
                datos.SegundoMaterial = pSegundoMaterial;
            }




        }

        public void GetProcesoLineal()
        {

            string str1;
            double luebto;
            double ltotalDeCajas;
            double lcantActualOrden;
            double lcajasMasNeto;
            string lordenSinCapacidad = "";
            int lsinLote;
            string lobjnr;
            int lok;
            int lrsum;

            gsCriterio = "";
            gsCriterio = "WHERE PLNTY = '2' AND "
                + "MATNR = '" + gvMatnr + "' AND "
               + "DWERK = '" + idCentro + "' "
               + "ORDER BY AUFNR DESC";
            //MATNR

            linealopCol = new ClsOPCSBAL().ConsultarOPCSBAL(gsCriterio);
            if (linealopCol.Count > 0)
            {
                gvError = false;

                IEnumerator totalOpcs = linealopCol.GetEnumerator();

                while (totalOpcs.MoveNext())
                {
                    ClsOPCS linealOpcsTemp = (ClsOPCS)totalOpcs.Current;
                    ltotalDeCajas = 0.0;
                    getCantidadEmbalada(linealOpcsTemp.Aufnr);
                    ltotalDeCajas = gTotalCantidadCajas;
                    luebto = linealOpcsTemp.Uebto;

                    //Cantidad actual de la orden (real -notificada)


                    lcantActualOrden = linealOpcsTemp.Psmng + (linealOpcsTemp.Psmng * linealOpcsTemp.Uebto / 100)
                            - ltotalDeCajas;


                    //si tiene capacidad

                    if (double.Parse(textPesoNeto.Text) <= lcantActualOrden)
                    {
                        /*Cantidad notificada tambien se verifica
                        cambio Temporal para revisar contra cantidad notificada
                        l_cant_actual_orden = afko-gamng - afko-igmng.*/

                        //Si la cantidad de cajas + el peso neto sobrepasa el total de orden..
                        //buscamos en la siguiente orden.


                        lcajasMasNeto = double.Parse(textPesoNeto.Text);
                        //+ ltotalDeCajas;
                        //asi dijo alex

                        if (lcajasMasNeto > lcantActualOrden)
                        {
                            lordenSinCapacidad = linealOpcsTemp.Aufnr;
                            continue;

                        }


                        // Material que se ingreso en pantalla
                        datos.MaterialPantalla = gvMatnr;

                        //Norma de embalajecccc

                        //Validamos y mostramos los datos del material padre
                        validaMaterialReal(gvMatnr);

                        Producto(1, gvMatnr, linealOpcsTemp.Aufnr, linealOpcsTemp.Plnty, linealOpcsTemp.Plnnr);


                        // Validacion almacen en orden
                        if (linealOpcsTemp.Lgort.Equals(""))
                        {
                            gsMensaje = "";
                            gsMensaje = "Ingrese almacen en orden '" + linealOpcsTemp.Aufnr + "' no tiene orden de producción";
                            textCodigoProducto.SelectAll();
                            textCodigoProducto.Focus();
                            gvError = true;
                            break;
                        }

                        gsCriterio = "WHERE RSNUM = '" + linealOpcsTemp.Rsnum + "' "
                            + "AND MATNR IS NOT NULL "
                            + "AND WERKS = '" + idCentro + "' "
                            + "AND AUFNR = '" + linealOpcsTemp.Aufnr + "' ";
                        //+"AND LGORT = '' ";
                        ClsResbCollection lResbColle = new ClsResbBAL().ConsultarResbBAL(gsCriterio);

                        //if (lResbColle.Count == 0)
                        //{
                        //    gsMensaje = "";
                        //    gsMensaje = "Ingrese almacen en lista de materiales de orden '" + resb1ra.Aufnr + "' ";
                        //    textCodigoProducto.SelectAll();
                        //    textCodigoProducto.Focus();
                        //    gvError = true;
                        //    break;
                        //}
                        if (lResbColle.Count > 0)
                        {
                            lrsum = lResbColle[0].Rsnum;
                            textOrden.Text = linealOpcsTemp.Aufnr;
                            datos.PrimeraOrden = linealOpcsTemp.Aufnr;
                            datos.PrimerMaterial = gvMatnr;
                            datos.MaximoXCaja = lcantActualOrden;
                            datos.TipoPrimera = "L";
                            datos.Lgort1 = linealOpcsTemp.Lgort;
                        }
                        else
                        {
                            gsMensaje = "No existe lista de materiales de orden '" + resb1ra.Aufnr + "' ";
                            textCodigoProducto.SelectAll();
                            textCodigoProducto.Focus();
                            gvError = true;
                            return;
                        }

                        gsEtiq.Charg = linealOpcsTemp.Lgort;
                        gsCriterio = "WHERE AUFNR = '" + resb1ra.Aufnr + "' "
                                + "AND WERKS = '" + idCentro + "' AND"
                                + " POTX1 = '" + gvMatnr + "'";
                        //+"AND LGORT = '' ";
                        lResbColle = new ClsResbBAL().ConsultarResbBAL(gsCriterio);

                        if (lResbColle.Count > 0)
                        {
                            datos.TipoPrimera = "P";
                            str1 = lResbColle[0].Potx1;
                            datos.MateriaPrima2 = lResbColle[0].Potx2;
                            datos.CodigoHijo2 = lResbColle[0].Potx3;
                        }


                        UpdateOtrosDatos(linealOpcsTemp.Psmng, gTotalCantidadCajas, gTotalCajas);

                        break;
                    }
                    else
                    {
                        lordenSinCapacidad = linealOpcsTemp.Aufnr;

                        continue;
                    }

                }

                if (!lordenSinCapacidad.Equals("") || gvError || (datos.PrimeraOrden).Equals(""))
                {
                    if ((datos.PrimeraOrden).Equals("") || (datos.PrimeraOrden).Equals(lordenSinCapacidad))
                    {
                        gvError = true;
                        if (lordenSinCapacidad.Equals(""))
                        {
                            gsMensaje = "";
                            gsMensaje = "No se encontró ninguna orden disponible";
                        }
                        else
                        {
                            gsMensaje = "";
                            gsMensaje = "La orden " + lordenSinCapacidad + " no tiene cantidad disponible";
                            textEntregado.Text = "0";
                            textProducirCajas.Text = "0";
                            textOrden.Text = "";
                            datos = new ClsDatosHU();
                        }

                    }

                }
            }
            else
            {
                gsMensaje = "";
                gsMensaje = "No se encuentra Orden de Producción para el material " + gvMatnr;
                return;
            }

        }

        public void ObtenerTatuaje()
        {
            DateTime lfecha;
            DateTime ltiempoProceso;
            int llength;

            llength = (textCodigoProducto.Text).Length;
            llength = llength - 1;

            //si el material es de importacion no se requiere tatuaje

            if (!((textCodigoProducto.Text).Substring((llength), 1).Equals("1")))
            {
                return;
            }

            DateTime hoy = DateTime.Now;
            TimeSpan diferencia = hoy - zTPPGrupoMat.Tiempo_Pro;
            ltiempoProceso = hoy.AddHours(diferencia.Hours);
            String lsfechaHoy;
            String lsfechaAntes = "";
            lsfechaHoy = hoy.Year.ToString() + hoy.Month.ToString().PadLeft(2, '0') + hoy.Day.ToString().PadLeft(2, '0');

            //Cuando es matanza

            if (zTPPGrupoMat.Procedimiento.Equals("MT"))
            {

                gsCriterio = "WHERE "
                + "WERKS = '" + idCentro + "' AND FECHA = '" + lsfechaHoy + "' AND HORA_CONT BETWEEN '" + ltiempoProceso.Hour + ":" + ltiempoProceso.Minute + ":" + ltiempoProceso.Second + "' "
                + "AND '" + hoy.Hour + ":" + hoy.Minute + ":" + hoy.Second + "' ORDER BY FECHA_CONT DESC, HORA_CONT DESC";
                lfatomCollection = new CLSFatomBAL().MostrarFatomBAL(gsCriterio);
                if (lfatomCollection.Count > 0)
                {
                    textTatuaje.Text = lfatomCollection[0].Tatuaje;
                    textFecMatanza.Text = "" + lfatomCollection[0].Fecha;
                }
                else
                {
                    lfecha = hoy.AddDays(-4);
                    lsfechaAntes = lfecha.Year.ToString() + lfecha.Month.ToString().PadLeft(2, '0') + lfecha.Day.ToString().PadLeft(2, '0') + " 00:00:00";
                    lfatomCollection = new CLSFatomBAL().MostrarFatomBAL("WHERE "
                    + "WERKS = '" + idCentro + "' AND FECHA "
                    + "BETWEEN '" + lsfechaAntes + "' AND '" + lsfechaHoy + " 23:59:59' "
                    + "ORDER BY FECHA_CONT DESC, HORA_CONT DESC");

                    if (lfatomCollection.Count > 0)
                    {
                        textTatuaje.Text = lfatomCollection[0].Tatuaje;
                        textFecMatanza.Text = "" + lfatomCollection[0].Fecha;
                    }
                }
            }

            //Cuando son las demas

            IEnumerator numObjs = grProcedimiento.GetEnumerator();
            bool banPro = false;
            while (numObjs.MoveNext())
            {
                ClsProcedimientos proce = (ClsProcedimientos)numObjs.Current;
                if (proce.Low.Equals(zTPPGrupoMat.Procedimiento))
                {
                    banPro = true;
                    break;
                }
            }

            if (banPro)
            {
                string lscriterio = "WHERE "
                    + " WERKS = '" + idCentro + "' AND PROCEDIMIENTO = '" + zTPPGrupoMat.Procedimiento + "' "
                    + " AND FECHA = '" + lsfechaHoy + "' AND HORA BETWEEN '" + ltiempoProceso.Hour + ":" + ltiempoProceso.Minute + ":" + ltiempoProceso.Second + "' AND '" + hoy.Hour + ":" + hoy.Minute + ":" + hoy.Second + "' "
                    + " ORDER BY FECHA DESC, HORA DESC";
                ztppTrazabiCol = new ClsZTPPTrazabiBAL().ConsultarZTPPTrazabiBAL(lscriterio);
                if (ztppTrazabiCol.Count > 0)
                {
                    textTatuaje.Text = "" + ztppTrazabiCol[0].Tatuaje;
                    textFecMatanza.Text = "" + ztppTrazabiCol[0].Fechamatanza;
                }
                else
                {
                    lfecha = hoy.AddDays(-7);
                    lsfechaAntes = lfecha.Year.ToString() + lfecha.Month.ToString().PadLeft(2, '0') + lfecha.Day.ToString().PadLeft(2, '0') + " 00:00:00";
                    ztppTrazabiCol = new ClsZTPPTrazabiBAL().ConsultarZTPPTrazabiBAL("WHERE "
                    + " WERKS = '" + idCentro + "' AND PROCEDIMIENTO = '" + zTPPGrupoMat.Procedimiento + "' "
                    + " AND FECHA BETWEEN '" + lsfechaAntes + "' AND '" + lsfechaHoy + "' "
                    + " ORDER BY FECHA DESC, HORA DESC");
                    if (ztppTrazabiCol.Count > 0)
                    {
                        textTatuaje.Text = "" + ztppTrazabiCol[0].Tatuaje;
                        textFecMatanza.Text = "" + ztppTrazabiCol[0].Fechamatanza;
                    }

                }

            }

        }

        public void UpdateOtrosDatos(double p_kgsprd, double p_entreg, double p_cjs)
        {
            textProducirCajas.Text = p_cjs + "";
            textProducirkgs.Text = p_kgsprd + "";
            textEntregado.Text = p_entreg + "";
            if (p_kgsprd > 0)
            {
                textTratado.Text = "" + (100 * p_entreg) / p_kgsprd;
            }



        }

        public void Producto(int pIOrden, string psMatnr, string psAufnr, string psPlnty, string psPlnnr)
        {
            string lslote;

            //Obtener lote del material

            ClsOPCSCollection lopcsColl = new ClsOPCSBAL().ConsultarOPCSBAL("WHERE AUFNR = '" + psAufnr + "' "
                + "AND MATNR = '" + psMatnr + "' AND CHARG IS NOT NULL");
            if (lopcsColl.Count > 0)
            {
                lslote = lopcsColl[0].Charg;
                if (gsEtiq.Charg.Equals(""))
                {
                    gsEtiq.Charg = lslote;
                }

                if ((textLote.Text).Equals(""))
                {
                    textLote.Text = lslote;
                }

                switch (pIOrden)
                {
                    case 1:
                        datos.CalculaFc1 = "X";
                        datos.Lote1 = lslote;
                        break;
                    case 2:
                        datos.CalculaFc1 = "X";
                        datos.Lote2 = lslote;
                        break;
                    case 3:
                        datos.CalculaFc1 = "X";
                        datos.Lote3 = lslote;
                        break;
                }
                string lsCriterio = "";

                //operaciones o faces a notificar

                switch (pIOrden)
                {
                    case 1:
                        gsCriterio = "WHERE PLNTY = '" + psPlnty + "' "
                            + "AND PLNNR = '" + psPlnnr + "'";
                        // + "AND PHFLG = 'X'";
                        plpo1Ra = new ClsPLPOBAL().ConsultarPLPOBAL(gsCriterio);
                        break;
                    case 2:
                        gsCriterio = "WHERE PLNTY = '" + psPlnty + "' "
                            + "AND PLNNR = '" + psPlnnr + "' ";
                        //+ "AND PHFLG = 'X'";
                        plpo2Da = new ClsPLPOBAL().ConsultarPLPOBAL(gsCriterio);
                        break;
                    case 3:
                        gsCriterio = "WHERE PLNTY = '" + psPlnty + "' "
                            + "AND PLNNR = '" + psPlnnr + "' ";
                        // + "AND PHFLG = 'X'";
                        plpo3Ra = new ClsPLPOBAL().ConsultarPLPOBAL(gsCriterio);
                        break;
                }

            }
            else
            {
                String lsMensaje;
                lsMensaje = "El material de cabecera '" + psMatnr + "' no tiene lote";
                textCodigoProducto.SelectAll();
                textCodigoProducto.Focus();
                throw new Exception(lsMensaje);
            }



        }

        public void validaMaterialReal(string psMatnr)
        {
            string lmagrv;
            string lpaisDeOrigen;
            //Validar material

            //norma de embalaje
            ClsMARACollection maraCols = new ClsMARABAL().ConsultarMARABAL("WHERE "
                + "MATNR = '" + psMatnr + "'");

            if (maraCols.Count == 0)
            {
                string lsMensaje;
                textCodigoProducto.Focus();
                textCodigoProducto.SelectAll();
                lsMensaje = "Material sin norma de embalaje";
                throw new Exception(lsMensaje);
            }

            lmagrv = maraCols[0].Magrv;
            textNombreProducto.Text = maraCols[0].Maktx;
            gsEtiq.Etiar = maraCols[0].Etiar;
            gsEtiq.DiasCad = maraCols[0].Mhdhb;
            gsEtiq.Etifo = maraCols[0].Etifo;
            lpaisDeOrigen = maraCols[0].Herkl;


            if ((maraCols[0].Etiar).Equals(""))
            {
                string lsMensaje;
                textCodigoProducto.Focus();
                textCodigoProducto.SelectAll();
                lsMensaje = "No se definió etiqueta para el material ";
                lsMensaje = lsMensaje + "" + psMatnr + " Verifique MARA-ETIAR'";
                throw new Exception(lsMensaje);
            }
            string tipo;
            tipo = textTipoProducto.Text;

            switch (tipo)
            {
                case "11":
                    textNombreTipo.Text = "VACIO";
                    break;
                case "12":
                    textNombreTipo.Text = "CONGELADO";
                    break;
                case "13":
                    textNombreTipo.Text = "FRESCO";
                    break;
                default:
                    string lsMensaje;
                    textPesoBruto.Focus();
                    textPesoBruto.SelectAll();
                    lsMensaje = "Tipo de producto no valido";
                    throw new Exception(lsMensaje);
            }

            gsEtiq.Matnr = psMatnr;
            gsEtiq.Maktx = textNombreProducto.Text;

        }

        public void getCantidadEmbalada(string pAufnr)
        {
            double ltotalCanCajas = 0.0;


            ClsZTPPLogsCollection ztppLogsCol;
            gsCriterio = "WHERE "
                + "WERKS = '" + idCentro + "' AND AUFNR = '" + pAufnr + "' AND len(MOV_HU) > 0";
            ztppLogsCol = new ClsZTPPLogsBAL().ConsultarZTPPLogsBAL(gsCriterio);
            bool ban = false;
            if (ztppLogsCol.Count > 0)
            {
                ban = true;
            }

            if (ban)
            {
                IEnumerator totalLogs = ztppLogsCol.GetEnumerator();
                int e = 0;
                while (totalLogs.MoveNext())
                {
                    ltotalCanCajas = ltotalCanCajas + ztppLogsCol[e].Vemng;
                    e++;
                }
                gTotalCantidadCajas = ltotalCanCajas;
                gTotalCajas = e + 1;
            }

        }

        public void fillRangoProc()
        {
            grProcedimiento = new ClsProcedimientosCollection();
            ClsProcedimientos proce1 = new ClsProcedimientos("CE"); //cortes especiales
            grProcedimiento.Add(proce1);

            proce1 = new ClsProcedimientos("VA");//valor agregado
            grProcedimiento.Add(proce1);

            proce1 = new ClsProcedimientos("MN");//mantequera
            grProcedimiento.Add(proce1);

            proce1 = new ClsProcedimientos("CR");//cortes regulares
            grProcedimiento.Add(proce1);

            proce1 = new ClsProcedimientos("RE");//relajados
            grProcedimiento.Add(proce1);
        }

        private void PuertoSerial()
        {

            //string codFatom = puertoFatom + settingFatom;
            string waBascula;
            string peso = "";
            int cont = 0;
            int cont2 = 0;
            int longitud = 0;
            int maxPos = 0;
            int indice;

            if (nombreBascula == "MANUAL") { return; }

            if (puertoS.IsOpen) { CerrarPuerto(); }

            peso = "";
            textPesoBruto.Clear();

            while (cont < 4)
            {
                if (textPesoBruto.Text != "")
                {
                    break;
                }
                AbrirPuerto();
                waBascula = "";
                InitComPort(setteoBascula);
                waBascula = puertoS.ReadLine().Trim();
                longitud = waBascula.Length;
                maxPos = longitud - 11;
                if (maxPos < 0) { break; }
                indice = 0;
                do
                {
                    if (waBascula + indice.ToString() == "")
                    {
                        waBascula = waBascula + indice.ToString();
                        if (waBascula.Length > maxPos) { break; }
                        peso = waBascula;
                        try
                        {
                            textPesoBruto.Text = peso;
                            CerrarPuerto();
                        }
                        catch (Exception)
                        {

                            throw new Exception("Error en lectura de báscula");
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

        private void FrmHuInterfazCaja_Activated(object sender, EventArgs e)
        {
            textCodigoProducto.Focus();
        }

        private void FrmHuInterfazCaja_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    textTratado.Text = 0 + "";
                    textEntregado.Text = 0 + "";
                    textProducirCajas.Text = 0 + "";
                    Validar();
                    ValidarProceso();
                    int ldProCaj = int.Parse(textProducirCajas.Text);
                    if (ldProCaj >= 1)
                    {
                        int ldProCajRes = ldProCaj - 1;
                        textProducirCajas.Text = ldProCajRes + "";
                    }


                    if (gvError)
                    {
                        throw new Exception(gsMensaje);
                    }

                }
                else if (e.KeyCode == Keys.F8)
                {
                    unEnter();
                    textTratado.Text = 0 + "";
                    textEntregado.Text = 0 + "";
                    textProducirCajas.Text = 0 + "";

                    Validar();
                    ValidarProceso();

                    ValidarValidarProcesoEjecutar();

                    double ldPesoN = double.Parse(textPesoNeto.Text);
                    if ((int.Parse(textProducirCajas.Text)) != 0)
                    {
                        double ldEntre = (double.Parse(textEntregado.Text)) + (double.Parse(textPesoNeto.Text));
                        textEntregado.Text = ldEntre + "";
                    }

                }

            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }

        public void EjecutaProceso2daP()
        {

            ClsZTPPLogs logs = new ClsZTPPLogs();
            ClsZTPPLogsBAL logsBal = new ClsZTPPLogsBAL();
            gvPosicion = 1;
            DateTime hoy = DateTime.Now;

            logs.Proceso = "EM";
            logs.Aufnr = datos.SegundaOrden;
            logs.Vornr = "";
            logs.Exidv = gvNoCaja;
            logs.Fecha = hoy;
            logs.Hora = hoy;
            logs.Matnr = datos.SegundoMaterial;
            logs.Vemng = datos.CantidadCaja;
            logs.Icon = cIconError;
            logs.Message = "Registro Generado por SC";
            logs.Mblnr = "";
            logs.Mjahr = 0;
            logs.Rueck = 0;
            logs.Rmzhl = 0;
            logs.Bwart = c101;
            logs.Werks = idCentro;
            logs.Posicion = gvPosicion;
            logs.Mov_hu = "";
            logs.Lgort = datos.Lgort2;
            logs.Tipo_en = "P";
            logsBal.AgregarZTPPLogsBAL(logs);

            ClsZTPPLogs logsT = new ClsZTPPLogs();
            IEnumerator NumPlpo2Da = plpo2Da.GetEnumerator();
            ClsPLPO plpoTemp;
            while (NumPlpo2Da.MoveNext())
            {
                plpoTemp = (ClsPLPO)NumPlpo2Da.Current;
                gvPosicion++;
                logsT.Proceso = "NOT";
                logsT.Aufnr = datos.SegundaOrden;
                logsT.Vornr = plpoTemp.Vornr;
                logsT.Exidv = gvNoCaja;
                logsT.Fecha = hoy;
                logsT.Hora = hoy;
                logsT.Matnr = datos.SegundoMaterial;
                logsT.Vemng = datos.CantidadCaja;
                logsT.Icon = cIconError;
                logsT.Message = "Registro Generado por SC";
                logsT.Mblnr = "";
                logsT.Mjahr = 0;
                logsT.Rueck = 0;
                logsT.Rmzhl = 0;
                logsT.Bwart = "";
                logsT.Werks = idCentro;
                logsT.Posicion = gvPosicion;
                logsT.Mov_hu = "";
                logsT.Lgort = datos.Lgort2;
                logs.Tipo_en = "P";
                logsBal.AgregarZTPPLogsBAL(logsT);
            }


            gsCriterio = " INNER JOIN MARA ON RESB.MATNR = MARA.MATNR WHERE RESB.RSNUM = '" + datos.SegundaRsnum + "' "
                + "AND RESB.WERKS = '" + idCentro + "' "
                + "AND RESB.BWART = '" + c261 + "' "
                + "AND MARA.MTART <> 'VERP' "
                + "AND MARA.XCHPF = 'X'";
            ClsResbCollection resCollTem = new ClsResbBAL().ConsultarResbBAL(gsCriterio);



            if (resCollTem.Count == 1)
            {
                gvPosicion++;
                logsT.Proceso = "SM";
                logsT.Aufnr = datos.SegundaOrden;
                logsT.Vornr = "";
                logsT.Exidv = gvNoCaja;
                logsT.Fecha = hoy;
                logsT.Hora = hoy;
                logsT.Matnr = datos.MateriaPrima2;
                logsT.Vemng = datos.CantidadCaja;
                logsT.Icon = cIconError;
                logsT.Message = "Registro Generado por SC";
                logsT.Mblnr = "";
                logsT.Mjahr = 0;
                logsT.Rueck = 0;
                logsT.Rmzhl = 0;
                logsT.Bwart = c261;
                logsT.Werks = idCentro;
                logsT.Posicion = gvPosicion;
                logsT.Mov_hu = "";
                logsT.Lgort = datos.Lgort2;
                logs.Tipo_en = "P";
                logsBal.AgregarZTPPLogsBAL(logsT);
            }
            else
            {
                gvPosicion++;
                logsT.Proceso = "SM";
                logsT.Aufnr = datos.SegundaOrden;
                logsT.Vornr = "";
                logsT.Exidv = gvNoCaja;
                logsT.Fecha = hoy;
                logsT.Hora = hoy;
                logsT.Matnr = "";
                logsT.Vemng = 0;
                logsT.Icon = cIconError;
                logsT.Message = "Registro Generado por SC";
                logsT.Mblnr = "";
                logsT.Mjahr = 0;
                logsT.Rueck = 0;
                logsT.Rmzhl = 0;
                logsT.Bwart = c261;
                logsT.Werks = idCentro;
                logsT.Posicion = gvPosicion;
                logsT.Mov_hu = "";
                logsT.Lgort = datos.Lgort2;
                logs.Tipo_en = "P";
                logsBal.AgregarZTPPLogsBAL(logsT);
            }

        }

        public void EjecutaProceso3raP()
        {
            ClsZTPPLogs logs = new ClsZTPPLogs();
            ClsZTPPLogsBAL logsBal = new ClsZTPPLogsBAL();
            gvPosicion++;
            DateTime hoy = DateTime.Now;

            logs.Proceso = "EM";
            logs.Aufnr = datos.TerceraOrden;
            logs.Vornr = "";
            logs.Exidv = gvNoCaja;
            logs.Fecha = hoy;
            logs.Hora = hoy;
            logs.Matnr = datos.TercerMaterial;
            logs.Vemng = datos.CantidadCaja;
            logs.Icon = cIconError;
            logs.Message = "Registro Generado por SC";
            logs.Mblnr = "";
            logs.Mjahr = 0;
            logs.Rueck = 0;
            logs.Rmzhl = 0;
            logs.Bwart = c101;
            logs.Werks = idCentro;
            logs.Posicion = gvPosicion;
            logs.Mov_hu = "";
            logs.Lgort = datos.Lgort3;
            logs.Tipo_en = "P";
            logsBal.AgregarZTPPLogsBAL(logs);

            ClsZTPPLogs logsT = new ClsZTPPLogs();
            IEnumerator NumPlpo3Ra = plpo3Ra.GetEnumerator();
            ClsPLPO plpoTemp = new ClsPLPO();
            while (NumPlpo3Ra.MoveNext())
            {
                plpoTemp = (ClsPLPO)NumPlpo3Ra.Current;
                gvPosicion++;
                logsT.Proceso = "NOT";
                logsT.Aufnr = datos.TerceraOrden;
                logsT.Vornr = plpoTemp.Vornr;
                logsT.Exidv = gvNoCaja;
                logsT.Fecha = hoy;
                logsT.Hora = hoy;
                logsT.Matnr = datos.TercerMaterial;
                logsT.Vemng = datos.CantidadCaja;
                logsT.Icon = cIconError;
                logsT.Message = "Registro Generado por SC";
                logsT.Mblnr = "";
                logsT.Mjahr = 0;
                logsT.Rueck = 0;
                logsT.Rmzhl = 0;
                logsT.Bwart = "";
                logsT.Werks = idCentro;
                logsT.Posicion = gvPosicion;
                logsT.Mov_hu = "";
                logs.Tipo_en = "P";
                logsT.Lgort = datos.Lgort3;

                logsBal.AgregarZTPPLogsBAL(logsT);
            }


            gsCriterio = " INNER JOIN MARA ON RESB.MATNR = MARA.MATNR WHERE RESB.RSNUM = '" + datos.TerceraRsnum + "' "
                + "AND RESB.WERKS = '" + idCentro + "' "
                + "AND RESB.BWART = '" + c261 + "' "
                + "AND MARA.MTART <> 'VERP' "
                + "AND MARA.XCHPF = 'X'";
            ClsResbCollection resCollTem = new ClsResbBAL().ConsultarResbBAL(gsCriterio);



            if (resCollTem.Count == 1)
            {
                gvPosicion++;
                logsT.Proceso = "SM";
                logsT.Aufnr = datos.TerceraOrden;
                logsT.Vornr = "";
                logsT.Exidv = gvNoCaja;
                logsT.Fecha = hoy;
                logsT.Hora = hoy;
                logsT.Matnr = datos.MateriaPrima3;
                logsT.Vemng = datos.CantidadCaja;
                logsT.Icon = cIconError;
                logsT.Message = "Registro Generado por SC";
                logsT.Mblnr = "";
                logsT.Mjahr = 0;
                logsT.Rueck = 0;
                logsT.Rmzhl = 0;
                logsT.Bwart = c261;
                logsT.Werks = idCentro;
                logsT.Posicion = gvPosicion;
                logsT.Mov_hu = "";
                logs.Tipo_en = "P";
                logsT.Lgort = datos.Lgort3;
                logsBal.AgregarZTPPLogsBAL(logsT);
            }
            else
            {
                gvPosicion++;
                logsT.Proceso = "SM";
                logsT.Aufnr = datos.TerceraOrden;
                logsT.Vornr = "";
                logsT.Exidv = gvNoCaja;
                logsT.Fecha = hoy;
                logsT.Hora = hoy;
                logsT.Matnr = "";
                logsT.Vemng = 0;
                logsT.Icon = cIconError;
                logsT.Message = "Registro Generado por SC";
                logsT.Mblnr = "";
                logsT.Mjahr = 0;
                logsT.Rueck = 0;
                logsT.Rmzhl = 0;
                logsT.Bwart = c261;
                logsT.Werks = idCentro;
                logsT.Posicion = gvPosicion;
                logsT.Mov_hu = "";
                logs.Tipo_en = "P";
                logsT.Lgort = datos.Lgort3;
                logsBal.AgregarZTPPLogsBAL(logsT);
            }



        }

        public void EjecutaProceso3raS()
        {
            ClsZTPPLogs logs = new ClsZTPPLogs();
            ClsZTPPLogsBAL logsBal = new ClsZTPPLogsBAL();
            gvPosicion++;
            string lbwart = "";
            DateTime hoy = DateTime.Now;

            gsCriterio = "WHERE RSNUM = '" + resb3ra.Rsnum + "' "
                + " AND AUFNR = '" + resb3ra.Aufnr + "'"
                + " AND MATNR = '" + datos.TercerMaterial + "'";

            ClsResbCollection resbtempoColl = new ClsResbBAL().ConsultarResbBAL(gsCriterio);
            if (resbtempoColl.Count > 0)
            {
                lbwart = resbtempoColl[0].Bwart;
            }



            logs.Proceso = "EM";
            logs.Aufnr = datos.TerceraOrden;
            logs.Vornr = "";
            logs.Exidv = gvNoCaja;
            logs.Fecha = hoy;
            logs.Hora = hoy;
            logs.Matnr = datos.TercerMaterial;
            logs.Vemng = datos.CantidadCaja;
            logs.Icon = cIconError;
            logs.Message = "Registro Generado por SC";
            logs.Mblnr = "";
            logs.Mjahr = 0;
            logs.Rueck = 0;
            logs.Rmzhl = 0;
            logs.Bwart = lbwart;
            logs.Werks = idCentro;
            logs.Posicion = gvPosicion;
            logs.Mov_hu = "";
            logs.Lgort = datos.Lgort3;
            logs.Tipo_en = "S";

            logsBal.AgregarZTPPLogsBAL(logs);
            ClsZTPPLogs logsT = new ClsZTPPLogs();


            gsCriterio = " INNER JOIN MARA ON RESB.MATNR = MARA.MATNR WHERE RESB.RSNUM = '" + datos.TerceraRsnum + "' "
                + "AND RESB.WERKS = '" + idCentro + "' "
                + "AND RESB.BWART = '" + c261 + "' "
                + "AND MARA.MTART <> 'VERP' "
                + "AND MARA.XCHPF = 'X'";

            ClsResbCollection resCollTem = new ClsResbBAL().ConsultarResbBAL(gsCriterio);

            if (resCollTem.Count == 1)
            {
                gvPosicion++;
                logsT.Proceso = "SM";
                logsT.Aufnr = datos.TerceraOrden;
                logsT.Vornr = "";
                logsT.Exidv = gvNoCaja;
                logsT.Fecha = hoy;
                logsT.Hora = hoy;
                logsT.Matnr = datos.MateriaPrima3;
                logsT.Vemng = datos.CantidadCaja;
                logsT.Icon = cIconError;
                logsT.Message = "Registro Generado por SC";
                logsT.Mblnr = "";
                logsT.Mjahr = 0;
                logsT.Rueck = 0;
                logsT.Rmzhl = 0;
                logsT.Bwart = c261;
                logsT.Werks = idCentro;
                logsT.Posicion = gvPosicion;
                logsT.Mov_hu = "";
                logsT.Lgort = datos.Lgort3;
                logs.Tipo_en = "S";
                logsBal.AgregarZTPPLogsBAL(logsT);
            }
            else
            {
                gvPosicion++;
                logsT.Proceso = "SM";
                logsT.Aufnr = datos.TerceraOrden;
                logsT.Vornr = "";
                logsT.Exidv = gvNoCaja;
                logsT.Fecha = hoy;
                logsT.Hora = hoy;
                logsT.Matnr = "";
                logsT.Vemng = 0;
                logsT.Icon = cIconError;
                logsT.Message = "Registro Generado por SC";
                logsT.Mblnr = "";
                logsT.Mjahr = 0;
                logsT.Rueck = 0;
                logsT.Rmzhl = 0;
                logsT.Bwart = c261;
                logsT.Werks = idCentro;
                logsT.Posicion = gvPosicion;
                logsT.Mov_hu = "";
                logsT.Lgort = datos.Lgort3;
                logs.Tipo_en = "S";
                logsBal.AgregarZTPPLogsBAL(logsT);
            }
        }

        public void EjecutaProcesos2daS()
        {
            ClsZTPPLogs logs = new ClsZTPPLogs();
            ClsZTPPLogsBAL logsBal = new ClsZTPPLogsBAL();
            gvPosicion = 1;
            string lbwart = "";
            DateTime hoy = DateTime.Now;

            gsCriterio = "WHERE RSNUM = '" + datos.SegundaRsnum + "' "
                + " AND AUFNR = '" + datos.SegundaOrden + "'"
                + " AND MATNR = '" + datos.SegundoMaterial + "'";

            ClsResbCollection resbtempoColl = new ClsResbBAL().ConsultarResbBAL(gsCriterio);
            if (resbtempoColl.Count > 0)
            {
                lbwart = resbtempoColl[0].Bwart;
            }



            logs.Proceso = "EM";
            logs.Aufnr = datos.SegundaOrden;
            logs.Vornr = "";
            logs.Exidv = gvNoCaja;
            logs.Fecha = hoy;
            logs.Hora = hoy;
            logs.Matnr = datos.SegundoMaterial;
            logs.Vemng = datos.CantidadCaja;
            logs.Icon = cIconError;
            logs.Message = "Registro Generado por SC";
            logs.Mblnr = "";
            logs.Mjahr = 0;
            logs.Rueck = 0;
            logs.Rmzhl = 0;
            logs.Bwart = lbwart;
            logs.Werks = idCentro;
            logs.Posicion = gvPosicion;
            logs.Mov_hu = "";
            logs.Lgort = datos.Lgort2;
            logs.Tipo_en = "S";
            logsBal.AgregarZTPPLogsBAL(logs);
            ClsZTPPLogs logsT = new ClsZTPPLogs();


            gsCriterio = " INNER JOIN MARA ON RESB.MATNR = MARA.MATNR WHERE RESB.RSNUM = '" + datos.SegundaRsnum + "' "
                + "AND RESB.WERKS = '" + idCentro + "' "
                + "AND RESB.BWART = '" + c261 + "' "
                + "AND MARA.MTART <> 'VERP' "
                + "AND MARA.XCHPF = 'X'";

            ClsResbCollection resCollTem = new ClsResbBAL().ConsultarResbBAL(gsCriterio);

            if (resCollTem.Count == 1)
            {
                gvPosicion++;
                logsT.Proceso = "SM";
                logsT.Aufnr = datos.SegundaOrden;
                logsT.Vornr = "";
                logsT.Exidv = gvNoCaja;
                logsT.Fecha = hoy;
                logsT.Hora = hoy;
                logsT.Matnr = datos.MateriaPrima2;
                logsT.Vemng = datos.CantidadCaja;
                logsT.Icon = cIconError;
                logsT.Message = "Registro Generado por SC";
                logsT.Mblnr = "";
                logsT.Mjahr = 0;
                logsT.Rueck = 0;
                logsT.Rmzhl = 0;
                logsT.Bwart = c261;
                logsT.Werks = idCentro;
                logsT.Posicion = gvPosicion;
                logsT.Mov_hu = "";
                logsT.Lgort = datos.Lgort2;
                logs.Tipo_en = "S";
                logsBal.AgregarZTPPLogsBAL(logsT);
            }
            else
            {
                gvPosicion++;
                logsT.Proceso = "SM";
                logsT.Aufnr = datos.SegundaOrden;
                logsT.Vornr = "";
                logsT.Exidv = gvNoCaja;
                logsT.Fecha = hoy;
                logsT.Hora = hoy;
                logsT.Matnr = "";
                logsT.Vemng = 0;
                logsT.Icon = cIconError;
                logsT.Message = "Registro Generado por SC";
                logsT.Mblnr = "";
                logsT.Mjahr = 0;
                logsT.Rueck = 0;
                logsT.Rmzhl = 0;
                logsT.Bwart = c261;
                logsT.Werks = idCentro;
                logsT.Posicion = gvPosicion;
                logsT.Mov_hu = "";
                logsT.Lgort = datos.Lgort2;
                logs.Tipo_en = "S";
                logsBal.AgregarZTPPLogsBAL(logsT);
            }
        }

        public void EjecutaProcesos1raP(string psTipoEn)
        {
            ClsZTPPLogs logs = new ClsZTPPLogs();
            ClsZTPPLogsBAL logsBal = new ClsZTPPLogsBAL();
            gvPosicion++;
            DateTime hoy = DateTime.Now;

            logs.Proceso = "EM";
            logs.Aufnr = datos.PrimeraOrden;
            logs.Vornr = "";
            logs.Exidv = gvNoCaja;
            logs.Fecha = hoy;
            logs.Hora = hoy;
            logs.Matnr = datos.PrimerMaterial;
            logs.Vemng = datos.CantidadCaja;
            logs.Icon = cIconError;
            logs.Message = "Registro Generado por SC";
            logs.Mblnr = "";
            logs.Mjahr = 0;
            logs.Rueck = 0;
            logs.Rmzhl = 0;
            logs.Bwart = c101;
            logs.Werks = idCentro;
            logs.Posicion = gvPosicion;
            logs.Mov_hu = "X";
            logs.Lgort = datos.Lgort1;
            logs.Tipo_en = psTipoEn;
            logsBal.AgregarZTPPLogsBAL(logs);

            ClsZTPPLogs logsT = new ClsZTPPLogs();
            IEnumerator NumPlpo1Ra = plpo1Ra.GetEnumerator();
            ClsPLPO plpoTemp;

            while (NumPlpo1Ra.MoveNext())
            {
                plpoTemp = (ClsPLPO)NumPlpo1Ra.Current;
                gvPosicion++;
                logsT.Proceso = "NOT";
                logsT.Aufnr = datos.PrimeraOrden;
                logsT.Vornr = plpoTemp.Vornr;
                logsT.Exidv = gvNoCaja;
                logsT.Fecha = hoy;
                logsT.Hora = hoy;
                logsT.Matnr = datos.PrimerMaterial;
                logsT.Vemng = datos.CantidadCaja;
                logsT.Icon = cIconError;
                logsT.Message = "Registro Generado por SC";
                logsT.Mblnr = "";
                logsT.Mjahr = 0;
                logsT.Rueck = 0;
                logsT.Rmzhl = 0;
                logsT.Bwart = "";
                logsT.Werks = idCentro;
                logsT.Posicion = gvPosicion;
                logsT.Mov_hu = "";
                logsT.Lgort = datos.Lgort1;
                logs.Tipo_en = psTipoEn;
                logsBal.AgregarZTPPLogsBAL(logsT);
            }




            gvPosicion++;
            logsT.Proceso = "SM";
            logsT.Aufnr = datos.PrimeraOrden;
            logsT.Vornr = "";
            logsT.Exidv = gvNoCaja;
            logsT.Fecha = hoy;
            logsT.Hora = hoy;
            logsT.Matnr = "";
            logsT.Vemng = 0;
            logsT.Icon = cIconError;
            logsT.Message = "Registro Generado por SC";
            logsT.Mblnr = "";
            logsT.Mjahr = 0;
            logsT.Rueck = 0;
            logsT.Rmzhl = 0;
            logsT.Bwart = c261;
            logsT.Werks = idCentro;
            logsT.Posicion = gvPosicion;
            logsT.Mov_hu = "";
            logsT.Lgort = datos.Lgort1;
            logs.Tipo_en = psTipoEn;
            logsBal.AgregarZTPPLogsBAL(logsT);
        }

        private void textTara_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textTara);
        }

        private void textTara_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textTara);
        }

        public void limpiarVariables()
        {

            //gsEtiq        
            //mara;
            //mara2;
            //zTPPGrupoMat;
            //zTPPGrupoEmp;

            //ztppTrazabi;
            //ztppTrazabiCol;
            //lfatomCollection;
            //resb;
            resb1raColl = new ClsResbCollection();
            resb2daColl = new ClsResbCollection();
            resb3raColl = new ClsResbCollection();
            resb1ra = new ClsResb();
            resb2da = new ClsResb();
            resb3ra = new ClsResb();
            opcs = new ClsOPCS();
            opcsColl = new ClsOPCSCollection();

            ztppLogs = new ClsZTPPLogs();

            datos = new ClsDatosHU();
            plpo1Ra = new ClsPLPOCollection();
            plpo2Da = new ClsPLPOCollection();
            plpo3Ra = new ClsPLPOCollection();
            gvError = false;
            gvNoCaja = "";
            linealopCol = new ClsOPCSCollection();

            l_material_gt_sub = "";

            pSegundoMaterial = "";


            gvPosicion = 0;

        }

        public string GetImpresoraDefecto()
        {
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                PrinterSettings a = new PrinterSettings();
                a.PrinterName = PrinterSettings.InstalledPrinters[i].ToString();
                if (a.IsDefaultPrinter)
                {
                    return PrinterSettings.InstalledPrinters[i].ToString();

                }
            }
            return "No hay impresora Predeterminada";
        }

        public string Calcular12Digitos(double pdPeso, string psMatnr)
        {
            string Dig12 = "";
            string lsPeso = pdPeso + "";
            string lsDivMatn = "";

            string[] divPeso = lsPeso.Split('.');
            lsPeso = divPeso[0];
            if (lsPeso.Length > 2)
            {
                lsPeso = lsPeso.Remove(0, (lsPeso.Length - 2));
            }

            if (lsPeso.Length == 1)
            {
                lsPeso = "0" + lsPeso;
            }
            else if (lsPeso.Length == 0)
            {
                lsPeso = "00";
            }

            lsPeso = lsPeso + ".00";

            lsDivMatn = psMatnr.Substring(0, 6);

            Dig12 = "2" + lsDivMatn + lsPeso;

            return Dig12;

        }

        public string CalculateChecksumDigit(string psDig12)
        {
            string lsDigVer = "";
            string lsEan13 = "";

            if (psDig12.Length != 12)
            {
                throw new Exception("Deven ser 12 Digitos");
            }
            else
            {
                string sTemp = psDig12;
                int iSum = 0;
                int iDigit = 0;
                int posicion = 1;
                string sDig = "";
                string sPar = "";
                string sNon = "";
                int iPar = 0;
                int iNon = 0;
                double dPar = 0.0;
                double dNon = 0.0;
                int aux = 0;

                // Calculate the checksum digit here.
                for (int i = sTemp.Length; i > 0; i--)
                {
                    sDig = sTemp.Substring(posicion - 1, 1);
                    if (i % 2 == 0)
                    {    // even: para números pares se multiplica por 1
                        sNon += sDig;
                    }
                    else
                    {    // odd: para números impares se multiplica por el factor
                        sPar += sDig;
                    }
                    posicion = posicion + 1;

                }

                dPar = double.Parse(sPar);
                dPar = Math.Round(dPar, 0);
                iPar = int.Parse(dPar + "");



                dNon = double.Parse(sNon);
                dNon = Math.Round(dNon, 0);
                iNon = int.Parse(dNon + "");

                iPar = iPar * 3;
                aux = (iNon + iPar) / 10;
                aux = aux * 10;


                lsDigVer = "" + (iNon + iPar - aux);
                string[] sinPunto = psDig12.Split('.');
                psDig12 = sinPunto[0];
                lsEan13 = psDig12 + lsDigVer;
            }

            return lsEan13;


        }

        public void limpiarTodasVariables()
        {
            gsEtiq = new ClsZEtiqueta();
            gvMatnr = "";
            gsMensaje = "";
            gsCriterio = "";
            mara = new ClsMARA();
            mara2 = new ClsMARA();
            zTPPGrupoMat = new ClsZTPPGrupoMat();
            zTPPGrupoEmp = new ClsZTPPGrupoEmp();
            grProcedimiento = new ClsProcedimientosCollection();
            ztppTrazabi = new ClsZTPPTrazabi();
            ztppTrazabiCol = new ClsZTPPTrazabiCollection();
            lfatomCollection = new CLSFatomCollection();
            resb = new ClsResb();
            resb1raColl = new ClsResbCollection();
            resb2daColl = new ClsResbCollection();
            resb3raColl = new ClsResbCollection();
            resb1ra = new ClsResb();
            resb2da = new ClsResb();
            resb3ra = new ClsResb();
            opcs = new ClsOPCS();
            opcsColl = new ClsOPCSCollection();
            gTotalCantidadCajas = 0.0;
            gTotalCajas = 0.0;
            ztppLogs = new ClsZTPPLogs();
            lMensaje2 = "";
            datos = new ClsDatosHU();
            plpo1Ra = new ClsPLPOCollection();
            plpo2Da = new ClsPLPOCollection();
            plpo3Ra = new ClsPLPOCollection();
            gvError = false;
            gvNoCaja = "";
            linealopCol = new ClsOPCSCollection();

            l_material_gt_sub = "";
            pSegundoMaterial = "";
        }

        public void unEnter()
        {
            try
            {
                textTratado.Text = 0 + "";
                textEntregado.Text = 0 + "";
                textProducirCajas.Text = 0 + "";
                Validar();
                ValidarProceso();
                int ldProCaj = int.Parse(textProducirCajas.Text);
                if (ldProCaj >= 1)
                {
                    int ldProCajRes = ldProCaj - 1;
                    textProducirCajas.Text = ldProCajRes + "";
                }


                if (gvError)
                {
                    throw new Exception(gsMensaje);
                }
            }
            catch
            {
                throw new Exception(gsMensaje);
            }
        }

        private void textCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                textTipoProducto.Select();
                textTipoProducto.Focus();
            }
            if (e.KeyCode == Keys.Right)
            {
                textPesoBruto.Select();
                textPesoBruto.Focus();
            }
        }

        private void textTipoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                textCodigoProducto.Select();
                textCodigoProducto.Focus();
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Down)
            {
                textPesoBruto.Select();
                textPesoBruto.Focus();
            }
        }

        private void textPesoBruto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                textCodigoProducto.Select();
                textCodigoProducto.Focus();
            }
            if (e.KeyCode == Keys.Left)
            {
                textTipoProducto.Select();
                textTipoProducto.Focus();
            }
        }
    }
}