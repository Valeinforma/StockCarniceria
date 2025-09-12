using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class actualizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoPagoEnum",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCompra",
                value: new DateTime(2025, 9, 12, 17, 58, 48, 260, DateTimeKind.Local).AddTicks(9052));

            migrationBuilder.UpdateData(
                table: "DetallesCompra",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCompra",
                value: new DateTime(2025, 9, 12, 17, 58, 48, 260, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cliente", "Fecha", "TipoPagoEnum", "UsuarioId" },
                values: new object[] { "Juan Perez", new DateTime(2025, 9, 12, 17, 58, 48, 260, DateTimeKind.Local).AddTicks(8903), 1, 1 });

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cliente", "Fecha", "Precio", "TipoPagoEnum" },
                values: new object[] { "Maria Gomez", new DateTime(2025, 9, 12, 17, 58, 48, 260, DateTimeKind.Local).AddTicks(8925), 800.00m, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoPagoEnum",
                table: "Ventas");

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
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cliente", "Fecha", "UsuarioId" },
                values: new object[] { null, new DateTime(2025, 8, 28, 12, 10, 47, 888, DateTimeKind.Local).AddTicks(2666), 2 });

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cliente", "Fecha", "Precio" },
                values: new object[] { null, new DateTime(2025, 8, 28, 12, 10, 47, 888, DateTimeKind.Local).AddTicks(2687), 1500.00m });
        }
    }
}
