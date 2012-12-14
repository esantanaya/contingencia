using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contingencia
{
    public partial class FrmPrincipal : FrmBase
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            try
            {
                ClsFunciones.ObtenerValoresConfiguracion();
                this.Text = Variables.NombreSistema;
            }
            catch (Exception ex)
            {
                base.MostrarError(ex.Message.ToString());
                Application.Exit();
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            base.PonerTitulo("Contingencia Acceso Rápido");
            treeOpciones.Nodes[0].Expand();
            this.Text = Application.ProductName;
            try
            {
                ValidarUsuario();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void ValidarUsuario()
        {
            DialogResult resultadoLogin;
            FrmLogin frmLogin = new FrmLogin();
            resultadoLogin = frmLogin.ShowDialog();
            if (resultadoLogin == DialogResult.Yes)
            {
                ClsEntorno.usuarioActual = frmLogin.UsuarioLogin;
                frmLogin.Close();

            }
            else
            {
                throw new Exception("Operación Cancelada");
            }
        }

        private void treeOpciones_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            if (e.Node.Text == "Shut Down")
            {
                //this.Hide();
                //DownLoad.FrmLogin down = new DownLoad.FrmLogin();
                //down.ShowDialog();
                //this.Show();
            }

            if (e.Node.Text == "Start Up")
            {
                //this.Hide();
                //StartUpSU.FrmLogin login = new StartUpSU.FrmLogin();
                //login.ShowDialog();
                //this.Show();
            }

            if (e.Node.Text == "Reimpresion Etiquetas")
            {
                this.Hide();
                //FrmReimpresionEtiquetas reimpri = new FrmReimpresionEtiquetas();
                //reimpri.ShowDialog();
                this.Show();
            }
            
            if (e.Node.Text == "ZWMG04")
            {
                this.Hide();
                //FrmZwmg04 zwmg04 = new FrmZwmg04();
                //zwmg04.ShowDialog();
                this.Show();
            }

            if (e.Node.Text == "ZTRASLADOS")
            {
                this.Hide();
                //FrmTrasladosTarimas traslado = new FrmTrasladosTarimas();
                //traslado.ShowDialog();
                this.Show();
            }

            if (e.Node.Text == "ZPPG03 Pesado de Cabeza")
            {
                this.Hide();
                //FrmZPPG03 zppg03 = new FrmZPPG03();
                //zppg03.ShowDialog();
                this.Show();
            }

            if (e.Node.Text == "ZPPG02 Proceso de Selección de Destino")
            {
                this.Hide();
                //FrmZPPG02 zppg02 = new FrmZPPG02();
                //zppg02.ShowDialog();
                this.Show();
            }

            if (e.Node.Text == "ZPPG01 Fatometer")
            {
                this.Hide();
                FrmZPPG01Entrada zppg01 = new FrmZPPG01Entrada();
                zppg01.ShowDialog();
                this.Show();
            }

            if (e.Node.Text == "ZPPG05 Pesado para canal de Corte y Venta")
            {
                this.Hide();
                //FrmZPPG05Entrada zppg05 = new FrmZPPG05Entrada();
                //zppg05.ShowDialog();
                this.Show();

            }

            if (e.Node.Text == "ZPPG27 Estación de Traslado de Cajas")
            {
                this.Hide();
                //FrmZPPG27 zppg27 = new FrmZPPG27();
                //zppg27.ShowDialog();
                this.Show();

            }

            if (e.Node.Text == "ZMASTER")
            {
                this.Hide();
                //FrmZMASTERMenu zmaster = new FrmZMASTERMenu();
                //zmaster.ShowDialog();
                this.Show();

            }

            if (e.Node.Text == "Reporte de Entregas")
            {
                this.Hide();
                //FrmMonitorEntregas monitorEntregas = new FrmMonitorEntregas();
                ////monitorEntregas.MdiParent = this;
                //monitorEntregas.ShowDialog();
                this.Show();

            }
            if (e.Node.Text == "Z Interfaz HU Pesado de Cajas")
            {
                this.Hide();
                //FrmHUProcesarEntrada huProcesarEntrada = new FrmHUProcesarEntrada();
                //huProcesarEntrada.ShowDialog();
                this.Show();

            }
        }

        private void treeOpciones_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }  
    }
}