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
        static private bool validado = false;

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
            base.RevisaEstado();
            base.PonerTitulo("Contingencia Acceso Rápido");
            this.Text = Variables.NombreSistema;
            treeOpciones.Nodes[0].Expand();
            this.Text = Application.ProductName;
            try
            {
                if (!validado)
                {
                    ValidarUsuario();
                    validado = true;
                }
               // Inactivo();
                CrearArbol();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void CrearArbol()
        {
            string lsOpciones = ClsEntorno.usuarioActual.Opciones;
            string[] laOpciones = lsOpciones.Split('|');
            treeOpciones.Nodes.Clear();
            treeOpciones.Nodes.Add("Favoritos","Favoritos");
            //treeOpciones.Nodes["Favoritos"].FirstNode.Collapse();
            if (laOpciones[0] == "1")
            {
                treeOpciones.Nodes[0].Nodes.Add(Variables.OpZPPG01);
            }
            if (laOpciones[1] == "1")
            {
                treeOpciones.Nodes[0].Nodes.Add(Variables.OpZPPG02);
            }
            if (laOpciones[2] == "1")
            {
                treeOpciones.Nodes[0].Nodes.Add(Variables.OpZPPG03);
            }
            if (laOpciones[3] == "1")
            {
                treeOpciones.Nodes[0].Nodes.Add(Variables.OpZPPG05);
            }
            if (laOpciones[4] == "1")
            {
                treeOpciones.Nodes[0].Nodes.Add(Variables.OpZInterfaz);
            }
            if (laOpciones[5] == "1")
            {
                treeOpciones.Nodes[0].Nodes.Add(Variables.OpZPPG27);
            }
            if (laOpciones[6] == "1")
            {
                treeOpciones.Nodes[0].Nodes.Add(Variables.OpZMaster);
            }
            if (laOpciones[7] == "1")
            {
                treeOpciones.Nodes[0].Nodes.Add(Variables.OpTraslados);
            }
            if (laOpciones[8] == "1")
            {
                treeOpciones.Nodes[0].Nodes.Add(Variables.OpZWMG04);
            }
            if (laOpciones[9] == "1")
            {
                treeOpciones.Nodes[0].Nodes.Add(Variables.OpReporte);
            }
            if (laOpciones[10] == "1")
            {
                treeOpciones.Nodes[0].Nodes.Add(Variables.OpReimpresion);
            }
            if (laOpciones[11] == "1")
            {
                treeOpciones.Nodes[0].Nodes.Add(Variables.OpUsuarios);
            }
            if (laOpciones[12] == "1")
            {
                treeOpciones.Nodes[0].Nodes.Add(Variables.OpCatalogos);
            }

            treeOpciones.ExpandAll();
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
                this.Hide();
                //DownLoad.FrmLogin down = new DownLoad.FrmLogin();
                //down.ShowDialog();
                this.Show();
            }

            

            if (e.Node.Text == Variables.OpReimpresion)
            {
                this.Hide();
                FrmReimpresionEtiquetas reimpri = new FrmReimpresionEtiquetas();
                reimpri.ShowDialog();
                this.Show();
            }

            if (e.Node.Text == Variables.OpZWMG04)
            {
                this.Hide();
                FrmZwmg04 zwmg04 = new FrmZwmg04();
                zwmg04.ShowDialog();
                this.Show();
            }

            if (e.Node.Text == Variables.OpTraslados)
            {
                this.Hide();
                FrmTrasladosTarimas traslado = new FrmTrasladosTarimas();
                traslado.ShowDialog();
                this.Show();
            }

            if (e.Node.Text == Variables.OpZPPG03)
            {
                this.Hide();
                FrmEntradaZPPG03 zppg03 = new FrmEntradaZPPG03();
                zppg03.ShowDialog();
                this.Show();
            }

            if (e.Node.Text == Variables.OpZPPG02)
            {
                this.Hide();
                FrmZPPG02 zppg02 = new FrmZPPG02();
                zppg02.MensajeError = "";
                zppg02.ShowDialog();
                this.Show();
            }

            if (e.Node.Text == Variables.OpZPPG01)
            {
                this.Hide();
                FrmZPPG01Entrada zppg01 = new FrmZPPG01Entrada();
                zppg01.ShowDialog();
                this.Show();
            }

            if (e.Node.Text == Variables.OpZPPG05)
            {
                this.Hide();
                FrmZPPG05Entrada zppg05 = new FrmZPPG05Entrada();
                zppg05.ShowDialog();
                this.Show();

            }

            if (e.Node.Text == Variables.OpZPPG27)
            {
                this.Hide();
                FrmZPPG27 zppg27 = new FrmZPPG27();
                zppg27.ShowDialog();
                this.Show();

            }

            if (e.Node.Text == Variables.OpZMaster)
            {
                this.Hide();
                FrmZMASTERMenu zmaster = new FrmZMASTERMenu();
                zmaster.ShowDialog();
                this.Show();

            }

            if (e.Node.Text == Variables.OpReporte)
            {
                this.Hide();
                FrmMonitorEntregas monitorEntregas = new FrmMonitorEntregas();
                //monitorEntregas.MdiParent = this;
                monitorEntregas.ShowDialog();
                this.Show();

            }

            if (e.Node.Text == Variables.OpZInterfaz)
            {
                this.Hide();
                FrmHUProcesarEntrada huProcesarEntrada = new FrmHUProcesarEntrada();
                huProcesarEntrada.ShowDialog();
                this.Show();

            }

            if (e.Node.Text == Variables.OpUsuarios)
            {
                this.Hide();
                FrmAdmoUsuarios usuarios = new FrmAdmoUsuarios();
                usuarios.ShowDialog();
                this.Show();
            }

            if (e.Node.Text == Variables.OpCatalogos)
            {
                this.Hide();
                FrmCatalagos Catalagos = new FrmCatalagos();
                Catalagos.ShowDialog();
                this.Show();
            }
        }      
    }
}