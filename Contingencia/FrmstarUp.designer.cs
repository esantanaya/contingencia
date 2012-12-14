namespace DownLoad
{
    partial class FrmstarUp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.spcPrincipal = new System.Windows.Forms.SplitContainer();
            this.spcProcesos = new System.Windows.Forms.SplitContainer();
            this.dgvRfc = new System.Windows.Forms.DataGridView();
            this.NombreRFC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaActualizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEquipos = new System.Windows.Forms.DataGridView();
            this.IpEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comunicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArchivoTexto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccesoSap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccesoRecartera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spcPrincipal.Panel1.SuspendLayout();
            this.spcPrincipal.Panel2.SuspendLayout();
            this.spcPrincipal.SuspendLayout();
            this.spcProcesos.Panel1.SuspendLayout();
            this.spcProcesos.Panel2.SuspendLayout();
            this.spcProcesos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRfc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Verificación de Equipos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Estado Actual del Proceso: ";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblEstado.Location = new System.Drawing.Point(221, 17);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(123, 16);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Sistema Iniciado";
            // 
            // btnIniciar
            // 
            this.btnIniciar.BackColor = System.Drawing.Color.Gold;
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.Location = new System.Drawing.Point(586, 10);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(134, 34);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Detener Sistema";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // spcPrincipal
            // 
            this.spcPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spcPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcPrincipal.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcPrincipal.Location = new System.Drawing.Point(0, 0);
            this.spcPrincipal.Name = "spcPrincipal";
            this.spcPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcPrincipal.Panel1
            // 
            this.spcPrincipal.Panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.spcPrincipal.Panel1.Controls.Add(this.label3);
            this.spcPrincipal.Panel1.Controls.Add(this.btnIniciar);
            this.spcPrincipal.Panel1.Controls.Add(this.lblEstado);
            this.spcPrincipal.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.spcPrincipal_Panel1_Paint);
            // 
            // spcPrincipal.Panel2
            // 
            this.spcPrincipal.Panel2.Controls.Add(this.spcProcesos);
            this.spcPrincipal.Size = new System.Drawing.Size(738, 614);
            this.spcPrincipal.SplitterDistance = 48;
            this.spcPrincipal.TabIndex = 5;
            // 
            // spcProcesos
            // 
            this.spcProcesos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spcProcesos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcProcesos.Location = new System.Drawing.Point(0, 0);
            this.spcProcesos.Name = "spcProcesos";
            this.spcProcesos.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcProcesos.Panel1
            // 
            this.spcProcesos.Panel1.Controls.Add(this.dgvRfc);
            this.spcProcesos.Panel1.Controls.Add(this.label1);
            // 
            // spcProcesos.Panel2
            // 
            this.spcProcesos.Panel2.Controls.Add(this.dgvEquipos);
            this.spcProcesos.Panel2.Controls.Add(this.label2);
            this.spcProcesos.Size = new System.Drawing.Size(738, 562);
            this.spcProcesos.SplitterDistance = 274;
            this.spcProcesos.TabIndex = 0;
            // 
            // dgvRfc
            // 
            this.dgvRfc.AllowUserToAddRows = false;
            this.dgvRfc.AllowUserToDeleteRows = false;
            this.dgvRfc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvRfc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRfc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NombreRFC,
            this.FechaActualizacion,
            this.Estado});
            this.dgvRfc.Location = new System.Drawing.Point(13, 29);
            this.dgvRfc.Name = "dgvRfc";
            this.dgvRfc.Size = new System.Drawing.Size(707, 230);
            this.dgvRfc.TabIndex = 1;
            // 
            // NombreRFC
            // 
            this.NombreRFC.HeaderText = "RFC";
            this.NombreRFC.Name = "NombreRFC";
            this.NombreRFC.Width = 150;
            // 
            // FechaActualizacion
            // 
            dataGridViewCellStyle1.Format = "MM.dd.yyyy hh:mm:ss";
            this.FechaActualizacion.DefaultCellStyle = dataGridViewCellStyle1;
            this.FechaActualizacion.HeaderText = "Fecha Última Actualización";
            this.FechaActualizacion.Name = "FechaActualizacion";
            this.FechaActualizacion.ReadOnly = true;
            this.FechaActualizacion.Width = 200;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Verificación de RFC\'s";
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AllowUserToDeleteRows = false;
            this.dgvEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IpEquipo,
            this.Comunicacion,
            this.ArchivoTexto,
            this.AccesoSap,
            this.AccesoRecartera});
            this.dgvEquipos.Location = new System.Drawing.Point(13, 33);
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.Size = new System.Drawing.Size(707, 237);
            this.dgvEquipos.TabIndex = 2;
            // 
            // IpEquipo
            // 
            this.IpEquipo.HeaderText = "IP del Equipo";
            this.IpEquipo.Name = "IpEquipo";
            this.IpEquipo.Width = 150;
            // 
            // Comunicacion
            // 
            this.Comunicacion.HeaderText = "Cominucación";
            this.Comunicacion.Name = "Comunicacion";
            this.Comunicacion.ReadOnly = true;
            this.Comunicacion.Width = 150;
            // 
            // ArchivoTexto
            // 
            this.ArchivoTexto.HeaderText = "Archivo Texto";
            this.ArchivoTexto.Name = "ArchivoTexto";
            this.ArchivoTexto.ReadOnly = true;
            this.ArchivoTexto.Visible = false;
            // 
            // AccesoSap
            // 
            this.AccesoSap.HeaderText = "Acceso a SAP";
            this.AccesoSap.Name = "AccesoSap";
            this.AccesoSap.ReadOnly = true;
            this.AccesoSap.Width = 150;
            // 
            // AccesoRecartera
            // 
            this.AccesoRecartera.HeaderText = "Acceso a Recartera";
            this.AccesoRecartera.Name = "AccesoRecartera";
            this.AccesoRecartera.ReadOnly = true;
            this.AccesoRecartera.Width = 180;
            // 
            // FrmstarUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(738, 614);
            this.Controls.Add(this.spcPrincipal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmstarUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Recartera, Download";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmstarUp_FormClosed);
            this.Load += new System.EventHandler(this.FrmstarUp_Load);
            this.spcPrincipal.Panel1.ResumeLayout(false);
            this.spcPrincipal.Panel1.PerformLayout();
            this.spcPrincipal.Panel2.ResumeLayout(false);
            this.spcPrincipal.ResumeLayout(false);
            this.spcProcesos.Panel1.ResumeLayout(false);
            this.spcProcesos.Panel1.PerformLayout();
            this.spcProcesos.Panel2.ResumeLayout(false);
            this.spcProcesos.Panel2.PerformLayout();
            this.spcProcesos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRfc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.SplitContainer spcPrincipal;
        private System.Windows.Forms.SplitContainer spcProcesos;
        private System.Windows.Forms.DataGridView dgvEquipos;
        private System.Windows.Forms.DataGridView dgvRfc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreRFC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaActualizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comunicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArchivoTexto;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccesoSap;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccesoRecartera;
    }
}