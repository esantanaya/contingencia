namespace Contingencia
{
    partial class FrmEntradaZPPG03
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
            this.lblBascula = new System.Windows.Forms.Label();
            this.txtbxCentro = new System.Windows.Forms.TextBox();
            this.txtbxBascula = new System.Windows.Forms.TextBox();
            this.pbxCentro = new System.Windows.Forms.PictureBox();
            this.pbxBascula = new System.Windows.Forms.PictureBox();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCentro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBascula)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.btnSalir);
            this.pnlBase.Controls.Add(this.btnContinuar);
            this.pnlBase.Controls.Add(this.pbxBascula);
            this.pnlBase.Controls.Add(this.pbxCentro);
            this.pnlBase.Controls.Add(this.txtbxBascula);
            this.pnlBase.Controls.Add(this.txtbxCentro);
            this.pnlBase.Controls.Add(this.lblBascula);
            this.pnlBase.Controls.Add(this.lblCentro);
            this.pnlBase.Size = new System.Drawing.Size(439, 264);
            // 
            // lblCentro
            // 
            this.lblCentro.AutoSize = true;
            this.lblCentro.Location = new System.Drawing.Point(12, 29);
            this.lblCentro.Name = "lblCentro";
            this.lblCentro.Size = new System.Drawing.Size(38, 13);
            this.lblCentro.TabIndex = 17;
            this.lblCentro.Text = "Centro";
            // 
            // lblBascula
            // 
            this.lblBascula.AutoSize = true;
            this.lblBascula.Location = new System.Drawing.Point(12, 55);
            this.lblBascula.Name = "lblBascula";
            this.lblBascula.Size = new System.Drawing.Size(45, 13);
            this.lblBascula.TabIndex = 19;
            this.lblBascula.Text = "Báscula";
            // 
            // txtbxCentro
            // 
            this.txtbxCentro.Location = new System.Drawing.Point(66, 26);
            this.txtbxCentro.MaxLength = 4;
            this.txtbxCentro.Name = "txtbxCentro";
            this.txtbxCentro.Size = new System.Drawing.Size(36, 20);
            this.txtbxCentro.TabIndex = 20;
            this.txtbxCentro.TextChanged += new System.EventHandler(this.txtbxCentro_TextChanged);
            this.txtbxCentro.Enter += new System.EventHandler(this.txtbxCentro_Enter);
            this.txtbxCentro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxCentro_KeyPress);
            this.txtbxCentro.Leave += new System.EventHandler(this.txtbxCentro_Leave);
            // 
            // txtbxBascula
            // 
            this.txtbxBascula.Location = new System.Drawing.Point(66, 52);
            this.txtbxBascula.Name = "txtbxBascula";
            this.txtbxBascula.Size = new System.Drawing.Size(100, 20);
            this.txtbxBascula.TabIndex = 21;
            this.txtbxBascula.Enter += new System.EventHandler(this.txtbxBascula_Enter);
            this.txtbxBascula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxBascula_KeyPress);
            this.txtbxBascula.Leave += new System.EventHandler(this.txtbxBascula_Leave);
            // 
            // pbxCentro
            // 
            this.pbxCentro.Image = global::Contingencia.Properties.Resources.Listado;
            this.pbxCentro.Location = new System.Drawing.Point(103, 27);
            this.pbxCentro.Name = "pbxCentro";
            this.pbxCentro.Size = new System.Drawing.Size(24, 19);
            this.pbxCentro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCentro.TabIndex = 25;
            this.pbxCentro.TabStop = false;
            this.pbxCentro.Click += new System.EventHandler(this.pbxCentro_Click);
            // 
            // pbxBascula
            // 
            this.pbxBascula.Image = global::Contingencia.Properties.Resources.Listado;
            this.pbxBascula.Location = new System.Drawing.Point(167, 53);
            this.pbxBascula.Name = "pbxBascula";
            this.pbxBascula.Size = new System.Drawing.Size(24, 19);
            this.pbxBascula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxBascula.TabIndex = 26;
            this.pbxBascula.TabStop = false;
            this.pbxBascula.Click += new System.EventHandler(this.pbxBascula_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.Transparent;
            this.btnContinuar.Location = new System.Drawing.Point(15, 121);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(107, 19);
            this.btnContinuar.TabIndex = 27;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.Location = new System.Drawing.Point(141, 121);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(112, 19);
            this.btnSalir.TabIndex = 28;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmEntradaZPPG03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 368);
            this.Name = "FrmEntradaZPPG03";
            this.Load += new System.EventHandler(this.FrmEntradaZPPG03_Load);
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCentro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBascula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCentro;
        private System.Windows.Forms.Label lblBascula;
        private System.Windows.Forms.TextBox txtbxCentro;
        private System.Windows.Forms.TextBox txtbxBascula;
        private System.Windows.Forms.PictureBox pbxCentro;
        private System.Windows.Forms.PictureBox pbxBascula;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Button btnSalir;
    }
}