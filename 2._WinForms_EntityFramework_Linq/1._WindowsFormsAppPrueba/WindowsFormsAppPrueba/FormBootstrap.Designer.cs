namespace WindowsFormsAppPrueba
{
    partial class FormBootstrap
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
            this.labTitle = new System.Windows.Forms.Label();
            this.labLocation = new System.Windows.Forms.Label();
            this.labPercentComplete = new System.Windows.Forms.Label();
            this.labStatus = new System.Windows.Forms.Label();
            this.labDuration = new System.Windows.Forms.Label();
            this.labStartDate = new System.Windows.Forms.Label();
            this.labDescription = new System.Windows.Forms.Label();
            this.labEnviroment = new System.Windows.Forms.Label();
            this.labCriticity = new System.Windows.Forms.Label();
            this.labType = new System.Windows.Forms.Label();
            this.chckBoxEmail = new System.Windows.Forms.CheckBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBoxType = new System.Windows.Forms.ComboBox();
            this.cmbBoxCriticity = new System.Windows.Forms.ComboBox();
            this.chckBoxProd = new System.Windows.Forms.CheckBox();
            this.chckBoxDemo = new System.Windows.Forms.CheckBox();
            this.chckBoxPreprod = new System.Windows.Forms.CheckBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.cmbBoxStatus = new System.Windows.Forms.ComboBox();
            this.cmBoxLocation = new System.Windows.Forms.ComboBox();
            this.cmbBoxPercent = new System.Windows.Forms.ComboBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numUDDuration = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numUDDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.Location = new System.Drawing.Point(73, 51);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(46, 20);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "Title";
            // 
            // labLocation
            // 
            this.labLocation.AutoSize = true;
            this.labLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labLocation.Location = new System.Drawing.Point(404, 51);
            this.labLocation.Name = "labLocation";
            this.labLocation.Size = new System.Drawing.Size(81, 20);
            this.labLocation.TabIndex = 1;
            this.labLocation.Text = "Location";
            // 
            // labPercentComplete
            // 
            this.labPercentComplete.AutoSize = true;
            this.labPercentComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPercentComplete.Location = new System.Drawing.Point(438, 387);
            this.labPercentComplete.Name = "labPercentComplete";
            this.labPercentComplete.Size = new System.Drawing.Size(159, 20);
            this.labPercentComplete.TabIndex = 2;
            this.labPercentComplete.Text = "Percent Complete";
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labStatus.Location = new System.Drawing.Point(72, 387);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(63, 20);
            this.labStatus.TabIndex = 3;
            this.labStatus.Text = "Status";
            // 
            // labDuration
            // 
            this.labDuration.AutoSize = true;
            this.labDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDuration.Location = new System.Drawing.Point(438, 318);
            this.labDuration.Name = "labDuration";
            this.labDuration.Size = new System.Drawing.Size(169, 20);
            this.labDuration.TabIndex = 4;
            this.labDuration.Text = "Duration (in hours)";
            // 
            // labStartDate
            // 
            this.labStartDate.AutoSize = true;
            this.labStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labStartDate.Location = new System.Drawing.Point(72, 318);
            this.labStartDate.Name = "labStartDate";
            this.labStartDate.Size = new System.Drawing.Size(96, 20);
            this.labStartDate.TabIndex = 5;
            this.labStartDate.Text = "Start Date";
            // 
            // labDescription
            // 
            this.labDescription.AutoSize = true;
            this.labDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDescription.Location = new System.Drawing.Point(72, 215);
            this.labDescription.Name = "labDescription";
            this.labDescription.Size = new System.Drawing.Size(106, 20);
            this.labDescription.TabIndex = 6;
            this.labDescription.Text = "Description";
            // 
            // labEnviroment
            // 
            this.labEnviroment.AutoSize = true;
            this.labEnviroment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEnviroment.Location = new System.Drawing.Point(567, 118);
            this.labEnviroment.Name = "labEnviroment";
            this.labEnviroment.Size = new System.Drawing.Size(103, 20);
            this.labEnviroment.TabIndex = 7;
            this.labEnviroment.Text = "Enviroment";
            // 
            // labCriticity
            // 
            this.labCriticity.AutoSize = true;
            this.labCriticity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labCriticity.Location = new System.Drawing.Point(319, 118);
            this.labCriticity.Name = "labCriticity";
            this.labCriticity.Size = new System.Drawing.Size(75, 20);
            this.labCriticity.TabIndex = 8;
            this.labCriticity.Text = "Criticity";
            // 
            // labType
            // 
            this.labType.AutoSize = true;
            this.labType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labType.Location = new System.Drawing.Point(73, 118);
            this.labType.Name = "labType";
            this.labType.Size = new System.Drawing.Size(49, 20);
            this.labType.TabIndex = 9;
            this.labType.Text = "Type";
            // 
            // chckBoxEmail
            // 
            this.chckBoxEmail.AutoSize = true;
            this.chckBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckBoxEmail.Location = new System.Drawing.Point(76, 463);
            this.chckBoxEmail.Name = "chckBoxEmail";
            this.chckBoxEmail.Size = new System.Drawing.Size(331, 22);
            this.chckBoxEmail.TabIndex = 10;
            this.chckBoxEmail.Text = "Check here if you want to send an email";
            this.chckBoxEmail.UseVisualStyleBackColor = true;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(76, 74);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(310, 22);
            this.txtTitle.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Create a new task";
            // 
            // cmbBoxType
            // 
            this.cmbBoxType.FormattingEnabled = true;
            this.cmbBoxType.Items.AddRange(new object[] {
            "Incident 1",
            "Incident 2",
            "Incident 3",
            "Incident 4"});
            this.cmbBoxType.Location = new System.Drawing.Point(76, 141);
            this.cmbBoxType.Name = "cmbBoxType";
            this.cmbBoxType.Size = new System.Drawing.Size(200, 24);
            this.cmbBoxType.TabIndex = 15;
            // 
            // cmbBoxCriticity
            // 
            this.cmbBoxCriticity.FormattingEnabled = true;
            this.cmbBoxCriticity.Items.AddRange(new object[] {
            "Minor 1",
            "Minor 2",
            "Minor 3"});
            this.cmbBoxCriticity.Location = new System.Drawing.Point(323, 141);
            this.cmbBoxCriticity.Name = "cmbBoxCriticity";
            this.cmbBoxCriticity.Size = new System.Drawing.Size(200, 24);
            this.cmbBoxCriticity.TabIndex = 16;
            // 
            // chckBoxProd
            // 
            this.chckBoxProd.AutoSize = true;
            this.chckBoxProd.Location = new System.Drawing.Point(571, 145);
            this.chckBoxProd.Name = "chckBoxProd";
            this.chckBoxProd.Size = new System.Drawing.Size(58, 20);
            this.chckBoxProd.TabIndex = 17;
            this.chckBoxProd.Text = "Prod";
            this.chckBoxProd.UseVisualStyleBackColor = true;
            // 
            // chckBoxDemo
            // 
            this.chckBoxDemo.AutoSize = true;
            this.chckBoxDemo.Location = new System.Drawing.Point(571, 197);
            this.chckBoxDemo.Name = "chckBoxDemo";
            this.chckBoxDemo.Size = new System.Drawing.Size(66, 20);
            this.chckBoxDemo.TabIndex = 18;
            this.chckBoxDemo.Text = "Demo";
            this.chckBoxDemo.UseVisualStyleBackColor = true;
            // 
            // chckBoxPreprod
            // 
            this.chckBoxPreprod.AutoSize = true;
            this.chckBoxPreprod.Location = new System.Drawing.Point(571, 171);
            this.chckBoxPreprod.Name = "chckBoxPreprod";
            this.chckBoxPreprod.Size = new System.Drawing.Size(78, 20);
            this.chckBoxPreprod.TabIndex = 19;
            this.chckBoxPreprod.Text = "Preprod";
            this.chckBoxPreprod.UseVisualStyleBackColor = true;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(76, 239);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(642, 63);
            this.txtDesc.TabIndex = 20;
            // 
            // dateStart
            // 
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStart.Location = new System.Drawing.Point(76, 341);
            this.dateStart.Name = "dateStart";
            this.dateStart.ShowCheckBox = true;
            this.dateStart.Size = new System.Drawing.Size(250, 22);
            this.dateStart.TabIndex = 21;
            this.dateStart.Value = new System.DateTime(2025, 11, 3, 0, 0, 0, 0);
            // 
            // cmbBoxStatus
            // 
            this.cmbBoxStatus.FormattingEnabled = true;
            this.cmbBoxStatus.Items.AddRange(new object[] {
            "Desing",
            "Doc",
            "WIP",
            "Testing",
            "DONE"});
            this.cmbBoxStatus.Location = new System.Drawing.Point(76, 410);
            this.cmbBoxStatus.Name = "cmbBoxStatus";
            this.cmbBoxStatus.Size = new System.Drawing.Size(250, 24);
            this.cmbBoxStatus.TabIndex = 23;
            // 
            // cmBoxLocation
            // 
            this.cmBoxLocation.FormattingEnabled = true;
            this.cmBoxLocation.Items.AddRange(new object[] {
            "Location 1",
            "Location 2",
            "Location 3",
            "Location 4",
            "Location 5",
            "Location 6"});
            this.cmBoxLocation.Location = new System.Drawing.Point(408, 74);
            this.cmBoxLocation.Name = "cmBoxLocation";
            this.cmBoxLocation.Size = new System.Drawing.Size(310, 24);
            this.cmBoxLocation.TabIndex = 24;
            // 
            // cmbBoxPercent
            // 
            this.cmbBoxPercent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbBoxPercent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbBoxPercent.FormatString = "NO+\"%\"";
            this.cmbBoxPercent.FormattingEnabled = true;
            this.cmbBoxPercent.Items.AddRange(new object[] {
            "0 %",
            "10 %",
            "20 %",
            "30 %",
            "40 %",
            "50 %",
            "60 %",
            "70 %",
            "80 %",
            "90 %",
            "100 %"});
            this.cmbBoxPercent.Location = new System.Drawing.Point(442, 410);
            this.cmbBoxPercent.Name = "cmbBoxPercent";
            this.cmbBoxPercent.Size = new System.Drawing.Size(250, 24);
            this.cmbBoxPercent.TabIndex = 25;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(643, 502);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 26;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(532, 502);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numUDDuration
            // 
            this.numUDDuration.Location = new System.Drawing.Point(442, 341);
            this.numUDDuration.Name = "numUDDuration";
            this.numUDDuration.Size = new System.Drawing.Size(250, 22);
            this.numUDDuration.TabIndex = 28;
            // 
            // FormBootstrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 537);
            this.Controls.Add(this.numUDDuration);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cmbBoxPercent);
            this.Controls.Add(this.cmBoxLocation);
            this.Controls.Add(this.cmbBoxStatus);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.chckBoxPreprod);
            this.Controls.Add(this.chckBoxDemo);
            this.Controls.Add(this.chckBoxProd);
            this.Controls.Add(this.cmbBoxCriticity);
            this.Controls.Add(this.cmbBoxType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.chckBoxEmail);
            this.Controls.Add(this.labType);
            this.Controls.Add(this.labCriticity);
            this.Controls.Add(this.labEnviroment);
            this.Controls.Add(this.labDescription);
            this.Controls.Add(this.labStartDate);
            this.Controls.Add(this.labDuration);
            this.Controls.Add(this.labStatus);
            this.Controls.Add(this.labPercentComplete);
            this.Controls.Add(this.labLocation);
            this.Controls.Add(this.labTitle);
            this.Name = "FormBootstrap";
            this.Text = "FormBootstrap";
            this.Load += new System.EventHandler(this.FormBootstrap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUDDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Label labLocation;
        private System.Windows.Forms.Label labPercentComplete;
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.Label labDuration;
        private System.Windows.Forms.Label labStartDate;
        private System.Windows.Forms.Label labDescription;
        private System.Windows.Forms.Label labEnviroment;
        private System.Windows.Forms.Label labCriticity;
        private System.Windows.Forms.Label labType;
        private System.Windows.Forms.CheckBox chckBoxEmail;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBoxType;
        private System.Windows.Forms.ComboBox cmbBoxCriticity;
        private System.Windows.Forms.CheckBox chckBoxProd;
        private System.Windows.Forms.CheckBox chckBoxDemo;
        private System.Windows.Forms.CheckBox chckBoxPreprod;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.ComboBox cmbBoxStatus;
        private System.Windows.Forms.ComboBox cmBoxLocation;
        private System.Windows.Forms.ComboBox cmbBoxPercent;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numUDDuration;
    }
}