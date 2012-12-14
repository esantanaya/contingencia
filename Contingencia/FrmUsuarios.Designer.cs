namespace Contingencia
{
    partial class FrmUsuarios
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuarios));
            this.lblUsuario = new System.Windows.Forms.Label();
            this.textId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textClaveUno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textClaveDos = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dtpFechaMod = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.cmbPerfil = new System.Windows.Forms.ComboBox();
            this.textPaterno = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textMaterno = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.grpClave = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.grpNombre = new System.Windows.Forms.GroupBox();
            this.grpDireccion = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textCP = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textPoblacion = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textColonia = new System.Windows.Forms.TextBox();
            this.textEstado = new System.Windows.Forms.TextBox();
            this.textCalle = new System.Windows.Forms.TextBox();
            this.grpRegistro = new System.Windows.Forms.GroupBox();
            this.pnlResumenLista.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.spcPrincipal.Panel2.SuspendLayout();
            this.spcPrincipal.SuspendLayout();
            this.grpClave.SuspendLayout();
            this.grpNombre.SuspendLayout();
            this.grpDireccion.SuspendLayout();
            this.grpRegistro.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlResumenLista
            // 
            this.pnlResumenLista.Size = new System.Drawing.Size(205, 30);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.AutoSize = true;
            this.pnlDetalle.Controls.Add(this.grpRegistro);
            this.pnlDetalle.Controls.Add(this.grpDireccion);
            this.pnlDetalle.Controls.Add(this.grpNombre);
            this.pnlDetalle.Controls.Add(this.grpClave);
            this.pnlDetalle.Controls.Add(this.lblDetalle);
            this.pnlDetalle.Size = new System.Drawing.Size(725, 410);
            this.pnlDetalle.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDetalle_Paint);
            this.pnlDetalle.Controls.SetChildIndex(this.lblDetalle, 0);
            this.pnlDetalle.Controls.SetChildIndex(this.grpClave, 0);
            this.pnlDetalle.Controls.SetChildIndex(this.grpNombre, 0);
            this.pnlDetalle.Controls.SetChildIndex(this.grpDireccion, 0);
            this.pnlDetalle.Controls.SetChildIndex(this.grpRegistro, 0);
            // 
            // spcPrincipal
            // 
            this.spcPrincipal.Size = new System.Drawing.Size(942, 414);
            this.spcPrincipal.SplitterDistance = 209;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(40, 212);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario:";
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(13, 19);
            this.textId.MaxLength = 10;
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(110, 20);
            this.textId.TabIndex = 1;
            this.textId.TextChanged += new System.EventHandler(this.textId_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre";
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(9, 19);
            this.textNombre.MaxLength = 20;
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(137, 20);
            this.textNombre.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(241, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nivel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(133, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password";
            // 
            // textClaveUno
            // 
            this.textClaveUno.Location = new System.Drawing.Point(135, 19);
            this.textClaveUno.MaxLength = 10;
            this.textClaveUno.Name = "textClaveUno";
            this.textClaveUno.PasswordChar = '*';
            this.textClaveUno.Size = new System.Drawing.Size(110, 20);
            this.textClaveUno.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(249, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "Confirmación de password";
            // 
            // textClaveDos
            // 
            this.textClaveDos.Location = new System.Drawing.Point(251, 19);
            this.textClaveDos.MaxLength = 10;
            this.textClaveDos.Name = "textClaveDos";
            this.textClaveDos.PasswordChar = '*';
            this.textClaveDos.Size = new System.Drawing.Size(110, 20);
            this.textClaveDos.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "Fecha Alta";
            // 
            // dtpFechaAlta
            // 
            this.dtpFechaAlta.CustomFormat = "dd/MMM/yyyy";
            this.dtpFechaAlta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaAlta.Location = new System.Drawing.Point(6, 21);
            this.dtpFechaAlta.Name = "dtpFechaAlta";
            this.dtpFechaAlta.Size = new System.Drawing.Size(110, 20);
            this.dtpFechaAlta.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(349, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(351, 22);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(97, 21);
            this.cmbEstado.TabIndex = 13;
            // 
            // dtpFechaMod
            // 
            this.dtpFechaMod.CustomFormat = "dd/MMM/yyyy";
            this.dtpFechaMod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaMod.Location = new System.Drawing.Point(122, 22);
            this.dtpFechaMod.Name = "dtpFechaMod";
            this.dtpFechaMod.Size = new System.Drawing.Size(107, 20);
            this.dtpFechaMod.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(120, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "Última Modificación";
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblDetalle.Location = new System.Drawing.Point(3, 6);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(161, 20);
            this.lblDetalle.TabIndex = 18;
            this.lblDetalle.Text = "Detalle del registro";
            // 
            // cmbPerfil
            // 
            this.cmbPerfil.FormattingEnabled = true;
            this.cmbPerfil.Location = new System.Drawing.Point(243, 21);
            this.cmbPerfil.Name = "cmbPerfil";
            this.cmbPerfil.Size = new System.Drawing.Size(92, 21);
            this.cmbPerfil.TabIndex = 19;
            this.cmbPerfil.SelectedIndexChanged += new System.EventHandler(this.cmbPerfil_SelectedIndexChanged);
            // 
            // textPaterno
            // 
            this.textPaterno.Location = new System.Drawing.Point(152, 19);
            this.textPaterno.MaxLength = 20;
            this.textPaterno.Name = "textPaterno";
            this.textPaterno.Size = new System.Drawing.Size(136, 20);
            this.textPaterno.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(150, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "A. Paterno";
            // 
            // textMaterno
            // 
            this.textMaterno.Location = new System.Drawing.Point(294, 19);
            this.textMaterno.MaxLength = 20;
            this.textMaterno.Name = "textMaterno";
            this.textMaterno.Size = new System.Drawing.Size(134, 20);
            this.textMaterno.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(292, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "A. Materno";
            // 
            // grpClave
            // 
            this.grpClave.Controls.Add(this.label12);
            this.grpClave.Controls.Add(this.textId);
            this.grpClave.Controls.Add(this.textClaveUno);
            this.grpClave.Controls.Add(this.label5);
            this.grpClave.Controls.Add(this.textClaveDos);
            this.grpClave.Controls.Add(this.label6);
            this.grpClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpClave.Location = new System.Drawing.Point(7, 38);
            this.grpClave.Name = "grpClave";
            this.grpClave.Size = new System.Drawing.Size(454, 61);
            this.grpClave.TabIndex = 24;
            this.grpClave.TabStop = false;
            this.grpClave.Text = "Clave";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(11, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "Usuario";
            // 
            // grpNombre
            // 
            this.grpNombre.Controls.Add(this.textPaterno);
            this.grpNombre.Controls.Add(this.label3);
            this.grpNombre.Controls.Add(this.textMaterno);
            this.grpNombre.Controls.Add(this.textNombre);
            this.grpNombre.Controls.Add(this.label11);
            this.grpNombre.Controls.Add(this.label10);
            this.grpNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpNombre.Location = new System.Drawing.Point(7, 114);
            this.grpNombre.Name = "grpNombre";
            this.grpNombre.Size = new System.Drawing.Size(454, 64);
            this.grpNombre.TabIndex = 25;
            this.grpNombre.TabStop = false;
            this.grpNombre.Text = "Nombre";
            // 
            // grpDireccion
            // 
            this.grpDireccion.Controls.Add(this.label17);
            this.grpDireccion.Controls.Add(this.textCP);
            this.grpDireccion.Controls.Add(this.label16);
            this.grpDireccion.Controls.Add(this.textPoblacion);
            this.grpDireccion.Controls.Add(this.label15);
            this.grpDireccion.Controls.Add(this.label14);
            this.grpDireccion.Controls.Add(this.label13);
            this.grpDireccion.Controls.Add(this.textColonia);
            this.grpDireccion.Controls.Add(this.textEstado);
            this.grpDireccion.Controls.Add(this.textCalle);
            this.grpDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDireccion.Location = new System.Drawing.Point(7, 196);
            this.grpDireccion.Name = "grpDireccion";
            this.grpDireccion.Size = new System.Drawing.Size(454, 109);
            this.grpDireccion.TabIndex = 26;
            this.grpDireccion.TabStop = false;
            this.grpDireccion.Text = "Dirección";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(295, 91);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(24, 12);
            this.label17.TabIndex = 33;
            this.label17.Text = "C.P.";
            // 
            // textCP
            // 
            this.textCP.Location = new System.Drawing.Point(297, 68);
            this.textCP.MaxLength = 5;
            this.textCP.Name = "textCP";
            this.textCP.Size = new System.Drawing.Size(47, 20);
            this.textCP.TabIndex = 32;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(150, 91);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 12);
            this.label16.TabIndex = 31;
            this.label16.Text = "Población";
            // 
            // textPoblacion
            // 
            this.textPoblacion.Location = new System.Drawing.Point(151, 68);
            this.textPoblacion.MaxLength = 20;
            this.textPoblacion.Name = "textPoblacion";
            this.textPoblacion.Size = new System.Drawing.Size(137, 20);
            this.textPoblacion.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(7, 91);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 12);
            this.label15.TabIndex = 29;
            this.label15.Text = "Estado";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(258, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 12);
            this.label14.TabIndex = 28;
            this.label14.Text = "Colonia";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(7, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 12);
            this.label13.TabIndex = 27;
            this.label13.Text = "Calle";
            // 
            // textColonia
            // 
            this.textColonia.Location = new System.Drawing.Point(260, 19);
            this.textColonia.MaxLength = 30;
            this.textColonia.Name = "textColonia";
            this.textColonia.Size = new System.Drawing.Size(190, 20);
            this.textColonia.TabIndex = 25;
            // 
            // textEstado
            // 
            this.textEstado.Location = new System.Drawing.Point(6, 68);
            this.textEstado.MaxLength = 20;
            this.textEstado.Name = "textEstado";
            this.textEstado.Size = new System.Drawing.Size(137, 20);
            this.textEstado.TabIndex = 26;
            // 
            // textCalle
            // 
            this.textCalle.Location = new System.Drawing.Point(8, 19);
            this.textCalle.MaxLength = 50;
            this.textCalle.Name = "textCalle";
            this.textCalle.Size = new System.Drawing.Size(246, 20);
            this.textCalle.TabIndex = 24;
            // 
            // grpRegistro
            // 
            this.grpRegistro.Controls.Add(this.label7);
            this.grpRegistro.Controls.Add(this.dtpFechaAlta);
            this.grpRegistro.Controls.Add(this.label9);
            this.grpRegistro.Controls.Add(this.dtpFechaMod);
            this.grpRegistro.Controls.Add(this.cmbPerfil);
            this.grpRegistro.Controls.Add(this.label4);
            this.grpRegistro.Controls.Add(this.cmbEstado);
            this.grpRegistro.Controls.Add(this.label8);
            this.grpRegistro.Location = new System.Drawing.Point(7, 322);
            this.grpRegistro.Name = "grpRegistro";
            this.grpRegistro.Size = new System.Drawing.Size(454, 65);
            this.grpRegistro.TabIndex = 27;
            this.grpRegistro.TabStop = false;
            this.grpRegistro.Text = "Registro";
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(942, 471);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUsuarios";
            this.Load += new System.EventHandler(this.FrmUsuarios_Load);
            this.pnlResumenLista.ResumeLayout(false);
            this.pnlResumenLista.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.spcPrincipal.Panel2.ResumeLayout(false);
            this.spcPrincipal.Panel2.PerformLayout();
            this.spcPrincipal.ResumeLayout(false);
            this.grpClave.ResumeLayout(false);
            this.grpClave.PerformLayout();
            this.grpNombre.ResumeLayout(false);
            this.grpNombre.PerformLayout();
            this.grpDireccion.ResumeLayout(false);
            this.grpDireccion.PerformLayout();
            this.grpRegistro.ResumeLayout(false);
            this.grpRegistro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textClaveDos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textClaveUno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaMod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFechaAlta;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.ComboBox cmbPerfil;
        private System.Windows.Forms.TextBox textMaterno;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textPaterno;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox grpClave;
        private System.Windows.Forms.GroupBox grpNombre;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox grpDireccion;
        private System.Windows.Forms.TextBox textColonia;
        private System.Windows.Forms.TextBox textEstado;
        private System.Windows.Forms.TextBox textCalle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textCP;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textPoblacion;
        private System.Windows.Forms.GroupBox grpRegistro;
    }
}
