using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class ClsUsuariosBAL: ClsUsuariosDAL 
    {
        public void AgregarUsuarioBAL(ClsUsuarios Usuario)
        {
            try
            {
                base.AgregarUsuarioDAL(Usuario);
            }
            catch
            {
                throw;
            }
        }

        public void ActualizarUsuarioBAL(ClsUsuarios Usuario)
        {
            try
            {
                base.ActualizarUsuarioDAL(Usuario);
            }
            catch
            {
                throw;
            }
        }

        public void EliminarUsuarioBAL(ClsUsuarios Usuario)
        {
            try
            {
                base.EliminarUsuarioDAL(Usuario);
            }
            catch
            {
                throw;
            }
        }

        public ClsUsuariosCollection ConsultarUsuariosBAL(string psCriterio)
        {
            ClsUsuariosCollection usuariosCollection = new ClsUsuariosCollection();
            try
            {
                usuariosCollection = base.ConsultarUsuariosDAL(psCriterio);
                return usuariosCollection;
            }
            catch
            {
                throw;
            }
        }

        public ArrayList CargarUsuarios()
        {
            string criterio = Variables.Nulo;
            //Lista de clientes
            ClsUsuariosCollection usuariosCollection;
            ClsUsuariosBAL usuariosBAL = new ClsUsuariosBAL();
            ArrayList arrUsuarios = new ArrayList();
            try
            {
                usuariosCollection = usuariosBAL.ConsultarUsuariosBAL(criterio);
                IEnumerator listaRegistros = usuariosCollection.GetEnumerator();
                while (listaRegistros.MoveNext())
                {
                    ClsUsuarios currUsuario = (ClsUsuarios)listaRegistros.Current;
                    arrUsuarios.Add(new AddValue(currUsuario.Usuario, currUsuario.Usuario));
                }
                return arrUsuarios;
            }
            catch
            {
                throw;
            }
        }

    }
}
