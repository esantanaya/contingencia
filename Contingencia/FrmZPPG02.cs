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
* Fecha de creación: 10/05/2012
* Fecha de liberación: 04/06/2012
* Descripción: Punto de control ZPPG02 :: Destinos
*/

namespace Contingencia
{
    public partial class FrmZPPG02 : FrmBase
    {

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Declaración de variables
         */

        private string centro;
        public string Centro
        {
            get { return centro; }
            set { centro = value; }
        }

        private string mensajeError;
        public string MensajeError
        {
            get { return mensajeError; }
            set { mensajeError = value; }
        }

        public FrmZPPG02()
        {
            InitializeComponent();
        }

        private void FrmZPPG02_Load(object sender, EventArgs e)
        {
            base.PonerTitulo("Porcesamiento de Folios - 2da. estación Umán.");
            dtpFecha.Value = DateTime.Now;
            ErrorRegreso();
            AutocompletarCentros();
            AutocompletarDestino();
            txtbxCentro.Select();
            txtbxCentro.Focus();
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Regresa de la tabla si hay un error
         */

        private void ErrorRegreso() { 
            if(mensajeError.Length > 0) {
                txtbxCentro.Text = centro;
                base.MostrarError(mensajeError);
                this.Activate();
            }
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Valida que los campos se hayan ingresado correctamente
         */

        private void Validaciones() {

            string lsMensaje = "";
            string criterio;

            if (txtbxCentro.TextLength == 0)
            {
                throw new Exception("Ingresa un centro");
            }

            try
            {
                criterio = "WHERE WERKS = '" + txtbxCentro.Text + "'";
                CLSCatCentroCollection centrosColeccion;
                centrosColeccion = (new CLSCatCentroBAL()).MostrarCatCentroBAL(criterio);

                if (centrosColeccion.Count == 0)
                {
                    txtbxCentro.SelectAll();
                    txtbxCentro.Focus();
                    lsMensaje = "El centro no existe";
                    throw new Exception(lsMensaje);
                }
                else
                {
                    txtbxCentro.Enabled = false;
                }

            }
            catch
            {
                throw;
            }
            
            if (!cbxPendientes.Checked && !cbxProc.Checked)
            {
                throw new Exception("Selecciona un tipo de Folio!");
            }


            try
            {
                if (txtbxDestino.Text.Length > 0)
                {
                    criterio = "WHERE CODDESTINO = '" + txtbxDestino.Text + "'";
                    CLSCatDestinoCollection destinoColeccion;
                    destinoColeccion = (new CLSCatDestinoBAL()).MostrarCatDestinoBAL(criterio);

                    if (destinoColeccion.Count == 0)
                    {
                        txtbxDestino.SelectAll();
                        txtbxDestino.Focus();
                        lsMensaje = "El destino no existe";
                        throw new Exception(lsMensaje);
                    }
                    else
                    {
                        txtbxCentro.Enabled = false;
                    } 
                }
            }
            catch { throw; }

            try
            {
                if (txtbxCalidad.Text.Length > 0)
                {
                    criterio = "WHERE CALIDAD = '" + txtbxCalidad.Text + "'";
                    CLSCalidadCollection calidadColeccion;
                    calidadColeccion = (new CLSCalidadBAL()).MostrarCalidadBAL(criterio);

                    if (calidadColeccion.Count == 0)
                    {
                        txtbxCalidad.SelectAll();
                        txtbxCalidad.Focus();
                        lsMensaje = "La calidad no existe";
                        throw new Exception(lsMensaje);
                    }
                    else
                    {
                        txtbxCentro.Enabled = false;
                    }
                }
            }
            catch { throw; }

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ZPPG02Tabla tabla = new ZPPG02Tabla();

            try
            {
                Validaciones();
                tabla.Centro = txtbxCentro.Text.ToUpper();
                tabla.Fecha1 = dtpFecha.Value.Date;
                tabla.CodDestino = txtbxDestino.Text;
                tabla.Calidad1 = txtbxCalidad.Text;
                tabla.Lote1 = txtbxLote.Text;
                if (cbxPendientes.Checked)
                {
                    tabla.Pendiente= true;
                }
                else
                {
                    tabla.Pendiente = false;
                }
                if (cbxProc.Checked)
                {
                    tabla.Procesado1 = true;
                }
                else {
                    tabla.Procesado1 = false;
                }
                this.Hide();
                tabla.ShowDialog();
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }

        private void pcbDestino_Click(object sender, EventArgs e)
        {
            ConsultarDestino();
        }

        private void pbxCalidad_Click(object sender, EventArgs e)
        {
            ConsultarCalidad();
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Muestra el catalogo de Calidad
         */

        private void ConsultarCalidad()
        {
            DialogResult resultado;
            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            listaSeleccion.TipoCatalogo = "CALIDAD";
            listaSeleccion.IniciarForma();
            resultado = listaSeleccion.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                string lsClave = listaSeleccion.ClaveSel;
                txtbxCalidad.Text = lsClave;
            }
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Muestra el catalogo de destinos
         */

        private void ConsultarDestino()
        {
            DialogResult resultado;
            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            listaSeleccion.TipoCatalogo = "DESTINO";
            listaSeleccion.IniciarForma();
            resultado = listaSeleccion.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                string lsClave = listaSeleccion.ClaveSel;
                txtbxDestino.Text = lsClave;
            }
        }

        private void txtbxCentro_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxCentro);
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Autocompleta el campo de Destino
         */

        public void AutocompletarDestino()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();

            CLSCatDestinoCollection centrosCol;
            centrosCol = new CLSCatDestinoBAL().MostrarCatDestinoBAL("");
            IEnumerator lista = centrosCol.GetEnumerator();

            while (lista.MoveNext())
            {
                CLSCatDestino destinoM = (CLSCatDestino)lista.Current;
                datos.Add(destinoM.CodDestino);
            }
            txtbxDestino.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtbxDestino.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtbxDestino.AutoCompleteCustomSource = datos;
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Autocompleta el campo de Centro
         */

        public void AutocompletarCentros()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();

            CLSCatCentroCollection centrosCol;
            centrosCol = new CLSCatCentroBAL().MostrarCatCentroBAL("");
            IEnumerator lista = centrosCol.GetEnumerator();

            while (lista.MoveNext())
            {
                CLSCatCentro centroM = (CLSCatCentro)lista.Current;
                datos.Add(centroM.CodCentro);
            }
            txtbxCentro.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtbxCentro.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtbxCentro.AutoCompleteCustomSource = datos;
        }

        private void LblCentro() {
            CLSCatCentroCollection centroDesc;
            string criterio = "WHERE (WERKS = '";
            criterio = criterio + txtbxCentro.Text + "')";
            centroDesc = new CLSCatCentroBAL().MostrarCatCentroBAL(criterio);
            IEnumerator lista = centroDesc.GetEnumerator();

            while(lista.MoveNext()) {
                CLSCatCentro centroD = new CLSCatCentro();
                lblCentro.Text = centroD.DescCentro;
            }
        }

        private void txtbxCentro_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxCentro);
            LblCentro();
        }

