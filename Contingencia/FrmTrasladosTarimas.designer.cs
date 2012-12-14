namespace Contingencia
{
    partial class FrmTrasladosTarimas
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
            this.textTarima = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textCentro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.textAlmacen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUbicación = new System.Windows.Forms.Label();
            this.textUbicacionDestino = new System.Windows.Forms.TextBox();
            this.pbxCentro = new System.Windows.Forms.PictureBox();
            this.pbxAlmacen = new System.Windows.Forms.PictureBox();
            this.pbxUbicacion = new System.Windows.Forms.PictureBox();
            this.lblTipoAlmacen = new System.Windows.Forms.Label();
            this.txtbxTipoAlmacen = new System.Windows.Forms.TextBox();
            this.pctbxTipoAlmacen = new System.Windows.Forms.PictureBox();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCentro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUbicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxTipoAlmacen)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.pctbxTipoAlmacen);
            this.pnlBase.Controls.Add(this.txtbxTipoAlmacen);
            this.pnlBase.Controls.Add(this.lblTipoAlmacen);
            this.pnlBase.Controls.Add(this.pbxUbicacion);
            this.pnlBase.Controls.Add(this.pbxAlmacen);
            this.pnlBase.Controls.Add(this.pbxCentro);
            this.pnlBase.Controls.Add(this.textUbicacionDestino);
            this.pnlBase.Controls.Add(this.lblUbicación);
            this.pnlBase.Controls.Add(this.btnSalir);
            this.pnlBase.Controls.Add(this.btnContinuar);
            this.pnlBase.Controls.Add(this.textAlmacen);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Controls.Add(this.textCentro);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Controls.Add(this.textTarima);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBase.Size = new System.Drawing.Size(501, 337);
            // 
            // textTarima
            // 
            this.textTarima.Location = new System.Drawing.Point(156, 29);
            this.textTarima.Margin = new System.Windows.Forms.Padding(4);
            this.textTarima.Name = "textTarima";
            this.textTarima.Size = new System.Drawing.Size(163, 22);
            this.textTarima.TabIndex = 5;
            this.textTarima.Enter += new System.EventHandler(this.textTarima_Enter);
            this.textTarima.Leave += new System.EventHandler(this.textTarima_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tarima:";
            // 
            // textCentro
            // 
            this.textCentro.Location = new System.Drawing.Point(156, 66);
            this.textCentro.Name = "textCentro";
            this.textCentro.Size = new System.Drawing.Size(57, 22);
            this.textCentro.TabIndex = 6;
            this.textCentro.Enter += new System.EventHandler(this.textCentro_Enter);
            this.textCentro.Leave += new System.EventHandler(this.textCentro_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Centro destino:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Gold;
            this.btnSalir.Location = new System.Drawing.Point(266, 212);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(195, 23);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.Gold;
            this.btnContinuar.Location = new System.Drawing.Point(45, 212);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(195, 23);
            this.btnContinuar.TabIndex = 9;
            this.btnContinuar.Text = "Crear pedido de traslado";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // textAlmacen
            // 
            this.textAlmacen.Location = new System.Drawing.Point(156, 130);
            this.textAlmacen.Name = "textAlmacen";
            this.textAlmacen.Size = new System.Drawing.Size(104, 22);
            this.textAlmacen.TabIndex = 7;
            this.textAlmacen.Enter += new System.EventHandler(this.textAlmacen_Enter);
            this.textAlmacen.Leave += new System.EventHandler(this.textAlmacen_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "Almacén destino:";
            // 
            // lblUbicación
            // 
            this.lblUbicación.AutoSize = true;
            this.lblUbicación.Location = new System.Drawing.Point(36, 169);
            this.lblUbicación.Name = "lblUbicación";
            this.lblUbicación.Size = new System.Drawing.Size(119, 16);
            this.lblUbicación.TabIndex = 24;
            this.lblUbicación.Text = "Ubicación destino:";
            // 
            // textUbicacionDestino
            // 
            this.textUbicacionDestino.Location = new System.Drawing.Point(156, 166);
            this.textUbicacionDestino.Name = "textUbicacionDestino";
            this.textUbicacionDestino.Size = new System.Drawing.Size(104, 22);
            this.textUbicacionDestino.TabIndex = 8;
            this.textUbicacionDestino.Enter += new System.EventHandler(this.textUbicacion_Enter);
            this.textUbicacionDestino.Leave += new System.EventHandler(this.textUbicacion_Leave);
            // 
            // pbxCentro
            // 
            this.pbxCentro.Image = global::Contingencia.Properties.Resources.Listado;
            this.pbxCentro.Location = new System.Drawing.Point(219, 69);
            this.pbxCentro.Name = "pbxCentro";
            this.pbxCentro.Size = new System.Drawing.Size(24, 19);
            this.pbxCentro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCentro.TabIndex = 25;
            this.pbxCentro.TabStop = false;
            this.pbxCentro.Click += new System.EventHandler(this.pbxCentro_Click);
            // 
            // pbxAlmacen
            // 
            this.pbxAlmacen.Image = global::Contingencia.Properties.Resources.Listado;
            this.pbxAlmacen.Location = new System.Drawing.Point(266, 133);
            this.pbxAlmacen.Name = "pbxAlmacen";
            this.pbxAlmacen.Size = new System.Drawing.Size(24, 19);
            this.pbxAlmacen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAlmacen.TabIndex = 26;
            this.pbxAlmacen.TabStop = false;
            this.pbxAlmacen.Click += new System.EventHandler(this.pbxAlmacen_Click);
            // 
            // pbxUbicacion
            // 
            this.pbxUbicacion.Image = global::Contingencia.Properties.Resources.Listado;
            this.pbxUbicacion.Location = new System.Drawing.Point(266, 169);
            this.pbxUbicacion.Name = "pbxUbicacion";
            this.pbxUbicacion.Size = new System.Drawing.Size(24, 19);
            this.pbxUbicacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxUbicacion.TabIndex = 27;
            this.pbxUbicacion.TabStop = false;
            this.pbxUbicacion.Click += new System.EventHandler(this.pbxUbicacion_Click);
            // 
            // lblTipoAlmacen
            // 
            this.lblTipoAlmacen.AutoSize = true;
            this.lblTipoAlmacen.Location = new System.Drawing.Point(36, 100);
            this.lblTipoAlmacen.Name = "lblTipoAlmacen";
            this.lblTipoAlmacen.Size = new System.Drawing.Size(114, 16);
            this.lblTipoAlmacen.TabIndex = 28;
            this.lblTipoAlmacen.Text = "Tipo de Almacen:";
            // 
            // txtbxTipoAlmacen
            // 
            this.txtbxTipoAlmacen.Location = new System.Drawing.Point(156, 97);
            this.txtbxTipoAlmacen.Name = "txtbxTipoAlmacen";
            this.txtbxTipoAlmacen.Size = new System.Drawing.Size(45, 22);
            this.txtbxTipoAlmacen.TabIndex = 29;
            // 
            // pctbxTipoAlmacen
            // 
            this.pctbxTipoAlmacen.Image = global::Contingencia.Properties.Resources.Listado;
            this.pctbxTipoAlmacen.Location = new System.Drawing.Point(207, 97);
            this.pctbxTipoAlmacen.Name = "pctbxTipoAlmacen";
            this.pctbxTipoAlmacen.Size = new System.Drawing.Size(24, 19);
            this.pctbxTipoAlmacen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbxTipoAlmacen.TabIndex = 30;
            this.pctbxTipoAlmacen.TabStop = false;
            this.pctbxTipoAlmacen.Click += new System.EventHandler(this.pctbxTipoAlmacen_Click);
            // 
            // FrmTrasladosTarimas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 441);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmTrasladosTarimas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.FrmTrasladosTarimas_Activated);
            this.Load += new System.EventHandler(this.FrmTrasladosTarimas_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmTrasladosTarimas_KeyUp);
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCentro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUbicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxTipoAlmacen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textTarima;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCentro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.TextBox textAlmacen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textUbicacionDestino;
        private System.Windows.Forms.Label lblUbicación;
        private System.Windows.Forms.PictureBox pbxCentro;
        private System.Windows.Forms.PictureBox pbxAlmacen;
        private System.Windows.Forms.PictureBox pbxUbicacion;
        private System.Windows.Forms.PictureBox pctbxTipoAlmacen;
        private System.Windows.Forms.TextBox txtbxTipoAlmacen;
        private System.Windows.Forms.Label lblTipoAlmacen;
    }
}