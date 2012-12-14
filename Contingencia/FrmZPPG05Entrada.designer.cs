namespace Contingencia
{
    partial class FrmZPPG05Entrada
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
            this.lblCentro = new System.Windows.Forms.Label();
            this.txtbxCentro = new System.Windows.Forms.TextBox();
            this.pctbxCentro = new System.Windows.Forms.PictureBox();
            this.lblBascula = new System.Windows.Forms.Label();
            this.txtbxBascula = new System.Windows.Forms.TextBox();
            this.pbxBascula = new System.Windows.Forms.PictureBox();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxCentro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBascula)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlBase.Controls.Add(this.btnSalir);
            this.pnlBase.Controls.Add(this.btnContinuar);
            this.pnlBase.Controls.Add(this.pbxBascula);
            this.pnlBase.Controls.Add(this.txtbxBascula);
            this.pnlBase.Controls.Add(this.lblBascula);
            this.pnlBase.Controls.Add(this.pctbxCentro);
            this.pnlBase.Controls.Add(this.txtbxCentro);
            this.pnlBase.Controls.Add(this.lblCentro);
            this.pnlBase.Size = new System.Drawing.Size(448, 237);
            // 
            // lblCentro
            // 
            this.lblCentro.AutoSize = true;
            this.lblCentro.Location = new System.Drawing.Point(12, 33);
            this.lblCentro.Name = "lblCentro";
            this.lblCentro.Size = new System.Drawing.Size(38, 13);
            this.lblCentro.TabIndex = 4;
            this.lblCentro.Text = "Centro";
            // 
            // txtbxCentro
            // 
            this.txtbxCentro.Location = new System.Drawing.Point(87, 30);
            this.txtbxCentro.Name = "txtbxCentro";
            this.txtbxCentro.Size = new System.Drawing.Size(36, 20);
            this.txtbxCentro.TabIndex = 1;
            this.txtbxCentro.TextChanged += new System.EventHandler(this.txtbxCentro_Enter);
            this.txtbxCentro.Enter += new System.EventHandler(this.txtbxCentro_Enter);
            this.txtbxCentro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxCentro_KeyPress);
            this.txtbxCentro.Leave += new System.EventHandler(this.txtbxCentro_Leave);
            // 
            // pctbxCentro
            // 
            this.pctbxCentro.Image = global::Contingencia.Properties.Resources.Listado;
            this.pctbxCentro.Location = new System.Drawing.Point(119, 30);
            this.pctbxCentro.Name = "pctbxCentro";
            this.pctbxCentro.Size = new System.Drawing.Size(24, 19);
            this.pctbxCentro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctbxCentro.TabIndex = 5;
            this.pctbxCentro.TabStop = false;
            this.pctbxCentro.Click += new System.EventHandler(this.pctbxCentro_Click);
            // 
            // lblBascula
            // 
            this.lblBascula.AutoSize = true;
            this.lblBascula.Location = new System.Drawing.Point(12, 75);
            this.lblBascula.Name = "lblBascula";
            this.lblBascula.Size = new System.Drawing.Size(45, 13);
            this.lblBascula.TabIndex = 6;
            this.lblBascula.Text = "Báscula";
            // 
            // txtbxBascula
            // 
            this.txtbxBascula.Location = new System.Drawing.Point(87, 68);
            this.txtbxBascula.Name = "txtbxBascula";
            this.txtbxBascula.Size = new System.Drawing.Size(150, 20);
            this.txtbxBascula.TabIndex = 2;
            this.txtbxBascula.Enter += new System.EventHandler(this.txtbxBascula_Enter);
            this.txtbxBascula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxBascula_KeyPress);
            this.txtbxBascula.Leave += new System.EventHandler(this.txtbxBascula_Leave);
            // 
            // pbxBascula
            // 
            this.pbxBascula.Image = global::Contingencia.Properties.Resources.Listado;
            this.pbxBascula.Location = new System.Drawing.Point(237, 68);
            this.pbxBascula.Name = "pbxBascula";
            this.pbxBascula.Size = new System.Drawing.Size(24, 19);
            this.pbxBascula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxBascula.TabIndex = 8;
            this.pbxBascula.TabStop = false;
            this.pbxBascula.Click += new System.EventHandler(this.pbxBascula_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Location = new System.Drawing.Point(15, 113);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(100, 23);
            this.btnContinuar.TabIndex = 3;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            this.btnContinuar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnContinuar_KeyPress);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(137, 113);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmZPPG05Entrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 341);
            this.Name = "FrmZPPG05Entrada";
            this.Load += new System.EventHandler(this.FrmZPPG05Entrada_Load);
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctbxCentro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBascula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCentro;
        private System.Windows.Forms.TextBox txtbxCentro;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.PictureBox pbxBascula;
        private System.Windows.Forms.TextBox txtbxBascula;
        private System.Windows.Forms.Label lblBascula;
        private System.Windows.Forms.PictureBox pctbxCentro;
    }
}