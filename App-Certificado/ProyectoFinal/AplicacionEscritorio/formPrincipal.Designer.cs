namespace AplicacionEscritorio
{
    partial class formPrincipal
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
            this.components = new System.ComponentModel.Container();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.pbxArticulo = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tbxFiltro = new System.Windows.Forms.TextBox();
            this.lblFiltroRapido = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.cbxCampo = new System.Windows.Forms.ComboBox();
            this.lblFiltroAvanzado = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbxCriterio = new System.Windows.Forms.ComboBox();
            this.tbxValor = new System.Windows.Forms.TextBox();
            this.lblFiltroValor = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblCampo = new System.Windows.Forms.Label();
            this.btnLimpiarFiltro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProductos.Location = new System.Drawing.Point(12, 54);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(708, 266);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvProductos_DataError);
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(42, 326);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(146, 326);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 2;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(257, 326);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // pbxArticulo
            // 
            this.pbxArticulo.Location = new System.Drawing.Point(741, 94);
            this.pbxArticulo.Name = "pbxArticulo";
            this.pbxArticulo.Size = new System.Drawing.Size(123, 202);
            this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxArticulo.TabIndex = 4;
            this.pbxArticulo.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tbxFiltro
            // 
            this.tbxFiltro.Location = new System.Drawing.Point(87, 27);
            this.tbxFiltro.Name = "tbxFiltro";
            this.tbxFiltro.Size = new System.Drawing.Size(171, 20);
            this.tbxFiltro.TabIndex = 5;
            this.tbxFiltro.TextChanged += new System.EventHandler(this.tbxFiltro_TextChanged);
            // 
            // lblFiltroRapido
            // 
            this.lblFiltroRapido.AutoSize = true;
            this.lblFiltroRapido.Location = new System.Drawing.Point(9, 30);
            this.lblFiltroRapido.Name = "lblFiltroRapido";
            this.lblFiltroRapido.Size = new System.Drawing.Size(69, 13);
            this.lblFiltroRapido.TabIndex = 6;
            this.lblFiltroRapido.Text = "Filtro Rapido:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(778, 25);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 7;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // cbxCampo
            // 
            this.cbxCampo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCampo.FormattingEnabled = true;
            this.cbxCampo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxCampo.Location = new System.Drawing.Point(361, 27);
            this.cbxCampo.Name = "cbxCampo";
            this.cbxCampo.Size = new System.Drawing.Size(121, 21);
            this.cbxCampo.TabIndex = 8;
            this.cbxCampo.SelectedIndexChanged += new System.EventHandler(this.cbxCampo_SelectedIndexChanged);
            // 
            // lblFiltroAvanzado
            // 
            this.lblFiltroAvanzado.AutoSize = true;
            this.lblFiltroAvanzado.Location = new System.Drawing.Point(272, 30);
            this.lblFiltroAvanzado.Name = "lblFiltroAvanzado";
            this.lblFiltroAvanzado.Size = new System.Drawing.Size(83, 13);
            this.lblFiltroAvanzado.TabIndex = 9;
            this.lblFiltroAvanzado.Text = "Filtro Avanzado:";
            // 
            // cbxCriterio
            // 
            this.cbxCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCriterio.FormattingEnabled = true;
            this.cbxCriterio.Location = new System.Drawing.Point(488, 27);
            this.cbxCriterio.Name = "cbxCriterio";
            this.cbxCriterio.Size = new System.Drawing.Size(121, 21);
            this.cbxCriterio.TabIndex = 10;
            // 
            // tbxValor
            // 
            this.tbxValor.Location = new System.Drawing.Point(615, 27);
            this.tbxValor.Name = "tbxValor";
            this.tbxValor.Size = new System.Drawing.Size(131, 20);
            this.tbxValor.TabIndex = 11;
            // 
            // lblFiltroValor
            // 
            this.lblFiltroValor.AutoSize = true;
            this.lblFiltroValor.Location = new System.Drawing.Point(662, 9);
            this.lblFiltroValor.Name = "lblFiltroValor";
            this.lblFiltroValor.Size = new System.Drawing.Size(34, 13);
            this.lblFiltroValor.TabIndex = 12;
            this.lblFiltroValor.Text = "Valor:";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(529, 9);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(42, 13);
            this.lblCriterio.TabIndex = 13;
            this.lblCriterio.Text = "Criterio:";
            // 
            // lblCampo
            // 
            this.lblCampo.AutoSize = true;
            this.lblCampo.Location = new System.Drawing.Point(402, 9);
            this.lblCampo.Name = "lblCampo";
            this.lblCampo.Size = new System.Drawing.Size(43, 13);
            this.lblCampo.TabIndex = 14;
            this.lblCampo.Text = "Campo:";
            // 
            // btnLimpiarFiltro
            // 
            this.btnLimpiarFiltro.Location = new System.Drawing.Point(778, 54);
            this.btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            this.btnLimpiarFiltro.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarFiltro.TabIndex = 15;
            this.btnLimpiarFiltro.Text = "Limpiar Filtro";
            this.btnLimpiarFiltro.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltro.Click += new System.EventHandler(this.btnLimpiarFiltro_Click);
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 356);
            this.Controls.Add(this.btnLimpiarFiltro);
            this.Controls.Add(this.lblCampo);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.lblFiltroValor);
            this.Controls.Add(this.tbxValor);
            this.Controls.Add(this.cbxCriterio);
            this.Controls.Add(this.lblFiltroAvanzado);
            this.Controls.Add(this.cbxCampo);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.lblFiltroRapido);
            this.Controls.Add(this.tbxFiltro);
            this.Controls.Add(this.pbxArticulo);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvProductos);
            this.Name = "formPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catalogo";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.PictureBox pbxArticulo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox tbxFiltro;
        private System.Windows.Forms.Label lblFiltroRapido;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox cbxCampo;
        private System.Windows.Forms.Label lblFiltroAvanzado;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cbxCriterio;
        private System.Windows.Forms.TextBox tbxValor;
        private System.Windows.Forms.Label lblFiltroValor;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Label lblCampo;
        private System.Windows.Forms.Button btnLimpiarFiltro;
    }
}

