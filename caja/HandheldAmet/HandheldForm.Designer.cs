namespace CajaAmet
{
    partial class HandheldForm
    {
        private System.ComponentModel.IContainer components = null;

        // Top Status Bar Controls
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblAgent;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Label lblNetworkDot;
        private System.Windows.Forms.Label lblNetworkText;

        // Main Header Controls
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlHeaderAccent;

        // Bottom Navigation Bar Controls
        private System.Windows.Forms.Panel pnlNavbar;
        private System.Windows.Forms.Button btnTabNueva;
        private System.Windows.Forms.Button btnTabHistorial;
        private System.Windows.Forms.Button btnTabCatalogo;
        private System.Windows.Forms.Button btnSalir;

        // Main swapping panels
        private System.Windows.Forms.Panel pnlNuevaActa;
        private System.Windows.Forms.Panel pnlHistorial;
        private System.Windows.Forms.Panel pnlCatalogo;

        // Panel: Nueva Acta Controls
        private System.Windows.Forms.Label lblTitleInfractor;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        
        private System.Windows.Forms.Label lblTitleVehiculo;
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label lblTipoVehiculo;
        private System.Windows.Forms.ComboBox cmbTipoVehiculo;
        private System.Windows.Forms.Label lblDescripcionVehiculo;
        private System.Windows.Forms.TextBox txtDescripcionVehiculo;

        private System.Windows.Forms.Label lblTitleInfraccion;
        private System.Windows.Forms.Label lblInfraccion;
        private System.Windows.Forms.ComboBox cmbInfraccion;
        private System.Windows.Forms.CheckBox chkRetencion;
        private System.Windows.Forms.Label lblGrua;
        private System.Windows.Forms.TextBox txtGrua;
        
        private System.Windows.Forms.Label lblIdActa;
        private System.Windows.Forms.TextBox txtIdActa;
        
        private System.Windows.Forms.Label lblMontoBase;
        private System.Windows.Forms.Label lblMontoBaseValue;

        private System.Windows.Forms.PictureBox picEvidencia;
        private System.Windows.Forms.Button btnCapturar;
        private System.Windows.Forms.Button btnFirmar;
        private System.Windows.Forms.Label lblFirmaStatus;
        private System.Windows.Forms.Button btnRegistrar;

        // Panel: Historial Controls
        private System.Windows.Forms.Label lblHistorialTitle;
        private System.Windows.Forms.DataGridView dgvActas;
        private System.Windows.Forms.Button btnSincronizar;
        private System.Windows.Forms.Button btnSeedPruebas;
        private System.Windows.Forms.ProgressBar prgSync;
        private System.Windows.Forms.Label lblSyncStatus;

        // Panel: Catálogo Controls
        private System.Windows.Forms.Label lblCatalogoTitle;
        private System.Windows.Forms.DataGridView dgvCatalogo;

        // Utilities
        private System.Windows.Forms.Timer timerNetwork;

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
            this.components = new System.ComponentModel.Container();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblAgent = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.lblNetworkDot = new System.Windows.Forms.Label();
            this.lblNetworkText = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlHeaderAccent = new System.Windows.Forms.Panel();
            this.pnlNavbar = new System.Windows.Forms.Panel();
            this.btnTabNueva = new System.Windows.Forms.Button();
            this.btnTabHistorial = new System.Windows.Forms.Button();
            this.btnTabCatalogo = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlNuevaActa = new System.Windows.Forms.Panel();
            this.lblTitleInfractor = new System.Windows.Forms.Label();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTitleVehiculo = new System.Windows.Forms.Label();
            this.lblPlaca = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.lblTipoVehiculo = new System.Windows.Forms.Label();
            this.cmbTipoVehiculo = new System.Windows.Forms.ComboBox();
            this.lblDescripcionVehiculo = new System.Windows.Forms.Label();
            this.txtDescripcionVehiculo = new System.Windows.Forms.TextBox();
            this.lblTitleInfraccion = new System.Windows.Forms.Label();
            this.lblInfraccion = new System.Windows.Forms.Label();
            this.cmbInfraccion = new System.Windows.Forms.ComboBox();
            this.chkRetencion = new System.Windows.Forms.CheckBox();
            this.lblGrua = new System.Windows.Forms.Label();
            this.txtGrua = new System.Windows.Forms.TextBox();
            this.lblIdActa = new System.Windows.Forms.Label();
            this.txtIdActa = new System.Windows.Forms.TextBox();
            this.lblMontoBase = new System.Windows.Forms.Label();
            this.lblMontoBaseValue = new System.Windows.Forms.Label();
            this.picEvidencia = new System.Windows.Forms.PictureBox();
            this.btnCapturar = new System.Windows.Forms.Button();
            this.btnFirmar = new System.Windows.Forms.Button();
            this.lblFirmaStatus = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.pnlHistorial = new System.Windows.Forms.Panel();
            this.lblHistorialTitle = new System.Windows.Forms.Label();
            this.dgvActas = new System.Windows.Forms.DataGridView();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.btnSeedPruebas = new System.Windows.Forms.Button();
            this.prgSync = new System.Windows.Forms.ProgressBar();
            this.lblSyncStatus = new System.Windows.Forms.Label();
            this.pnlCatalogo = new System.Windows.Forms.Panel();
            this.lblCatalogoTitle = new System.Windows.Forms.Label();
            this.dgvCatalogo = new System.Windows.Forms.DataGridView();
            this.timerNetwork = new System.Windows.Forms.Timer(this.components);
            this.pnlStatus.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlNavbar.SuspendLayout();
            this.pnlNuevaActa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEvidencia)).BeginInit();
            this.pnlHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActas)).BeginInit();
            this.pnlCatalogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlStatus.Controls.Add(this.lblAgent);
            this.pnlStatus.Controls.Add(this.lblDevice);
            this.pnlStatus.Controls.Add(this.lblNetworkDot);
            this.pnlStatus.Controls.Add(this.lblNetworkText);
            this.pnlStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatus.Location = new System.Drawing.Point(0, 0);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(464, 40);
            this.pnlStatus.TabIndex = 0;
            // 
            // lblAgent
            // 
            this.lblAgent.AutoSize = true;
            this.lblAgent.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblAgent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblAgent.Location = new System.Drawing.Point(12, 13);
            this.lblAgent.Name = "lblAgent";
            this.lblAgent.Size = new System.Drawing.Size(107, 13);
            this.lblAgent.TabIndex = 0;
            this.lblAgent.Text = "Agente: Cargando...";
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblDevice.Location = new System.Drawing.Point(215, 13);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(95, 13);
            this.lblDevice.TabIndex = 1;
            this.lblDevice.Text = "Disp: HW-DIGE-00";
            // 
            // lblNetworkDot
            // 
            this.lblNetworkDot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetworkDot.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblNetworkDot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(222)))), ((int)(((byte)(128)))));
            this.lblNetworkDot.Location = new System.Drawing.Point(325, 8);
            this.lblNetworkDot.Name = "lblNetworkDot";
            this.lblNetworkDot.Size = new System.Drawing.Size(20, 20);
            this.lblNetworkDot.TabIndex = 2;
            this.lblNetworkDot.Text = "●";
            this.lblNetworkDot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNetworkText
            // 
            this.lblNetworkText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetworkText.AutoSize = true;
            this.lblNetworkText.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblNetworkText.ForeColor = System.Drawing.Color.White;
            this.lblNetworkText.Location = new System.Drawing.Point(348, 13);
            this.lblNetworkText.Name = "lblNetworkText";
            this.lblNetworkText.Size = new System.Drawing.Size(104, 13);
            this.lblNetworkText.TabIndex = 3;
            this.lblNetworkText.Text = "En Línea (3G/4G)";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 40);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(464, 60);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(236, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TERMINAL DE FISCALIZACIÓN";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(251)))), ((int)(((byte)(241)))));
            this.lblSubtitle.Location = new System.Drawing.Point(13, 33);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(217, 13);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Registro y Consulta de Actas (Offline-First)";
            // 
            // pnlHeaderAccent
            // 
            this.pnlHeaderAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.pnlHeaderAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderAccent.Location = new System.Drawing.Point(0, 100);
            this.pnlHeaderAccent.Name = "pnlHeaderAccent";
            this.pnlHeaderAccent.Size = new System.Drawing.Size(464, 4);
            this.pnlHeaderAccent.TabIndex = 2;
            // 
            // pnlNavbar
            // 
            this.pnlNavbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.pnlNavbar.Controls.Add(this.btnTabNueva);
            this.pnlNavbar.Controls.Add(this.btnTabHistorial);
            this.pnlNavbar.Controls.Add(this.btnTabCatalogo);
            this.pnlNavbar.Controls.Add(this.btnSalir);
            this.pnlNavbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavbar.Location = new System.Drawing.Point(0, 701);
            this.pnlNavbar.Name = "pnlNavbar";
            this.pnlNavbar.Size = new System.Drawing.Size(464, 60);
            this.pnlNavbar.TabIndex = 6;
            // 
            // btnTabNueva
            // 
            this.btnTabNueva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabNueva.FlatAppearance.BorderSize = 0;
            this.btnTabNueva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabNueva.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnTabNueva.ForeColor = System.Drawing.Color.White;
            this.btnTabNueva.Location = new System.Drawing.Point(10, 10);
            this.btnTabNueva.Name = "btnTabNueva";
            this.btnTabNueva.Size = new System.Drawing.Size(105, 40);
            this.btnTabNueva.TabIndex = 0;
            this.btnTabNueva.Text = "📝 NUEVA\r\nACTA";
            this.btnTabNueva.UseVisualStyleBackColor = true;
            this.btnTabNueva.Click += new System.EventHandler(this.btnTabNueva_Click);
            // 
            // btnTabHistorial
            // 
            this.btnTabHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabHistorial.FlatAppearance.BorderSize = 0;
            this.btnTabHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabHistorial.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnTabHistorial.ForeColor = System.Drawing.Color.White;
            this.btnTabHistorial.Location = new System.Drawing.Point(120, 10);
            this.btnTabHistorial.Name = "btnTabHistorial";
            this.btnTabHistorial.Size = new System.Drawing.Size(105, 40);
            this.btnTabHistorial.TabIndex = 1;
            this.btnTabHistorial.Text = "📂 VER\r\nHISTORIAL";
            this.btnTabHistorial.UseVisualStyleBackColor = true;
            this.btnTabHistorial.Click += new System.EventHandler(this.btnTabHistorial_Click);
            // 
            // btnTabCatalogo
            // 
            this.btnTabCatalogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabCatalogo.FlatAppearance.BorderSize = 0;
            this.btnTabCatalogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabCatalogo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnTabCatalogo.ForeColor = System.Drawing.Color.White;
            this.btnTabCatalogo.Location = new System.Drawing.Point(230, 10);
            this.btnTabCatalogo.Name = "btnTabCatalogo";
            this.btnTabCatalogo.Size = new System.Drawing.Size(105, 40);
            this.btnTabCatalogo.TabIndex = 2;
            this.btnTabCatalogo.Text = "📖 LEY\r\n63-17";
            this.btnTabCatalogo.UseVisualStyleBackColor = true;
            this.btnTabCatalogo.Click += new System.EventHandler(this.btnTabCatalogo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(344, 10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(110, 40);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "❌ SALIR\r\nMODO H.";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlNuevaActa
            // 
            this.pnlNuevaActa.AutoScroll = true;
            this.pnlNuevaActa.Controls.Add(this.lblTitleInfractor);
            this.pnlNuevaActa.Controls.Add(this.lblCedula);
            this.pnlNuevaActa.Controls.Add(this.txtCedula);
            this.pnlNuevaActa.Controls.Add(this.lblNombre);
            this.pnlNuevaActa.Controls.Add(this.txtNombre);
            this.pnlNuevaActa.Controls.Add(this.lblTitleVehiculo);
            this.pnlNuevaActa.Controls.Add(this.lblPlaca);
            this.pnlNuevaActa.Controls.Add(this.txtPlaca);
            this.pnlNuevaActa.Controls.Add(this.lblTipoVehiculo);
            this.pnlNuevaActa.Controls.Add(this.cmbTipoVehiculo);
            this.pnlNuevaActa.Controls.Add(this.lblDescripcionVehiculo);
            this.pnlNuevaActa.Controls.Add(this.txtDescripcionVehiculo);
            this.pnlNuevaActa.Controls.Add(this.lblTitleInfraccion);
            this.pnlNuevaActa.Controls.Add(this.lblInfraccion);
            this.pnlNuevaActa.Controls.Add(this.cmbInfraccion);
            this.pnlNuevaActa.Controls.Add(this.chkRetencion);
            this.pnlNuevaActa.Controls.Add(this.lblGrua);
            this.pnlNuevaActa.Controls.Add(this.txtGrua);
            this.pnlNuevaActa.Controls.Add(this.lblIdActa);
            this.pnlNuevaActa.Controls.Add(this.txtIdActa);
            this.pnlNuevaActa.Controls.Add(this.lblMontoBase);
            this.pnlNuevaActa.Controls.Add(this.lblMontoBaseValue);
            this.pnlNuevaActa.Controls.Add(this.picEvidencia);
            this.pnlNuevaActa.Controls.Add(this.btnCapturar);
            this.pnlNuevaActa.Controls.Add(this.btnFirmar);
            this.pnlNuevaActa.Controls.Add(this.lblFirmaStatus);
            this.pnlNuevaActa.Controls.Add(this.btnRegistrar);
            this.pnlNuevaActa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNuevaActa.Location = new System.Drawing.Point(0, 104);
            this.pnlNuevaActa.Name = "pnlNuevaActa";
            this.pnlNuevaActa.Size = new System.Drawing.Size(464, 597);
            this.pnlNuevaActa.TabIndex = 3;
            // 
            // lblTitleInfractor
            // 
            this.lblTitleInfractor.AutoSize = true;
            this.lblTitleInfractor.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitleInfractor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.lblTitleInfractor.Location = new System.Drawing.Point(15, 15);
            this.lblTitleInfractor.Name = "lblTitleInfractor";
            this.lblTitleInfractor.Size = new System.Drawing.Size(167, 19);
            this.lblTitleInfractor.TabIndex = 0;
            this.lblTitleInfractor.Text = "DATOS DEL INFRACTOR";
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCedula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblCedula.Location = new System.Drawing.Point(15, 45);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(107, 15);
            this.lblCedula.TabIndex = 1;
            this.lblCedula.Text = "Cédula Conductor:";
            // 
            // txtCedula
            // 
            this.txtCedula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtCedula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCedula.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCedula.ForeColor = System.Drawing.Color.White;
            this.txtCedula.Location = new System.Drawing.Point(15, 65);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(415, 25);
            this.txtCedula.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblNombre.Location = new System.Drawing.Point(15, 100);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(113, 15);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre Conductor:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.Location = new System.Drawing.Point(15, 120);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(415, 25);
            this.txtNombre.TabIndex = 4;
            // 
            // lblTitleVehiculo
            // 
            this.lblTitleVehiculo.AutoSize = true;
            this.lblTitleVehiculo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitleVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.lblTitleVehiculo.Location = new System.Drawing.Point(15, 160);
            this.lblTitleVehiculo.Name = "lblTitleVehiculo";
            this.lblTitleVehiculo.Size = new System.Drawing.Size(155, 19);
            this.lblTitleVehiculo.TabIndex = 5;
            this.lblTitleVehiculo.Text = "DATOS DEL VEHÍCULO";
            // 
            // lblPlaca
            // 
            this.lblPlaca.AutoSize = true;
            this.lblPlaca.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPlaca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblPlaca.Location = new System.Drawing.Point(15, 190);
            this.lblPlaca.Name = "lblPlaca";
            this.lblPlaca.Size = new System.Drawing.Size(89, 15);
            this.lblPlaca.TabIndex = 6;
            this.lblPlaca.Text = "Placa Vehículo:";
            // 
            // txtPlaca
            // 
            this.txtPlaca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlaca.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPlaca.ForeColor = System.Drawing.Color.White;
            this.txtPlaca.Location = new System.Drawing.Point(15, 210);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(185, 25);
            this.txtPlaca.TabIndex = 7;
            // 
            // lblTipoVehiculo
            // 
            this.lblTipoVehiculo.AutoSize = true;
            this.lblTipoVehiculo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipoVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblTipoVehiculo.Location = new System.Drawing.Point(215, 190);
            this.lblTipoVehiculo.Name = "lblTipoVehiculo";
            this.lblTipoVehiculo.Size = new System.Drawing.Size(97, 15);
            this.lblTipoVehiculo.TabIndex = 8;
            this.lblTipoVehiculo.Text = "Tipo de Vehículo:";
            // 
            // cmbTipoVehiculo
            // 
            this.cmbTipoVehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoVehiculo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTipoVehiculo.ForeColor = System.Drawing.Color.White;
            this.cmbTipoVehiculo.FormattingEnabled = true;
            this.cmbTipoVehiculo.Location = new System.Drawing.Point(215, 210);
            this.cmbTipoVehiculo.Name = "cmbTipoVehiculo";
            this.cmbTipoVehiculo.Size = new System.Drawing.Size(215, 25);
            this.cmbTipoVehiculo.TabIndex = 9;
            this.cmbTipoVehiculo.SelectedIndexChanged += new System.EventHandler(this.cmbTipoVehiculo_SelectedIndexChanged);
            // 
            // lblDescripcionVehiculo
            // 
            this.lblDescripcionVehiculo.AutoSize = true;
            this.lblDescripcionVehiculo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescripcionVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblDescripcionVehiculo.Location = new System.Drawing.Point(15, 250);
            this.lblDescripcionVehiculo.Name = "lblDescripcionVehiculo";
            this.lblDescripcionVehiculo.Size = new System.Drawing.Size(248, 15);
            this.lblDescripcionVehiculo.TabIndex = 10;
            this.lblDescripcionVehiculo.Text = "Descripción Vehículo (Marca, Modelo, Color):";
            // 
            // txtDescripcionVehiculo
            // 
            this.txtDescripcionVehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtDescripcionVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcionVehiculo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescripcionVehiculo.ForeColor = System.Drawing.Color.White;
            this.txtDescripcionVehiculo.Location = new System.Drawing.Point(15, 270);
            this.txtDescripcionVehiculo.Name = "txtDescripcionVehiculo";
            this.txtDescripcionVehiculo.Size = new System.Drawing.Size(415, 25);
            this.txtDescripcionVehiculo.TabIndex = 11;
            // 
            // lblTitleInfraccion
            // 
            this.lblTitleInfraccion.AutoSize = true;
            this.lblTitleInfraccion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitleInfraccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.lblTitleInfraccion.Location = new System.Drawing.Point(15, 310);
            this.lblTitleInfraccion.Name = "lblTitleInfraccion";
            this.lblTitleInfraccion.Size = new System.Drawing.Size(199, 19);
            this.lblTitleInfraccion.TabIndex = 12;
            this.lblTitleInfraccion.Text = "DETALLES DE LA INFRACCIÓN";
            // 
            // lblInfraccion
            // 
            this.lblInfraccion.AutoSize = true;
            this.lblInfraccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfraccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblInfraccion.Location = new System.Drawing.Point(15, 340);
            this.lblInfraccion.Name = "lblInfraccion";
            this.lblInfraccion.Size = new System.Drawing.Size(126, 15);
            this.lblInfraccion.TabIndex = 13;
            this.lblInfraccion.Text = "Seleccionar Infracción:";
            // 
            // cmbInfraccion
            // 
            this.cmbInfraccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.cmbInfraccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInfraccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbInfraccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbInfraccion.ForeColor = System.Drawing.Color.White;
            this.cmbInfraccion.FormattingEnabled = true;
            this.cmbInfraccion.Location = new System.Drawing.Point(15, 360);
            this.cmbInfraccion.Name = "cmbInfraccion";
            this.cmbInfraccion.Size = new System.Drawing.Size(415, 25);
            this.cmbInfraccion.TabIndex = 14;
            this.cmbInfraccion.SelectedIndexChanged += new System.EventHandler(this.cmbInfraccion_SelectedIndexChanged);
            // 
            // chkRetencion
            // 
            this.chkRetencion.AutoSize = true;
            this.chkRetencion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRetencion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkRetencion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.chkRetencion.Location = new System.Drawing.Point(15, 400);
            this.chkRetencion.Name = "chkRetencion";
            this.chkRetencion.Size = new System.Drawing.Size(176, 19);
            this.chkRetencion.TabIndex = 15;
            this.chkRetencion.Text = "¿Requiere Retención / Grúa?";
            this.chkRetencion.UseVisualStyleBackColor = true;
            this.chkRetencion.CheckedChanged += new System.EventHandler(this.chkRetencion_CheckedChanged);
            // 
            // lblGrua
            // 
            this.lblGrua.AutoSize = true;
            this.lblGrua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGrua.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblGrua.Location = new System.Drawing.Point(215, 400);
            this.lblGrua.Name = "lblGrua";
            this.lblGrua.Size = new System.Drawing.Size(61, 15);
            this.lblGrua.TabIndex = 16;
            this.lblGrua.Text = "No. Grúa:";
            // 
            // txtGrua
            // 
            this.txtGrua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtGrua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGrua.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtGrua.ForeColor = System.Drawing.Color.White;
            this.txtGrua.Location = new System.Drawing.Point(215, 420);
            this.txtGrua.Name = "txtGrua";
            this.txtGrua.Size = new System.Drawing.Size(215, 24);
            this.txtGrua.TabIndex = 17;
            // 
            // lblIdActa
            // 
            this.lblIdActa.AutoSize = true;
            this.lblIdActa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIdActa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblIdActa.Location = new System.Drawing.Point(15, 460);
            this.lblIdActa.Name = "lblIdActa";
            this.lblIdActa.Size = new System.Drawing.Size(81, 15);
            this.lblIdActa.TabIndex = 18;
            this.lblIdActa.Text = "ID de Acta H.:";
            // 
            // txtIdActa
            // 
            this.txtIdActa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.txtIdActa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIdActa.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.txtIdActa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtIdActa.Location = new System.Drawing.Point(100, 460);
            this.txtIdActa.Name = "txtIdActa";
            this.txtIdActa.ReadOnly = true;
            this.txtIdActa.Size = new System.Drawing.Size(100, 16);
            this.txtIdActa.TabIndex = 19;
            this.txtIdActa.Text = "ACTA-2026-0000";
            // 
            // lblMontoBase
            // 
            this.lblMontoBase.AutoSize = true;
            this.lblMontoBase.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMontoBase.ForeColor = System.Drawing.Color.White;
            this.lblMontoBase.Location = new System.Drawing.Point(215, 460);
            this.lblMontoBase.Name = "lblMontoBase";
            this.lblMontoBase.Size = new System.Drawing.Size(95, 19);
            this.lblMontoBase.TabIndex = 20;
            this.lblMontoBase.Text = "Monto Multa:";
            // 
            // lblMontoBaseValue
            // 
            this.lblMontoBaseValue.AutoSize = true;
            this.lblMontoBaseValue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMontoBaseValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.lblMontoBaseValue.Location = new System.Drawing.Point(315, 458);
            this.lblMontoBaseValue.Name = "lblMontoBaseValue";
            this.lblMontoBaseValue.Size = new System.Drawing.Size(76, 21);
            this.lblMontoBaseValue.TabIndex = 21;
            this.lblMontoBaseValue.Text = "RD$ 0.00";
            // 
            // picEvidencia
            // 
            this.picEvidencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.picEvidencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEvidencia.Location = new System.Drawing.Point(15, 500);
            this.picEvidencia.Name = "picEvidencia";
            this.picEvidencia.Size = new System.Drawing.Size(185, 120);
            this.picEvidencia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEvidencia.TabIndex = 22;
            this.picEvidencia.TabStop = false;
            // 
            // btnCapturar
            // 
            this.btnCapturar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnCapturar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapturar.FlatAppearance.BorderSize = 0;
            this.btnCapturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapturar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnCapturar.ForeColor = System.Drawing.Color.White;
            this.btnCapturar.Location = new System.Drawing.Point(215, 500);
            this.btnCapturar.Name = "btnCapturar";
            this.btnCapturar.Size = new System.Drawing.Size(215, 32);
            this.btnCapturar.TabIndex = 23;
            this.btnCapturar.Text = "📷 CAPTURAR EVIDENCIA";
            this.btnCapturar.UseVisualStyleBackColor = false;
            this.btnCapturar.Click += new System.EventHandler(this.btnCapturar_Click);
            // 
            // btnFirmar
            // 
            this.btnFirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnFirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirmar.FlatAppearance.BorderSize = 0;
            this.btnFirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirmar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnFirmar.ForeColor = System.Drawing.Color.White;
            this.btnFirmar.Location = new System.Drawing.Point(215, 542);
            this.btnFirmar.Name = "btnFirmar";
            this.btnFirmar.Size = new System.Drawing.Size(215, 32);
            this.btnFirmar.TabIndex = 24;
            this.btnFirmar.Text = "✍️ FIRMA DIGITAL INFRACTOR";
            this.btnFirmar.UseVisualStyleBackColor = false;
            this.btnFirmar.Click += new System.EventHandler(this.btnFirmar_Click);
            // 
            // lblFirmaStatus
            // 
            this.lblFirmaStatus.AutoSize = true;
            this.lblFirmaStatus.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblFirmaStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblFirmaStatus.Location = new System.Drawing.Point(216, 582);
            this.lblFirmaStatus.Name = "lblFirmaStatus";
            this.lblFirmaStatus.Size = new System.Drawing.Size(100, 13);
            this.lblFirmaStatus.TabIndex = 25;
            this.lblFirmaStatus.Text = "Firma: PENDIENTE";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(15, 640);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(415, 45);
            this.btnRegistrar.TabIndex = 26;
            this.btnRegistrar.Text = "💾 GUARDAR EN DISPOSITIVO (OFFLINE)";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // pnlHistorial
            // 
            this.pnlHistorial.Controls.Add(this.lblHistorialTitle);
            this.pnlHistorial.Controls.Add(this.dgvActas);
            this.pnlHistorial.Controls.Add(this.btnSincronizar);
            this.pnlHistorial.Controls.Add(this.btnSeedPruebas);
            this.pnlHistorial.Controls.Add(this.prgSync);
            this.pnlHistorial.Controls.Add(this.lblSyncStatus);
            this.pnlHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHistorial.Location = new System.Drawing.Point(0, 104);
            this.pnlHistorial.Name = "pnlHistorial";
            this.pnlHistorial.Size = new System.Drawing.Size(464, 597);
            this.pnlHistorial.TabIndex = 4;
            this.pnlHistorial.Visible = false;
            // 
            // lblHistorialTitle
            // 
            this.lblHistorialTitle.AutoSize = true;
            this.lblHistorialTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHistorialTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.lblHistorialTitle.Location = new System.Drawing.Point(15, 15);
            this.lblHistorialTitle.Name = "lblHistorialTitle";
            this.lblHistorialTitle.Size = new System.Drawing.Size(271, 19);
            this.lblHistorialTitle.TabIndex = 0;
            this.lblHistorialTitle.Text = "ACTAS LOCALES EN ESTE DISPOSITIVO";
            // 
            // dgvActas
            // 
            this.dgvActas.AllowUserToAddRows = false;
            this.dgvActas.AllowUserToDeleteRows = false;
            this.dgvActas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvActas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvActas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvActas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvActas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvActas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvActas.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvActas.ColumnHeadersHeight = 30;
            this.dgvActas.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvActas.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvActas.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.dgvActas.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvActas.EnableHeadersVisualStyles = false;
            this.dgvActas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvActas.Location = new System.Drawing.Point(15, 45);
            this.dgvActas.MultiSelect = false;
            this.dgvActas.Name = "dgvActas";
            this.dgvActas.ReadOnly = true;
            this.dgvActas.RowHeadersVisible = false;
            this.dgvActas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActas.Size = new System.Drawing.Size(434, 450);
            this.dgvActas.TabIndex = 1;
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(118)))), ((int)(((byte)(110)))));
            this.btnSincronizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSincronizar.FlatAppearance.BorderSize = 0;
            this.btnSincronizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSincronizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSincronizar.ForeColor = System.Drawing.Color.White;
            this.btnSincronizar.Location = new System.Drawing.Point(15, 510);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(200, 40);
            this.btnSincronizar.TabIndex = 2;
            this.btnSincronizar.Text = "🔄 SINCRONIZAR A CENTRAL";
            this.btnSincronizar.UseVisualStyleBackColor = false;
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // btnSeedPruebas
            // 
            this.btnSeedPruebas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnSeedPruebas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeedPruebas.FlatAppearance.BorderSize = 0;
            this.btnSeedPruebas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeedPruebas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSeedPruebas.ForeColor = System.Drawing.Color.White;
            this.btnSeedPruebas.Location = new System.Drawing.Point(249, 510);
            this.btnSeedPruebas.Name = "btnSeedPruebas";
            this.btnSeedPruebas.Size = new System.Drawing.Size(200, 40);
            this.btnSeedPruebas.TabIndex = 3;
            this.btnSeedPruebas.Text = "🧪 REGISTROS PRUEBA";
            this.btnSeedPruebas.UseVisualStyleBackColor = false;
            this.btnSeedPruebas.Click += new System.EventHandler(this.btnSeedPruebas_Click);
            // 
            // prgSync
            // 
            this.prgSync.Location = new System.Drawing.Point(15, 560);
            this.prgSync.Name = "prgSync";
            this.prgSync.Size = new System.Drawing.Size(434, 15);
            this.prgSync.TabIndex = 4;
            this.prgSync.Visible = false;
            // 
            // lblSyncStatus
            // 
            this.lblSyncStatus.AutoSize = true;
            this.lblSyncStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblSyncStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.lblSyncStatus.Location = new System.Drawing.Point(15, 578);
            this.lblSyncStatus.Name = "lblSyncStatus";
            this.lblSyncStatus.Size = new System.Drawing.Size(121, 15);
            this.lblSyncStatus.TabIndex = 5;
            this.lblSyncStatus.Text = "Enviando paquetes...";
            this.lblSyncStatus.Visible = false;
            // 
            // pnlCatalogo
            // 
            this.pnlCatalogo.Controls.Add(this.lblCatalogoTitle);
            this.pnlCatalogo.Controls.Add(this.dgvCatalogo);
            this.pnlCatalogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCatalogo.Location = new System.Drawing.Point(0, 104);
            this.pnlCatalogo.Name = "pnlCatalogo";
            this.pnlCatalogo.Size = new System.Drawing.Size(464, 597);
            this.pnlCatalogo.TabIndex = 5;
            this.pnlCatalogo.Visible = false;
            // 
            // lblCatalogoTitle
            // 
            this.lblCatalogoTitle.AutoSize = true;
            this.lblCatalogoTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCatalogoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(212)))), ((int)(((byte)(191)))));
            this.lblCatalogoTitle.Location = new System.Drawing.Point(15, 15);
            this.lblCatalogoTitle.Name = "lblCatalogoTitle";
            this.lblCatalogoTitle.Size = new System.Drawing.Size(262, 19);
            this.lblCatalogoTitle.TabIndex = 0;
            this.lblCatalogoTitle.Text = "CATÁLOGO DE INFRACCIONES LEY 63-17";
            // 
            // dgvCatalogo
            // 
            this.dgvCatalogo.AllowUserToAddRows = false;
            this.dgvCatalogo.AllowUserToDeleteRows = false;
            this.dgvCatalogo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCatalogo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCatalogo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCatalogo.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvCatalogo.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCatalogo.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.dgvCatalogo.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.dgvCatalogo.ColumnHeadersHeight = 30;
            this.dgvCatalogo.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.dgvCatalogo.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCatalogo.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(148)))), ((int)(((byte)(136)))));
            this.dgvCatalogo.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCatalogo.EnableHeadersVisualStyles = false;
            this.dgvCatalogo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvCatalogo.Location = new System.Drawing.Point(15, 45);
            this.dgvCatalogo.MultiSelect = false;
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.ReadOnly = true;
            this.dgvCatalogo.RowHeadersVisible = false;
            this.dgvCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCatalogo.Size = new System.Drawing.Size(434, 530);
            this.dgvCatalogo.TabIndex = 1;
            // 
            // timerNetwork
            // 
            this.timerNetwork.Enabled = true;
            this.timerNetwork.Interval = 3000;
            this.timerNetwork.Tick += new System.EventHandler(this.timerNetwork_Tick);
            // 
            // HandheldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(464, 761);
            this.Controls.Add(this.pnlNuevaActa);
            this.Controls.Add(this.pnlHistorial);
            this.Controls.Add(this.pnlCatalogo);
            this.Controls.Add(this.pnlNavbar);
            this.Controls.Add(this.pnlHeaderAccent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HandheldForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DIGESETT — Handheld Terminal";
            this.Load += new System.EventHandler(this.HandheldForm_Load);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlNavbar.ResumeLayout(false);
            this.pnlNuevaActa.ResumeLayout(false);
            this.pnlNuevaActa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEvidencia)).EndInit();
            this.pnlHistorial.ResumeLayout(false);
            this.pnlHistorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActas)).EndInit();
            this.pnlCatalogo.ResumeLayout(false);
            this.pnlCatalogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
