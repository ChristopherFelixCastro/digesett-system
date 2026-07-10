namespace CajaAmet
{
    partial class HandheldForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlAccent;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label lblDescripcionVehiculo;
        private System.Windows.Forms.TextBox txtDescripcionVehiculo;
        private System.Windows.Forms.GroupBox gbTipoVehiculo;
        private System.Windows.Forms.RadioButton rbCarga;
        private System.Windows.Forms.RadioButton rbMotocicleta;
        private System.Windows.Forms.RadioButton rbParticular;
        private System.Windows.Forms.Label lblInfraccion;
        private System.Windows.Forms.ComboBox cmbInfraccion;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.CheckBox chkRetencion;
        private System.Windows.Forms.Label lblGrua;
        private System.Windows.Forms.TextBox txtGrua;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblAgente;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtFecha;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.lblDescripcionVehiculo = new System.Windows.Forms.Label();
            this.txtDescripcionVehiculo = new System.Windows.Forms.TextBox();
            this.gbTipoVehiculo = new System.Windows.Forms.GroupBox();
            this.rbCarga = new System.Windows.Forms.RadioButton();
            this.rbMotocicleta = new System.Windows.Forms.RadioButton();
            this.rbParticular = new System.Windows.Forms.RadioButton();
            this.lblInfraccion = new System.Windows.Forms.Label();
            this.cmbInfraccion = new System.Windows.Forms.ComboBox();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.chkRetencion = new System.Windows.Forms.CheckBox();
            this.lblGrua = new System.Windows.Forms.Label();
            this.txtGrua = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblAgente = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.gbTipoVehiculo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(504, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(306, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "FISCALIZACIÓN - MODO HANDHELD";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblSubtitle.Location = new System.Drawing.Point(18, 40);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(325, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Registro de Acta de Infracción en Vía Pública (Agente de Calle)";
            // 
            // pnlAccent
            // 
            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(74, 222, 128);
            this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAccent.Location = new System.Drawing.Point(0, 75);
            this.pnlAccent.Name = "pnlAccent";
            this.pnlAccent.Size = new System.Drawing.Size(504, 4);
            this.pnlAccent.TabIndex = 1;
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCedula.ForeColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblCedula.Location = new System.Drawing.Point(24, 98);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(126, 15);
            this.lblCedula.TabIndex = 2;
            this.lblCedula.Text = "Cédula Conductor (*):";
            // 
            // txtCedula
            // 
            this.txtCedula.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.txtCedula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCedula.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCedula.ForeColor = System.Drawing.Color.White;
            this.txtCedula.Location = new System.Drawing.Point(27, 116);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(210, 24);
            this.txtCedula.TabIndex = 3;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblNombre.Location = new System.Drawing.Point(260, 98);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(135, 15);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre Conductor (*):";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.Location = new System.Drawing.Point(263, 116);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(210, 24);
            this.txtNombre.TabIndex = 5;
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlaca.ForeColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblPlaca.Location = new System.Drawing.Point(24, 153);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(109, 15);
            this.lblPlaca.TabIndex = 6;
            this.lblPlaca.Text = "Placa Vehículo (*):";
            // 
            // txtPlaca
            // 
            this.txtPlaca.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.txtPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlaca.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaca.ForeColor = System.Drawing.Color.White;
            this.txtPlaca.Location = new System.Drawing.Point(27, 171);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(210, 24);
            this.txtPlaca.TabIndex = 7;
            // 
            // lblDescripcionVehiculo
            // 
            this.lblDescripcionVehiculo.AutoSize = true;
            this.lblDescripcionVehiculo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcionVehiculo.ForeColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblDescripcionVehiculo.Location = new System.Drawing.Point(260, 153);
            this.lblDescripcionVehiculo.Name = "lblDescripcionVehiculo";
            this.lblDescripcionVehiculo.Size = new System.Drawing.Size(126, 15);
            this.lblDescripcionVehiculo.TabIndex = 8;
            this.lblDescripcionVehiculo.Text = "Descripción Vehículo:";
            // 
            // txtDescripcionVehiculo
            // 
            this.txtDescripcionVehiculo.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.txtDescripcionVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcionVehiculo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionVehiculo.ForeColor = System.Drawing.Color.White;
            this.txtDescripcionVehiculo.Location = new System.Drawing.Point(263, 171);
            this.txtDescripcionVehiculo.Name = "txtDescripcionVehiculo";
            this.txtDescripcionVehiculo.Size = new System.Drawing.Size(210, 24);
            this.txtDescripcionVehiculo.TabIndex = 9;
            // 
            // gbTipoVehiculo
            // 
            this.gbTipoVehiculo.Controls.Add(this.rbCarga);
            this.gbTipoVehiculo.Controls.Add(this.rbMotocicleta);
            this.gbTipoVehiculo.Controls.Add(this.rbParticular);
            this.gbTipoVehiculo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTipoVehiculo.ForeColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.gbTipoVehiculo.Location = new System.Drawing.Point(27, 212);
            this.gbTipoVehiculo.Name = "gbTipoVehiculo";
            this.gbTipoVehiculo.Size = new System.Drawing.Size(446, 55);
            this.gbTipoVehiculo.TabIndex = 10;
            this.gbTipoVehiculo.TabStop = false;
            this.gbTipoVehiculo.Text = "Tipo de Vehículo";
            // 
            // rbCarga
            // 
            this.rbCarga.AutoSize = true;
            this.rbCarga.Location = new System.Drawing.Point(298, 23);
            this.rbCarga.Name = "rbCarga";
            this.rbCarga.Size = new System.Drawing.Size(127, 19);
            this.rbCarga.TabIndex = 2;
            this.rbCarga.Text = "Carga / Comercial";
            this.rbCarga.UseVisualStyleBackColor = true;
            this.rbCarga.CheckedChanged += new System.EventHandler(this.rbVehiculo_CheckedChanged);
            // 
            // rbMotocicleta
            // 
            this.rbMotocicleta.AutoSize = true;
            this.rbMotocicleta.Location = new System.Drawing.Point(155, 23);
            this.rbMotocicleta.Name = "rbMotocicleta";
            this.rbMotocicleta.Size = new System.Drawing.Size(90, 19);
            this.rbMotocicleta.TabIndex = 1;
            this.rbMotocicleta.Text = "Motocicleta";
            this.rbMotocicleta.UseVisualStyleBackColor = true;
            this.rbMotocicleta.CheckedChanged += new System.EventHandler(this.rbVehiculo_CheckedChanged);
            // 
            // rbParticular
            // 
            this.rbParticular.AutoSize = true;
            this.rbParticular.Checked = true;
            this.rbParticular.Location = new System.Drawing.Point(18, 23);
            this.rbParticular.Name = "rbParticular";
            this.rbParticular.Size = new System.Drawing.Size(77, 19);
            this.rbParticular.TabIndex = 0;
            this.rbParticular.TabStop = true;
            this.rbParticular.Text = "Particular";
            this.rbParticular.UseVisualStyleBackColor = true;
            this.rbParticular.CheckedChanged += new System.EventHandler(this.rbVehiculo_CheckedChanged);
            // 
            // lblInfraccion
            // 
            this.lblInfraccion.AutoSize = true;
            this.lblInfraccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfraccion.ForeColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblInfraccion.Location = new System.Drawing.Point(24, 283);
            this.lblInfraccion.Name = "lblInfraccion";
            this.lblInfraccion.Size = new System.Drawing.Size(126, 15);
            this.lblInfraccion.TabIndex = 11;
            this.lblInfraccion.Text = "Tipo de Infracción (*):";
            // 
            // cmbInfraccion
            // 
            this.cmbInfraccion.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.cmbInfraccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInfraccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbInfraccion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbInfraccion.ForeColor = System.Drawing.Color.White;
            this.cmbInfraccion.FormattingEnabled = true;
            this.cmbInfraccion.Location = new System.Drawing.Point(27, 301);
            this.cmbInfraccion.Name = "cmbInfraccion";
            this.cmbInfraccion.Size = new System.Drawing.Size(446, 25);
            this.cmbInfraccion.TabIndex = 12;
            this.cmbInfraccion.SelectedIndexChanged += new System.EventHandler(this.cmbInfraccion_SelectedIndexChanged);
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.ForeColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblMonto.Location = new System.Drawing.Point(24, 344);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(130, 15);
            this.lblMonto.TabIndex = 13;
            this.lblMonto.Text = "Monto de Multa (RD$):";
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.Black;
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.ForeColor = System.Drawing.Color.FromArgb(74, 222, 128);
            this.txtMonto.Location = new System.Drawing.Point(27, 362);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(155, 25);
            this.txtMonto.TabIndex = 14;
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkRetencion
            // 
            this.chkRetencion.AutoSize = true;
            this.chkRetencion.Enabled = false;
            this.chkRetencion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRetencion.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.chkRetencion.Location = new System.Drawing.Point(220, 365);
            this.chkRetencion.Name = "chkRetencion";
            this.chkRetencion.Size = new System.Drawing.Size(203, 19);
            this.chkRetencion.TabIndex = 15;
            this.chkRetencion.Text = "Requiere Retención de Vehículo";
            this.chkRetencion.UseVisualStyleBackColor = true;
            this.chkRetencion.CheckedChanged += new System.EventHandler(this.chkRetencion_CheckedChanged);
            // 
            // lblGrua
            // 
            this.lblGrua.AutoSize = true;
            this.lblGrua.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrua.ForeColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblGrua.Location = new System.Drawing.Point(24, 406);
            this.lblGrua.Name = "lblGrua";
            this.lblGrua.Size = new System.Drawing.Size(107, 15);
            this.lblGrua.TabIndex = 16;
            this.lblGrua.Text = "Número de Grúa:";
            // 
            // txtGrua
            // 
            this.txtGrua.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.txtGrua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrua.Enabled = false;
            this.txtGrua.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrua.ForeColor = System.Drawing.Color.White;
            this.txtGrua.Location = new System.Drawing.Point(27, 424);
            this.txtGrua.Name = "txtGrua";
            this.txtGrua.Size = new System.Drawing.Size(210, 24);
            this.txtGrua.TabIndex = 17;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(27, 480);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(298, 38);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.Text = "💾 Registrar e Imprimir Acta";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(341, 480);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(132, 38);
            this.btnVolver.TabIndex = 19;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblAgente
            // 
            this.lblAgente.AutoSize = true;
            this.lblAgente.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgente.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblAgente.Location = new System.Drawing.Point(24, 532);
            this.lblAgente.Name = "lblAgente";
            this.lblAgente.Size = new System.Drawing.Size(107, 15);
            this.lblAgente.TabIndex = 20;
            this.lblAgente.Text = "Agente ID: Ninguno";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblFecha.Location = new System.Drawing.Point(260, 406);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(81, 15);
            this.lblFecha.TabIndex = 21;
            this.lblFecha.Text = "Fecha Hecho:";
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.Color.Black;
            this.txtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.ForeColor = System.Drawing.Color.White;
            this.txtFecha.Location = new System.Drawing.Point(263, 424);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(210, 24);
            this.txtFecha.TabIndex = 22;
            // 
            // HandheldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 31, 15);
            this.ClientSize = new System.Drawing.Size(504, 561);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblAgente);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtGrua);
            this.Controls.Add(this.lblGrua);
            this.Controls.Add(this.chkRetencion);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.cmbInfraccion);
            this.Controls.Add(this.lblInfraccion);
            this.Controls.Add(this.gbTipoVehiculo);
            this.Controls.Add(this.txtDescripcionVehiculo);
            this.Controls.Add(this.lblDescripcionVehiculo);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.lblPlaca);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.pnlAccent);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "HandheldForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DIGESETT — Handheld Mode";
            this.Load += new System.EventHandler(this.HandheldForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.gbTipoVehiculo.ResumeLayout(false);
            this.gbTipoVehiculo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
