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
* Descripción: Punto de control ZPPG03 :: Pesado de Cabeza
*/

namespace Contingencia
{
    public partial class FrmZPPG03 : FrmBase
    {

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Declaración de variables
         */

        private CLSFatomCollection fatCol;

        private string centro;
        public string Centro
        {
            get { return centro; }
            set { centro = value; }
        }

        private string bascula;
        public string Bascula
        {
            get { return bascula; }
            set { bascula = value; }
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Revisa que exista el folio
         */

        private void RevisarFolios() 
        {
            string hoy = dtpFecha.Value.ToString("yyyy-MM-dd 00:00:00");
            string diaSiguiente = dtpFecha.Value.AddDays(1).ToString("yyyy-MM-dd 00:00:00");
            string criterio = "WHERE (FECHA >= CONVERT(DATETIME, '" + hoy + "', 120)) ";
            criterio = criterio + "AND (FECHA <= CONVERT(DATETIME, '" + diaSiguiente + "', 120)) ";
            criterio = criterio + "AND (WERKS = '" + centro + "')";
            criterio = criterio + "AND (PESAR_CAB = 'X')";
            criterio = criterio + "AND (PESO_CAB <= 0)";
            fatCol = new CLSFatomBAL().MostrarFatomBAL(criterio);
            IEnumerator lista = fatCol.GetEnumerator();
            try
            {
                if (fatCol.Count <= 0)
                {
                    btnGrabar.Enabled = false;
                    MessageBox.Show("Ya no hay folios para esta fecha!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtbxFolio.Text = "";
                    txtbxFolio.Enabled = false;
                    throw new Exception("Ya no hay folios para esta fecha!");
                }
                else
                {
                    while (lista.MoveNext())
                    {
                        btnGrabar.Enabled = true;
                        txtbxFolio.Enabled = true;
                        txtbxFolio.Text = fatCol[0].Folio.ToString();
                        break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FrmZPPG03()
        {
            InitializeComponent();
        }

        private void FrmZPPG03_Load(object sender, EventArgs e)
        {
            try
            {
                base.PonerTitulo("Pesado de Cabeza.");
                txtbxPeso.Select();
                txtbxPeso.Focus();
                if(bascula != "MANUAL")
                {
                    txtbxPeso.Enabled = false;
                }
                RevisarFolios();
            }
            catch (Exception ex)
            {

                base.MostrarError(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.MensajeApagar();
            try
            {
                CalcularNeto();
                ActualizarFatom();
                RevisarFolios();
                txtbxPeso.Select();
                txtbxPeso.Focus();
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
         * Descripción: Actualiza la tabla ZPPFATOM
         */

        private void ActualizarFatom()
        {
            CLSFatomBAL fatomBAL = new CLSFatomBAL();
            CLSFatom fatom = new CLSFatom();
            string criterio = "";
            DateTime diaSiguiente = dtpFecha.Value.AddDays(1);

            for (int i = 0; i < dgvLista.RowCount; i++)
            {
                criterio = "WHERE (FECHA >= CONVERT(DATETIME, '" + dtpFecha.Value.ToString("yyyy-MM-dd 00:00:00") + "', 120)) ";
                criterio = criterio + "AND (FECHA <= CONVERT(DATETIME, '" + diaSiguiente.ToString("yyyy-MM-dd 00:00:00") + "', 120)) ";
                criterio = criterio + "AND (WERKS = '" + centro + "')";
                criterio = criterio + "AND (FOLIO = '" + dgvLista.Rows[i].Cells[1].Value.ToString() + "')";
                fatom.PesoCab = Convert.ToDouble(dgvLista.Rows[i].Cells[2].Value.ToString());
                fatom.Procesado = " ";
                fatomBAL.ActualizarEstadoBAL(fatom, criterio);
            }
        }

        /*
         * Autor: Enrique Santana
         * Fecha de creación: 02/05/2012
         * Fecha de liberación: 04/06/2012
         * Descripción: Calcula el peso neto
         */

        private void CalcularNeto() {
            
            double peso = 0.0;
            double tara = 0.0;
            double neto = 0.0;
            string cadena = "";

            try
            {
                peso = Convert.ToDouble(txtbxPeso.Text);
                if (txtbxTara.TextLength != 0)
                {
                    tara = Convert.ToDouble(txtbxTara.Text);
                }
                else
                {
                    txtbxTara.Text = tara.ToString();
                }
                neto = peso - tara;

                cadena = neto.ToString();

                if (peso <= tara)
                {
                    throw new Exception("El peso debe ser mayor a la tara");
                }

                if (txtbxFolio.Text == "" || txtbxPeso.Text == "")
                {
                    throw new Exception("Ingresar todos los campos");
                }

                dgvLista.Rows.Add(dtpFecha.Text, txtbxFolio.Text, cadena);
            }
            catch (Exception ex)
            {
                
                base.MostrarError(ex.Message);
            }
        }

        private void txtbxFolio_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxFolio);
        }

        private void txtbxFolio_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxFolio);
        }

        private void txtbxPeso_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxPeso);
        }

        private void txtbxPeso_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxPeso);
        }

        private void txtbxTara_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxTara);
        }

        private void txtbxTara_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxTara);
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                MensajeApagar();
                RevisarFolios();
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }

        //private void txtbxPeso_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Enter) { button1_Click(sender, e); }
        //}

        //private void txtbxTara_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if(e.KeyChar == (char)Keys.Enter) { button1_Click(sender, e); }
        //}

        //private void txtbxFolio_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if(e.KeyChar == (char)Keys.Enter) { button1_Click(sender, e); }
        //}

        //private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if(e.KeyChar == (char)Keys.Enter) { button1_Click(sender, e); }
        //}

        private void FrmZPPG03_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8 ) 
            {
                if (bascula != "MANUAL")
                {
                    CLSBasculas claseBascula = new CLSBasculas();
                    claseBascula.ModeloBascula = bascula;
                    try
                    {
                        txtbxPeso.Text = claseBascula.PuertoSerial();
                        button1_Click(sender, e);
                    }
                    catch (Exception ex)
                    {

                        base.MostrarError(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        if (btnGrabar.Enabled)
                        {
                            button1_Click(sender, e); 
                        }
                    }
                    catch (Exception ex)
                    {

                        base.MostrarError(ex.Message);
                    }
                }
            }
        }

        private void txtbxFolio_TextChanged(object sender, EventArgs e)
        {
            RevisarFolios();
        }

        private void btnSalir_Enter(object sender, EventArgs e)
        {
            btnSalir.TabStop = false;
        }
    }
}
