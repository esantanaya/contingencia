using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DownLoad
{
    public partial class FrmstarUp : Form
    {
        public FrmstarUp()
        {
            InitializeComponent();
        }

        private void FrmstarUp_Load(object sender, EventArgs e)
        {
            IniciarRFC();
            IniciarIp();
        }

        private void FrmstarUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            IniciarRecartera();
        }

        private void IniciarRecartera()
        {
            DialogResult resultado;
            bool lbCorrecto = true;
            string lsMensaje = "¿Al detener el sistema de Recartera se actualizará la base de datos de SAP, desea continuar?";
            resultado = MessageBox.Show(lsMensaje,"Download Recartera",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (resultado != DialogResult.Yes)
            {
                return;
            }
            //Analizar RFC
            for (int liCont = 0; liCont < dgvRfc.Rows.Count; liCont++)
            {
                if (dgvRfc["NombreRFC", liCont].Value != null)
                {
                    string lsRFC = dgvRfc["NombreRFC", liCont].Value.ToString();
                    if (lsRFC.StartsWith("R") == false)
                    {
                        dgvRfc["Estado", liCont].Value = "Error...";
                        dgvRfc.Rows[liCont].DefaultCellStyle.BackColor = Color.LightSalmon;
                        lbCorrecto = false;
                    }
                    else
                    {
                        dgvRfc["FechaActualizacion", liCont].Value = DateTime.Now;
                        dgvRfc["Estado", liCont].Value = "SAP actualizado";
                        dgvRfc.Rows[liCont].DefaultCellStyle.BackColor = Color.LightGreen;

                    }
                }
            }
            //Comenzar a analizar IP por IP
            for (int liCont = 0; liCont < dgvEquipos.Rows.Count; liCont++)
            {
                if (dgvEquipos["IpEquipo", liCont].Value != null)
                {
                    string lsIp = dgvEquipos["IpEquipo", liCont].Value.ToString();
                    if (lsIp.StartsWith("101"))
                    {
                        dgvEquipos["Comunicacion", liCont].Value = "Correcto";
                        dgvEquipos["Comunicacion", liCont].Tag = "C";
                        dgvEquipos["ArchivoTexto", liCont].Value = "Correcto";
                        dgvEquipos["AccesoSap", liCont].Value = "Concedido";
                        dgvEquipos["AccesoRecartera", liCont].Value = "Denegado";
                        dgvEquipos.Rows[liCont].DefaultCellStyle.BackColor = Color.LightGreen;


                    }
                    else
                    {
                        dgvEquipos["Comunicacion", liCont].Value = "Error...";
                        dgvEquipos["Comunicacion", liCont].Tag = "E";
                        dgvEquipos["ArchivoTexto", liCont].Value = "Error...";
                        dgvEquipos["AccesoSap", liCont].Value = "Error...";
                        dgvEquipos["AccesoRecartera", liCont].Value = "Correcto";

                        dgvEquipos.Rows[liCont].DefaultCellStyle.BackColor = Color.LightSalmon;
                        lbCorrecto = false;
                    }
                }
            }
            if(lbCorrecto == true)
            {
                lblEstado.Text = "Sistema deshabilitado.";
                btnIniciar.Enabled = false;
            }

        }



        private void IniciarRFC()
        {
             
            dgvRfc.Rows.Clear();
            dgvRfc.Rows.Add("RFC SALIDA 1", DateTime.Now,"");
            dgvRfc.Rows.Add("RFC SALIDA 2", DateTime.Now, "");
            dgvRfc.Rows.Add("RFC SALIDA 3", DateTime.Now, "");
            dgvRfc.Rows.Add("RFC SALIDA 4", DateTime.Now, "");
            dgvRfc.Rows.Add("RFC SALIDA 5", DateTime.Now, "");
            dgvRfc.Rows.Add("RFC SALIDA 6", DateTime.Now, "");
        }

        private void IniciarIp()
        {
            dgvEquipos.Rows.Clear();
            dgvEquipos.Rows.Add("101.168.10.101");
            dgvEquipos.Rows.Add("101.168.10.102");
            dgvEquipos.Rows.Add("101.168.10.103");
            dgvEquipos.Rows.Add("101.168.10.104");
            dgvEquipos.Rows.Add("101.168.10.105");
            dgvEquipos.Rows.Add("101.168.10.106");
            dgvEquipos.Rows.Add("101.168.10.107");
            dgvEquipos.Rows.Add("101.168.10.108");
            dgvEquipos.Rows.Add("101.168.10.109");
            dgvEquipos.Rows.Add("101.168.10.110");
            dgvEquipos.Rows.Add("101.168.10.111");
            dgvEquipos.Rows.Add("101.168.10.112");
        }

        private void spcPrincipal_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}