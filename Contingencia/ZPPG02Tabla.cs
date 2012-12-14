using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

/*
* Autor: Enrique Santana
* Fecha de creación: 02/05/2012
* Fecha de liberación: 04/06/2012
* Descripción: Tabla de folios del día
*/

namespace Contingencia
{
    public partial class ZPPG02Tabla : FrmBase
    {

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Declaracion de variables
         */

        //private ArrayList fatiList = new ArrayList();

        private int celda = 0;

        private CLSFatom contenedor;
        public CLSFatom Contenedor
        {
            get { return contenedor; }
            set { contenedor = value; }
        }

        private ArrayList matnrG = new ArrayList();
        private ArrayList codDestinoG = new ArrayList();

        private string centro;
        public string Centro
        {
            get { return centro; }
            set { centro = value; }
        }

        private DateTime fecha;
        public DateTime Fecha1
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string codDestino;
        public string CodDestino
        {
            get { return codDestino; }
            set { codDestino = value; }
        }

        private string calidad;
        public string Calidad1
        {
            get { return calidad; }
            set { calidad = value; }
        }

        private string lote;
        public string Lote1
        {
            get { return lote; }
            set { lote = value; }
        }

        private bool pendiente;
        public bool Pendiente
        {
            get { return pendiente; }
            set { pendiente = value; }
        }

        private bool procesado1;
        public bool Procesado1
        {
            get { return procesado1; }
            set { procesado1 = value; }
        }

        public ZPPG02Tabla()
        {
            InitializeComponent();
        }

