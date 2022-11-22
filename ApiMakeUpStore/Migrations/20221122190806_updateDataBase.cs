using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMakeUpStore.Migrations
{
    public partial class updateDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PHOTO_PRODUCT",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION_PRODUCT",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION_PRODUCT",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PHOTO_PRODUCT",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
