using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class inicioVale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCompra",
                value: new DateTime(2025, 8, 27, 13, 40, 52, 345, DateTimeKind.Local).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCompra",
                value: new DateTime(2025, 8, 27, 13, 40, 52, 345, DateTimeKind.Local).AddTicks(6177));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 8, 27, 13, 40, 52, 345, DateTimeKind.Local).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 8, 27, 13, 40, 52, 345, DateTimeKind.Local).AddTicks(6093));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCompra",
                value: new DateTime(2025, 8, 27, 13, 39, 2, 188, DateTimeKind.Local).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCompra",
                value: new DateTime(2025, 8, 27, 13, 39, 2, 188, DateTimeKind.Local).AddTicks(5637));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 8, 27, 13, 39, 2, 188, DateTimeKind.Local).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 8, 27, 13, 39, 2, 188, DateTimeKind.Local).AddTicks(5496));
        }
    }
}
