namespace Contingencia
{
    partial class FrmArmadoTarimas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmArmadoTarimas));
            this.pnlArmado = new System.Windows.Forms.Panel();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnSigCaja = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.txtbxCont = new System.Windows.Forms.TextBox();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnPrimero = new System.Windows.Forms.Button();
            this.txtbxKilosAcum = new System.Windows.Forms.TextBox();
            this.lblKilosAcum = new System.Windows.Forms.Label();
            this.txtbxCajasAcum = new System.Windows.Forms.TextBox();
            this.lblCajasAcum = new System.Windows.Forms.Label();
            this.txtbxEmbalada = new System.Windows.Forms.TextBox();
            this.lblEmbalada = new System.Windows.Forms.Label();
            this.txtbxLote = new System.Windows.Forms.TextBox();
            this.lblLote = new System.Windows.Forms.Label();
            this.txtbxDenom = new System.Windows.Forms.TextBox();
            this.lblDenom = new System.Windows.Forms.Label();
            this.txtbxMaterial = new System.Windows.Forms.TextBox();
            this.lblMaterial = new System.Windows.Forms.Label();
            this.pbxAlmacen = new System.Windows.Forms.PictureBox();
            this.txtbxAlmacen = new System.Windows.Forms.TextBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.txtbxCaja = new System.Windows.Forms.TextBox();
            this.lblNoCaja = new System.Windows.Forms.Label();
            this.pnlTitArmar = new System.Windows.Forms.Panel();
            this.lblArmar = new System.Windows.Forms.Label();
            this.pnlBase.SuspendLayout();
            this.pnlArmado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlmacen)).BeginInit();
            this.pnlTitArmar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.pnlTitArmar);
            this.pnlBase.Controls.Add(this.pnlArmado);
            this.pnlBase.Size = new System.Drawing.Size(622, 413);
            this.pnlBase.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBase_Paint);
            // 
            // pnlArmado
            // 
            this.pnlArmado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlArmado.Controls.Add(this.btnGenerar);
            this.pnlArmado.Controls.Add(this.btnSigCaja);
            this.pnlArmado.Controls.Add(this.btnVolver);
            this.pnlArmado.Controls.Add(this.txtbxCont);
            this.pnlArmado.Controls.Add(this.btnUltimo);
            this.pnlArmado.Controls.Add(this.btnSiguiente);
            this.pnlArmado.Controls.Add(this.btnAnterior);
            this.pnlArmado.Controls.Add(this.btnPrimero);
            this.pnlArmado.Controls.Add(this.txtbxKilosAcum);
            this.pnlArmado.Controls.Add(this.lblKilosAcum);
            this.pnlArmado.Controls.Add(this.txtbxCajasAcum);
            this.pnlArmado.Controls.Add(this.lblCajasAcum);
            this.pnlArmado.Controls.Add(this.txtbxEmbalada);
            this.pnlArmado.Controls.Add(this.lblEmbalada);
            this.pnlArmado.Controls.Add(this.txtbxLote);
            this.pnlArmado.Controls.Add(this.lblLote);
            this.pnlArmado.Controls.Add(this.txtbxDenom);
            this.pnlArmado.Controls.Add(this.lblDenom);
            this.pnlArmado.Controls.Add(this.txtbxMaterial);
            this.pnlArmado.Controls.Add(this.lblMaterial);
            this.pnlArmado.Controls.Add(this.pbxAlmacen);
            this.pnlArmado.Controls.Add(this.txtbxAlmacen);
            this.pnlArmado.Controls.Add(this.lblAlmacen);
            this.pnlArmado.Controls.Add(this.txtbxCaja);
            this.pnlArmado.Controls.Add(this.lblNoCaja);
            this.pnlArmado.Location = new System.Drawing.Point(24, 21);
            this.pnlArmado.Name = "pnlArmado";
            this.pnlArmado.Size = new System.Drawing.Size(422, 358);
            this.pnlArmado.TabIndex = 0;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(262, 317);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(150, 23);
            this.btnGenerar.TabIndex = 25;
            this.btnGenerar.Text = "Generar Tarima e Imprimir";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnSigCaja
            // 
            this.btnSigCaja.Location = new System.Drawing.Point(6, 316);
            this.btnSigCaja.Name = "btnSigCaja";
            this.btnSigCaja.Size = new System.Drawing.Size(150, 23);
            this.btnSigCaja.TabIndex = 24;
            this.btnSigCaja.Text = "Siguiente Caja";
            this.btnSigCaja.UseVisualStyleBackColor = true;
            this.btnSigCaja.Click += new System.EventHandler(this.btnSigCaja_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(262, 270);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(150, 23);
            this.btnVolver.TabIndex = 23;
            this.btnVolver.Text = "Volver al menú";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // txtbxCont
            // 
            this.txtbxCont.Location = new System.Drawing.Point(139, 272);
            this.txtbxCont.Name = "txtbxCont";
            this.txtbxCont.ReadOnly = true;
            this.txtbxCont.Size = new System.Drawing.Size(27, 20);
            this.txtbxCont.TabIndex = 22;
            this.txtbxCont.Text = "0";
            // 
            // btnUltimo
            // 
            this.btnUltimo.Location = new System.Drawing.Point(96, 270);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(25, 23);
            this.btnUltimo.TabIndex = 21;
            this.btnUltimo.Text = ">|";
            this.btnUltimo.UseVisualStyleBackColor = true;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(65, 270);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(25, 23);
            this.btnSiguiente.TabIndex = 20;
            this.btnSiguiente.Text = ">";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(34, 270);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(25, 23);
            this.btnAnterior.TabIndex = 19;
            this.btnAnterior.Text = "<";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnPrimero
            // 
            this.btnPrimero.Location = new System.Drawing.Point(3, 270);
            this.btnPrimero.Name = "btnPrimero";
            this.btnPrimero.Size = new System.Drawing.Size(25, 23);
            this.btnPrimero.TabIndex = 18;
            this.btnPrimero.Text = "|<";
            this.btnPrimero.UseVisualStyleBackColor = true;
            this.btnPrimero.Click += new System.EventHandler(this.btnPrimero_Click);
            // 
            // txtbxKilosAcum
            // 
            this.txtbxKilosAcum.Location = new System.Drawing.Point(107, 241);
            this.txtbxKilosAcum.Name = "txtbxKilosAcum";
            this.txtbxKilosAcum.ReadOnly = true;
            this.txtbxKilosAcum.Size = new System.Drawing.Size(100, 20);
            this.txtbxKilosAcum.TabIndex = 17;
            this.txtbxKilosAcum.Text = "0.000";
            // 
            // lblKilosAcum
            // 
            this.lblKilosAcum.AutoSize = true;
            this.lblKilosAcum.Location = new System.Drawing.Point(3, 244);
            this.lblKilosAcum.Name = "lblKilosAcum";
            this.lblKilosAcum.Size = new System.Drawing.Size(90, 13);
            this.lblKilosAcum.TabIndex = 16;
            this.lblKilosAcum.Text = "Kilos Acumulados";
            // 
            // txtbxCajasAcum
            // 
            this.txtbxCajasAcum.Location = new System.Drawing.Point(107, 215);
            this.txtbxCajasAcum.Name = "txtbxCajasAcum";
            this.txtbxCajasAcum.ReadOnly = true;
            this.txtbxCajasAcum.Size = new System.Drawing.Size(100, 20);
            this.txtbxCajasAcum.TabIndex = 15;
            this.txtbxCajasAcum.Text = "0.000";
            // 
            // lblCajasAcum
            // 
            this.lblCajasAcum.AutoSize = true;
            this.lblCajasAcum.Location = new System.Drawing.Point(3, 218);
            this.lblCajasAcum.Name = "lblCajasAcum";
            this.lblCajasAcum.Size = new System.Drawing.Size(94, 13);
            this.lblCajasAcum.TabIndex = 14;
            this.lblCajasAcum.Text = "Cajas Acumuladas";
            // 
            // txtbxEmbalada
            // 
            this.txtbxEmbalada.Location = new System.Drawing.Point(107, 161);
            this.txtbxEmbalada.Name = "txtbxEmbalada";
            this.txtbxEmbalada.ReadOnly = true;
            this.txtbxEmbalada.Size = new System.Drawing.Size(100, 20);
            this.txtbxEmbalada.TabIndex = 13;
            this.txtbxEmbalada.Text = "0.000";
            // 
            // lblEmbalada
            // 
            this.lblEmbalada.AutoSize = true;
            this.lblEmbalada.Location = new System.Drawing.Point(3, 164);
            this.lblEmbalada.Name = "lblEmbalada";
            this.lblEmbalada.Size = new System.Drawing.Size(75, 13);
            this.lblEmbalada.TabIndex = 12;
            this.lblEmbalada.Text = "Ctd. embalada";
            // 
            // txtbxLote
            // 
            this.txtbxLote.Location = new System.Drawing.Point(106, 132);
            this.txtbxLote.Name = "txtbxLote";
            this.txtbxLote.ReadOnly = true;
            this.txtbxLote.Size = new System.Drawing.Size(43, 20);
            this.txtbxLote.TabIndex = 11;
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Location = new System.Drawing.Point(3, 135);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(28, 13);
            this.lblLote.TabIndex = 10;
            this.lblLote.Text = "Lote";
            // 
            // txtbxDenom
            // 
            this.txtbxDenom.Location = new System.Drawing.Point(107, 104);
            this.txtbxDenom.Name = "txtbxDenom";
            this.txtbxDenom.ReadOnly = true;
            this.txtbxDenom.Size = new System.Drawing.Size(236, 20);
            this.txtbxDenom.TabIndex = 9;
            this.txtbxDenom.TabStop = false;
            // 
            // lblDenom
            // 
            this.lblDenom.AutoSize = true;
            this.lblDenom.Location = new System.Drawing.Point(3, 107);
            this.lblDenom.Name = "lblDenom";
            this.lblDenom.Size = new System.Drawing.Size(75, 13);
            this.lblDenom.TabIndex = 8;
            this.lblDenom.Text = "Denominación";
            // 
            // txtbxMaterial
            // 
            this.txtbxMaterial.Location = new System.Drawing.Point(106, 78);
            this.txtbxMaterial.Name = "txtbxMaterial";
            this.txtbxMaterial.ReadOnly = true;
            this.txtbxMaterial.Size = new System.Drawing.Size(124, 20);
            this.txtbxMaterial.TabIndex = 7;
            this.txtbxMaterial.TabStop = false;
            // 
            // lblMaterial
            // 
            this.lblMaterial.AutoSize = true;
            this.lblMaterial.Location = new System.Drawing.Point(3, 81);
            this.lblMaterial.Name = "lblMaterial";
            this.lblMaterial.Size = new System.Drawing.Size(44, 13);
            this.lblMaterial.TabIndex = 6;
            this.lblMaterial.Text = "Material";
            // 
            // pbxAlmacen
            // 
            this.pbxAlmacen.Image = ((System.Drawing.Image)(resources.GetObject("pbxAlmacen.Image")));
            this.pbxAlmacen.Location = new System.Drawing.Point(139, 53);
            this.pbxAlmacen.Name = "pbxAlmacen";
            this.pbxAlmacen.Size = new System.Drawing.Size(24, 19);
            this.pbxAlmacen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxAlmacen.TabIndex = 5;
            this.pbxAlmacen.TabStop = false;
            this.pbxAlmacen.Visible = false;
            this.pbxAlmacen.Click += new System.EventHandler(this.pbxAlmacen_Click);
            // 
            // txtbxAlmacen
            // 
            this.txtbxAlmacen.Location = new System.Drawing.Point(106, 52);
            this.txtbxAlmacen.MaxLength = 4;
            this.txtbxAlmacen.Name = "txtbxAlmacen";
            this.txtbxAlmacen.Size = new System.Drawing.Size(36, 20);
            this.txtbxAlmacen.TabIndex = 2;
            this.txtbxAlmacen.Visible = false;
            this.txtbxAlmacen.Enter += new System.EventHandler(this.txtbxAlmacen_Enter);
            this.txtbxAlmacen.Leave += new System.EventHandler(this.txtbxAlmacen_Leave);
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Location = new System.Drawing.Point(3, 55);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(48, 13);
            this.lblAlmacen.TabIndex = 2;
            this.lblAlmacen.Text = "Almacén";
            this.lblAlmacen.Visible = false;
            // 
            // txtbxCaja
            // 
            this.txtbxCaja.Location = new System.Drawing.Point(106, 27);
            this.txtbxCaja.Name = "txtbxCaja";
            this.txtbxCaja.Size = new System.Drawing.Size(124, 20);
            this.txtbxCaja.TabIndex = 1;
            this.txtbxCaja.Enter += new System.EventHandler(this.txtbxCaja_Enter);
            this.txtbxCaja.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbxCaja_KeyUp);
            this.txtbxCaja.Leave += new System.EventHandler(this.txtbxCaja_Leave);
            // 
            // lblNoCaja
            // 
            this.lblNoCaja.AutoSize = true;
            this.lblNoCaja.Location = new System.Drawing.Point(3, 30);
            this.lblNoCaja.Name = "lblNoCaja";
            this.lblNoCaja.Size = new System.Drawing.Size(62, 13);
            this.lblNoCaja.TabIndex = 0;
            this.lblNoCaja.Text = "No. de caja";
            // 
            // pnlTitArmar
            // 
            this.pnlTitArmar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlTitArmar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitArmar.Controls.Add(this.lblArmar);
            this.pnlTitArmar.Location = new System.Drawing.Point(24, 21);
            this.pnlTitArmar.Name = "pnlTitArmar";
            this.pnlTitArmar.Size = new System.Drawing.Size(422, 22);
            this.pnlTitArmar.TabIndex = 0;
            // 
            // lblArmar
            // 
            this.lblArmar.AutoSize = true;
            this.lblArmar.Location = new System.Drawing.Point(5, 4);
            this.lblArmar.Name = "lblArmar";
            this.lblArmar.Size = new System.Drawing.Size(90, 13);
            this.lblArmar.TabIndex = 0;
            this.lblArmar.Text = "ARMAR TARIMA";
            // 
            // FrmArmadoTarimas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 517);
            this.Name = "FrmArmadoTarimas";
            this.Load += new System.EventHandler(this.FrmArmadoTarimas_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmArmadoTarimas_KeyPress);
            this.pnlBase.ResumeLayout(false);
            this.pnlArmado.ResumeLayout(false);
            this.pnlArmado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAlmacen)).EndInit();
            this.pnlTitArmar.ResumeLayout(false);
            this.pnlTitArmar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitArmar;
        private System.Windows.Forms.Label lblArmar;
        private System.Windows.Forms.Panel pnlArmado;
        private System.Windows.Forms.TextBox txtbxCaja;
        private System.Windows.Forms.Label lblNoCaja;
        private System.Windows.Forms.TextBox txtbxAlmacen;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.PictureBox pbxAlmacen;
        private System.Windows.Forms.TextBox txtbxDenom;
        private System.Windows.Forms.Label lblDenom;
        private System.Windows.Forms.TextBox txtbxMaterial;
        private System.Windows.Forms.Label lblMaterial;
        private System.Windows.Forms.TextBox txtbxKilosAcum;
        private System.Windows.Forms.Label lblKilosAcum;
        private System.Windows.Forms.TextBox txtbxCajasAcum;
        private System.Windows.Forms.Label lblCajasAcum;
        private System.Windows.Forms.TextBox txtbxEmbalada;
        private System.Windows.Forms.Label lblEmbalada;
        private System.Windows.Forms.TextBox txtbxLote;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnSigCaja;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtbxCont;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnPrimero;
    }
}