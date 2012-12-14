using System;
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
        public FrmZPPG01Entrada()
        {
            InitializeComponent();
        }

        private void FrmZPPG01Entrada_Load(object sender, EventArgs e) {

            base.PonerTitulo("Estación 1: Fatometer");
            txtbxCentro.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            txtbxCentro.Text = txtbxCentro.Text.ToUpper();
            txtbxBascula.Text = txtbxBascula.Text.ToUpper();

            if(txtbxCentro.Text == "" || txtbxBascula.Text == "") {
                base.MostrarError("Todos los campos son obligatorios");
                return;
            }

            if(txtbxCentro.Text != "0R00") {
                base.MostrarError("No existe centro!");
                return;
            }

            if(txtbxBascula.Text != "MANUAL") {
                base.MostrarError("No existe el modelo de Báscula");
                return;
            }

            if (txtbxBascula.Text.Trim().StartsWith("0") == true) {
                base.MostrarError("No existe el modelo de Báscula");
                return;
            }

            this.Hide();
            FrmZPPG01Captura zppg01 = new FrmZPPG01Captura();
            zppg01.ShowDialog();
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
        }

        private void txtbxPuertoSrl_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxPuertoSrl);
        }
    }
}
