namespace Contingencia
{
    partial class FrmZPPG02
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbxProc = new System.Windows.Forms.CheckBox();
            this.cbxPendientes = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtbxDestino = new System.Windows.Forms.TextBox();
            this.lblCentro = new System.Windows.Forms.Label();
            this.txtbxCalidad = new System.Windows.Forms.TextBox();
            this.txtbxLote = new System.Windows.Forms.TextBox();
            this.txtbxCentro = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.pcbDestino = new System.Windows.Forms.PictureBox();
            this.pbxCalidad = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlBase.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDestino)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCalidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.pictureBox1);
            this.pnlBase.Controls.Add(this.pbxCalidad);
            this.pnlBase.Controls.Add(this.pcbDestino);
            this.pnlBase.Controls.Add(this.btnConsultar);
            this.pnlBase.Controls.Add(this.panel4);
            this.pnlBase.Controls.Add(this.panel3);
            this.pnlBase.Controls.Add(this.txtbxDestino);
            this.pnlBase.Controls.Add(this.lblCentro);
            this.pnlBase.Controls.Add(this.txtbxCalidad);
            this.pnlBase.Controls.Add(this.txtbxLote);
            this.pnlBase.Controls.Add(this.txtbxCentro);
            this.pnlBase.Controls.Add(this.dtpFecha);
            this.pnlBase.Controls.Add(this.label6);
            this.pnlBase.Controls.Add(this.label5);
            this.pnlBase.Controls.Add(this.label4);
            this.pnlBase.Controls.Add(this.label3);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Size = new System.Drawing.Size(643, 365);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Lavender;
            this.panel4.Controls.Add(this.cbxProc);
            this.panel4.Controls.Add(this.cbxPendientes);
            this.panel4.Location = new System.Drawing.Point(37, 244);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(165, 85);
            this.panel4.TabIndex = 35;
            // 
            // cbxProc
            // 
            this.cbxProc.AutoSize = true;
            this.cbxProc.Location = new System.Drawing.Point(34, 49);
            this.cbxProc.Name = "cbxProc";
            this.cbxProc.Size = new System.Drawing.Size(82, 17);
            this.cbxProc.TabIndex = 7;
            this.cbxProc.Text = "Procesados";
            this.cbxProc.UseVisualStyleBackColor = true;
            // 
            // cbxPendientes
            // 
            this.cbxPendientes.AutoSize = true;
            this.cbxPendientes.Checked = true;
            this.cbxPendientes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxPendientes.Location = new System.Drawing.Point(34, 16);
            this.cbxPendientes.Name = "cbxPendientes";
            this.cbxPendientes.Size = new System.Drawing.Size(79, 17);
            this.cbxPendientes.TabIndex = 6;
            this.cbxPendientes.Text = "Pendientes";
            this.cbxPendientes.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(37, 221);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(165, 24);
            this.panel3.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Estado de los folios";
            // 
            // txtbxDestino
            // 
            this.txtbxDestino.Location = new System.Drawing.Point(122, 105);
            this.txtbxDestino.Name = "txtbxDestino";
            this.txtbxDestino.Size = new System.Drawing.Size(100, 20);
            this.txtbxDestino.TabIndex = 3;
            this.txtbxDestino.Enter += new System.EventHandler(this.txtbxDestino_Enter);
            this.txtbxDestino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxDestino_KeyPress);
            this.txtbxDestino.Leave += new System.EventHandler(this.txtbxDestino_Leave);
            // 
            // lblCentro
            // 
            this.lblCentro.AutoSize = true;
            this.lblCentro.Location = new System.Drawing.Point(159, 11);
            this.lblCentro.Name = "lblCentro";
            this.lblCentro.Size = new System.Drawing.Size(0, 13);
            this.lblCentro.TabIndex = 33;
            // 
            // txtbxCalidad
            // 
            this.txtbxCalidad.Location = new System.Drawing.Point(122, 134);
            this.txtbxCalidad.Name = "txtbxCalidad";
            this.txtbxCalidad.Size = new System.Drawing.Size(137, 20);
            this.txtbxCalidad.TabIndex = 4;
            this.txtbxCalidad.Enter += new System.EventHandler(this.txtbxCalidad_Enter);
            this.txtbxCalidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxCalidad_KeyPress);
            this.txtbxCalidad.Leave += new System.EventHandler(this.txtbxCalidad_Leave);
            // 
            // txtbxLote
            // 
            this.txtbxLote.Location = new System.Drawing.Point(122, 162);
            this.txtbxLote.Name = "txtbxLote";
            this.txtbxLote.Size = new System.Drawing.Size(100, 20);
            this.txtbxLote.TabIndex = 5;
            this.txtbxLote.Enter += new System.EventHandler(this.txtbxLote_Enter);
            this.txtbxLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxLote_KeyPress);
            this.txtbxLote.Leave += new System.EventHandler(this.txtbxLote_Leave);
            // 
            // txtbxCentro
            // 
            this.txtbxCentro.Location = new System.Drawing.Point(87, 8);
            this.txtbxCentro.MaxLength = 4;
            this.txtbxCentro.Name = "txtbxCentro";
            this.txtbxCentro.Size = new System.Drawing.Size(41, 20);
            this.txtbxCentro.TabIndex = 1;
            this.txtbxCentro.TabStop = false;
            this.txtbxCentro.Enter += new System.EventHandler(this.txtbxCentro_Enter);
            this.txtbxCentro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxCentro_KeyPress);
            this.txtbxCentro.Leave += new System.EventHandler(this.txtbxCentro_Leave);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(122, 80);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(96, 20);
            this.dtpFecha.TabIndex = 2;
            this.dtpFecha.Value = new System.DateTime(2012, 5, 10, 0, 0, 0, 0);
            this.dtpFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFecha_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Lote";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Calidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Destino";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Fecha Folio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Centro";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(329, 273);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(150, 23);
            this.btnConsultar.TabIndex = 8;
            this.btnConsultar.Text = "Consultar Folios";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            this.btnConsultar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnConsultar_KeyPress);
            // 
            // pcbDestino
            // 
            this.pcbDestino.Image = global::Contingencia.Properties.Resources.Listado;
            this.pcbDestino.Location = new System.Drawing.Point(222, 105);
            this.pcbDestino.Name = "pcbDestino";
            this.pcbDestino.Size = new System.Drawing.Size(24, 19);
            this.pcbDestino.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbDestino.TabIndex = 37;
            this.pcbDestino.TabStop = false;
            this.pcbDestino.Click += new System.EventHandler(this.pcbDestino_Click);
            // 
            // pbxCalidad
            // 
            this.pbxCalidad.Image = global::Contingencia.Properties.Resources.Listado;
            this.pbxCalidad.Location = new System.Drawing.Point(260, 134);
            this.pbxCalidad.Name = "pbxCalidad";
            this.pbxCalidad.Size = new System.Drawing.Size(24, 19);
            this.pbxCalidad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxCalidad.TabIndex = 38;
            this.pbxCalidad.TabStop = false;
            this.pbxCalidad.Click += new System.EventHandler(this.pbxCalidad_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Contingencia.Properties.Resources.Listado;
            this.pictureBox1.Location = new System.Drawing.Point(129, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // FrmZPPG02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 469);
            this.Name = "FrmZPPG02";
            this.Load += new System.EventHandler(this.FrmZPPG02_Load);
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDestino)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCalidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox cbxProc;
        private System.Windows.Forms.CheckBox cbxPendientes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtbxDestino;
        private System.Windows.Forms.Label lblCentro;
        private System.Windows.Forms.TextBox txtbxCalidad;
        private System.Windows.Forms.TextBox txtbxLote;
        private System.Windows.Forms.TextBox txtbxCentro;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.PictureBox pbxCalidad;
        private System.Windows.Forms.PictureBox pcbDestino;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}