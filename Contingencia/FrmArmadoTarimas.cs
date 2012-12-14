using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
//using System.Drawing.Printing;

namespace Contingencia
{
    public partial class FrmArmadoTarimas : FrmBase
    {
        public ArrayList arrayCantidaItems = new ArrayList();
        ArrayList arrayNumCaja = new ArrayList();
        private ArrayList listaMat = new ArrayList();
        private ArrayList listaCantKil = new ArrayList();
        private string centro;
        bool btnRetAv;
        int liCont = 0;
        static int liIndice;
        static double liCantidadAux;
        string lsFolio = "";
        private int gIindice = 0;
        private ClsNumCaja numCaja;
        //private bool banFo = true;
        private long glfolio;
        private bool banGl = true;
        string lsNumCaja = "";
        string lsSQLAux = "";
        string lsWerks = "";
        bool lbCajaIDlogs;
        double liCantidad;
        string lsDesc = "";
        string lsDescMatnr = "";
        string lsLote = "";
        private string lsCodTarima;
        private string lsFechaArmado;
        private string lsTotalCajas;
        private double liTotalKilos;
        private string lsMatnrTarima;
        private string lsDescMatnrTarima;
        private decimal liTotalKilosMatnr;
        private int liTotalCajasMatnr;
        private string lsMatnr;
        private double totalKilosGral = 0.0;
        private static int nuevosRenglones = 39;
        string[,] aValoresTotales = new string[nuevosRenglones, 2];
        string cajasTarima = "";
        string tarima2D = "";
        int liContador = 0;

        //EtiquetaTarima

        private double resta = 0.0;
        private double EtotalPeso = 0.0;



        public FrmArmadoTarimas()
        {
            InitializeComponent();
        }

        private void FrmArmadoTarimas_Load(object sender, EventArgs e)
        {
            base.PonerTitulo("Armar Tarima");
            liCantidadAux = 0.0;
            txtbxCaja.Focus();
            txtbxCaja.Select();
        }

