namespace CajaAmet
{
    partial class CajaForm
    {
        private System.ComponentModel.IContainer components = null;
<<<<<<< Updated upstream
<<<<<<< Updated upstream

        // Sidebar
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblSidebarTitle;
        private System.Windows.Forms.Label lblSidebarSubtitle;
        private System.Windows.Forms.Button btnNavApertura;
        private System.Windows.Forms.Button btnNavCobro;
        private System.Windows.Forms.Button btnNavMovimientos;
        private System.Windows.Forms.Button btnNavCierre;
        private System.Windows.Forms.Label lblNavCajeroStatus;
        private System.Windows.Forms.Button btnNavVolver;
        private System.Windows.Forms.Panel pnlSidebarAccent;

        // Container Panel
        private System.Windows.Forms.Panel pnlContentContainer;

        // Panel 1: Apertura
        private System.Windows.Forms.Panel pnlApertura;
        private System.Windows.Forms.Label lblAperturaHeader;
        private System.Windows.Forms.Label lblAperturaDesc;
        private System.Windows.Forms.Label lblMontoInicial;
        private System.Windows.Forms.TextBox txtMontoInicial;
        private System.Windows.Forms.Button btnAbrirCaja;
        private System.Windows.Forms.Label lblAperturaStatus;

        // Panel 2: Cobro
        private System.Windows.Forms.Panel pnlCobro;
        private System.Windows.Forms.Label lblCobroHeader;
        private System.Windows.Forms.Label lblCobroDesc;
        private System.Windows.Forms.TextBox txtSearchQuery;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlMultaDetails;
        private System.Windows.Forms.Label lblDetailsTitle;
        private System.Windows.Forms.Label lblDetConductor;
        private System.Windows.Forms.Label lblDetCedula;
        private System.Windows.Forms.Label lblDetInfraccion;
        private System.Windows.Forms.Label lblDetPlaca;
        private System.Windows.Forms.Label lblDetFecha;
        private System.Windows.Forms.Label lblBreakdownTitle;
        private System.Windows.Forms.Label lblBreakdownBase;
        private System.Windows.Forms.Label lblBreakdownMora;
        private System.Windows.Forms.Label lblBreakdownCanodromo;
        private System.Windows.Forms.Label lblBreakdownTotal;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label lblMontoRecibido;
        private System.Windows.Forms.TextBox txtMontoRecibido;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Label lblCambioValor;
        private System.Windows.Forms.Button btnProcesarPago;
        
        // Panel 2.1: Recibo (Sub-panel within Cobro)
        private System.Windows.Forms.Panel pnlRecibo;
        private System.Windows.Forms.Label lblReciboHeader;
        private System.Windows.Forms.TextBox txtReciboDetalle;
        private System.Windows.Forms.Button btnPrintRecibo;
        private System.Windows.Forms.Button btnNuevaBusqueda;

        // Panel 3: Movimientos
        private System.Windows.Forms.Panel pnlMovimientos;
        private System.Windows.Forms.Label lblMovHeader;
        private System.Windows.Forms.Label lblMovType;
        private System.Windows.Forms.ComboBox cmbMovType;
        private System.Windows.Forms.Label lblMovMonto;
        private System.Windows.Forms.TextBox txtMovMonto;
        private System.Windows.Forms.Label lblMovDesc;
        private System.Windows.Forms.TextBox txtMovDesc;
        private System.Windows.Forms.Button btnRegistrarMov;
        private System.Windows.Forms.Label lblMovHistorialTitle;
        private System.Windows.Forms.ListBox lstMovimientos;

        // Panel 4: Cierre
        private System.Windows.Forms.Panel pnlCierre;
        private System.Windows.Forms.Label lblCierreHeader;
        private System.Windows.Forms.Label lblCierreDesc;
        private System.Windows.Forms.Label lblCierreApertura;
        private System.Windows.Forms.Label lblCierreAperturaValor;
        private System.Windows.Forms.Label lblCierreCobros;
        private System.Windows.Forms.Label lblCierreCobrosValor;
        private System.Windows.Forms.Label lblCierreEntradas;
        private System.Windows.Forms.Label lblCierreEntradasValor;
        private System.Windows.Forms.Label lblCierreSalidas;
        private System.Windows.Forms.Label lblCierreSalidasValor;
        private System.Windows.Forms.Label lblCierreTotalEsperado;
        private System.Windows.Forms.Label lblCierreTotalEsperadoValor;
        private System.Windows.Forms.Label lblCierreConteoFisico;
        private System.Windows.Forms.TextBox txtCierreConteoFisico;
        private System.Windows.Forms.Label lblCierreDiferencia;
        private System.Windows.Forms.Label lblCierreDiferenciaValor;
        private System.Windows.Forms.Button btnCerrarCaja;
=======
=======
>>>>>>> Stashed changes
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlAccent;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvActas;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.GroupBox gbCobro;
        private System.Windows.Forms.Label lblSelectedActa;
        private System.Windows.Forms.Label lblSelectedConductor;
        private System.Windows.Forms.Label lblSelectedMonto;
        private System.Windows.Forms.Label lblDescPago;
        private System.Windows.Forms.TextBox txtDescPago;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblCajero;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.lblSidebarSubtitle = new System.Windows.Forms.Label();
            this.btnNavApertura = new System.Windows.Forms.Button();
            this.btnNavCobro = new System.Windows.Forms.Button();
            this.btnNavMovimientos = new System.Windows.Forms.Button();
            this.btnNavCierre = new System.Windows.Forms.Button();
            this.lblNavCajeroStatus = new System.Windows.Forms.Label();
            this.btnNavVolver = new System.Windows.Forms.Button();
            this.pnlSidebarAccent = new System.Windows.Forms.Panel();
            this.pnlContentContainer = new System.Windows.Forms.Panel();
            
            // Panel Apertura
            this.pnlApertura = new System.Windows.Forms.Panel();
            this.lblAperturaHeader = new System.Windows.Forms.Label();
            this.lblAperturaDesc = new System.Windows.Forms.Label();
            this.lblMontoInicial = new System.Windows.Forms.Label();
            this.txtMontoInicial = new System.Windows.Forms.TextBox();
            this.btnAbrirCaja = new System.Windows.Forms.Button();
            this.lblAperturaStatus = new System.Windows.Forms.Label();
            
            // Panel Cobro
            this.pnlCobro = new System.Windows.Forms.Panel();
            this.lblCobroHeader = new System.Windows.Forms.Label();
            this.lblCobroDesc = new System.Windows.Forms.Label();
            this.txtSearchQuery = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.pnlMultaDetails = new System.Windows.Forms.Panel();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.lblDetConductor = new System.Windows.Forms.Label();
            this.lblDetCedula = new System.Windows.Forms.Label();
            this.lblDetInfraccion = new System.Windows.Forms.Label();
            this.lblDetPlaca = new System.Windows.Forms.Label();
            this.lblDetFecha = new System.Windows.Forms.Label();
            this.lblBreakdownTitle = new System.Windows.Forms.Label();
            this.lblBreakdownBase = new System.Windows.Forms.Label();
            this.lblBreakdownMora = new System.Windows.Forms.Label();
            this.lblBreakdownCanodromo = new System.Windows.Forms.Label();
            this.lblBreakdownTotal = new System.Windows.Forms.Label();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMontoRecibido = new System.Windows.Forms.Label();
            this.txtMontoRecibido = new System.Windows.Forms.TextBox();
            this.lblCambio = new System.Windows.Forms.Label();
            this.lblCambioValor = new System.Windows.Forms.Label();
            this.btnProcesarPago = new System.Windows.Forms.Button();
            
            // Sub-Panel Recibo
            this.pnlRecibo = new System.Windows.Forms.Panel();
            this.lblReciboHeader = new System.Windows.Forms.Label();
            this.txtReciboDetalle = new System.Windows.Forms.TextBox();
            this.btnPrintRecibo = new System.Windows.Forms.Button();
            this.btnNuevaBusqueda = new System.Windows.Forms.Button();
            
            // Panel Movimientos
            this.pnlMovimientos = new System.Windows.Forms.Panel();
            this.lblMovHeader = new System.Windows.Forms.Label();
            this.lblMovType = new System.Windows.Forms.Label();
            this.cmbMovType = new System.Windows.Forms.ComboBox();
            this.lblMovMonto = new System.Windows.Forms.Label();
            this.txtMovMonto = new System.Windows.Forms.TextBox();
            this.lblMovDesc = new System.Windows.Forms.Label();
            this.txtMovDesc = new System.Windows.Forms.TextBox();
            this.btnRegistrarMov = new System.Windows.Forms.Button();
            this.lblMovHistorialTitle = new System.Windows.Forms.Label();
            this.lstMovimientos = new System.Windows.Forms.ListBox();
            
