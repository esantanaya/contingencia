//Notas de uso y configuración
//1. El nombre del campo en la base de datos y Objeto debe ser el que se quiere desplegar como encabezado Ej. UnidadMedidad --> Unidad Medida
//2. Los campos que se guardan com oun caracter como clave, pero su descripción se debe desplegar,
// en el case del query se debe de poner la decripcion + |º| + el valor en la BD ej. Metros|º|M

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
    public partial class FrmBaseCatalogo : Form
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private bool iniciandoVista;
        public bool IniciandoVista
        {
            set
            {
                iniciandoVista = value;
            }
            get
            {
                return iniciandoVista;
            }
        }


        private string operacion;
        public string Operacion
        {
            get
            {
                return operacion;
            }
            set
            {
                operacion = value;
            }
        }

        private DataGridViewRow currRow;
        public DataGridViewRow CurrRow
        {
            get
            {
                return currRow;
            }
            set
            {
                currRow = value;
            }
        }

        private string criterioLista;
        public string CriterioLista
        { 
            get
            {
                return criterioLista;
            }
            set
            {
                criterioLista = value;
            }
        }


        public FrmBaseCatalogo()
        {
            InitializeComponent();
        }

        private void FrmBaseCatalogo_Load(object sender, EventArgs e)
        {
            //Ajuste del panel principal a la forma
            iniciandoVista = true;
            //Crea el encabezado del grid
            CrearLista();
            CrearListasSeleccion();
            CrearListaFiltros();
            //CargarLista(Variables.ListaNueva);
            //Genera las listas de estado e idioma
            ConfigurarControlesParticulares();

            ConfigurarControlesPaginacion();
            iniciandoVista = false; ;
        }

        public virtual void CrearLista()
        {
            //Se desarrolla detalle en la clase instanciada
        }


        public virtual void CargarLista(string psModo)
        {
            if (dgvColeccion.Rows.Count > 0)
            {
                if (psModo == Variables.ListaNueva)
                {
                    //Seleccionar primer registro
                    dgvColeccion.CurrentCell = dgvColeccion[0, 0];
                    dgvColeccion.FirstDisplayedScrollingRowIndex = 0;
                    DesplegarRegistroSeleccionado();
                }
                else
                {
                    DesplegarRegistroSeleccionado();
                }
            }
            else
            {
                MostrarMensaje("No hay registros a mostrar");

            }
        }


        public virtual void GuardarRegistro()
        {
            if (operacion == Variables.Alta)
            {
                //Seleccionar último registro
                dgvColeccion.CurrentCell = dgvColeccion[0, dgvColeccion.Rows.Count - 1];
                dgvColeccion.FirstDisplayedScrollingRowIndex = dgvColeccion.Rows.Count - 1;
            }
            DesplegarRegistroSeleccionado();
            ConfigurarControlesPaginacion();

        }

        public virtual void ConfirmarEliminarRegistro()
        {
            if (dgvColeccion.Rows.Count == 0)
            {
                MostrarMensaje("Debe seleccionar un registro válido");
                return;
            }

            if (dgvColeccion.CurrentRow.Index < 0)
            {
                MostrarMensaje("Debe seleccionar un registro válido");
                return;
            }
            DialogResult respuesta = MessageBox.Show("Desea eliminar el registro seleccionado?",Variables.NombreSistema,MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {
                EliminarRegistro();
            }
        }

        public virtual void EliminarRegistro()
        { 
            //Eliminar el registro de la lista
            dgvColeccion.Rows.RemoveAt(dgvColeccion.CurrentRow.Index);

        }

        
        public virtual void ValidarDatos()
        { 

        }

        private void InsertarRegistroLista()
        { 

        }

        public virtual void IniciarObjetoControles()
        {
        }

        public virtual void CrearListasSeleccion()
        { 
            //Se define en la instancia de esta clase...
        }

        public virtual void CrearListaFiltros()
        {
            string tmpTexto = Variables.Nulo;
            string tmpValor = Variables.Nulo;
            //Crea la lista de los filtros a partir del datagridview
            //El nombre de la columna contiene el nombre del campo, el tag contiene el tipo de dato
            ArrayList arrFiltro = new ArrayList();
            lstCampos.Items.Clear();

            for (int liCont = 0; liCont <= dgvColeccion.Columns.Count - 1 ; liCont++)
            {
                tmpTexto = dgvColeccion.Columns[liCont].HeaderText.ToString();
                try
                {
                    tmpValor = dgvColeccion.Columns[liCont].Tag.ToString();
                    //tmpValor = tmpValor + "|" + dgvColeccion.Columns[liCont].Tag.ToString();
                }
                catch
                {
                }
                arrFiltro.Add(new AddValue(tmpTexto, tmpValor));
            }
            lstCampos.DataSource = arrFiltro;
            lstCampos.DisplayMember = "Display";
            lstCampos.ValueMember = "Value";
        }

        public virtual void CargarObjetoDesdeForma()
        {
        }

        private void gpbLista_Enter(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarAlta();
        }


        #region Configuración de controles

        private void HabilitarOpcionesFunciones()
        {
            tsmiNuevo.Enabled = true;
            tsmiModificar.Enabled = true;
            tsmiEliminar.Enabled = true;
            tsmiImprimir.Enabled = true;
            tsmiSalir.Enabled = true;
            tsbNuevo.Enabled = true;
            tsbModificar.Enabled = true;
            tsbEliminar.Enabled = true;
            tsbImprimir.Enabled = true;
        }


        private void DeshabilitarOpcionesFunciones()
        {
            tsmiNuevo.Enabled = false;
            tsmiModificar.Enabled = false;
            tsmiEliminar.Enabled = false;
            tsmiImprimir.Enabled = false;
            tsmiSalir.Enabled = false;
            tsbNuevo.Enabled = false;
            tsbModificar.Enabled = false;
            tsbEliminar.Enabled = false;
            tsbImprimir.Enabled = false;
        }

        private void HabilitarOpcionesGuardar()
        {
            tsmiGuardar.Enabled = true;
            tsmiCancelar.Enabled = true;
            tsbGuardar.Enabled = true;
            tsbCancelar.Enabled = true;
        }

        private void DeshabilitarOpcionesGuardar()
        {
            tsmiGuardar.Enabled = false;
            tsmiCancelar.Enabled = false;
            tsbGuardar.Enabled = false;
            tsbCancelar.Enabled = false;
        }

        public virtual void ConfigurarControlesAlta()
        {
            IniciarObjetoControles();
            MostrarRegistro();
            DeshabilitarOpcionesFunciones();
            HabilitarOpcionesGuardar();
            spcPrincipal.Panel1.Enabled = false;
            //spcPrincipal.Panel2.Enabled = true;
            operacion = Variables.Alta;
        }

        public virtual void ConfigurarControlesModificar()
        {
            DeshabilitarOpcionesFunciones();
            HabilitarOpcionesGuardar();
            spcPrincipal.Panel1.Enabled = false;
            //spcPrincipal.Panel2.Enabled = true;
            operacion = Variables.Modificar;
        }

        public virtual void ConfigurarControlesPaginacion()
        {
            DeshabilitarOpcionesGuardar();
            HabilitarOpcionesFunciones();
            spcPrincipal.Panel1.Enabled = true;
            //spcPrincipal.Panel2.Enabled = false;
        } 
        #endregion

        private void ConfigurarAlta()
        {
            ConfigurarControlesAlta();
        }

        private void ConfigurarModificar()
        {

            if (dgvColeccion.Rows.Count == 0)
            {
                MostrarMensaje("Debe seleccionar un registro válido");
                return;
            }

            if (dgvColeccion.CurrentRow.Index < 0)
            {
                MostrarMensaje("Debe seleccionar un registro válido");
                return;
            }
            ConfigurarControlesModificar();
        }

        private void ConfigurarPaginacion()
        {
            ConfigurarControlesPaginacion();
        }

        public void EstablecerTituloForma(string psTitulo)
        {
            this.Text = psTitulo;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ConfigurarAlta();
        }

        private void tsmiCancelar_Click(object sender, EventArgs e)
        {
            DesplegarRegistroSeleccionado();
            ConfigurarPaginacion();
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            //IniciarObjetoControles();
            DesplegarRegistroSeleccionado();
            ConfigurarPaginacion();
        }

        public void MostrarError(string psMensaje)
        {
            MessageBox.Show(psMensaje, Variables.NombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void MostrarMensaje(string psMensaje)
        {
            MessageBox.Show(psMensaje, Variables.NombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarClave()
        {
            if (dgvColeccion.Rows.Count > 0)
            {
                ClsFunciones.BuscarValorGrid(dgvColeccion, textBuscar.Text);
            }
            else
            {
                //MostrarMensaje("No se tienen registros listados");
            }
        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarClave();
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            GuardarRegistro();
        }

        public virtual void CargarRegistro()
        {
            
            MostrarMensaje("Cargar detalle de registro");
        }

        private void btnActualizarLista_Click(object sender, EventArgs e)
        {
            CargarLista(Variables.ListaNueva);
        }


        private void dgvColeccion_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DesplegarRegistroSeleccionado()
        {
            if (dgvColeccion.Rows.Count > 0)
            {
                if (dgvColeccion.CurrentRow.Index > -1)
                {
                    currRow = dgvColeccion.CurrentRow;
                }
                //Carga el objeto actual
                CargarRegistro();
            }
            else
            {
                IniciarObjetoControles();
            }
            MostrarRegistro();



        }

        public virtual void MostrarRegistro()
        { 

        }

        public virtual void ConfigurarControlesParticulares()
        {

        }

        private void dgvColeccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            ConfigurarModificar();
        }

        private void dgvColeccion_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (iniciandoVista)
            {
                return;
            }
            //Carga el renglón actual
            DesplegarRegistroSeleccionado();
        }

        private void tsmiImprimir_Click(object sender, EventArgs e)
        {

        }

        private void tsmiModificar_Click(object sender, EventArgs e)
        {
            ConfigurarModificar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminarRegistro();
        }

        private void tsmiGuardar_Click(object sender, EventArgs e)
        {
            GuardarRegistro();
        }

        private void tsmiEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminarRegistro();
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void spcSeccion_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void spcListaDetalle_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void btnFiltros_Click(object sender, EventArgs e)
        {
            if (btnFiltros.Tag.ToString() == Variables.S) //Entonce se debe ocultar
            {
                spcListaDetalle.SplitterDistance = 40;
                btnFiltros.Tag = Variables.N;
                btnFiltros.Text = "Mostrar Filtros";
            }
            else //Se debe mostrar
            {
                spcListaDetalle.SplitterDistance = 225;
                btnFiltros.Tag = Variables.S;
                btnFiltros.Text = "Ocultar Filtros";
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            iniciandoVista = true;
            //Definir el criterio de la lista
            CargarLista(Variables.ListaNueva);
            iniciandoVista = false;
        }

        #region Criterios de selección de regsitros
        private void lstCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iniciandoVista)
            {
                return;
            }
            ConfigurarControlesCriterio();
        }

        private void ConfigurarControlesCriterio()
        {
            string tipoCampo = "";
            string[] arrPropiedades;
            ArrayList listaOperador = new ArrayList();
            //Obtiene propiedades del campo
            arrPropiedades = lstCampos.SelectedValue.ToString().Split('|');
            tipoCampo = arrPropiedades[1];
            //Establece valores posibles de los campos
            dtpCriterio.Value = DateTime.Now;
            dtpCriterio.Visible = false;
            textCriterio.Text = "";
            textCriterio.Visible = false;
            textCriterio.Tag = tipoCampo;
            cmbCriterio.SelectedIndex = -1;
            if (tipoCampo == Variables.TipoDatoString)
            {
                listaOperador.Add(new AddValue("=", "="));
                listaOperador.Add(new AddValue("Contiene", "Like"));
                textCriterio.Visible = true;
            }

            if (tipoCampo == Variables.TipoDatoFecha)
            {
                listaOperador.Add(new AddValue("<", "<"));
                listaOperador.Add(new AddValue(">", ">"));
                listaOperador.Add(new AddValue("=", "="));
                dtpCriterio.Visible = true;
            }

            if (tipoCampo == Variables.TipoDatoInt ||
                tipoCampo == Variables.TipoDatoDouble ||
                tipoCampo == Variables.TipoDatoDecimal)
            {
                listaOperador.Add(new AddValue("<", "<"));
                listaOperador.Add(new AddValue(">", ">"));
                listaOperador.Add(new AddValue("=", "="));
                textCriterio.Visible = true;
            }


            cmbCriterio.DataSource = listaOperador;
            cmbCriterio.DisplayMember = "Display";
            cmbCriterio.ValueMember = "Value";
            cmbCriterio.SelectedIndex = 0;
            cmbCriterio.Visible = true;
        }

        private void textCriterio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ValidarEntradaCriterio())
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private bool ValidarEntradaCriterio()
        {
            bool resultado = false;
            if (textCriterio.Tag.ToString() == Variables.TipoDatoString)
            {
                resultado = true;
            }
            if (textCriterio.Tag.ToString() == Variables.TipoDatoInt)
            {
                resultado = ClsFunciones.ValidarEnteroCorto(textCriterio.Text);
            }
            if (textCriterio.Tag.ToString() == Variables.TipoDatoDecimal ||
                textCriterio.Tag.ToString() == Variables.TipoDatoDouble)
            {
                resultado = ClsFunciones.ValidarEnteroLargo(textCriterio.Text);
            }

            return true;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            QuitarCriterio();
        }

        private void QuitarCriterio()
        {
            string textoNuevo = "";
            string valornuevo = "";
            int elementoBorrar = 0;
            if (lstCriterios.Items.Count == 0)
            {
                MostrarMensaje("No hay criterios por eliminar");
                return;
            }
            if (lstCriterios.SelectedIndex == -1)
            {
                MostrarMensaje("Debe seleccionar un criterio válido");
                return;
            }
            elementoBorrar = lstCriterios.SelectedIndex;
            //Cargar los valores de la lista al arreglo
            ArrayList arrCampos = new ArrayList();
            for (int contList = 0; contList <= lstCriterios.Items.Count - 1; contList++)
            {
                lstCriterios.SelectedIndex = contList;
                textoNuevo = lstCriterios.Text;  //lstCriterios.DisplayMember[contList].ToString();
                valornuevo = lstCriterios.SelectedValue.ToString(); // lstCriterios.ValueMember[contList].ToString();
                arrCampos.Add(new AddValue(textoNuevo, valornuevo));
            }
            //Eliminar el elemento seleccionado
            arrCampos.RemoveAt(elementoBorrar);
            lstCriterios.DataSource = arrCampos;
        }

        public string ObtenerCriterioConsulta()
        {
            StringBuilder criterio = new StringBuilder();
            string valor = "";
            if (lstCriterios.Items.Count > 0)
            {
                for (int contList = 0; contList <= lstCriterios.Items.Count - 1; contList++)
                {
                    if (valor.Length > 0)
                    {
                        valor = valor + " AND ";
                    }
                    lstCriterios.SelectedIndex = contList;
                    valor = valor + lstCriterios.SelectedValue.ToString();
                    //criterio.Append(valor);
                }
                //valor = criterio.ToString();
            }

            return valor;
        }

        private void AgregarCriterio()
        {
            string textoNuevo = Variables.Nulo;
            string valorNuevo = Variables.Nulo;
            string nombreCampo = Variables.Nulo;
            string tipoCampo = Variables.Nulo;
            string[] arrPropiedades;

            if (lstCampos.SelectedIndex < 0)
            {
                MostrarMensaje("Debe seleccionar un campo de la lista");
                return;
            }
            if (textCriterio.Visible && textCriterio.Text.Trim().Length == 0)
            {
                MostrarMensaje("Debe ingresar un criterio válido.");
                return;
            }
            arrPropiedades = lstCampos.SelectedValue.ToString().Split('|');
            nombreCampo = arrPropiedades[0];
            tipoCampo = arrPropiedades[1];

            //Cargar los valores de la lista al arreglo
            ArrayList arrCampos = new ArrayList();
            for (int contList = 0; contList <= lstCriterios.Items.Count - 1; contList++)
            {
                lstCriterios.SelectedIndex = contList;
                textoNuevo = lstCriterios.Text;  //lstCriterios.DisplayMember[contList].ToString();
                valorNuevo = lstCriterios.SelectedValue.ToString(); // lstCriterios.ValueMember[contList].ToString();
                arrCampos.Add(new AddValue(textoNuevo, valorNuevo));
            }

            //Carga el nuevo campo al arreglo
            textoNuevo = lstCampos.Text + " ";
            valorNuevo = nombreCampo + " ";

            textoNuevo = textoNuevo + cmbCriterio.Text.ToString() + " ";
            valorNuevo = valorNuevo + cmbCriterio.SelectedValue.ToString() + " ";

            if (textCriterio.Visible)
            {
                if (tipoCampo == Variables.TipoDatoString)
                {
                    textoNuevo = textoNuevo + "'" + textCriterio.Text.Trim() + "'";
                    valorNuevo = valorNuevo + "'" + textCriterio.Text.Trim() + "'";
                }
                else
                {
                    textoNuevo = textoNuevo + textCriterio.Text.Trim();
                    valorNuevo = valorNuevo + textCriterio.Text.Trim();
                }
            }
            else
            {
                string fecha = "";
                DateTime tmpFecha = dtpCriterio.Value;
                textoNuevo = textoNuevo + dtpCriterio.Value.ToShortDateString();
                if (cmbCriterio.Text == "<")
                {
                    tmpFecha = tmpFecha.AddDays(1);
                }
                fecha = tmpFecha.Year.ToString();
                fecha = fecha + tmpFecha.Month.ToString().PadLeft(2, '0');
                fecha = fecha + tmpFecha.Day.ToString().PadLeft(2, '0');
                valorNuevo = valorNuevo + "'" + fecha + "'";
            }

            arrCampos.Add(new AddValue(textoNuevo, valorNuevo));
            //carga arreglo de campos a lista
            lstCriterios.DataSource = arrCampos;
            lstCriterios.DisplayMember = "Display";
            lstCriterios.ValueMember = "Value";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCriterio();
        }

        #endregion

        public void ActualizarEstadoProceso(string psMensaje)
        {
            tssEstado.Text = psMensaje;
        }
    }
}