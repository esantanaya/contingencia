using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contingencia
{
    public partial class FrmZPPG27 : FrmBase
    {
        public FrmZPPG27()
        {
            InitializeComponent();
            textCentro.Focus();
        }

        ClsDividirC divCodigo;

        private ClsZCTCCollection zCTCCollection = new ClsZCTCCollection();
        private int contador =0;
        private string caja;

        private void FrmZPPG27_Load(object sender, EventArgs e)
        {
            base.PonerTitulo("Estación de traslado de cajas");
            textCentro.Focus();
            AutocompletarCentros();
            AutocompletarAlmacen();
            
            
        }

        private void textCentro_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textCentro);
        }

        private void textCentro_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(textCentro);
        }

        private void textAlmacen_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textAlmacen);
        }

        private void textAlmacen_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(textAlmacen);
        }

        private void txtbxcaja_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textCaja);
        }

        private void txtbxcaja_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(textCaja);
        }

        private void txtbxCaja_Finish(object sender, EventArgs e)
        {
            
        }

        
        private void btnResfrescar_Click(object sender, EventArgs e)
        {
            
            textCaja.Text = Variables.Blanco;            
            dgvLista.Rows.Clear(); 
            textTotalCajas.Text = Variables.Blanco;
            contador = 0;

        }

        
        private void LimpiarMensaje() {
            
            base.MostrarError("");
            
        }

        

        
        private void pbxAlmacen_Click(object sender, EventArgs e)
        {
            ConsultarAlmacen();
        }

        private void pbxCentro_Click(object sender, EventArgs e)
        {
            ConsultarCentros();
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

        

        public void AgregarACollection()
        {
            DateTime fecha = DateTime.Now;
            ClsZCTC zCTC = new ClsZCTC();
            string lsCriterio ="";
            
            zCTC.Werks = textCentro.Text;
            zCTC.Lgort = textAlmacen.Text;
            zCTC.Caja = caja;
            zCTC.FechaTraslado = fecha;
            zCTC.HoraTraslado = fecha;
            lsCriterio = "WHERE  CAJA = '" + caja + "'";
            ClsZCTCCollection zCTCColeccionTemp;
            zCTCColeccionTemp = (new ClsZCTCBAL()).ConsultarZCTCBAL(lsCriterio);
            zCTC.CantidadMovimientos = zCTCColeccionTemp.Count + 1;
            contador++;
            textTotalCajas.Text = ""+contador;
            zCTCCollection.Add(zCTC);
        }

        public void InsertarColeccionATablaZCTC() 
        {
            IEnumerator lista = zCTCCollection.GetEnumerator();
            ClsZCTCBAL zCTCbal = new ClsZCTCBAL();
            while (lista.MoveNext())
            {
                ClsZCTC zCTC = (ClsZCTC)lista.Current;
                zCTCbal.AgregarZCTCBAL(zCTC);
            }
        }

        

        private void ValidarDatos()
        {
            
            bool lbCentroCorrecto = true;
            bool lbAlmacenCorrecto = true;
            bool lbCajaCorrecto = true;
            string lsMensaje = "";
            string criterio;
            
            try
            {
                if (textCentro.Text.Trim().Length == 0)
                {
                    lbCentroCorrecto = false;
                }

                criterio = "WHERE WERKS = '" + textCentro.Text + "'";
                CLSCatCentroCollection centrosColeccion;
                centrosColeccion = (new CLSCatCentroBAL()).MostrarCatCentroBAL(criterio);

                if (centrosColeccion.Count == 0)
                {
                    lbCentroCorrecto = false;
                }
                if (lbCentroCorrecto == false)
                {
                    textCentro.SelectAll();
                    textCentro.Focus();
                    textAlmacen.Text = Variables.Blanco;
                    textCaja.Text = Variables.Blanco;
                    lsMensaje = "El centro no existe";
                    throw new Exception(lsMensaje);
                }

            }
            catch
            {
                throw;
            }


            try
            {
                if (textAlmacen.Text.Trim().Length == 0)
                {
                    lbAlmacenCorrecto = false;
                }
                //if (textBascula.Text.Trim().StartsWith("0") == false)
                criterio = "WHERE LGORT = '" + textAlmacen.Text + "' AND WERKS = '" + textCentro.Text + "'";
                ClsCatAlmacenCollection almacenColeccion;
                almacenColeccion = (new ClsCatAlmacenBAL()).ConsultarAlmacenesBAL(criterio);

                if (almacenColeccion.Count == 0)
                {
                    lbAlmacenCorrecto = false;
                }
                if (lbAlmacenCorrecto == false)
                {
                    textAlmacen.SelectAll();
                    lsMensaje = "El almacén no existe";
                    textCaja.Text = Variables.Blanco;
                    textAlmacen.Focus();

                    throw new Exception(lsMensaje);
                }
            }
            catch
            {
                throw;
            }

            try
            {
                if (textCaja.Text.Trim().Length < 10)
                {
                    lbCajaCorrecto = false;
                    lsMensaje = "Código incorrrecto";
                }
                else
                {
                    //comprueba que tenga un tamaño 10
                    if (textCaja.Text.Trim().Length == 10)
                    {
                        
                        //comprueba que sea numerico char x char
                        for (int x = 0; x <= textCaja.Text.Length - 1; x++)
                        {
                            if (!(char.IsDigit(textCaja.Text[x])))
                            {
                                lbCajaCorrecto = false;
                                lsMensaje = "Código incorrrecto";
                                break;
                            }
                        }


                        //busca si ya existe en la coleccion
                        caja = textCaja.Text;
                        if (lbCajaCorrecto)
                        {
                            if (BuscarEnColeccion(caja))
                            {
                                lbCajaCorrecto = false;
                                lsMensaje = "La caja ya existe";
                            }
                            //buscar en ztpp_logs
                            string lsCriterio = " WHERE EXIDV = " + textCaja.Text;
                            ClsZTPPLogsCollection colLogs = new ClsZTPPLogsBAL().ConsultarZTPPLogsBAL(lsCriterio);

                            if (colLogs.Count == 0)
                            {
                                lbCajaCorrecto = false;
                                lsMensaje = "El código " + textCaja.Text + " no existe en ZtppLogs";

                            }
                        }

                        

                        

                    }
                    else
                    {
                        //si  tiene > 10 digitos es un codigo se comprueba que sea codigo 2d
                        if (textCaja.Text.Substring(0, 1).Equals("H"))
                        {

                            divCodigo = new ClsDividirC();
                            //H8500000142|P134303C1|L0014399446|D24/04/2012|Q     30.0 |W0R00
                            //H8500000143|P134303C1|L0014399446|D24/04/2012|Q     30.0 |W0R00
                            //H8500000144|P134303C1|L0014399446|D24/04/2012|Q     30.0 |W0R00
                            //H8500000145|P134303C1|L0014399446|D24/04/2012|Q     30.0 |W0R00
                            string[] formatoC = { "H", "P", "L", "D", "Q", "W" };
                            if (divCodigo.DividirC(textCaja.Text, formatoC))
                            {
                                string centroCo = divCodigo.Centro;
                                caja = divCodigo.NumCaja;
                                if (BuscarEnColeccion(caja))
                                {
                                    lbCajaCorrecto = false;
                                    lsMensaje = "La caja ya existe";
                                }
                                else
                                {

                                    if ((textCentro.Text).Equals(centroCo))
                                    {

                                    }
                                    else
                                    {
                                        lbCajaCorrecto = false;
                                        lsMensaje = "El centro no coincide";
                                    }

                                }


                            }
                            else
                            {
                                lbCajaCorrecto = false;
                                lsMensaje = "Código incorrrecto";
                                textCaja.Text = Variables.Blanco;
                            }

                        }
                        else {
                            lbCajaCorrecto = false;
                            lsMensaje = "Código incorrrecto";
                            textCaja.Text = Variables.Blanco;
                        }
                    }
                    //aqui sale
                }

                if (lbCajaCorrecto == false)
                {
                    textCaja.SelectAll();
                    textCaja.Text = Variables.Blanco;
                    textCaja.Focus();
                    throw new Exception(lsMensaje);
                }
                else 
                {
                    
                    Agregar();
                    //AgregarACollection();
                    dgvLista.Rows.Add(caja);

                }
            }
            catch
            {
                throw;
            }

        }

        public Boolean BuscarEnColeccion(string codCaja) 
        {
            Boolean lbSeEncontro = false;
            IEnumerator lista = zCTCCollection.GetEnumerator();
            ClsZCTCBAL zCTCbal = new ClsZCTCBAL();
            while (lista.MoveNext())
            {
                ClsZCTC zCTC = (ClsZCTC)lista.Current;
                if (codCaja.Equals(zCTC.Caja))
                {
                    lbSeEncontro = true;                  
                    break;
                }
            }
            return lbSeEncontro;
        }

        public void EliminarDeColeccion() 
        {
            int liindex=0;
            string caja ="";
            liindex= dgvLista.CurrentCell.ColumnIndex;
            caja = dgvLista.Rows[liindex].Cells[0].Value.ToString();

            IEnumerator lista = zCTCCollection.GetEnumerator();
            
            while (lista.MoveNext())
            {

                ClsZCTC zCTC = (ClsZCTC)lista.Current;
                if((zCTC.Caja).Equals(caja))
                {
                    zCTCCollection.Remove(zCTC);
                    break;
                }
                
            }            
               
                dgvLista.CurrentRow.Visible = false;
                contador--;
                textTotalCajas.Text = "" + contador;
            
            
        }

        private void pctbxEliminar_MouseClick(object sender, MouseEventArgs e)
        {
            if(contador!=0)
            {                
                EliminarDeColeccion();
            }            
        }

        private void FrmZPPG27_Activated(object sender, EventArgs e)
        {
            textCentro.Focus();
        }

      

        public void Agregar()
        {

            for(int i=0; i<contador;i++)
            {
                if ((dgvLista.Rows[i].Cells[0].Value.ToString()).Equals(caja))
                {
                    textCaja.SelectAll();
                    textCaja.Text = Variables.Blanco;
                    textCaja.Focus();
                    string lsMensaje = "La caja ya fue escaneada";
                    throw new Exception(lsMensaje);   
                }  
            }
                    
            DateTime fecha = DateTime.Now;
            ClsZCTC zCTC = new ClsZCTC();
            string lsCriterio = "";
            zCTC.Werks = textCentro.Text;
            zCTC.Lgort = textAlmacen.Text;
            zCTC.Caja = caja;
            zCTC.FechaTraslado = fecha;
            zCTC.HoraTraslado = fecha;
            lsCriterio = "WHERE  CAJA = '" + caja + "'";
            ClsZCTCCollection zCTCColeccionTemp;
            zCTCColeccionTemp = (new ClsZCTCBAL()).ConsultarZCTCBAL(lsCriterio);
            zCTC.CantidadMovimientos = zCTCColeccionTemp.Count + 1;
            contador++;
            textTotalCajas.Text = "" + contador;
            ClsZCTCBAL balZctc = new ClsZCTCBAL();
            balZctc.AgregarZCTCBAL(zCTC);
        }

        private void FrmZPPG27_KeyUp(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.Enter)
            {                
                    try
                    {
                        ValidarDatos();
                        textCentro.Text = textCentro.Text.ToUpper();
                        textAlmacen.Text = textAlmacen.Text.ToUpper();
                        base.MensajeApagar();

                        textCaja.Text = Variables.Blanco;
                        caja = Variables.Blanco;

                    }
                    catch (Exception ex)
                    {
                        base.MostrarError(ex.Message);
                    }
                
            }
        }


    }
}