        private void txtbxCaja_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxCaja);
        }

        private void txtbxCaja_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxCaja);
        }

        private void txtbxAlmacen_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxAlmacen);
        }

        private void txtbxAlmacen_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxAlmacen);
        }

        private void pbxAlmacen_Click(object sender, EventArgs e)
        {
            ConsultarAlmacen();
        }

        private void ConsultarAlmacen()
        {
            DialogResult resultado;
            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            listaSeleccion.TipoCatalogo = "ALMACEN";
            listaSeleccion.IniciarForma();
            resultado = listaSeleccion.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                string lsClave = listaSeleccion.ClaveSel;
                txtbxAlmacen.Text = lsClave;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
            FrmZMASTERMenu menu = new FrmZMASTERMenu();
            menu.ShowDialog();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (arrayCantidaItems.Count == 0)
                {
                    txtbxCaja.Focus();
                    txtbxCaja.Select();
                    throw new Exception("No hay cajas en la tarima!");
                }

                imprimeDatos();
                base.MostrarMensaje("La Tarima " + glfolio + " se generó correctamente");
                arrayCantidaItems.Clear();
                arrayNumCaja.Clear();
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }

        private void btnSigCaja_Click(object sender, EventArgs e)
        {
            txtbxCaja.Text = "";
            txtbxAlmacen.Text = "";
            txtbxDenom.Text = "";
            txtbxEmbalada.Text = "";
            txtbxLote.Text = "";
            txtbxMaterial.Text = "";
            txtbxCaja.Focus();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                siguiente();
                btnRetAv = true;
               // banGl = false;
            }
            catch(Exception ex)
            {
                base.MostrarError(ex.Message);
            }

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                anterior();
                btnRetAv = false;
                //banGl = false;
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }

        }


        private void ValidaDatos()
        {

            ClsNumCaja numCaja = new ClsNumCaja();
            lsNumCaja = numCaja.BackCadena(txtbxCaja.Text.Trim());
            lsMatnr = numCaja.BackCadenaMatnr(txtbxCaja.Text.Trim());
            lsWerks = numCaja.BackCadenaWerks(txtbxCaja.Text.Trim());
            lbCajaIDlogs = numCaja.verificaIDcaja(lsNumCaja);
            liCantidad = numCaja.cantidadAcomulada(txtbxCaja.Text.Trim());
            lsDesc = numCaja.descripcion(lsMatnr, lsWerks);
            lsLote = numCaja.BackCadenaLote(txtbxCaja.Text.Trim());

            //Crear Coleccion para almacenar datos leidos de la BD
                ClsCatZMasterCollection coleccionCajas;

                if (txtbxCaja.Text.Trim().Length >= 30)
                {
                    lsSQLAux = "WHERE IDCaja =" + lsNumCaja + " and werks = '" + lsWerks + "' and (Desembalada = '' OR DESEMBALADA = ' ') and " +
                        "(borrado = '' OR BORRADO = ' ')";
                    try
                    {
                        coleccionCajas = (new ClsCatZMasterBAL()).ConsultarZMasterBAL(lsSQLAux);
                    }
                    catch (Exception)
                    {

                        throw new Exception("La caja esta asignada a una tarima en ZMASTER!");
                    }

                    if (coleccionCajas.Count != 0)
                    {
                        throw new Exception("La caja esta asignada a una tarima en ZMASTER!");
                    }
                    else
                    {
                        for (int i = 0; i < arrayNumCaja.Count; i++)
                        {
                            if (lsNumCaja == arrayNumCaja[i].ToString())
                            {
                                throw new Exception("La caja ya fue leida!");
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("No es un Codigo 2D valido!");
                }

            if (liContador == 0)
            {
                centro = lsWerks;
            }
            else
            {
                if (lsWerks != centro)
                {
                    throw new Exception("La caja " + lsNumCaja + " no pertenece al centro " + centro);
                }
            }
            liContador++;

            arrayNumCaja.Add(lsNumCaja);
            txtbxMaterial.Text = lsMatnr;
            txtbxAlmacen.Text = lsWerks;
            txtbxDenom.Text = lsDesc;
            txtbxLote.Text = lsLote;
            txtbxEmbalada.Text = liCantidad.ToString();
            txtbxCont.Text = (liContador).ToString();

            

            arrayCantidaItems.Add(txtbxCaja.Text.Trim());
         
            /*if (!MaterialRepetido())
            {
                ObtenerCantKilo();
            }
            if (CambioMaterial())
            {
                //ClsNumCaja beto = new ClsNumCaja();
                //string tmpMatnr;
                //int i = 0;

                //foreach (string material in listaMat)
                //{
                //    ++i;
                    
                //    if (material == txtbxMaterial.Text)
                //    {
                //        break;
                //    }
                //}
                CLSMatnrWFecha claseRara = new CLSMatnrWFecha();
                int difMat = listaMat.Count;

                if (difMat > 0)
                {
                    claseRara = (CLSMatnrWFecha)listaCantKil[difMat - 1];
                    txtbxCajasAcum.Text = claseRara.Cajas.ToString();
                    txtbxKilosAcum.Text = claseRara.Cajas.ToString();

                    txtbxKilosAcum.Text.ToString();
                    base.MostrarMensaje("Caja agregada!");
                }
            }
            else
            {*/
            if (txtbxCajasAcum.Text == "0.000") { txtbxCajasAcum.Text = "1"; }
            else { txtbxCajasAcum.Text = (Convert.ToInt32(txtbxCajasAcum.Text) + 1).ToString(); }
            liCantidadAux = liCantidadAux + Convert.ToDouble(liCantidad);
            /*EtotalPeso =Convert.ToDouble(*/txtbxKilosAcum.Text = liCantidadAux.ToString();//);
            //EtotalPeso = EtotalPeso - resta;

                base.MostrarMensaje("Caja agregada!");
            //}
        }
    
        

        /*private void ObtenerCantKilo()
        {
                CLSMatnrWFechaCollection coleccionMat;
                ClsNumCaja numCaja = new ClsNumCaja();
                string criterio = "WHERE (MATNR = '" + txtbxMaterial.Text + "') ";
                criterio = criterio + "AND (FechaCreacion >= CONVERT(DATETIME, '" + DateTime.Now.ToString("yyyy-MM-dd 00:00:00") + "', 120))";
                criterio = criterio + "AND (WERKS = '" + txtbxAlmacen.Text + "')";
                coleccionMat = numCaja.ObtenerMatFec(criterio);
                resta = Convert.ToInt32(coleccionMat[0].Cantidad);
                txtbxKilosAcum.Text = coleccionMat[0].Cantidad.ToString();
                txtbxCajasAcum.Text = coleccionMat[0].Cajas.ToString();
        }*/

        public void GenerarFolio()
        {
            ClsZFolio folio = new ClsZFolio();
            folio.Werks = numCaja.BackCadenaWerks(arrayCantidaItems[0].ToString());
            folio.Pref = "";
            folio.Tipo = "TC";
            folio.Nbr = "";
            ClsZFolioCollection folios = new ClsZFolioBAL().AgregaryRetornoZFolioBAL(folio);

            folio = folios[0];

            glfolio = long.Parse(folio.Nbr + "");
            //liCantidadAux = 0.0;
        }


        private void imprimeDatos()
        {

            //ImprimirEtiquetaGenericaTarimas("C:\\NuevasEtiquetas\\Tarima.zpl", GetImpresoraDefecto());

            numCaja = new ClsNumCaja();

            /*if (banFo)
            {*/
            GenerarFolio();
            //}

            #region Blancos
            aValoresTotales[6, 0] = "&G_MATNR01&";
            aValoresTotales[6, 1] = " ";
                           
            aValoresTotales[7, 0] = "&G_MAKTX01&";
            aValoresTotales[7, 1] = " ";

            aValoresTotales[8, 0] = "&GV_PESO01&";
            aValoresTotales[8, 1] = " ";

            aValoresTotales[9, 0] = "&GV_CAJA01&";
            aValoresTotales[9, 1] = " ";

            aValoresTotales[10, 0] = "&G_MATNR02&";
            aValoresTotales[10, 1] = " ";

            aValoresTotales[11, 0] = "&G_MAKTX02&";
            aValoresTotales[11, 1] = " ";

            aValoresTotales[12, 0] = "&GV_PESO02&";
            aValoresTotales[12, 1] = " ";

            aValoresTotales[13, 0] = "&GV_CAJA02&";
            aValoresTotales[13, 1] = " ";

            aValoresTotales[14, 0] = "&G_MATNR03&";
            aValoresTotales[14, 1] = " ";

            aValoresTotales[15, 0] = "&G_MAKTX03&";
            aValoresTotales[15, 1] = " ";

            aValoresTotales[16, 0] = "&GV_PESO03&";
            aValoresTotales[16, 1] = " ";

            aValoresTotales[17, 0] = "&GV_CAJA03&";
            aValoresTotales[17, 1] = " ";

            aValoresTotales[18, 0] = "&G_MATNR04&";
            aValoresTotales[18, 1] = " ";

            aValoresTotales[19, 0] = "&G_MAKTX04&";
            aValoresTotales[19, 1] = " ";

            aValoresTotales[20, 0] = "&GV_PESO04&";
            aValoresTotales[20, 1] = " ";

            aValoresTotales[21, 0] = "&GV_CAJA04&";
            aValoresTotales[21, 1] = " ";

            aValoresTotales[22, 0] = "&G_MATNR05&";
            aValoresTotales[22, 1] = " ";

            aValoresTotales[23, 0] = "&G_MAKTX05&";
            aValoresTotales[23, 1] = " ";

            aValoresTotales[24, 0] = "&GV_PESO05&";
            aValoresTotales[24, 1] = " ";

            aValoresTotales[25, 0] = "&GV_CAJA05&";
            aValoresTotales[25, 1] = " ";

            aValoresTotales[26, 0] = "&G_MATNR06&";
            aValoresTotales[26, 1] = " ";

            aValoresTotales[27, 0] = "&G_MAKTX06&";
            aValoresTotales[27, 1] = " ";

            aValoresTotales[28, 0] = "&GV_PESO06&";
            aValoresTotales[28, 1] = " ";

            aValoresTotales[29, 0] = "&GV_CAJA06&";
            aValoresTotales[29, 1] = " ";

            aValoresTotales[30, 0] = "&G_MATNR07&";
            aValoresTotales[30, 1] = " ";

            aValoresTotales[31, 0] = "&G_MAKTX07&";
            aValoresTotales[31, 1] = " ";

            aValoresTotales[32, 0] = "&GV_PESO07&";
            aValoresTotales[32, 1] = " ";

            aValoresTotales[33, 0] = "&GV_CAJA07&";
            aValoresTotales[33, 1] = " ";

            aValoresTotales[34, 0] = "&G_MATNR08&";
            aValoresTotales[34, 1] = " ";

            aValoresTotales[35, 0] = "&G_MAKTX08&";
            aValoresTotales[35, 1] = " ";

            aValoresTotales[36, 0] = "&GV_PESO08&";
            aValoresTotales[36, 1] = " ";

            aValoresTotales[37, 0] = "&GV_CAJA08&";
            aValoresTotales[37, 1] = " ";
            #endregion

            ClsTabTemZMasterCollection tabTempCol = new ClsTabTemZMasterCollection();

            numCaja.NumFolio = glfolio;
            tarima2D = "T" + glfolio;
            numCaja.coleccionDatos(arrayCantidaItems);
                   
            string criterio0 = "WHERE (ZMASTER.WERKS = '" + lsWerks + "') AND (IDTarima = '" + glfolio + "')";

            ClsCatZMasterCollection etiquetaMaster = new ClsCatZMasterBAL().ConsultarZMasterBAL(criterio0);
            IEnumerator recorredor = etiquetaMaster.GetEnumerator();
            while(recorredor.MoveNext())
            {
                ClsCatZMaster claseTarima = (ClsCatZMaster)recorredor.Current;
                cajasTarima = cajasTarima + "|H" + claseTarima.IdCaja + "|P" + claseTarima.Matnr + "|L" + claseTarima.Charg + "|D" + 
                    String.Format("{0:d}", claseTarima.FechaProduccion) + "|Q" + claseTarima.Cantidad + "|W" + claseTarima.Werks + "@";
            }

            tabTempCol = new ClsTabTemZMasterBAL().ConsultarMaterialesZMasterBAL(criterio0);
            IEnumerator lista1 = tabTempCol.GetEnumerator();
            int valores = 5;
            int caja = 1;

            while (lista1.MoveNext())
	        {

                ClsTabTemZMaster mastersilla = new ClsTabTemZMaster();
                mastersilla = (ClsTabTemZMaster)lista1.Current;

                lsMatnr = mastersilla.Matnr;
                ClsTabTemZMasterCollection ZMaster;

                string criterio = "INNER JOIN MARA ON ZMASTER.MATNR = MARA.MATNR ";
                criterio = criterio + "WHERE (IDTarima = '" + glfolio + "') ";
                criterio = criterio + "AND (ZMASTER.WERKS = '" + lsWerks + "')";
                criterio = criterio + "AND (MARA.WERKS = '" + lsWerks + "')";
                criterio = criterio + "AND (ZMASTER.MATNR = '" + lsMatnr + "')";

                ZMaster = new ClsTabTemZMasterBAL().ConsultaZMasterBAL(criterio);
                IEnumerator lista2 = ZMaster.GetEnumerator();
                int cajas = 0;
                double peso = 0.0;
                while (lista2.MoveNext())
                {
                    ClsTabTemZMaster clase = (ClsTabTemZMaster)lista2.Current;
                    lsDescMatnr = clase.Descripcion;
                    cajas++;
                    peso = peso + clase.Cantidad;
                }
                liTotalCajasMatnr = cajas;
                liTotalKilos = peso;
                totalKilosGral = totalKilosGral + liTotalKilos;
                lsTotalCajas = (Convert.ToInt32(lsTotalCajas) + cajas).ToString();
         
                valores++;
                aValoresTotales[valores, 0] = "&G_MATNR0" + caja + "&";
                aValoresTotales[valores, 1] = lsMatnr;
                valores++;
                aValoresTotales[valores, 0] = "&G_MAKTX0" + caja + "&";
                aValoresTotales[valores, 1] = lsDescMatnr;
                valores++;
                aValoresTotales[valores, 0] = "&GV_PESO0" + caja + "&";
                aValoresTotales[valores, 1] = liTotalKilos.ToString();
                valores++;
                aValoresTotales[valores, 0] = "&GV_CAJA0" + caja + "&";
                aValoresTotales[valores, 1] = liTotalCajasMatnr.ToString(); 
                caja++;
	        }
                               
            //DialogResult result = MessageBox.Show("Los Datos a Imprimir son :  Num Tarima: " + lsCodTarima +
            //", Fecha Armado: " + lsFechaArmado + ",\n Total Cajas: " + lsTotalCajas +
            //", Total Kilos: " + liTotalKilos + ",\n " +
            //" Cajas Ma: " + liTotalCajasMatnr + "****** Material: " + lsMatnr +
            //"****** Descripcion: " + lsDescMatnrTarima + "****** kilos: " + liTotalKilosMatnr +"\n" +
            //" Cajas Ma: " + liTotalCajasMatnr + "****** Material: " + lsMatnr +
            //"****** Descripcion: " + lsDescMatnrTarima + "****** kilos: " + liTotalKilosMatnr
            //, "Tarima", MessageBoxButtons.YesNo);

            /*if (result == DialogResult.Yes)
            {*/
            MessageBox.Show("Imprimiendo Etiqueta");
            string ruta = ClsFunciones.ObtenerValorEntorno(Variables.SistemaOperativo);
            string nombreArchivo = ruta + "Tarima.zpl";
            //ImprimirEtiquetaGenericaTarimas("\\\\CELBKS02\\EtiquetasContingencia\\Tarima.zpl", GetImpresoraDefecto());
            ImprimirEtiquetaGenericaTarimas(nombreArchivo, GetImpresoraDefecto());
            /*}
            else if (result == DialogResult.No)
            {

            }*/

            txtbxCaja.Text = "";
            txtbxAlmacen.Text = "";
            txtbxDenom.Text = "";
            txtbxEmbalada.Text = "0.00";
            txtbxLote.Text = "";
            txtbxCont.Text = "";
            txtbxMaterial.Text = "";
            txtbxKilosAcum.Text = "0.000";
            txtbxCajasAcum.Text = "0.000";
            txtbxCaja.Focus();
        }

        private bool MaterialRepetido()
        {
            for (int i = 0; i < listaMat.Count; i++)
            {
                if (listaMat[i].ToString() != txtbxMaterial.Text)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public void ImprimirEtiquetaGenericaTarimas(string psArchivoBase, string psImpresora)
        {

            //A los valores obtenidos se les debe agregar los fijos de la parte
            string fecha = String.Format("{0:d}", DateTime.Now);

            aValoresTotales[0, 0] = "&P_TARIMA&";
            aValoresTotales[0, 1] = glfolio.ToString(); //Valor de la propiedad

            aValoresTotales[1, 0] = "&P_FECHA&";
            aValoresTotales[1, 1] = fecha;

            aValoresTotales[2, 0] = "&P_TOTAL_PESO&";
            aValoresTotales[2, 1] = totalKilosGral.ToString();

            aValoresTotales[3, 0] = "&P_TOTAL_CAJAS&";
            aValoresTotales[3, 1] = lsTotalCajas;

            aValoresTotales[4, 0] = "&P_TOTAL_PAGS&";
            aValoresTotales[4, 1] = "1";

            aValoresTotales[5, 0] = "&P_PAGINA_ACTUAL&";
            aValoresTotales[5, 1] = "1";

            aValoresTotales[38, 0] = "&CODIGO2D&";
            aValoresTotales[38, 1] = "T" + tarima2D + "|Q" + txtbxCajasAcum.Text;  //+ cajasTarima;

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

        private void txtbxCaja_KeyUp(object sender, KeyEventArgs e)
        {
            base.MensajeApagar();
            if (e.KeyCode == (Keys.Enter))
            {
                CLSMatnrWFecha matnrFecha = new CLSMatnrWFecha();
                if (txtbxCaja.TextLength != 0)
                {
                    try
                    {
                        /*if (CambioMaterial() || arrayCantidaItems.Count == 0)
                        {*/
                            if (txtbxCajasAcum.Text == "0.000")
                            {
                                matnrFecha.Cajas = 0;
                            }
                            else
                            {
                                matnrFecha.Cajas = Convert.ToInt32(txtbxCajasAcum.Text);
                            }
                            
                            matnrFecha.Cantidad = Convert.ToDouble(txtbxKilosAcum.Text);
                            //listaCantKil.Add(matnrFecha);
                        //}

                        ValidaDatos();

                        /*if (!MaterialRepetido())
                        {
                            listaMat.Add(txtbxMaterial.Text);
                        }*/
                        txtbxCaja.Clear();
                    }
                    catch (Exception ex)
                    {
                        txtbxCaja.Clear();
                        base.MostrarError(ex.Message);
                    }
                }
            }
        }

        private bool CambioMaterial()
        {
            int index;
            if (arrayCantidaItems.Count >= 2)
            {
                index = arrayCantidaItems.Count - 2;
                ClsNumCaja miMat = new ClsNumCaja();
                string material = miMat.BackCadenaMatnr(arrayCantidaItems[index].ToString());
                string nuevoMat = miMat.BackCadenaMatnr(txtbxCaja.Text);
                if (nuevoMat != material)
                {
                    return true;
                }
            }
            else if (arrayCantidaItems.Count == 1)
            {
                index = 0;
                ClsNumCaja miMat = new ClsNumCaja();
                string material = miMat.BackCadenaMatnr(arrayCantidaItems[index].ToString());
                string nuevoMat = miMat.BackCadenaMatnr(txtbxCaja.Text);
                if (nuevoMat != material)
                {
                    return true;
                }
            }
            return false;
        }

        private void pnlBase_Paint(object sender, PaintEventArgs e)
        {

        }


        public void siguiente()
        {
            base.MensajeApagar();
    
            int liCont = int.Parse(txtbxCont.Text);

            try
            {
                if (liCont == arrayCantidaItems.Count)
                {
                    throw new Exception("Ya no hay numeros de cajas");
                }
                else
                {            
                    obtenerDatos(liCont + 1);
                    txtbxCont.Text = "" + (liCont + 1);

                    txtbxCaja.SelectionStart = 0;
                }
            }
            catch (Exception)
            {
                throw new Exception("Ya no hay numeros de cajas");
            }
        }


        public void anterior()
        {
            base.MensajeApagar();
            int liCont = int.Parse(txtbxCont.Text) - 1;

            try
            {
                if (liCont == -1)
                {
                    throw new Exception("Ya no hay numeros de cajas");
                }
                else
                {
                    obtenerDatos(liCont);
                    txtbxCaja.SelectionStart = 0;
                    txtbxCont.Text = "" + (liCont);
                }
            }
            catch (Exception)
            {
                throw new Exception("Ya no hay numeros de cajas");
            }

        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            int liCont = arrayCantidaItems.Count;

            obtenerDatos(liCont);

            txtbxCont.Text = "" + (liCont);

            banGl = false;

            txtbxCaja.SelectionStart = 0;
            txtbxCaja.SelectAll();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            int liPrimero = arrayCantidaItems.Count - (arrayCantidaItems.Count - 1);
            int liCont = liPrimero;

            obtenerDatos(liCont);

            txtbxCont.Text = "" + (liCont);
            banGl = false;

            txtbxCaja.SelectionStart = 0;
            txtbxCaja.SelectAll();
        }

        public void obtenerDatos(int pindice)
        {
            ClsNumCaja numcaja = new ClsNumCaja();
            char[] arrayNotArroba = { ']' };
            String[] b = arrayCantidaItems[pindice - 1].ToString().Split(arrayNotArroba);
            txtbxCaja.SelectAll();
            txtbxCaja.Text = arrayCantidaItems[pindice -1].ToString();
            txtbxAlmacen.Text = b[5].ToString().Remove(0, 1);
            txtbxMaterial.Text = b[2].ToString().Remove(0, 1);
            txtbxDenom.Text = numcaja.descripcion(txtbxMaterial.Text, txtbxAlmacen.Text);
            txtbxLote.Text = b[2].ToString().Remove(0, 1);
            txtbxEmbalada.Text = b[4].ToString().Remove(0, 1);


            txtbxCaja.SelectionStart = 0;
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

        private void FrmArmadoTarimas_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        //public void ImprimirEtiquetaGenericaTarimas(string psArchivoBase, string psImpresora)
        //{
            

        //    //Se aumenta el renglon para el valor 
        //    //A los valores obtenidos se les debe agregar los fijos de la parte
        //    aValoresTotales[0, 0] = "&P_TARIMA&";
        //    aValoresTotales[0, 1] = glfolio.ToString(); //Valor de la propiedad

        //    aValoresTotales[1, 0] = "&P_FECHA&";
        //    aValoresTotales[1, 1] = DateTime.Now.ToString().Substring(0,12);

        //    aValoresTotales[2, 0] = "&P_TOTAL_PESO&";
        //    aValoresTotales[2, 1] =  EtotalPeso+"";

        //    aValoresTotales[3, 0] = "&P_TOTAL_CAJAS&";
        //    aValoresTotales[3, 1] = txtbxCont.Text;

        //    aValoresTotales[4, 0] = "&P_TOTAL_PAGS&";
        //    aValoresTotales[4, 1] = "1";

        //    aValoresTotales[5, 0] = "&P_PAGINA_ACTUAL&";
        //    aValoresTotales[5, 1] = "1";

        //    aValoresTotales[6, 0] = "&G_MATNR01&";
        //    aValoresTotales[6, 1] = "";

        //    aValoresTotales[7, 0] = "&G_MAKTX01&";
        //    aValoresTotales[7, 1] = "";

        //    aValoresTotales[8, 0] = "&GV_PESO01&";
        //    aValoresTotales[8, 1] = "";

        //    aValoresTotales[9, 0] = "&GV_CAJA01&";
        //    aValoresTotales[9, 1] = "";

        //    aValoresTotales[10, 0] = "&G_MATNR02&";
        //    aValoresTotales[10, 1] = "";

        //    aValoresTotales[11, 0] = "&G_MAKTX02&";
        //    aValoresTotales[11, 1] = "";

        //    aValoresTotales[12, 0] = "&GV_PESO02&";
        //    aValoresTotales[12, 1] = "";

        //    aValoresTotales[13, 0] = "&GV_CAJA02&";
        //    aValoresTotales[13, 1] = "";


        //    ClsEtiquetaGeneral etiquetaGeneral = new ClsEtiquetaGeneral();
        //    etiquetaGeneral.AValores = aValoresTotales;
        //    etiquetaGeneral.ArchivoBase = psArchivoBase;
        //    etiquetaGeneral.Impresora = psImpresora;

        //    try
        //    {
        //        etiquetaGeneral.ProcesarEtiqueta();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        //public string GetImpresoraDefecto()
        //{
        //    for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
        //    {
        //        PrinterSettings a = new PrinterSettings();
        //        a.PrinterName = PrinterSettings.InstalledPrinters[i].ToString();
        //        if (a.IsDefaultPrinter)
        //        {
        //            return PrinterSettings.InstalledPrinters[i].ToString();

        //        }
        //    }
        //    return "No hay impresora Predeterminada";
        //}

    }
}
