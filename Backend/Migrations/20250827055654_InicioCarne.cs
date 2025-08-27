using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InicioCarne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCompra",
                value: new DateTime(2025, 8, 27, 2, 56, 51, 507, DateTimeKind.Local).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCompra",
                value: new DateTime(2025, 8, 27, 2, 56, 51, 507, DateTimeKind.Local).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 8, 27, 2, 56, 51, 507, DateTimeKind.Local).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 8, 27, 2, 56, 51, 507, DateTimeKind.Local).AddTicks(1526));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCompra",
                value: new DateTime(2025, 8, 27, 2, 41, 33, 287, DateTimeKind.Local).AddTicks(9368));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCompra",
                value: new DateTime(2025, 8, 27, 2, 41, 33, 287, DateTimeKind.Local).AddTicks(9375));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 8, 27, 2, 41, 33, 287, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 8, 27, 2, 41, 33, 287, DateTimeKind.Local).AddTicks(9208));
        }
    }
}