        private void txtbxDestino_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxDestino);
        }

        private void txtbxDestino_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxDestino);
        }

        private void txtbxCalidad_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxCalidad);
        }

        private void txtbxCalidad_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxCalidad);
        }

        private void txtbxLote_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxLote);
        }

        private void txtbxLote_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxLote);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ConsultarCentros();
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Muestra el catalogo de Destinos
         */

        private void ConsultarDestinos() {
            DialogResult resultado;
            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            listaSeleccion.TipoCatalogo = "DESTINO";
            listaSeleccion.IniciarForma();
            resultado = listaSeleccion.ShowDialog();
            if(resultado == DialogResult.Yes) {
                string lsClave = listaSeleccion.ClaveSel;
                txtbxDestino.Text = lsClave;
            }
        }

        private void ConsultarCentros()
        {
            DialogResult resultado;
            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            listaSeleccion.TipoCatalogo = "CENTRO";
            listaSeleccion.IniciarForma();
            resultado = listaSeleccion.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                string lsClave = listaSeleccion.ClaveSel;
                string lsDesc = listaSeleccion.DescSel;
                txtbxCentro.Text = lsClave;
                lblCentro.Text = lsDesc;
            }
        }

        private void txtbxCentro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { btnConsultar_Click(sender, e); }
        }

        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { btnConsultar_Click(sender, e); }
        }

        private void txtbxDestino_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { btnConsultar_Click(sender, e); }
        }

        private void txtbxCalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { btnConsultar_Click(sender, e); }
        }

        private void txtbxLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { btnConsultar_Click(sender, e); }
        }

        private void btnConsultar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { btnConsultar_Click(sender, e); }
        }
    }
}
