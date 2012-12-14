using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Threading;

namespace Contingencia
{
    public partial class FrmHUProcesarEntrada : FrmBase
    {

        private string setteoBascula = "";

        public FrmHUProcesarEntrada()
        {
            InitializeComponent();
        }

                
        

        private void textCentro_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textCentro);
        }

        private void textCentro_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(textCentro);
        }

        
        private void picCentros_Click(object sender, EventArgs e)
        {
            ConsultarCentros();
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
                textCentro.Text = lsClave.ToUpper();
                string lsDesc = listaSeleccion.DescSel;
                textNombreCentro.Text = lsDesc;
            }


        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            ValidarYProcesar();
        }

        private void ValidarYProcesar() 
        {
            string lsCriterio;
            
            try
            {
                ValidarDatos();
                FrmHuInterfazCaja huInterfazCaja;
                
                CLSCatCentro centro;
                lsCriterio = "WHERE WERKS = '" + textCentro.Text.ToUpper() + "'";
                CLSCatCentroCollection centros;
                centros = new CLSCatCentroBAL().MostrarCatCentroBAL(lsCriterio);
                centro = centros[0];
                if (MessageBox.Show("Estas seguro de entrar con centro " + centro.DescCentro, "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    huInterfazCaja = new FrmHuInterfazCaja();
                    huInterfazCaja.IdCentro = textCentro.Text.ToUpper();
                    huInterfazCaja.NombreCentro = textNombreCentro.Text.ToUpper();
                    huInterfazCaja.NombreBascula = textBascula.Text.ToUpper();
                    huInterfazCaja.SetteoBascula = setteoBascula.ToUpper();
                    
                    if (((textBascula.Text).ToUpper()).Equals("MANUAL"))
                    {
                        huInterfazCaja.textPesoBruto.ReadOnly = false;
                    }
                    else
                    {
                        huInterfazCaja.textPesoBruto.ReadOnly = true;
                    }
                    
                    huInterfazCaja.InciarForma();
                    huInterfazCaja.ShowDialog();
                   
                }
                else
                {
                    textCentro.Text = textCentro.Text.ToUpper();
                    textImpresora.Text = textImpresora.Text.ToUpper();
                    textBascula.Text = textBascula.Text.ToUpper();
                    textNombreCentro.Text = centro.DescCentro;

                }

                

            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }

        private void ValidarDatos()
        {
            bool lbCentroCorrecto = true;
            bool lbBasculaCorrecto = true;
            bool lbInpresoraCorrecto = true;
            string lsMensaje = "";
            string criterio;
            try
            {
                if (textCentro.Text.Trim().Length == 0)
                {
                    lbCentroCorrecto = false;
                }

                criterio = "WHERE WERKS = '" + textCentro.Text.ToUpper() + "'";
                CLSCatCentroCollection centrosColeccion;
                centrosColeccion = (new CLSCatCentroBAL()).MostrarCatCentroBAL(criterio);

                if (centrosColeccion.Count == 0)
                {
                    lbCentroCorrecto = false;
                }
                else {
                    textNombreCentro.Text = centrosColeccion[0].DescCentro;
                }             
                if (lbCentroCorrecto == false)
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


            try
            {
                if (textImpresora.Text.Trim().Length == 0)
                {
                    lbInpresoraCorrecto = false;
                }

                PrintDocument printDocument = new PrintDocument();
                string strPrinter;
                IEnumerator impresorasInstaladas = PrinterSettings.InstalledPrinters.GetEnumerator();

                //impresoras.Items.Add("Ninguna");
                lbInpresoraCorrecto = false;
                while (impresorasInstaladas.MoveNext())
                {
                    strPrinter = (impresorasInstaladas.Current.ToString()).ToUpper();
                    if (strPrinter.Equals((textImpresora.Text).ToUpper())) 
                    {
                        lbInpresoraCorrecto = true;
                        break;
                    }
                    
                }

                if (lbInpresoraCorrecto == false)
                {
                    textImpresora.SelectAll();
                    lsMensaje = "No existe la Impresora";
                    textImpresora.Focus();
                    throw new Exception(lsMensaje);
                }
            }
            catch
            {
                throw;
            }


            try
            {
                if (textBascula.Text.Trim().Length == 0)
                {
                    lbBasculaCorrecto = false;
                }
                //if (textBascula.Text.Trim().StartsWith("0") == false)
                criterio = "WHERE MODELO = '" + textBascula.Text + "'";
                ClsZBasculasCollection basculasColeccion;
                basculasColeccion = (new ClsZBasculasBAL()).ConsultarZBasculasBAL(criterio);

                if (basculasColeccion.Count == 0)
                {
                    lbBasculaCorrecto = false;
                }
                if (lbBasculaCorrecto == false)
                {
                    textBascula.SelectAll();
                    lsMensaje = "No existe la báscula";
                    textBascula.Focus();
                    throw new Exception(lsMensaje);
                }
            }
            catch
            {
                throw;
            }

            

        }

        private void picBasculas_Click(object sender, EventArgs e)
        {
            ConsutarBasculas();
        }

        private void ConsutarBasculas()
        {
            DialogResult resultado;
            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            listaSeleccion.TipoCatalogo = "BASCULA";
            listaSeleccion.IniciarForma();
            resultado = listaSeleccion.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                string lsClave = listaSeleccion.ClaveSel;
                string lsSetteo = listaSeleccion.DescSel;
                textBascula.Text = lsClave;
                setteoBascula = lsSetteo;
            }
 
        }

        private void ConsutarImpresoras()
        {
            DialogResult resultado;
            FrmListaSeleccion listaSeleccion = new FrmListaSeleccion();
            listaSeleccion.TipoCatalogo = "IMPRESORA";
            listaSeleccion.IniciarForma();
            resultado = listaSeleccion.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                string lsClave = listaSeleccion.ClaveSel;
                textImpresora.Text = lsClave;



            }

        }

        private void FrmHUProcesarEntrada_Activated(object sender, EventArgs e)
        {
            textCentro.Focus();
        }

        private void textBascula_Enter(object sender, EventArgs e)
        {
            base.TextoColorEdicionOn(textBascula);
        }

        private void textBascula_Leave(object sender, EventArgs e)
        {
            base.TextoColorEdicionOff(textBascula);
        }

        private void textBascula_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.MensajeApagar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void textNombreCentro_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ConsutarImpresoras();
        }

        private void textImpresora_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBascula_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       public string  GetImpresoraDefecto()
        {
            for (int i = 0; i <PrinterSettings.InstalledPrinters.Count; i++)
            {
                PrinterSettings a = new PrinterSettings();
                a.PrinterName = PrinterSettings.InstalledPrinters[i].ToString();
                if (a.IsDefaultPrinter)
                {
                   return   PrinterSettings.InstalledPrinters[i].ToString();

                }
            }
            return "No hay impresora Predeterminada";
        }

       public string PredeterminarImpresora()
       {
           for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
           {
               PrinterSettings a = new PrinterSettings();
               a.PrinterName = PrinterSettings.InstalledPrinters[i].ToString();
               if (a.IsDefaultPrinter)
               {
                   return PrinterSettings.InstalledPrinters[i].ToString();

               }
           }
           return "No hay impresora Predeterminada";
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


       public void AutocompletarImpresoras()
       {
           AutoCompleteStringCollection datos = new AutoCompleteStringCollection();

           PrintDocument printDocument = new PrintDocument();
           string strPrinter;
           IEnumerator impresorasInstaladas = PrinterSettings.InstalledPrinters.GetEnumerator();

           //impresoras.Items.Add("Ninguna");

           while (impresorasInstaladas.MoveNext())
           {
               strPrinter = impresorasInstaladas.Current.ToString();
               datos.Add(strPrinter);
           }

           textImpresora.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           textImpresora.AutoCompleteSource = AutoCompleteSource.CustomSource;
           textImpresora.AutoCompleteCustomSource = datos;
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

           textBascula.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           textBascula.AutoCompleteSource = AutoCompleteSource.CustomSource;
           textBascula.AutoCompleteCustomSource = datos;
       }

       private void FrmHUProcesarEntrada_Load(object sender, EventArgs e)
       {
           base.PonerTitulo("ATENCIÓN!!! Procesa solo movimientos con HU");
           AutocompletarCentros();
           AutocompletarImpresoras();
           AutocompletarBasculas();
           textImpresora.Text = GetImpresoraDefecto();
       }

       private void textImpresora_Enter(object sender, EventArgs e)
       {
           base.TextoColorEdicionOn(textImpresora);
       }

       private void textImpresora_Leave(object sender, EventArgs e)
       {
           base.TextoColorEdicionOff(textImpresora);
       }

      

      

       private void FrmHUProcesarEntrada_KeyUp(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Enter)
           {
               try
               {
                   ValidarDatos();
                   btnContinuar.Focus();
               }
               catch (Exception ex)
               {
                   base.MostrarError(ex.Message);
               }
           }
           else if (e.KeyCode == Keys.F8)
           {
               ValidarYProcesar();
           }
       }

    
    }
}