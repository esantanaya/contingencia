using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Contingencia
{
    public partial class FrmDesembalar : FrmBase
    {
        private string lsWerks = "";
        private string lsMatnr = "";
        private string lsDesc = "";
        private string lsDesembalada = "";
        private string lsTarima= "";

        public FrmDesembalar()
        {
            InitializeComponent();

        }

        private void FrmDesembalar_Load(object sender, EventArgs e)
        {
            base.PonerTitulo("Desembalar Tarima");
            txtbxTarimas.Focus();
            txtbxTarimas.Select();
        }



        private void txtbxTarimas_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxTarimas);
            base.MensajeApagar();
        }

        private void txtbxTarimas_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxTarimas);
            base.MensajeApagar();
        }

        private void txtbxMaterial_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxMaterial);
        }

        private void txtbxMaterial_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxMaterial);

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmZMASTERMenu master = new FrmZMASTERMenu();
            master.ShowDialog();
        }

        private void txtbxTarimas_KeyPress(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == (Keys.Enter))
            {
                ValidarLlenaTxt();
            }

        }

        public void ValidarDatos()
        {
            char[] arraySep = { ']' };
            String[] cad;

            if (txtbxTarimas.Text.Substring(0, 1).Equals("T"))
            {
                //string tarima;
                cad = txtbxTarimas.Text.Trim().Split(arraySep);
                lsTarima = cad[0].ToString().Remove(0, 1); 
            }
            else
            {
                lsTarima = txtbxTarimas.Text;
            }
            string criterio = "";

            criterio = "where IdTarima = " + lsTarima;

            ClsCatZMasterCollection coleccionZMaster;
            coleccionZMaster = (new ClsCatZMasterBAL()).ConsultarZMasterBAL(criterio);

            if (coleccionZMaster.Count != 0)
            {
                ClsCatZMaster tabZmaster = new ClsCatZMaster();

            }
            else
            {
                throw new Exception("No existe la tarima!");
            }

            //Valida werks tipo 0G00
            lsWerks = coleccionZMaster[0].Werks;
            lsDesembalada = coleccionZMaster[0].Desembalada;
                
            criterio = "where WERKS = '" + lsWerks + "'";
            CLSCatCentroCollection colCentros = new CLSCatCentroBAL().MostrarCatCentroBAL(criterio);
            if (colCentros.Count > 0)
            {
                CLSCatCentro centro = colCentros[0];
                if ((centro.TipoCentro).Equals("0G00"))
                {
                    throw new Exception("No se puede Desembalar");
                }
                else
                {
                    if (lsDesembalada == "X")
                    {
                        Limpiar();
                        throw new Exception("La Tarima ya fue Desemabalada!!");
                    }
                    else
                    {
                        Desembalar();
                    }
                }
            }
            else
            {
                throw new Exception("No existe el centro al que esta asiganda la Tarima!");
            }
        }

        public void ValidarLlenaTxt()
        {
            if(txtbxTarimas.Text.Substring(0, 1).Equals("T"))
            {
                //string tarima;

                char[] arraySep = { ']' };
                String[] cad = txtbxTarimas.Text.Trim().Split(arraySep);
                lsTarima = cad[0].ToString().Remove(0, 1);
           // }
            //else if (txtbxTarimas.Text.Trim().Length != 0)
            //{
                string criterio = "";

                criterio = "where IdTarima = " + lsTarima;

                ClsCatZMasterCollection coleccionZMaster;
                coleccionZMaster = (new ClsCatZMasterBAL()).ConsultarZMasterBAL(criterio);

                if (coleccionZMaster.Count != 0)
                {
                    ClsCatZMaster tabZmaster = new ClsCatZMaster();
                    ClsNumCaja numCaja = new ClsNumCaja();
                    txtbxCajaAcum.Text = coleccionZMaster.Count.ToString();
                    txtbxFechaArma.Text = coleccionZMaster[0].FechaCreacion.ToString().Substring(0, 10);
                    txtbxLote.Text = coleccionZMaster[0].Charg;
                    lsWerks = coleccionZMaster[0].Werks;
                    lsMatnr = coleccionZMaster[0].Matnr;
                    lsDesc = numCaja.descripcion(lsMatnr, lsWerks);
                    txtbxMaterial.Text = lsMatnr;
                    txtbxDesc.Text = lsDesc;

                    IEnumerator lista = coleccionZMaster.GetEnumerator();
                    int kilos = 0;

                    while (lista.MoveNext())
                    {
                        tabZmaster = (ClsCatZMaster)lista.Current;
                        kilos = kilos + int.Parse(tabZmaster.Cantidad.ToString());
                    }
                    txtbxKiloAcum.Text = kilos.ToString();
                }
                else
                {
                    base.MostrarError("No existe la tarima!");
                }
            }

        }

        private void btnDesembalar_Click(object sender, EventArgs e)
        {
            string tarima = "";

            if (txtbxTarimas.Text.StartsWith("T"))
            {
                tarima = txtbxTarimas.Text.Substring(1, 10);
            }
            else
            {
                tarima = txtbxTarimas.Text;
            }

            if (txtbxTarimas.Text == "")
            {
                base.MostrarError("Ingresa el numero de tarima!");
                return;
            }

            try
            {
                DialogResult resultado = MessageBox.Show("Desea Desembalar la tarima " + tarima + "?", "Desembalar", MessageBoxButtons.YesNo);
                
                if (resultado == DialogResult.Yes)
                {
                    ValidarDatos(); 
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }

        }



        public void Desembalar()
        {
           if(txtbxTarimas.Text.Substring(0, 1).Equals("T"))
            {
                char[] arraySep = { ']' };
                String[] cad = txtbxTarimas.Text.Trim().Split(arraySep);
                lsTarima = cad[0].ToString().Remove(0, 1);
            }
            else   
           {
               lsTarima = txtbxTarimas.Text;
           }
            string criterio = "";

            criterio = "where IdTarima = " + lsTarima;

            ClsCatZMasterCollection coleccionZMaster;
            coleccionZMaster = (new ClsCatZMasterBAL()).ConsultarZMasterBAL(criterio);

            if (coleccionZMaster.Count != 0)
            {
                ClsCatZMaster tabZmaster = new ClsCatZMaster();
                ClsCatZMasterBAL bal = new ClsCatZMasterBAL();

                tabZmaster = coleccionZMaster[0];

                tabZmaster.Desembalada = "X";
                bal.ActualizarZMasterBAL(tabZmaster);
                base.MostrarMensaje("Tarima Desemabalada!!");
            }
            else
            {
                base.MostrarError("No existe Tarima!!");
            }

            
        }

        public void Limpiar()
        {
            txtbxTarimas.Text = "";
            //txtbxTarimas.Focus();
            txtbxCajaAcum.Text = "";
            txtbxDesc.Text = "";
            txtbxFechaArma.Text = "";
            txtbxKiloAcum.Text = "";
            txtbxLote.Text = "";
            txtbxMaterial.Text = "";
        }

        private void txtbxDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void ValidaTarima()
        {
            txtbxTarimas.Text = txtbxTarimas.Text.ToUpper();

            if (txtbxTarimas.Text.Substring(0, 1) != "T")
            {
                throw new Exception("Ingrese una tarima valida!");
            }
        }

        private void FrmDesembalar_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tarima = txtbxTarimas.Text.Substring(1, 10);

            try
            {
                if (txtbxTarimas.Text == "")
                {
                    base.MostrarError("Ingresa el numero de tarima!");
                    return;
                }

                if (e.KeyChar == (char)Keys.Enter)
                {
                    ValidarLlenaTxt();
                }

                if(e.KeyChar == (char)Keys.F8)
                {
                    DialogResult resultado = MessageBox.Show("Desea Desembalar la tarima " + tarima + "?", "Desembalar", MessageBoxButtons.YesNo);
                    if (resultado == DialogResult.Yes)
                    {
                        ValidarDatos();
                    }
                }
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }
    }

}
