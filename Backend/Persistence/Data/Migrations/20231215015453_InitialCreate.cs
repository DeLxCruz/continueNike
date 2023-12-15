using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    categoria_id = table.Column<int>(type: "int", nullable: false),
                    nombre_categoria = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.categoria_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    producto_id = table.Column<int>(type: "int", nullable: false),
                    nombre_producto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precio = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    existencias = table.Column<int>(type: "int", nullable: false),
                    stock_minimo = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'0'"),
                    stock_maximo = table.Column<int>(type: "int", nullable: true, defaultValueSql: "'100'"),
                    url_producto = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.producto_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "inventarios",
                columns: table => new
                {
                    inventario_id = table.Column<int>(type: "int", nullable: false),
                    producto_id = table.Column<int>(type: "int", nullable: true),
                    cantidad_anterior = table.Column<int>(type: "int", nullable: false),
                    cantidad_nueva = table.Column<int>(type: "int", nullable: false),
                    fecha_movimiento = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.inventario_id);
                    table.ForeignKey(
                        name: "inventarios_ibfk_1",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "producto_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "productoscategorias",
                columns: table => new
                {
                    producto_id = table.Column<int>(type: "int", nullable: false),
                    categoria_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.producto_id, x.categoria_id })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "productoscategorias_ibfk_1",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "producto_id");
                    table.ForeignKey(
                        name: "productoscategorias_ibfk_2",
                        column: x => x.categoria_id,
                        principalTable: "categorias",
                        principalColumn: "categoria_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "carritos",
                columns: table => new
                {
                    carrito_id = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: true),
                    fecha_creacion = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.carrito_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "detallescarrito",
                columns: table => new
                {
                    detalle_carrito_id = table.Column<int>(type: "int", nullable: false),
                    carrito_id = table.Column<int>(type: "int", nullable: true),
                    producto_id = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.detalle_carrito_id);
                    table.ForeignKey(
                        name: "detallescarrito_ibfk_1",
                        column: x => x.carrito_id,
                        principalTable: "carritos",
                        principalColumn: "carrito_id");
                    table.ForeignKey(
                        name: "detallescarrito_ibfk_2",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "producto_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "detallespedido",
                columns: table => new
                {
                    detalle_id = table.Column<int>(type: "int", nullable: false),
                    pedido_id = table.Column<int>(type: "int", nullable: true),
                    producto_id = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.detalle_id);
                    table.ForeignKey(
                        name: "detallespedido_ibfk_2",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "producto_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "detallestransaccion",
                columns: table => new
                {
                    detalle_transaccion_id = table.Column<int>(type: "int", nullable: false),
                    transaccion_id = table.Column<int>(type: "int", nullable: true),
                    producto_id = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precio_unitario = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.detalle_transaccion_id);
                    table.ForeignKey(
                        name: "detallestransaccion_ibfk_2",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "producto_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    pedido_id = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: true),
                    fecha_pedido = table.Column<DateOnly>(type: "date", nullable: false),
                    estado_pedido = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.pedido_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                columns: table => new
                {
                    refresh_token_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    token = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    expiry_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.refresh_token_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    rol_id = table.Column<int>(type: "int", nullable: false),
                    nombre_rol = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.rol_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    nombre_usuario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    correo_electronico = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contrasena = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rol_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.usuario_id);
                    table.ForeignKey(
                        name: "usuarios_ibfk_1",
                        column: x => x.rol_id,
                        principalTable: "roles",
                        principalColumn: "rol_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "transacciones",
                columns: table => new
                {
                    transaccion_id = table.Column<int>(type: "int", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: true),
                    fecha_transaccion = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    total = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.transaccion_id);
                    table.ForeignKey(
                        name: "transacciones_ibfk_1",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "usuario_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "usuarioscompras",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false),
                    total_compras = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.usuario_id);
                    table.ForeignKey(
                        name: "usuarioscompras_ibfk_1",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "usuario_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "usuario_id",
                table: "carritos",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "carrito_id",
                table: "detallescarrito",
                column: "carrito_id");

            migrationBuilder.CreateIndex(
                name: "producto_id",
                table: "detallescarrito",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "pedido_id",
                table: "detallespedido",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "producto_id1",
                table: "detallespedido",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "producto_id2",
                table: "detallestransaccion",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "transaccion_id",
                table: "detallestransaccion",
                column: "transaccion_id");

            migrationBuilder.CreateIndex(
                name: "producto_id3",
                table: "inventarios",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "usuario_id1",
                table: "pedidos",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "categoria_id",
                table: "productoscategorias",
                column: "categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_tokens_UsuarioId",
                table: "refresh_tokens",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_tokens_user_id",
                table: "refresh_tokens",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_roles_UsuarioId",
                table: "roles",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "usuario_id2",
                table: "transacciones",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "rol_id",
                table: "usuarios",
                column: "rol_id");

            migrationBuilder.AddForeignKey(
                name: "carritos_ibfk_1",
                table: "carritos",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "usuario_id");

            migrationBuilder.AddForeignKey(
                name: "detallespedido_ibfk_1",
                table: "detallespedido",
                column: "pedido_id",
                principalTable: "pedidos",
                principalColumn: "pedido_id");

            migrationBuilder.AddForeignKey(
                name: "detallestransaccion_ibfk_1",
                table: "detallestransaccion",
                column: "transaccion_id",
                principalTable: "transacciones",
                principalColumn: "transaccion_id");

            migrationBuilder.AddForeignKey(
                name: "pedidos_ibfk_1",
                table: "pedidos",
                column: "usuario_id",
                principalTable: "usuarios",
                principalColumn: "usuario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_refresh_tokens_usuarios_UsuarioId",
                table: "refresh_tokens",
                column: "user_id",
                principalTable: "usuarios",
                principalColumn: "usuario_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_refresh_tokens_usuarios_UsuarioId1",
                table: "refresh_tokens",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "usuario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_roles_usuarios_UsuarioId",
                table: "roles",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_usuarios_UsuarioId",
                table: "roles");

            migrationBuilder.DropTable(
                name: "detallescarrito");

            migrationBuilder.DropTable(
                name: "detallespedido");

            migrationBuilder.DropTable(
                name: "detallestransaccion");

            migrationBuilder.DropTable(
                name: "inventarios");

            migrationBuilder.DropTable(
                name: "productoscategorias");

            migrationBuilder.DropTable(
                name: "refresh_tokens");

            migrationBuilder.DropTable(
                name: "usuarioscompras");

            migrationBuilder.DropTable(
                name: "carritos");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "transacciones");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
