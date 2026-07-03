using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amet.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conductores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificacionPendiente = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conductores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposInfraccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoParticular = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoMotocicleta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoCarga = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequiereRetencion = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposInfraccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Actas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConductorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TipoInfraccionId = table.Column<int>(type: "int", nullable: false),
                    AgenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoRecargo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaHecho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaLimitePago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reincidente = table.Column<bool>(type: "bit", nullable: false),
                    UrlEvidencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentificacionPendiente = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actas_Conductores_ConductorId",
                        column: x => x.ConductorId,
                        principalTable: "Conductores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Actas_TiposInfraccion_TipoInfraccionId",
                        column: x => x.TipoInfraccionId,
                        principalTable: "TiposInfraccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actas_Usuarios_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Canodromos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiasCobrados = table.Column<int>(type: "int", nullable: false),
                    CostoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminIngresoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminSalidaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canodromos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Canodromos_Actas_ActaId",
                        column: x => x.ActaId,
                        principalTable: "Actas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Canodromos_Usuarios_AdminIngresoId",
                        column: x => x.AdminIngresoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Canodromos_Usuarios_AdminSalidaId",
                        column: x => x.AdminSalidaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Impugnaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaLimite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoResolucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MontoNuevo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FiscalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FechaResolucion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MotivoCiudadano = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impugnaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Impugnaciones_Actas_ActaId",
                        column: x => x.ActaId,
                        principalTable: "Actas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Impugnaciones_Usuarios_FiscalId",
                        column: x => x.FiscalId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Canal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTransaccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoMulta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoRecargo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoEstadia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CajeroId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Actas_ActaId",
                        column: x => x.ActaId,
                        principalTable: "Actas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pagos_Usuarios_CajeroId",
                        column: x => x.CajeroId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actas_AgenteId",
                table: "Actas",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Actas_ConductorId",
                table: "Actas",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_Actas_TipoInfraccionId",
                table: "Actas",
                column: "TipoInfraccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Canodromos_ActaId",
                table: "Canodromos",
                column: "ActaId");

            migrationBuilder.CreateIndex(
                name: "IX_Canodromos_AdminIngresoId",
                table: "Canodromos",
                column: "AdminIngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_Canodromos_AdminSalidaId",
                table: "Canodromos",
                column: "AdminSalidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Impugnaciones_ActaId",
                table: "Impugnaciones",
                column: "ActaId");

            migrationBuilder.CreateIndex(
                name: "IX_Impugnaciones_FiscalId",
                table: "Impugnaciones",
                column: "FiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ActaId",
                table: "Pagos",
                column: "ActaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_CajeroId",
                table: "Pagos",
                column: "CajeroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canodromos");

            migrationBuilder.DropTable(
                name: "Impugnaciones");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Actas");

            migrationBuilder.DropTable(
                name: "Conductores");

            migrationBuilder.DropTable(
                name: "TiposInfraccion");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
