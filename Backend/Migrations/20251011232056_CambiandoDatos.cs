using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CambiandoDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCompra",
                value: new DateTime(2025, 10, 11, 20, 20, 53, 387, DateTimeKind.Local).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCompra",
                value: new DateTime(2025, 10, 11, 20, 20, 53, 387, DateTimeKind.Local).AddTicks(6580));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCompra",
                value: new DateTime(2025, 10, 11, 20, 20, 53, 387, DateTimeKind.Local).AddTicks(6583));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCompra",
                value: new DateTime(2025, 10, 11, 20, 20, 53, 387, DateTimeKind.Local).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 10, 11, 20, 20, 53, 387, DateTimeKind.Local).AddTicks(6412));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 10, 11, 20, 20, 53, 387, DateTimeKind.Local).AddTicks(6434));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
