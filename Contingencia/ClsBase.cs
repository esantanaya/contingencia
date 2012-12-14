using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace Contingencia
{
    class ClsBase : IDisposable
    {
        private SqlConnection conexion;

        /// <summary>
        /// Propiedad para obtener la cadena de conexión
        /// </summary>
        protected SqlConnection Conexion
        {
            get { return conexion; }
        }

        /// <summary>
        /// Método que permite la generación de una conexión a la base de datos
        /// </summary>
        /// <param name="cadenaConexion">Cadena de conexión para la base de datos</param>
        protected void CrearConexion()
        {
            string cadenaConexionServidor;
            
            try
            {
                cadenaConexionServidor = ObetnerCadenaConexion();
                conexion = new SqlConnection(cadenaConexionServidor);
            }
            catch (Exception ex)
            {
                throw new Exception(Errores.ConexionBase + Errores.MensajeOriginal + ex.Message, ex);
            }
        }

        protected string ObetnerCadenaConexion()
        {
            string servidor = Variables.Nulo;
            string baseDatos = Variables.Nulo;
            string usuarioBase = Variables.Nulo;
            string passwordBase = Variables.Nulo;
            string cadena = Variables.Nulo;
            try
            {
                servidor = ClsFunciones.ObtenerValorEntorno(Variables.Servidor);
                baseDatos = ClsFunciones.ObtenerValorEntorno(Variables.NombreBd);
                usuarioBase = ClsFunciones.ObtenerValorEntorno(Variables.UsuarioBd);
                passwordBase = ClsFunciones.ObtenerValorEntorno(Variables.PasswordBd);

                cadena = "Server=" + servidor + ";Database=" + baseDatos + ";user id=" + usuarioBase + "; password=Sql" + passwordBase;
                return cadena;
            }
            catch(Exception)
            {
                throw;
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Implementa el método IDisposable
        /// </summary>
        public void Dispose()
        {
            conexion.Close();
            conexion.Dispose();
        }

        #endregion
    }
}