        private void ZPPG02Tabla_Load(object sender, EventArgs e)
        {
            bool llenado;

            base.PonerTitulo("Procesamiento de Folios - 2da. estación Umán.");
            llenado = LlenarTabla();
            if(!llenado) {             
                Regresar();
                return;
            }
            dgvFatom.Rows[0].Cells[0].Selected = false;
            dgvFatom.Rows[0].Cells[6].Selected = true;
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Regresa al formulario anterior y manda el error
         */

        private void Regresar() {
            FrmZPPG02 zppg02 = new FrmZPPG02();
            this.Hide();
            zppg02.MensajeError = "No hay datos para la seleccion";
            zppg02.Centro = this.centro;
            zppg02.ShowDialog();
            this.Dispose();
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Llena la tabla de folios
         */

        private bool LlenarTabla() 
        {    
            CLSFatomCollection tabla;
            string fechaFolio = fecha.ToString("yyyy-MM-dd 00:00:00");
            string fechaSiguiente = fecha.AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            bool pesarCab = false;
            bool llenado = false;

            string criterio = "WHERE (WERKS = '" + centro + "') ";
            criterio = criterio + "AND (FECHA >= CONVERT(DATETIME, '" + fechaFolio + "', 120)) ";
            criterio = criterio + "AND (FECHA <= CONVERT(DATETIME, '" + fechaSiguiente + "', 120)) ";
            if(codDestino.Length > 0) {
                criterio = criterio + "AND (CODDESTINO = '" + codDestino + "') ";
            }
            if(calidad.Length > 0) {
                criterio = criterio + "AND (CALIDAD = '" + calidad + "') ";
            }
            if(lote.Length > 0) {
                criterio = criterio + "AND (CHARG = '" + lote + "') ";
            }
            if (pendiente && !procesado1)
            {
                criterio = criterio + "AND (ESTADO = ' ')";
            }
            else if (!pendiente && procesado1)
            {
                criterio = criterio + "AND (ESTADO = 'X')";
            }
            tabla = new CLSFatomBAL().MostrarFatomBAL(criterio);
            IEnumerator lista = tabla.GetEnumerator();
            if(tabla.Count > 0) {
                llenado = true;
            }

            while (lista.MoveNext())
            {
                CLSFatom fatometer = (CLSFatom)lista.Current;
                if (fatometer.PesarCab == "X") { pesarCab = true; }
                else { pesarCab = false; }
                if (fatometer.Procesado == "X") { dgvFatom.ReadOnly = true; }
                dgvFatom.Rows.Add(fatometer.Charg, fatometer.Fecha.Date.ToString("dd.MM.yyyy"), fatometer.Folio, fatometer.Erfmg, fatometer.Tatuaje, fatometer.Calidad, fatometer.CodDestino,
                    fatometer.Destino, fatometer.Musculo, fatometer.Grasa, fatometer.Chuleta, pesarCab, fatometer.PesoCab, fatometer.Procesado);
                matnrG.Add(fatometer.Matnr);
                codDestinoG.Add(fatometer.CodDestino);

            }
            return llenado;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMarcarT_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvFatom.Rows.Count; i++)
            {
                dgvFatom.Rows[i].Selected = true; 
            }
        }

        private void btnDesmT_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvFatom.Rows.Count; i++)
            {
                dgvFatom.Rows[i].Selected = false; 
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                MensajeApagar();
                RevisarDestino();
                ActualizarFatom();
                MostrarMensaje("Folios procesados!");
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
         * Descripción: Valida que el destino exista de manera individual
         */

        private void RevisaUnicoDestino()
        {
            CLSCatDestinoCollection desCol;
            desCol = new CLSCatDestinoBAL().MostrarCatDestinoBAL("");
            string destino = dgvFatom.CurrentRow.Cells[6].Value.ToString().Trim();
            int cont = 0;
            int longitud = desCol.Count;

            for (int i = 0; i < longitud; i++)
            { 
                string destinoCol = desCol[i].CodDestino.ToString().Trim();

                if(destino != destinoCol)
                {
                    cont++;
                    if (cont >= longitud)
                    {
                        throw new Exception("El destino no existe!");
                    }
                    continue;
                }
            }
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Valida que cada destino exista
         */

        private void RevisarDestino() {
            CLSCatDestinoCollection desCol;
            desCol = new CLSCatDestinoBAL().MostrarCatDestinoBAL("");
            //IEnumerator lista = desCol.GetEnumerator();
            
            int elGrid = dgvFatom.Rows.Count;
            int laColec = desCol.Count;
            
            //CLSCatDestino destino;

            /*while (lista.MoveNext())
            {
                CLSCatDestino destino = (CLSCatDestino)lista.Current;
                desCol.Add(destino);
            }*/

            for (int i = 0; i < elGrid; i++)
            {
                int cont = 0;

                for (int m = 0; m < laColec; m++)
                {
                    string cadenaGrid = dgvFatom.Rows[i].Cells[6].Value.ToString().Trim();
                    string cadenaCol = desCol[m].CodDestino.ToString().Trim();

                    if (cadenaGrid != cadenaCol)
                    {
                        cont++;
                        if (cont >= laColec)
                        {
                            throw new Exception("El destino no existe!");
                        }
                        continue;
                    }
                }
            }
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Actualiza la descripcion del destino en la DB
         */

        private void ActualizarDescripcion(CLSFatom fatom, int index) {
            CLSCatDestinoCollection destino = new CLSCatDestinoBAL().MostrarCatDestinoBAL("");
            CLSFatomBAL fatoBal = new CLSFatomBAL();
            //CLSFatomCollection fatoCol;
            string criterio = "WHERE (CODDESTINO = '" + fatom.CodDestino.ToString() + "')";
            criterio = criterio + "AND (WERKS = '" + fatom.Werks + "')";
            string destinoPar = "";
            string pesarCab = "";
            bool pesarCabLog = false;
            //dgvFatom.Rows[index].Cells.
            for (int i = 0; i < destino.Count; i++)
			{
			    if(fatom.CodDestino.ToString() == destino[i].CodDestino.ToString()) {
                    destinoPar = destino[i].DescDestino;
                    pesarCab = destino[i].PesarCab;
                    if (pesarCab == "X")
                    {
                        pesarCabLog = true;
                    }
                    else 
                    {
                        pesarCabLog = false;
                    }
                    fatom.Matnr = destino[i].MatnrComp.ToString();
                    if (fatom.Matnr != matnrG[index].ToString())
                    {
                        dgvFatom.Rows[index].Cells[6].Value = codDestinoG[index].ToString();
                        throw new Exception("No se puede cambiar el destino del folio " + fatom.Folio + "!");
                    }
                    fatom.Destino = destinoPar;
                    fatom.PesarCab = pesarCab;
                    dgvFatom.Rows[index].Cells[7].Value = destinoPar;
                    dgvFatom.Rows[index].Cells[11].Value = pesarCabLog;
                    fatom.MatnrProd = destino[i].MatnrProd.ToString();
                    fatoBal.AcualizarDescripcionBAL(fatom, criterio);
                    //fatoCol = fatoBal().
                    ObtenerOrden(fatom);
                    break;
                } 
			}
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Obtiene el número de orden
         */

        private void ObtenerOrden(CLSFatom fatom) {

            CLSOrdenProdCollection orden;
            string criterio = "";
            //string lote = txtbxLote.Text;
            string matCons = fatom.Matnr;
            string matProd = fatom.MatnrProd;

            criterio = "WHERE (MATNR_COMP = '" + matCons + "') " ;
            criterio = criterio + "AND (WERKS = '" + centro + "')";
            criterio = criterio + "AND (MATNR = '" + matProd + "')";
            orden = new CLSOrdenProdBAL().MostrarOrdenProdBAL(criterio);
            if (orden.Count == 0)
            {
                throw new Exception("No se encuentra Orden de Producción en el folio: " + fatom.Folio);
            }
            IEnumerator lista = orden.GetEnumerator();
            
            string criterioFatom = "WHERE (WERKS = '" + fatom.Werks + "') ";
            criterioFatom = criterioFatom + "AND (FECHA >= CONVERT(DATETIME, '" + fecha.ToString("yyyy-MM-dd 00:00:00") + "', 120)) ";
            criterioFatom = criterioFatom + "AND (FECHA <= CONVERT(DATETIME, '" + fecha.AddDays(1).ToString("yyyy-MM-dd 00:00:00") + "', 120)) ";
            criterioFatom = criterioFatom + "AND (FOLIO = '" + fatom.Folio + "') ";
            //ObtenerProductos(fatom, criterioFatom);
            while (lista.MoveNext())
            {
                CLSOrdenProd ordenProd = (CLSOrdenProd)lista.Current;
                //ClsResbCollection resb;
                /*string criterio2 = "WHERE (RSNUM = '" + "471729" + "') "; //****************************************************
                criterio2 = criterio2 + "AND (MATNR = '" + matProd + "') ";
                criterio2 = criterio2 + "AND (BWART = '261')";
                resb = new ClsResbBAL().ConsultarResbBAL(criterio2);*/
                fatom.Aufnr = ordenProd.Aufnr;
                fatom.Charg = ordenProd.Charg;
                CLSFatomBAL fatomAgrega = new CLSFatomBAL();
                fatomAgrega.ActualizarOrdenesZPPG02BAL(fatom, criterioFatom);
            }

            //if (orden.Count == 0)
            //{
            //    throw new Exception("No se encuentra Orden de Producción en el folio: " + fatom.Folio);
            //}
                /*txtbxOrdenesProd.Text = ordenProd.Aufnr;
                charg2 = orden[0].Charg.ToString();*/
                
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Obtiene los números de material
         */

        private void ObtenerProductos(CLSFatom fatom, string criterioFatom)
        {
            CLSCatDestinoCollection destinos;
            CLSFatomBAL AgregaFatom = new CLSFatomBAL();
            string criterio = "WHERE (CODDESTINO = '" + fatom.CodDestino + "') ";
            criterio = criterio + "AND (PESOINI < '" + fatom.Erfmg.ToString() + "') ";
            criterio = criterio + "ORDER BY CODDESTINO, PESOINI DESC";            
            destinos = new CLSCatDestinoBAL().MostrarCatDestinoBAL(criterio);
            fatom.Matnr = destinos[0].MatnrComp.ToString();
            fatom.MatnrProd = destinos[0].MatnrProd.ToString();
            fatom.PesarCab = destinos[0].PesarCab.ToString();
            AgregaFatom.ActualizarMaterialesBAL(fatom, criterioFatom);
            //lblPesarCab.Text = destinos[0].PesarCab.ToString();
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Actualiza cada registro individualmente
         */

        private void ActualizaUnicaFatom()
        {
            CLSFatomBAL fatomBAL = new CLSFatomBAL();
            CLSFatom fatom = new CLSFatom();
            string criterio = "";
            DateTime diaSiguiente = fecha.AddDays(1);

            criterio = "WHERE (WERKS = '" + centro + "') ";
            criterio = criterio + "AND (FECHA >= CONVERT(DATETIME, '" + fecha.ToString("yyyy-MM-dd 00:00:00") + "', 120)) ";
            criterio = criterio + "AND (FECHA <= CONVERT(DATETIME, '" + diaSiguiente.ToString("yyyy-MM-dd 00:00:00") + "', 120)) ";
            int indice = celda;
            criterio = criterio + "AND (FOLIO = '" + dgvFatom.Rows[indice].Cells[2].Value.ToString() + "')";
            fatom.CodDestino = dgvFatom.Rows[indice].Cells[6].Value.ToString();
            fatom.Folio = Convert.ToInt32(dgvFatom.Rows[indice].Cells[2].Value);
            fatom.PesoSinCabeza = Convert.ToDouble(dgvFatom.Rows[indice].Cells[3].Value) - Convert.ToDouble(dgvFatom.Rows[indice].Cells[12].Value);
            fatom.Werks = centro;
            /*}
            else
            {

                criterio = criterio + "AND (FOLIO = '" + dgvFatom.Rows[indice].Cells[2].Value.ToString() + "')";
                fatom.CodDestino = dgvFatom.Rows[indice].Cells[6].Value.ToString();
                fatom.Folio = Convert.ToInt32(dgvFatom.Rows[indice].Cells[2].Value);
                fatom.PesoSinCabeza = Convert.ToDouble(dgvFatom.Rows[indice].Cells[3].Value) - Convert.ToDouble(dgvFatom.Rows[indice].Cells[12].Value);
                fatom.Werks = centro;
            }*/
            
            //fatom.Matnr = matnrG;
            fatomBAL.ActualizarDestinoBAL(fatom, criterio);
            
            try
            {
                ActualizarDescripcion(fatom, indice);
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
         * Descripción: Actualiza todos los registros
         */

        private void ActualizarFatom(){
            CLSFatomBAL fatomBAL = new CLSFatomBAL();
            CLSFatom fatom = new CLSFatom();
            string criterio = "";
            DateTime diaSiguiente = fecha.AddDays(1);

            /*for (int i = 0; i < fatiList.Count; i++)
            {
                criterio = "WHERE (WERKS = '" + centro + "') ";
                criterio = criterio + "AND (FECHA >= CONVERT(DATETIME, '" + fecha.ToString("yyyy-MM-dd 00:00:00") + "', 120)) ";
                criterio = criterio + "AND (FECHA <= CONVERT(DATETIME, '" + diaSiguiente.ToString("yyyy-MM-dd 00:00:00") + "', 120)) ";
                criterio = criterio + "AND (FOLIO = '" + dgvFatom.Rows[i].Cells[2].Value.ToString() + "')";
                foreach(CLSFatom fatomi in fatiList) 
                {
                    fatom.CodDestino = fatomi.CodDestino;
                    fatom.Folio = fatomi.Folio;
                    fatom.PesoSinCabeza = fatomi.Erfmg - fatomi.PesoCab;
                    fatomBAL.ActualizarDestinoBAL(fatom, criterio);
                    ActualizarDescripcion(fatom, i); 
                }
            }*/

            for (int i = 0; i < dgvFatom.RowCount; i++ ) {
                criterio = "WHERE (WERKS = '" + centro + "') ";
                criterio = criterio + "AND (FECHA >= CONVERT(DATETIME, '" + fecha.ToString("yyyy-MM-dd 00:00:00") + "', 120)) ";
                criterio = criterio + "AND (FECHA <= CONVERT(DATETIME, '" + diaSiguiente.ToString("yyyy-MM-dd 00:00:00") + "', 120)) ";
                criterio = criterio + "AND (FOLIO = '" + dgvFatom.Rows[i].Cells[2].Value.ToString() + "')";
                fatom.CodDestino = dgvFatom.Rows[i].Cells[6].Value.ToString();
                fatom.Folio = Convert.ToInt32(dgvFatom.Rows[i].Cells[2].Value);
                fatom.PesoSinCabeza = Convert.ToDouble(dgvFatom.Rows[i].Cells[3].Value) - Convert.ToDouble(dgvFatom.Rows[i].Cells[12].Value);
                fatom.Werks = centro;
                //fatom.Matnr = matnrG;
                fatomBAL.ActualizarDestinoBAL(fatom, criterio);
                try
                {
                    ActualizarDescripcion(fatom, i);
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }

        private void ZPPG02Tabla_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F8)
            {
                pictureBox1_Click(sender, e);

            }
        }

        private void dgvFatom_KeyUp(object sender, KeyEventArgs e)
        {
            /*if (e.KeyCode == Keys.F8)
            {
                if (dgvFatom.CurrentCell.IsInEditMode) 
                {
                    DataGridViewDataErrorContexts err = new DataGridViewDataErrorContexts();
                    dgvFatom.CurrentCell.Value = dgvFatom.CurrentCell.GetEditedFormattedValue(dgvFatom.CurrentCell.ColumnIndex, err); 
                }

            }*/
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    MensajeApagar();
                    RevisaUnicoDestino();
                    ActualizaUnicaFatom();
                    MostrarMensaje("Folios procesados!");
                }
                catch (Exception ex)
                {

                    base.MostrarError(ex.Message);
                }
                //pictureBox1_Click(sender, e);
            }
        }

        private void dgvFatom_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            celda = dgvFatom.CurrentCell.RowIndex;
        }

        /*private void dgvFatom_CurrentCellChanged(object sender, EventArgs e)
        {
            CLSFatom fati = new CLSFatom();
            //ArrayList<CLSFatom> fatiList = new ArrayList();
            int index = dgvFatom.CurrentCell.RowIndex;
            fati.Aufnr = dgvFatom.Rows[index].Cells[0].Value.ToString();
            fati.Fecha = Convert.ToDateTime(dgvFatom.Rows[index].Cells[1].Value);
            fati.Folio = Convert.ToInt32(dgvFatom.Rows[index].Cells[2].Value);
            fati.Erfmg = Convert.ToDouble(dgvFatom.Rows[index].Cells[3].Value);
            fati.Tatuaje = dgvFatom.Rows[index].Cells[4].Value.ToString();
            fati.Calidad = dgvFatom.Rows[index].Cells[5].Value.ToString();
            fati.CodDestino = dgvFatom.Rows[index].Cells[6].Value.ToString();
            fati.Destino = dgvFatom.Rows[index].Cells[7].Value.ToString();
            fati.Musculo = Convert.ToDouble(dgvFatom.Rows[index].Cells[8].Value);
            fati.Grasa = Convert.ToDouble(dgvFatom.Rows[index].Cells[9].Value);
            fati.Chuleta = Convert.ToDouble(dgvFatom.Rows[index].Cells[10].Value);
            fati.PesarCab = dgvFatom.Rows[index].Cells[11].Value.ToString();
            fati.PesoCab = Convert.ToDouble(dgvFatom.Rows[index].Cells[12].Value);
            fati.Procesado = dgvFatom.Rows[index].Cells[13].Value.ToString();
            fatiList.Add(fati); 
            
        }*/
    }
}   
