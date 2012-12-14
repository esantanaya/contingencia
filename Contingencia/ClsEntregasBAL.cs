using System.Data;

namespace Contingencia
{
    class ClsEntregasBAL : ClsEntregasDAL
    {
        public void AgregarTarimaTemporalBAL(ClsTarimaTemporal tarima)
        {
            AgregarTarimaTemporalDAL(tarima);
        }

        public ClsEntregasCollection ConsultarEntregasBAL(string psCriterio)
        {
            ClsEntregasCollection entregasCollection = new ClsEntregasCollection();
            entregasCollection = base.ConsultarEntregasDAL(psCriterio);

            return entregasCollection;
        }

        public ClsDetalleCollection ConsultarDetalleBAL(string entrega, string centro)
        {
            ClsDetalleCollection detalleCollection = new ClsDetalleCollection();
            detalleCollection = base.ConsultarDetalleDAL(entrega, centro);

            return detalleCollection;
        }
        
        public void ActualizarPickingBAL(string entrega, int posicion, string centro, decimal picking, int uniEmp)
        {
            ActualizarPickingDAL(entrega, posicion, centro, picking, uniEmp);
        }

        public DataSet ConsultarResumenBAL(string entrega, string centro)
        {
            DataSet ds = ConsultarResumenDAL(entrega, centro);

            return ds;
        }

        public DataSet ConsultarResumenDetalleBAL(string entrega, string material, string centro)
        {
            DataSet ds = ConsultarResumenDetalleDAL(entrega, material, centro);

            return ds;
        }

        public DataSet ConsultarProductoBAL(string entrega, string centro)
        {
            DataSet ds = ConsultarProductoDAL(entrega, centro);

            return ds;
        }

        public DataSet ConsultarRemisionBAL(string entrega, string centro)
        {
            DataSet ds = ConsultarRemisionDAL(entrega, centro);

            return ds;
        }

        public DataSet ConsultarRemisionCanalBAL(string entrega, string centro)
        {
            DataSet ds = ConsultarRemisionCanalDAL(entrega, centro);

            return ds;
        }

        public DataSet ConsultarCanalBAL(string entrega, string centro)
        {
            DataSet ds = ConsultarCanalDAL(entrega, centro);

            return ds;
        }
    }
}
