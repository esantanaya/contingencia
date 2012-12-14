using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Collections; 

namespace Contingencia
{
    public partial class FrmAdmoUsuarios : FrmBase
    {
        ClsUsuariosBAL usuariosBAL = new ClsUsuariosBAL();
        ClsUsuarios selUsuario = new ClsUsuarios();
        string modo = "";
        bool iniciandoVista = false;

        public FrmAdmoUsuarios()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
                this.Dispose();
            }
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cBProgDataSet.IdUsuarios' Puede moverla o quitarla según sea necesario.
            IniciarObjetoControles();
            DGVUsuarios.Rows.Clear();
            CargarUsuarios();
            ConfigurarPaginacion();
            chkOpciones.Enabled = false;
            
            
        }

        private void CargarUsuarios()
        {
            ClsUsuariosCollection usuariosCollection;
           // int contador = 0;
            iniciandoVista = true;
            try
            {
                usuariosCollection = usuariosBAL.ConsultarUsuariosBAL("");

                if (usuariosCollection.Count > 0)
                {
                    IEnumerator listaUsuarios = usuariosCollection.GetEnumerator();
                    while (listaUsuarios.MoveNext())
                    {
                        ClsUsuarios currUsuario = (ClsUsuarios)listaUsuarios.Current;
                        DGVUsuarios.Rows.Add();
                        DGVUsuarios["Usuario", DGVUsuarios.RowCount - 1].Value = currUsuario.Usuario;
                        DGVUsuarios["Clave", DGVUsuarios.RowCount - 1].Value = currUsuario.Clave;
                        DGVUsuarios["Nombre", DGVUsuarios.RowCount - 1].Value = currUsuario.Nombre;
                        DGVUsuarios["Nivel", DGVUsuarios.RowCount - 1].Value = currUsuario.Nivel;
                        DGVUsuarios["Estado", DGVUsuarios.RowCount - 1].Value = currUsuario.Estado;
                        DGVUsuarios["FAlta", DGVUsuarios.RowCount - 1].Value = currUsuario.FAlta;
                        DGVUsuarios["Funciones", DGVUsuarios.RowCount - 1].Value = currUsuario.Opciones;
                    }
                }
                else
                {
                    MostrarMensaje("No hay registros a mostrar.");
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
            finally
            {
                iniciandoVista = false;
            }

        }

        private void HabilitarBotonesFunciones()
        {
            btnAgregar.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            btnRefrescar.Enabled = true;
            btnSalir.Enabled = true;
        }

        private void DeshabilitarBotonesFunciones()
        {
            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnRefrescar.Enabled = false;
            btnSalir.Enabled = false;
        }

        private void HabilitarBotonesGuardar()
        {
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void DeshabilitarBotonesGuardar()
        {
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void IniciarObjetoControles()
        {
            textUsuario.Text = "";
            textNombre.Text = "";
            // cmbNivel.Text = "";
            textClave.Text = "";
            textRecaptura.Text = "";
            cmbEstado.Text = "";
           // lblFMovto.Text = "";
            selUsuario.IniciarObjeto();
        }

        private string opciones;

        private void CargarObjetoDesdeForma()
        {

            opciones = Variables.Nulo;
            for (int x = 0; x <= chkOpciones.Items.Count - 1; x++)
            {
                if (chkOpciones.GetItemChecked(x) == true)
                {
                    opciones = opciones + "1|";
                }
                else
                {
                    opciones = opciones + "0|";
                }
            }

            selUsuario.Usuario = textUsuario.Text;
            selUsuario.Nombre = textNombre.Text;
            selUsuario.Clave = textClave.Text;
            selUsuario.Estado = ClsFunciones.ObtenerClaveCadena(cmbEstado.Text, Variables.CorcheteAbre, Variables.CorcheteCierra);
            selUsuario.FAlta = DateTime.Now;
            selUsuario.Opciones = opciones;
        }

        private void ConfigurarAlta()
        {
            DeshabilitarBotonesFunciones();
            HabilitarBotonesGuardar();
            textUsuario.Enabled = true;
            textNombre.Enabled = true;
            // cmbNivel.Enabled = false;
            // cmbNivel.SelectedIndex = 0;
            textClave.Enabled = true;
            cmbEstado.SelectedIndex = 0;
            cmbEstado.Enabled = true;
            label6.Visible = true;
            textRecaptura.Visible = true;
            textRecaptura.Enabled = true;
            DGVUsuarios.Enabled = false;
            IniciarObjetoControles();
            textUsuario.Focus();
            modo = Variables.Alta;
        }

        private void ConfigurarModificar()
        {
            if (textUsuario.Text.Length == 0)
            {
                MostrarMensaje("Registro inválido.");
                return;
            }
            DeshabilitarBotonesFunciones();
            HabilitarBotonesGuardar();
            textUsuario.Enabled = false;
            textNombre.Enabled = true;
            //  cmbNivel.Enabled = true;
            textClave.Enabled = true;
            cmbEstado.Enabled = false;
            textRecaptura.Visible = true;
            textRecaptura.Enabled = true;
            DGVUsuarios.Enabled = false;
            cmbEstado.Enabled = true;
            chkOpciones.Enabled = true;
            textNombre.Focus();
            modo = Variables.Modificar;
        }

        private void ConfigurarPaginacion()
        {
            DeshabilitarBotonesGuardar();
            HabilitarBotonesFunciones();
            textUsuario.Enabled = false;
            textNombre.Enabled = false;
            // cmbNivel.Enabled = false;
            cmbEstado.Enabled = false;
            label6.Visible = false;
            textRecaptura.Visible = false;
            textClave.Enabled = false;
            textRecaptura.Enabled = false;
            chkOpciones.Enabled = false;
            DGVUsuarios.Enabled = true;
        }

        

        private void GuardarRegistro(string psModo)
        {
            try
            {
                ValidarRegistro();
                //ValidarRecapturaClave();
                CargarObjetoDesdeForma();
                if (psModo == Variables.Alta)
                {
                    usuariosBAL.AgregarUsuarioBAL(selUsuario);
                    InsertarRenglonVista();
                    base.MostrarMensaje("Registro insertado");
                }
                else
                {
                    usuariosBAL.ActualizarUsuarioBAL(selUsuario);
                    ActualizarRenglonVista();
                    MostrarMensaje("Registro actualizado");

                }
                ConfigurarPaginacion();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        //private void EliminarRegistro()
        //{
        //    if (textUsuario.Text.Length == 0)
        //    {
        //        MostrarMensaje(Errores.NoRegistroValido);
        //        return;
        //    }

        //    DialogResult respuesta = MessageBox.Show(Variables.PreguntaEliminar, Variables.NombreSistema, MessageBoxButtons.YesNo);

        //    if (respuesta.ToString().ToUpper() == Variables.NO.ToUpper())
        //    {
        //        return;
        //    }

        //    try
        //    {
        //        CargarObjetoDesdeForma();
        //        usuarios.EliminarUsuario();
        //        EliminarRenglonVista();
        //        MostrarMensaje(Variables.EliminarCorrecto);
        //        ConfigurarPaginacion();
        //        IniciarObjetoControles();
        //    }
        //    catch (Exception ex)
        //    {
        //        MostrarError(ex.Message);
        //    }

        //}

        private void ValidarRegistro()
        {
            if (textUsuario.Text.Length == 0)
            {
                throw new Exception("Clave de usuario inválida.");
            }
            if (textNombre.Text.Length == 0)
            {
                throw new Exception("Nombre de usuario inválido");
            }
            if (textClave.Text.Length == 0)
            {
                throw new Exception("Contraseña inválida.");
            }
            if (cmbEstado.SelectedIndex == -1)
            {
                throw new Exception("Estado inváludo");
            }
        }

        private void InsertarRenglonVista()
        {
            DGVUsuarios.Rows.Add(selUsuario.Usuario, selUsuario.Nombre, selUsuario.Clave, selUsuario.Nivel, selUsuario.Estado, selUsuario.FAlta, selUsuario.Opciones);//, selUsuario.FMovto, selUsuario.UsuarioAdmin);

        }

        private void ActualizarRenglonVista()
        {
            DGVUsuarios.Rows[DGVUsuarios.CurrentRow.Index].Cells[0].Value = selUsuario.Usuario;
            DGVUsuarios.Rows[DGVUsuarios.CurrentRow.Index].Cells[1].Value = selUsuario.Nombre;
            DGVUsuarios.Rows[DGVUsuarios.CurrentRow.Index].Cells[2].Value = selUsuario.Clave;
           // DGVUsuarios.Rows[DGVUsuarios.CurrentRow.Index].Cells[3].Value = selUsuario.Nivel;
            DGVUsuarios.Rows[DGVUsuarios.CurrentRow.Index].Cells[4].Value = selUsuario.Estado;
            DGVUsuarios.Rows[DGVUsuarios.CurrentRow.Index].Cells[5].Value = selUsuario.FAlta;
            DGVUsuarios.Rows[DGVUsuarios.CurrentRow.Index].Cells[6].Value = selUsuario.Opciones;
        }

        private void EliminarRenglonVista()
        {
            int renglonActual = 0;
            renglonActual = DGVUsuarios.CurrentRow.Index;
            DGVUsuarios.Rows[0].Selected = true;
            DGVUsuarios.Rows.RemoveAt(renglonActual);

        }

        private void CargarRenglon()
        {
            try
            {
                textUsuario.Text = DGVUsuarios.Rows[DGVUsuarios.CurrentRow.Index].Cells["Usuario"].Value.ToString();
                textNombre.Text = DGVUsuarios.Rows[DGVUsuarios.CurrentRow.Index].Cells["Nombre"].Value.ToString();
                textClave.Text = DGVUsuarios.Rows[DGVUsuarios.CurrentRow.Index].Cells["Clave"].Value.ToString();
                textRecaptura.Text = DGVUsuarios.Rows[DGVUsuarios.CurrentRow.Index].Cells["Clave"].Value.ToString();
                cmbEstado.SelectedIndex = ClsFunciones.LocalizarClaveCombo(cmbEstado, DGVUsuarios.Rows[DGVUsuarios.CurrentRow.Index].Cells["Estado"].Value.ToString());

                //Cargar opciones
                string lsOopciones = DGVUsuarios.Rows[DGVUsuarios.CurrentRow.Index].Cells["Funciones"].Value.ToString();
                string[] laOpciones = lsOopciones.Split('|');
                for (int liCont = 0; liCont < laOpciones.Length - 1; liCont++)
                {
                    if (laOpciones[liCont] == "1")
                    {
                        chkOpciones.SetItemChecked(liCont, true);
                    }
                    else
                    {
                        chkOpciones.SetItemChecked(liCont, false);
                    }
                }
            }
            catch (Exception)
            {
                IniciarObjetoControles();
            }
        }

        private void ValidarRecapturaClave()
        {
            if (textClave.Text != textRecaptura.Text)
            {
                textRecaptura.Text = Variables.Nulo;
                textRecaptura.Focus();
                throw new Exception("Error en la clave.");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ConfigurarAlta();
            chkOpciones.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ConfigurarModificar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarRegistro(modo);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ConfigurarPaginacion();
            IniciarObjetoControles();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            IniciarObjetoControles();
            DGVUsuarios.Rows.Clear();
            CargarUsuarios();
            ConfigurarPaginacion();
            CargarRenglon();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //EliminarRegistro();
            cmbEstado.SelectedIndex = 1;
            ConfigurarModificar();
            //IniciarObjetoControles();
          /*  DGVUsuarios.Rows.Clear();
            CargarUsuarios();
            ConfigurarPaginacion();*/
        }



        private void DGVUsuarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!iniciandoVista)
            {
                CargarRenglon();
            }
        }

        private void DGVUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void textBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            BuscarClave();
        }

        private void BuscarClave()
        {
            int contador = 0;
            string claveActual = "N";
            for (contador = 0; contador <= this.DGVUsuarios.RowCount - 1; contador++)
            {
                claveActual = DGVUsuarios.Rows[contador].Cells[1].Value.ToString().ToUpper();
                /* if (claveActual.StartsWith(textBuscar.Text.ToString().Trim().ToUpper()))
                 {
                     DGVUsuarios.FirstDisplayedScrollingRowIndex = contador;
                    
                     break;
                 }*/
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlBase_Paint(object sender, PaintEventArgs e)
        {
            base.PonerTitulo("Administracion de Usuarios");
        }
    }
}
