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
            try
            {
                ValidarAcceso();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void VerificarConexion()
        { 

        }

        private void ValidarAcceso()
        {
            string lsUsuario = "";
            string lsClave = "";
            string lsCriterio = "";
            try
            {
                lsUsuario = textUsuario.Text.ToString().Trim();
                lsClave = textClave.Text.ToString().Trim();
                lsCriterio = "WHERE IdUsuario = '" + lsUsuario + "'";
                ClsUsuariosBAL usuariosBAL = new ClsUsuariosBAL();
                ClsUsuariosCollection listaUsuarios = usuariosBAL.ConsultarUsuariosBAL(lsCriterio);
                if (listaUsuarios.Count == 0)
                {
                    throw new Exception("Error, el usuario no existe.");
                }
                else
                {
                    IEnumerator usuarios = listaUsuarios.GetEnumerator();
                    while (usuarios.MoveNext())
                    {
                        UsuarioLogin= (ClsUsuarios)usuarios.Current;
                        if (UsuarioLogin.Usuario.Contains(lsUsuario))
                        {
                            if (UsuarioLogin.Estado == "B")
                            {
                                textClave.Text = "";
                                textUsuario.Text = "";
                                textUsuario.Focus();
                                throw new Exception("El Usuario esta dado de Baja...");
                            }

                            if (UsuarioLogin.Clave.Equals(lsClave))
                            {
                                this.DialogResult = DialogResult.Yes;
                                //break;
                            }
                            else
                            {
                                throw new Exception("Error, clave de usario inválida.");
                            }
                        }
                        else
                        {
                            throw new Exception("Error, el usuario no existe.");
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            /*ArrayList opciones = new ArrayList();
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
                textUsuario.Focus();
            }
            else
            {
                IEnumerator listaUsuarios = usuariosColeccion.GetEnumerator();
                listaUsuarios.MoveNext();
               
                    UsuarioLogin = (ClsUsuarios)listaUsuarios.Current;

                    if (UsuarioLogin.Estado == "B")
                    {
                        MessageBox.Show("El Usuario esta dado de Baja...");
                        textClave.Text = "";
                        textUsuario.Text = "";
                        textUsuario.Focus();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Yes;
                    }              
                    //ClsEntorno.usuarioActual = (ClsUsuarios)listaUsuarios.Current;
                    //MessageBox.Show("Acceso concedido...");
            }*/
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
            lblVersion.Text = "Version: "+Application.ProductVersion.ToString();
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