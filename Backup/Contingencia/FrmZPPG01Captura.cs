using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contingencia
{
    public partial class FrmZPPG01Captura : FrmBase
    {
        public FrmZPPG01Captura()
        {
            InitializeComponent();
        }

        private void FrmZPPG01Captura_Load(object sender, EventArgs e)
        {
            base.PonerTitulo("Estación 1: Fatometer");
            txtbxLote.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            double neto, bruto, tara;

            if(txtbxFolio.Text == "") {
                base.MostrarError("Ingrese FOLIO");
                return;
            }

            if (txtbxLote.Text == "")
            {
                base.MostrarError("Ingrese LOTE");
                return;
            }

            if (txtbxTara.Text == "")
            {
                base.MostrarError("Ingrese PESO");
                return;
            }

            if (txtbxPesoBruto.Text == "")
            {
                base.MostrarError("Ingrese PESO");
                return;
            }

            if (txtbxGrasa.Text == "")
            {
                base.MostrarError("Ingrese GRASA");
                return;
            } 

            if (txtbxMusculo.Text == "")
            {
                base.MostrarError("Ingrese MUSCULO");
                return;
            }

            if (txtbxChuleta.Text == "")
            {
                base.MostrarError("Ingrese CHULETA");
                return;
            }

            txtbxMatCon.Text = "10F902";
            txtbxMatProd.Text = "131133M1";

            neto = Convert.ToDouble(txtbxPesoNeto.Text);
            bruto = Convert.ToDouble(txtbxPesoBruto.Text);
            tara = (Convert.ToDouble(txtbxTara.Text))/1000;

            neto = (bruto - tara);

            txtbxPesoNeto.Text = neto.ToString();

            txtbxCalidad.Text = "STDR";

            base.MostrarMensaje("Folio Grabado!");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtbxFolio_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxFolio);
        }

        private void txtbxFolio_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxFolio);
        }

        private void txtbxMusculo_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxMusculo);
        }

        private void txtbxMusculo_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxMusculo);
        }

        private void txtbxGrasa_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxGrasa);
        }

        private void txtbxGrasa_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxGrasa);
        }

        private void txtbxChuleta_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxChuleta);
        }

        private void txtbxChuleta_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxChuleta);
        }

        private void txtbxPesoBruto_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxPesoBruto);
        }

        private void txtbxPesoBruto_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxPesoBruto);
        }

        private void txtbxTara_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxPesoBruto);
        }

        private void txtbxTara_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxPesoBruto);
        }

        private void txtbxDestino_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxDestino);
        }

        private void txtbxDestino_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxDestino);
        }

        private void txtbxLote_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxLote);
        }

        private void txtbxLote_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxLote);
        }
    }
}