            // Panel Cierre
            this.pnlCierre = new System.Windows.Forms.Panel();
            this.lblCierreHeader = new System.Windows.Forms.Label();
            this.lblCierreDesc = new System.Windows.Forms.Label();
            this.lblCierreApertura = new System.Windows.Forms.Label();
            this.lblCierreAperturaValor = new System.Windows.Forms.Label();
            this.lblCierreCobros = new System.Windows.Forms.Label();
            this.lblCierreCobrosValor = new System.Windows.Forms.Label();
            this.lblCierreEntradas = new System.Windows.Forms.Label();
            this.lblCierreEntradasValor = new System.Windows.Forms.Label();
            this.lblCierreSalidas = new System.Windows.Forms.Label();
            this.lblCierreSalidasValor = new System.Windows.Forms.Label();
            this.lblCierreTotalEsperado = new System.Windows.Forms.Label();
            this.lblCierreTotalEsperadoValor = new System.Windows.Forms.Label();
            this.lblCierreConteoFisico = new System.Windows.Forms.Label();
            this.txtCierreConteoFisico = new System.Windows.Forms.TextBox();
            this.lblCierreDiferencia = new System.Windows.Forms.Label();
            this.lblCierreDiferenciaValor = new System.Windows.Forms.Label();
            this.btnCerrarCaja = new System.Windows.Forms.Button();

