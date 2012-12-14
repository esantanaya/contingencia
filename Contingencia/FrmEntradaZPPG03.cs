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
    public partial class FrmEntradaZPPG03 : FrmBase
    {
        public FrmEntradaZPPG03()
        {
            InitializeComponent();
        }

        private void FrmEntradaZPPG03_Load(object sender, EventArgs e)
        {
            base.PonerTitulo("Pesado de Cabeza");
            txtbxCentro.Select();
            txtbxCentro.Focus();
            AutocompletarCentros();
            AutocompletarBasculas();

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
                txtbxBascula.Text = lsClave;
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

        private void txtbxCentro_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbxCentro_Click(object sender, EventArgs e)
        {
            ConsultarCentros();
        }

        private string Cadena() {
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

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            ValidarDatos();
            FrmZPPG03 zppg03 = new FrmZPPG03();
            string cadena = Cadena();
            if (MessageBox.Show("Estas seguro de entrar con centro " + cadena, "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                zppg03.Bascula = txtbxBascula.Text;
                zppg03.Centro = txtbxCentro.Text;
                this.Hide();
                zppg03.ShowDialog();    
            }

        }

        private void pbxBascula_Click(object sender, EventArgs e)
        {
            ConsultarBasculas();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtbxCentro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { btnContinuar_Click(sender, e); }
        }

        private void txtbxBascula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) { btnContinuar_Click(sender, e); }
        }
    }
}
