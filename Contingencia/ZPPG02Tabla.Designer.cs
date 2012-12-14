namespace Contingencia
{
    partial class ZPPG02Tabla
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
            this.dgvFatom = new System.Windows.Forms.DataGridView();
            this.Charg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tatuaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tablaCalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Musculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grasa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chuleta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PesarCabeza = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PesoCabeza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Procesado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMarcarT = new System.Windows.Forms.Button();
            this.btnDesmT = new System.Windows.Forms.Button();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFatom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.btnDesmT);
            this.pnlBase.Controls.Add(this.btnMarcarT);
            this.pnlBase.Controls.Add(this.pictureBox1);
            this.pnlBase.Controls.Add(this.dgvFatom);
            this.pnlBase.Size = new System.Drawing.Size(1121, 339);
            // 
            // dgvFatom
            // 
            this.dgvFatom.AllowUserToAddRows = false;
            this.dgvFatom.AllowUserToDeleteRows = false;
            this.dgvFatom.AllowUserToResizeRows = false;
            this.dgvFatom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFatom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Charg,
            this.fechaReg,
            this.Folio,
            this.Peso,
            this.Tatuaje,
            this.tablaCalidad,
            this.Destino,
            this.DescDestino,
            this.Musculo,
            this.Grasa,
            this.Chuleta,
            this.PesarCabeza,
            this.PesoCabeza,
            this.Procesado});
            this.dgvFatom.Location = new System.Drawing.Point(10, 32);
            this.dgvFatom.Name = "dgvFatom";
            this.dgvFatom.Size = new System.Drawing.Size(1089, 269);
            this.dgvFatom.TabIndex = 0;
            this.dgvFatom.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvFatom_CellBeginEdit);
            this.dgvFatom.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvFatom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvFatom_KeyUp);
            // 
            // Charg
            // 
            this.Charg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Charg.Frozen = true;
            this.Charg.HeaderText = "Lote";
            this.Charg.Name = "Charg";
            this.Charg.ReadOnly = true;
            this.Charg.Width = 53;
            // 
            // fechaReg
            // 
            this.fechaReg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fechaReg.Frozen = true;
            this.fechaReg.HeaderText = "Fecha";
            this.fechaReg.Name = "fechaReg";
            this.fechaReg.ReadOnly = true;
            this.fechaReg.Width = 62;
            // 
            // Folio
            // 
            this.Folio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Folio.Frozen = true;
            this.Folio.HeaderText = "Folio";
            this.Folio.Name = "Folio";
            this.Folio.ReadOnly = true;
            this.Folio.Width = 54;
            // 
            // Peso
            // 
            this.Peso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Peso.Frozen = true;
            this.Peso.HeaderText = "Peso";
            this.Peso.Name = "Peso";
            this.Peso.ReadOnly = true;
            this.Peso.Width = 56;
            // 
            // Tatuaje
            // 
            this.Tatuaje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Tatuaje.Frozen = true;
            this.Tatuaje.HeaderText = "Tatuaje/Proovedor";
            this.Tatuaje.Name = "Tatuaje";
            this.Tatuaje.ReadOnly = true;
            this.Tatuaje.Width = 122;
            // 
            // tablaCalidad
            // 
            this.tablaCalidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.tablaCalidad.Frozen = true;
            this.tablaCalidad.HeaderText = "Calidad";
            this.tablaCalidad.Name = "tablaCalidad";
            this.tablaCalidad.ReadOnly = true;
            this.tablaCalidad.Width = 67;
            // 
            // Destino
            // 
            this.Destino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Destino.Frozen = true;
            this.Destino.HeaderText = "Destino";
            this.Destino.Name = "Destino";
            this.Destino.Width = 68;
            // 
            // DescDestino
            // 
            this.DescDestino.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DescDestino.Frozen = true;
            this.DescDestino.HeaderText = "Descrip. destino";
            this.DescDestino.Name = "DescDestino";
            this.DescDestino.ReadOnly = true;
            this.DescDestino.Width = 99;
            // 
            // Musculo
            // 
            this.Musculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Musculo.Frozen = true;
            this.Musculo.HeaderText = "Músculo";
            this.Musculo.Name = "Musculo";
            this.Musculo.ReadOnly = true;
            this.Musculo.Width = 72;
            // 
            // Grasa
            // 
            this.Grasa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Grasa.Frozen = true;
            this.Grasa.HeaderText = "Grasa";
            this.Grasa.Name = "Grasa";
            this.Grasa.ReadOnly = true;
            this.Grasa.Width = 60;
            // 
            // Chuleta
            // 
            this.Chuleta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Chuleta.Frozen = true;
            this.Chuleta.HeaderText = "Chuleta";
            this.Chuleta.Name = "Chuleta";
            this.Chuleta.ReadOnly = true;
            this.Chuleta.Width = 68;
            // 
            // PesarCabeza
            // 
            this.PesarCabeza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PesarCabeza.Frozen = true;
            this.PesarCabeza.HeaderText = "Pesar Cabeza";
            this.PesarCabeza.Name = "PesarCabeza";
            this.PesarCabeza.ReadOnly = true;
            this.PesarCabeza.Width = 71;
            // 
            // PesoCabeza
            // 
            this.PesoCabeza.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PesoCabeza.Frozen = true;
            this.PesoCabeza.HeaderText = "Peso Cabeza";
            this.PesoCabeza.Name = "PesoCabeza";
            this.PesoCabeza.ReadOnly = true;
            this.PesoCabeza.Width = 88;
            // 
            // Procesado
            // 
            this.Procesado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Procesado.Frozen = true;
            this.Procesado.HeaderText = "Procesado";
            this.Procesado.Name = "Procesado";
            this.Procesado.ReadOnly = true;
            this.Procesado.Width = 83;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Contingencia.Properties.Resources.Listado;
            this.pictureBox1.Location = new System.Drawing.Point(12, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnMarcarT
            // 
            this.btnMarcarT.Location = new System.Drawing.Point(57, 3);
            this.btnMarcarT.Name = "btnMarcarT";
            this.btnMarcarT.Size = new System.Drawing.Size(100, 23);
            this.btnMarcarT.TabIndex = 2;
            this.btnMarcarT.Text = "Marcar Todo";
            this.btnMarcarT.UseVisualStyleBackColor = true;
            this.btnMarcarT.Click += new System.EventHandler(this.btnMarcarT_Click);
            // 
            // btnDesmT
            // 
            this.btnDesmT.Location = new System.Drawing.Point(176, 3);
            this.btnDesmT.Name = "btnDesmT";
            this.btnDesmT.Size = new System.Drawing.Size(100, 23);
            this.btnDesmT.TabIndex = 3;
            this.btnDesmT.Text = "Desmarcar Todo";
            this.btnDesmT.UseVisualStyleBackColor = true;
            this.btnDesmT.Click += new System.EventHandler(this.btnDesmT_Click);
            // 
            // ZPPG02Tabla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 443);
            this.KeyPreview = true;
            this.Name = "ZPPG02Tabla";
            this.Load += new System.EventHandler(this.ZPPG02Tabla_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ZPPG02Tabla_KeyUp);
            this.pnlBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFatom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFatom;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDesmT;
        private System.Windows.Forms.Button btnMarcarT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Charg;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tatuaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn tablaCalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destino;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn Musculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grasa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chuleta;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PesarCabeza;
        private System.Windows.Forms.DataGridViewTextBoxColumn PesoCabeza;
        private System.Windows.Forms.DataGridViewTextBoxColumn Procesado;
    }
}