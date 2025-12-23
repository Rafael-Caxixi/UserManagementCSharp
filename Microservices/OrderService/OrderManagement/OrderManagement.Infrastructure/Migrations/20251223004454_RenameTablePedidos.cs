using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameTablePedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_pedidos",
                table: "pedidos");

            migrationBuilder.RenameTable(
                name: "pedidos",
                newName: "tblPedidos");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "tblPedidos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblPedidos",
                table: "tblPedidos",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblPedidos",
                table: "tblPedidos");

            migrationBuilder.RenameTable(
                name: "tblPedidos",
                newName: "pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "pedidos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_pedidos",
                table: "pedidos",
                column: "id");
        }
    }
}
