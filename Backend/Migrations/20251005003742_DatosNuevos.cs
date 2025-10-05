using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class DatosNuevos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCompra",
                value: new DateTime(2025, 10, 4, 21, 37, 37, 535, DateTimeKind.Local).AddTicks(6516));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCompra",
                value: new DateTime(2025, 10, 4, 21, 37, 37, 535, DateTimeKind.Local).AddTicks(6545));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCompra",
                value: new DateTime(2025, 10, 4, 21, 37, 37, 535, DateTimeKind.Local).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCompra",
                value: new DateTime(2025, 10, 4, 21, 37, 37, 535, DateTimeKind.Local).AddTicks(6556));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 10, 4, 21, 37, 37, 531, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 10, 4, 21, 37, 37, 531, DateTimeKind.Local).AddTicks(1897));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCompra",
                value: new DateTime(2025, 9, 30, 17, 23, 33, 370, DateTimeKind.Local).AddTicks(14));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCompra",
                value: new DateTime(2025, 9, 30, 17, 23, 33, 370, DateTimeKind.Local).AddTicks(21));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCompra",
                value: new DateTime(2025, 9, 30, 17, 23, 33, 370, DateTimeKind.Local).AddTicks(24));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCompra",
                value: new DateTime(2025, 9, 30, 17, 23, 33, 370, DateTimeKind.Local).AddTicks(28));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 9, 30, 17, 23, 33, 369, DateTimeKind.Local).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 9, 30, 17, 23, 33, 369, DateTimeKind.Local).AddTicks(9874));
        }
    }
}
