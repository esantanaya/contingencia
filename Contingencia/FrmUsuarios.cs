using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;


namespace Contingencia
{
    public partial class FrmUsuarios : FrmBaseCatalogo
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);
        ClsUsuarios usuarioActual = new ClsUsuarios();
        ClsUsuariosCollection usuariosColeccion = new ClsUsuariosCollection();
        
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            base.EstablecerTituloForma("Administración de Usuarios");
        }


        public override void CrearLista()
        {
            //En el grid, utilizar el nombre de la columna para poner el nombre del 
            //Campo en la base de datos
            DataGridViewCellStyle celdaEstilo = new DataGridViewCellStyle();
            //Inicia Grid
            dgvColeccion.Columns.Clear();
            //Determina las columnas en el grid y los respectivos títulos

            dgvColeccion.Columns.Add("Usuario", "Usuario");
            dgvColeccion.Columns["Usuario"].Tag = "Usuario" + "|" + Variables.TipoDatoString;
            dgvColeccion.Columns.Add("Clave", "Clave");
            dgvColeccion.Columns["Clave"].Tag = "Clave" + "|" + Variables.TipoDatoString;
            dgvColeccion.Columns["Clave"].Visible = false; //Se oculta la clave
            dgvColeccion.Columns.Add("Nombre", "Nombre");
            dgvColeccion.Columns["Nombre"].Tag = "Nombre" + "|" + Variables.TipoDatoString;
            dgvColeccion.Columns.Add("Paterno", "Paterno");
            dgvColeccion.Columns["Paterno"].Tag = "Paterno" + "|" + Variables.TipoDatoString;
            dgvColeccion.Columns.Add("Materno", "Materno");
            dgvColeccion.Columns["Materno"].Tag = "Materno" + "|" + Variables.TipoDatoString;
            dgvColeccion.Columns.Add("Calle", "Calle");
            dgvColeccion.Columns["Calle"].Tag = "Calle" + "|" + Variables.TipoDatoString;
            dgvColeccion.Columns.Add("Colonia", "Colonia");
            dgvColeccion.Columns["Colonia"].Tag = "Colonia" + "|" + Variables.TipoDatoString;
            dgvColeccion.Columns.Add("Cp", "Cód.Post.");
            dgvColeccion.Columns["Cp"].Tag = "Cp" + "|" + Variables.TipoDatoDecimal;
            dgvColeccion.Columns.Add("Estado", "Estado");
            dgvColeccion.Columns["Estado"].Tag = "Estado" + "|" + Variables.TipoDatoString;
            dgvColeccion.Columns.Add("Poblacion", "Poblacion");
            dgvColeccion.Columns["Poblacion"].Tag = "Poblacion" + "|" + Variables.TipoDatoString;
            dgvColeccion.Columns.Add("Nivel", "Nivel");
            dgvColeccion.Columns["Nivel"].Tag = "Nivel" + "|" + Variables.TipoDatoInt;
            dgvColeccion.Columns.Add("FAlta", "Fec.Alta");
            dgvColeccion.Columns["FAlta"].Tag = "FAlta" + "|" + Variables.TipoDatoFecha;
            dgvColeccion.Columns.Add("FMod", "Fec.Mod.");
            dgvColeccion.Columns["FMod"].Tag = "FMod" + "|" + Variables.TipoDatoFecha;
            dgvColeccion.Columns.Add("EstadoUsuario", "Estado Usr.");
            dgvColeccion.Columns["EstadoUsuario"].Tag = "EstadoUsuario" + "|" + Variables.TipoDatoString;
            celdaEstilo.FormatProvider = currentCulture;
            celdaEstilo.Format = "D";
            celdaEstilo.Format = "dd/MMM/yyyy";
            dgvColeccion.Columns["FAlta"].DefaultCellStyle = celdaEstilo;
            dgvColeccion.Columns["FMod"].DefaultCellStyle = celdaEstilo;
        }

        public override void CrearListaFiltros()
        {
            base.CrearListaFiltros();
        }

        public override void  CargarLista(string psModo)
        {
            int currRow = 0;
            
            string criterio = Variables.Nulo;
            if (psModo == Variables.ListaNueva)
            {
                criterio = base.ObtenerCriterioConsulta();
            }
            else
            {
                criterio = "Usuario = '" + usuarioActual.Usuario + "'";
            }
            if (criterio.Length == 0)
            {
                DialogResult respuesta = MessageBox.Show("No ha seleccionado un criterio de búsqueda, desea obtener todos los registros?",
                    Variables.NombreSistema, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.No)
                {
                    return;
                }
            }
            //Inicia la lista
            if (psModo == Variables.ListaNueva)
            {
                dgvColeccion.Rows.Clear();
            }

            ClsUsuariosBAL usuariosBAL = new ClsUsuariosBAL();

            try
            {
                usuariosColeccion = usuariosBAL.ConsultarUsuariosBAL(criterio);

                IEnumerator listaRegistros = usuariosColeccion.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsUsuarios currUsuario = (ClsUsuarios)listaRegistros.Current;
                    if (psModo == Variables.ListaNueva || psModo == Variables.ListaInsertar)
                    {
                        dgvColeccion.Rows.Add();
                        currRow = dgvColeccion.Rows.Count - 1;
                    }
                    else
                    {
                        currRow = dgvColeccion.CurrentRow.Index;
                    }

                    dgvColeccion[0, currRow].Value = currRow.ToString();
                    dgvColeccion["Usuario", currRow].Value = currUsuario.Usuario;
                    dgvColeccion["Clave", currRow].Value = currUsuario.Clave;
                    dgvColeccion["Nombre",currRow].Value = currUsuario.Nombre;
                    dgvColeccion["Paterno", currRow].Value = currUsuario.Paterno;
                    dgvColeccion["Materno", currRow].Value = currUsuario.Materno;
                    dgvColeccion["Calle", currRow].Value = currUsuario.Calle;
                    dgvColeccion["Colonia", currRow].Value = currUsuario.Colonia;
                    dgvColeccion["Cp", currRow].Value = currUsuario.Cp;
                    dgvColeccion["Estado", currRow].Value = currUsuario.Estado;
                    dgvColeccion["Poblacion", currRow].Value = currUsuario.Poblacion;
                    dgvColeccion["Nivel", currRow].Value = currUsuario.Nivel;
                    dgvColeccion["FAlta", currRow].Value = currUsuario.FAlta;
                    dgvColeccion["FMod", currRow].Value = currUsuario.FMod;
                    dgvColeccion["EstadoUsuario", currRow].Value = currUsuario.EstadoUsuario;
                    dgvColeccion.Rows[currRow].HeaderCell.Value = currRow;
                }
                if (dgvColeccion.Rows.Count > 0)
                {
                    base.textTotalRegistros.Text = dgvColeccion.Rows.Count.ToString();
                    dgvColeccion.Rows[currRow].Selected = true;
                    base.CurrRow = dgvColeccion.Rows[currRow];
                    CargarRegistro();
                    MostrarRegistro();
                }
                //else
                //{
                //    MostrarMensaje("No hay registros a mostrar");
                //    base.textTotalRegistros.Text = Variables.Cero;
                //}


            }
            catch(Exception ex)
            {
                base.MostrarError(ex.Message);
            }
        }

        public override void CrearListasSeleccion()
        {
            ArrayList arrNivel = new ArrayList();
            ArrayList arrEstado = new ArrayList();
            cmbPerfil.Items.Clear();
            cmbEstado.Items.Clear();

            //Lista de Nivel
            arrNivel.Add(new AddValue("Administrador", "1"));
            arrNivel.Add(new AddValue("Supervisor", "2"));
            arrNivel.Add(new AddValue("Operador", "3"));
            cmbPerfil.DataSource = arrNivel;
            cmbPerfil.DisplayMember = "Display";
            cmbPerfil.ValueMember = "Value";

            //Estados
            arrEstado.Add(new AddValue("Activo", "A"));
            arrEstado.Add(new AddValue("Baja", "B"));

            cmbEstado.DataSource = arrEstado;
            cmbEstado.DisplayMember = "Display";
            cmbEstado.ValueMember = "Value";

        }

        public override void GuardarRegistro()
        {
            ClsUsuariosBAL usuariosBAL = new ClsUsuariosBAL();
            try
            {
                ValidarDatos();
                CargarObjetoDesdeForma();
                if (base.Operacion == Variables.Alta)
                {
                    usuariosBAL.AgregarUsuarioBAL(usuarioActual);
                }
                else
                {
                    usuariosBAL.ActualizarUsuarioBAL(usuarioActual);
                }
                CargarRegistroProcesado();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
            finally
            {
                
            }
        }

        public override void ConfirmarEliminarRegistro()
        { 
            //No se hace nada, esta opción no opera en este caso.
        }

        private void CargarRegistroProcesado()
        {
            try
            {
                //usuariosColeccion = (new ClsUsuariosBAL()).ConsultarUsuariosBAL(criterio);
                //object objetoColeccion = usuariosColeccion;
                //Cargar todos los registros de la coleccion
                //IEnumerator listaRegistros = usuariosColeccion.GetEnumerator();
                if (base.Operacion == Variables.Alta)
                {
                    CargarLista(Variables.ListaInsertar);
                    base.CargarLista(Variables.ListaInsertar);
                }
                else
                {
                    CargarLista(Variables.ListaModificar);
                    base.CargarLista(Variables.ListaModificar);
                }
                base.GuardarRegistro(); //Sólo se encarga de seleccionar el último registro y mostrarlo
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
            finally
            {

            }

        }

        public override void ValidarDatos()
        {
            if (textId.Text.Trim().Length == 0)
            {
                textId.Focus();
                throw new Exception("Debe ingresar una clave de usuario válida");
            }
            if (textNombre.Text.Trim().Length  == 0)
            {
                textNombre.Focus();
                throw new Exception("Debe ingresar un Nombre de usuario válido");
            }
            if (cmbPerfil.SelectedIndex == -1)
            {
                cmbPerfil.Focus();
                throw new Exception("Debe seleccionar un nivel del usuario");
            }
            if (textClaveUno.Text.Trim().Length == 0)
            {
                textClaveUno.Focus();
                throw new Exception("Debe ingresar una contraseña válida");
            }
            if (textClaveDos.Text.Trim().Length == 0 || textClaveDos.Text.Trim() != textClaveUno.Text.Trim())
            {
                textClaveDos.Focus();
                throw new Exception("La contraseña y su confirmación no coinciden");
            }

            if (cmbEstado.SelectedIndex == -1)
            {
                cmbEstado.Focus();
                throw new Exception("Debe seleccionar un estado inicial del usuario");
            }
            if (textCP.Text.Length == 0)
            {
                textCP.Text = Variables.Cero;
            }
            try
            {
                Convert.ToDouble(textCP.Text);
            }
            catch
            {
                textCP.Focus();
                throw new Exception("Código Postal inválido");
            }

        }

        public override void CargarRegistro()
        {
            //Carga el registro a la pantala de usuarios
            try
            {
                usuarioActual.IniciarObjeto();
                usuarioActual.Usuario = base.CurrRow.Cells["Usuario"].Value.ToString().Trim();
                usuarioActual.Clave = base.CurrRow.Cells["Clave"].Value.ToString().Trim();
                usuarioActual.Nombre = base.CurrRow.Cells["Nombre"].Value.ToString().Trim();
                usuarioActual.Paterno = base.CurrRow.Cells["Paterno"].Value.ToString().Trim();
                usuarioActual.Materno = base.CurrRow.Cells["Materno"].Value.ToString().Trim();
                usuarioActual.Calle = base.CurrRow.Cells["Calle"].Value.ToString().Trim();
                usuarioActual.Colonia = base.CurrRow.Cells["Colonia"].Value.ToString().Trim();
                usuarioActual.Cp = Convert.ToDouble(base.CurrRow.Cells["Cp"].Value.ToString().Trim());
                usuarioActual.Estado = base.CurrRow.Cells["Estado"].Value.ToString().Trim();
                usuarioActual.Poblacion = base.CurrRow.Cells["Poblacion"].Value.ToString().Trim();
                usuarioActual.Nivel = Convert.ToInt32(base.CurrRow.Cells["Nivel"].Value.ToString().Trim());
                usuarioActual.FAlta = Convert.ToDateTime(base.CurrRow.Cells["FAlta"].Value.ToString().Trim());
                usuarioActual.FMod = Convert.ToDateTime(base.CurrRow.Cells["FMod"].Value.ToString().Trim());
                usuarioActual.EstadoUsuario = base.CurrRow.Cells["EstadoUsuario"].Value.ToString().Trim();

            }
            catch(Exception ex)
            {
                base.MostrarError(Errores.ConsultarRegistro + " " + Errores.MensajeOriginal + " " + ex.Message);
            }
        }

        public override void MostrarRegistro()
        { 
            //Carga los datos del objeto a la forma
            textId.Text = usuarioActual.Usuario;
            textClaveUno.Text = usuarioActual.Clave;
            textClaveDos.Text = usuarioActual.Clave;
            textNombre.Text = usuarioActual.Nombre;
            textPaterno.Text = usuarioActual.Paterno;
            textMaterno.Text = usuarioActual.Materno;
            textCalle.Text = usuarioActual.Calle;
            textColonia.Text = usuarioActual.Colonia;
            textEstado.Text = usuarioActual.Estado;
            textPoblacion.Text = usuarioActual.Poblacion;
            textCP.Text = usuarioActual.Cp.ToString();
            dtpFechaAlta.Value = usuarioActual.FAlta;
            dtpFechaMod.Value = usuarioActual.FMod;
            cmbPerfil.SelectedValue = usuarioActual.Nivel.ToString().Trim();
            cmbEstado.SelectedValue = usuarioActual.EstadoUsuario;
        }

        public override void IniciarObjetoControles()
        {
            //Inicia el objeto usuario actual
            usuarioActual.IniciarObjeto();
        }

        public override void CargarObjetoDesdeForma()
        {
            usuarioActual.Usuario = textId.Text.Trim();
            usuarioActual.Clave = textClaveUno.Text.Trim();
            usuarioActual.Nombre = textNombre.Text.Trim();
            usuarioActual.Paterno = textPaterno.Text.Trim();
            usuarioActual.Materno = textMaterno.Text.Trim();
            usuarioActual.Calle = textCalle.Text.Trim();
            usuarioActual.Colonia = textColonia.Text.Trim();
            usuarioActual.Estado = textEstado.Text.Trim();
            usuarioActual.Poblacion = textPoblacion.Text.Trim();
            usuarioActual.Cp = Convert.ToDouble(textCP.Text.Trim());
            usuarioActual.EstadoUsuario = cmbEstado.SelectedValue.ToString();
            usuarioActual.Nivel = Convert.ToInt32(cmbPerfil.SelectedValue.ToString());
            usuarioActual.FAlta = dtpFechaAlta.Value;
            usuarioActual.FMod = DateTime.Now;
        }

        public override void ConfigurarControlesParticulares()
        {
            dtpFechaAlta.Enabled = true;
            dtpFechaMod.Enabled = false;
        }

        public override void ConfigurarControlesModificar()
        {
            base.ConfigurarControlesModificar();
            //Inhabilita los controles de sólo lectura
            textId.Enabled = false;
            textNombre.Focus();
        }

        public override void ConfigurarControlesAlta()
        {
            base.ConfigurarControlesAlta();
            //Habilita los controles de sólo lectura
            textId.Enabled = true;
            textId.Focus();
        }

        public override void ConfigurarControlesPaginacion()
        {
            base.ConfigurarControlesPaginacion();
            textId.Enabled = true;
            textId.Focus();
        }

        private void pnlDetalle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textId_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
