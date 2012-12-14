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
    public partial class FrmLogin : Form
    {
        ClsUsuarios usuarioLogin;
        public ClsUsuarios UsuarioLogin
        {
            get
            {
                return usuarioLogin;
            }
            set
            {
                usuarioLogin = value;
            }
        }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ValidarAcceso();
        }

        private void VerificarConexion()
        { 

        }

        private void ValidarAcceso()
        {
            string idUsuario = "";
            string clave = "";
            string criterio = "";
            idUsuario = textUsuario.Text;
            clave = textClave.Text;
            criterio = "WHERE IdUsuario = '" + idUsuario.Trim() + "' AND Clave = '" + clave.Trim() + "'";
            ClsUsuariosCollection usuariosColeccion;
            usuariosColeccion = (new ClsUsuariosBAL()).ConsultarUsuariosBAL(criterio);

            if (usuariosColeccion.Count == 0)
            {
                
                MessageBox.Show("Error, usuario/clave invalida...");
            }
            else
            {
                IEnumerator listaUsuarios = usuariosColeccion.GetEnumerator();
                listaUsuarios.MoveNext();
                UsuarioLogin = (ClsUsuarios)listaUsuarios.Current;
                //ClsEntorno.usuarioActual = (ClsUsuarios)listaUsuarios.Current;
                //MessageBox.Show("Acceso concedido...");
                this.DialogResult = DialogResult.Yes;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        protected void TextoColorEdicionOn(TextBox obTexto)
        {
            obTexto.BackColor = Color.Gold;
        }

        protected void TextoColorEdicionOff(TextBox obTexto)
        {
            obTexto.BackColor = Color.White;
        }

        private void textUsuario_Enter(object sender, EventArgs e)
        {
            TextoColorEdicionOn(textUsuario);
            textUsuario.SelectAll();
        }

        private void textUsuario_Leave(object sender, EventArgs e)
        {
            TextoColorEdicionOff(textUsuario);
        }

        private void textClave_Enter(object sender, EventArgs e)
        {
            TextoColorEdicionOn(textClave);
            textUsuario.SelectAll();
        }

        private void textClave_Leave(object sender, EventArgs e)
        {
            TextoColorEdicionOff(textClave);
        }


    }
}