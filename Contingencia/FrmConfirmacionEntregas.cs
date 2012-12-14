using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Contingencia
{
    public partial class FrmConfirmacionEntregas : Form
    {
        string _tipoReporte;
        private string _idEntrega;
        private string _idCentro;
        private DataTable tablaTemporal;
        private DataTable tablaProducto;
        private DataTable tablaRemision;

        public string TipoReporte
        {
            get { return _tipoReporte; }
            set { _tipoReporte = value;}
        }
        
        public string IdEntrega
        {
            get { return _idEntrega; }
            set { _idEntrega = value; }
        }

        public string IdCentro
        {
            get { return _idCentro; }
            set { _idCentro = value; }
        }

        public FrmConfirmacionEntregas()
        {
            InitializeComponent();
        }

        private void FrmConfirmacionEntregas_Load(object sender, EventArgs e)
        {
        }

        public void IniciarForma()
        {
            if (_tipoReporte == "REMISION")
            {
                btnDetalle.Text = "Canal";
                btnResumen.Text = "Remisión";
                btnProducto.Visible = true;
            }
            else
            {
                
                btnDetalle.Text = "Detalle";
                btnProducto.Visible = false;
            }

            if (TipoReporte.Equals("CANAL"))
            {
                string lsCriterio = "WHERE VBELN = '" + _idEntrega + "'"
                    + " AND WERKS ='" + _idCentro + "'";

                CLSLipsCollection colLips = new CLSLipsBAL().ConsultarLipsCollectionBAL(lsCriterio);
                IEnumerator listaLips = colLips.GetEnumerator();

                ClsPesoMatNCollection colPNMat = new ClsPesoMatNCollection();

                while (listaLips.MoveNext())
                {
                    lsCriterio = "";
                    CLSLips unaLips = (CLSLips)listaLips.Current;

                    lsCriterio = "WHERE VBELN = '" + _idEntrega + "'"
                    + " AND WERKS ='" + _idCentro + "'"
                    + " AND MATNR_PROD2_VIRT ='" + unaLips.Matnr + "'";

                    CLSFatomCollection colFatom = new CLSFatomBAL().MostrarFatomBAL(lsCriterio);
                    IEnumerator listaFa = colFatom.GetEnumerator();

                    double ldPesoAcumulado = 0.0;
                    int liContador = 0;


                    while (listaFa.MoveNext())
                    {
                        CLSFatom unaFatom = (CLSFatom)listaFa.Current;
                        liContador++;
                        ldPesoAcumulado = ldPesoAcumulado + unaFatom.Erfmg;

                    }

                    lsCriterio = "WHERE VBELN = '" + _idEntrega + "'"
                    + " AND WERKS ='" + _idCentro + "'"
                    + " AND MATNR ='" + unaLips.Matnr + "'";

                    CLSLipsBAL lipsBal = new CLSLipsBAL();

                    unaLips.Picking = ldPesoAcumulado;
                    unaLips.Uniemp = liContador;

                    lipsBal.ActualizarLIPSBAL(unaLips);

                }



            }

            ClsDetalleCollection detalleCollection = new ClsEntregasBAL().ConsultarDetalleBAL(IdEntrega, IdCentro);
            IEnumerator lista = detalleCollection.GetEnumerator();
            double diferencia = 0;

            while (lista.MoveNext())
            {
                var detalleObt = (ClsDetalle) lista.Current;

                if (!String.IsNullOrEmpty(detalleObt.Picking))
                {
                    diferencia = Convert.ToDouble(detalleObt.Cantidad) - Convert.ToDouble(detalleObt.Picking);


                    dgvLista.Rows.Add(detalleObt.Entrega, detalleObt.Fecha, detalleObt.Posicion, detalleObt.NumMaterial,
                                      detalleObt.Centro, detalleObt.Almacen,
                                      String.Format("{0:0.000}", detalleObt.Cantidad),
                                      String.Format("{0:0.000}", detalleObt.Picking),
                                      String.Format("{0:0.000}", diferencia),
                                      detalleObt.UnidadMed, detalleObt.Descripcion, detalleObt.UniE);
                }
                else
                {

                    dgvLista.Rows.Add(detalleObt.Entrega, detalleObt.Fecha, detalleObt.Posicion, detalleObt.NumMaterial,
                                      detalleObt.Centro, detalleObt.Almacen,
                                      String.Format("{0:0.000}", detalleObt.Cantidad),
                                      "0.000",
                                      String.Format("{0:0.000}", diferencia),
                                      detalleObt.UnidadMed, detalleObt.Descripcion, detalleObt.UniE);
                }
            }

            //Inicializar tabla temporal
            tablaTemporal = new DataTable();
            tablaTemporal.Columns.Add("tarima", typeof(string));
            tablaTemporal.Columns.Add("cajas", typeof(int));
            tablaTemporal.Columns.Add("peso", typeof(double));

            //Inicializar tabla producto
            tablaProducto = new DataTable();
            tablaProducto.Columns.Add("entrega", typeof(string));
            tablaProducto.Columns.Add("uniManip", typeof(string));
            tablaProducto.Columns.Add("material", typeof(string));
            tablaProducto.Columns.Add("denominacion", typeof(string));
            tablaProducto.Columns.Add("lote", typeof(string));
            tablaProducto.Columns.Add("pesoBruto", typeof(decimal));
            tablaProducto.Columns.Add("pesoNeto", typeof(decimal));
            tablaProducto.Columns.Add("piezas", typeof(int));
            tablaProducto.Columns.Add("fechaProd", typeof(DateTime));
            tablaProducto.Columns.Add("fechaCad", typeof(DateTime));

            //Inicializar tabla remision
            tablaRemision = new DataTable();
            tablaRemision.Columns.Add("cantidad", typeof(double));
            tablaRemision.Columns.Add("material", typeof(string));
            tablaRemision.Columns.Add("descripcion", typeof(string));
            tablaRemision.Columns.Add("pesoTotal", typeof(double));
            tablaRemision.Columns.Add("precioUnit", typeof(double));
        }

        private void PrintResumen()
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDialog.UseEXDialog = true; //Permite habilitar la caja de dialogo en Win 7 64

            try
            {
                printDialog.Document = printDocument;
                printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintResumen);

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

        void printDocument_PrintResumen(object sender, PrintPageEventArgs e)
        {
            string nombreEmpresa = "Comercializadora Porcícola Mexicana, S.A. de C.V.";
            string datos1Empresa = "Calle 27 A 495 Entre 56 y 56 A Col. Itzimna";
            string datos2Empresa = "C.P. 97100, Mérida, Yucatán, México";
            string datos3Empresa = "TEL: 999 930 2200   /  FAX:";
            string datos4Empresa = "RFC: CPM010703RD6";
            string noPedidoTitulo = "No. DE PEDIDO";
            string noEntregaTitulo = "No. ENTREGA";
            string clienteTitulo = "CLIENTE";
            string fechaEmbarqueTitulo = "FECHA DE EMBARQUE:";
            string fechaEntregaTitulo = "FECHA DE ENTREGA:";
            string columnasTitulo = "CODIGO".PadRight(20) + "DESCRIPCION".PadRight(60) + "UNI".PadRight(10) +
                                    "PRESENTACION".PadRight(30) + "KILOS".PadRight(15) + "KG ENTRG".PadRight(15) +
                                    "UNI EMP";
            string totalesTitulo = "TOTALES:";
            string observacionTitulo = "OBSERVACIONES PARA ENTREGA DEL PRODUCTO:";

            //Obtener la informacion de la BD
            DataSet dsResumen = new ClsEntregasBAL().ConsultarResumenBAL(IdEntrega, IdCentro);

            //Asignacion de valores
            string noPedido = dsResumen.Tables[0].Rows[0]["noPedido"].ToString();
            string nombreCliente = dsResumen.Tables[1].Rows[0]["nombreCliente"].ToString();
            string cp = dsResumen.Tables[1].Rows[0]["cp"].ToString();
            string rfc = dsResumen.Tables[1].Rows[0]["rfc"].ToString();
            string fechaEmbarque = Convert.ToDateTime(dsResumen.Tables[1].Rows[0]["fechaEmbarque"]).ToString("d");
            string fechaEntrega = Convert.ToDateTime(dsResumen.Tables[1].Rows[0]["fechaEntrega"]).ToString("d");

            Graphics graphic = e.Graphics;
            Font fontHeader = new Font("Courier New", 11);
            Font fontHeaderBold = new Font("Courier New", 11, FontStyle.Bold);
            Font fontHeaderTitle = new Font("Calibri", 11);
            Font fontHeaderFieldBold = new Font("Calibri", 10, FontStyle.Bold);
            Font fontHeaderTitleBig = new Font("Calibri", 12, FontStyle.Bold);
            Font fontDetail = new Font("Courier New", 8);
            SolidBrush brush = new SolidBrush(Color.Black);

            //Localizar el encabezado del documento
            Image header = Properties.Resources.logo_keken;
            Point headerPos = new Point(60, 60);

            //Imprimir encabezado
            graphic.DrawImage(header, headerPos);

            graphic.DrawRectangle(new Pen(brush), 620, 50, 160, 45);
            graphic.DrawRectangle(new Pen(brush), 620, 105, 160, 45);
            graphic.DrawRectangle(new Pen(brush), 480, 165, 300, 50);
            graphic.DrawRectangle(new Pen(brush), 45, 165, 400, 70);
            graphic.DrawRectangle(new Pen(brush), 45, 165, 400, 20);
            graphic.DrawRectangle(new Pen(brush), 45, 240, 735, 20);

            int startX = 210;
            int startY = 45;
            int offset = 15;

            //Definir posicion para titulos encabezado
            graphic.DrawString(nombreEmpresa, fontHeaderTitleBig, brush, startX, startY += offset);
            graphic.DrawString(datos1Empresa, fontHeaderTitle, brush, startX, startY += offset);
            graphic.DrawString(datos2Empresa, fontHeaderTitle, brush, startX, startY += offset);
            graphic.DrawString(datos3Empresa, fontHeaderTitle, brush, startX, startY += offset);
            graphic.DrawString(datos4Empresa, fontHeaderTitle, brush, startX, startY += offset);

            startX = 630;

            graphic.DrawString(noPedidoTitulo, fontHeaderFieldBold, brush, startX, 55);
            graphic.DrawString(noEntregaTitulo, fontHeaderFieldBold, brush, startX, 110);

            graphic.DrawString(clienteTitulo, fontHeaderFieldBold, brush, 55, 166);
            graphic.DrawString(fechaEmbarqueTitulo, fontHeaderFieldBold, brush, 490, 172);
            graphic.DrawString(fechaEntregaTitulo, fontHeaderFieldBold, brush, 490, 195);
            graphic.DrawString(columnasTitulo, fontHeaderFieldBold, brush, 55, 242);

            //Definir posicion para datos encabezado
            graphic.DrawString(noPedido, fontHeader, brush, 645, 77);
            graphic.DrawString(IdEntrega, fontHeader, brush, 645, 132);
            graphic.DrawString(nombreCliente, fontHeader, brush, 55, 186);
            graphic.DrawString(cp, fontHeader, brush, 55, 201);
            graphic.DrawString(rfc, fontHeader, brush, 55, 216);
            graphic.DrawString(fechaEmbarque, fontHeader, brush, 660, 174);
            graphic.DrawString(fechaEntrega, fontHeader, brush, 660, 197);

            //Definir la posicion para detalle
            startX = 50;
            startY = 230;
            offset = 40;
            float fontHeight = fontDetail.GetHeight();

            string totalUnidad = "0.000";
            double totalKilos = 0;

            DataTable dtDetalle = dsResumen.Tables[2];
            foreach (DataRow row in dtDetalle.Rows)
            {
                tablaTemporal.Clear();
                string codigo = row["material"].ToString().Trim();
                string descripcion = row["descripcion"].ToString().Trim();
                string unidad = row["centro"].ToString().Trim();
                string presentacion = row["presentacion"].ToString().Trim();
                string kilos = row["kilos"].ToString().Trim();
                string kgEntregados = row["kgEntrg"].ToString().Trim();
                string unidadEmpaque = row["uniEmp"].ToString().Trim();

                totalKilos += Convert.ToDouble(kilos);
                
                string lineaImpresion = codigo.PadRight(14) + 
                                        descripcion.PadRight(35) +
                                        unidad.PadRight(5) +
                                        presentacion.PadRight(22) +
                                        kilos.PadRight(10) +
                                        kgEntregados.PadRight(12) +
                                        unidadEmpaque;

                graphic.DrawString(lineaImpresion, fontDetail, brush, startX, startY + offset);
  
                offset = offset + (int)fontHeight + 5;

                if (Convert.ToInt16(unidadEmpaque) > 0)
                {
                    //Obtener los nuevos registros
                    DataSet dsResumenDetalle = new ClsEntregasBAL().ConsultarResumenDetalleBAL(IdEntrega, codigo, IdCentro);

                    DataTable dtDetalleResumen = dsResumenDetalle.Tables[0];

                    string tarimaPrevia = "";
                    int totalCajasPrevias = 0;
                    double pesoCajasPrevias = 0;
                    int totalRegistros = dtDetalleResumen.Rows.Count;
                    int contador = 0;

                    //Procesar las tarimas asociadas, contar el numero de cajas y el peso de las mismas
                    foreach (DataRow rowTmp in dtDetalleResumen.Rows)
                    {
                        string tarimaActual = rowTmp["idTarima"].ToString().Trim();
                        contador++;

                        //Solo existe un registro
                        if (dtDetalleResumen.Rows.Count == 1)
                        {
                            tablaTemporal.Rows.Add(tarimaActual, 1, Convert.ToDouble(rowTmp["cantidad"].ToString().Trim()));
                            break;
                        }
                        
                        //Existe mas de un registro
                        if (tarimaPrevia == "")
                        {
                            tarimaPrevia = tarimaActual;
                            totalCajasPrevias = 1;
                            pesoCajasPrevias = Convert.ToDouble(rowTmp["cantidad"].ToString().Trim());
                        }
                        else
                        {
                            //Se acumulan las tarimas con el mismo material
                            if (tarimaPrevia == tarimaActual)
                            {
                                tarimaPrevia = tarimaActual;
                                totalCajasPrevias++;
                                pesoCajasPrevias += Convert.ToDouble(rowTmp["cantidad"].ToString().Trim());

                                //Validar si se llegó al final de los registros
                                if (contador == totalRegistros)
                                    tablaTemporal.Rows.Add(tarimaActual, 1,
                                                           Convert.ToDouble(rowTmp["cantidad"].ToString().Trim()));
                            }
                            else
                            {
                                tablaTemporal.Rows.Add(tarimaPrevia, totalCajasPrevias, pesoCajasPrevias);
                                tarimaPrevia = tarimaActual;
                                totalCajasPrevias = 1;
                                pesoCajasPrevias = Convert.ToDouble(rowTmp["cantidad"].ToString().Trim());

                                //Validar si se llegó al final de los registros
                                if (contador == totalRegistros)
                                    tablaTemporal.Rows.Add(tarimaPrevia, totalCajasPrevias, pesoCajasPrevias);
                            }
                        }
                    }

                    //Imprimir linea con detalle de tarimas
                    foreach (DataRow rowTmp in tablaTemporal.Rows)
                    {
                        string impTarima = rowTmp["tarima"].ToString().Trim();
                        string impCajas = rowTmp["cajas"].ToString().Trim();
                        string impPesoCajas = rowTmp["peso"].ToString().Trim();

                        lineaImpresion = impTarima.PadRight(14) + impCajas.PadRight(14) + impPesoCajas;
                        graphic.DrawString(lineaImpresion, fontDetail, brush, startX + 100, startY + offset);

                        offset = offset + (int) fontHeight + 5;
                    }
                }
            }
            
            //Localizar el final del documento
            graphic.DrawRectangle(new Pen(brush), 45, 940, 735, 20);
            graphic.DrawRectangle(new Pen(brush), 45, 965, 735, 80);

            //Definir posicion para titulos pie
            graphic.DrawString(totalesTitulo, fontHeaderFieldBold, brush, 200, 940);
            graphic.DrawString(observacionTitulo, fontHeaderFieldBold, brush, 55, 972);

            //Localizar resultados
            graphic.DrawString(totalUnidad, fontDetail, brush, 400, 943);
            graphic.DrawString(String.Format("{0:0.000}", totalKilos), fontDetail, brush, 570, 943);
        }

        private void PrintRemision()
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDialog.UseEXDialog = true; //Permite habilitar la caja de dialogo en Win 7 64

            try
            {
                printDialog.Document = printDocument;
                printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintRemision);

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

        void printDocument_PrintRemision(object sender, PrintPageEventArgs e)
        {
            string lugarExpDir1 = "";
            string lugarExpDir2 = "";
            string lugarExpDir3 = "";

            string autorizacion = "";
            string certificado = "";
            string anioAprobacion = "";

            string clientePoblacion = "";
            string clienteCiudad = "";
            string clienteEstado = "";
            string clienteTipo = "";
            string clienteOrdenCompra;

            string destDireccion = "";
            string destDireccionComp = "";
            string destEstado = "";
            string destCp = "";

            string nombreEmpresa = "Comercializadora Porcícola Mexicana, S.A. de C.V.";
            string datos1Empresa = "Calle 27 A 495 Entre 56 y 56 A Col. Itzimna";
            string datos2Empresa = "C.P. 97100, Mérida, Yucatán, México";
            string datos3Empresa = "TEL: 999 930 2200   /  FAX:";
            string datos4Empresa = "RFC: CPM010703RD6";

            DataSet dsRemision;
            //Obtener la informacion de la BD

            if (_tipoReporte.Equals("CANAL"))
            {
                dsRemision = new ClsEntregasBAL().ConsultarRemisionCanalBAL(IdEntrega, IdCentro);
            }
            else
            {
                dsRemision = new ClsEntregasBAL().ConsultarRemisionBAL(IdEntrega, IdCentro);
            }

            //Asignacion de valores

            string clienteNombre = dsRemision.Tables[0].Rows[0]["nombreCliente"].ToString();
            string clienteCp = dsRemision.Tables[0].Rows[0]["cp"].ToString();
            string clienteRfc = dsRemision.Tables[0].Rows[0]["rfc"].ToString();
            clienteOrdenCompra = dsRemision.Tables[1].Rows[0]["nombreDestinatario"].ToString();
            string destNombre = dsRemision.Tables[1].Rows[0]["nombreDestinatario"].ToString();

            Graphics graphic = e.Graphics;
            Font fontFooter = new Font("Courier New", 7);
            Font fontHeader = new Font("Courier New", 8);
            Font fontHeaderBold = new Font("Courier New", 8, FontStyle.Bold);
            Font fontDetail = new Font("Courier New", 8);
            SolidBrush brush = new SolidBrush(Color.Black);
            
            int startX = 55;
            int startY = 25;
            int offset = 13;

            //Localizar el encabezado del documento
            Image header = Properties.Resources.logo_keken;
            Point headerPos = new Point(startX, startY);

            //Imprimir encabezado
            graphic.DrawImage(header, headerPos);

            //Imprimir cuadros
            //graphic.DrawRectangle(new Pen(brush), 45, 20, 750, 380);
            //graphic.DrawRectangle(new Pen(brush), 45, 410, 750, 640);
            graphic.DrawRectangle(new Pen(brush), 45, 20, 750, 340);
            graphic.DrawRectangle(new Pen(brush), 45, 370, 750, 660);
            
            //Redefinir posiciones
            startX = 60;
            startY = 87;

            //Definir posicion para titulos encabezado

            graphic.DrawString(nombreEmpresa, fontHeaderBold, brush, startX, startY += offset);
            graphic.DrawString(datos1Empresa, fontHeader, brush, startX, startY += offset);
            graphic.DrawString(datos2Empresa, fontHeader, brush, startX, startY += offset);
            graphic.DrawString(datos3Empresa, fontHeader, brush, startX, startY += offset);
            graphic.DrawString(datos4Empresa, fontHeader, brush, startX, startY + offset);

            startY = 155;
            offset = 15;

            graphic.DrawString("Lugar de Expedición: " + lugarExpDir1, fontHeader, brush, startX, startY += offset);
            graphic.DrawString(lugarExpDir2, fontHeader, brush, startX, startY += offset);
            graphic.DrawString(lugarExpDir3, fontHeader, brush, startX + 100, startY + offset);

            startY = 190;// 215;

            graphic.DrawString("CLIENTE", fontHeaderBold, brush, startX, startY += offset);
            graphic.DrawString(clienteNombre, fontHeader, brush, startX, startY += offset);
            graphic.DrawString(clientePoblacion, fontHeader, brush, startX, startY += offset);
            graphic.DrawString(clienteCiudad, fontHeader, brush, startX, startY += offset);
            graphic.DrawString(clienteEstado, fontHeader, brush, startX, startY += offset);
            graphic.DrawString("CP: " + clienteCp, fontHeader, brush, startX, startY += offset);
            graphic.DrawString("R.F.C. " + clienteRfc, fontHeader, brush, startX + 100, startY);

            startY = 295;// 320;
            offset = 20;

            graphic.DrawString(clienteTipo, fontHeader, brush, startX, startY += offset);
            graphic.DrawString("Orden de Compra: " + clienteOrdenCompra, fontHeader, brush, startX, startY + offset);

            startX = 510;
            startY = 135;
            offset = 15;

            graphic.DrawString("Autorización: " + autorizacion, fontHeader, brush, startX, startY += offset);
            graphic.DrawString("Certificado: " + certificado, fontHeader, brush, startX, startY += offset);
            graphic.DrawString("Año de Aprobación: " + anioAprobacion, fontHeader, brush, startX, startY + offset);

            startX = 450;
            startY = 190;// 215;

            graphic.DrawString("DESTINATARIO DE MERCANCIAS", fontHeaderBold, brush, startX, startY += offset);
            graphic.DrawString(destNombre, fontHeader, brush, startX, startY += offset);
            graphic.DrawString(destDireccion, fontHeader, brush, startX, startY += offset);
            graphic.DrawString(destDireccionComp, fontHeader, brush, startX, startY += offset);
            graphic.DrawString(destEstado, fontHeader, brush, startX, startY += offset);
            graphic.DrawString("CP:" + destCp, fontHeader, brush, startX, startY + offset);

            //Definir la posicion para detalle
            startX = 80;
            startY = 380;// 420;
            offset = 40;
            float fontHeight = fontDetail.GetHeight();

            string columnasTitulo = "CANTIDAD".PadRight(10) + "DESCRIPCION".PadRight(35) + "PESO PROM".PadRight(15) +
                                    "PESO TOTAL".PadRight(15) + "PRECIO UNIT".PadRight(15) + "IMPORTE";
            graphic.DrawString(columnasTitulo, fontHeader, brush, startX, startY);
            //graphic.DrawLine(new Pen(brush), 60, 440, 770, 440);
            graphic.DrawLine(new Pen(brush), 60, 400, 770, 400);

            string materialPrevio = "";
            double cantidadPrevia = 0;
            string descripcionPrevia = "";
            double pesoTotalPrevio = 0;
            double precioUnitPrevio = 0;

            int contador = 0;

            DataTable dtDetalle = dsRemision.Tables[2];
            int totalRegistros = dtDetalle.Rows.Count;

            foreach (DataRow rowTmp in dtDetalle.Rows)
            {
                string materialActual = rowTmp["material"].ToString().Trim();
                contador++;

                //Solo existe un registro
                if (dtDetalle.Rows.Count == 1)
                {
                    cantidadPrevia = 1;
                    descripcionPrevia = rowTmp["descripcion"].ToString().Trim();
                    pesoTotalPrevio = Convert.ToDouble(rowTmp["pesoTotal"].ToString());
                    precioUnitPrevio = Convert.ToDouble(rowTmp["precioUnit"].ToString());

                    tablaRemision.Rows.Add(cantidadPrevia, materialActual, descripcionPrevia, pesoTotalPrevio, precioUnitPrevio);
                    break;
                }

                //Existe mas de un registro
                if (materialPrevio == "")
                {
                    materialPrevio = materialActual;
                    cantidadPrevia = 1;
                    descripcionPrevia = rowTmp["descripcion"].ToString().Trim();
                    pesoTotalPrevio = Convert.ToDouble(rowTmp["pesoTotal"].ToString());
                    precioUnitPrevio = Convert.ToDouble(rowTmp["precioUnit"].ToString());
                }
                else
                {
                    //Se acumulan las tarimas con el mismo material
                    if (materialPrevio == materialActual)
                    {
                        materialPrevio = materialActual;
                        cantidadPrevia++;
                        descripcionPrevia = rowTmp["descripcion"].ToString().Trim();
                        pesoTotalPrevio += Convert.ToDouble(rowTmp["pesoTotal"].ToString());
                        precioUnitPrevio += Convert.ToDouble(rowTmp["precioUnit"].ToString());

                        //Validar si se llegó al final de los registros
                        if (contador == totalRegistros)
                            tablaRemision.Rows.Add(cantidadPrevia, materialPrevio, descripcionPrevia, pesoTotalPrevio, precioUnitPrevio);
                    }
                    else
                    {
                        tablaRemision.Rows.Add(cantidadPrevia, materialPrevio, descripcionPrevia, pesoTotalPrevio, precioUnitPrevio);
                        materialPrevio = materialActual;
                        cantidadPrevia = 1;
                        descripcionPrevia = rowTmp["descripcion"].ToString().Trim();
                        pesoTotalPrevio = Convert.ToDouble(rowTmp["pesoTotal"].ToString());
                        precioUnitPrevio = Convert.ToDouble(rowTmp["precioUnit"].ToString());

                        //Validar si se llegó al final de los registros
                        if (contador == totalRegistros)
                            tablaRemision.Rows.Add(cantidadPrevia, materialPrevio, descripcionPrevia, pesoTotalPrevio, precioUnitPrevio);
                    }
                }
            }

            string iva = "0.00";
            double subTotalTemporal = 0;
            double ivaTemporal = 0;
            double totalTemporal = 0;

            foreach (DataRow row in tablaRemision.Rows)
            {
                string cantidad = row["cantidad"].ToString();
                string descripcion = row["descripcion"].ToString().Trim();
                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex(@"[ ]{2,}", options);
                descripcion = regex.Replace(descripcion, @" ");
                string pesoTotal = String.Format("{0:0.00}", Convert.ToDouble(row["pesoTotal"].ToString()));
                string precioUnit = String.Format("{0:0.00}", Convert.ToDouble(row["precioUnit"].ToString()));
                string pesoProm = String.Format("{0:0.00}", Convert.ToDouble(pesoTotal) / Convert.ToDouble(cantidad));
                string importe = String.Format("{0:0.00}", Convert.ToDouble(pesoTotal) * Convert.ToDouble(precioUnit));
                subTotalTemporal += Convert.ToDouble(importe);

                string lineaImpresion = cantidad.PadLeft(8) + "  " +
                                        descripcion.PadRight(35) +
                                        pesoProm.PadLeft(10) +
                                        pesoTotal.PadLeft(15) +
                                        precioUnit.PadLeft(15) +
                                        importe.PadLeft(12);

                graphic.DrawString(lineaImpresion, fontDetail, brush, startX, startY + offset);

                offset += (int)fontHeight + 5;
            }


            offset += 10;

            graphic.DrawLine(new Pen(brush), 60, startY + offset, 770, startY + offset);
            offset += 10;

            string subTotal = subTotalTemporal.ToString();
            graphic.DrawString("SUBTOTAL".PadRight(20) + subTotal.PadLeft(16), fontDetail, brush, 500, startY + offset);
            offset += (int)fontHeight + 5;

            graphic.DrawString("IVA".PadRight(20) + iva.PadLeft(16), fontDetail, brush, 500, startY + offset);
            offset += (int)fontHeight + 5;

            totalTemporal = ivaTemporal + subTotalTemporal;
            string total = totalTemporal.ToString();
            graphic.DrawString("TOTAL".PadRight(20) + total.PadLeft(16), fontDetail, brush, 500, startY + offset);
            offset += (int)fontHeight + 5;

            graphic.DrawLine(new Pen(brush), 500, startY + offset, 770, startY + offset);
            offset += (int)fontHeight + 5;

            string totalLetra = Conversion.Enletras(total.Replace(",", ""));
            graphic.DrawString(totalLetra, fontDetail, brush, startX, startY + offset);

            string cadena =
                "Debe (mos) y pagare (mos) incondicionalmente por este Pagaré a la orden de Comercializadora " +
                "Porcícola Mexicana, S.A. de C.V. en Mérida, Yucatán el día *FECHA* la cantidad de $ *CANTIDAD* (*LETRA*), " +
                "valor recibido a mi (nuestra) entera satisfacción. A partir de la fecha de su vencimiento, de no haber sido " +
                "pagado causará intereses moratorios a la tasa de 6 % mensual, pagadero en esta ciudad juntamente con el " +
                "principal. Para la interpretación y cumplimiento de este pagaré, nos sometemos a las leyes y a la jurisdicción " +
                "de los tribunales competentes de esta ciudad renunciando expresamente al fuero que pudiera correspondernos " +
                "por razón de nuestros domicilios actuales o futuros o por cualquier causa.";

            cadena = cadena.Replace("*FECHA*", DateTime.Now.ToString());
            cadena = cadena.Replace("*CANTIDAD*", total);
            cadena = cadena.Replace("*LETRA*", totalLetra);

            graphic.DrawLine(new Pen(brush), 60, 890, 770, 890);

            graphic.DrawString(cadena, fontFooter, brush, new RectangleF(100, 910, 650, 500));
        }

        private void PrintProducto()
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDialog.UseEXDialog = true; //Permite habilitar la caja de dialogo en Win 7 64

            try
            {
                printDialog.Document = printDocument;
                printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintProducto);
                printDocument.DefaultPageSettings.Landscape = true;

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

        void printDocument_PrintProducto(object sender, PrintPageEventArgs e)
        {
            //Obtener la informacion de la BD
            DataSet dsProducto = new ClsEntregasBAL().ConsultarProductoBAL(IdEntrega, IdCentro);

            Graphics graphic = e.Graphics;
            Font fontHeader = new Font("Courier New", 11);
            Font fontHeaderBold = new Font("Courier New", 11, FontStyle.Bold);
            Font fontHeaderTitle = new Font("Calibri", 11);
            Font fontHeaderFieldBold = new Font("Calibri", 10, FontStyle.Bold);
            Font fontHeaderTitleBig = new Font("Calibri", 12, FontStyle.Bold);
            Font fontDetail = new Font("Courier New", 8);
            SolidBrush brush = new SolidBrush(Color.Black);

            //Definir la posicion para detalle
            int startX = 100;
            int startY = 70;
            int offset = 40;
            float fontHeight = fontDetail.GetHeight();

            string lineaImpresion = "Entrega".PadRight(12) +
                                    "Un.Manip.".PadRight(12) +
                                    "Material".PadRight(10) +
                                    "Denominación".PadRight(15) +
                                    "Lote".PadRight(12) +
                                    "Peso Bruto".PadRight(12) +
                                    "Peso Neto".PadRight(12) +
                                    "Piezas".PadRight(10) +
                                    "Fecha Prod.".PadRight(12) +
                                    "Fecha Cad.";

            graphic.DrawLine(new Pen(brush), 100, startY + offset, 990, startY + offset);
            offset += 10;
            graphic.DrawString(lineaImpresion, fontDetail, brush, startX, startY + offset);
            offset = offset + (int)fontHeight + 5;
            graphic.DrawLine(new Pen(brush), 100, startY + offset, 990, startY + offset);
            offset += 10;

            string materialPrevio = "";
            string materialActual = "";
            double pesoBrutoTemporal = 0;
            double pesoNetoTemporal = 0;
            int piezasTemporal = 0;
            int contador = 0;
            double totalPesoBruto = 0;
            double totalPesoNeto = 0;
            int totalPiezas = 0;
            
            DataTable dtProducto = dsProducto.Tables[0];
            int totalRegistros = dtProducto.Rows.Count;
            string denominacionAnterior = "";

            foreach (DataRow row in dtProducto.Rows)
            {
                contador++;
                
                string entrega = row["entrega"].ToString().Trim();
                string uniManip = row["uniManip"].ToString().Trim();
                string material = row["material"].ToString().Trim();
                string denominacion = row["denominacion"].ToString().Trim().Substring(0,10);
                string denominacionCompleta = row["denominacion"].ToString().Trim();
                string lote = row["lote"].ToString().Trim();
                string pesoBruto = String.Format("{0:0.000}", Convert.ToDouble(row["pesoBruto"].ToString()));
                string pesoNeto = String.Format("{0:0.000}", Convert.ToDouble(row["pesoNeto"].ToString().Trim()));
                string piezas = row["piezas"].ToString().Trim();
                string fechaProd = Convert.ToDateTime(row["fechaProd"].ToString().Trim()).ToString("d");
                string fechaCad = Convert.ToDateTime(row["fechaCad"].ToString().Trim()).ToString("d");

                materialActual = material;

                //Validaciones para impresion de acumulados              
                if (dtProducto.Rows.Count == 1)
                {
                    lineaImpresion = entrega.PadRight(12) +
                             uniManip.PadRight(12) +
                             material.PadRight(10) +
                             denominacion.PadRight(15) +
                             lote.PadRight(12) +
                             pesoBruto.PadLeft(10) +
                             pesoNeto.PadLeft(10) +
                             piezas.PadLeft(10) +
                             fechaProd.PadLeft(12) +
                             fechaCad.PadLeft(12);

                    graphic.DrawString(lineaImpresion, fontDetail, brush, startX, startY + offset);
                    offset = offset + (int)fontHeight + 5;

                    pesoBrutoTemporal += Convert.ToDouble(pesoBruto);
                    pesoNetoTemporal += Convert.ToDouble(pesoNeto);
                    piezasTemporal++;

                    lineaImpresion = denominacion.PadRight(59) +
                                  String.Format("{0:0.000}", Convert.ToDouble(pesoBrutoTemporal.ToString())).PadLeft(22) +
                                  String.Format("{0:0.000}", Convert.ToDouble(pesoNetoTemporal.ToString())).PadLeft(10) +
                                  piezasTemporal.ToString().PadLeft(10);

                    totalPesoBruto += Convert.ToDouble(pesoBrutoTemporal.ToString());
                    totalPesoNeto += Convert.ToDouble(pesoNetoTemporal.ToString());
                    totalPiezas += piezasTemporal;

                    graphic.DrawString(lineaImpresion, fontDetail, brush, startX, startY + offset);
                    offset = offset + (int)fontHeight + 5;
                    graphic.DrawLine(new Pen(brush), 100, startY + offset, 990, startY + offset);
                    offset += 10;

                    break;
                }

                //Existe mas de un registro
                if (materialPrevio == "")
                {
                    lineaImpresion = entrega.PadRight(12) +
                             uniManip.PadRight(12) +
                             material.PadRight(10) +
                             denominacion.PadRight(15) +
                             lote.PadRight(12) +
                             pesoBruto.PadRight(12) +
                             pesoNeto.PadRight(12) +
                             piezas.PadRight(10) +
                             fechaProd.PadRight(12) +
                             fechaCad;
                             /*pesoBruto.PadLeft(10) +
                             pesoNeto.PadLeft(10) +
                             piezas.PadLeft(10) +
                             fechaProd.PadLeft(12) +
                             fechaCad.PadLeft(12);*/

                    graphic.DrawString(lineaImpresion, fontDetail, brush, startX, startY + offset);
                    offset = offset + (int)fontHeight + 5;

                    denominacionAnterior = denominacionCompleta;
                    materialPrevio = materialActual;
                    pesoBrutoTemporal = Convert.ToDouble(pesoBruto);
                    pesoNetoTemporal = Convert.ToDouble(pesoNeto);
                    piezasTemporal = 1;
                }
                else
                {
                    //Se acumulan las tarimas con el mismo material
                    if (materialPrevio == materialActual)
                    {
                        lineaImpresion = entrega.PadRight(12) +
                             uniManip.PadRight(12) +
                             material.PadRight(10) +
                             denominacion.PadRight(15) +
                             lote.PadRight(12) +
                             pesoBruto.PadRight(12) +
                             pesoNeto.PadRight(12) +
                             piezas.PadRight(10) +
                             fechaProd.PadRight(12) +
                             fechaCad;
                             /*pesoBruto.PadLeft(10) +
                             pesoNeto.PadLeft(10) +
                             piezas.PadLeft(10) +
                             fechaProd.PadLeft(12) +
                             fechaCad.PadLeft(12);*/

                        graphic.DrawString(lineaImpresion, fontDetail, brush, startX, startY + offset);
                        offset = offset + (int)fontHeight + 5;

                        materialPrevio = materialActual;
                        pesoBrutoTemporal += Convert.ToDouble(pesoBruto);
                        pesoNetoTemporal += Convert.ToDouble(pesoNeto);
                        piezasTemporal++;

                        //Validar si se llegó al final de los registros
                        if (contador == totalRegistros)
                        {
                            lineaImpresion = denominacionCompleta.PadRight(57) +
                                  String.Format("{0:0.000}", Convert.ToDouble(pesoBrutoTemporal.ToString())).PadLeft(10) +
                                  String.Format("{0:0.000}", Convert.ToDouble(pesoNetoTemporal.ToString())).PadLeft(12) +
                                  piezasTemporal.ToString().PadLeft(7);

                            totalPesoBruto += Convert.ToDouble(pesoBrutoTemporal.ToString());
                            totalPesoNeto += Convert.ToDouble(pesoNetoTemporal.ToString());
                            totalPiezas += piezasTemporal;

                            graphic.DrawString(lineaImpresion, fontDetail, brush, startX, startY + offset);
                            offset = offset + (int) fontHeight + 5;
                            graphic.DrawLine(new Pen(brush), 100, startY + offset, 990, startY + offset);
                            offset += 10;
                        }
                    }
                    else
                    {
                        lineaImpresion = denominacionAnterior.PadRight(57) +
                                  String.Format("{0:0.000}", Convert.ToDouble(pesoBrutoTemporal.ToString())).PadLeft(10) +
                                  String.Format("{0:0.000}", Convert.ToDouble(pesoNetoTemporal.ToString())).PadLeft(12) +
                                  piezasTemporal.ToString().PadLeft(7);

                        /*lineaImpresion = denominacionAnterior.PadRight(59) +
                                  String.Format("{0:0.000}", Convert.ToDouble(pesoBrutoTemporal.ToString())).PadLeft(22) +
                                  String.Format("{0:0.000}", Convert.ToDouble(pesoNetoTemporal.ToString())).PadLeft(10) +
                                  piezasTemporal.ToString().PadLeft(10);*/

                        totalPesoBruto += Convert.ToDouble(pesoBrutoTemporal.ToString());
                        totalPesoNeto += Convert.ToDouble(pesoNetoTemporal.ToString());
                        totalPiezas += piezasTemporal;

                        graphic.DrawString(lineaImpresion, fontDetail, brush, startX, startY + offset);
                        offset = offset + (int) fontHeight + 5;
                        graphic.DrawLine(new Pen(brush), 100, startY + offset, 990, startY + offset);
                        offset += 10;

                        lineaImpresion = entrega.PadRight(12) +
                             uniManip.PadRight(12) +
                             material.PadRight(10) +
                             denominacion.PadRight(15) +
                             lote.PadRight(12) +
                             pesoBruto.PadRight(12) +
                             pesoNeto.PadRight(12) +
                             piezas.PadRight(10) +
                             fechaProd.PadRight(12) +
                             fechaCad; 
                             /*pesoBruto.PadLeft(10) +
                             pesoNeto.PadLeft(10) +
                             piezas.PadLeft(10) +
                             fechaProd.PadLeft(12) +
                             fechaCad.PadLeft(12);*/

                        graphic.DrawString(lineaImpresion, fontDetail, brush, startX, startY + offset);
                        offset = offset + (int)fontHeight + 5;

                        denominacionAnterior = denominacionCompleta;
                        materialPrevio = materialActual;
                        pesoBrutoTemporal = Convert.ToDouble(pesoBruto);
                        pesoNetoTemporal = Convert.ToDouble(pesoNeto);
                        piezasTemporal = 1;

                        //Validar si se llegó al final de los registros
                        if (contador == totalRegistros)
                        {
                            lineaImpresion = denominacionCompleta.PadRight(59) +
                                  String.Format("{0:0.000}", Convert.ToDouble(pesoBrutoTemporal.ToString())).PadLeft(22) +
                                  String.Format("{0:0.000}", Convert.ToDouble(pesoNetoTemporal.ToString())).PadLeft(10) +
                                  piezasTemporal.ToString().PadLeft(10);

                            totalPesoBruto += Convert.ToDouble(pesoBrutoTemporal.ToString());
                            totalPesoNeto += Convert.ToDouble(pesoNetoTemporal.ToString());
                            totalPiezas += piezasTemporal;

                            graphic.DrawString(lineaImpresion, fontDetail, brush, startX, startY + offset);
                            offset = offset + (int) fontHeight + 5;
                            graphic.DrawLine(new Pen(brush), 100, startY + offset, 990, startY + offset);
                            offset += 10;
                        }
                    }
                }
                
            }

            lineaImpresion = String.Format("{0:0.000}", totalPesoBruto).PadLeft(67) +
                             String.Format("{0:0.000}", totalPesoNeto).PadLeft(12) +
                             totalPiezas.ToString().PadLeft(7);
            graphic.DrawString(lineaImpresion, fontDetail, brush, startX, startY + offset);
        }

        private void PrintCanal()
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printDocument = new PrintDocument();
            printDialog.UseEXDialog = true; //Permite habilitar la caja de dialogo en Win 7 64
            try
            {
                printDialog.Document = printDocument;
                printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintCanal);

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

        void printDocument_PrintCanal(object sender, PrintPageEventArgs e)
        {
            string nombreEmpresa = "Comercializadora Porcícola Mexicana, S.A. de C.V.";
            string datos1Empresa = "Calle 27 A 495 Entre 56 y 56 A Col. Itzimna";
            string datos2Empresa = "C.P. 97100, Mérida, Yucatán, México";
            string datos3Empresa = "TEL: 999 930 2200   /  FAX:";
            string datos4Empresa = "RFC: CPM010703RD6";
            string noPedidoTitulo = "No. DE PEDIDO";
            string noEntregaTitulo = "No. ENTREGA";
            string clienteTitulo = "TRASPASO DE CANALES";
            string columnasTitulo = "POS".PadRight(5) + "MATERIAL".PadRight(15) + "DESCRIPCION".PadRight(45) +
                                    "Picking".PadLeft(10) + "  UM".PadRight(10) + "Ctd. Pick.".PadRight(13) + 
                                    "FOLIO".PadRight(17) + "LOTE".PadRight(27) + "FECHA";

            //Obtener la informacion de la BD
            DataSet dsResumen = new ClsEntregasBAL().ConsultarCanalBAL(IdEntrega, IdCentro);

            string noPedido = dsResumen.Tables[0].Rows[0]["noPedido"].ToString();

            Graphics graphic = e.Graphics;
            Font fontHeader = new Font("Courier New", 11);
            Font fontHeaderBold = new Font("Courier New", 11, FontStyle.Bold);
            Font fontHeaderTitle = new Font("Calibri", 11);
            Font fontHeaderFieldBold = new Font("Calibri", 10, FontStyle.Bold);
            Font fontHeaderTitleBig = new Font("Calibri", 12, FontStyle.Bold);
            Font fontDetail = new Font("Courier New", 8);
            SolidBrush brush = new SolidBrush(Color.Black);

            //Localizar el encabezado del documento
            Image header = Properties.Resources.logo_keken;
            Point headerPos = new Point(60, 60);

            //Imprimir encabezado
            graphic.DrawImage(header, headerPos);

            graphic.DrawRectangle(new Pen(brush), 620, 50, 160, 45);
            graphic.DrawRectangle(new Pen(brush), 620, 105, 160, 45);
            graphic.DrawRectangle(new Pen(brush), 45, 165, 400, 20);

            int startX = 210;
            int startY = 45;
            int offset = 15;

            //Definir posicion para titulos encabezado
            graphic.DrawString(nombreEmpresa, fontHeaderTitleBig, brush, startX, startY += offset);
            graphic.DrawString(datos1Empresa, fontHeaderTitle, brush, startX, startY += offset);
            graphic.DrawString(datos2Empresa, fontHeaderTitle, brush, startX, startY += offset);
            graphic.DrawString(datos3Empresa, fontHeaderTitle, brush, startX, startY += offset);
            graphic.DrawString(datos4Empresa, fontHeaderTitle, brush, startX, startY += offset);

            startX = 630;

            graphic.DrawString(noPedidoTitulo, fontHeaderFieldBold, brush, startX, 55);
            graphic.DrawString(noEntregaTitulo, fontHeaderFieldBold, brush, startX, 110);
            graphic.DrawString(clienteTitulo, fontHeaderFieldBold, brush, 55, 166);
            graphic.DrawString(columnasTitulo, fontHeaderFieldBold, brush, 50, 200);
            graphic.DrawString(noPedido, fontHeader, brush, 645, 77);
            graphic.DrawString(IdEntrega, fontHeader, brush, 645, 132);

            //Definir la posicion para detalle
            startX = 50;
            startY = 190;
            offset = 40;
            float fontHeight = fontDetail.GetHeight();

            double totalPicking = 0;
            int totalPiezas = 0;
            DataTable dtDetalle = dsResumen.Tables[1];
            foreach (DataRow row in dtDetalle.Rows)
            {
                string posicion = row["posicion"].ToString().Trim();
                string material = row["material"].ToString().Trim();
                string descripcion = row["descripcion"].ToString().Trim();
                string picking = String.Format("{0:0.00}", Convert.ToDouble(row["picking"].ToString()));
                string uniMed = row["uniMed"].ToString().Trim();
                string cantidad = row["Cantidad"].ToString().Trim();
                string folio = row["folio"].ToString().Trim();
                string lote = row["lote"].ToString().Trim();
                string fecha = Convert.ToDateTime(row["fecha"]).ToString("d");

                string lineaImpresion = posicion.PadRight(5) +
                                        material.PadRight(15) +
                                        descripcion.PadRight(26) +
                                        picking.PadLeft(5) + " " +
                                        uniMed.PadRight(8) +
                                        cantidad.PadRight(8) +
                                        folio.PadRight(10) +
                                        lote.PadRight(15) +
                                        fecha;

                graphic.DrawString(lineaImpresion, fontDetail, brush, startX, startY + offset);

                offset = offset + (int) fontHeight + 5;
                totalPicking += Convert.ToDouble(picking);
                totalPiezas++;
            }
            
            string lineaImpresionResultado = String.Format("{0:0.00}", totalPicking).PadLeft(51) + totalPiezas.ToString().PadLeft(10);

            graphic.DrawString(lineaImpresionResultado, fontDetail, brush, startX, startY + offset);
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            if (_tipoReporte == "CANAL" || _tipoReporte == "PRODUCTO")
            {   
                PrintResumen();
            }
            else
            {
                PrintRemision();
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (_tipoReporte == "PRODUCTO")
                PrintProducto();
            else 
                PrintCanal();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            PrintProducto();
        }


    }
}