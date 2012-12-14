using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;


namespace Contingencia
{
    public partial class FrmCatalagos : FrmBase
    {


        public FrmCatalagos()
        {
            InitializeComponent();

            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnConsultar.Enabled = false;
        }


        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter sqlDA = new SqlDataAdapter();
      
        private string sql = null;
        private string criterio = null;


        private void GetData(string sql)
        {
            string baseDatos = Variables.Nulo;
            string usuarioBase = Variables.Nulo;
            string passwordBase = Variables.Nulo;
            string cadena = Variables.Nulo;

            try
            {
                baseDatos = ClsFunciones.ObtenerValorEntorno(Variables.Servidor);
                usuarioBase = ClsFunciones.ObtenerValorEntorno(Variables.UsuarioBd);
                passwordBase = ClsFunciones.ObtenerValorEntorno(Variables.PasswordBd);
                string conexion = "Server=" + baseDatos + ";Database=KekenDB;user id=" + usuarioBase + "; password=Sql" + passwordBase;

                //string conexion = "Server=VCSALGADO\\SQLEXPRESS;Database=KekenBD;user id=sa; password=SqlMisato";
                
                sqlDA = new SqlDataAdapter(sql, conexion);

                SqlCommandBuilder sqlCB = new SqlCommandBuilder(sqlDA);

                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                sqlDA.Fill(table);
                bindingSource1.DataSource = table;


                dgvRegistros.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                //dataGridView1.DataSourc
                //dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Conexion " + ex.Message);
            }
        
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                sql = "Select * from " + criterio;

                dgvRegistros.DataSource = bindingSource1;
                GetData(sql);

                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;
                MensajeApagar();
                Application.DoEvents();
                PerformLayout();
                PonerTitulo("Administración de Catálogos, editando " + treeCatalogos.SelectedNode.Text);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            
        }

        


        private void Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarMensaje("Cargando registros");
                PerformLayout();
                Cursor.Current = Cursors.WaitCursor;
                sqlDA.Update((DataTable)bindingSource1.DataSource);
                MostrarMensaje("Catálogo actualizado.");
                //Thread.Sleep(3000);
                //MensajeApagar();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MostrarError(ex.Message);
                PerformLayout();
                //Thread.Sleep(3000);
                //MensajeApagar();

            }
        }


    private void btnEliminar_Click(object sender, EventArgs e)
        {
            int i = dgvRegistros.CurrentRow.Index;

            DialogResult result = MessageBox.Show("Desea Borrar el Registro?", "Salir", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                dgvRegistros.Rows.RemoveAt(i);

                sqlDA.Update((DataTable)bindingSource1.DataSource);
            }
            else if (result == DialogResult.No)
            {

            }    
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "KNA1")
            {
                criterio = "KNA1";
            }
            else if (e.Node.Text == "LCVS")
            {
                criterio = "LCVS";
            }
            else if (e.Node.Text == "LIKP")
            {
                criterio = "LIKP";
            }
            else if (e.Node.Text == "LIPS")
            {
                criterio = "LIPS";
            }
            else if (e.Node.Text == "MARA")
            {
                criterio = "MARA";
            }
            else if (e.Node.Text == "OPCS")
            {
                criterio = "OPCS";
            }
            else if (e.Node.Text == "OPMS")
            {
                criterio = "OPMS";
            }
            else if (e.Node.Text == "PLPO")
            {
                criterio = "PLPO";
            }
            else if (e.Node.Text == "RESB")
            {
                criterio = "RESB";
            }
            else if (e.Node.Text == "UBICACIONES")
            {
                criterio = "UBICACIONES";
            }
            else if (e.Node.Text == "WERKS_D")
            {
                criterio = "WERKS_D";
            }
            else if (e.Node.Text == "Z_CAT")
            {
                criterio = "Z_CAT";
            }
            else if (e.Node.Text == "Z_CTC")
            {
                criterio = "Z_CTC";
            }
            else if (e.Node.Text == "Z_CTE")
            {
                criterio = "Z_CTE";
            }
            else if (e.Node.Text == "Z_MACHINE")
            {
                criterio = "Z_MACHINE";
            }
            else if (e.Node.Text == "ZBASCULAS")
            {
                criterio = "ZBASCULAS";
            }
            else if (e.Node.Text == "ZMASTER")
            {
                criterio = "ZMASTER";
            }
            else if (e.Node.Text == "ZPPCALIDAD")
            {
                criterio = "ZPPCALIDAD";
            }
            else if (e.Node.Text == "ZPPCANALFIN")
            {
                criterio = "ZPPCANALFIN";
            }
            else if (e.Node.Text == "ZPPDESTINO")
            {
                criterio = "ZPPDESTINO";
            }
            else if (e.Node.Text == "ZPPFATOM")
            {
                criterio = "ZPPFATOM";
            }
            else if (e.Node.Text == "ZPPTRASPCALIDAD")
            {
                criterio = "ZPPTRASPCALIDAD";
            }
            else if (e.Node.Text == "ZTPP_GRUPOEMP")
            {
                criterio = "ZTPP_GRUPOEMP";
            }
            else if (e.Node.Text == "ZTPP_GRUPOMAT")
            {
                criterio = "ZTPP_GRUPOMAT";
            }
            else if (e.Node.Text == "ZTPP_LOGS")
            {
                criterio = "ZTPP_LOGS";
            }
            else if (e.Node.Text == "ZTPPLGORT")
            {
                criterio = "ZTPPLGORT";
            }
            else if (e.Node.Text == "ZTTP_TRAZABI")
            {
                criterio = "ZTTP_TRAZABI";
            }

            btnConsultar.Enabled= true;

        }

       

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pnlBase_Paint(object sender, PaintEventArgs e)
        {
            base.PonerTitulo("Administración de Catálogos");
        }

        private void BuscarClave()
        {

            int contador = 0;

            string claveActual = Variables.N;

            for (contador = 0; contador <= this.dgvRegistros.RowCount - 1; contador++)
            {
                string texto = txtbxBuscar.Text.ToString().Trim().ToUpper();
                try
                {
                    claveActual = dgvRegistros.Rows[contador].Cells[dgvRegistros.CurrentCell.ColumnIndex].Value.ToString();

                    if (claveActual.StartsWith(texto))
                    {
                        
                        dgvRegistros.FirstDisplayedScrollingRowIndex = contador;
                        /*dgvRegistros.CurrentCell = dgvRegistros.FIR;
                        dgvRegistros.CurrentCell.Selected = true;*/

                        //CargarRenglon();

                        break;

                    }
                }
                catch 
                {

                    break;
                }

            }

        }

        private void textBuscar_KeyUp(object sender, EventArgs e)
        {
            BuscarClave();
        }

    }
}
