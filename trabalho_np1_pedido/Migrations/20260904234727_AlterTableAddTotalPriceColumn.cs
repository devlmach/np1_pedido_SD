using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trabalho_np1_pedido.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableAddTotalPriceColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalOrderPrice",
                table: "Orders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalOrderPrice",
                table: "Orders");
        }
    }
}
