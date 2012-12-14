using System;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class ClsUsuario
    {
        string usuario;
        public string Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }

        string nombre;
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        string nivel;
        public string Nivel
        {
            get
            {
                return nivel;
            }
            set
            {
                nivel = value;
            }
        }

        string clave;
        public string Clave
        {
            get
            {
                return clave;
            }
            set
            {
                clave = value;
            }
        }

        string estado;
        public string Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        DateTime fMovto;
        public DateTime FMovto
        {
            get
            {
                return fMovto;
            }
            set
            {
                fMovto = value;
            }
        }

        string usuarioAdmin;
        public string UsuarioAdmin
        {
            get
            {
                return usuarioAdmin;
            }
            set
            {
                usuarioAdmin = value;
            }
        }

        public void IniciarObjeto()
        {
            usuario = "";
            nombre = "";
            nivel = "";
            clave = "";
            estado = "";
            FMovto = DateTime.Now;
            usuarioAdmin = "";
        }


    }
}