            this.pnlSidebar.SuspendLayout();
            this.pnlContentContainer.SuspendLayout();
            this.pnlApertura.SuspendLayout();
            this.pnlCobro.SuspendLayout();
            this.pnlMultaDetails.SuspendLayout();
            this.pnlRecibo.SuspendLayout();
            this.pnlMovimientos.SuspendLayout();
            this.pnlCierre.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.pnlSidebar.Controls.Add(this.lblSidebarTitle);
            this.pnlSidebar.Controls.Add(this.lblSidebarSubtitle);
            this.pnlSidebar.Controls.Add(this.btnNavApertura);
            this.pnlSidebar.Controls.Add(this.btnNavCobro);
            this.pnlSidebar.Controls.Add(this.btnNavMovimientos);
            this.pnlSidebar.Controls.Add(this.btnNavCierre);
            this.pnlSidebar.Controls.Add(this.lblNavCajeroStatus);
            this.pnlSidebar.Controls.Add(this.btnNavVolver);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 600);
            this.pnlSidebar.TabIndex = 0;
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.AutoSize = true;
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.White;
            this.lblSidebarTitle.Location = new System.Drawing.Point(15, 20);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(126, 30);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "DIGESETT";
            // 
            // lblSidebarSubtitle
            // 
            this.lblSidebarSubtitle.AutoSize = true;
            this.lblSidebarSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSidebarSubtitle.ForeColor = System.Drawing.Color.FromArgb(134, 239, 172);
            this.lblSidebarSubtitle.Location = new System.Drawing.Point(16, 50);
            this.lblSidebarSubtitle.Name = "lblSidebarSubtitle";
            this.lblSidebarSubtitle.Size = new System.Drawing.Size(122, 17);
            this.lblSidebarSubtitle.TabIndex = 1;
            this.lblSidebarSubtitle.Text = "Módulo de Caja";
            // 
            // btnNavApertura
            // 
            this.btnNavApertura.BackColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.btnNavApertura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavApertura.FlatAppearance.BorderSize = 0;
            this.btnNavApertura.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnNavApertura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnNavApertura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavApertura.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavApertura.ForeColor = System.Drawing.Color.White;
            this.btnNavApertura.Location = new System.Drawing.Point(0, 100);
            this.btnNavApertura.Name = "btnNavApertura";
            this.btnNavApertura.Size = new System.Drawing.Size(200, 45);
            this.btnNavApertura.TabIndex = 2;
            this.btnNavApertura.Text = "🔑 Apertura de Caja";
            this.btnNavApertura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavApertura.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavApertura.UseVisualStyleBackColor = false;
            this.btnNavApertura.Click += new System.EventHandler(this.btnNavApertura_Click);
            // 
            // btnNavCobro
            // 
            this.btnNavCobro.BackColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.btnNavCobro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavCobro.FlatAppearance.BorderSize = 0;
            this.btnNavCobro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnNavCobro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnNavCobro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCobro.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavCobro.ForeColor = System.Drawing.Color.White;
            this.btnNavCobro.Location = new System.Drawing.Point(0, 150);
            this.btnNavCobro.Name = "btnNavCobro";
            this.btnNavCobro.Size = new System.Drawing.Size(200, 45);
            this.btnNavCobro.TabIndex = 3;
            this.btnNavCobro.Text = "🏧 Cobrar Multa";
            this.btnNavCobro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCobro.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavCobro.UseVisualStyleBackColor = false;
            this.btnNavCobro.Click += new System.EventHandler(this.btnNavCobro_Click);
            // 
            // btnNavMovimientos
            // 
            this.btnNavMovimientos.BackColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.btnNavMovimientos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavMovimientos.FlatAppearance.BorderSize = 0;
            this.btnNavMovimientos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnNavMovimientos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnNavMovimientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavMovimientos.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavMovimientos.ForeColor = System.Drawing.Color.White;
            this.btnNavMovimientos.Location = new System.Drawing.Point(0, 200);
            this.btnNavMovimientos.Name = "btnNavMovimientos";
            this.btnNavMovimientos.Size = new System.Drawing.Size(200, 45);
            this.btnNavMovimientos.TabIndex = 4;
            this.btnNavMovimientos.Text = "💸 Entradas / Salidas";
            this.btnNavMovimientos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavMovimientos.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavMovimientos.UseVisualStyleBackColor = false;
            this.btnNavMovimientos.Click += new System.EventHandler(this.btnNavMovimientos_Click);
            // 
            // btnNavCierre
            // 
            this.btnNavCierre.BackColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.btnNavCierre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavCierre.FlatAppearance.BorderSize = 0;
            this.btnNavCierre.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnNavCierre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnNavCierre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCierre.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavCierre.ForeColor = System.Drawing.Color.White;
            this.btnNavCierre.Location = new System.Drawing.Point(0, 250);
            this.btnNavCierre.Name = "btnNavCierre";
            this.btnNavCierre.Size = new System.Drawing.Size(200, 45);
            this.btnNavCierre.TabIndex = 5;
            this.btnNavCierre.Text = "🔒 Cierre de Caja";
            this.btnNavCierre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCierre.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnNavCierre.UseVisualStyleBackColor = false;
            this.btnNavCierre.Click += new System.EventHandler(this.btnNavCierre_Click);
            // 
            // lblNavCajeroStatus
            // 
            this.lblNavCajeroStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavCajeroStatus.ForeColor = System.Drawing.Color.FromArgb(187, 247, 208);
            this.lblNavCajeroStatus.Location = new System.Drawing.Point(10, 480);
            this.lblNavCajeroStatus.Name = "lblNavCajeroStatus";
            this.lblNavCajeroStatus.Size = new System.Drawing.Size(180, 45);
            this.lblNavCajeroStatus.TabIndex = 6;
            this.lblNavCajeroStatus.Text = "Cajero:\r\ncajero1@digesett.gov.do";
            // 
            // btnNavVolver
            // 
            this.btnNavVolver.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnNavVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavVolver.FlatAppearance.BorderSize = 0;
            this.btnNavVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavVolver.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavVolver.ForeColor = System.Drawing.Color.White;
            this.btnNavVolver.Location = new System.Drawing.Point(10, 540);
            this.btnNavVolver.Name = "btnNavVolver";
            this.btnNavVolver.Size = new System.Drawing.Size(180, 35);
            this.btnNavVolver.TabIndex = 7;
            this.btnNavVolver.Text = "🚪 Volver al Menú";
            this.btnNavVolver.UseVisualStyleBackColor = false;
            this.btnNavVolver.Click += new System.EventHandler(this.btnNavVolver_Click);
            // 
            // pnlSidebarAccent
            // 
            this.pnlSidebarAccent.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            this.pnlSidebarAccent.Location = new System.Drawing.Point(196, 100);
            this.pnlSidebarAccent.Name = "pnlSidebarAccent";
            this.pnlSidebarAccent.Size = new System.Drawing.Size(4, 45);
            this.pnlSidebarAccent.TabIndex = 8;
            // 
            // pnlContentContainer
            // 
            this.pnlContentContainer.Controls.Add(this.pnlApertura);
            this.pnlContentContainer.Controls.Add(this.pnlCobro);
            this.pnlContentContainer.Controls.Add(this.pnlMovimientos);
            this.pnlContentContainer.Controls.Add(this.pnlCierre);
            this.pnlContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentContainer.Location = new System.Drawing.Point(200, 0);
            this.pnlContentContainer.Name = "pnlContentContainer";
            this.pnlContentContainer.Size = new System.Drawing.Size(600, 600);
            this.pnlContentContainer.TabIndex = 1;
            // 
            // pnlApertura
            // 
            this.pnlApertura.BackColor = System.Drawing.Color.FromArgb(13, 31, 15);
            this.pnlApertura.Controls.Add(this.lblAperturaHeader);
            this.pnlApertura.Controls.Add(this.lblAperturaDesc);
            this.pnlApertura.Controls.Add(this.lblMontoInicial);
            this.pnlApertura.Controls.Add(this.txtMontoInicial);
            this.pnlApertura.Controls.Add(this.btnAbrirCaja);
            this.pnlApertura.Controls.Add(this.lblAperturaStatus);
            this.pnlApertura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlApertura.Location = new System.Drawing.Point(0, 0);
            this.pnlApertura.Name = "pnlApertura";
            this.pnlApertura.Size = new System.Drawing.Size(600, 600);
            this.pnlApertura.TabIndex = 0;
            // 
            // lblAperturaHeader
            // 
            this.lblAperturaHeader.AutoSize = true;
            this.lblAperturaHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAperturaHeader.ForeColor = System.Drawing.Color.FromArgb(134, 239, 172);
            this.lblAperturaHeader.Location = new System.Drawing.Point(25, 30);
            this.lblAperturaHeader.Name = "lblAperturaHeader";
            this.lblAperturaHeader.Size = new System.Drawing.Size(232, 30);
            this.lblAperturaHeader.TabIndex = 0;
            this.lblAperturaHeader.Text = "APERTURA DE TURNO";
            // 
            // lblAperturaDesc
            // 
            this.lblAperturaDesc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAperturaDesc.ForeColor = System.Drawing.Color.FromArgb(200, 220, 200);
            this.lblAperturaDesc.Location = new System.Drawing.Point(27, 75);
            this.lblAperturaDesc.Name = "lblAperturaDesc";
            this.lblAperturaDesc.Size = new System.Drawing.Size(540, 50);
            this.lblAperturaDesc.TabIndex = 1;
            this.lblAperturaDesc.Text = "Registre el balance inicial en efectivo con el que se inicia la caja física para este turno de cobros. Una vez abierta, se habilitarán las opciones de cobro.";
            // 
            // lblMontoInicial
            // 
            this.lblMontoInicial.AutoSize = true;
            this.lblMontoInicial.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoInicial.ForeColor = System.Drawing.Color.White;
            this.lblMontoInicial.Location = new System.Drawing.Point(26, 150);
            this.lblMontoInicial.Name = "lblMontoInicial";
            this.lblMontoInicial.Location = new System.Drawing.Point(26, 150);
            this.lblMontoInicial.Size = new System.Drawing.Size(227, 20);
            this.lblMontoInicial.TabIndex = 2;
            this.lblMontoInicial.Text = "Monto Inicial de Efectivo (RD$):";
            // 
            // txtMontoInicial
            // 
            this.txtMontoInicial.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.txtMontoInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoInicial.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoInicial.ForeColor = System.Drawing.Color.White;
            this.txtMontoInicial.Location = new System.Drawing.Point(30, 180);
            this.txtMontoInicial.Name = "txtMontoInicial";
            this.txtMontoInicial.Size = new System.Drawing.Size(250, 32);
            this.txtMontoInicial.TabIndex = 3;
            this.txtMontoInicial.Text = "5000.00";
            // 
            // btnAbrirCaja
            // 
            this.btnAbrirCaja.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnAbrirCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirCaja.FlatAppearance.BorderSize = 0;
            this.btnAbrirCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirCaja.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirCaja.ForeColor = System.Drawing.Color.White;
            this.btnAbrirCaja.Location = new System.Drawing.Point(30, 240);
            this.btnAbrirCaja.Name = "btnAbrirCaja";
            this.btnAbrirCaja.Size = new System.Drawing.Size(250, 45);
            this.btnAbrirCaja.TabIndex = 4;
            this.btnAbrirCaja.Text = "🟢 Abrir Caja e Iniciar Turno";
            this.btnAbrirCaja.UseVisualStyleBackColor = false;
            this.btnAbrirCaja.Click += new System.EventHandler(this.btnAbrirCaja_Click);
            // 
            // lblAperturaStatus
            // 
            this.lblAperturaStatus.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAperturaStatus.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.lblAperturaStatus.Location = new System.Drawing.Point(30, 310);
            this.lblAperturaStatus.Name = "lblAperturaStatus";
            this.lblAperturaStatus.Size = new System.Drawing.Size(537, 80);
            this.lblAperturaStatus.TabIndex = 5;
            this.lblAperturaStatus.Text = "Estado: Caja Cerrada.\r\nDebe ingresar un saldo inicial para abrir operaciones.";
            // 
            // pnlCobro
            // 
            this.pnlCobro.BackColor = System.Drawing.Color.FromArgb(13, 31, 15);
            this.pnlCobro.Controls.Add(this.lblCobroHeader);
            this.pnlCobro.Controls.Add(this.lblCobroDesc);
            this.pnlCobro.Controls.Add(this.txtSearchQuery);
            this.pnlCobro.Controls.Add(this.btnSearch);
            this.pnlCobro.Controls.Add(this.pnlMultaDetails);
            this.pnlCobro.Controls.Add(this.pnlRecibo);
            this.pnlCobro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCobro.Location = new System.Drawing.Point(0, 0);
            this.pnlCobro.Name = "pnlCobro";
            this.pnlCobro.Size = new System.Drawing.Size(600, 600);
            this.pnlCobro.TabIndex = 1;
            this.pnlCobro.Visible = false;
            // 
            // lblCobroHeader
            // 
            this.lblCobroHeader.AutoSize = true;
            this.lblCobroHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCobroHeader.ForeColor = System.Drawing.Color.FromArgb(134, 239, 172);
            this.lblCobroHeader.Location = new System.Drawing.Point(25, 30);
            this.lblCobroHeader.Name = "lblCobroHeader";
            this.lblCobroHeader.Size = new System.Drawing.Size(227, 30);
            this.lblCobroHeader.TabIndex = 0;
            this.lblCobroHeader.Text = "COBRO DE MULTAS";
            // 
            // lblCobroDesc
            // 
            this.lblCobroDesc.AutoSize = true;
            this.lblCobroDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCobroDesc.ForeColor = System.Drawing.Color.FromArgb(200, 220, 200);
            this.lblCobroDesc.Location = new System.Drawing.Point(27, 75);
            this.lblCobroDesc.Name = "lblCobroDesc";
            this.lblCobroDesc.Size = new System.Drawing.Size(394, 17);
            this.lblCobroDesc.TabIndex = 1;
            this.lblCobroDesc.Text = "Busque la multa por Cédula del conductor o por ID Único del Acta:";
            // 
            // txtSearchQuery
            // 
            this.txtSearchQuery.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.txtSearchQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchQuery.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchQuery.ForeColor = System.Drawing.Color.White;
            this.txtSearchQuery.Location = new System.Drawing.Point(30, 100);
            this.txtSearchQuery.Name = "txtSearchQuery";
            this.txtSearchQuery.Size = new System.Drawing.Size(380, 27);
            this.txtSearchQuery.TabIndex = 2;
            this.txtSearchQuery.Text = "223-0123456-7";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(420, 100);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 27);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "🔍 Buscar Multa";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // pnlMultaDetails
            // 
            this.pnlMultaDetails.BackColor = System.Drawing.Color.FromArgb(22, 40, 25);
            this.pnlMultaDetails.Controls.Add(this.lblDetailsTitle);
            this.pnlMultaDetails.Controls.Add(this.lblDetConductor);
            this.pnlMultaDetails.Controls.Add(this.lblDetCedula);
            this.pnlMultaDetails.Controls.Add(this.lblDetInfraccion);
            this.pnlMultaDetails.Controls.Add(this.lblDetPlaca);
            this.pnlMultaDetails.Controls.Add(this.lblDetFecha);
            this.pnlMultaDetails.Controls.Add(this.lblBreakdownTitle);
            this.pnlMultaDetails.Controls.Add(this.lblBreakdownBase);
            this.pnlMultaDetails.Controls.Add(this.lblBreakdownMora);
            this.pnlMultaDetails.Controls.Add(this.lblBreakdownCanodromo);
            this.pnlMultaDetails.Controls.Add(this.lblBreakdownTotal);
            this.pnlMultaDetails.Controls.Add(this.lblMetodoPago);
            this.pnlMultaDetails.Controls.Add(this.cmbMetodoPago);
            this.pnlMultaDetails.Controls.Add(this.lblMontoRecibido);
            this.pnlMultaDetails.Controls.Add(this.txtMontoRecibido);
            this.pnlMultaDetails.Controls.Add(this.lblCambio);
            this.pnlMultaDetails.Controls.Add(this.lblCambioValor);
            this.pnlMultaDetails.Controls.Add(this.btnProcesarPago);
            this.pnlMultaDetails.Location = new System.Drawing.Point(30, 145);
            this.pnlMultaDetails.Name = "pnlMultaDetails";
            this.pnlMultaDetails.Size = new System.Drawing.Size(540, 430);
            this.pnlMultaDetails.TabIndex = 4;
            this.pnlMultaDetails.Visible = false;
            // 
            // lblDetailsTitle
            // 
            this.lblDetailsTitle.AutoSize = true;
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(134, 239, 172);
            this.lblDetailsTitle.Location = new System.Drawing.Point(15, 10);
            this.lblDetailsTitle.Name = "lblDetailsTitle";
            this.lblDetailsTitle.Size = new System.Drawing.Size(147, 19);
            this.lblDetailsTitle.TabIndex = 0;
            this.lblDetailsTitle.Text = "Datos de la Infracción";
            // 
            // lblDetConductor
            // 
            this.lblDetConductor.AutoSize = true;
            this.lblDetConductor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetConductor.ForeColor = System.Drawing.Color.White;
            this.lblDetConductor.Location = new System.Drawing.Point(15, 35);
            this.lblDetConductor.Name = "lblDetConductor";
            this.lblDetConductor.Size = new System.Drawing.Size(161, 17);
            this.lblDetConductor.TabIndex = 1;
            this.lblDetConductor.Text = "Conductor: Juan Pérez";
            // 
            // lblDetCedula
            // 
            this.lblDetCedula.AutoSize = true;
            this.lblDetCedula.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetCedula.ForeColor = System.Drawing.Color.White;
            this.lblDetCedula.Location = new System.Drawing.Point(15, 55);
            this.lblDetCedula.Name = "lblDetCedula";
            this.lblDetCedula.Size = new System.Drawing.Size(143, 17);
            this.lblDetCedula.TabIndex = 2;
            this.lblDetCedula.Text = "Cédula: 223-0123456-7";
            // 
            // lblDetInfraccion
            // 
            this.lblDetInfraccion.AutoSize = true;
            this.lblDetInfraccion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetInfraccion.ForeColor = System.Drawing.Color.White;
            this.lblDetInfraccion.Location = new System.Drawing.Point(15, 75);
            this.lblDetInfraccion.Name = "lblDetInfraccion";
            this.lblDetInfraccion.Size = new System.Drawing.Size(262, 17);
            this.lblDetInfraccion.TabIndex = 3;
            this.lblDetInfraccion.Text = "Infracción: Cruzar Luz Roja (INF-02)";
            // 
            // lblDetPlaca
            // 
            this.lblDetPlaca.AutoSize = true;
            this.lblDetPlaca.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetPlaca.ForeColor = System.Drawing.Color.White;
            this.lblDetPlaca.Location = new System.Drawing.Point(290, 35);
            this.lblDetPlaca.Name = "lblDetPlaca";
            this.lblDetPlaca.Size = new System.Drawing.Size(107, 17);
            this.lblDetPlaca.TabIndex = 4;
            this.lblDetPlaca.Text = "Placa: A123456";
            // 
            // lblDetFecha
            // 
            this.lblDetFecha.AutoSize = true;
            this.lblDetFecha.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetFecha.ForeColor = System.Drawing.Color.White;
            this.lblDetFecha.Location = new System.Drawing.Point(290, 55);
            this.lblDetFecha.Name = "lblDetFecha";
            this.lblDetFecha.Size = new System.Drawing.Size(155, 17);
            this.lblDetFecha.TabIndex = 5;
            this.lblDetFecha.Text = "Fecha Hecho: 2026-06-18";
            // 
            // lblBreakdownTitle
            // 
            this.lblBreakdownTitle.AutoSize = true;
            this.lblBreakdownTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreakdownTitle.ForeColor = System.Drawing.Color.FromArgb(134, 239, 172);
            this.lblBreakdownTitle.Location = new System.Drawing.Point(15, 110);
            this.lblBreakdownTitle.Name = "lblBreakdownTitle";
            this.lblBreakdownTitle.Size = new System.Drawing.Size(148, 19);
            this.lblBreakdownTitle.TabIndex = 6;
            this.lblBreakdownTitle.Text = "Desglose de Conceptos";
            // 
            // lblBreakdownBase
            // 
            this.lblBreakdownBase.AutoSize = true;
            this.lblBreakdownBase.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreakdownBase.ForeColor = System.Drawing.Color.FromArgb(200, 220, 200);
            this.lblBreakdownBase.Location = new System.Drawing.Point(15, 135);
            this.lblBreakdownBase.Name = "lblBreakdownBase";
            this.lblBreakdownBase.Size = new System.Drawing.Size(175, 17);
            this.lblBreakdownBase.TabIndex = 7;
            this.lblBreakdownBase.Text = "Multa Base: ........ RD$ 3,500.00";
            // 
            // lblBreakdownMora
            // 
            this.lblBreakdownMora.AutoSize = true;
            this.lblBreakdownMora.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreakdownMora.ForeColor = System.Drawing.Color.FromArgb(200, 220, 200);
            this.lblBreakdownMora.Location = new System.Drawing.Point(15, 155);
            this.lblBreakdownMora.Name = "lblBreakdownMora";
            this.lblBreakdownMora.Size = new System.Drawing.Size(176, 17);
            this.lblBreakdownMora.TabIndex = 8;
            this.lblBreakdownMora.Text = "Recargo por Mora: .. RD$ 350.00";
            // 
            // lblBreakdownCanodromo
            // 
            this.lblBreakdownCanodromo.AutoSize = true;
            this.lblBreakdownCanodromo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreakdownCanodromo.ForeColor = System.Drawing.Color.FromArgb(200, 220, 200);
            this.lblBreakdownCanodromo.Location = new System.Drawing.Point(15, 175);
            this.lblBreakdownCanodromo.Name = "lblBreakdownCanodromo";
            this.lblBreakdownCanodromo.Size = new System.Drawing.Size(176, 17);
            this.lblBreakdownCanodromo.TabIndex = 9;
            this.lblBreakdownCanodromo.Text = "Estadía Canódromo: RD$ 1,500.00";
            // 
            // lblBreakdownTotal
            // 
            this.lblBreakdownTotal.AutoSize = true;
            this.lblBreakdownTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreakdownTotal.ForeColor = System.Drawing.Color.White;
            this.lblBreakdownTotal.Location = new System.Drawing.Point(14, 200);
            this.lblBreakdownTotal.Name = "lblBreakdownTotal";
            this.lblBreakdownTotal.Size = new System.Drawing.Size(232, 21);
            this.lblBreakdownTotal.TabIndex = 10;
            this.lblBreakdownTotal.Text = "Total a Pagar: ...... RD$ 5,350.00";
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetodoPago.ForeColor = System.Drawing.Color.White;
            this.lblMetodoPago.Location = new System.Drawing.Point(15, 245);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(113, 17);
            this.lblMetodoPago.TabIndex = 11;
            this.lblMetodoPago.Text = "Método de Pago:";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.cmbMetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetodoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMetodoPago.ForeColor = System.Drawing.Color.White;
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Items.AddRange(new object[] {
            "EFECTIVO",
            "TARJETA DE CRÉDITO/DÉBITO"});
            this.cmbMetodoPago.Location = new System.Drawing.Point(140, 242);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(220, 25);
            this.cmbMetodoPago.TabIndex = 12;
            this.cmbMetodoPago.SelectedIndexChanged += new System.EventHandler(this.cmbMetodoPago_SelectedIndexChanged);
            // 
            // lblMontoRecibido
            // 
            this.lblMontoRecibido.AutoSize = true;
            this.lblMontoRecibido.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoRecibido.ForeColor = System.Drawing.Color.White;
            this.lblMontoRecibido.Location = new System.Drawing.Point(15, 285);
            this.lblMontoRecibido.Name = "lblMontoRecibido";
            this.lblMontoRecibido.Size = new System.Drawing.Size(109, 17);
            this.lblMontoRecibido.TabIndex = 13;
            this.lblMontoRecibido.Text = "Efectivo Recibido:";
            // 
            // txtMontoRecibido
            // 
            this.txtMontoRecibido.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.txtMontoRecibido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontoRecibido.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoRecibido.ForeColor = System.Drawing.Color.White;
            this.txtMontoRecibido.Location = new System.Drawing.Point(140, 282);
            this.txtMontoRecibido.Name = "txtMontoRecibido";
            this.txtMontoRecibido.Size = new System.Drawing.Size(220, 25);
            this.txtMontoRecibido.TabIndex = 14;
            this.txtMontoRecibido.Text = "6000.00";
            this.txtMontoRecibido.TextChanged += new System.EventHandler(this.txtMontoRecibido_TextChanged);
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.ForeColor = System.Drawing.Color.White;
            this.lblCambio.Location = new System.Drawing.Point(15, 325);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(117, 17);
            this.lblCambio.TabIndex = 15;
            this.lblCambio.Text = "Cambio a Devolver:";
            // 
            // lblCambioValor
            // 
            this.lblCambioValor.AutoSize = true;
            this.lblCambioValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambioValor.ForeColor = System.Drawing.Color.FromArgb(74, 222, 128);
            this.lblCambioValor.Location = new System.Drawing.Point(136, 322);
            this.lblCambioValor.Name = "lblCambioValor";
            this.lblCambioValor.Size = new System.Drawing.Size(95, 21);
            this.lblCambioValor.TabIndex = 16;
            this.lblCambioValor.Text = "RD$ 650.00";
            // 
            // btnProcesarPago
            // 
            this.btnProcesarPago.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnProcesarPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcesarPago.FlatAppearance.BorderSize = 0;
            this.btnProcesarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesarPago.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesarPago.ForeColor = System.Drawing.Color.White;
            this.btnProcesarPago.Location = new System.Drawing.Point(18, 365);
            this.btnProcesarPago.Name = "btnProcesarPago";
            this.btnProcesarPago.Size = new System.Drawing.Size(505, 45);
            this.btnProcesarPago.TabIndex = 17;
            this.btnProcesarPago.Text = "🏧 Registrar Pago y Generar Recibo";
            this.btnProcesarPago.UseVisualStyleBackColor = false;
            this.btnProcesarPago.Click += new System.EventHandler(this.btnProcesarPago_Click);
            // 
            // pnlRecibo
            // 
            this.pnlRecibo.BackColor = System.Drawing.Color.FromArgb(13, 31, 15);
            this.pnlRecibo.Controls.Add(this.lblReciboHeader);
            this.pnlRecibo.Controls.Add(this.txtReciboDetalle);
            this.pnlRecibo.Controls.Add(this.btnPrintRecibo);
            this.pnlRecibo.Controls.Add(this.btnNuevaBusqueda);
            this.pnlRecibo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRecibo.Location = new System.Drawing.Point(0, 0);
            this.pnlRecibo.Name = "pnlRecibo";
            this.pnlRecibo.Size = new System.Drawing.Size(600, 600);
            this.pnlRecibo.TabIndex = 5;
            this.pnlRecibo.Visible = false;
            // 
            // lblReciboHeader
            // 
            this.lblReciboHeader.AutoSize = true;
            this.lblReciboHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReciboHeader.ForeColor = System.Drawing.Color.FromArgb(134, 239, 172);
            this.lblReciboHeader.Location = new System.Drawing.Point(25, 30);
            this.lblReciboHeader.Name = "lblReciboHeader";
            this.lblReciboHeader.Size = new System.Drawing.Size(251, 30);
            this.lblReciboHeader.TabIndex = 0;
            this.lblReciboHeader.Text = "RECIBO OFICIAL DE PAGO";
            // 
            // txtReciboDetalle
            // 
            this.txtReciboDetalle.BackColor = System.Drawing.Color.Black;
            this.txtReciboDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReciboDetalle.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReciboDetalle.ForeColor = System.Drawing.Color.FromArgb(74, 222, 128);
            this.txtReciboDetalle.Location = new System.Drawing.Point(30, 80);
            this.txtReciboDetalle.Multiline = true;
            this.txtReciboDetalle.Name = "txtReciboDetalle";
            this.txtReciboDetalle.ReadOnly = true;
            this.txtReciboDetalle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReciboDetalle.Size = new System.Drawing.Size(540, 390);
            this.txtReciboDetalle.TabIndex = 1;
            this.txtReciboDetalle.Text = "Cargando ticket de recibo...";
            // 
            // btnPrintRecibo
            // 
            this.btnPrintRecibo.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            this.btnPrintRecibo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintRecibo.FlatAppearance.BorderSize = 0;
            this.btnPrintRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintRecibo.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintRecibo.ForeColor = System.Drawing.Color.White;
            this.btnPrintRecibo.Location = new System.Drawing.Point(30, 490);
            this.btnPrintRecibo.Name = "btnPrintRecibo";
            this.btnPrintRecibo.Size = new System.Drawing.Size(250, 45);
            this.btnPrintRecibo.TabIndex = 2;
            this.btnPrintRecibo.Text = "🖨️ Simular Impresión (Tique)";
            this.btnPrintRecibo.UseVisualStyleBackColor = false;
            this.btnPrintRecibo.Click += new System.EventHandler(this.btnPrintRecibo_Click);
            // 
            // btnNuevaBusqueda
            // 
            this.btnNuevaBusqueda.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnNuevaBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaBusqueda.FlatAppearance.BorderSize = 0;
            this.btnNuevaBusqueda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaBusqueda.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaBusqueda.ForeColor = System.Drawing.Color.White;
            this.btnNuevaBusqueda.Location = new System.Drawing.Point(320, 490);
            this.btnNuevaBusqueda.Name = "btnNuevaBusqueda";
            this.btnNuevaBusqueda.Size = new System.Drawing.Size(250, 45);
            this.btnNuevaBusqueda.TabIndex = 3;
            this.btnNuevaBusqueda.Text = "🔄 Cobrar Otra Multa";
            this.btnNuevaBusqueda.UseVisualStyleBackColor = false;
            this.btnNuevaBusqueda.Click += new System.EventHandler(this.btnNuevaBusqueda_Click);
            // 
            // pnlMovimientos
            // 
            this.pnlMovimientos.BackColor = System.Drawing.Color.FromArgb(13, 31, 15);
            this.pnlMovimientos.Controls.Add(this.lblMovHeader);
            this.pnlMovimientos.Controls.Add(this.lblMovType);
            this.pnlMovimientos.Controls.Add(this.cmbMovType);
            this.pnlMovimientos.Controls.Add(this.lblMovMonto);
            this.pnlMovimientos.Controls.Add(this.txtMovMonto);
            this.pnlMovimientos.Controls.Add(this.lblMovDesc);
            this.pnlMovimientos.Controls.Add(this.txtMovDesc);
            this.pnlMovimientos.Controls.Add(this.btnRegistrarMov);
            this.pnlMovimientos.Controls.Add(this.lblMovHistorialTitle);
            this.pnlMovimientos.Controls.Add(this.lstMovimientos);
            this.pnlMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMovimientos.Location = new System.Drawing.Point(0, 0);
            this.pnlMovimientos.Name = "pnlMovimientos";
            this.pnlMovimientos.Size = new System.Drawing.Size(600, 600);
            this.pnlMovimientos.TabIndex = 2;
            this.pnlMovimientos.Visible = false;
            // 
            // lblMovHeader
            // 
            this.lblMovHeader.AutoSize = true;
            this.lblMovHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovHeader.ForeColor = System.Drawing.Color.FromArgb(134, 239, 172);
            this.lblMovHeader.Location = new System.Drawing.Point(25, 30);
            this.lblMovHeader.Name = "lblMovHeader";
            this.lblMovHeader.Size = new System.Drawing.Size(349, 30);
            this.lblMovHeader.TabIndex = 0;
            this.lblMovHeader.Text = "ENTRADAS / SALIDAS DE EFECTIVO";
            // 
            // lblMovType
            // 
            this.lblMovType.AutoSize = true;
            this.lblMovType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovType.ForeColor = System.Drawing.Color.White;
            this.lblMovType.Location = new System.Drawing.Point(27, 85);
            this.lblMovType.Name = "lblMovType";
            this.lblMovType.Size = new System.Drawing.Size(133, 17);
            this.lblMovType.TabIndex = 1;
            this.lblMovType.Text = "Tipo de Movimiento:";
            // 
            // cmbMovType
            // 
            this.cmbMovType.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.cmbMovType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMovType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMovType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMovType.ForeColor = System.Drawing.Color.White;
            this.cmbMovType.FormattingEnabled = true;
            this.cmbMovType.Items.AddRange(new object[] {
            "ENTRADA (Ingreso de efectivo adicional)",
            "SALIDA (Retiro de efectivo / Arqueo / Envío a Bóveda)"});
            this.cmbMovType.Location = new System.Drawing.Point(30, 110);
            this.cmbMovType.Name = "cmbMovType";
            this.cmbMovType.Size = new System.Drawing.Size(350, 25);
            this.cmbMovType.TabIndex = 2;
            // 
            // lblMovMonto
            // 
            this.lblMovMonto.AutoSize = true;
            this.lblMovMonto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovMonto.ForeColor = System.Drawing.Color.White;
            this.lblMovMonto.Location = new System.Drawing.Point(400, 85);
            this.lblMovMonto.Name = "lblMovMonto";
            this.lblMovMonto.Size = new System.Drawing.Size(89, 17);
            this.lblMovMonto.TabIndex = 3;
            this.lblMovMonto.Text = "Monto (RD$):";
            // 
            // txtMovMonto
            // 
            this.txtMovMonto.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.txtMovMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMovMonto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMovMonto.ForeColor = System.Drawing.Color.White;
            this.txtMovMonto.Location = new System.Drawing.Point(403, 110);
            this.txtMovMonto.Name = "txtMovMonto";
            this.txtMovMonto.Size = new System.Drawing.Size(167, 24);
            this.txtMovMonto.TabIndex = 4;
            // 
            // lblMovDesc
            // 
            this.lblMovDesc.AutoSize = true;
            this.lblMovDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovDesc.ForeColor = System.Drawing.Color.White;
            this.lblMovDesc.Location = new System.Drawing.Point(27, 150);
            this.lblMovDesc.Name = "lblMovDesc";
            this.lblMovDesc.Size = new System.Drawing.Size(147, 17);
            this.lblMovDesc.TabIndex = 5;
            this.lblMovDesc.Text = "Concepto / Descripción:";
            // 
            // txtMovDesc
            // 
            this.txtMovDesc.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.txtMovDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMovDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMovDesc.ForeColor = System.Drawing.Color.White;
            this.txtMovDesc.Location = new System.Drawing.Point(30, 175);
            this.txtMovDesc.Name = "txtMovDesc";
            this.txtMovDesc.Size = new System.Drawing.Size(350, 24);
            this.txtMovDesc.TabIndex = 6;
            // 
            // btnRegistrarMov
            // 
            this.btnRegistrarMov.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            this.btnRegistrarMov.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrarMov.FlatAppearance.BorderSize = 0;
            this.btnRegistrarMov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarMov.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarMov.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarMov.Location = new System.Drawing.Point(403, 173);
            this.btnRegistrarMov.Name = "btnRegistrarMov";
            this.btnRegistrarMov.Size = new System.Drawing.Size(167, 26);
            this.btnRegistrarMov.TabIndex = 7;
            this.btnRegistrarMov.Text = "📥 Registrar Movimiento";
            this.btnRegistrarMov.UseVisualStyleBackColor = false;
            this.btnRegistrarMov.Click += new System.EventHandler(this.btnRegistrarMov_Click);
            // 
            // lblMovHistorialTitle
            // 
            this.lblMovHistorialTitle.AutoSize = true;
            this.lblMovHistorialTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovHistorialTitle.ForeColor = System.Drawing.Color.FromArgb(134, 239, 172);
            this.lblMovHistorialTitle.Location = new System.Drawing.Point(27, 225);
            this.lblMovHistorialTitle.Name = "lblMovHistorialTitle";
            this.lblMovHistorialTitle.Size = new System.Drawing.Size(252, 20);
            this.lblMovHistorialTitle.TabIndex = 8;
            this.lblMovHistorialTitle.Text = "Movimientos Registrados en Turno";
            // 
            // lstMovimientos
            // 
            this.lstMovimientos.BackColor = System.Drawing.Color.Black;
            this.lstMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstMovimientos.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMovimientos.ForeColor = System.Drawing.Color.White;
            this.lstMovimientos.FormattingEnabled = true;
            this.lstMovimientos.ItemHeight = 15;
            this.lstMovimientos.Location = new System.Drawing.Point(30, 255);
            this.lstMovimientos.Name = "lstMovimientos";
            this.lstMovimientos.Size = new System.Drawing.Size(540, 317);
            this.lstMovimientos.TabIndex = 9;
            // 
            // pnlCierre
            // 
            this.pnlCierre.BackColor = System.Drawing.Color.FromArgb(13, 31, 15);
            this.pnlCierre.Controls.Add(this.lblCierreHeader);
            this.pnlCierre.Controls.Add(this.lblCierreDesc);
            this.pnlCierre.Controls.Add(this.lblCierreApertura);
            this.pnlCierre.Controls.Add(this.lblCierreAperturaValor);
            this.pnlCierre.Controls.Add(this.lblCierreCobros);
            this.pnlCierre.Controls.Add(this.lblCierreCobrosValor);
            this.pnlCierre.Controls.Add(this.lblCierreEntradas);
            this.pnlCierre.Controls.Add(this.lblCierreEntradasValor);
            this.pnlCierre.Controls.Add(this.lblCierreSalidas);
            this.pnlCierre.Controls.Add(this.lblCierreSalidasValor);
            this.pnlCierre.Controls.Add(this.lblCierreTotalEsperado);
            this.pnlCierre.Controls.Add(this.lblCierreTotalEsperadoValor);
            this.pnlCierre.Controls.Add(this.lblCierreConteoFisico);
            this.pnlCierre.Controls.Add(this.txtCierreConteoFisico);
            this.pnlCierre.Controls.Add(this.lblCierreDiferencia);
            this.pnlCierre.Controls.Add(this.lblCierreDiferenciaValor);
            this.pnlCierre.Controls.Add(this.btnCerrarCaja);
            this.pnlCierre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCierre.Location = new System.Drawing.Point(0, 0);
            this.pnlCierre.Name = "pnlCierre";
            this.pnlCierre.Size = new System.Drawing.Size(600, 600);
            this.pnlCierre.TabIndex = 3;
            this.pnlCierre.Visible = false;
            // 
            // lblCierreHeader
            // 
            this.lblCierreHeader.AutoSize = true;
            this.lblCierreHeader.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreHeader.ForeColor = System.Drawing.Color.FromArgb(134, 239, 172);
            this.lblCierreHeader.Location = new System.Drawing.Point(25, 30);
            this.lblCierreHeader.Name = "lblCierreHeader";
            this.lblCierreHeader.Size = new System.Drawing.Size(325, 30);
            this.lblCierreHeader.TabIndex = 0;
            this.lblCierreHeader.Text = "CIERRE Y CUADRE DEL TURNO";
            // 
            // lblCierreDesc
            // 
            this.lblCierreDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreDesc.ForeColor = System.Drawing.Color.FromArgb(200, 220, 200);
            this.lblCierreDesc.Location = new System.Drawing.Point(27, 75);
            this.lblCierreDesc.Name = "lblCierreDesc";
            this.lblCierreDesc.Size = new System.Drawing.Size(540, 40);
            this.lblCierreDesc.TabIndex = 1;
            this.lblCierreDesc.Text = "Revise el saldo consolidado del turno. Compare con el efectivo físico en caja y presione Confirmar para cerrar la sesión y consolidar movimientos.";
            // 
            // lblCierreApertura
            // 
            this.lblCierreApertura.AutoSize = true;
            this.lblCierreApertura.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreApertura.ForeColor = System.Drawing.Color.White;
            this.lblCierreApertura.Location = new System.Drawing.Point(30, 140);
            this.lblCierreApertura.Name = "lblCierreApertura";
            this.lblCierreApertura.Size = new System.Drawing.Size(102, 19);
            this.lblCierreApertura.TabIndex = 2;
            this.lblCierreApertura.Text = "Saldo Apertura:";
            // 
            // lblCierreAperturaValor
            // 
            this.lblCierreAperturaValor.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreAperturaValor.ForeColor = System.Drawing.Color.White;
            this.lblCierreAperturaValor.Location = new System.Drawing.Point(220, 140);
            this.lblCierreAperturaValor.Name = "lblCierreAperturaValor";
            this.lblCierreAperturaValor.Size = new System.Drawing.Size(150, 19);
            this.lblCierreAperturaValor.TabIndex = 3;
            this.lblCierreAperturaValor.Text = "RD$ 5,000.00";
            this.lblCierreAperturaValor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCierreCobros
            // 
            this.lblCierreCobros.AutoSize = true;
            this.lblCierreCobros.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreCobros.ForeColor = System.Drawing.Color.White;
            this.lblCierreCobros.Location = new System.Drawing.Point(30, 175);
            this.lblCierreCobros.Name = "lblCierreCobros";
            this.lblCierreCobros.Size = new System.Drawing.Size(130, 19);
            this.lblCierreCobros.TabIndex = 4;
            this.lblCierreCobros.Text = "(+) Cobros Realizados:";
            // 
            // lblCierreCobrosValor
            // 
            this.lblCierreCobrosValor.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreCobrosValor.ForeColor = System.Drawing.Color.White;
            this.lblCierreCobrosValor.Location = new System.Drawing.Point(220, 175);
            this.lblCierreCobrosValor.Name = "lblCierreCobrosValor";
            this.lblCierreCobrosValor.Size = new System.Drawing.Size(150, 19);
            this.lblCierreCobrosValor.TabIndex = 5;
            this.lblCierreCobrosValor.Text = "RD$ 5,350.00";
            this.lblCierreCobrosValor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCierreEntradas
            // 
            this.lblCierreEntradas.AutoSize = true;
            this.lblCierreEntradas.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreEntradas.ForeColor = System.Drawing.Color.White;
            this.lblCierreEntradas.Location = new System.Drawing.Point(30, 210);
            this.lblCierreEntradas.Name = "lblCierreEntradas";
            this.lblCierreEntradas.Size = new System.Drawing.Size(149, 19);
            this.lblCierreEntradas.TabIndex = 6;
            this.lblCierreEntradas.Text = "(+) Entradas Adicionales:";
            // 
            // lblCierreEntradasValor
            // 
            this.lblCierreEntradasValor.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreEntradasValor.ForeColor = System.Drawing.Color.White;
            this.lblCierreEntradasValor.Location = new System.Drawing.Point(220, 210);
            this.lblCierreEntradasValor.Name = "lblCierreEntradasValor";
            this.lblCierreEntradasValor.Size = new System.Drawing.Size(150, 19);
            this.lblCierreEntradasValor.TabIndex = 7;
            this.lblCierreEntradasValor.Text = "RD$ 0.00";
            this.lblCierreEntradasValor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCierreSalidas
            // 
            this.lblCierreSalidas.AutoSize = true;
            this.lblCierreSalidas.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreSalidas.ForeColor = System.Drawing.Color.White;
            this.lblCierreSalidas.Location = new System.Drawing.Point(30, 245);
            this.lblCierreSalidas.Name = "lblCierreSalidas";
            this.lblCierreSalidas.Size = new System.Drawing.Size(130, 19);
            this.lblCierreSalidas.TabIndex = 8;
            this.lblCierreSalidas.Text = "(-) Salidas del Turno:";
            // 
            // lblCierreSalidasValor
            // 
            this.lblCierreSalidasValor.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreSalidasValor.ForeColor = System.Drawing.Color.White;
            this.lblCierreSalidasValor.Location = new System.Drawing.Point(220, 245);
            this.lblCierreSalidasValor.Name = "lblCierreSalidasValor";
            this.lblCierreSalidasValor.Size = new System.Drawing.Size(150, 19);
            this.lblCierreSalidasValor.TabIndex = 9;
            this.lblCierreSalidasValor.Text = "RD$ 0.00";
            this.lblCierreSalidasValor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCierreTotalEsperado
            // 
            this.lblCierreTotalEsperado.AutoSize = true;
            this.lblCierreTotalEsperado.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreTotalEsperado.ForeColor = System.Drawing.Color.White;
            this.lblCierreTotalEsperado.Location = new System.Drawing.Point(30, 290);
            this.lblCierreTotalEsperado.Name = "lblCierreTotalEsperado";
            this.lblCierreTotalEsperado.Size = new System.Drawing.Size(161, 20);
            this.lblCierreTotalEsperado.TabIndex = 10;
            this.lblCierreTotalEsperado.Text = "Saldo Final Esperado:";
            // 
            // lblCierreTotalEsperadoValor
            // 
            this.lblCierreTotalEsperadoValor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreTotalEsperadoValor.ForeColor = System.Drawing.Color.FromArgb(134, 239, 172);
            this.lblCierreTotalEsperadoValor.Location = new System.Drawing.Point(220, 290);
            this.lblCierreTotalEsperadoValor.Name = "lblCierreTotalEsperadoValor";
            this.lblCierreTotalEsperadoValor.Size = new System.Drawing.Size(150, 20);
            this.lblCierreTotalEsperadoValor.TabIndex = 11;
            this.lblCierreTotalEsperadoValor.Text = "RD$ 10,350.00";
            this.lblCierreTotalEsperadoValor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblCierreConteoFisico
            // 
            this.lblCierreConteoFisico.AutoSize = true;
            this.lblCierreConteoFisico.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreConteoFisico.ForeColor = System.Drawing.Color.White;
            this.lblCierreConteoFisico.Location = new System.Drawing.Point(30, 350);
            this.lblCierreConteoFisico.Name = "lblCierreConteoFisico";
            this.lblCierreConteoFisico.Size = new System.Drawing.Size(193, 19);
            this.lblCierreConteoFisico.TabIndex = 12;
            this.lblCierreConteoFisico.Text = "Conteo Físico Efectivo Real:";
            // 
            // txtCierreConteoFisico
            // 
            this.txtCierreConteoFisico.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.txtCierreConteoFisico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCierreConteoFisico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCierreConteoFisico.ForeColor = System.Drawing.Color.White;
            this.txtCierreConteoFisico.Location = new System.Drawing.Point(250, 345);
            this.txtCierreConteoFisico.Name = "txtCierreConteoFisico";
            this.txtCierreConteoFisico.Size = new System.Drawing.Size(120, 29);
            this.txtCierreConteoFisico.TabIndex = 13;
            this.txtCierreConteoFisico.Text = "10350.00";
            this.txtCierreConteoFisico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCierreConteoFisico.TextChanged += new System.EventHandler(this.txtCierreConteoFisico_TextChanged);
            // 
            // lblCierreDiferencia
            // 
            this.lblCierreDiferencia.AutoSize = true;
            this.lblCierreDiferencia.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreDiferencia.ForeColor = System.Drawing.Color.White;
            this.lblCierreDiferencia.Location = new System.Drawing.Point(30, 400);
            this.lblCierreDiferencia.Name = "lblCierreDiferencia";
            this.lblCierreDiferencia.Size = new System.Drawing.Size(83, 19);
            this.lblCierreDiferencia.TabIndex = 14;
            this.lblCierreDiferencia.Text = "Diferencia:";
            // 
            // lblCierreDiferenciaValor
            // 
            this.lblCierreDiferenciaValor.AutoSize = true;
            this.lblCierreDiferenciaValor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCierreDiferenciaValor.ForeColor = System.Drawing.Color.FromArgb(74, 222, 128);
            this.lblCierreDiferenciaValor.Location = new System.Drawing.Point(246, 400);
            this.lblCierreDiferenciaValor.Name = "lblCierreDiferenciaValor";
            this.lblCierreDiferenciaValor.Size = new System.Drawing.Size(124, 20);
            this.lblCierreDiferenciaValor.TabIndex = 15;
            this.lblCierreDiferenciaValor.Text = "RD$ 0.00 (Cuadado)";
            this.lblCierreDiferenciaValor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnCerrarCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarCaja.FlatAppearance.BorderSize = 0;
            this.btnCerrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcesarPago.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarCaja.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarCaja.ForeColor = System.Drawing.Color.White;
            this.btnCerrarCaja.Location = new System.Drawing.Point(34, 460);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(336, 45);
            this.btnCerrarCaja.TabIndex = 16;
            this.btnCerrarCaja.Text = "🔒 Confirmar Cuadre y Cerrar Caja";
            this.btnCerrarCaja.UseVisualStyleBackColor = false;
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
            
