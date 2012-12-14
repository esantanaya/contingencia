namespace Contingencia
{
    partial class FrmZMASTERMenu
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnDesembalar = new System.Windows.Forms.Button();
            this.btnArmar = new System.Windows.Forms.Button();
            this.pnlMenuPrincipal = new System.Windows.Forms.Panel();
            this.lblMenuPrinc = new System.Windows.Forms.Label();
            this.pnlBase.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlMenuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.pnlMenu);
            this.pnlBase.Size = new System.Drawing.Size(396, 274);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.btnAgregar);
            this.pnlMenu.Controls.Add(this.btnSalir);
            this.pnlMenu.Controls.Add(this.btnDesembalar);
            this.pnlMenu.Controls.Add(this.btnArmar);
            this.pnlMenu.Controls.Add(this.pnlMenuPrincipal);
            this.pnlMenu.Location = new System.Drawing.Point(39, 18);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(323, 221);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(55, 34);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(200, 23);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar Tarima";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregarTarima_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(55, 171);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(200, 23);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnDesembalar
            // 
            this.btnDesembalar.Location = new System.Drawing.Point(55, 128);
            this.btnDesembalar.Name = "btnDesembalar";
            this.btnDesembalar.Size = new System.Drawing.Size(200, 23);
            this.btnDesembalar.TabIndex = 2;
            this.btnDesembalar.Text = "Desembalar";
            this.btnDesembalar.UseVisualStyleBackColor = true;
            this.btnDesembalar.Click += new System.EventHandler(this.btnDesembalar_Click);
            // 
            // btnArmar
            // 
            this.btnArmar.Location = new System.Drawing.Point(55, 79);
            this.btnArmar.Name = "btnArmar";
            this.btnArmar.Size = new System.Drawing.Size(200, 23);
            this.btnArmar.TabIndex = 1;
            this.btnArmar.Text = "Armar Tarima";
            this.btnArmar.UseVisualStyleBackColor = true;
            this.btnArmar.Click += new System.EventHandler(this.btnArmar_Click);
            // 
            // pnlMenuPrincipal
            // 
            this.pnlMenuPrincipal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlMenuPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenuPrincipal.Controls.Add(this.lblMenuPrinc);
            this.pnlMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuPrincipal.Name = "pnlMenuPrincipal";
            this.pnlMenuPrincipal.Size = new System.Drawing.Size(323, 25);
            this.pnlMenuPrincipal.TabIndex = 0;
            // 
            // lblMenuPrinc
            // 
            this.lblMenuPrinc.AutoSize = true;
            this.lblMenuPrinc.Location = new System.Drawing.Point(3, 6);
            this.lblMenuPrinc.Name = "lblMenuPrinc";
            this.lblMenuPrinc.Size = new System.Drawing.Size(98, 13);
            this.lblMenuPrinc.TabIndex = 1;
            this.lblMenuPrinc.Text = "MENU PRINCIPAL";
            // 
            // FrmZMASTERMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 378);
            this.Name = "FrmZMASTERMenu";
            this.Load += new System.EventHandler(this.FrmZMASTERMenu_Load);
            this.pnlBase.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenuPrincipal.ResumeLayout(false);
            this.pnlMenuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnDesembalar;
        private System.Windows.Forms.Button btnArmar;
        private System.Windows.Forms.Panel pnlMenuPrincipal;
        private System.Windows.Forms.Label lblMenuPrinc;
        private System.Windows.Forms.Button btnAgregar;
    }
}