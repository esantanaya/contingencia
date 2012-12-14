using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace Contingencia
{
    public partial class FrmAsignarTarimasEntrega : FrmBase
    {
        private DataTable tablaTemporal;
        private int tarimaAgregada = 0;
        private string _idEntrega;
        private string _idCentro;

        public string IdEntrega
        {
            get { return _idEntrega; }
            set { _idEntrega = value; }
        }

        public string IdCentro
        {
            get { return _idCentro; }
            set { _idCentro = value; }
        }

        public FrmAsignarTarimasEntrega()
        {
            InitializeComponent();
        }

        private void FrmAsignarTarimasEntrega_Load(object sender, EventArgs e)
        {
            PonerTitulo("Asignar Tarimas Entrega " + IdEntrega);
        }

        public void IniciarForma()
        {
            ClsDetalleCollection detalleCollection = new ClsEntregasBAL().ConsultarDetalleBAL(IdEntrega, IdCentro);
            IEnumerator lista = detalleCollection.GetEnumerator();
            double diferencia = 0;
            double tmpPicking = 0;

            while (lista.MoveNext())
            {
                var detalleObt = (ClsDetalle) lista.Current;

                if (!String.IsNullOrEmpty(detalleObt.Picking))
                {
                    diferencia = Convert.ToDouble(detalleObt.Cantidad) - Convert.ToDouble(detalleObt.Picking);


                    dgvLista.Rows.Add(detalleObt.Entrega, detalleObt.Fecha, detalleObt.Posicion, detalleObt.NumMaterial,
                                      detalleObt.Centro, detalleObt.Almacen,
                                      String.Format("{0:0.000}", detalleObt.Cantidad),
                                      String.Format("{0:0.000}", detalleObt.Picking),
                                      String.Format("{0:0.000}", diferencia),
                                      detalleObt.UnidadMed, detalleObt.Descripcion,detalleObt.UniE);
                }
                else
                {

                    dgvLista.Rows.Add(detalleObt.Entrega, detalleObt.Fecha, detalleObt.Posicion, detalleObt.NumMaterial,
                                      detalleObt.Centro, detalleObt.Almacen,
                                      String.Format("{0:0.000}", detalleObt.Cantidad),
                                      "0.000",
                                      String.Format("{0:0.000}", diferencia),
                                      detalleObt.UnidadMed, detalleObt.Descripcion, detalleObt.UniE);
                }

                if (!String.IsNullOrEmpty(detalleObt.Picking))
                    tmpPicking = Convert.ToDouble(detalleObt.Picking);

                lblPesoTarima.Text = String.Format("{0:0.000}", Convert.ToDouble(lblPesoTarima.Text) + tmpPicking);
            }

            lblTotalEntradas.Text += detalleCollection.Count;

            //Inicializar tabla temporal
            tablaTemporal = new DataTable();
            tablaTemporal.Columns.Add("idTarima", typeof(double));
            tablaTemporal.Columns.Add("idEntrega", typeof(string));
            tablaTemporal.Columns.Add("pedido", typeof(string));
            tablaTemporal.Columns.Add("fecha", typeof(DateTime));

            //Ubicar foco
            textTarima.Focus();
        }

        private void textTarima_Enter(object sender, EventArgs e)
        {
            TextoColorEdicionOn(textTarima);
        }

        private void textTarima_Leave(object sender, EventArgs e)
        {
            TextoColorEdicionOff(textTarima);
        }

        private void textTarima_KeyPress(object sender, KeyPressEventArgs e)
        {
            MensajeApagar();
            bool tarimaProcesada = false;
            string mensajeTarima = "";

            //Validar la tecla "Enter"
            if (e.KeyChar == (char) 13)
            {
                //Valida que la tarima no haya sido seleccionada previamente
                foreach (DataRow row in tablaTemporal.Rows)
                {
                    if (row["idTarima"].ToString() == textTarima.Text)
                        tarimaProcesada = true;
                }

                //Si la tarimga ya fue seleccionada salir del proceso
                if (tarimaProcesada)
                {
                    MostrarError("La tarima " + textTarima.Text + " ya fue seleccionada");
                    return;
                }

                //Validar que la tarima proporcionada este en la BD
                string criterio = "where idTarima = '" + textTarima.Text + "'";
                ClsCatZMasterCollection zMasterCollection = new ClsCatZMasterBAL().ConsultarZMasterBAL(criterio);
                IEnumerator listaZMaster = zMasterCollection.GetEnumerator();
                bool tarimaValida = true;
                bool relacionValida = false;

                if (zMasterCollection.Count > 0)
                {
                    //Validar si la tarima ya fue asignada o existe inconsistenia en datos
                    while (listaZMaster.MoveNext())
                    {
                        var zMasterObt = (ClsCatZMaster) listaZMaster.Current;

                        if (!string.IsNullOrEmpty(zMasterObt.AsignadaEntrega))
                        {
                            tarimaValida = false;
                            mensajeTarima = "La tarima ya fue asignada a una entrega";
                            break;
                        }
                        if (!string.IsNullOrEmpty(zMasterObt.Desembalada))
                        {
                            tarimaValida = false;
                            mensajeTarima = "La tarima esta desembalada y no puede ser asignada a entrega";
                            break;
                        }
                        if (!string.IsNullOrEmpty(zMasterObt.Borrado))
                        {
                            tarimaValida = false;
                            mensajeTarima = "La tarima no existe";
                            break;
                        }
                    }

                    if (tarimaValida)
                    {
                        //Validar si los elementos de la tarima son validos
                        ClsDetalleCollection detalleCollection = new ClsEntregasBAL().ConsultarDetalleBAL(IdEntrega, IdCentro);
                        IEnumerator listaDetalle = detalleCollection.GetEnumerator();

                        listaZMaster.Reset();
                        while (listaZMaster.MoveNext())
                        {
                            var zMasterObt = (ClsCatZMaster) listaZMaster.Current;

                            listaDetalle.Reset();
                            while (listaDetalle.MoveNext())
                            {
                                var detalleObt = (ClsDetalle) listaDetalle.Current;

                                if ((zMasterObt.Matnr).Equals((detalleObt.NumMaterial).ToUpper()))
                                {
                                    relacionValida = true;
                                    break;
                                }
                                else
                                {
                                    relacionValida = false;
                                }
                            }

                            if (relacionValida == false)
                                break;
                        }

                        if (relacionValida)
                        {
                            tarimaAgregada++;
                            lblAcumuladas.Text = tarimaAgregada.ToString();

                            MostrarMensaje("Tarima " + textTarima.Text + " agregada");

                            //Grabar registro temporal: idTarima, idEntrega, pedido, fecha
                            tablaTemporal.Rows.Add(textTarima.Text, IdEntrega, IdEntrega, DateTime.Now);

                            //Hacer suma en las celdas correspondientes
                            listaZMaster.Reset();
                            while (listaZMaster.MoveNext())
                            {
                                var zMasterObt = (ClsCatZMaster) listaZMaster.Current;

                                foreach (DataGridViewRow r in dgvLista.Rows)
                                {
                                    if (r.Cells["Material"].Value.ToString() == zMasterObt.Matnr)
                                    {
                                        //Sumar en picking
                                        r.Cells["Picking"].Value = String.Format("{0:0.000}",
                                                                                 Convert.ToDouble(
                                                                                     r.Cells["Picking"].Value) +
                                                                                 zMasterObt.Cantidad);

                                        //Restar en diferencia
                                        r.Cells["Diferencia"].Value = String.Format("{0:0.000}",
                                                                                    Convert.ToDouble(                                                                                        
                                                                                        r.Cells["Cantidad"].Value) -
                                                                                         Convert.ToDouble(
                                                                                     r.Cells["Picking"].Value)
                                                                                    );

                                        r.Cells["UniEmp"].Value = Convert.ToInt16(r.Cells["UniEmp"].Value) + 1;
                                    }
                                }

                                //Sumar peso de la tarima
                                lblPesoTarima.Text = String.Format("{0:0.000}",
                                                                   Convert.ToDouble(lblPesoTarima.Text) +
                                                                   zMasterObt.Cantidad);
                            }
                            //Limpiar campo captura
                            textTarima.Text = "";
                            textTarima.Focus();
                        }
                        else
                        {
                            MostrarError("La tarima contiene material invalido");
                        }
                    }
                    else
                    {
                        textTarima.Text = "";
                        //base.MostrarError("La tarima ya fue asignada");
                        MostrarError(mensajeTarima);
                    }
                }
                else
                {
                    //La tarima no existe en la BD
                    textTarima.Text = "";
                    MostrarError("La tarima no es existe");
                }
            }
        }

        private void FrmAsignarTarimasEntrega_Activated(object sender, EventArgs e)
        {
            textTarima.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                //Guardar registros en la tabla temporal
                ClsEntregasBAL entregas = new ClsEntregasBAL();

                foreach (DataRow row in tablaTemporal.Rows)
                {
                    ClsTarimaTemporal tarima = new ClsTarimaTemporal();
                    tarima.IdTarima = row["idTarima"].ToString();
                    tarima.IdEntrega = row["idEntrega"].ToString();
                    tarima.Pedido = row["pedido"].ToString();
                    tarima.Fecha = Convert.ToDateTime(row["fecha"].ToString());

                    entregas.AgregarTarimaTemporalBAL(tarima);
                }

                //Actualizar dato picking en lips
                string tmpEntrega;
                string tmpPosicion;
                string tmpCentro;
                string tmpPicking;
                int tmpUniEmp = 0;

                foreach (DataGridViewRow r in dgvLista.Rows)
                {
                    tmpEntrega = r.Cells["Entrega"].Value.ToString();
                    tmpPosicion = r.Cells["Posicion"].Value.ToString();
                    tmpCentro = r.Cells["Centro"].Value.ToString();
                    tmpPicking = r.Cells["Picking"].Value.ToString();

                    if (r.Cells["UniEmp"].Value == null)
                        tmpUniEmp = 0;
                    else
                    {
                        tmpUniEmp = int.Parse(r.Cells["UniEmp"].Value.ToString());
                        
                        //tmpUniEmp = tmpUniEmp + 1;
                    }
                    entregas.ActualizarPickingBAL(tmpEntrega, Convert.ToInt16(tmpPosicion), tmpCentro,
                                                  Convert.ToDecimal(tmpPicking), Convert.ToInt16(tmpUniEmp));
                }

                MostrarMensaje("Registro de la operación finalizado");
                btnGrabar.Enabled = false;
                btnSalir.Focus();
            }
            catch
            {
                MostrarError("La información no pudo ser registrada");
            }

        }
    }
}