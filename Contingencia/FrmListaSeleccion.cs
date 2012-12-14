using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;


namespace Contingencia
{
    public partial class FrmListaSeleccion : Form
    {
        private string criterioAd;

        public string CriterioAd
        {
            get { return criterioAd; }
            set { criterioAd = value; }
        }

        private string tipoCatalogo;
        public string TipoCatalogo
        {
            get
            {
                return tipoCatalogo;
            }
            set
            {
                tipoCatalogo = value;
            }
        }

        private string claveSel;
        public string ClaveSel
        {
            get
            {
                return claveSel;
            }
            set
            {
                claveSel = value;
            }
        }

        private string descSel;
        public string DescSel
        {
            get
            {
                return descSel;
            }
            set
            {
                descSel = value;
            }
        }

        public FrmListaSeleccion()
        {
            InitializeComponent();
        }


        private void FrmListaSeleccion_Load(object sender, EventArgs e)
        {
            dgvLista.MultiSelect = false;
        }

        public void IniciarForma()
        {

            dgvLista.Rows.Clear();
            if (tipoCatalogo == "CENTRO")
            {
                CLSCatCentroCollection centro;
                this.Text = "Catálogo de Centros";
                lblTitulo.Text = "Seleccione el centro.";
                dgvLista.Columns.Clear();
                dgvLista.ColumnCount = 3;
                dgvLista.Columns[0].Name = "Clave";
                dgvLista.Columns[1].Name = "Descripción";
                dgvLista.Columns[2].Name = "TipoCentro";
                centro = new CLSCatCentroBAL().MostrarCatCentroBAL("");
                IEnumerator lista = centro.GetEnumerator();

                while (lista.MoveNext())
                {
                    CLSCatCentro centroM = (CLSCatCentro)lista.Current;
                    dgvLista.Rows.Add(centroM.CodCentro, centroM.DescCentro, centroM.TipoCentro);
                }
            }
            if (tipoCatalogo == "DESTINO")
            {
                CLSCatDestinoCollection destino;
                this.Text = "Catálogo de Destinos";
                lblTitulo.Text = "Seleccione el destino.";
                dgvLista.Columns.Clear();
                dgvLista.ColumnCount = 2;
                dgvLista.Columns[0].Name = "Clave";
                dgvLista.Columns[1].Name = "Descripción";
                destino = new CLSCatDestinoBAL().MostrarCatDestinoBAL("");
                IEnumerator lista = destino.GetEnumerator();

                while(lista.MoveNext()) {
                    CLSCatDestino destinoM = (CLSCatDestino)lista.Current;
                    dgvLista.Rows.Add(destinoM.CodDestino, destinoM.DescDestino);
                }
            }

            if (tipoCatalogo == "CALIDAD")
            {
                CLSCalidadCollection calidad;
                this.Text = "Catálogo de Calidad";
                lblTitulo.Text = "Seleccione la calidad.";
                string criterio = "WHERE (WERKS = '" + "0R00" + "')";

                dgvLista.Columns.Clear();
                dgvLista.ColumnCount = 1;
                dgvLista.Columns[0].Name = "Clave";
                calidad = new CLSCalidadBAL().MostrarCalidadBAL(criterio);
                IEnumerator lista = calidad.GetEnumerator();

                while(lista.MoveNext()) {
                    CLSCalidad calidadM = (CLSCalidad)lista.Current;
                    dgvLista.Rows.Add(calidadM.Calidad);
                }
            }

            if (tipoCatalogo == "LOTE")
            {
                this.Text = "Catálogo de Lotes";
                lblTitulo.Text = "Seleccione el lote.";
                dgvLista.Rows.Add("00","CORTES");
                dgvLista.Rows.Add("01","CANAL BAJIO");
                dgvLista.Rows.Add("02","CAPOTES");
                dgvLista.Rows.Add("05","MARRANAS A VENTAS");
            }

            if (tipoCatalogo == "ALMACEN")
            {
                ClsCatAlmacenCollection almacenCol;
                this.Text = "Catálogo de Almacenes";
                lblTitulo.Text = "Seleccione el almacén.";
              
                dgvLista.Columns.Clear();
                dgvLista.ColumnCount = 2;
                dgvLista.Columns[0].Name = "Clave";
                dgvLista.Columns[1].Name = "Descripción";
                almacenCol = new ClsCatAlmacenBAL().ConsultarAlmacenesBAL("");
                IEnumerator lista = almacenCol.GetEnumerator();

                while (lista.MoveNext())
                { 
                    ClsCatAlmacen almacen = (ClsCatAlmacen)lista.Current;
                    dgvLista.Rows.Add(almacen.Lgort, almacen.Descripcion);
                }

            }
            if (tipoCatalogo == "BASCULA")
            {
                ClsZBasculasCollection zBasBalCol;
                this.Text = "Catálogo de Básculas";
                lblTitulo.Text = "Seleccione la báscula.";
                dgvLista.Columns.Clear();
                dgvLista.ColumnCount = 2;
                dgvLista.Columns[0].Name = "Clave";
                dgvLista.Columns[1].Name = "Descripción";
                zBasBalCol = new ClsZBasculasBAL().ConsultarZBasculasBAL("");
                IEnumerator lista = zBasBalCol.GetEnumerator();

                while (lista.MoveNext())
                {
                    ClsZBasculas zBas = (ClsZBasculas)lista.Current;
                    dgvLista.Rows.Add(zBas.Modelo, zBas.Setting);
                }
            }
            if (tipoCatalogo == "MATERIAL")
            {
                this.Text = "Catálogo de Materiales";
                lblTitulo.Text = "Seleccione la materiales.";

                ClsMARACollection zBasMaraCol;
                dgvLista.Columns.Clear();
                dgvLista.ColumnCount = 2;
                dgvLista.Columns[0].Name = "Clave";
                dgvLista.Columns[1].Name = "Descripción";
                zBasMaraCol = new ClsMARABAL().ConsultarMARABAL("");
                IEnumerator lista = zBasMaraCol.GetEnumerator();
                string lsMatnrEd ="";
                while (lista.MoveNext())
                {
                    ClsMARA mara = (ClsMARA)lista.Current;
                    lsMatnrEd = mara.Matnr.Remove(0,1);
                    dgvLista.Rows.Add(lsMatnrEd, mara.Etiar);
                }

                /*dgvLista.Rows.Add("134303A1","PIERNA SIN HUESO");
                dgvLista.Rows.Add("134366C1","PIERNA EN TROZO");
                dgvLista.Rows.Add("134602A1","CUERO SIN GRASA");
                dgvLista.Rows.Add("134606A2","CUERO CON GRASA");*/
            }

            if (tipoCatalogo == "TIPOMATERIAL")
            {
                this.Text = "Catálogo de Tipo de Materiales";
                lblTitulo.Text = "Seleccione el tipo de material.";

                ClsMARACollection zBasMaraCol;
                dgvLista.Columns.Clear();
                dgvLista.ColumnCount = 2;
                dgvLista.Columns[0].Name = "Clave";
                dgvLista.Columns[1].Name = "Descripción";
                zBasMaraCol = new ClsMARABAL().ConsultarMARABAL("");
                IEnumerator lista = zBasMaraCol.GetEnumerator();

                while (lista.MoveNext())
                {
                    ClsMARA mara = (ClsMARA)lista.Current;
                    dgvLista.Rows.Add(mara.Matnr, mara.Etiar);
                }
                
                /*dgvLista.Rows.Add("01", "Tipo 01");
                dgvLista.Rows.Add("02", "Tipo 02");
                dgvLista.Rows.Add("03", "Tipo 03");*/

            }
            if(tipoCatalogo == "TIPOALMACEN")
            {
                this.Text = "Catálogo de Tipo de Almacenes";
                lblTitulo.Text = "Seleccione el tipo de almacen.";

                dgvLista.Columns.Clear();
                dgvLista.ColumnCount = 2;
                dgvLista.Columns[0].Name = "Clave";
                dgvLista.Columns[1].Name = "Descripción";
                CLSTipoAlmacenCollection tipoAlmacen = new CLSTipoAlmacenBAL().ConsultarTipoAlmacenBAL(criterioAd);
                IEnumerator lista = tipoAlmacen.GetEnumerator();

                while(lista.MoveNext())
                {
                    CLSTipoAlmacen objetoTipoAlmacen = (CLSTipoAlmacen)lista.Current;
                    dgvLista.Rows.Add(objetoTipoAlmacen.Codigo, objetoTipoAlmacen.Descripcion);
                }
            }
            if (tipoCatalogo == "IMPRESORA")
            {

                this.Text = "Catálogo de Tipo de Materiales";
                lblTitulo.Text = "Seleccione el tipo de material.";

                dgvLista.Columns.Clear();
                dgvLista.ColumnCount = 2;
                dgvLista.Columns[0].Name = "Clave";
                dgvLista.Columns[1].Name = "Descripción";

                PrintDocument printDocument = new PrintDocument();
                string strPrinter;
                IEnumerator impresorasInstaladas = PrinterSettings.InstalledPrinters.GetEnumerator();
                
                //impresoras.Items.Add("Ninguna");
                
                while (impresorasInstaladas.MoveNext())
                {
                    strPrinter = impresorasInstaladas.Current.ToString();
                    dgvLista.Rows.Add(strPrinter, strPrinter);
                }
            }
            if (tipoCatalogo == "UBICACIONES")
            {
                this.Text = "Catálogo de Tipo Ubicaciones";
                lblTitulo.Text = "Seleccione la Ubicacion";

                ClsCatUbicacionesCollection ubicacionCol;
                dgvLista.Columns.Clear();
                dgvLista.ColumnCount = 1;
                dgvLista.Columns[0].Name = "Clave";
                //dgvLista.Columns[1].Name = "Descripcion";
                ubicacionCol = new ClsCatUbicacionesBAL().ConsultarUbicacionesBAL(criterioAd);
                IEnumerator lista = ubicacionCol.GetEnumerator();

                while (lista.MoveNext())
                {
                    ClsCatUbicaciones ubicacion = (ClsCatUbicaciones)lista.Current;
                    dgvLista.Rows.Add(ubicacion.Ubicacion);
                }
            }


            PerformLayout();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int liRow = 0;
            try
            {
                liRow = dgvLista.CurrentRow.Index;
                claveSel = dgvLista["Clave", liRow].Value.ToString();
                if (dgvLista.ColumnCount > 1)
                {
                    descSel = dgvLista["Descripción", liRow].Value.ToString(); 
                }
                this.DialogResult = DialogResult.Yes;
            }
            catch
            {
                throw;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void spcPrincipal_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        
    }
}