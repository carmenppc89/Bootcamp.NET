namespace WindowsFormsAppPrueba
{
    partial class PruebaWindForms
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnPulsar = new System.Windows.Forms.Button();
            this.listDiaSemana = new System.Windows.Forms.ListBox();
            this.btnFromulario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labNombre
            // 
            this.labNombre.AutoSize = true;
            this.labNombre.Location = new System.Drawing.Point(32, 26);
            this.labNombre.Name = "labNombre";
            this.labNombre.Size = new System.Drawing.Size(56, 16);
            this.labNombre.TabIndex = 0;
            this.labNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(108, 26);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(204, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // btnPulsar
            // 
            this.btnPulsar.Location = new System.Drawing.Point(47, 203);
            this.btnPulsar.Name = "btnPulsar";
            this.btnPulsar.Size = new System.Drawing.Size(281, 23);
            this.btnPulsar.TabIndex = 2;
            this.btnPulsar.Text = "Pulsar para copiar";
            this.btnPulsar.UseVisualStyleBackColor = true;
            this.btnPulsar.Click += new System.EventHandler(this.btnPulsar_Click);
            // 
            // listDiaSemana
            // 
            this.listDiaSemana.FormattingEnabled = true;
            this.listDiaSemana.ItemHeight = 16;
            this.listDiaSemana.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miercoles",
            "Jueves",
            "Viernes",
            "Sabado",
            "Domingo"});
            this.listDiaSemana.Location = new System.Drawing.Point(35, 71);
            this.listDiaSemana.Name = "listDiaSemana";
            this.listDiaSemana.Size = new System.Drawing.Size(120, 116);
            this.listDiaSemana.TabIndex = 3;
            this.listDiaSemana.SelectedIndexChanged += new System.EventHandler(this.listDiaSetmana_SelectedIndexChanged);
            // 
            // btnFromulario
            // 
            this.btnFromulario.Location = new System.Drawing.Point(171, 90);
            this.btnFromulario.Name = "btnFromulario";
            this.btnFromulario.Size = new System.Drawing.Size(176, 23);
            this.btnFromulario.TabIndex = 4;
            this.btnFromulario.Text = "Formulario Bootstrap";
            this.btnFromulario.UseVisualStyleBackColor = true;
            this.btnFromulario.Click += new System.EventHandler(this.btnFromulario_Click);
            // 
            // PruebaWindForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 245);
            this.Controls.Add(this.btnFromulario);
            this.Controls.Add(this.listDiaSemana);
            this.Controls.Add(this.btnPulsar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labNombre);
            this.Name = "PruebaWindForms";
            this.Text = "Mi primera app";
            this.Load += new System.EventHandler(this.PruebaWindForms_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnPulsar;
        private System.Windows.Forms.ListBox listDiaSemana;
        private System.Windows.Forms.Button btnFromulario;
    }
}

