using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
using System.Collections;

namespace Contingencia
{
    public partial class FrmReimpresionEtiquetas : FrmBase
    {
        public FrmReimpresionEtiquetas()
        {
            InitializeComponent();
        }

        private string lsMensaje = "";
        private string lsCriterio = "";
        //tarimas
        private string lsCodTarima;
        private string lsFechaArmado;
        private string lsTotalCajas;
        private double liTotalKilos;
        /*private string lsMatnrTarima;
        private string lsDescMatnrTarima01;
        private decimal liTotalKilosMatnr01;*/
        private int liTotalCajasMatnr01;
        private string lsMatnr01;
        /*private string lsDescMatnrTarima02;
        private decimal liTotalKilosMatnr02;
        private int liTotalCajasMatnr02;
        private string lsMatnr02;
        private string lsDescMatnrTarima03;
        private decimal liTotalKilosMatnr03;
        private int liTotalCajasMatnr03;
        private string lsMatnr03;
        private string lsDescMatnrTarima04;
        private decimal liTotalKilosMatnr04;
        private int liTotalCajasMatnr04;
        private string lsMatnr04;
        private string lsDescMatnrTarima05;
        private decimal liTotalKilosMatnr05;
        private int liTotalCajasMatnr05;
        private string lsMatnr05;
        private string lsDescMatnrTarima06;
        private decimal liTotalKilosMatnr06;
        private int liTotalCajasMatnr06;
        private string lsMatnr06;
        private string lsDescMatnrTarima07;
        private decimal liTotalKilosMatnr07;
        private int liTotalCajasMatnr07;
        private string lsMatnr07;
        private string lsDescMatnrTarima08;
        private decimal liTotalKilosMatnr08;
        private int liTotalCajasMatnr08;
        private string lsMatnr08;*/
        private static int nuevosRenglones = 0;
        string[,] aValoresTotales = new string[nuevosRenglones, 2];
        private double totalKilosGral = 0.0;
        string tarima2D = "";
        string cajasTarima = "";
        //cajas
        private string textoTipo = "";
        private string lsCodHU = "";
        private DateTime fechaCad;
        private string lsCentroCo = "";
        private string lsLote = "";
        private string lsMatnr = "";
        private DateTime lsFechaCaja;
        private string lsAufnr = "";
        private string lsHoraCaja = "";
        private string lsPesoNetoCaja ="";
        private string lsDescMatnr;
        private string lsFechaNow = DateTime.Now.ToString();
        //private string lsNumParte="";
        private string lsEtiar = ""; //numEtiqueta        
        private string lsEtifo = "";   //numAImprimir
        private string lsTipo = "";
        private void FrmReimpresionEtiquetas_Load(object sender, EventArgs e)
        {
            base.PonerTitulo("Reimpresión de Etiquetas");
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void textHu_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textHu);
        }

