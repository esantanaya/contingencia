namespace Contingencia
{
    partial class FrmAgregarTarima
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
            this.pnlAgregarTarima = new System.Windows.Forms.Panel();
            this.txtbxContCajas = new System.Windows.Forms.TextBox();
            this.lblContCajas = new System.Windows.Forms.Label();
            this.txtbxCaja = new System.Windows.Forms.TextBox();
            this.lblCaja = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtbxTarima = new System.Windows.Forms.TextBox();
            this.lblTarima = new System.Windows.Forms.Label();
            this.pnlTiAgregarTarima = new System.Windows.Forms.Panel();
            this.lblArmar = new System.Windows.Forms.Label();
            this.pnlBase.SuspendLayout();
            this.pnlAgregarTarima.SuspendLayout();
            this.pnlTiAgregarTarima.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.pnlAgregarTarima);
            this.pnlBase.Size = new System.Drawing.Size(497, 307);
            // 
            // pnlAgregarTarima
            // 
            this.pnlAgregarTarima.Controls.Add(this.txtbxContCajas);
            this.pnlAgregarTarima.Controls.Add(this.lblContCajas);
            this.pnlAgregarTarima.Controls.Add(this.txtbxCaja);
            this.pnlAgregarTarima.Controls.Add(this.lblCaja);
            this.pnlAgregarTarima.Controls.Add(this.btnAgregar);
            this.pnlAgregarTarima.Controls.Add(this.txtbxTarima);
            this.pnlAgregarTarima.Controls.Add(this.lblTarima);
            this.pnlAgregarTarima.Controls.Add(this.pnlTiAgregarTarima);
            this.pnlAgregarTarima.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAgregarTarima.Location = new System.Drawing.Point(0, 0);
            this.pnlAgregarTarima.Name = "pnlAgregarTarima";
            this.pnlAgregarTarima.Size = new System.Drawing.Size(497, 307);
            this.pnlAgregarTarima.TabIndex = 0;
            // 
            // txtbxContCajas
            // 
            this.txtbxContCajas.Location = new System.Drawing.Point(206, 112);
            this.txtbxContCajas.Name = "txtbxContCajas";
            this.txtbxContCajas.ReadOnly = true;
            this.txtbxContCajas.Size = new System.Drawing.Size(25, 20);
            this.txtbxContCajas.TabIndex = 7;
            this.txtbxContCajas.TabStop = false;
            // 
            // lblContCajas
            // 
            this.lblContCajas.AutoSize = true;
            this.lblContCajas.Location = new System.Drawing.Point(115, 115);
            this.lblContCajas.Name = "lblContCajas";
            this.lblContCajas.Size = new System.Drawing.Size(87, 13);
            this.lblContCajas.TabIndex = 6;
            this.lblContCajas.Text = "Cajas Restantes:";
            // 
            // txtbxCaja
            // 
            this.txtbxCaja.Location = new System.Drawing.Point(206, 86);
            this.txtbxCaja.Name = "txtbxCaja";
            this.txtbxCaja.ReadOnly = true;
            this.txtbxCaja.Size = new System.Drawing.Size(148, 20);
            this.txtbxCaja.TabIndex = 2;
            this.txtbxCaja.TabStop = false;
            this.txtbxCaja.Enter += new System.EventHandler(this.txtbxCaja_Enter);
            this.txtbxCaja.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbxCaja_KeyUp);
            this.txtbxCaja.Leave += new System.EventHandler(this.txtbxCaja_Leave);
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Location = new System.Drawing.Point(115, 89);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(67, 13);
            this.lblCaja.TabIndex = 4;
            this.lblCaja.Text = "Código Caja:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(228, 191);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(105, 23);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar Tarima";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtbxTarima
            // 
            this.txtbxTarima.Location = new System.Drawing.Point(206, 61);
            this.txtbxTarima.Name = "txtbxTarima";
            this.txtbxTarima.Size = new System.Drawing.Size(148, 20);
            this.txtbxTarima.TabIndex = 1;
            this.txtbxTarima.Enter += new System.EventHandler(this.txtbxTarima_Enter);
            this.txtbxTarima.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbxTarima_KeyUp);
            this.txtbxTarima.Leave += new System.EventHandler(this.txtbxTarima_Leave);
            // 
            // lblTarima
            // 
            this.lblTarima.AutoSize = true;
            this.lblTarima.Location = new System.Drawing.Point(115, 64);
            this.lblTarima.Name = "lblTarima";
            this.lblTarima.Size = new System.Drawing.Size(78, 13);
            this.lblTarima.TabIndex = 1;
            this.lblTarima.Text = "Código Tarima:";
            // 
            // pnlTiAgregarTarima
            // 
            this.pnlTiAgregarTarima.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTiAgregarTarima.Controls.Add(this.lblArmar);
            this.pnlTiAgregarTarima.Location = new System.Drawing.Point(3, 3);
            this.pnlTiAgregarTarima.Name = "pnlTiAgregarTarima";
            this.pnlTiAgregarTarima.Size = new System.Drawing.Size(494, 25);
            this.pnlTiAgregarTarima.TabIndex = 0;
            // 
            // lblArmar
            // 
            this.lblArmar.AutoSize = true;
            this.lblArmar.Location = new System.Drawing.Point(10, 8);
            this.lblArmar.Name = "lblArmar";
            this.lblArmar.Size = new System.Drawing.Size(104, 13);
            this.lblArmar.TabIndex = 1;
            this.lblArmar.Text = "AGREGAR TARIMA";
            // 
            // FrmAgregarTarima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 411);
            this.Name = "FrmAgregarTarima";
            this.Text = "FrmAgregarTarima";
            this.Load += new System.EventHandler(this.FrmAgregarTarima_Load);
            this.pnlBase.ResumeLayout(false);
            this.pnlAgregarTarima.ResumeLayout(false);
            this.pnlAgregarTarima.PerformLayout();
            this.pnlTiAgregarTarima.ResumeLayout(false);
            this.pnlTiAgregarTarima.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAgregarTarima;
        private System.Windows.Forms.Panel pnlTiAgregarTarima;
        private System.Windows.Forms.Label lblArmar;
        private System.Windows.Forms.Label lblTarima;
        private System.Windows.Forms.TextBox txtbxTarima;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtbxCaja;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.TextBox txtbxContCajas;
        private System.Windows.Forms.Label lblContCajas;
    }
}