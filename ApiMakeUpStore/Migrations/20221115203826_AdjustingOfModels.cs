using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMakeUpStore.Migrations
{
    public partial class AdjustingOfModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PHOTO_PRODUCT",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "QUANTITY_PRODUCT",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QUANTITY_PRODUCT",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "PHOTO_PRODUCT",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