=======
=======
>>>>>>> Stashed changes
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvActas = new System.Windows.Forms.DataGridView();
            this.lblResultados = new System.Windows.Forms.Label();
            this.gbCobro = new System.Windows.Forms.GroupBox();
            this.lblSelectedActa = new System.Windows.Forms.Label();
            this.lblSelectedConductor = new System.Windows.Forms.Label();
            this.lblSelectedMonto = new System.Windows.Forms.Label();
            this.lblDescPago = new System.Windows.Forms.Label();
            this.txtDescPago = new System.Windows.Forms.TextBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblCajero = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActas)).BeginInit();
            this.gbCobro.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(784, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(271, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ADMINISTRACIÓN - MODO CAJA";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(204, 251, 241);
            this.lblSubtitle.Location = new System.Drawing.Point(18, 40);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(306, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Cobros de Actas de Infracción y Control de Caja en Ventanilla";
            // 
            // pnlAccent
            // 
            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(13, 148, 136);
            this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAccent.Location = new System.Drawing.Point(0, 75);
            this.pnlAccent.Name = "pnlAccent";
            this.pnlAccent.Size = new System.Drawing.Size(784, 4);
            this.pnlAccent.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblBuscar.Location = new System.Drawing.Point(18, 92);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(185, 15);
            this.lblBuscar.TabIndex = 2;
            this.lblBuscar.Text = "Buscar por Cédula, Placa o Nombre:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.White;
            this.txtBuscar.Location = new System.Drawing.Point(21, 110);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(350, 24);
            this.txtBuscar.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(385, 108);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 26);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvActas
            // 
            this.dgvActas.AllowUserToAddRows = false;
            this.dgvActas.AllowUserToDeleteRows = false;
            this.dgvActas.AllowUserToResizeRows = false;
            this.dgvActas.BackgroundColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.dgvActas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvActas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvActas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvActas.ColumnHeadersHeight = 30;
            this.dgvActas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(22, 101, 52);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvActas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvActas.EnableHeadersVisualStyles = false;
            this.dgvActas.GridColor = System.Drawing.Color.FromArgb(13, 31, 15);
            this.dgvActas.Location = new System.Drawing.Point(21, 160);
            this.dgvActas.MultiSelect = false;
            this.dgvActas.Name = "dgvActas";
            this.dgvActas.ReadOnly = true;
            this.dgvActas.RowHeadersVisible = false;
            this.dgvActas.RowTemplate.Height = 28;
            this.dgvActas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActas.Size = new System.Drawing.Size(454, 300);
            this.dgvActas.TabIndex = 5;
            this.dgvActas.SelectionChanged += new System.EventHandler(this.dgvActas_SelectionChanged);
            // 
            // lblResultados
            // 
            this.lblResultados.AutoSize = true;
            this.lblResultados.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultados.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblResultados.Location = new System.Drawing.Point(18, 470);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(133, 15);
            this.lblResultados.TabIndex = 6;
            this.lblResultados.Text = "Esperando búsqueda...";
            // 
            // gbCobro
            // 
            this.gbCobro.Controls.Add(this.lblSelectedActa);
            this.gbCobro.Controls.Add(this.lblSelectedConductor);
            this.gbCobro.Controls.Add(this.lblSelectedMonto);
            this.gbCobro.Controls.Add(this.lblDescPago);
            this.gbCobro.Controls.Add(this.txtDescPago);
            this.gbCobro.Controls.Add(this.btnPagar);
            this.gbCobro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCobro.ForeColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.gbCobro.Location = new System.Drawing.Point(495, 110);
            this.gbCobro.Name = "gbCobro";
            this.gbCobro.Size = new System.Drawing.Size(265, 350);
            this.gbCobro.TabIndex = 7;
            this.gbCobro.TabStop = false;
            this.gbCobro.Text = "Detalles de Cobro";
            // 
            // lblSelectedActa
            // 
            this.lblSelectedActa.AutoSize = true;
            this.lblSelectedActa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedActa.ForeColor = System.Drawing.Color.FromArgb(204, 251, 241);
            this.lblSelectedActa.Location = new System.Drawing.Point(18, 40);
            this.lblSelectedActa.Name = "lblSelectedActa";
            this.lblSelectedActa.Size = new System.Drawing.Size(167, 15);
            this.lblSelectedActa.TabIndex = 0;
            this.lblSelectedActa.Text = "Acta UUID: Seleccione una multa";
            // 
            // lblSelectedConductor
            // 
            this.lblSelectedConductor.AutoSize = true;
            this.lblSelectedConductor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedConductor.ForeColor = System.Drawing.Color.White;
            this.lblSelectedConductor.Location = new System.Drawing.Point(18, 70);
            this.lblSelectedConductor.Name = "lblSelectedConductor";
            this.lblSelectedConductor.Size = new System.Drawing.Size(89, 17);
            this.lblSelectedConductor.TabIndex = 1;
            this.lblSelectedConductor.Text = "Conductor: -";
            // 
            // lblSelectedMonto
            // 
            this.lblSelectedMonto.AutoSize = true;
            this.lblSelectedMonto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedMonto.ForeColor = System.Drawing.Color.FromArgb(74, 222, 128);
            this.lblSelectedMonto.Location = new System.Drawing.Point(17, 105);
            this.lblSelectedMonto.Name = "lblSelectedMonto";
            this.lblSelectedMonto.Size = new System.Drawing.Size(199, 21);
            this.lblSelectedMonto.TabIndex = 2;
            this.lblSelectedMonto.Text = "Monto a Pagar: RD$ 0.00";
            // 
            // lblDescPago
            // 
            this.lblDescPago.AutoSize = true;
            this.lblDescPago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescPago.ForeColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblDescPago.Location = new System.Drawing.Point(18, 160);
            this.lblDescPago.Name = "lblDescPago";
            this.lblDescPago.Size = new System.Drawing.Size(124, 15);
            this.lblDescPago.TabIndex = 3;
            this.lblDescPago.Text = "Descripción del Pago:";
            // 
            // txtDescPago
            // 
            this.txtDescPago.BackColor = System.Drawing.Color.FromArgb(26, 58, 29);
            this.txtDescPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescPago.Enabled = false;
            this.txtDescPago.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescPago.ForeColor = System.Drawing.Color.White;
            this.txtDescPago.Location = new System.Drawing.Point(21, 180);
            this.txtDescPago.Multiline = true;
            this.txtDescPago.Name = "txtDescPago";
            this.txtDescPago.Size = new System.Drawing.Size(225, 70);
            this.txtDescPago.TabIndex = 4;
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnPagar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPagar.Enabled = false;
            this.btnPagar.FlatAppearance.BorderSize = 0;
            this.btnPagar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnPagar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ForeColor = System.Drawing.Color.White;
            this.btnPagar.Location = new System.Drawing.Point(21, 280);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(225, 45);
            this.btnPagar.TabIndex = 5;
            this.btnPagar.Text = "💳 Registrar Cobro / Pago";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnVolver.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(628, 470);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(132, 30);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCajero.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblCajero.Location = new System.Drawing.Point(495, 477);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(107, 15);
            this.lblCajero.TabIndex = 9;
            this.lblCajero.Text = "Cajero ID: Ninguno";
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            // 
            // CajaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 31, 15);
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlSidebarAccent);
            this.Controls.Add(this.pnlContentContainer);
            this.Controls.Add(this.pnlSidebar);
=======
=======
>>>>>>> Stashed changes
            this.ClientSize = new System.Drawing.Size(784, 511);
            this.Controls.Add(this.lblCajero);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.gbCobro);
            this.Controls.Add(this.lblResultados);
            this.Controls.Add(this.dgvActas);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.pnlAccent);
            this.Controls.Add(this.pnlHeader);
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CajaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            this.Text = "DIGESETT — Módulo de Caja (Ventanilla)";
            this.Load += new System.EventHandler(this.CajaForm_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlContentContainer.ResumeLayout(false);
            this.pnlApertura.ResumeLayout(false);
            this.pnlApertura.PerformLayout();
            this.pnlCobro.ResumeLayout(false);
            this.pnlCobro.PerformLayout();
            this.pnlMultaDetails.ResumeLayout(false);
            this.pnlMultaDetails.PerformLayout();
            this.pnlRecibo.ResumeLayout(false);
            this.pnlRecibo.PerformLayout();
            this.pnlMovimientos.ResumeLayout(false);
            this.pnlMovimientos.PerformLayout();
            this.pnlCierre.ResumeLayout(false);
            this.pnlCierre.PerformLayout();
            this.ResumeLayout(false);
=======
=======
>>>>>>> Stashed changes
            this.Text = "DIGESETT — Caja Mode";
            this.Load += new System.EventHandler(this.CajaForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActas)).EndInit();
            this.gbCobro.ResumeLayout(false);
            this.gbCobro.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

        }
    }
}
