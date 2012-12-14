namespace Contingencia
{
    partial class FrmReimpresionEtiquetas
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
            this.label1 = new System.Windows.Forms.Label();
            this.textHu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTarima = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.pnlBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.btnSalir);
            this.pnlBase.Controls.Add(this.btnContinuar);
            this.pnlBase.Controls.Add(this.textTarima);
            this.pnlBase.Controls.Add(this.label2);
            this.pnlBase.Controls.Add(this.textHu);
            this.pnlBase.Controls.Add(this.label1);
            this.pnlBase.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBase.Size = new System.Drawing.Size(427, 198);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código HU:";
            // 
            // textHu
            // 
            this.textHu.Location = new System.Drawing.Point(98, 27);
            this.textHu.Name = "textHu";
            this.textHu.Size = new System.Drawing.Size(123, 22);
            this.textHu.TabIndex = 1;
            this.textHu.TextChanged += new System.EventHandler(this.textHu_TextChanged);
            this.textHu.Enter += new System.EventHandler(this.textHu_Enter);
            this.textHu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textHu_KeyPress);
            this.textHu.Leave += new System.EventHandler(this.textHu_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tarima:";
            // 
            // textTarima
            // 
            this.textTarima.Location = new System.Drawing.Point(98, 66);
            this.textTarima.Name = "textTarima";
            this.textTarima.Size = new System.Drawing.Size(123, 22);
            this.textTarima.TabIndex = 3;
            this.textTarima.TextChanged += new System.EventHandler(this.textTarima_TextChanged);
            this.textTarima.Enter += new System.EventHandler(this.textTarima_Enter);
            this.textTarima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textTarima_KeyPress);
            this.textTarima.Leave += new System.EventHandler(this.textTarima_Leave);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Gold;
            this.btnSalir.Location = new System.Drawing.Point(256, 125);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(71, 23);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.Gold;
            this.btnContinuar.Location = new System.Drawing.Point(98, 125);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(83, 23);
            this.btnContinuar.TabIndex = 19;
            this.btnContinuar.Text = "Imprimir";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // FrmReimpresionEtiquetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 302);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmReimpresionEtiquetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.FrmReimpresionEtiquetas_Activated);
            this.Load += new System.EventHandler(this.FrmReimpresionEtiquetas_Load);
            this.pnlBase.ResumeLayout(false);
            this.pnlBase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTarima;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textHu;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnContinuar;
    }
}