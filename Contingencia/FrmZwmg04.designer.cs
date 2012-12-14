namespace Contingencia
{
    partial class FrmZwmg04
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
            this.pnlBase.Controls.Add(this.btnSalir);
            this.pnlBase.Controls.Add(this.btnContinuar);
            this.pnlBase.Controls.Add(this.textNombreCentro);
            this.pnlBase.Controls.Add(this.picCentros);
            this.pnlBase.Controls.Add(this.textEntrega);
            this.pnlBase.Controls.Add(this.textCentro);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Size = new System.Drawing.Size(471, 225);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Gold;
            this.btnSalir.Location = new System.Drawing.Point(250, 121);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(71, 23);
            this.btnSalir.TabIndex = 26;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.Gold;
            this.btnContinuar.Location = new System.Drawing.Point(138, 121);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(83, 23);
            this.btnContinuar.TabIndex = 25;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // textNombreCentro
            // 
            this.textNombreCentro.Location = new System.Drawing.Point(206, 34);
            this.textNombreCentro.Name = "textNombreCentro";
            this.textNombreCentro.ReadOnly = true;
            this.textNombreCentro.Size = new System.Drawing.Size(151, 20);
            this.textNombreCentro.TabIndex = 24;
            // 
            // picCentros
            // 
            this.picCentros.Image = global::Contingencia.Properties.Resources.Listado;
            this.picCentros.Location = new System.Drawing.Point(176, 33);
            this.picCentros.Name = "picCentros";
            this.picCentros.Size = new System.Drawing.Size(24, 19);
            this.picCentros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCentros.TabIndex = 23;
            this.picCentros.TabStop = false;
            this.picCentros.Click += new System.EventHandler(this.picCentros_Click);
            // 
            // textEntrega
            // 
            this.textEntrega.Location = new System.Drawing.Point(117, 59);
            this.textEntrega.Name = "textEntrega";
            this.textEntrega.Size = new System.Drawing.Size(104, 20);
            this.textEntrega.TabIndex = 22;
            this.textEntrega.Click += new System.EventHandler(this.textEntrega_Enter);
            this.textEntrega.Enter += new System.EventHandler(this.textEntrega_Enter);
            this.textEntrega.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEntrega_KeyPress);
            this.textEntrega.Leave += new System.EventHandler(this.textEntrega_Leave);
            // 
            // textCentro
            // 
            this.textCentro.Location = new System.Drawing.Point(117, 31);
            this.textCentro.Name = "textCentro";
            this.textCentro.Size = new System.Drawing.Size(57, 20);
            this.textCentro.TabIndex = 21;
            this.textCentro.Enter += new System.EventHandler(this.textCentro_Enter);
            this.textCentro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCentro_KeyPress);
            this.textCentro.Leave += new System.EventHandler(this.textCentro_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Entrega:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Centro:";
            // 
            // FrmZwmg04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 329);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmZwmg04";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Tarimas a Entrega";
            this.Activated += new System.EventHandler(this.FrmZwmg04_Activated);
            this.Load += new System.EventHandler(this.FrmZwmg04_Load);
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCentros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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