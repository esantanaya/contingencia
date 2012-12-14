using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contingencia
{
    public partial class FrmZPPG01Entrada : FrmBase
    {
        private string codBascula = "";

        public FrmZPPG01Entrada()
        {
            InitializeComponent();
        }

        private void FrmZPPG01Entrada_Load(object sender, EventArgs e) {

            base.PonerTitulo("Estación 1: Fatometer");
            txtbxCentro.Select();
            txtbxCentro.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarDatos();
                FrmZPPG01Captura zppg01 = new FrmZPPG01Captura();
                string cadena = "WHERE (WERKS = '" + txtbxCentro.Text + "')";
                CLSCatCentroCollection centro = new CLSCatCentroBAL().MostrarCatCentroBAL(cadena);
                IEnumerator lista = centro.GetEnumerator();
                while (lista.MoveNext())
                {
                    CLSCatCentro centroM = (CLSCatCentro)lista.Current;
                    cadena = centroM.DescCentro.ToString(); 
                }
                if (MessageBox.Show("Estas seguro de entrar con centro " + cadena, "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    zppg01.CodCentro = txtbxCentro.Text;
                    zppg01.DesCentro = cadena;
                    string bascula = txtbxBascula.Text.ToUpper();
                    if (bascula != "MANUAL") { 
                        zppg01.Bascula = true;
                        zppg01.CodBascula = codBascula;
                        zppg01.ModeloBascula = txtbxBascula.Text.ToUpper();
                    } else { 
                        zppg01.Bascula = false; 
                    }
                    zppg01.PuertoFatom = txtbxPuertoSrl.Text;
                    zppg01.SettingFatom = txtbxSettings.Text;
                    zppg01.IniciarForma();
                    this.Hide();
                    zppg01.ShowDialog();
                    zppg01.CerrarPuerto();
                }
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }   

        private void pbxBascula_Click(object sender, EventArgs e)
        {
            ConsultarBasculas();
        }

        private void pbxCentro_Click(object sender, EventArgs e)
        {
            ConsultarCentros();
        }

        private void ConsultarBasculas()
        {
            DialogResult resultado;
            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            listaSeleccion.TipoCatalogo = "BASCULA";
            listaSeleccion.IniciarForma();
            resultado = listaSeleccion.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                string lsClave = listaSeleccion.ClaveSel;
                string lsDesc = listaSeleccion.DescSel;
                txtbxBascula.Text = lsClave;
                codBascula = lsDesc;
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
                txtbxCentro.Text = lsClave;
            }
        }

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

        public void AutocompletarBasculas()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();

            ClsZBasculasCollection basculasCol;
            basculasCol = new ClsZBasculasBAL().ConsultarZBasculasBAL("");
            IEnumerator lista = basculasCol.GetEnumerator();

            while (lista.MoveNext())
            {
                ClsZBasculas bascula = (ClsZBasculas)lista.Current;
                datos.Add(bascula.Modelo);
            }

            txtbxBascula.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtbxBascula.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtbxBascula.AutoCompleteCustomSource = datos;
        }

        private void ValidarDatos()
        {
            bool lbCentroCorrecto = true;
            bool lbBasculaCorrecto = true;
            string lsMensaje = "";
            string criterio;
            try
            {
                if (txtbxCentro.Text.Trim().Length == 0)
                {
                    lbCentroCorrecto = false;
                }

                criterio = "WHERE WERKS = '" + txtbxCentro.Text + "'";
                CLSCatCentroCollection centrosColeccion;
                centrosColeccion = (new CLSCatCentroBAL()).MostrarCatCentroBAL(criterio);

                if (centrosColeccion.Count == 0)
                {
                    lbCentroCorrecto = false;
                }
                if (lbCentroCorrecto == false)
                {
                    txtbxCentro.SelectAll();
                    txtbxCentro.Focus();
                    lsMensaje = "El centro no existe";
                    throw new Exception(lsMensaje);
                }
                if(lbCentroCorrecto == true) {
                    txtbxCentro.Enabled = false;
                }

            }
            catch
            {
                throw;
            }


            try
            {
                if (txtbxBascula.Text.Trim().Length == 0)
                {
                    lbBasculaCorrecto = false;
                }
                //if (txtbxBascula.Text.Trim().StartsWith("0") == false)
                criterio = "WHERE MODELO = '" + txtbxBascula.Text + "'";
                ClsZBasculasCollection basculasColeccion;
                basculasColeccion = (new ClsZBasculasBAL()).ConsultarZBasculasBAL(criterio);

                if (basculasColeccion.Count == 0)
                {
                    lbBasculaCorrecto = false;
                }
                if (lbBasculaCorrecto == true)
                {
                    txtbxBascula.Enabled = false;
                }
                if (lbBasculaCorrecto == false)
                {
                    txtbxBascula.SelectAll();
                    lsMensaje = "No existe el modelo de báscula";
                    txtbxBascula.Focus();
                    throw new Exception(lsMensaje);
                }
            }
            catch
            {
                throw;
            }

            /*if (lbBasculaCorrecto && lbCentroCorrecto)
            {

            }*/

        }

        private void txtbxCentro_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxCentro);
            AutocompletarCentros();
        }

        private void txtbxCentro_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxCentro);
        }

        private void txtbxBascula_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxBascula);
            AutocompletarBasculas();
        }

        private void txtbxBascula_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxBascula);
            txtbxSettings.Select();
            txtbxSettings.Focus();
        }

        private void txtbxSettings_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxSettings);
        }

        private void txtbxSettings_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxSettings);
        }

        private void txtbxPuertoSrl_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxPuertoSrl);
            txtbxPuertoSrl.TabStop = false;
        }

        private void txtbxPuertoSrl_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxPuertoSrl);
            txtbxPuertoSrl.TabStop = true;
        }

        /*private void txtbxCentro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnContinuar_Click(sender, e); 
            }
        }*/

        /*private void ObtenerIndice()
        { 

        }*/

        private void FrmZPPG01Entrada_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnContinuar_Click(sender, e);
            }
        }
    }
}
