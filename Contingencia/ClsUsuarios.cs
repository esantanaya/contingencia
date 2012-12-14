using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Contingencia
{
    public class ClsUsuarios
    {
        CultureInfo currentCulture = CultureInfo.GetCultureInfo(Variables.Cultura);

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        private string clave;
        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string paterno;
        public string Paterno
        {
            get { return paterno; }
            set { paterno = value; }
        }

        private string materno;
        public string Materno
        {
            get { return materno; }
            set { materno = value; }
        }

        private string calle;
        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }

        private string colonia;
        public string Colonia
        {
            get { return colonia; }
            set { colonia = value; }
        }

        private double cp;
        public double Cp
        {
            get { return cp; }
            set { cp = value; }
        }

        private string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string poblacion;
        public string Poblacion
        {
            get { return poblacion; }
            set { poblacion = value; }
        }

        private int nivel;
        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        private DateTime fAlta;
        public DateTime FAlta
        {
            get { return fAlta; }
            set { fAlta = value; }
        }

        private DateTime fMod;
        public DateTime FMod
        {
            get { return fMod; }
            set { fMod = value; }
        }

        private string estadoUsuario;
        public string EstadoUsuario
        {
            get { return estadoUsuario; }
            set { estadoUsuario = value; }
        }

        private string opciones;

        public string Opciones
        {
            get { return opciones; }
            set { opciones = value; }
        }


        public void IniciarObjeto()
        {
            DateTime tmpFecha = new DateTime(1753, 1, 1);
            usuario = Variables.Nulo;
            Clave = Variables.Blanco;
            Nombre = Variables.Blanco;
            Paterno = Variables.Blanco;
            Materno = Variables.Blanco;
            Calle = Variables.Blanco;
            Colonia = Variables.Blanco;
            Cp = Convert.ToDouble(Variables.Cero, currentCulture);
            Estado = Variables.Blanco;
            Poblacion = Variables.Blanco;
            Nivel = Convert.ToInt32(Variables.Cero, currentCulture);
            FAlta = DateTime.Now;
            FMod = tmpFecha;
            EstadoUsuario = Variables.Blanco;
            Opciones = Variables.Blanco;
        }


    }
}
