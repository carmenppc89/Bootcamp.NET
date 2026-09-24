using System.Data;
using System.Data.SqlClient;

namespace WinformsAccesoADatos
{
    partial class FormConnexion
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
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnDesconectar = new System.Windows.Forms.Button();
            this.labTabla = new System.Windows.Forms.Label();
            this.listBSelect = new System.Windows.Forms.ListBox();
            this.lab_CHNG_Tabla = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.labMinSal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd_V1 = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd_V4 = new System.Windows.Forms.Button();
            this.btnAdd_V3 = new System.Windows.Forms.Button();
            this.btnAdd_V2 = new System.Windows.Forms.Button();
            this.labTrabajo = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labConStatus
            // 
            this.labConStatus.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.labConStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labConStatus.Location = new System.Drawing.Point(25, 9);
            this.labConStatus.MinimumSize = new System.Drawing.Size(100, 20);
            this.labConStatus.Name = "labConStatus";
            this.labConStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labConStatus.Size = new System.Drawing.Size(300, 25);
            this.labConStatus.TabIndex = 0;
            this.labConStatus.Text = "Closed";
            this.labConStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnConectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectar.Location = new System.Drawing.Point(25, 38);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(140, 30);
            this.btnConectar.TabIndex = 1;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnDesconectar
            // 
            this.btnDesconectar.BackColor = System.Drawing.Color.LightCoral;
            this.btnDesconectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDesconectar.Location = new System.Drawing.Point(185, 38);
            this.btnDesconectar.Name = "btnDesconectar";
            this.btnDesconectar.Size = new System.Drawing.Size(140, 30);
            this.btnDesconectar.TabIndex = 2;
            this.btnDesconectar.Text = "Desconectar";
            this.btnDesconectar.UseVisualStyleBackColor = false;
            this.btnDesconectar.Click += new System.EventHandler(this.btnDesconectar_Click);
            // 
            // labTabla
            // 
            this.labTabla.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.labTabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTabla.Location = new System.Drawing.Point(25, 83);
            this.labTabla.MinimumSize = new System.Drawing.Size(100, 20);
            this.labTabla.Name = "labTabla";
            this.labTabla.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labTabla.Size = new System.Drawing.Size(300, 25);
            this.labTabla.TabIndex = 6;
            this.labTabla.Text = "Añadir Trabajo";
            this.labTabla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listBSelect
            // 
            this.listBSelect.AccessibleName = "";
            this.listBSelect.FormattingEnabled = true;
            this.listBSelect.ItemHeight = 16;
            this.listBSelect.Location = new System.Drawing.Point(357, 41);
            this.listBSelect.Name = "listBSelect";
            this.listBSelect.ScrollAlwaysVisible = true;
            this.listBSelect.Size = new System.Drawing.Size(320, 356);
            this.listBSelect.TabIndex = 9;
            // 
            // lab_CHNG_Tabla
            // 
            this.lab_CHNG_Tabla.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lab_CHNG_Tabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_CHNG_Tabla.Location = new System.Drawing.Point(357, 9);
            this.lab_CHNG_Tabla.MinimumSize = new System.Drawing.Size(100, 20);
            this.lab_CHNG_Tabla.Name = "lab_CHNG_Tabla";
            this.lab_CHNG_Tabla.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lab_CHNG_Tabla.Size = new System.Drawing.Size(320, 25);
            this.lab_CHNG_Tabla.TabIndex = 10;
            this.lab_CHNG_Tabla.Text = "Trabajos";
            this.lab_CHNG_Tabla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(145, 111);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(180, 22);
            this.txtTitle.TabIndex = 11;
            // 
            // labMinSal
            // 
            this.labMinSal.AutoSize = true;
            this.labMinSal.Location = new System.Drawing.Point(27, 145);
            this.labMinSal.Name = "labMinSal";
            this.labMinSal.Size = new System.Drawing.Size(96, 16);
            this.labMinSal.TabIndex = 14;
            this.labMinSal.Text = "Salario Minimo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Salario Maximo";
            // 
            // btnAdd_V1
            // 
            this.btnAdd_V1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAdd_V1.Enabled = false;
            this.btnAdd_V1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd_V1.Location = new System.Drawing.Point(25, 209);
            this.btnAdd_V1.Name = "btnAdd_V1";
            this.btnAdd_V1.Size = new System.Drawing.Size(300, 30);
            this.btnAdd_V1.TabIndex = 16;
            this.btnAdd_V1.Text = "Añadir Trabajo V1";
            this.btnAdd_V1.UseVisualStyleBackColor = false;
            this.btnAdd_V1.Click += new System.EventHandler(this.btnAddV1_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(357, 408);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(320, 30);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refrescar";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAdd_V4
            // 
            this.btnAdd_V4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAdd_V4.Enabled = false;
            this.btnAdd_V4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd_V4.Location = new System.Drawing.Point(25, 317);
            this.btnAdd_V4.Name = "btnAdd_V4";
            this.btnAdd_V4.Size = new System.Drawing.Size(300, 30);
            this.btnAdd_V4.TabIndex = 18;
            this.btnAdd_V4.Text = "Añadir Trabajo V4";
            this.btnAdd_V4.UseVisualStyleBackColor = false;
            this.btnAdd_V4.Click += new System.EventHandler(this.btnAddV4_Click);
            // 
            // btnAdd_V3
            // 
            this.btnAdd_V3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAdd_V3.Enabled = false;
            this.btnAdd_V3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd_V3.Location = new System.Drawing.Point(25, 281);
            this.btnAdd_V3.Name = "btnAdd_V3";
            this.btnAdd_V3.Size = new System.Drawing.Size(300, 30);
            this.btnAdd_V3.TabIndex = 19;
            this.btnAdd_V3.Text = "Añadir Trabajo V3";
            this.btnAdd_V3.UseVisualStyleBackColor = false;
            this.btnAdd_V3.Click += new System.EventHandler(this.btnAddV3_Click);
            // 
            // btnAdd_V2
            // 
            this.btnAdd_V2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAdd_V2.Enabled = false;
            this.btnAdd_V2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd_V2.Location = new System.Drawing.Point(25, 245);
            this.btnAdd_V2.Name = "btnAdd_V2";
            this.btnAdd_V2.Size = new System.Drawing.Size(300, 30);
            this.btnAdd_V2.TabIndex = 20;
            this.btnAdd_V2.Text = "Añadir Trabajo V2";
            this.btnAdd_V2.UseVisualStyleBackColor = false;
            this.btnAdd_V2.Click += new System.EventHandler(this.btnAddV2_Click);
            // 
            // labTrabajo
            // 
            this.labTrabajo.AutoSize = true;
            this.labTrabajo.Location = new System.Drawing.Point(27, 117);
            this.labTrabajo.Name = "labTrabajo";
            this.labTrabajo.Size = new System.Drawing.Size(55, 16);
            this.labTrabajo.TabIndex = 21;
            this.labTrabajo.Text = "Trabajo";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(145, 139);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(180, 22);
            this.txtMin.TabIndex = 22;
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(145, 167);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(180, 22);
            this.txtMax.TabIndex = 23;
            // 
            // FormConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 450);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.labTrabajo);
            this.Controls.Add(this.btnAdd_V2);
            this.Controls.Add(this.btnAdd_V3);
            this.Controls.Add(this.btnAdd_V4);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAdd_V1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labMinSal);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lab_CHNG_Tabla);
            this.Controls.Add(this.listBSelect);
            this.Controls.Add(this.labTabla);
            this.Controls.Add(this.btnDesconectar);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.labConStatus);
            this.Name = "FormConnexion";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labConStatus;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnDesconectar;
        private System.Windows.Forms.Label labTabla;
        private System.Windows.Forms.ListBox listBSelect;
        private System.Windows.Forms.Label lab_CHNG_Tabla;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label labMinSal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd_V1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd_V4;
        private System.Windows.Forms.Button btnAdd_V3;
        private System.Windows.Forms.Button btnAdd_V2;
        private System.Windows.Forms.Label labTrabajo;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtMax;
    }
}

