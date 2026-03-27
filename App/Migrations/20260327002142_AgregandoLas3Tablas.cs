using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoLas3Tablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Documento = table.Column<string>(type: "TEXT", nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Departamento = table.Column<decimal>(type: "TEXT", nullable: false),
                    PuestoTrabajo = table.Column<decimal>(type: "TEXT", nullable: false),
                    SalarioBase = table.Column<decimal>(type: "TEXT", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planillas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Periodo = table.Column<string>(type: "TEXT", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planillas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetallesPlanilla",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    PlanillaId = table.Column<string>(type: "TEXT", nullable: true),
                    EmpleadoId = table.Column<string>(type: "TEXT", nullable: true),
                    SalarioBase = table.Column<decimal>(type: "TEXT", nullable: false),
                    HorasExtra = table.Column<decimal>(type: "TEXT", nullable: false),
                    Bonificaciones = table.Column<decimal>(type: "TEXT", nullable: false),
                    Deducciones = table.Column<decimal>(type: "TEXT", nullable: false),
                    SalarioNeto = table.Column<decimal>(type: "TEXT", nullable: false),
                    Comentarios = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesPlanilla", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesPlanilla_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetallesPlanilla_Planillas_PlanillaId",
                        column: x => x.PlanillaId,
                        principalTable: "Planillas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPlanilla_EmpleadoId",
                table: "DetallesPlanilla",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPlanilla_PlanillaId",
                table: "DetallesPlanilla",
                column: "PlanillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesPlanilla");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Planillas");
        }
    }
}
