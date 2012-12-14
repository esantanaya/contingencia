namespace Contingencia
{
    partial class FrmZPPG03
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtbxPeso = new System.Windows.Forms.TextBox();
            this.txtbxTara = new System.Windows.Forms.TextBox();
            this.txtbxFolio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.dgvLista);
            this.pnlBase.Controls.Add(this.btnSalir);
            this.pnlBase.Controls.Add(this.btnGrabar);
            this.pnlBase.Controls.Add(this.dtpFecha);
            this.pnlBase.Controls.Add(this.txtbxPeso);
            this.pnlBase.Controls.Add(this.txtbxTara);
            this.pnlBase.Controls.Add(this.txtbxFolio);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Size = new System.Drawing.Size(799, 426);
            // 
            // dgvLista
            // 
            this.dgvLista.AllowUserToAddRows = false;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Folio,
            this.Peso});
            this.dgvLista.Location = new System.Drawing.Point(417, 14);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(294, 413);
            this.dgvLista.TabIndex = 25;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 62;
            // 
            // Folio
            // 
            this.Folio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Folio.HeaderText = "Folio";
            this.Folio.Name = "Folio";
            this.Folio.Width = 54;
            // 
            // Peso
            // 
            this.Peso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Peso.HeaderText = "Peso";
            this.Peso.Name = "Peso";
            this.Peso.Width = 56;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(180, 120);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(118, 22);
            this.btnSalir.TabIndex = 24;
            this.btnSalir.TabStop = false;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.button2_Click);
            this.btnSalir.Enter += new System.EventHandler(this.btnSalir_Enter);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(27, 120);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(129, 22);
            this.btnGrabar.TabIndex = 22;
            this.btnGrabar.TabStop = false;
            this.btnGrabar.Text = "Grabar Folio";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(111, 32);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(84, 20);
            this.dtpFecha.TabIndex = 15;
            this.dtpFecha.TabStop = false;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // txtbxPeso
            // 
            this.txtbxPeso.Location = new System.Drawing.Point(111, 58);
            this.txtbxPeso.Name = "txtbxPeso";
            this.txtbxPeso.Size = new System.Drawing.Size(84, 20);
            this.txtbxPeso.TabIndex = 2;
            this.txtbxPeso.Enter += new System.EventHandler(this.txtbxPeso_Enter);
            this.txtbxPeso.Leave += new System.EventHandler(this.txtbxPeso_Leave);
            // 
            // txtbxTara
            // 
            this.txtbxTara.Location = new System.Drawing.Point(270, 58);
            this.txtbxTara.Name = "txtbxTara";
            this.txtbxTara.Size = new System.Drawing.Size(88, 20);
            this.txtbxTara.TabIndex = 3;
            this.txtbxTara.Enter += new System.EventHandler(this.txtbxTara_Enter);
            this.txtbxTara.Leave += new System.EventHandler(this.txtbxTara_Leave);
            // 
            // txtbxFolio
            // 
            this.txtbxFolio.Location = new System.Drawing.Point(270, 31);
            this.txtbxFolio.Name = "txtbxFolio";
            this.txtbxFolio.Size = new System.Drawing.Size(88, 20);
            this.txtbxFolio.TabIndex = 1;
            this.txtbxFolio.TabStop = false;
            this.txtbxFolio.TextChanged += new System.EventHandler(this.txtbxFolio_TextChanged);
            this.txtbxFolio.Enter += new System.EventHandler(this.txtbxFolio_Enter);
            this.txtbxFolio.Leave += new System.EventHandler(this.txtbxFolio_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Fecha de Folio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Peso Cabeza";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tara";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Folio";
            // 
            // FrmZPPG03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 530);
            this.KeyPreview = true;
            this.Name = "FrmZPPG03";
            this.Load += new System.EventHandler(this.FrmZPPG03_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmZPPG03_KeyUp);
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtbxPeso;
        private System.Windows.Forms.TextBox txtbxTara;
        private System.Windows.Forms.TextBox txtbxFolio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso;
    }
}