namespace Contingencia
{
    partial class FrmPrincipal
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Start Up");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("ZPPG01 Fatometer");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("ZPPG02 Proceso de Selección de Destino");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("ZPPG03 Pesado de Cabeza");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("ZPPG05 Pesado para canal de Corte y Venta");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Z Interfaz HU Pesado de Cajas");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("ZPPG27 Estación de Traslado de Cajas");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("ZMASTER");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("ZTRASLADOS");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("ZWMG04");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Reporte de Entregas");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Reimpresion Etiquetas");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Shut Down");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Favoritos", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13});
            this.spcArbol = new System.Windows.Forms.SplitContainer();
            this.treeOpciones = new System.Windows.Forms.TreeView();
            this.pnlBase.SuspendLayout();
            this.spcArbol.Panel1.SuspendLayout();
            this.spcArbol.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.spcArbol);
            this.pnlBase.Size = new System.Drawing.Size(908, 441);
            // 
            // spcArbol
            // 
            this.spcArbol.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spcArbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcArbol.Location = new System.Drawing.Point(0, 0);
            this.spcArbol.Name = "spcArbol";
            // 
            // spcArbol.Panel1
            // 
            this.spcArbol.Panel1.Controls.Add(this.treeOpciones);
            // 
            // spcArbol.Panel2
            // 
            this.spcArbol.Panel2.BackgroundImage = global::Contingencia.Properties.Resources.logo_keken;
            this.spcArbol.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.spcArbol.Size = new System.Drawing.Size(908, 441);
            this.spcArbol.SplitterDistance = 411;
            this.spcArbol.TabIndex = 1;
            // 
            // treeOpciones
            // 
            this.treeOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeOpciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeOpciones.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.treeOpciones.Location = new System.Drawing.Point(0, 0);
            this.treeOpciones.Name = "treeOpciones";
            treeNode1.Name = "START";
            treeNode1.Text = "Start Up";
            treeNode2.Name = "ZPPG01";
            treeNode2.Text = "ZPPG01 Fatometer";
            treeNode3.Name = "ZPPG02";
            treeNode3.Text = "ZPPG02 Proceso de Selección de Destino";
            treeNode4.Name = "ZPPG03";
            treeNode4.Text = "ZPPG03 Pesado de Cabeza";
            treeNode5.Name = "ZPPG05";
            treeNode5.Text = "ZPPG05 Pesado para canal de Corte y Venta";
            treeNode6.Name = "ZInterfaz";
            treeNode6.Text = "Z Interfaz HU Pesado de Cajas";
            treeNode7.Name = "ZPPG27";
            treeNode7.Text = "ZPPG27 Estación de Traslado de Cajas";
            treeNode8.Name = "ZMASTER";
            treeNode8.Text = "ZMASTER";
            treeNode9.Name = "ZTRASLADOS";
            treeNode9.Text = "ZTRASLADOS";
            treeNode10.Name = "ZWMG04";
            treeNode10.Text = "ZWMG04";
            treeNode11.Name = "Reporte";
            treeNode11.Text = "Reporte de Entregas";
            treeNode12.Name = "Reimpresion";
            treeNode12.Text = "Reimpresion Etiquetas";
            treeNode13.Name = "ShutDown";
            treeNode13.Text = "Shut Down";
            treeNode14.Name = "Favoritos";
            treeNode14.Text = "Favoritos";
            this.treeOpciones.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode14});
            this.treeOpciones.Size = new System.Drawing.Size(407, 437);
            this.treeOpciones.TabIndex = 0;
            this.treeOpciones.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeOpciones_AfterSelect);
            this.treeOpciones.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeOpciones_NodeMouseClick);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(908, 545);
            this.IsMdiContainer = true;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.pnlBase.ResumeLayout(false);
            this.spcArbol.Panel1.ResumeLayout(false);
            this.spcArbol.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcArbol;
        private System.Windows.Forms.TreeView treeOpciones;
    }
}