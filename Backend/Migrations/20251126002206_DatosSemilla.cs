using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class DatosSemilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipoUsuarioEnum = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    Unidad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    VendedorId = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    NombreClienteSinUsuario = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrecioTotal = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TipoPagoEnum = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Usuarios_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ventas_Usuarios_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetallesVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CantidadProductoVendido = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PrecioTotalProductoVendido = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesVenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesVenta_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesVenta_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "IsDeleted", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Carnes Rojas" },
                    { 2, false, "Aves y Pescados" },
                    { 3, false, "Embutidos" },
                    { 4, false, "Mariscos" }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "Id", "IsDeleted", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Ganadería Premium S.A." },
                    { 2, false, "Distribuidora de Carnes del Sur" },
                    { 3, false, "Mariscos Frescos Ltda." },
                    { 4, false, "Embutidos Artesanales" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "IsDeleted", "Nombre", "tipoUsuarioEnum" },
                values: new object[,]
                {
                    { 1, false, "Carlos Mendez", 1 },
                    { 2, false, "Ana González", 1 },
                    { 3, false, "Juan Pérez", 2 },
                    { 4, false, "María García", 2 },
                    { 5, false, "Roberto López", 2 },
                    { 6, false, "Sofía Martínez", 1 }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "IsDeleted", "Nombre", "PrecioUnitario", "ProveedorId", "Stock", "Unidad" },
                values: new object[,]
                {
                    { 1, 1, false, "Carne de Res - Corte Premium", 25.50m, 1, 50, "kg" },
                    { 2, 1, false, "Carne de Res - Costilla", 18.75m, 1, 35, "kg" },
                    { 3, 1, false, "Carne Molida de Res", 15.99m, 2, 60, "kg" },
                    { 4, 2, false, "Pechuga de Pollo", 9.50m, 1, 80, "kg" },
                    { 5, 2, false, "Muslo de Pollo", 7.99m, 1, 75, "kg" },
                    { 6, 2, false, "Filete de Pescado", 16.50m, 2, 40, "kg" },
                    { 7, 3, false, "Jamón Serrano", 22.00m, 4, 30, "kg" },
                    { 8, 3, false, "Chorizo Español", 14.50m, 4, 25, "kg" },
                    { 9, 3, false, "Salchicha Premium", 12.75m, 4, 45, "kg" },
                    { 10, 4, false, "Camarón Fresco", 28.00m, 3, 20, "kg" },
                    { 11, 4, false, "Pulpo Gallego", 32.50m, 3, 15, "kg" },
                    { 12, 4, false, "Mejillones Frescos", 11.99m, 3, 50, "kg" }
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "Id", "ClienteId", "Fecha", "IsDeleted", "NombreClienteSinUsuario", "PrecioTotal", "TipoPagoEnum", "VendedorId" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2025, 11, 18, 21, 21, 54, 561, DateTimeKind.Local).AddTicks(7952), false, null, 76.50m, 1, 1 },
                    { 2, 4, new DateTime(2025, 11, 20, 21, 21, 54, 561, DateTimeKind.Local).AddTicks(7985), false, null, 57.49m, 2, 2 },
                    { 3, 5, new DateTime(2025, 11, 23, 21, 21, 54, 561, DateTimeKind.Local).AddTicks(7990), false, null, 94.99m, 3, 1 },
                    { 4, null, new DateTime(2025, 11, 24, 21, 21, 54, 561, DateTimeKind.Local).AddTicks(7994), false, "Cliente Anónimo", 45.75m, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "DetallesVenta",
                columns: new[] { "Id", "CantidadProductoVendido", "IsDeleted", "PrecioTotalProductoVendido", "ProductoId", "VentaId" },
                values: new object[,]
                {
                    { 1, 2m, false, 51.00m, 1, 1 },
                    { 2, 2.5m, false, 23.75m, 4, 1 },
                    { 3, 1m, false, 15.99m, 3, 2 },
                    { 4, 1.5m, false, 33.00m, 7, 2 },
                    { 5, 2m, false, 56.00m, 10, 3 },
                    { 6, 3m, false, 23.97m, 5, 3 },
                    { 7, 1m, false, 14.50m, 8, 4 },
                    { 8, 2m, false, 23.98m, 12, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesVenta_ProductoId",
                table: "DetallesVenta",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesVenta_VentaId",
                table: "DetallesVenta",
                column: "VentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ProveedorId",
                table: "Productos",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteId",
                table: "Ventas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_VendedorId",
                table: "Ventas",
                column: "VendedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesVenta");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
