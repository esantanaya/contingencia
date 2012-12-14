using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            tslEstadoImagen.BackColor = Color.Red;
            tslEstadoDescripcion.Text = psMensaje;
        }

        protected void MostrarMensaje(string psMensaje)
        {
            tslEstadoImagen.BackColor = Color.Green;
            tslEstadoDescripcion.Text = psMensaje;
        }

        protected void MensajeApagar()
        {
            tslEstadoImagen.BackColor = this.BackColor; ;
            tslEstadoDescripcion.Text = "";
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

        

        private void pnlBase_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textAcceso_TextChanged(object sender, EventArgs e)
        {
            MensajeApagar();
        }
    }
}