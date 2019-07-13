namespace ProyectoFinal_Rafael.UI.Consultas
{
    partial class cUsuarios
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
            this.ConsultadataGridView = new System.Windows.Forms.DataGridView();
            this.Buscarbutton = new System.Windows.Forms.Button();
            this.CriteriotextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FiltrocomboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HastadateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.Hasta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DesdedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ImprimirButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultadataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ConsultadataGridView
            // 
            this.ConsultadataGridView.AllowUserToAddRows = false;
            this.ConsultadataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConsultadataGridView.Location = new System.Drawing.Point(9, 59);
            this.ConsultadataGridView.Name = "ConsultadataGridView";
            this.ConsultadataGridView.Size = new System.Drawing.Size(786, 375);
            this.ConsultadataGridView.TabIndex = 28;
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.Image = global::ProyectoFinal_Rafael.Properties.Resources.search_13_16;
            this.Buscarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Buscarbutton.Location = new System.Drawing.Point(728, 29);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(67, 23);
            this.Buscarbutton.TabIndex = 27;
            this.Buscarbutton.Text = "Buscar";
            this.Buscarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Buscarbutton.UseVisualStyleBackColor = true;
            this.Buscarbutton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // CriteriotextBox
            // 
            this.CriteriotextBox.Location = new System.Drawing.Point(339, 32);
            this.CriteriotextBox.Name = "CriteriotextBox";
            this.CriteriotextBox.Size = new System.Drawing.Size(383, 20);
            this.CriteriotextBox.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Criterio";
            // 
            // FiltrocomboBox
            // 
            this.FiltrocomboBox.FormattingEnabled = true;
            this.FiltrocomboBox.Items.AddRange(new object[] {
            "Todo",
            "ID",
            "Nombre",
            "email",
            "usuario"});
            this.FiltrocomboBox.Location = new System.Drawing.Point(213, 31);
            this.FiltrocomboBox.Name = "FiltrocomboBox";
            this.FiltrocomboBox.Size = new System.Drawing.Size(120, 21);
            this.FiltrocomboBox.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Filtro";
            // 
            // HastadateTimePicker
            // 
            this.HastadateTimePicker.CustomFormat = "dd/mm/yyyy";
            this.HastadateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.HastadateTimePicker.Location = new System.Drawing.Point(112, 32);
            this.HastadateTimePicker.Name = "HastadateTimePicker";
            this.HastadateTimePicker.Size = new System.Drawing.Size(95, 20);
            this.HastadateTimePicker.TabIndex = 22;
            // 
            // Hasta
            // 
            this.Hasta.AutoSize = true;
            this.Hasta.Location = new System.Drawing.Point(109, 16);
            this.Hasta.Name = "Hasta";
            this.Hasta.Size = new System.Drawing.Size(35, 13);
            this.Hasta.TabIndex = 21;
            this.Hasta.Text = "Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Desde";
            // 
            // DesdedateTimePicker
            // 
            this.DesdedateTimePicker.CustomFormat = "dd/mm/yyyy";
            this.DesdedateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DesdedateTimePicker.Location = new System.Drawing.Point(9, 32);
            this.DesdedateTimePicker.Name = "DesdedateTimePicker";
            this.DesdedateTimePicker.Size = new System.Drawing.Size(97, 20);
            this.DesdedateTimePicker.TabIndex = 19;
            // 
            // ImprimirButton
            // 
            this.ImprimirButton.Image = global::ProyectoFinal_Rafael.Properties.Resources.printer_3_24;
            this.ImprimirButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImprimirButton.Location = new System.Drawing.Point(12, 440);
            this.ImprimirButton.Name = "ImprimirButton";
            this.ImprimirButton.Size = new System.Drawing.Size(80, 27);
            this.ImprimirButton.TabIndex = 29;
            this.ImprimirButton.Text = "Imprimir";
            this.ImprimirButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ImprimirButton.UseVisualStyleBackColor = true;
            // 
            // cUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 479);
            this.Controls.Add(this.ImprimirButton);
            this.Controls.Add(this.ConsultadataGridView);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.CriteriotextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FiltrocomboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HastadateTimePicker);
            this.Controls.Add(this.Hasta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DesdedateTimePicker);
            this.Name = "cUsuarios";
            this.Text = "cUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.ConsultadataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ConsultadataGridView;
        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.TextBox CriteriotextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox FiltrocomboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker HastadateTimePicker;
        private System.Windows.Forms.Label Hasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DesdedateTimePicker;
        private System.Windows.Forms.Button ImprimirButton;
    }
}