        private void textTarima_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textTarima);
        }

        private void textHu_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.MensajeApagar();
        }

        private void textTarima_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.MensajeApagar();
        }

        private void textHu_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(textHu);
        }

        private void textTarima_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(textTarima);
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (textTarima.Text.Trim().Length != 0)
            {
                ValidarDatos();
            }
            else if(textHu.Text.Trim().Length != 0)
            {
                ValidarDatos();

                DialogResult result = MessageBox.Show("Los Datos a Imprimir son :  Num Caja: " + lsCodHU + "Material: " + lsMatnr +
                    "Desc Material : " + lsDescMatnr , "Salir" ,MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    //string ruta = "\\\\CELBKS02\\EtiquetasContingencia\\";
                    string ruta = ClsFunciones.ObtenerValorEntorno(Variables.SistemaOperativo);
                    string nombreArchivo = ruta + "GMPF" + lsEtiar + lsCentroCo + ".zpl";
                    
                    //ImprimirEtiquetaGenerica(nombreArchivo, GetImpresoraDefecto());
                    ImprimirEtiquetaGenericaCaja(nombreArchivo, GetImpresoraDefecto());   
                }
                else if (result == DialogResult.No)
                { 
                
                
                }
               
            }    
        }

        private void ValidarDatos()
        {
            ClsNumCaja numCaja = new ClsNumCaja();
               //datos llenos
            if (textHu.Text.Trim().Length == 0 && textTarima.Text.Trim().Length == 0)
            {
                lsMensaje = "Ingresar al menos un campo";
                textHu.Focus();
                throw new Exception(lsMensaje);
            }

            //Datos de tarima llenos
            if (textTarima.Text.ToString().Trim().Length != 0)
            {
                nuevosRenglones = 39;

                if (textTarima.Text.Trim().Length < 10)
                {
                    lsMensaje = "Código incorrrecto";
                    base.MostrarError(lsMensaje);
                }
                else
                {
                    //comprueba que tenga un tamaño 10
                    if (textTarima.Text.Trim().Length == 10)
                    {
                        //comprueba que sea numerico char x char
                        for (int x = 0; x <= textTarima.Text.Length - 1; x++)
                        {
                            if (!char.IsDigit(textTarima.Text[x]))
                            {
                                lsMensaje = "Código incorrrecto";                       
                                base.MostrarError(lsMensaje);
                            }
                        }
                        lsCodTarima = textTarima.Text;
                    }


                    lsCriterio = "where IDTarima=" + lsCodTarima + "order by MATNR";

                    ClsCatZMasterCollection zMasterCollection;

                       zMasterCollection = (new ClsCatZMasterBAL().ConsultarZMasterBAL(lsCriterio));

                       if (zMasterCollection.Count != 0)
                       {
                           lsMensaje = "Tarima Encontrada";
                           base.MostrarMensaje(lsMensaje);

                           IEnumerator lista = zMasterCollection.GetEnumerator();

                           //ClsCatZMaster zMaster = (ClsCatZMaster)lista.Current;

                           while (lista.MoveNext())
                           {
                               ClsCatZMaster zMaster = (ClsCatZMaster)lista.Current;

                               lsFechaArmado = zMaster.FechaCreacion.ToString();
                               lsTotalCajas = zMasterCollection.Count.ToString();
                               //lsMatnrTarima = zMaster.Matnr.ToString(); 
                               lsCentroCo = zMaster.Werks.ToString();
                                          
                           }

                           lsFechaArmado = lsFechaArmado.Substring(0, 10).ToString();
                           ClsTabTemZMasterCollection tablaTempCol = new ClsTabTemZMasterCollection();

                           aValoresTotales = new string[nuevosRenglones, 2];

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

                           /*for (int i = 0; i < zMasterCollection.Count; i++ )
                           {*/
                            ClsTabTemZMasterCollection tabTempCol = new ClsTabTemZMasterCollection();

                            tarima2D = lsCodTarima;

                            string criterio0 = "WHERE (ZMASTER.WERKS = '" + lsCentroCo + "') AND (IDTarima = '" + lsCodTarima + "')";

                            ClsCatZMasterCollection etiquetaMaster = new ClsCatZMasterBAL().ConsultarZMasterBAL(criterio0);
                            IEnumerator recorredor = etiquetaMaster.GetEnumerator();
                            while (recorredor.MoveNext())
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
                                criterio = criterio + "WHERE (IDTarima = '" + lsCodTarima + "') ";
                                criterio = criterio + "AND (ZMASTER.MATNR = '" + lsMatnr + "')";
                                criterio = criterio + "AND (MARA.WERKS = '" + lsCentroCo + "')";
                                criterio = criterio + "AND (ZMASTER.WERKS = '" + lsCentroCo + "')";

                                ZMaster = new ClsTabTemZMasterBAL().ConsultaZMasterBAL(criterio);
                                IEnumerator lista2 = ZMaster.GetEnumerator();
                                int cajas = 0;
                                double peso = 0.0;
                                while (lista2.MoveNext())
                                {
                                    ClsTabTemZMaster clase = (ClsTabTemZMaster)lista2.Current;
                                    lsMatnr01 = clase.Matnr;
                                    lsDescMatnr = clase.Descripcion;
                                    cajas++;
                                    peso = peso + clase.Cantidad;
                                }

                                liTotalCajasMatnr01 = cajas;
                                liTotalKilos = peso;
                                totalKilosGral = totalKilosGral + liTotalKilos;
                                
                                valores++;
                                aValoresTotales[valores, 0] = "&G_MATNR0" + caja + "&";
                                aValoresTotales[valores, 1] = lsMatnr01;
                                valores++;
                                aValoresTotales[valores, 0] = "&G_MAKTX0" + caja + "&";
                                aValoresTotales[valores, 1] = lsDescMatnr;
                                valores++;
                                aValoresTotales[valores, 0] = "&GV_PESO0" + caja + "&";
                                aValoresTotales[valores, 1] = liTotalKilos.ToString();
                                valores++;
                                aValoresTotales[valores, 0] = "&GV_CAJA0" + caja + "&";
                                aValoresTotales[valores, 1] = liTotalCajasMatnr01.ToString(); 
                                caja++;
	                        }
                               
                               //liTotalKilos = Convert.ToDecimal(liTotalKilos) + Convert.ToDecimal(zMasterCollection[i].Cantidad.ToString());
                               //int x = 1;

                               //if (zMasterCollection[i].Matnr.ToString() != zMasterCollection[1].Matnr.ToString())
                               //{
                               //    liTotalKilosMatnr02 = Convert.ToDecimal(liTotalKilosMatnr02) + Convert.ToDecimal(zMasterCollection[i].Cantidad.ToString());  
                               //    liTotalCajasMatnr02 = liTotalCajasMatnr02 + x;
                               //    lsMatnr02 = zMasterCollection[i].Matnr;
                               //}
                               //else
                               //{
                               //    tablaTemp.Matnr = zMasterCollection[i].Matnr;
                               //    liTotalKilosMatnr01 = Convert.ToDecimal(liTotalKilosMatnr01) + Convert.ToDecimal(zMasterCollection[i].Cantidad.ToString());
                               //    liTotalCajasMatnr01 = liTotalCajasMatnr01 + x;
                                   

                               //    ClsMARACollection maraCollection;
                               //    maraCollection = (new ClsMARABAL().ConsultarMARABAL("where MATNR ='" + lsMatnr01 + "'"));
                               //    if (maraCollection.Count != 0)
                               //    {
                               //        IEnumerator lista1 = maraCollection.GetEnumerator();
                               //        while (lista1.MoveNext())
                               //        {
                               //            ClsMARA mara = (ClsMARA)lista1.Current;
                               //            lsDescMatnrTarima01 = mara.Maktx.ToString();
                               //        }
                               //    }
                               //}
                           //}


                    //       DialogResult result = MessageBox.Show("Los Datos a Imprimir son :  Num Tarima: " + lsCodTarima +
                    //", Fecha Armado: " + lsFechaArmado + ",\n Total Cajas: " + lsTotalCajas +
                    //", Total Kilos: " + liTotalKilos + ",\n " +
                    // " Cajas Ma: " + liTotalCajasMatnr01 + "****** Material: " + lsMatnr01 +
                    //"****** Descripcion: " + lsDescMatnrTarima01 + "****** kilos: " + liTotalKilosMatnr01 +"\n" +
                    // " Cajas Ma: " + liTotalCajasMatnr02 + "****** Material: " + lsMatnr02 +
                    //"****** Descripcion: " + lsDescMatnrTarima02 + "****** kilos: " + liTotalKilosMatnr02
                    //, "Tarima", MessageBoxButtons.YesNo);

                           /*if (result == DialogResult.YeS)
                           {*/
                            MessageBox.Show("Imprimiendo Etiqueta");

                            string ruta = ClsFunciones.ObtenerValorEntorno(Variables.SistemaOperativo);
                            string nombreArchivo = ruta + "Tarima.zpl";                          
                           
                            ImprimirEtiquetaGenericaTarimas(nombreArchivo, GetImpresoraDefecto());
                           /*}
                           else if (result == DialogResult.No)
                           {

                           }*/

                       }
                       else
                       {
                           lsMensaje = "No se encuentra la Tarima";
                           base.MostrarError(lsMensaje);
                       }
                }
             }
            // Caja
            else if (textHu.Text.ToString().Trim().Length != 0)
            {
                if (textHu.Text.Trim().Length < 10)
                {
                    lsMensaje = "Código incorrrecto";
                    base.MostrarError(lsMensaje);
                }
                else
                {
                    //comprueba que tenga un tamaño 10
                    if (textHu.Text.Trim().Length == 10)
                    {
                        //comprueba que sea numerico char x char
                        for (int x = 0; x <= textHu.Text.Length - 1; x++)
                        {
                            if (!char.IsDigit(textHu.Text[x]))
                            {
                                //  lbCajaCorrecto = false;
                                lsMensaje = "Código incorrrecto";
                                //break;
                                base.MostrarError(lsMensaje);
                            }
                        }

                        lsCodHU = textHu.Text;
                    }
                    else
                    {
                        //si no tiene 10 digitos es un codigo se comprueba que sea codigo 2d
                        if (textHu.Text.Substring(0, 1).Equals("H"))
                        {
                            ClsDividirC divCodigo = new ClsDividirC();
                            //H1001009875|P134303C1|L0014399446|D24/04/2012|Q     30.0 |W0R00
                            string[] formatoC = { "H", "P", "L", "D", "Q", "W" };
                            if (divCodigo.DividirC(textHu.Text, formatoC))
                            {
                                lsCodHU = divCodigo.NumCaja;
                                lsLote = divCodigo.NumLoteProd;
                                lsMatnr = divCodigo.NumParete;
                                lsFechaCaja = Convert.ToDateTime(divCodigo.FechProd);
                                lsPesoNetoCaja = divCodigo.Cant;
                                lsCentroCo = divCodigo.Centro;
                            }
                        }   
                    }
                    
                    lsCriterio = "where EXIDV= '" + lsCodHU + "' and MOV_HU='X'";

                    ClsZTPPLogsCollection zLogsCollection;
                    zLogsCollection = (new ClsZTPPLogsBAL().ConsultarZTPPLogsBAL(lsCriterio));

                    if (zLogsCollection.Count != 0)
                    {
                        IEnumerator lista = zLogsCollection.GetEnumerator();

                        while (lista.MoveNext())
                        {
                            ClsZTPPLogs zLogs = (ClsZTPPLogs)lista.Current;

                            lsCentroCo = zLogs.Werks.ToString();
                            lsMatnr = zLogs.Matnr.ToString();
                            lsFechaCaja = zLogs.Fecha;
                            lsAufnr = zLogs.Aufnr.ToString();
                            lsPesoNetoCaja = zLogs.Vemng.ToString();
                        }

                        lsTipo = lsMatnr.Substring(0, 2);


                        switch (lsTipo)
                        {
                            case "11":
                                textoTipo = "VACIO";
                                break;
                            case "12":
                                textoTipo = "CONGELADO";
                                break;
                            case "13":
                                textoTipo = "FRESCO";
                                break;
                            default:
                                string lsMensaje1;
                                lsMensaje1 = "Tipo de producto no valido";
                                throw new Exception(lsMensaje1);
                        }

                        lsCriterio = "as zt inner join OPCS as o on zt.AUFNR = o.AUFNR where zt.AUFNR ='" + lsAufnr + "' and zt.MOV_HU='X' AND (zt.WERKS = '" + 
                            lsCentroCo + "') AND (EXIDV = '" + lsCodHU + "')";

                        zLogsCollection = new ClsZTPPLogsBAL().ObtenerChargReimpresionBAL(lsCriterio);

                        if (zLogsCollection.Count != 0)
                        {
                            lsLote = zLogsCollection[0].Charg;
                        }

                        ClsMARACollection maraCollection;
                        maraCollection = (new ClsMARABAL().ConsultarMARABAL("where MATNR ='" + lsMatnr + "' and WERKS = '" + lsCentroCo + "'"));
                        if (maraCollection.Count != 0)
                        {
                            IEnumerator lista1 = maraCollection.GetEnumerator();
                            while (lista1.MoveNext())
                            {
                                ClsMARA mara = (ClsMARA)lista1.Current;
                                lsDescMatnr = mara.Maktx.ToString();
                                lsEtiar = mara.Etiar;
                                lsEtifo = mara.Etifo;
                            }
                        }

                        fechaCad = numCaja.regresaFecha(lsMatnr, Convert.ToDateTime(lsFechaCaja), lsCentroCo);

                        lsMensaje = "Caja Encontrada";
                        base.MostrarMensaje(lsMensaje);
                        

                    }
                    else
                    {
                        lsMensaje = "No se encontra la Caja";
                        base.MostrarError(lsMensaje);
                    }
                }
         }
    }
    
        private void FrmReimpresionEtiquetas_Activated(object sender, EventArgs e)
        {
            textHu.Focus();
        }

        private void textHu_TextChanged(object sender, EventArgs e)
        {
            textTarima.ReadOnly = true;
        }

        private void textTarima_TextChanged(object sender, EventArgs e)
        {
            textHu.ReadOnly = true;
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

        public string PredeterminarImpresora()
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

        public void ImprimirEtiquetaGenericaCaja(string psArchivoBase, string psImpresora)
        {
//            lsFechaNow = lsFechaNow.Substring(10,20).ToString();

            
            int nuevosRenglones = 18;
            //Se aumenta el renglon para el valor compuesto 2020
            //MessageBox.Show("Hora: " + fechaNow);

            string[,] aValoresTotales = new string[nuevosRenglones, 2];
            //A los valores obtenidos se les debe agregar los fijos de la parte
            aValoresTotales[0, 0] = "&datos-maktx&"; //Descripcion del Material
            aValoresTotales[0, 1] = lsDescMatnr;

            aValoresTotales[1, 0] = "&gv_fecha_prod&"; //Fecha Produccion
            aValoresTotales[1, 1] = String.Format("{0:d}", lsFechaCaja);

            aValoresTotales[2, 0] = "&datos-peso&"; //Datos Peso
            aValoresTotales[2, 1] = lsPesoNetoCaja;

            lsHoraCaja = lsFechaCaja.Hour + ":" + lsFechaCaja.Minute + ":" + lsFechaCaja.Second;

            aValoresTotales[3, 0] = "&datos-hora&"; //Datos Hora
            aValoresTotales[3, 1] = String.Format("{0:hh:mm:ss}", lsHoraCaja);

            aValoresTotales[4, 0] = "&datos-matnr&"; //Datos Material
            aValoresTotales[4, 1] = lsMatnr;

            aValoresTotales[5, 0] = "&datos-padre&"; //Datos Padre
            aValoresTotales[5, 1] = lsMatnr;

            aValoresTotales[6, 0] = "&datos-HU&";
            aValoresTotales[6, 1] = lsCodHU;

            aValoresTotales[7, 0] = "&datos-barcode1&";//Datos CodigoBarra
            aValoresTotales[7, 1] = lsCodHU;

            aValoresTotales[8, 0] = "&datos-um&";//DatosCentro
            aValoresTotales[8, 1] = "KG";

            aValoresTotales[9, 0] = "&datos-tatunr&";//
            aValoresTotales[9, 1] = "";

            aValoresTotales[10, 0] = "&datos-fmatan&";//
            aValoresTotales[10, 1] = "";

            aValoresTotales[11, 0] = "&datos-charg&"; //Datos Lote
            aValoresTotales[11, 1] = lsLote;

            aValoresTotales[12, 0] = "&gv_stadom&"; //
            aValoresTotales[12, 1] = textoTipo;

            aValoresTotales[13, 0] = "&datos-werks&";
            aValoresTotales[13, 1] =  lsCentroCo;

            aValoresTotales[14, 0] = "&NEtiq&";
            aValoresTotales[14, 1] = lsEtifo;

            aValoresTotales[15, 0] = "&barcode2d&";
            aValoresTotales[15, 1] = lsCodHU + "|" + lsMatnr + "|" + lsLote + "|" + (lsFechaCaja).ToString("yyyy/MM/dd") + "|" + lsPesoNetoCaja + lsCentroCo;

            aValoresTotales[16, 0] = "&gv_fecha_cad&";
            aValoresTotales[16, 1] = fechaCad.ToString("yyyy/MM/dd");

            aValoresTotales[17, 0] = "&V_BARCODE4&";
            aValoresTotales[17, 1] = lsCodHU + "|" + lsMatnr + "|" + lsLote + "|" + (lsFechaCaja).ToString("yyyy/MM/dd") + "|" + lsPesoNetoCaja + lsCentroCo;

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

        private void NumeroMateriales()
        { 

        }

        public void ImprimirEtiquetaGenericaTarimas(string psArchivoBase, string psImpresora)
        {
           
            //A los valores obtenidos se les debe agregar los fijos de la parte
            aValoresTotales[0, 0] = "&P_TARIMA&";
            aValoresTotales[0, 1] = lsCodTarima; //Valor de la propiedad

            aValoresTotales[1, 0] = "&P_FECHA&";
            aValoresTotales[1, 1] = lsFechaArmado;

            aValoresTotales[2, 0] = "&P_TOTAL_PESO&";
            aValoresTotales[2, 1] = totalKilosGral.ToString(); 

            aValoresTotales[3, 0] = "&P_TOTAL_CAJAS&";
            aValoresTotales[3, 1] = lsTotalCajas;

            aValoresTotales[4, 0] = "&P_TOTAL_PAGS&";
            aValoresTotales[4, 1] = "1";

            aValoresTotales[5, 0] = "&P_PAGINA_ACTUAL&";
            aValoresTotales[5, 1] = "1";

            aValoresTotales[38, 0] = "&CODIGO2D&";
            aValoresTotales[38, 1] = "T" + tarima2D + "|Q" + lsTotalCajas.ToString();//cajasTarima;

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


        private void PrintResumen()
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();

            try
            {
                printDialog.Document = printDocument;
        //        printDocument.PrintPage += new PrintPageEventHandler();

                DialogResult result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            catch
            {
                MessageBox.Show("No es posible realizar la operación solicitada");
            }
        }
    }
}
