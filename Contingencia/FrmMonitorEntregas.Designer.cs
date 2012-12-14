namespace Contingencia
{
    partial class FrmMonitorEntregas
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
            this.rdbRemision = new System.Windows.Forms.RadioButton();
            this.rdbProducto = new System.Windows.Forms.RadioButton();
            this.rdbCanal = new System.Windows.Forms.RadioButton();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.textNombreCentro = new System.Windows.Forms.TextBox();
            this.picCentros = new System.Windows.Forms.PictureBox();
            this.textEntrega = new System.Windows.Forms.TextBox();
            this.textCentro = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCentros)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.rdbRemision);
            this.pnlBase.Controls.Add(this.rdbProducto);
            this.pnlBase.Controls.Add(this.rdbCanal);
            this.pnlBase.Controls.Add(this.btnSalir);
            this.pnlBase.Controls.Add(this.btnContinuar);
            this.pnlBase.Controls.Add(this.textNombreCentro);
            this.pnlBase.Controls.Add(this.picCentros);
            this.pnlBase.Controls.Add(this.textEntrega);
            this.pnlBase.Controls.Add(this.textCentro);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Size = new System.Drawing.Size(586, 210);
            // 
            // rdbRemision
            // 
            this.rdbRemision.AutoSize = true;
            this.rdbRemision.Location = new System.Drawing.Point(413, 95);
            this.rdbRemision.Name = "rdbRemision";
            this.rdbRemision.Size = new System.Drawing.Size(83, 20);
            this.rdbRemision.TabIndex = 21;
            this.rdbRemision.Text = "Remisión";
            this.rdbRemision.UseVisualStyleBackColor = true;
            // 
            // rdbProducto
            // 
            this.rdbProducto.AutoSize = true;
            this.rdbProducto.Location = new System.Drawing.Point(413, 69);
            this.rdbProducto.Name = "rdbProducto";
            this.rdbProducto.Size = new System.Drawing.Size(80, 20);
            this.rdbProducto.TabIndex = 20;
            this.rdbProducto.Text = "Producto";
            this.rdbProducto.UseVisualStyleBackColor = true;
            // 
            // rdbCanal
            // 
            this.rdbCanal.AutoSize = true;
            this.rdbCanal.Checked = true;
            this.rdbCanal.Location = new System.Drawing.Point(413, 43);
            this.rdbCanal.Name = "rdbCanal";
            this.rdbCanal.Size = new System.Drawing.Size(61, 20);
            this.rdbCanal.TabIndex = 19;
            this.rdbCanal.TabStop = true;
            this.rdbCanal.Text = "Canal";
            this.rdbCanal.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Gold;
            this.btnSalir.Location = new System.Drawing.Point(231, 119);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(71, 23);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.Gold;
            this.btnContinuar.Location = new System.Drawing.Point(119, 119);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(83, 23);
            this.btnContinuar.TabIndex = 17;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // textNombreCentro
            // 
            this.textNombreCentro.Location = new System.Drawing.Point(187, 32);
            this.textNombreCentro.Name = "textNombreCentro";
            this.textNombreCentro.ReadOnly = true;
            this.textNombreCentro.Size = new System.Drawing.Size(151, 22);
            this.textNombreCentro.TabIndex = 16;
            // 
            // picCentros
            // 
            this.picCentros.Image = global::Contingencia.Properties.Resources.Listado;
            this.picCentros.Location = new System.Drawing.Point(157, 31);
            this.picCentros.Name = "picCentros";
            this.picCentros.Size = new System.Drawing.Size(24, 19);
            this.picCentros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCentros.TabIndex = 15;
            this.picCentros.TabStop = false;
            this.picCentros.Click += new System.EventHandler(this.picCentros_Click);
            // 
            // textEntrega
            // 
            this.textEntrega.Location = new System.Drawing.Point(98, 57);
            this.textEntrega.Name = "textEntrega";
            this.textEntrega.Size = new System.Drawing.Size(104, 22);
            this.textEntrega.TabIndex = 14;
            this.textEntrega.Enter += new System.EventHandler(this.textEntrega_Enter);
            this.textEntrega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEntrega_KeyPress);
            this.textEntrega.Leave += new System.EventHandler(this.textEntrega_Leave);
            // 
            // textCentro
            // 
            this.textCentro.Location = new System.Drawing.Point(98, 29);
            this.textCentro.Name = "textCentro";
            this.textCentro.Size = new System.Drawing.Size(57, 22);
            this.textCentro.TabIndex = 13;
            this.textCentro.Enter += new System.EventHandler(this.textCentro_Enter);
            this.textCentro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCentro_KeyPress);
            this.textCentro.Leave += new System.EventHandler(this.textCentro_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Entrega:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Centro:";
            // 
            // FrmMonitorEntregas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 314);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMonitorEntregas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.FrmMonitorEntregas_Activated);
            this.Load += new System.EventHandler(this.FrmMonitorEntregas_Load);
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCentros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbRemision;
        private System.Windows.Forms.RadioButton rdbProducto;
        private System.Windows.Forms.RadioButton rdbCanal;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.TextBox textNombreCentro;
        private System.Windows.Forms.PictureBox picCentros;
        private System.Windows.Forms.TextBox textEntrega;
        private System.Windows.Forms.TextBox textCentro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}