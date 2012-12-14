using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Contingencia
{
    public partial class FrmBase : Form
    {
        public FrmBase()
        {
            InitializeComponent();
            IniciarBase();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IniciarBase()
        {
            MensajeApagar();
            PonerTitulo("");
        }

        protected void MostrarError(string psMensaje)
        {
            int liMax = psMensaje.Length * 5;
            tslEstadoImagen.Width = 0;
            tslEstadoDescripcion.Text = "";
            tslEstadoImagen.BackColor = Color.Red;
            
            for (int liCont = 0; liCont < liMax; liCont++)
            {
                Thread.Sleep(4);
                tslEstadoImagen.Width = liCont;
                Application.DoEvents();
                PerformLayout();
            }
            Thread.Sleep(4);
            tslEstadoImagen.Width = 15;
            Application.DoEvents();
            PerformLayout();
            tslEstadoDescripcion.Text = psMensaje;
        }

        protected void MostrarAdvertencia(string psMensaje)
        {

            int liMax = psMensaje.Length * 5;
            tslEstadoImagen.Width = 0;
            tslEstadoDescripcion.Text = "";
            tslEstadoImagen.BackColor = Color.Yellow;

            for (int liCont = 0; liCont < liMax; liCont++)
            {
                Thread.Sleep(4);
                tslEstadoImagen.Width = liCont;
                Application.DoEvents();
                PerformLayout();
            }
            Thread.Sleep(4);
            tslEstadoImagen.Width = 15;
            Application.DoEvents();
            PerformLayout();
            tslEstadoDescripcion.Text = psMensaje;
        }

        protected void MostrarMensaje(string psMensaje)
        {
            int liMax = psMensaje.Length * 5;
            tslEstadoImagen.Width = 0;
            tslEstadoDescripcion.Text = "";
            tslEstadoImagen.BackColor = Color.Green;

            for (int liCont = 0; liCont < liMax; liCont++)
            {
                Thread.Sleep(4);
                tslEstadoImagen.Width = liCont;
                Application.DoEvents();
                PerformLayout();
            }
            Thread.Sleep(4);
            tslEstadoImagen.Width = 15;
            Application.DoEvents();
            PerformLayout();
            tslEstadoDescripcion.Text = psMensaje;
        }

        protected void MensajeApagar()
        {
            tslEstadoImagen.BackColor = this.BackColor;
            tslEstadoImagen.Width = 0;
            tslEstadoDescripcion.Text = "";
            Application.DoEvents();
            PerformLayout();
        }

        protected void PonerTitulo(string psMensaje)
        {
            lblTitulo.Text = psMensaje;
        }

        private void toolBase_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void picInstancia_Click(object sender, EventArgs e)
        {
            FrmPrincipal frmPricipal = new FrmPrincipal();
            frmPricipal.Show();
        }

        private void FrmBase_Load(object sender, EventArgs e)
        {
            this.Text = Variables.NombreSistema;
        }

        protected void TextoColorEdicionOn(TextBox obTexto)
        {
            obTexto.BackColor = Color.Gold;
        }

        protected void TextoColorEdicionOff(TextBox obTexto)
        {
            obTexto.BackColor = Color.White;
        }

        protected void MostrarForma()
        {
            this.Show();
        }

        private void picEnter_Click(object sender, EventArgs e)
        {
            BuscarForma(textAcceso.Text);
        }

        private void textAcceso_PressEnter(object sender, EventArgs e)
        {
            BuscarForma(textAcceso.Text);
        }

        protected void BuscarForma(string cadena) { 
            
            try {

                cadena = cadena.ToUpper();
                FrmPrincipal principal = new FrmPrincipal();
                bool flag = false;

                if(cadena.Trim().Length == 0) {
                    flag = true;
                    MostrarError("El campo se encuentra vacio");
                }

                if(cadena == "ZPPG01") {
                    flag = true;
                    this.Hide();
                    //FrmZPPG01Entrada zppg01 = new FrmZPPG01Entrada();
                    //zppg01.ShowDialog();
                    this.Show();
                }

                if (cadena == "ZPPG02")
                {
                    flag = true;
                    this.Hide();
                    //FrmZPPG02 zppg02 = new FrmZPPG02();
                    //zppg02.ShowDialog();
                    this.Show();
                }

                if (cadena == "ZPPG03")
                {
                    flag = true;
                    this.Hide();
                    //FrmZPPG03 zppg03 = new FrmZPPG03();
                    //zppg03.ShowDialog();
                    this.Show();
                }

                if (cadena == "ZPPG05")
                {
                    flag = true;
                    this.Hide();
                    //FrmZPPG05Entrada zppg05 = new FrmZPPG05Entrada();
                    //zppg05.ShowDialog();
                    this.Show();
                }

                if (cadena == "ZINTERFAZHU")
                {
                    flag = true;
                    this.Hide();
                    //FrmHUProcesarEntrada hu = new FrmHUProcesarEntrada();
                    //hu.ShowDialog();
                    this.Show();
                }

                if (cadena == "ZPPG27")
                {
                    flag = true;
                    this.Hide();
                    //FrmZPPG27 zppg27 = new FrmZPPG27();
                    //zppg27.ShowDialog();
                    this.Show();
                }

                if (cadena == "ZMASTER")
                {
                    flag = true;
                    this.Hide();
                    //FrmZMASTERMenu menu = new FrmZMASTERMenu();
                    //menu.ShowDialog();
                    this.Show();
                }

                if (cadena == "ZMASTER")
                {
                    flag = true;
                    this.Hide();
                    //FrmZMASTERMenu menu = new FrmZMASTERMenu();
                    //menu.ShowDialog();
                    this.Show();
                }

                if (cadena == "ZTRASLADOS")
                {
                    flag = true;
                    this.Hide();
                    //FrmTrasladosTarimas tras = new FrmTrasladosTarimas();
                    //tras.ShowDialog();
                    this.Show();
                }

                if (cadena == "ZWMG04")
                {
                    flag = true;
                    this.Hide();
                    //FrmZwmg04 zwmg04 = new FrmZwmg04();
                    //zwmg04.ShowDialog();
                    this.Show();
                }

                if(flag == false) {
                    MostrarError("Ingresa un código válido");
                }
            }
            catch(Exception ex) {
                MostrarError(ex.Message);
            }
        }        

        private void textAcceso_TextChanged(object sender, EventArgs e)
        {
            MensajeApagar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmPrincipal frmPricipal = new FrmPrincipal();
            frmPricipal.Show();
        }

        private void AccederOpciones()
        {
            string cadena = textAcceso.Text.ToUpper();
            string lsOpciones = ClsEntorno.usuarioActual.Opciones;
            string[] laOpciones = lsOpciones.Split('|');

            if (cadena.Equals("ZPPG01"))
            {
                if (laOpciones[0] == "1")
                {
                    FrmZPPG01Entrada zppg01 = new FrmZPPG01Entrada();
                    zppg01.Show();
                }
            }
            if (cadena.Equals("ZPPG02"))
            {
                if (laOpciones[1] == "1")
                {
                    FrmZPPG02 zppg02 = new FrmZPPG02();
                    zppg02.Show(); 
                }
            }
            if (cadena.Equals("ZPPG03"))
            {
                if (laOpciones[2] == "1")
                {
                    FrmEntradaZPPG03 zppg03 = new FrmEntradaZPPG03();
                    zppg03.Show(); 
                }
            } 
            if (cadena.Equals("ZPPG05"))
            {
                if (laOpciones[3] == "1")
                {
                    FrmZPPG05Entrada zppg05 = new FrmZPPG05Entrada();
                    zppg05.Show(); 
                }
            }
            if (cadena.Equals("ZPPG27"))
            {
                if (laOpciones[5] == "1")
                {
                    FrmZPPG27 zppg27 = new FrmZPPG27();
                    zppg27.Show(); 
                }
            }
            if (cadena.Equals("ZINTERFAZHU"))
            {
                if (laOpciones[4] == "1")
                {
                    FrmHUProcesarEntrada interfaz = new FrmHUProcesarEntrada();
                    interfaz.Show(); 
                }
            }
            if (cadena.Equals("ZMASTER"))
            {
                if (laOpciones[6] == "1")
                {
                    FrmZMASTERMenu master = new FrmZMASTERMenu();
                    master.Show(); 
                }
            }
            if (cadena.Equals("ZTRASLADOS"))
            {
                if (laOpciones[7] == "1")
                {
                    FrmTrasladosTarimas traslado = new FrmTrasladosTarimas();
                    traslado.Show(); 
                }
            }
        }

        private void picInstancia_Click_1(object sender, EventArgs e)
        {
            AccederOpciones();
        }

        private void textAcceso_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                AccederOpciones();
            }
        }

        private void poleoContingencia_Tick(object sender, EventArgs e)
        {
            RevisaEstado();
        }

        public void RevisaEstado()
        {
            CLSRFC estado = new CLSRFC();
            estado.ObtenerEstado();
            if (estado.Estado.Equals("D"))
            {
                MessageBox.Show("Se ha detectado que el Sistema de Contingencia se encuentra deshabilitado, imposible continuar con la aplicaión!");
                Application.Exit();
            }
        }
    }
}