namespace WinformsDAL
{
    partial class FormJob
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
            this.labConStatus = new System.Windows.Forms.Label();
            this.labTabla = new System.Windows.Forms.Label();
            this.listBSelect = new System.Windows.Forms.ListBox();
            this.lab_CHNG_Tabla = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.labMinSal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.labTrabajo = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.btnAddJob = new System.Windows.Forms.Button();
            this.btnEditJob = new System.Windows.Forms.Button();
            this.chckLinq = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labConStatus
            // 
            this.labConStatus.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.labConStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labConStatus.Location = new System.Drawing.Point(19, 7);
            this.labConStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labConStatus.MinimumSize = new System.Drawing.Size(75, 16);
            this.labConStatus.Name = "labConStatus";
            this.labConStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labConStatus.Size = new System.Drawing.Size(225, 20);
            this.labConStatus.TabIndex = 0;
            this.labConStatus.Text = "Closed";
            this.labConStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labTabla
            // 
            this.labTabla.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.labTabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTabla.Location = new System.Drawing.Point(19, 41);
            this.labTabla.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labTabla.MinimumSize = new System.Drawing.Size(75, 16);
            this.labTabla.Name = "labTabla";
            this.labTabla.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.labTabla.Size = new System.Drawing.Size(225, 20);
            this.labTabla.TabIndex = 6;
            this.labTabla.Text = "Trabajo";
            this.labTabla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBSelect
            // 
            this.listBSelect.AccessibleName = "";
            this.listBSelect.FormattingEnabled = true;
            this.listBSelect.Location = new System.Drawing.Point(268, 33);
            this.listBSelect.Margin = new System.Windows.Forms.Padding(2);
            this.listBSelect.Name = "listBSelect";
            this.listBSelect.ScrollAlwaysVisible = true;
            this.listBSelect.Size = new System.Drawing.Size(241, 290);
            this.listBSelect.TabIndex = 6;
            this.listBSelect.SelectedIndexChanged += new System.EventHandler(this.listBSelect_SelectedIndexChanged);
            this.listBSelect.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBSelect_DoubleClick);
            // 
            // lab_CHNG_Tabla
            // 
            this.lab_CHNG_Tabla.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lab_CHNG_Tabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_CHNG_Tabla.Location = new System.Drawing.Point(268, 7);
            this.lab_CHNG_Tabla.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lab_CHNG_Tabla.MinimumSize = new System.Drawing.Size(75, 16);
            this.lab_CHNG_Tabla.Name = "lab_CHNG_Tabla";
            this.lab_CHNG_Tabla.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.lab_CHNG_Tabla.Size = new System.Drawing.Size(240, 20);
            this.lab_CHNG_Tabla.TabIndex = 10;
            this.lab_CHNG_Tabla.Text = "Trabajos";
            this.lab_CHNG_Tabla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(116, 64);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(128, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // labMinSal
            // 
            this.labMinSal.AutoSize = true;
            this.labMinSal.Location = new System.Drawing.Point(20, 92);
            this.labMinSal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labMinSal.Name = "labMinSal";
            this.labMinSal.Size = new System.Drawing.Size(75, 13);
            this.labMinSal.TabIndex = 14;
            this.labMinSal.Text = "Salario Minimo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 115);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Salario Maximo";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(268, 332);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(240, 24);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refrescar";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // labTrabajo
            // 
            this.labTrabajo.AutoSize = true;
            this.labTrabajo.Location = new System.Drawing.Point(20, 69);
            this.labTrabajo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labTrabajo.Name = "labTrabajo";
            this.labTrabajo.Size = new System.Drawing.Size(89, 13);
            this.labTrabajo.TabIndex = 21;
            this.labTrabajo.Text = "Titulo del Trabajo";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(116, 87);
            this.txtMin.Margin = new System.Windows.Forms.Padding(2);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(128, 20);
            this.txtMin.TabIndex = 2;
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(116, 110);
            this.txtMax.Margin = new System.Windows.Forms.Padding(2);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(128, 20);
            this.txtMax.TabIndex = 3;
            // 
            // btnAddJob
            // 
            this.btnAddJob.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAddJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddJob.Location = new System.Drawing.Point(19, 144);
            this.btnAddJob.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddJob.Name = "btnAddJob";
            this.btnAddJob.Size = new System.Drawing.Size(225, 24);
            this.btnAddJob.TabIndex = 4;
            this.btnAddJob.Text = "Añadir Trabajo";
            this.btnAddJob.UseVisualStyleBackColor = false;
            this.btnAddJob.Click += new System.EventHandler(this.btnAddJob_Click);
            // 
            // btnEditJob
            // 
            this.btnEditJob.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnEditJob.Enabled = false;
            this.btnEditJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditJob.Location = new System.Drawing.Point(19, 173);
            this.btnEditJob.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditJob.Name = "btnEditJob";
            this.btnEditJob.Size = new System.Drawing.Size(225, 24);
            this.btnEditJob.TabIndex = 5;
            this.btnEditJob.Text = "Editar Trabajo";
            this.btnEditJob.UseVisualStyleBackColor = false;
            this.btnEditJob.Click += new System.EventHandler(this.btnEditJob_Click);
            // 
            // chckLinq
            // 
            this.chckLinq.AutoSize = true;
            this.chckLinq.Location = new System.Drawing.Point(23, 203);
            this.chckLinq.Name = "chckLinq";
            this.chckLinq.Size = new System.Drawing.Size(68, 17);
            this.chckLinq.TabIndex = 23;
            this.chckLinq.Text = "Use Linq";
            this.chckLinq.UseVisualStyleBackColor = true;
            // 
            // FormJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 366);
            this.Controls.Add(this.chckLinq);
            this.Controls.Add(this.btnEditJob);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.labTrabajo);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddJob);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labMinSal);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lab_CHNG_Tabla);
            this.Controls.Add(this.listBSelect);
            this.Controls.Add(this.labTabla);
            this.Controls.Add(this.labConStatus);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormJob";
            this.Text = "Form Job";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labConStatus;
        private System.Windows.Forms.Label labTabla;
        private System.Windows.Forms.ListBox listBSelect;
        private System.Windows.Forms.Label lab_CHNG_Tabla;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label labMinSal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label labTrabajo;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Button btnAddJob;
        private System.Windows.Forms.Button btnEditJob;
        private System.Windows.Forms.CheckBox chckLinq;
    }
}

