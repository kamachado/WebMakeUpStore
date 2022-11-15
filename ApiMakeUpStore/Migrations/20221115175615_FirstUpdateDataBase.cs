using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMakeUpStore.Migrations
{
    public partial class FirstUpdateDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID_BRAND = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME_BRAND = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COUNTRY_BRAND = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID_BRAND);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID_PRODUCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME_PRODUCT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Brand = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION_PRODUCT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TYPE_PRODUCT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BODYPART_PRODUCT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRICE_PRODUCT = table.Column<double>(type: "float", nullable: false),
                    PHOTO_PRODUCT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID_PRODUCT);
                    table.ForeignKey(
                        name: "FK_Product_Brand_ID_Brand",
                        column: x => x.ID_Brand,
                        principalTable: "Brand",
                        principalColumn: "ID_BRAND",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ID_Brand",
                table: "Product",
                column: "ID_Brand");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
