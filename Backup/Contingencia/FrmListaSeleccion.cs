using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contingencia
{
    public partial class FrmListaSeleccion : Form
    {

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

        public FrmListaSeleccion()
        {
            InitializeComponent();
        }


        private void FrmListaSeleccion_Load(object sender, EventArgs e)
        {

        }

        public void IniciarForma()
        {

            dgvLista.Rows.Clear();
            if (tipoCatalogo == "CENTRO")
            {
                this.Text = "Cat�logo de Centros";
                lblTitulo.Text = "Seleccione el centro.";
                //dgvLista.DataSource = 
                dgvLista.Rows.Add("0R00","RASTRO UMAN");
                dgvLista.Rows.Add("0R02", "RASTRO IRAPUATO");
            }
            if (tipoCatalogo == "DESTINO")
            {
                this.Text = "Cat�logo de Destinos";
                lblTitulo.Text = "Seleccione el destino.";
                dgvLista.Rows.Add("00", "CORTES");
                dgvLista.Rows.Add("00", "MARRANAS A VENTA");
            }
            if (tipoCatalogo == "CALIDAD")
            {
                this.Text = "Cat�logo de Calidad";
                lblTitulo.Text = "Seleccione la calidad.";
                dgvLista.Rows.Add("MARRANA","");
                dgvLista.Rows.Add("AA","");
                dgvLista.Rows.Add("AAA","");
                dgvLista.Rows.Add("HORNO","");
                dgvLista.Rows.Add("STDR","");
            }
            if (tipoCatalogo == "LOTE")
            {
                this.Text = "Cat�logo de Lotes";
                lblTitulo.Text = "Seleccione el lote.";
                dgvLista.Rows.Add("00","CORTES");
                dgvLista.Rows.Add("01","CANAL BAJIO");
                dgvLista.Rows.Add("02","CAPOTES");
                dgvLista.Rows.Add("05","MARRANAS A VENTAS");
            }

            if (tipoCatalogo == "ALMACEN")
            {
                this.Text = "Cat�logo de Almacenes";
                lblTitulo.Text = "Seleccione el almac�n.";
                dgvLista.Rows.Add("01","Almac�n 01");
                dgvLista.Rows.Add("02", "Almac�n 02");
                dgvLista.Rows.Add("03", "Almac�n 04");
                dgvLista.Rows.Add("04", "Almac�n 05");
            }
            if (tipoCatalogo == "BASCULA")
            {
                this.Text = "Cat�logo de B�sculas";
                lblTitulo.Text = "Seleccione la b�scula.";
                dgvLista.Rows.Add("01","B�scula 1");
                dgvLista.Rows.Add("02", "B�scula 2");
                dgvLista.Rows.Add("03", "B�scula 3");
                dgvLista.Rows.Add("MANUAL", "MANUAL");
            }
            if (tipoCatalogo == "MATERIAL")
            {
                this.Text = "Cat�logo de Materiales";
                lblTitulo.Text = "Seleccione la materiales.";
                dgvLista.Rows.Add("134303A1","PIERNA SIN HUESO");
                dgvLista.Rows.Add("134366C1","PIERNA EN TROZO");
                dgvLista.Rows.Add("134602A1","CUERO SIN GRASA");
                dgvLista.Rows.Add("134606A2","CUERO CON GRASA");
            }

            if (tipoCatalogo == "TIPOMATERIAL")
            {
                this.Text = "Cat�logo de Tipo de Materiales";
                lblTitulo.Text = "Seleccione lel tipo de material.";
                dgvLista.Rows.Add("01", "Tipo 01");
                dgvLista.Rows.Add("02", "Tipo 02");
                dgvLista.Rows.Add("03", "Tipo 03");
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
                this.DialogResult = DialogResult.Yes;
            }
            catch
            { 
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void spcPrincipal_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}