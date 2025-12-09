using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Cosas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "NombreClienteSinUsuario",
                table: "Ventas");

            migrationBuilder.AddColumn<int>(
                name: "VentaId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "VentaId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2,
                column: "VentaId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3,
                column: "VentaId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4,
                column: "VentaId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 5,
                column: "VentaId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 6,
                column: "VentaId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 7,
                column: "VentaId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 8,
                column: "VentaId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 9,
                column: "VentaId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 10,
                column: "VentaId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 11,
                column: "VentaId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 12,
                column: "VentaId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2025, 12, 1, 23, 20, 45, 640, DateTimeKind.Local).AddTicks(8307));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Fecha",
                value: new DateTime(2025, 12, 3, 23, 20, 45, 640, DateTimeKind.Local).AddTicks(8342));

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Fecha",
                value: new DateTime(2025, 12, 6, 23, 20, 45, 640, DateTimeKind.Local).AddTicks(8348));

            migrationBuilder.CreateIndex(
                name: "IX_Productos_VentaId",
                table: "Productos",
                column: "VentaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Ventas_VentaId",
                table: "Productos",
                column: "VentaId",
                principalTable: "Ventas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Ventas_VentaId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_VentaId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "VentaId",
                table: "Productos");

            migrationBuilder.AddColumn<string>(
                name: "NombreClienteSinUsuario",
                table: "Ventas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fecha", "NombreClienteSinUsuario" },
                values: new object[] { new DateTime(2025, 12, 1, 17, 26, 45, 170, DateTimeKind.Local).AddTicks(5497), null });

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Fecha", "NombreClienteSinUsuario" },
                values: new object[] { new DateTime(2025, 12, 3, 17, 26, 45, 170, DateTimeKind.Local).AddTicks(5526), null });

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Fecha", "NombreClienteSinUsuario" },
                values: new object[] { new DateTime(2025, 12, 6, 17, 26, 45, 170, DateTimeKind.Local).AddTicks(5531), null });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "Id", "ClienteId", "Fecha", "IsDeleted", "NombreClienteSinUsuario", "PrecioTotal", "TipoPagoEnum", "VendedorId" },
                values: new object[] { 4, null, new DateTime(2025, 12, 7, 17, 26, 45, 170, DateTimeKind.Local).AddTicks(5535), false, "Cliente Anónimo", 45.75m, 4, 2 });
        }
    }
}
