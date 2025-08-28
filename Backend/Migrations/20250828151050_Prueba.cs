using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Prueba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCompra",
                value: new DateTime(2025, 8, 28, 12, 10, 47, 888, DateTimeKind.Local).AddTicks(2814));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCompra",
                value: new DateTime(2025, 8, 28, 12, 10, 47, 888, DateTimeKind.Local).AddTicks(2820));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nombre",
                value: "Martin");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "Pepe");

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 8, 28, 12, 10, 47, 888, DateTimeKind.Local).AddTicks(2666));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 8, 28, 12, 10, 47, 888, DateTimeKind.Local).AddTicks(2687));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "Nombre",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "vendedor1");

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
    }
}
