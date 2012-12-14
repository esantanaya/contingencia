namespace Contingencia
{
    partial class FrmHUProcesarEntrada
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
            this.textNombreCentro = new System.Windows.Forms.TextBox();
            this.picCentros = new System.Windows.Forms.PictureBox();
            this.textCentro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textImpresora = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBascula = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.picBasculas = new System.Windows.Forms.PictureBox();
            this.picImpresora = new System.Windows.Forms.PictureBox();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCentros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBasculas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImpresora)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.picImpresora);
            this.pnlBase.Controls.Add(this.picBasculas);
            this.pnlBase.Controls.Add(this.btnSalir);
            this.pnlBase.Controls.Add(this.btnContinuar);
            this.pnlBase.Controls.Add(this.textBascula);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Controls.Add(this.textImpresora);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.textNombreCentro);
            this.pnlBase.Controls.Add(this.picCentros);
            this.pnlBase.Controls.Add(this.textCentro);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Size = new System.Drawing.Size(441, 234);
            // 
            // textNombreCentro
            // 
            this.textNombreCentro.Location = new System.Drawing.Point(224, 34);
            this.textNombreCentro.Name = "textNombreCentro";
            this.textNombreCentro.ReadOnly = true;
            this.textNombreCentro.Size = new System.Drawing.Size(151, 20);
            this.textNombreCentro.TabIndex = 20;
            this.textNombreCentro.TextChanged += new System.EventHandler(this.textNombreCentro_TextChanged);
            // 
            // picCentros
            // 
            this.picCentros.Image = global::Contingencia.Properties.Resources.Listado;
            this.picCentros.Location = new System.Drawing.Point(194, 36);
            this.picCentros.Name = "picCentros";
            this.picCentros.Size = new System.Drawing.Size(24, 19);
            this.picCentros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCentros.TabIndex = 19;
            this.picCentros.TabStop = false;
            this.picCentros.Click += new System.EventHandler(this.picCentros_Click);
            // 
            // textCentro
            // 
            this.textCentro.AutoCompleteCustomSource.AddRange(new string[] {
            "0R00",
            "0R01"});
            this.textCentro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textCentro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textCentro.Location = new System.Drawing.Point(135, 34);
            this.textCentro.Name = "textCentro";
            this.textCentro.Size = new System.Drawing.Size(57, 20);
            this.textCentro.TabIndex = 1;
            this.textCentro.Enter += new System.EventHandler(this.textCentro_Enter);
            this.textCentro.Leave += new System.EventHandler(this.textCentro_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Centro:";
            // 
            // textImpresora
            // 
            this.textImpresora.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textImpresora.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textImpresora.BackColor = System.Drawing.SystemColors.Window;
            this.textImpresora.Location = new System.Drawing.Point(135, 68);
            this.textImpresora.Name = "textImpresora";
            this.textImpresora.Size = new System.Drawing.Size(240, 20);
            this.textImpresora.TabIndex = 2;
            this.textImpresora.TextChanged += new System.EventHandler(this.textImpresora_TextChanged);
            this.textImpresora.Enter += new System.EventHandler(this.textImpresora_Enter);
            this.textImpresora.Leave += new System.EventHandler(this.textImpresora_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Disp.Salida:";
            // 
            // textBascula
            // 
            this.textBascula.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBascula.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBascula.Location = new System.Drawing.Point(135, 103);
            this.textBascula.Name = "textBascula";
            this.textBascula.Size = new System.Drawing.Size(171, 20);
            this.textBascula.TabIndex = 3;
            this.textBascula.TextChanged += new System.EventHandler(this.textBascula_TextChanged);
            this.textBascula.Enter += new System.EventHandler(this.textBascula_Enter);
            this.textBascula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBascula_KeyPress);
            this.textBascula.Leave += new System.EventHandler(this.textBascula_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Modelo de Báscula:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Gold;
            this.btnSalir.Location = new System.Drawing.Point(221, 156);
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
            this.btnContinuar.Location = new System.Drawing.Point(109, 156);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(83, 23);
            this.btnContinuar.TabIndex = 4;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // picBasculas
            // 
            this.picBasculas.Image = global::Contingencia.Properties.Resources.Listado;
            this.picBasculas.Location = new System.Drawing.Point(312, 104);
            this.picBasculas.Name = "picBasculas";
            this.picBasculas.Size = new System.Drawing.Size(24, 19);
            this.picBasculas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBasculas.TabIndex = 27;
            this.picBasculas.TabStop = false;
            this.picBasculas.Click += new System.EventHandler(this.picBasculas_Click);
            // 
            // picImpresora
            // 
            this.picImpresora.Image = global::Contingencia.Properties.Resources.Listado;
            this.picImpresora.Location = new System.Drawing.Point(381, 72);
            this.picImpresora.Name = "picImpresora";
            this.picImpresora.Size = new System.Drawing.Size(24, 19);
            this.picImpresora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImpresora.TabIndex = 28;
            this.picImpresora.TabStop = false;
            this.picImpresora.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FrmHUProcesarEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 338);
            this.KeyPreview = true;
            this.Name = "FrmHUProcesarEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.FrmHUProcesarEntrada_Activated);
            this.Load += new System.EventHandler(this.FrmHUProcesarEntrada_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmHUProcesarEntrada_KeyUp);
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCentros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBasculas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImpresora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textNombreCentro;
        private System.Windows.Forms.PictureBox picCentros;
        private System.Windows.Forms.TextBox textCentro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBascula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textImpresora;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.PictureBox picBasculas;
        private System.Windows.Forms.PictureBox picImpresora;
    }
}