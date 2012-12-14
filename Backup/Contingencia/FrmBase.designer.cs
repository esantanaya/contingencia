namespace Contingencia
{
    partial class FrmBase
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.spcPrincipal = new System.Windows.Forms.SplitContainer();
            this.spcEncabezado = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picInstancia = new System.Windows.Forms.PictureBox();
            this.textAcceso = new System.Windows.Forms.TextBox();
            this.picEnter = new System.Windows.Forms.PictureBox();
            this.menuBase = new System.Windows.Forms.MenuStrip();
            this.menúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlBase = new System.Windows.Forms.Panel();
            this.statusBase = new System.Windows.Forms.StatusStrip();
            this.tslEstadoImagen = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslEstadoDescripcion = new System.Windows.Forms.ToolStripStatusLabel();
            this.spcPrincipal.Panel1.SuspendLayout();
            this.spcPrincipal.Panel2.SuspendLayout();
            this.spcPrincipal.SuspendLayout();
            this.spcEncabezado.Panel1.SuspendLayout();
            this.spcEncabezado.Panel2.SuspendLayout();
            this.spcEncabezado.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInstancia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnter)).BeginInit();
            this.menuBase.SuspendLayout();
            this.pnlTitulo.SuspendLayout();
            this.statusBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcPrincipal
            // 
            this.spcPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcPrincipal.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcPrincipal.IsSplitterFixed = true;
            this.spcPrincipal.Location = new System.Drawing.Point(0, 0);
            this.spcPrincipal.Name = "spcPrincipal";
            this.spcPrincipal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcPrincipal.Panel1
            // 
            this.spcPrincipal.Panel1.Controls.Add(this.spcEncabezado);
            // 
            // spcPrincipal.Panel2
            // 
            this.spcPrincipal.Panel2.Controls.Add(this.pnlBase);
            this.spcPrincipal.Size = new System.Drawing.Size(916, 517);
            this.spcPrincipal.SplitterDistance = 100;
            this.spcPrincipal.TabIndex = 0;
            // 
            // spcEncabezado
            // 
            this.spcEncabezado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcEncabezado.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcEncabezado.IsSplitterFixed = true;
            this.spcEncabezado.Location = new System.Drawing.Point(0, 0);
            this.spcEncabezado.Name = "spcEncabezado";
            this.spcEncabezado.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcEncabezado.Panel1
            // 
            this.spcEncabezado.Panel1.Controls.Add(this.panel1);
            this.spcEncabezado.Panel1.Controls.Add(this.menuBase);
            // 
            // spcEncabezado.Panel2
            // 
            this.spcEncabezado.Panel2.Controls.Add(this.pnlTitulo);
            this.spcEncabezado.Size = new System.Drawing.Size(916, 100);
            this.spcEncabezado.SplitterDistance = 58;
            this.spcEncabezado.TabIndex = 0;
            this.spcEncabezado.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picInstancia);
            this.panel1.Controls.Add(this.textAcceso);
            this.panel1.Controls.Add(this.picEnter);
            this.panel1.Location = new System.Drawing.Point(3, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 32);
            this.panel1.TabIndex = 0;
            // 
            // picInstancia
            // 
            this.picInstancia.Image = global::Contingencia.Properties.Resources.Enter;
            this.picInstancia.Location = new System.Drawing.Point(9, 5);
            this.picInstancia.Name = "picInstancia";
            this.picInstancia.Size = new System.Drawing.Size(21, 22);
            this.picInstancia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picInstancia.TabIndex = 0;
            this.picInstancia.TabStop = false;
            // 
            // textAcceso
            // 
            this.textAcceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAcceso.Location = new System.Drawing.Point(36, 5);
            this.textAcceso.Name = "textAcceso";
            this.textAcceso.Size = new System.Drawing.Size(192, 22);
            this.textAcceso.TabIndex = 90;
            this.textAcceso.TabStop = false;
            this.textAcceso.TextChanged += new System.EventHandler(this.textAcceso_TextChanged);
            this.textAcceso.Validated += new System.EventHandler(this.textAcceso_PressEnter);
            // 
            // picEnter
            // 
            this.picEnter.Location = new System.Drawing.Point(0, 0);
            this.picEnter.Name = "picEnter";
            this.picEnter.Size = new System.Drawing.Size(100, 50);
            this.picEnter.TabIndex = 91;
            this.picEnter.TabStop = false;
            // 
            // menuBase
            // 
            this.menuBase.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menúToolStripMenuItem});
            this.menuBase.Location = new System.Drawing.Point(0, 0);
            this.menuBase.Name = "menuBase";
            this.menuBase.Size = new System.Drawing.Size(916, 24);
            this.menuBase.TabIndex = 0;
            this.menuBase.Text = "menuStrip1";
            // 
            // menúToolStripMenuItem
            // 
            this.menúToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.menúToolStripMenuItem.Name = "menúToolStripMenuItem";
            this.menúToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.menúToolStripMenuItem.Text = "&Menú";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(916, 38);
            this.pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(5, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(57, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "label1";
            // 
            // pnlBase
            // 
            this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(0, 0);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(916, 413);
            this.pnlBase.TabIndex = 0;
            this.pnlBase.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBase_Paint);
            // 
            // statusBase
            // 
            this.statusBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslEstadoImagen,
            this.tslEstadoDescripcion});
            this.statusBase.Location = new System.Drawing.Point(0, 495);
            this.statusBase.Name = "statusBase";
            this.statusBase.Size = new System.Drawing.Size(916, 22);
            this.statusBase.TabIndex = 0;
            this.statusBase.Text = "statusStrip1";
            // 
            // tslEstadoImagen
            // 
            this.tslEstadoImagen.AutoSize = false;
            this.tslEstadoImagen.BackColor = System.Drawing.Color.Red;
            this.tslEstadoImagen.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.tslEstadoImagen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslEstadoImagen.Name = "tslEstadoImagen";
            this.tslEstadoImagen.Size = new System.Drawing.Size(15, 17);
            // 
            // tslEstadoDescripcion
            // 
            this.tslEstadoDescripcion.Name = "tslEstadoDescripcion";
            this.tslEstadoDescripcion.Size = new System.Drawing.Size(121, 17);
            this.tslEstadoDescripcion.Text = "Desplegado de Mensaje";
            // 
            // FrmBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(916, 517);
            this.Controls.Add(this.statusBase);
            this.Controls.Add(this.spcPrincipal);
            this.Name = "FrmBase";
            this.Text = "Sistema de Contingencia";
            this.Load += new System.EventHandler(this.FrmBase_Load);
            this.spcPrincipal.Panel1.ResumeLayout(false);
            this.spcPrincipal.Panel2.ResumeLayout(false);
            this.spcPrincipal.ResumeLayout(false);
            this.spcEncabezado.Panel1.ResumeLayout(false);
            this.spcEncabezado.Panel1.PerformLayout();
            this.spcEncabezado.Panel2.ResumeLayout(false);
            this.spcEncabezado.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picInstancia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEnter)).EndInit();
            this.menuBase.ResumeLayout(false);
            this.menuBase.PerformLayout();
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            this.statusBase.ResumeLayout(false);
            this.statusBase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcPrincipal;
        private System.Windows.Forms.SplitContainer spcEncabezado;
        private System.Windows.Forms.MenuStrip menuBase;
        private System.Windows.Forms.ToolStripMenuItem menúToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.StatusStrip statusBase;
        private System.Windows.Forms.ToolStripStatusLabel tslEstadoImagen;
        private System.Windows.Forms.ToolStripStatusLabel tslEstadoDescripcion;
        public System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picEnter;
        private System.Windows.Forms.TextBox textAcceso;
        private System.Windows.Forms.PictureBox picInstancia;
    }
}