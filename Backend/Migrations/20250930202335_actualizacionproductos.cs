using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class actualizacionproductos : Migration
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
                    { 1, false, "Vacuno" },
                    { 2, false, "Aves" },
                    { 3, false, "Lácteos" },
                    { 4, false, "Bebidas" }
                });

            migrationBuilder.InsertData(
                table: "DetallesCompra",
                columns: new[] { "Id", "Cantidad", "FechaCompra", "IdCompra", "IdDetalleCompra", "IsDeleted", "PrecioUnitario", "ProductoId", "ProveedorId" },
                values: new object[,]
                {
                    { 1, 30m, new DateTime(2025, 9, 30, 17, 23, 33, 370, DateTimeKind.Local).AddTicks(14), 0, 0, false, 2000.00m, 1, 1 },
                    { 2, 60m, new DateTime(2025, 9, 30, 17, 23, 33, 370, DateTimeKind.Local).AddTicks(21), 0, 0, false, 1000.00m, 2, 2 },
                    { 3, 25m, new DateTime(2025, 9, 30, 17, 23, 33, 370, DateTimeKind.Local).AddTicks(24), 0, 0, false, 1500.00m, 3, 3 },
                    { 4, 50m, new DateTime(2025, 9, 30, 17, 23, 33, 370, DateTimeKind.Local).AddTicks(28), 0, 0, false, 1200.00m, 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "DetallesVenta",
                columns: new[] { "Id", "Cantidad", "IdDetalleVenta", "IsDeleted", "PrecioUnitario", "ProductoId", "VentaId" },
                values: new object[,]
                {
                    { 1, 2m, 0, false, 2500.00m, 1, 1 },
                    { 2, 1m, 0, false, 1500.00m, 5, 1 },
                    { 3, 1m, 0, false, 1200.00m, 2, 2 },
                    { 4, 2m, 0, false, 900.00m, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "Id", "IsDeleted", "Nombre" },
                values: new object[,]
                {
                    { 1, false, "Frigorífico Patagonia" },
                    { 2, false, "Avícola San Juan" },
                    { 3, false, "Distribuidora Láctea SRL" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "IsDeleted", "Nombre", "Password", "Rol" },
                values: new object[,]
                {
                    { 1, "admin@tienda.com", false, "Sofia", "sofiaAdmin2025", "admin" },
                    { 2, "carlos@tienda.com", false, "Carlos", "carlosV123", "vendedor" },
                    { 3, "lucia@tienda.com", false, "Lucia", "luciaV123", "vendedor" }
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "Id", "Cliente", "Fecha", "IdVenta", "IsDeleted", "Precio", "TipoPagoEnum", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "Pedro López", new DateTime(2025, 9, 30, 17, 23, 33, 369, DateTimeKind.Local).AddTicks(9853), 0, false, 5000.00m, 1, 2 },
                    { 2, "Laura Fernández", new DateTime(2025, 9, 30, 17, 23, 33, 369, DateTimeKind.Local).AddTicks(9874), 0, false, 2700.00m, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "IsDeleted", "Nombre", "Precio", "Stock", "Unidad" },
                values: new object[,]
                {
                    { 1, 1, false, "Asado de Tira", 2500.00m, 20, "kg" },
                    { 2, 2, false, "Suprema de Pollo", 1200.00m, 40, "kg" },
                    { 3, 3, false, "Queso Cremoso", 1800.00m, 15, "kg" },
                    { 4, 3, false, "Leche Entera", 900.00m, 30, "litro" },
                    { 5, 4, false, "Gaseosa Cola", 1500.00m, 50, "botella" },
                    { 6, 1, false, "Matambre Vacuno", 2200.00m, 10, "kg" },
                    { 7, 2, false, "Pechuga de Pollo", 1300.00m, 25, "kg" },
                    { 8, 3, false, "Yogur Natural", 700.00m, 35, "unidad" },
                    { 9, 4, false, "Agua Mineral", 800.00m, 60, "botella" },
                    { 10, 1, false, "Chorizo Parrillero", 1100.00m, 18, "kg" }
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
