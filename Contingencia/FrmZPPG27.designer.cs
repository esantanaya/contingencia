namespace Contingencia
{
    partial class FrmZPPG27
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
            this.pnlParametros = new System.Windows.Forms.Panel();
            this.textCaja = new System.Windows.Forms.TextBox();
            this.lblCaja = new System.Windows.Forms.Label();
            this.textAlmacen = new System.Windows.Forms.TextBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.textCentro = new System.Windows.Forms.TextBox();
            this.lblCentro = new System.Windows.Forms.Label();
            this.pnlTitParametros = new System.Windows.Forms.Panel();
            this.lblParametros = new System.Windows.Forms.Label();
            this.pnlLista = new System.Windows.Forms.Panel();
            this.textTotalCajas = new System.Windows.Forms.TextBox();
            this.pctbxEliminar = new System.Windows.Forms.PictureBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.Caja1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTitLista = new System.Windows.Forms.Label();
            this.btnResfrescar = new System.Windows.Forms.Button();
            this.pnlBase.SuspendLayout();
            this.pnlParametros.SuspendLayout();
            this.pnlTitParametros.SuspendLayout();
            this.pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlBase.Controls.Add(this.btnResfrescar);
            this.pnlBase.Controls.Add(this.pnlLista);
            this.pnlBase.Controls.Add(this.pnlTitParametros);
            this.pnlBase.Controls.Add(this.pnlParametros);
            this.pnlBase.Size = new System.Drawing.Size(666, 449);
            // 
            // pnlParametros
            // 
            this.pnlParametros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlParametros.Controls.Add(this.textCaja);
            this.pnlParametros.Controls.Add(this.lblCaja);
            this.pnlParametros.Controls.Add(this.textAlmacen);
            this.pnlParametros.Controls.Add(this.lblAlmacen);
            this.pnlParametros.Controls.Add(this.textCentro);
            this.pnlParametros.Controls.Add(this.lblCentro);
            this.pnlParametros.Location = new System.Drawing.Point(9, 3);
            this.pnlParametros.Name = "pnlParametros";
            this.pnlParametros.Size = new System.Drawing.Size(200, 100);
            this.pnlParametros.TabIndex = 0;
            // 
            // textCaja
            // 
            this.textCaja.Location = new System.Drawing.Point(97, 65);
            this.textCaja.Name = "textCaja";
            this.textCaja.Size = new System.Drawing.Size(100, 20);
            this.textCaja.TabIndex = 3;
            this.textCaja.Enter += new System.EventHandler(this.txtbxcaja_Enter);
            this.textCaja.Leave += new System.EventHandler(this.txtbxcaja_Leave);
            this.textCaja.Validated += new System.EventHandler(this.txtbxCaja_Finish);
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(6, 68);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(28, 13);
            this.lblCaja.TabIndex = 1;
            this.lblCaja.Text = "Caja";
            // 
            // textAlmacen
            // 
            this.textAlmacen.Location = new System.Drawing.Point(97, 42);
            this.textAlmacen.Name = "textAlmacen";
            this.textAlmacen.Size = new System.Drawing.Size(36, 20);
            this.textAlmacen.TabIndex = 2;
            this.textAlmacen.Enter += new System.EventHandler(this.textAlmacen_Enter);
            this.textAlmacen.Leave += new System.EventHandler(this.textAlmacen_Leave);
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Location = new System.Drawing.Point(6, 45);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(87, 13);
            this.lblAlmacen.TabIndex = 2;
            this.lblAlmacen.Text = "Almacén Destino";
            // 
            // textCentro
            // 
            this.textCentro.Location = new System.Drawing.Point(97, 20);
            this.textCentro.Name = "textCentro";
            this.textCentro.Size = new System.Drawing.Size(36, 20);
            this.textCentro.TabIndex = 1;
            this.textCentro.Enter += new System.EventHandler(this.textCentro_Enter);
            this.textCentro.Leave += new System.EventHandler(this.textCentro_Leave);
            // 
            // lblCentro
            // 
            this.lblCentro.AutoSize = true;
            this.lblCentro.Location = new System.Drawing.Point(5, 23);
            this.lblCentro.Name = "lblCentro";
            this.lblCentro.Size = new System.Drawing.Size(77, 13);
            this.lblCentro.TabIndex = 1;
            this.lblCentro.Text = "Centro Destino";
            // 
            // pnlTitParametros
            // 
            this.pnlTitParametros.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTitParametros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitParametros.Controls.Add(this.lblParametros);
            this.pnlTitParametros.Location = new System.Drawing.Point(10, 3);
            this.pnlTitParametros.Name = "pnlTitParametros";
            this.pnlTitParametros.Size = new System.Drawing.Size(199, 18);
            this.pnlTitParametros.TabIndex = 0;
            // 
            // lblParametros
            // 
            this.lblParametros.AutoSize = true;
            this.lblParametros.Location = new System.Drawing.Point(5, 2);
            this.lblParametros.Name = "lblParametros";
            this.lblParametros.Size = new System.Drawing.Size(60, 13);
            this.lblParametros.TabIndex = 0;
            this.lblParametros.Text = "Parámetros";
            // 
            // pnlLista
            // 
            this.pnlLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLista.Controls.Add(this.textTotalCajas);
            this.pnlLista.Controls.Add(this.pctbxEliminar);
            this.pnlLista.Controls.Add(this.lblTotal);
            this.pnlLista.Controls.Add(this.dgvLista);
            this.pnlLista.Controls.Add(this.panel3);
            this.pnlLista.Location = new System.Drawing.Point(213, 3);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Size = new System.Drawing.Size(201, 421);
            this.pnlLista.TabIndex = 1;
            // 
            // textTotalCajas
            // 
            this.textTotalCajas.Location = new System.Drawing.Point(60, 390);
            this.textTotalCajas.Name = "textTotalCajas";
            this.textTotalCajas.ReadOnly = true;
            this.textTotalCajas.Size = new System.Drawing.Size(40, 20);
            this.textTotalCajas.TabIndex = 3;
            this.textTotalCajas.TabStop = false;
            this.textTotalCajas.Text = "0";
            // 
            // pctbxEliminar
            // 
            this.pctbxEliminar.Image = global::Contingencia.Properties.Resources.Eliminar1;
            this.pctbxEliminar.Location = new System.Drawing.Point(167, 20);
            this.pctbxEliminar.Name = "pctbxEliminar";
            this.pctbxEliminar.Size = new System.Drawing.Size(29, 20);
            this.pctbxEliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbxEliminar.TabIndex = 2;
            this.pctbxEliminar.TabStop = false;
            this.pctbxEliminar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pctbxEliminar_MouseClick);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(8, 393);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(46, 13);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "T. Cajas";
            // 
            // dgvLista
            // 
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Caja1});
            this.dgvLista.Location = new System.Drawing.Point(2, 19);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(144, 343);
            this.dgvLista.TabIndex = 1;
            // 
            // Caja1
            // 
            this.Caja1.Frozen = true;
            this.Caja1.HeaderText = "Caja";
            this.Caja1.Name = "Caja1";
            this.Caja1.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblTitLista);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(261, 18);
            this.panel3.TabIndex = 0;
            // 
            // lblTitLista
            // 
            this.lblTitLista.AutoSize = true;
            this.lblTitLista.Location = new System.Drawing.Point(7, 2);
            this.lblTitLista.Name = "lblTitLista";
            this.lblTitLista.Size = new System.Drawing.Size(184, 13);
            this.lblTitLista.TabIndex = 0;
            this.lblTitLista.Text = "Unidades de manipulación a trasladar";
            // 
            // btnResfrescar
            // 
            this.btnResfrescar.Location = new System.Drawing.Point(68, 394);
            this.btnResfrescar.Name = "btnResfrescar";
            this.btnResfrescar.Size = new System.Drawing.Size(75, 23);
            this.btnResfrescar.TabIndex = 4;
            this.btnResfrescar.Text = "Refrescar";
            this.btnResfrescar.UseVisualStyleBackColor = true;
            this.btnResfrescar.Click += new System.EventHandler(this.btnResfrescar_Click);
            // 
            // FrmZPPG27
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 553);
            this.KeyPreview = true;
            this.Name = "FrmZPPG27";
            this.Activated += new System.EventHandler(this.FrmZPPG27_Activated);
            this.Load += new System.EventHandler(this.FrmZPPG27_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmZPPG27_KeyUp);
            this.pnlBase.ResumeLayout(false);
            this.pnlParametros.ResumeLayout(false);
            this.pnlParametros.PerformLayout();
            this.pnlTitParametros.ResumeLayout(false);
            this.pnlTitParametros.PerformLayout();
            this.pnlLista.ResumeLayout(false);
            this.pnlLista.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlLista;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTitLista;
        private System.Windows.Forms.Panel pnlTitParametros;
        private System.Windows.Forms.Label lblParametros;
        private System.Windows.Forms.Panel pnlParametros;
        private System.Windows.Forms.TextBox textCaja;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.TextBox textAlmacen;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.TextBox textCentro;
        private System.Windows.Forms.Label lblCentro;
        private System.Windows.Forms.PictureBox pctbxEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Caja1;
        private System.Windows.Forms.Button btnResfrescar;
        private System.Windows.Forms.TextBox textTotalCajas;
        private System.Windows.Forms.Label lblTotal;
    }
}