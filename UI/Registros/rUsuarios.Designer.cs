namespace ProyectoFinal_Rafael.UI.Registros
{
    partial class rUsuarios
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
            this.components = new System.ComponentModel.Container();
            this.Eliminarbutton = new System.Windows.Forms.Button();
            this.Guardarbutton = new System.Windows.Forms.Button();
            this.Nuevobutton = new System.Windows.Forms.Button();
            this.Buscarbutton = new System.Windows.Forms.Button();
            this.FechadateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ConfirmarmaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ClavemaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.UsuariotextBox = new System.Windows.Forms.TextBox();
            this.EmailtextBox = new System.Windows.Forms.TextBox();
            this.NombretextBox = new System.Windows.Forms.TextBox();
            this.IdnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MyerrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.IdnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyerrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // Eliminarbutton
            // 
            this.Eliminarbutton.Image = global::ProyectoFinal_Rafael.Properties.Resources.delete_16;
            this.Eliminarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Eliminarbutton.Location = new System.Drawing.Point(173, 270);
            this.Eliminarbutton.Name = "Eliminarbutton";
            this.Eliminarbutton.Size = new System.Drawing.Size(75, 37);
            this.Eliminarbutton.TabIndex = 39;
            this.Eliminarbutton.Text = "Eliminar";
            this.Eliminarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Eliminarbutton.UseVisualStyleBackColor = true;
            this.Eliminarbutton.Click += new System.EventHandler(this.Eliminarbutton_Click);
            // 
            // Guardarbutton
            // 
            this.Guardarbutton.Image = global::ProyectoFinal_Rafael.Properties.Resources.save_16;
            this.Guardarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Guardarbutton.Location = new System.Drawing.Point(90, 270);
            this.Guardarbutton.Name = "Guardarbutton";
            this.Guardarbutton.Size = new System.Drawing.Size(75, 37);
            this.Guardarbutton.TabIndex = 38;
            this.Guardarbutton.Text = "Guardar";
            this.Guardarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Guardarbutton.UseVisualStyleBackColor = true;
            this.Guardarbutton.Click += new System.EventHandler(this.Guardarbutton_Click);
            // 
            // Nuevobutton
            // 
            this.Nuevobutton.Image = global::ProyectoFinal_Rafael.Properties.Resources.file_16;
            this.Nuevobutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Nuevobutton.Location = new System.Drawing.Point(7, 270);
            this.Nuevobutton.Name = "Nuevobutton";
            this.Nuevobutton.Size = new System.Drawing.Size(70, 37);
            this.Nuevobutton.TabIndex = 37;
            this.Nuevobutton.Text = "Nuevo";
            this.Nuevobutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Nuevobutton.UseVisualStyleBackColor = true;
            this.Nuevobutton.Click += new System.EventHandler(this.Nuevobutton_Click);
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.Image = global::ProyectoFinal_Rafael.Properties.Resources.search_13_16;
            this.Buscarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Buscarbutton.Location = new System.Drawing.Point(162, 4);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(67, 23);
            this.Buscarbutton.TabIndex = 36;
            this.Buscarbutton.Text = "Buscar";
            this.Buscarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Buscarbutton.UseVisualStyleBackColor = true;
            this.Buscarbutton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // FechadateTimePicker
            // 
            this.FechadateTimePicker.CustomFormat = "dd/mm/yyy";
            this.FechadateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechadateTimePicker.Location = new System.Drawing.Point(104, 233);
            this.FechadateTimePicker.Name = "FechadateTimePicker";
            this.FechadateTimePicker.Size = new System.Drawing.Size(127, 20);
            this.FechadateTimePicker.TabIndex = 35;
            // 
            // ConfirmarmaskedTextBox
            // 
            this.ConfirmarmaskedTextBox.Location = new System.Drawing.Point(102, 194);
            this.ConfirmarmaskedTextBox.Name = "ConfirmarmaskedTextBox";
            this.ConfirmarmaskedTextBox.PasswordChar = '*';
            this.ConfirmarmaskedTextBox.Size = new System.Drawing.Size(127, 20);
            this.ConfirmarmaskedTextBox.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Confirmar clave:";
            // 
            // ClavemaskedTextBox
            // 
            this.ClavemaskedTextBox.Location = new System.Drawing.Point(102, 153);
            this.ClavemaskedTextBox.Name = "ClavemaskedTextBox";
            this.ClavemaskedTextBox.PasswordChar = '*';
            this.ClavemaskedTextBox.Size = new System.Drawing.Size(127, 20);
            this.ClavemaskedTextBox.TabIndex = 32;
            // 
            // UsuariotextBox
            // 
            this.UsuariotextBox.Location = new System.Drawing.Point(102, 115);
            this.UsuariotextBox.Name = "UsuariotextBox";
            this.UsuariotextBox.Size = new System.Drawing.Size(127, 20);
            this.UsuariotextBox.TabIndex = 31;
            // 
            // EmailtextBox
            // 
            this.EmailtextBox.Location = new System.Drawing.Point(102, 81);
            this.EmailtextBox.Name = "EmailtextBox";
            this.EmailtextBox.Size = new System.Drawing.Size(127, 20);
            this.EmailtextBox.TabIndex = 30;
            // 
            // NombretextBox
            // 
            this.NombretextBox.Location = new System.Drawing.Point(102, 46);
            this.NombretextBox.Name = "NombretextBox";
            this.NombretextBox.Size = new System.Drawing.Size(127, 20);
            this.NombretextBox.TabIndex = 29;
            // 
            // IdnumericUpDown
            // 
            this.IdnumericUpDown.Location = new System.Drawing.Point(102, 7);
            this.IdnumericUpDown.Name = "IdnumericUpDown";
            this.IdnumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.IdnumericUpDown.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Fecha Ingreso:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Clave:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Usuario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "ID:";
            // 
            // MyerrorProvider
            // 
            this.MyerrorProvider.ContainerControl = this;
            // 
            // rUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 323);
            this.Controls.Add(this.Eliminarbutton);
            this.Controls.Add(this.Guardarbutton);
            this.Controls.Add(this.Nuevobutton);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.FechadateTimePicker);
            this.Controls.Add(this.ConfirmarmaskedTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ClavemaskedTextBox);
            this.Controls.Add(this.UsuariotextBox);
            this.Controls.Add(this.EmailtextBox);
            this.Controls.Add(this.NombretextBox);
            this.Controls.Add(this.IdnumericUpDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "rUsuarios";
            this.Text = "rUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.IdnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyerrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Eliminarbutton;
        private System.Windows.Forms.Button Guardarbutton;
        private System.Windows.Forms.Button Nuevobutton;
        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.DateTimePicker FechadateTimePicker;
        private System.Windows.Forms.MaskedTextBox ConfirmarmaskedTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox ClavemaskedTextBox;
        private System.Windows.Forms.TextBox UsuariotextBox;
        private System.Windows.Forms.TextBox EmailtextBox;
        private System.Windows.Forms.TextBox NombretextBox;
        private System.Windows.Forms.NumericUpDown IdnumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider MyerrorProvider;
    }
}