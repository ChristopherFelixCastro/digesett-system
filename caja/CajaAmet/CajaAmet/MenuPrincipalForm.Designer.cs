using System.Windows.Forms;
using System.Drawing;

namespace CajaAmet
{
    partial class MenuPrincipalForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlAccent;
        private System.Windows.Forms.Label lblNetworkDot;
        private System.Windows.Forms.Label lblNetworkText;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDbPath;
        private System.Windows.Forms.Button btnHandheld;
        private System.Windows.Forms.Button btnCaja;
        private System.Windows.Forms.Button btnLogout;
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblNetworkDot = new System.Windows.Forms.Label();
            this.lblNetworkText = new System.Windows.Forms.Label();
            this.pnlAccent = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblDbPath = new System.Windows.Forms.Label();
            this.btnHandheld = new System.Windows.Forms.Button();
            this.btnCaja = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.timerNetwork = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblNetworkDot);
            this.pnlHeader.Controls.Add(this.lblNetworkText);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(584, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(252, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SISTEMA DIGITAL DIGESETT";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(204, 251, 241);
            this.lblSubtitle.Location = new System.Drawing.Point(18, 40);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(251, 15);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Panel Principal de Operaciones y Cuentas";
            // 
            // lblNetworkDot
            // 
            this.lblNetworkDot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetworkDot.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkDot.ForeColor = System.Drawing.Color.FromArgb(74, 222, 128);
            this.lblNetworkDot.Location = new System.Drawing.Point(445, 18);
            this.lblNetworkDot.Name = "lblNetworkDot";
            this.lblNetworkDot.Size = new System.Drawing.Size(25, 30);
            this.lblNetworkDot.TabIndex = 2;
            this.lblNetworkDot.Text = "●";
            this.lblNetworkDot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNetworkText
            // 
            this.lblNetworkText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetworkText.AutoSize = true;
            this.lblNetworkText.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetworkText.ForeColor = System.Drawing.Color.White;
            this.lblNetworkText.Location = new System.Drawing.Point(472, 27);
            this.lblNetworkText.Name = "lblNetworkText";
            this.lblNetworkText.Size = new System.Drawing.Size(95, 17);
            this.lblNetworkText.TabIndex = 3;
            this.lblNetworkText.Text = "En Línea (Red)";
            // 
            // pnlAccent
            // 
            this.pnlAccent.BackColor = System.Drawing.Color.FromArgb(15, 150, 136);
            this.pnlAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAccent.Location = new System.Drawing.Point(0, 75);
            this.pnlAccent.Name = "pnlAccent";
            this.pnlAccent.Size = new System.Drawing.Size(584, 4);
            this.pnlAccent.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblWelcome.Location = new System.Drawing.Point(26, 95);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(189, 21);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Sesión Activa: Cargando...";
            // 
            // lblDbPath
            // 
            this.lblDbPath.AutoSize = true;
            this.lblDbPath.Font = new System.Drawing.Font("Consolas", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDbPath.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblDbPath.Location = new System.Drawing.Point(27, 120);
            this.lblDbPath.Name = "lblDbPath";
            this.lblDbPath.Size = new System.Drawing.Size(280, 14);
            this.lblDbPath.TabIndex = 3;
            this.lblDbPath.Text = "Base de datos local: %AppData%\\Digesett\\";
            // 
            // btnHandheld
            // 
            this.btnHandheld.BackColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.btnHandheld.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHandheld.FlatAppearance.BorderSize = 0;
            this.btnHandheld.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnHandheld.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnHandheld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHandheld.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHandheld.ForeColor = System.Drawing.Color.White;
            this.btnHandheld.Location = new System.Drawing.Point(30, 160);
            this.btnHandheld.Name = "btnHandheld";
            this.btnHandheld.Size = new System.Drawing.Size(248, 120);
            this.btnHandheld.TabIndex = 4;
            this.btnHandheld.Text = "📱 MODO HANDHELD\r\n\r\nFiscalización de Actas\r\n(Offline-First)";
            this.btnHandheld.UseVisualStyleBackColor = false;
            this.btnHandheld.Click += new System.EventHandler(this.btnHandheld_Click);
            // 
            // btnCaja
            // 
            this.btnCaja.BackColor = System.Drawing.Color.FromArgb(15, 118, 110);
            this.btnCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaja.FlatAppearance.BorderSize = 0;
            this.btnCaja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(13, 148, 136);
            this.btnCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(13, 148, 136);
            this.btnCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaja.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaja.ForeColor = System.Drawing.Color.White;
            this.btnCaja.Location = new System.Drawing.Point(306, 160);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Size = new System.Drawing.Size(248, 120);
            this.btnCaja.TabIndex = 5;
            this.btnCaja.Text = "🏧 MODO CAJA\r\n\r\nCobros e Ingresos\r\nde Ventanilla";
            this.btnCaja.UseVisualStyleBackColor = false;
            this.btnCaja.Click += new System.EventHandler(this.btnCaja_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(444, 309);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 30);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Cerrar Sesión";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // timerNetwork
            // 
            this.timerNetwork.Enabled = true;
            this.timerNetwork.Interval = 3000;
            this.timerNetwork.Tick += new System.EventHandler(this.timerNetwork_Tick);
            // 
            // MenuPrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 31, 15);
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCaja);
            this.Controls.Add(this.btnHandheld);
            this.Controls.Add(this.lblDbPath);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pnlAccent);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuPrincipalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DIGESETT — Menú Principal";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
