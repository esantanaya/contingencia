namespace Contingencia
{
    partial class FrmZPPG01Entrada
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
            this.label6 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtbxPuertoSrl = new System.Windows.Forms.TextBox();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCentro = new System.Windows.Forms.Label();
            this.txtbxSettings = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBascula = new System.Windows.Forms.Label();
            this.txtbxCentro = new System.Windows.Forms.TextBox();
            this.txtbxBascula = new System.Windows.Forms.TextBox();
            this.pbxCentro = new System.Windows.Forms.PictureBox();
            this.pbxBascula = new System.Windows.Forms.PictureBox();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCentro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBascula)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Size = new System.Drawing.Size(566, 341);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Puerto serial";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Transparent;
            this.btnSalir.Location = new System.Drawing.Point(149, 337);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(112, 19);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtbxPuertoSrl
            // 
            this.txtbxPuertoSrl.Location = new System.Drawing.Point(87, 39);
            this.txtbxPuertoSrl.Name = "txtbxPuertoSrl";
            this.txtbxPuertoSrl.Size = new System.Drawing.Size(23, 20);
            this.txtbxPuertoSrl.TabIndex = 4;
            this.txtbxPuertoSrl.Text = "2";
            this.txtbxPuertoSrl.Enter += new System.EventHandler(this.txtbxPuertoSrl_Enter);
            this.txtbxPuertoSrl.Leave += new System.EventHandler(this.txtbxPuertoSrl_Leave);
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.Transparent;
            this.btnContinuar.Location = new System.Drawing.Point(19, 337);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(107, 19);
            this.btnContinuar.TabIndex = 5;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Settings";
            // 
            // lblCentro
            // 
            this.lblCentro.AutoSize = true;
            this.lblCentro.Location = new System.Drawing.Point(14, 124);
            this.lblCentro.Name = "lblCentro";
            this.lblCentro.Size = new System.Drawing.Size(38, 13);
            this.lblCentro.TabIndex = 16;
            this.lblCentro.Text = "Centro";
            // 
            // txtbxSettings
            // 
            this.txtbxSettings.Location = new System.Drawing.Point(87, 12);
            this.txtbxSettings.Name = "txtbxSettings";
            this.txtbxSettings.Size = new System.Drawing.Size(117, 20);
            this.txtbxSettings.TabIndex = 3;
            this.txtbxSettings.Text = "2400,N,8,1";
            this.txtbxSettings.Enter += new System.EventHandler(this.txtbxSettings_Enter);
            this.txtbxSettings.Leave += new System.EventHandler(this.txtbxSettings_Leave);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Lavender;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.txtbxPuertoSrl);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.txtbxSettings);
            this.panel6.Location = new System.Drawing.Point(11, 227);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(222, 73);
            this.panel6.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(11, 209);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(222, 18);
            this.panel4.TabIndex = 20;
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(0, 19);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(221, 63);
            this.panel5.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fatometer";
            // 
            // lblBascula
            // 
            this.lblBascula.AutoSize = true;
            this.lblBascula.Location = new System.Drawing.Point(14, 167);
            this.lblBascula.Name = "lblBascula";
            this.lblBascula.Size = new System.Drawing.Size(45, 13);
            this.lblBascula.TabIndex = 18;
            this.lblBascula.Text = "Báscula";
            // 
            // txtbxCentro
            // 
            this.txtbxCentro.Location = new System.Drawing.Point(77, 121);
            this.txtbxCentro.MaxLength = 4;
            this.txtbxCentro.Name = "txtbxCentro";
            this.txtbxCentro.Size = new System.Drawing.Size(36, 20);
            this.txtbxCentro.TabIndex = 1;
            this.txtbxCentro.Enter += new System.EventHandler(this.txtbxCentro_Enter);
            this.txtbxCentro.Leave += new System.EventHandler(this.txtbxCentro_Leave);
            // 
            // txtbxBascula
            // 
            this.txtbxBascula.Location = new System.Drawing.Point(77, 164);
            this.txtbxBascula.Name = "txtbxBascula";
            this.txtbxBascula.Size = new System.Drawing.Size(100, 20);
            this.txtbxBascula.TabIndex = 2;
            this.txtbxBascula.Enter += new System.EventHandler(this.txtbxBascula_Enter);
            this.txtbxBascula.Leave += new System.EventHandler(this.txtbxBascula_Leave);
            // 
            // pbxCentro
            // 
            this.pbxCentro.Image = global::Contingencia.Properties.Resources.Listado;
            this.pbxCentro.Location = new System.Drawing.Point(113, 121);
            this.pbxCentro.Name = "pbxCentro";
            this.pbxCentro.Size = new System.Drawing.Size(24, 19);
            this.pbxCentro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCentro.TabIndex = 24;
            this.pbxCentro.TabStop = false;
            this.pbxCentro.Click += new System.EventHandler(this.pbxCentro_Click);
            // 
            // pbxBascula
            // 
            this.pbxBascula.Image = global::Contingencia.Properties.Resources.Listado;
            this.pbxBascula.Location = new System.Drawing.Point(178, 164);
            this.pbxBascula.Name = "pbxBascula";
            this.pbxBascula.Size = new System.Drawing.Size(24, 19);
            this.pbxBascula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxBascula.TabIndex = 25;
            this.pbxBascula.TabStop = false;
            this.pbxBascula.Click += new System.EventHandler(this.pbxBascula_Click);
            // 
            // FrmZPPG01Entrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 445);
            this.Controls.Add(this.pbxBascula);
            this.Controls.Add(this.pbxCentro);
            this.Controls.Add(this.txtbxBascula);
            this.Controls.Add(this.txtbxCentro);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.lblCentro);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblBascula);
            this.Name = "FrmZPPG01Entrada";
            this.Load += new System.EventHandler(this.FrmZPPG01Entrada_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmZPPG01Entrada_KeyUp);
            this.Controls.SetChildIndex(this.lblBascula, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.Controls.SetChildIndex(this.panel6, 0);
            this.Controls.SetChildIndex(this.lblCentro, 0);
            this.Controls.SetChildIndex(this.btnContinuar, 0);
            this.Controls.SetChildIndex(this.btnSalir, 0);
            this.Controls.SetChildIndex(this.txtbxCentro, 0);
            this.Controls.SetChildIndex(this.txtbxBascula, 0);
            this.Controls.SetChildIndex(this.pbxCentro, 0);
            this.Controls.SetChildIndex(this.pbxBascula, 0);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCentro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBascula)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtbxPuertoSrl;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCentro;
        private System.Windows.Forms.TextBox txtbxSettings;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBascula;
        private System.Windows.Forms.TextBox txtbxCentro;
        private System.Windows.Forms.TextBox txtbxBascula;
        private System.Windows.Forms.PictureBox pbxCentro;
        private System.Windows.Forms.PictureBox pbxBascula;

    }
}