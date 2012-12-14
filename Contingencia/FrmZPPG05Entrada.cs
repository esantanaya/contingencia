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
    public partial class FrmZPPG05Entrada : FrmBase
    {

        FrmPrincipal principal = new FrmPrincipal();

        public FrmZPPG05Entrada()
        {
            InitializeComponent();
        }

        private void FrmZPPG05Entrada_Load(object sender, EventArgs e)
        {
            base.PonerTitulo("SAP");
            txtbxCentro.Select();
            txtbxCentro.Focus();
            AutocompletarCentros();
            AutocompletarBasculas();
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

        private void txtbxCentro_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxCentro);
        }

        private void txtbxCentro_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxCentro);
        }

        private void txtbxBascula_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxBascula);
        }

        private void txtbxBascula_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxBascula);
        }

        private void ValidarDatos()
        {
            bool lbCentroCorrecto = true;
            bool lbBasculaCorrecto = true;
            string lsMensaje = "";
            string criterio = "";
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
                if (lbCentroCorrecto == true)
                {
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
                    lsMensaje = "No existe la báscula";
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

        private void btnContinuar_Click(object sender, EventArgs e)
        {

            FrmZPPG05 zppg05 = new FrmZPPG05();
            txtbxCentro.Text = txtbxCentro.Text.ToUpper();
            txtbxBascula.Text = txtbxBascula.Text.ToUpper();

            try
            {
                ValidarDatos();
                string cadena = Cadena();
                if (MessageBox.Show("Estas seguro de entrar con centro " + cadena, "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    zppg05.Centro = txtbxCentro.Text;
                    zppg05.Bascula = txtbxBascula.Text;
                    zppg05.Descripcion = cadena;
                    zppg05.IniciarForma();
                    this.Hide();
                    zppg05.ShowDialog(); 
                }
            }
            catch (Exception ex)
            {
                
                base.MostrarError(ex.Message);
            }
        }

        private string Cadena()
        {
            string cadena = "WHERE (WERKS = '" + txtbxCentro.Text + "')";
            CLSCatCentroCollection centro = new CLSCatCentroBAL().MostrarCatCentroBAL(cadena);
            IEnumerator lista = centro.GetEnumerator();
            while (lista.MoveNext())
            {
                CLSCatCentro centroM = (CLSCatCentro)lista.Current;
                cadena = centroM.DescCentro.ToString();
                return cadena;
            }
            return cadena;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pctbxCentro_Click(object sender, EventArgs e)
        {
            ConsultarCentros();
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

        private void ConsultarBascula()
        {
            DialogResult resultado;
            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            listaSeleccion.TipoCatalogo = "BASCULA";
            listaSeleccion.IniciarForma();
            resultado = listaSeleccion.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                string lsClave = listaSeleccion.ClaveSel;
                txtbxBascula.Text = lsClave;
            }
        }

        private void pbxBascula_Click(object sender, EventArgs e)
        {
            ConsultarBascula();
        }

        private void txtbxCentro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnContinuar_Click(sender, e); 
            }
        }

        private void txtbxBascula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnContinuar_Click(sender, e); 
            }
        }

        private void btnContinuar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnContinuar_Click(sender, e);
            }
        }
    }
}
