namespace winform_app
{
    partial class frmAgregarPokemon
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
            this.lblNumero = new System.Windows.Forms.Label();
            this.tbNumero = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblImagen = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblDeb = new System.Windows.Forms.Label();
            this.btnAgregarForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.Location = new System.Drawing.Point(34, 34);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(58, 13);
            this.lblNumero.TabIndex = 1;
            this.lblNumero.Text = "Numero: ";
            // 
            // tbNumero
            // 
            this.tbNumero.Location = new System.Drawing.Point(98, 31);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(180, 20);
            this.tbNumero.TabIndex = 2;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(98, 57);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(180, 20);
            this.tbNombre.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(34, 60);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 13);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre: ";
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(98, 83);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(180, 20);
            this.tbDesc.TabIndex = 6;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(10, 86);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(82, 13);
            this.lblDesc.TabIndex = 5;
            this.lblDesc.Text = "Descripcion: ";
            // 
            // lblImagen
            // 
            this.lblImagen.AutoSize = true;
            this.lblImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImagen.Location = new System.Drawing.Point(114, 106);
            this.lblImagen.Name = "lblImagen";
            this.lblImagen.Size = new System.Drawing.Size(142, 13);
            this.lblImagen.TabIndex = 7;
            this.lblImagen.Text = "Imagen (Proximamente) ";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.Location = new System.Drawing.Point(122, 124);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(122, 13);
            this.lblTipo.TabIndex = 9;
            this.lblTipo.Text = "Tipo (Proximamente)";
            // 
            // lblDeb
            // 
            this.lblDeb.AutoSize = true;
            this.lblDeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeb.Location = new System.Drawing.Point(107, 142);
            this.lblDeb.Name = "lblDeb";
            this.lblDeb.Size = new System.Drawing.Size(150, 13);
            this.lblDeb.TabIndex = 11;
            this.lblDeb.Text = "Debilidad (Proximamente)";
            // 
            // btnAgregarForm
            // 
            this.btnAgregarForm.Location = new System.Drawing.Point(108, 204);
            this.btnAgregarForm.Name = "btnAgregarForm";
            this.btnAgregarForm.Size = new System.Drawing.Size(112, 38);
            this.btnAgregarForm.TabIndex = 13;
            this.btnAgregarForm.Text = "Agregar";
            this.btnAgregarForm.UseVisualStyleBackColor = true;
            this.btnAgregarForm.Click += new System.EventHandler(this.btnAgregarForm_Click);
            // 
            // frmAgregarPokemon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 359);
            this.Controls.Add(this.btnAgregarForm);
            this.Controls.Add(this.lblDeb);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblImagen);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.tbNumero);
            this.Controls.Add(this.lblNumero);
            this.Name = "frmAgregarPokemon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Pokemon";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAgregarPokemon_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox tbNumero;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblImagen;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblDeb;
        private System.Windows.Forms.Button btnAgregarForm;
    }
}