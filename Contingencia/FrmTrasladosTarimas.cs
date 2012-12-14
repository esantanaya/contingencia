using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Contingencia
{
    public partial class FrmTrasladosTarimas : FrmBase
    {
        public FrmTrasladosTarimas()
        {
            InitializeComponent();
            codigoCaja = "";
            tarima = "";
            primeraVez = true;
        }

        private string codigoCaja;
        private string tarima;
        private string centroC;
        private bool primeraVez;

        private void FrmTrasladosTarimas_Load(object sender, EventArgs e)
        {
            base.PonerTitulo("Traslado de Tarimas");
            textTarima.Focus();
            AutocompletarCentros();
            AutocompletarAlmacen();
        }

        private void textNombreCentro_TextChanged(object sender, EventArgs e)
        {

        }

        //private void picCentros_Click(object sender, EventArgs e)
        //{

        //}

        private void textTarima_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textTarima);
        }

        private void textCentro_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textCentro);
        }

        private void textAlmacen_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textAlmacen);
        }

        private void textTarima_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(textTarima);
        }

        private void textCentro_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(textCentro);
        }

        private void textAlmacen_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(textAlmacen);
        }


        private void FrmTrasladosTarimas_Activated(object sender, EventArgs e)
        {
            textTarima.Focus();
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {

            try
            {
                base.MensajeApagar();
                ValidarDatos();
                if (txtbxTipoAlmacen.TextLength > 10)
                {
                    Valida2(); 
                }
                GuardarRegistro();
 
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }

        private void GuardarRegistro()
        {
            try
            {
                //Crear el objeto con la info de la forma
                ClsZCAT zCat = new ClsZCAT();
                zCat.TARIMA = Convert.ToDecimal(textTarima.Text);
                zCat.Werks = textCentro.Text.Trim();
                zCat.Lgort = textAlmacen.Text.Trim();
                zCat.Ubicacion = textUbicacionDestino.Text.Trim();
                zCat.TipoAlmacen = txtbxTipoAlmacen.Text.Trim();

                ClsZCATBAL zCATBAL = new ClsZCATBAL();
                zCATBAL.AgregarZCATBAL(zCat);

                String lsCriterio = "WHERE IDTarima = '" + tarima + "' AND WERKS = '" + centroC + "' ";
                ClsCatZMasterBAL zMasBal = new ClsCatZMasterBAL();
                ClsCatZMasterCollection zMasColl = zMasBal.ConsultarZMasterBAL(lsCriterio);

                if (zMasColl.Count>0)
                {
                    ClsCatZMaster zMast = zMasColl[0];
                    zMast.CentroDestino = textCentro.Text;
                    zMast.AlmacenDestino = textAlmacen.Text;
                    zMast.UbicacionDestino = textUbicacionDestino.Text;
                    zMasBal.ActualizarZMasterDestinosBAL(zMast);
                }

                base.MostrarMensaje("Pedido de traslado creado...");
                PerformLayout();
                Application.DoEvents();
                System.Threading.Thread.Sleep(2000);


                textUbicacionDestino.Text = "";
                textTarima.Text = "";
                textCentro.Text = "";
                textAlmacen.Text = "";
                textTarima.Focus();
            }
            catch
            {
                throw;
            }
        }

        public void ValidaPrimeraVez() 
        {
            //valida tarima deacuerdo al codigo
            string lsMensaje="";
            if (!(((textTarima.Text).Substring(0, 1)).Equals("T")))
            {
                textTarima.SelectAll();
                lsMensaje = "Codigo no valido";
                textTarima.Focus();
                throw new Exception(lsMensaje);
            }

            tarima = textTarima.Text;

            String[] codigoCompleto = tarima.Split('@');
            tarima = codigoCompleto[0];

            String[] codigoTarima = tarima.Split('|');
            tarima = codigoCompleto[0];

            if (codigoTarima.Length == 7)
            {
                tarima = codigoTarima[0];
                tarima = tarima.Remove(0, 1);
                codigoCaja = codigoTarima[1] + "|" + codigoTarima[2] + "|" + codigoTarima[3] + "|" + codigoTarima[4] + "|" +
                    codigoTarima[5] + "|" + codigoTarima[6];
                textTarima.Text = tarima;

            }
            else
            {
                textTarima.SelectAll();
                lsMensaje = "Codigo no valido";
                textTarima.Focus();
                throw new Exception(lsMensaje);
            }
        }

        private void ValidarDatos()
        {
            //    bool lbCentroCorrecto = true;

            if (primeraVez)
            {
                primeraVez = false;
                ValidaPrimeraVez();
            }

            //    string lsMensaje = "";
            bool lbTarimaCorrecto = true;
            bool lbCentroCorrecto = true;
            bool lbAlmacenCorrecto = true;
            bool lblTarimaCorrecto = true;
            string lsMensaje = "";
            string criterio;
            
            
            base.MensajeApagar();

            

            //Valida que se tengan datos ingresados
            if (textTarima.Text.Trim().Length == 0)
            {
                textTarima.SelectAll();
                lsMensaje = "Ingrese TARIMA";
                textTarima.Focus();
                throw new Exception(lsMensaje);
            }
            if (txtbxTipoAlmacen.TextLength == 0)
            {
                txtbxTipoAlmacen.SelectAll();
                lsMensaje = "Ingrese TIPO DE ALMACEN";
                txtbxTipoAlmacen.Focus();
                throw new Exception(lsMensaje);
            }
            if (textCentro.Text.Trim().Length == 0)
            {
                textCentro.SelectAll();
                lsMensaje = "Ingrese CENTRO";
                textCentro.Focus();
                throw new Exception(lsMensaje);
            }

            if (textAlmacen.Text.Trim().Length == 0)
            {
                textAlmacen.SelectAll();
                lsMensaje = "Ingrese ALMACEN";
                textAlmacen.Focus();
                throw new Exception(lsMensaje);
            }
            if (textUbicacionDestino.Text.Trim().Length == 0)
            {
                textUbicacionDestino.SelectAll();
                lsMensaje = "Ingrese UBICACION";
                textUbicacionDestino.Focus();
                throw new Exception(lsMensaje);
            }

            //Validación por base de datos
            //Valida tarima

            try
            {
                double ldTarima = Convert.ToDouble(textTarima.Text.Trim());
            }
            catch
            {
                lbTarimaCorrecto = false;
                textTarima.SelectAll();
                textTarima.Focus();
                lsMensaje = "Tarima Inexistente";
                throw new Exception(lsMensaje);
            }


            try
            {
                //if (textTarima.Text.Trim().Length == 0)
                //{
                //    lblTarimaCorrecto = false;
                //}

                //criterio = "WHERE IDTarima = " + textTarima.Text + " AND WERKS = '" + textCentro.Text.Trim() + "'";
                criterio = "WHERE IDTarima = " + textTarima.Text;
                ClsCatZMasterCollection masterCollection;
                masterCollection = (new ClsCatZMasterBAL()).ConsultarZMasterBAL(criterio);
                if (masterCollection.Count == 0)
                {
                    lblTarimaCorrecto = false;
                }
                if (lblTarimaCorrecto == false)
                {
                    textTarima.SelectAll();
                    textTarima.Focus();
                    lsMensaje = "Tarima inexistente";
                    throw new Exception(lsMensaje);
                }


            }
            catch
            {
                throw;
            }


            //Valida centro
            try
            {

                criterio = "WHERE WERKS = '" + textCentro.Text + "'";
                CLSCatCentroCollection centrosColeccion;
                centrosColeccion = (new CLSCatCentroBAL()).MostrarCatCentroBAL(criterio);

                if (centrosColeccion.Count == 0)
                {
                    textCentro.SelectAll();
                    textCentro.Focus();
                    lsMensaje = "El centro no existe";
                    throw new Exception(lsMensaje);
                }
            }
            catch
            {
                throw;
            }
            
           

            //Valida Almacen
            try
            {

                //if (textBascula.Text.Trim().StartsWith("0") == false)
                criterio = "WHERE LGORT = '" + textAlmacen.Text + "' AND WERKS = '" + textCentro.Text + "' ";
                ClsCatAlmacenCollection almacenColeccion;
                almacenColeccion = (new ClsCatAlmacenBAL()).ConsultarAlmacenesBAL(criterio);

                if (almacenColeccion.Count == 0)
                {
                    lbAlmacenCorrecto = false;
                }
                                
                if (lbAlmacenCorrecto == false)
                {
                    textAlmacen.SelectAll();
                    lsMensaje = "Almacén inválido para el centro.";
                    textAlmacen.Focus();
                    throw new Exception(lsMensaje);
                }
            }

            catch
            {
                throw;
            }

            //Valida Ubicacion
            try
            {
                criterio = "WHERE LGORT = '" + textAlmacen.Text + "' AND WERKS = '" + textCentro.Text + "' "
                + " AND UBICACIONES = '" + textUbicacionDestino.Text.Trim() + "' AND TIPOALMACEN = '" + txtbxTipoAlmacen.Text + "'";
                ClsCatUbicacionesCollection ubicacionesColeccion;
                ubicacionesColeccion = (new ClsCatUbicacionesBAL()).ConsultarUbicacionesBAL(criterio);

                if (ubicacionesColeccion.Count == 0)
                {
                    textUbicacionDestino.SelectAll();
                    lsMensaje = "Ubicación inválida para el Centro/Almacén.";
                    textUbicacionDestino.Focus();
                    throw new Exception(lsMensaje);
                }
            }
            catch
            {
                throw;
            }

            //Validar disponibilidad en zmaster
            try
            {

                //criterio = "WHERE IDTarima = " + textTarima.Text + " AND WERKS = '" + textCentro.Text.Trim() + "'";
                criterio = "WHERE IDTarima = " + textTarima.Text
                    +  " AND WERKS <> '" + textCentro.Text.Trim() + "' ";
                ClsCatZMasterCollection masterCollection;
                masterCollection = (new ClsCatZMasterBAL()).ConsultarZMasterBAL(criterio);
                //if (masterCollection.Count == 0)
                //{
                //    textTarima.SelectAll();
                //    textTarima.Focus();
                //    lsMensaje = "La Tarima no corresponde al centro.";
                //    throw new Exception(lsMensaje);
                //}
                IEnumerator listaRegistros = masterCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsCatZMaster currMaster = (ClsCatZMaster)listaRegistros.Current;
                    if (currMaster.Werks.ToUpper() == textCentro.Text.Trim().ToUpper())
                    {
                        textTarima.SelectAll();
                        textTarima.Focus();
                        lsMensaje = "La Tarima se encuentra en el centro de destino.";
                        throw new Exception(lsMensaje);
                    }
                    if (currMaster.Desembalada != null && currMaster.Desembalada.Length > 0)
                    {
                        lsMensaje = "La Tarima está desembalada.";
                        throw new Exception(lsMensaje);
                    }
                    if (currMaster.Borrado != null && currMaster.Borrado.Length>0)
                    {
                        lsMensaje = "La Tarima está borrada.";
                        throw new Exception(lsMensaje);
                    }
                    if (currMaster.AsignadaEntrega != null && currMaster.AsignadaEntrega.Length > 0)
                    {
                        lsMensaje = "La Tarima está asignada para entrega.";
                        throw new Exception(lsMensaje);
                    }
                    break;
                }

            }
            catch
            {
                throw;
            }

            //validar 

        }

        private void ConsultarTipoAlmacen()
        {
            DialogResult resultado;
            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            listaSeleccion.TipoCatalogo = "TIPOALMACEN";
            string lsCriterio = "WHERE WERKS = '" + textCentro.Text + "'";
            listaSeleccion.CriterioAd = lsCriterio;
            listaSeleccion.IniciarForma();
            resultado = listaSeleccion.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                string lsClave = listaSeleccion.ClaveSel;
                txtbxTipoAlmacen.Text = lsClave;
            }
        }

        private void ConsultarAlmacen()
        {
            DialogResult resultado;
            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            listaSeleccion.TipoCatalogo = "ALMACEN";
            listaSeleccion.IniciarForma();
            resultado = listaSeleccion.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                string lsClave = listaSeleccion.ClaveSel;
                textAlmacen.Text = lsClave;
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
                textCentro.Text = lsClave;
            }
        }

        private void ConsultarUbicacion()
        {
            DialogResult resultado;
            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            string lsCriterio = "where werks='" + textCentro.Text + "' and lgort='" + textAlmacen.Text + "' and tipoalmacen='" + txtbxTipoAlmacen.Text + "'";
            listaSeleccion.CriterioAd = lsCriterio;
            listaSeleccion.TipoCatalogo = "UBICACIONES";
            listaSeleccion.IniciarForma();
            listaSeleccion.CriterioAd = lsCriterio;
            resultado = listaSeleccion.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                string lsClave = listaSeleccion.ClaveSel;
                textUbicacionDestino.Text = lsClave;
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
            textCentro.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textCentro.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textCentro.AutoCompleteCustomSource = datos;
        }

        public void AutocompletarAlmacen()
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();

            ClsCatAlmacenCollection almacenCol;
            almacenCol = new ClsCatAlmacenBAL().ConsultarAlmacenesBAL("");
            IEnumerator lista = almacenCol.GetEnumerator();

            while (lista.MoveNext())
            {
                ClsCatAlmacen almacenM = (ClsCatAlmacen)lista.Current;
                datos.Add(almacenM.Lgort);
            }
            textAlmacen.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textAlmacen.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textAlmacen.AutoCompleteCustomSource = datos;
        }       


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void textUbicacion_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textUbicacionDestino);
        }

        private void textUbicacion_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(textUbicacionDestino);
        }

        private void pbxCentro_Click(object sender, EventArgs e)
        {
            ConsultarCentros();
        }

        private void pbxAlmacen_Click(object sender, EventArgs e)
        {
            ConsultarAlmacen();
        }

        private void pbxUbicacion_Click(object sender, EventArgs e)
        {
            ConsultarUbicacion();
        }

        private void FrmTrasladosTarimas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    ValidarDatos();
                    if(txtbxTipoAlmacen.TextLength > 10)
                    {
                        Valida2();
                    }
                    btnContinuar.Focus();
                }
                catch (Exception ex)
                {
                    base.MostrarError(ex.Message);
                }
            }
            else if (e.KeyCode == Keys.F8)
            {
                //ValidarYProcesar();
            }
        }

        public void Valida2() 
        {
            string lsCriterio="";
            ClsDividirC dividirCodCaja = new ClsDividirC();
            string[] formatoC = { "H", "P", "L", "D", "Q", "W" };
            string lsMensaje = "";

            if (dividirCodCaja.DividirC(codigoCaja, formatoC))
            {
                lsCriterio = "WHERE WERKS = '"+dividirCodCaja.Centro+"'";
                CLSCatCentroCollection colCentros = new CLSCatCentroBAL().MostrarCatCentroBAL(lsCriterio);
                if(colCentros.Count > 0)
                {

                    CLSCatCentro centro = colCentros[0];
                    if((centro.TipoCentro).Equals("0G00"))
                    {
                        centroC = dividirCodCaja.Centro;
                        lsCriterio = "WHERE IDTarima = '" + tarima + "' AND WERKS = '" + centroC + "' ";
                        ClsCatZMasterCollection zMasColl = new ClsCatZMasterBAL().ConsultarZMasterBAL(lsCriterio);
                        if(zMasColl.Count>0){
                            ClsCatZMaster zMaz= zMasColl[0];
                            
                            if (!((zMaz.CentroDestino).Equals("")))
                            {
                                textTarima.SelectAll();
                                lsMensaje = "La tarima se encuentra en centro " + zMaz.CentroDestino;
                                textTarima.Focus();
                                throw new Exception(lsMensaje);
                            }

                            if (!((zMaz.AlmacenDestino).Equals("")))
                            {
                                textTarima.SelectAll();
                                lsMensaje = "La tarima se encuentra en almacen "+ zMaz.AlmacenDestino;
                                textTarima.Focus();
                                throw new Exception(lsMensaje);
                            }

                            if (!((zMaz.UbicacionDestino).Equals("")))
                            {
                                textTarima.SelectAll();
                                lsMensaje = "La tarima se encuentra en ubicacion " + zMaz.UbicacionDestino;
                                textTarima.Focus();
                                throw new Exception(lsMensaje);
                            }
                        }
                    }
                }
            }
            else 
            {
                textTarima.SelectAll();
                lsMensaje = "Codigo no valido";
                textTarima.Focus();
                throw new Exception(lsMensaje);
            }

        }

        private void pctbxTipoAlmacen_Click(object sender, EventArgs e)
        {
            ConsultarTipoAlmacen();
        }
    }
}