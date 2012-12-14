using System;
using System.Collections;
using System.Windows.Forms;

namespace Contingencia
{
    public partial class FrmMonitorEntregas : FrmBase
    {
        public FrmMonitorEntregas()
        {
            InitializeComponent();
            textCentro.Focus();
        }

        private void FrmMonitorEntregas_Activated(object sender, EventArgs e)
        {
            textCentro.Focus();
        }


        private void FrmMonitorEntregas_Load(object sender, EventArgs e)
        {
            PonerTitulo("Monitor de Entregas Pendientes");

            //Preparar caja texto para autollenado
            AutollenadoCentro();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarDatos();
                FrmConfirmacionEntregas confirmacionEntregas = new FrmConfirmacionEntregas();
                confirmacionEntregas.IdEntrega = textEntrega.Text;
                confirmacionEntregas.IdCentro = textCentro.Text;

                if (rdbCanal.Checked)
                    confirmacionEntregas.TipoReporte = "CANAL";
                else if (rdbProducto.Checked)
                    confirmacionEntregas.TipoReporte = "PRODUCTO";
                else
                    confirmacionEntregas.TipoReporte = "REMISION";

                confirmacionEntregas.IniciarForma();
                confirmacionEntregas.ShowDialog();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        //*********************************************
        //                 Centro
        //*********************************************

        private void textCentro_Enter(object sender, EventArgs e)
        {
            TextoColorEdicionOn(textCentro);
        }

        private void textCentro_KeyPress(object sender, KeyPressEventArgs e)
        {
            MensajeApagar();
            textNombreCentro.Text = "";
        }

        private void textCentro_Leave(object sender, EventArgs e)
        {
            TextoColorEdicionOff(textCentro);
        }


        //*********************************************
        //                 Entrega
        //*********************************************

        private void textEntrega_Enter(object sender, EventArgs e)
        {
            TextoColorEdicionOn(textEntrega);
        }

        private void textEntrega_KeyPress(object sender, KeyPressEventArgs e)
        {
            MensajeApagar();
        }

        private void textEntrega_Leave(object sender, EventArgs e)
        {
            TextoColorEdicionOff(textEntrega);
        }

        //*********************************************
        //                 Centros
        //*********************************************

        private void picCentros_Click(object sender, EventArgs e)
        {
            ConsultarCentros();
        }

        //*********************************************
        //                 Validaciones
        //*********************************************

        private void ValidarDatos()
        {
            bool centroValido = true;
            bool entregaValido = true;
            string mensaje = "";

            //Validacion del Centro
            if (textCentro.Text.Trim().Length == 0)
            {
                centroValido = false;
            }

            if (!centroValido)
            {
                textCentro.SelectAll();
                textCentro.Focus();
                mensaje = "El centro no existe";
                throw new Exception(mensaje);
            }

            //Validacion de la entrega
            if (textEntrega.Text.Trim().Length == 0)
            {
                entregaValido = false;
            }
            else
            {
                string expresion = "where vstel ='" + textCentro.Text.Trim() + "'";
                ClsEntregasCollection entregasCollection = new ClsEntregasBAL().ConsultarEntregasBAL(expresion);
                IEnumerator lista = entregasCollection.GetEnumerator();

                entregaValido = false;

                while (lista.MoveNext())
                {
                    var entregaObtenida = (ClsEntregas)lista.Current;

                    if (textEntrega.Text.Trim() == entregaObtenida.Entrega)
                    {
                        entregaValido = true;
                        break;
                    }
                }
            }

            if (!entregaValido)
            {
                textEntrega.SelectAll();
                mensaje = "No existe la entrega";
                textEntrega.Focus();
                throw new Exception(mensaje);
            }
        }

        private void ConsultarCentros()
        {
            MensajeApagar();

            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            listaSeleccion.TipoCatalogo = "CENTRO";
            listaSeleccion.IniciarForma();

            DialogResult resultado = listaSeleccion.ShowDialog();

            if (resultado == DialogResult.Yes)
            {
                textCentro.Text = listaSeleccion.ClaveSel;
                textNombreCentro.Text = listaSeleccion.DescSel;
            }
        }
        
        private void AutollenadoCentro()
        {
            textCentro.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textCentro.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            CLSCatCentroCollection centro = new CLSCatCentroBAL().MostrarCatCentroBAL("");
            IEnumerator lista = centro.GetEnumerator();
            var data = new AutoCompleteStringCollection();

            while (lista.MoveNext())
            {
                var centroM = (CLSCatCentro) lista.Current;
                if (centroM != null)
                    data.Add(centroM.CodCentro);
            }

            textCentro.AutoCompleteCustomSource = data;
        }

    }
}