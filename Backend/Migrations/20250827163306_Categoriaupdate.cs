using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Categoriaupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCompra",
                value: new DateTime(2025, 8, 27, 13, 33, 4, 170, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCompra",
                value: new DateTime(2025, 8, 27, 13, 33, 4, 170, DateTimeKind.Local).AddTicks(1826));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 8, 27, 13, 33, 4, 170, DateTimeKind.Local).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 8, 27, 13, 33, 4, 170, DateTimeKind.Local).AddTicks(1746));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCompra",
                value: new DateTime(2025, 8, 27, 13, 18, 14, 261, DateTimeKind.Local).AddTicks(1292));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCompra",
                value: new DateTime(2025, 8, 27, 13, 18, 14, 261, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 8, 27, 13, 18, 14, 261, DateTimeKind.Local).AddTicks(1173));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 8, 27, 13, 18, 14, 261, DateTimeKind.Local).AddTicks(1195));
        }
    }
}
