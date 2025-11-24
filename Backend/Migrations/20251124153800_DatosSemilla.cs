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
                name: "DetallesCompra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdDetalleCompra = table.Column<int>(type: "int", nullable: false),
                    IdCompra = table.Column<int>(type: "int", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesCompra", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetallesVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdDetalleVenta = table.Column<int>(type: "int", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesVenta", x => x.Id);
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
                    Rol = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdVenta = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Cliente = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TipoPagoEnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
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
                    Precio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "IsDeleted", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Carnes Rojas" },
                    { 2, false, "Carnes Blancas" },
                    { 3, false, "Embutidos" },
                    { 4, false, "Mariscos" }
                });

            migrationBuilder.InsertData(
                table: "DetallesCompra",
                columns: new[] { "Id", "Cantidad", "FechaCompra", "IdCompra", "IdDetalleCompra", "IsDeleted", "PrecioUnitario", "ProductoId", "ProveedorId" },
                values: new object[,]
                {
                    { 1, 100m, new DateTime(2025, 10, 25, 12, 37, 57, 449, DateTimeKind.Local).AddTicks(8646), 5001, 1, false, 18.00m, 1, 1 },
                    { 2, 150m, new DateTime(2025, 10, 27, 12, 37, 57, 449, DateTimeKind.Local).AddTicks(8655), 5002, 2, false, 6.50m, 4, 1 },
                    { 3, 80m, new DateTime(2025, 10, 30, 12, 37, 57, 449, DateTimeKind.Local).AddTicks(8659), 5003, 3, false, 16.00m, 7, 4 },
                    { 4, 50m, new DateTime(2025, 11, 4, 12, 37, 57, 449, DateTimeKind.Local).AddTicks(8664), 5004, 4, false, 20.00m, 10, 3 },
                    { 5, 120m, new DateTime(2025, 11, 9, 12, 37, 57, 449, DateTimeKind.Local).AddTicks(8668), 5005, 5, false, 11.50m, 3, 2 },
                    { 6, 100m, new DateTime(2025, 11, 14, 12, 37, 57, 449, DateTimeKind.Local).AddTicks(8672), 5006, 6, false, 8.50m, 12, 3 }
                });

            migrationBuilder.InsertData(
                table: "DetallesVenta",
                columns: new[] { "Id", "Cantidad", "IdDetalleVenta", "IsDeleted", "PrecioUnitario", "ProductoId", "VentaId" },
                values: new object[,]
                {
                    { 1, 2m, 1, false, 25.50m, 1, 1 },
                    { 2, 2m, 2, false, 9.50m, 4, 1 },
                    { 3, 1m, 3, false, 15.99m, 3, 2 },
                    { 4, 2m, 4, false, 22.00m, 7, 2 },
                    { 5, 2m, 5, false, 28.00m, 10, 3 },
                    { 6, 3m, 6, false, 7.99m, 5, 3 },
                    { 7, 1.5m, 7, false, 14.50m, 8, 4 },
                    { 8, 2m, 8, false, 11.99m, 12, 4 }
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
                columns: new[] { "Id", "Email", "IsDeleted", "Nombre", "Password", "Rol" },
                values: new object[,]
                {
                    { 1, "admin@carniceria.com", false, "Admin Carnicería", "hashed_password_admin", "admin" },
                    { 2, "juan@carniceria.com", false, "Juan Vendedor", "hashed_password_vendedor", "vendedor" },
                    { 3, "maria@carniceria.com", false, "María Vendedora", "hashed_password_vendedor2", "vendedor" }
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "Id", "Cliente", "Fecha", "IdVenta", "IsDeleted", "Precio", "TipoPagoEnum", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Juan Pérez", new DateTime(2025, 11, 17, 12, 37, 57, 449, DateTimeKind.Local).AddTicks(8444), 1001, false, 76.50m, 1, 2 },
                    { 2, "María García", new DateTime(2025, 11, 19, 12, 37, 57, 449, DateTimeKind.Local).AddTicks(8471), 1002, false, 57.49m, 2, 3 },
                    { 3, "Carlos López", new DateTime(2025, 11, 22, 12, 37, 57, 449, DateTimeKind.Local).AddTicks(8476), 1003, false, 94.99m, 3, 2 },
                    { 4, "Ana Martínez", new DateTime(2025, 11, 23, 12, 37, 57, 449, DateTimeKind.Local).AddTicks(8480), 1004, false, 45.75m, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "IsDeleted", "Nombre", "Precio", "Stock", "Unidad" },
                values: new object[,]
                {
                    { 1, 1, false, "Carne de Res - Corte Premium", 25.50m, 50, "kg" },
                    { 2, 1, false, "Carne de Res - Costilla", 18.75m, 35, "kg" },
                    { 3, 1, false, "Carne Molida de Res", 15.99m, 60, "kg" },
                    { 4, 2, false, "Pechuga de Pollo", 9.50m, 80, "kg" },
                    { 5, 2, false, "Muslo de Pollo", 7.99m, 75, "kg" },
                    { 6, 2, false, "Filete de Pescado", 16.50m, 40, "kg" },
                    { 7, 3, false, "Jamón Serrano", 22.00m, 30, "kg" },
                    { 8, 3, false, "Chorizo Español", 14.50m, 25, "kg" },
                    { 9, 3, false, "Salchicha Premium", 12.75m, 45, "kg" },
                    { 10, 4, false, "Camarón Fresco", 28.00m, 20, "kg" },
                    { 11, 4, false, "Pulpo Gallego", 32.50m, 15, "kg" },
                    { 12, 4, false, "Mejillones Frescos", 11.99m, 50, "kg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesCompra");

            migrationBuilder.DropTable(
                name: "DetallesVenta");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
