using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingIt.Crm.Infrastructure.Migrations
{
    public partial class addsalestosalesitemsrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalItems",
                table: "Sale",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalItems",
                table: "Sale");
        }
    }
}
