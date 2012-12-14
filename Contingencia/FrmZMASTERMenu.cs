using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Contingencia
{
    public partial class FrmZMASTERMenu : FrmBase
    {
        public FrmZMASTERMenu()
        {
            InitializeComponent();
        }

        private void FrmZMASTERMenu_Load(object sender, EventArgs e)
        {
            base.PonerTitulo("Menú Principal Etiqueta Master");
           
        }

        private void btnArmar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmArmadoTarimas armado = new FrmArmadoTarimas();
            armado.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDesembalar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDesembalar desemba = new FrmDesembalar();
            desemba.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            //FrmArmadoTarimas frmArmandoTarimas = new FrmArmadoTarimas();
            //frmArmandoTarimas.ShowDialog();
            /*FrmAgregarTarima agregarTarima = new FrmAgregarTarima();
            agregarTarima.ShowDialog();*/
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAgregarTarima_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAgregarTarima frmAgregaTarimas = new FrmAgregarTarima();
            frmAgregaTarimas.ShowDialog();
            
        }
    }
}
