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
    public partial class FrmAgregarTarima : FrmBase
    {
        private string tarima = "";
        private int cajas = 0;
        private ArrayList arregloTarima = new ArrayList();

        public FrmAgregarTarima()
        {
            InitializeComponent();
        }

        private void FrmAgregarTarima_Load(object sender, EventArgs e)
        {
            base.PonerTitulo("Agregar Tarima");
            txtbxTarima.Select();
            txtbxTarima.Focus();
        }

        private void txtbxTarima_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxTarima);
        }

        private void txtbxTarima_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxTarima);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            base.MensajeApagar();
            ClsNumCaja num = new ClsNumCaja();
            try
            {
                //ValidaTarima();
                //int i = ObtenerCajas();
                ValidaVacios();
                int cont = 0;
                cont = Convert.ToInt32(txtbxContCajas.Text);
                if(cont > 0)
                {
                    base.MostrarError("Aún le faltan agregar " + txtbxContCajas.Text + " cajas");
                    return;
                }
                num.NumFolio = Convert.ToInt64(tarima);
                num.coleccionDatos(arregloTarima);
                base.MostrarMensaje("La tarima se agregó correctamente con " + cajas.ToString() + " cajas!");
                txtbxTarima.Enabled = true;
                txtbxTarima.ReadOnly = false;
                txtbxCaja.Clear();
                txtbxTarima.Select();
                txtbxTarima.Focus();
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }

        private void ValidaVacios()
        { 
            if(txtbxTarima.TextLength == 0)
            {
                throw new Exception("Ingresa una tarima!");
            }
        }

        private int ObtenerCajas()
        {
            ClsCatZMasterBAL agregaZMaster = new ClsCatZMasterBAL();
            DateTime ahora = DateTime.Now;
            string horaC = ahora.Hour.ToString() + ":" + ahora.Minute.ToString() + ":" + ahora.Second.ToString();

            string[] cajas = txtbxTarima.Text.Split('@');
            
            int i = 0;

            foreach (string elem in cajas)
            {
                ClsCatZMaster zMaster = new ClsCatZMaster();
                ClsNumCaja numCaja = new ClsNumCaja();
                string[] elementos = elem.Split('|');
                zMaster.IdTarima = elementos[0].Remove(0, 1);
                zMaster.IdCaja = Convert.ToInt64(elementos[1].Remove(0, 1));
                zMaster.Matnr = elementos[2].Remove(0, 1);
                zMaster.Charg = elementos[3].Remove(0, 1);
                zMaster.FechaProduccion = Convert.ToDateTime(elementos[4].Remove(0, 1).ToString());
                zMaster.Cantidad = Convert.ToDouble(elementos[5].Remove(0, 1));
                zMaster.Werks = elementos[6].Remove(0, 1);
                zMaster.CreadoPor = "SAP";
                zMaster.Desembalada = " ";
                zMaster.Borrado = " ";
                zMaster.AsignadaEntrega = " ";
                zMaster.FechaCaducidad = numCaja.regresaFecha(zMaster.Matnr, zMaster.FechaProduccion, zMaster.Werks);
                zMaster.FechaCreacion = ahora;
                zMaster.HoraCreacion = ahora;

                if (i == 0)
                {
                    ClsCatZMasterCollection revisaZMaster;
                    string criterio = "WHERE (WERKS = '" + zMaster.Werks + "') ";
                    criterio = criterio + "AND (IDTARIMA = '" + zMaster.IdTarima + "')";
                    revisaZMaster = new ClsCatZMasterBAL().ConsultarNumCajasTarimaBAL(criterio);
                    if (revisaZMaster.Count > 0)
                    {
                        throw new Exception("La Tarima " + zMaster.IdTarima + " ya se encuentra en la tabla ZMASTER ");
                    } 
                }

                i++;
                txtbxTarima.Text = zMaster.IdTarima;
                agregaZMaster.AgregarZMasterBAL(zMaster);
            }
            return i;
        }

        private void ValidaTarima()
        {
            txtbxTarima.Text = txtbxTarima.Text.ToUpper();

            if (txtbxTarima.Text.Substring(0, 1) != "T")
            {
                throw new Exception("Ingrese una tarima valida!");
            }
        }

        private void txtbxTarima_KeyUp(object sender, KeyEventArgs e)
        {
            base.MensajeApagar();

            if (e.KeyCode == Keys.Enter)
            {
                string[] arrayTarima = txtbxTarima.Text.Split(']');
                try
                {
                    tarima = arrayTarima[0].Remove(0, 1);
                    cajas = Convert.ToInt32(arrayTarima[1].Remove(0, 1));
                    txtbxTarima.Enabled = false;
                }
                catch 
                {
                    base.MostrarError("Ingrese o escanee un código de tarima valido");
                    return;
                }

                MessageBox.Show("Debe ingresar " + cajas.ToString() + " cajas a la tarima", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtbxContCajas.Text = cajas.ToString();
                txtbxCaja.ReadOnly = false;
                txtbxCaja.TabStop = true;
            }
        }

        private void txtbxCaja_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(txtbxCaja);
        }

        private void txtbxCaja_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(txtbxCaja);
        }

        private void txtbxCaja_KeyUp(object sender, KeyEventArgs e)
        {

            base.MensajeApagar();

            if (e.KeyCode == Keys.Enter)
            {
                if(txtbxCaja.TextLength == 0)
                {
                    base.MostrarError("Ingrese una caja!");
                    return;
                }

                if(txtbxContCajas.Text.Equals("0"))
                {
                    base.MostrarError("Ya ha registrado todas las cajas para esta tarima");
                    return;
                }

                //string cajaCompleto = "T" + tarima + "]" + txtbxCaja.Text.Trim();
                int cont = 0;
                try
                {
                    ValidaCaja(txtbxCaja.Text);
                    arregloTarima.Add(txtbxCaja.Text);
                    cont = Convert.ToInt32(txtbxContCajas.Text);
                    cont--;
                    txtbxContCajas.Text = cont.ToString();
                }
                catch (Exception ex)
                {
                    base.MostrarError(ex.Message);
                } 
            }
        }

        private void ValidaCaja(string codigoCaja)
        {
            string[] elemetosCaja = codigoCaja.Split(']');
            string cajaUnica = " ";
            string centro = " ";
            string criterio = "";

            try
            {
                cajaUnica = elemetosCaja[0].Remove(0, 1);
                centro = elemetosCaja[5].Remove(0, 1);

                criterio = "WHERE (IDCaja = '" + cajaUnica + "') ";
                criterio = criterio + "AND (WERKS = '" + centro + "') ";
                criterio = criterio + "AND (DESEMBALADA = '' OR DESEMBALADA = ' ') ";
                criterio = criterio + "AND (BORRADO = '' OR BORRADO = ' ')";

                ClsCatZMasterCollection validaZMaster = new ClsCatZMasterBAL().ConsultarZMasterBAL(criterio);

                if (validaZMaster.Count > 0)
                {
                    throw new Exception("La caja " + cajaUnica + " ya se encuentra asignada a una tarima");
                }

                foreach(string registroCaja in arregloTarima)
                {
                    if(registroCaja.Equals(txtbxCaja.Text))
                    {
                        throw new Exception("Caja ya ingresada");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }        
}
